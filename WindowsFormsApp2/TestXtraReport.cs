using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UNILOG.LIP.Business;

//namespace WindowsFormsApp2
//{
//    public partial class TestXtraReport : DevExpress.XtraReports.UI.XtraReport
//    {
//        public TestXtraReport()
//        {
//            InitializeComponent();
//        }
//        public TestXtraReport(DcEpDecHead head)
//        {
//            InitializeComponent();
//            try
//            {
//                //this.DataSource = head;
//                this.bindingSource1.DataSource =head;
//            }
//            catch (Exception ex)
//            {

//            }
//        } 
//    }
//}

using System.Linq;
using DevExpress.XtraPrinting.Drawing;
using System.Collections.Generic;

namespace WindowsFormsApp2
{
    public partial class TestXtraReport : DevExpress.XtraReports.UI.XtraReport
    {
        public TestXtraReport()
        {
            InitializeComponent();
        }
        //明细数量
        private DcEpDecDtlList dtlList = DcEpDecDtlList.NewList();
        //行数
        private List<int> totalRow = new List<int>();
        int dtlUnitNum = 0;
        int RowNum = 0;
        int NoteNum = 0;
        public TestXtraReport(DcEpDecHead head)
        {
            if (head.DcPreAcceptanceMember == null)
            {
                throw new Exception("没有接单，无法打印");
            }

            InitializeComponent();
            if (head.DcEpDecContainers.Count > 0)
            {
                int strDecContainerModel = 0; string strDec = "";
                foreach (var anItem in head.DcEpDecContainers)
                {
                    strDecContainerModel += Convert.ToInt16(anItem.DecContainerModel);
                }

                strDec = head.DcEpDecContainers.Count + "(" + strDecContainerModel + ")";

                head.MvcDcEpDecContainerCountDisplay = strDec;

                var datad = (from a in head.DcEpDecContainers
                             group a by new { a.DecContainerNo } into b
                             select new
                             {
                                 DecContainerNo = b.Key.DecContainerNo
                             });
                string strDecContainerNo = "";
                foreach (var anItem in datad)
                {
                    strDecContainerNo += anItem.DecContainerNo + ";";
                }
                head.MvcDcEpDecDecContainerNoDisplay = strDecContainerNo.TrimEnd(';');
            }

            if (head.DcEpDecCerts.Count > 0)
            {
                var datac = (from a in head.DcEpDecCerts
                             group a by new { a.DdcDocuCode } into b
                             select new
                             {
                                 DdcDocuCode = b.Key.DdcDocuCode
                             });
                string strDdcDocuCode = "";
                foreach (var anItem in datac)
                {
                    strDdcDocuCode += anItem.DdcDocuCode + ";";
                }
                head.MvcDcEpDecEdocrelationDisplay = strDdcDocuCode.TrimEnd(';');
            }
            if (!string.IsNullOrEmpty(head.DehTradeAreaCode.ToStringNoNull()))
            {
                var list = DcBasCountryList.Fetch(new DcBasCountryCriteria { DbtKey = head.DehTradeAreaCode });
                if (list.Count > 0)
                    head.MvcDehTradeAreaCode = list[0].DbtNm;//贸易国别
            }
            xrluserinfo.Text = head.DcPreAcceptanceMember.DpaUserInfo.IsNullOrEmpty() ? head.DehUserInfo : head.DcPreAcceptanceMember.DpaUserInfo;//设备号
            if (head.DcEpDecDtls.Count > 0)
            {
                int number = 1;
                #region 计算总价和数量
                //成交币制
                var dedtotalMes = head.DcEpDecDtls.GroupBy(a => a.DedTradeCurr).ToList();
                //申报单位
                var dedmess = head.DcEpDecDtls.GroupBy(a => a.DedGUnit).ToList();
                //法定单位
                var dedfa = head.DcEpDecDtls.GroupBy(a => a.DedUnit1).ToList();
                if (dedfa.Count > 0)
                {
                    string num = "";//法定数量加法定单位
                    string m = "";//法定单位
                    for (int i = 0; i < dedfa.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(dedfa[i].Key.ToStringNoNull()))
                        {
                            var list = DcBasMeasurementUnitList.Fetch(new DcBasMeasurementUnitCriteria { DmuCd = dedfa[i].Key });
                            if (list.Count > 0)
                            {
                                m = list[0].DmuNm;//币制
                            }
                            else
                            {
                                m = "\t\n";
                            }
                        }
                        else
                        {
                            m = "\t\n";
                        }
                        num += Convert.ToDouble(head.DcEpDecDtls.Where(a => a.DedUnit1 == dedfa[i].Key).Sum(a => a.DedQty1)).ToString("0.0000") + "\t\n" + m + ";";
                    }
                    //法定数量总和
                    //xrlTotalFaGoodsNum.Text = num;
                }
                if (dedmess.Count > 0)
                {
                    string num = "";//申报数量加申报单位
                    string m = "";//申报单位
                    for (int i = 0; i < dedmess.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(dedmess[i].Key.ToStringNoNull()))
                        {
                            var list = DcBasMeasurementUnitList.Fetch(new DcBasMeasurementUnitCriteria { DmuCd = dedmess[i].Key });
                            if (list.Count > 0)
                            {
                                m = list[0].DmuNm;//币制
                            }
                            else
                            {
                                m = "\t\n";
                            }
                        }
                        else
                        {
                            m = "\t\n";
                        }
                        num += Convert.ToDouble(head.DcEpDecDtls.Where(a => a.DedGUnit == dedmess[i].Key).Sum(a => a.DedGQty)).ToString("0.0000") + "\t\n" + m + ";";
                    }
                    //申报数量总和
                    // xrlTotalGoodsNum.Text = num;
                }
                if (dedtotalMes.Count > 0)
                {
                    string mess = "";//不同币值的总价和币值信息
                    string m = "";//币值
                    for (int i = 0; i < dedtotalMes.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(dedtotalMes[i].Key.ToStringNoNull()))
                        {
                            var list = DcBasCurrencyList.Fetch(new DcBasCurrencyCriteria { DbcKey = dedtotalMes[i].Key });
                            if (list.Count > 0)
                            {
                                m = list[0].DbcNm;//币制
                            }
                            else
                            {
                                m = "\t\n";
                            }
                        }
                        else
                        {
                            m = "\t\n";
                        }
                        mess += Convert.ToDouble(head.DcEpDecDtls.Where(a => a.DedTradeCurr == dedtotalMes[i].Key).Sum(a => a.DedTradeTotal)).ToString("0.00") + "\t\n" + m + ";";
                    }
                    //总价
                    xrlTotalGoodsPrice.Text = mess.TrimEnd(';');
                }
                #endregion
                var s = head.DcEpDecDtls.Sum(a => a.DedTradeTotal);
                foreach (var x in head.DcEpDecDtls)
                {
                    x.MvcNumber = number;
                    number++;
                    if (x.MvcNumber == 0) { xrLabel3.Text = ""; }
                    #region 翻译
                    if (!string.IsNullOrEmpty(x.DedOriginCountry.ToStringNoNull()))
                    {
                        var list = DcBasCountryList.Fetch(new DcBasCountryCriteria { DbtKey = x.DedOriginCountry });
                        if (list.Count > 0)
                            x.MvcDedOriginCountry = list[0].DbtNm;//产销国
                    }
                    if (!string.IsNullOrEmpty(head.DehTradeCountry.ToStringNoNull()))
                    {
                        var list = DcBasCountryList.Fetch(new DcBasCountryCriteria { DbtKey = head.DehTradeCountry });
                        if (list.Count > 0)
                            x.MvcDedTradeCountryDtl = list[0].DbtNm;//运抵国
                    }
                    if (!string.IsNullOrEmpty(x.DedOriginCountry.ToStringNoNull()))
                    {
                        var list = DcBasCountryList.Fetch(new DcBasCountryCriteria { DbtKey = x.DedOriginCountry });
                        if (list.Count > 0)
                            x.MvcDedOriginCountry = list[0].DbtNm;//目的国
                    }
                    if (!string.IsNullOrEmpty(x.DedDestinationCountry.ToStringNoNull()))
                    {
                        var list = DcBasCountryList.Fetch(new DcBasCountryCriteria { DbtKey = x.DedDestinationCountry });
                        if (list.Count > 0)
                            x.MvcDedDestinationCountry = list[0].DbtNm;//原产国
                    }
                    if (!string.IsNullOrEmpty(head.DehTradeCountry.ToStringNoNull()))
                    {
                        x.MvcDedTradeCountryDtlCode = head.DehTradeCountry;//运抵国代码
                    }
                    if (!string.IsNullOrEmpty(x.DedTradeCurr.ToStringNoNull()))
                    {
                        var list = DcBasCurrencyList.Fetch(new DcBasCurrencyCriteria { DbcKey = x.DedTradeCurr });
                        if (list.Count > 0)
                        {
                            x.MvcDedTradeCurr = list[0].DbcNm;//币制
                            x.MvcDedTradeE = list[0].DbcCd;//币制代码
                        }
                    }
                    if (!string.IsNullOrEmpty(x.DedGUnit.ToStringNoNull()))
                    {
                        var list = DcBasMeasurementUnitList.Fetch(new DcBasMeasurementUnitCriteria { DmuCd = x.DedGUnit });
                        if (list.Count > 0)
                            x.MvcDedGUnit = list[0].DmuNm;//申报单位
                    }
                    if (!string.IsNullOrEmpty(x.DedUnit1.ToStringNoNull()))
                    {
                        var list = DcBasMeasurementUnitList.Fetch(new DcBasMeasurementUnitCriteria { DmuCd = x.DedUnit1 });
                        if (list.Count > 0)
                            x.MvcDedUnit1 = list[0].DmuNm;//法定单位
                    }
                    if (!string.IsNullOrEmpty(x.DedUnit2.ToStringNoNull()))
                    {
                        var list = DcBasMeasurementUnitList.Fetch(new DcBasMeasurementUnitCriteria { DmuCd = x.DedUnit2 });
                        if (list.Count > 0)
                            x.MvcDedUnit2 = list[0].DmuNm;//第二单位
                    }
                    if (!string.IsNullOrEmpty(x.DedDutyMode.ToStringNoNull()))
                    {
                        var list = DcBasFreedutyTypeList.Fetch(new DcBasFreedutyTypeCriteria { DftCd = x.DedDutyMode });
                        if (list.Count > 0)
                            x.MvcDedDutyMode = list[0].DftNm;//征免方式
                    }
                    #endregion
                }
                //重新排序
                var sortList = head.DcEpDecDtls.OrderBy(x => x.DedGNo).ToList();
                head.DcEpDecDtls = DcEpDecDtlList.NewList();
                //每条明细的行数
                totalRow = new List<int>();
                #region 按单位统计
                string UnitTotals = "";
                var dtlUnitList = new List<DtlUnit>();
                for (int i = 0; i < sortList.Count; i++)
                {
                    foreach (var item in dtlUnitList)
                    {
                        item.flag = false;
                    }
                    //申报单位
                    if (!sortList[i].MvcDedGUnit.IsNullOrEmpty())
                    {
                        var dltUnit = dtlUnitList.FirstOrDefault(x => x.Unit == sortList[i].MvcDedGUnit);
                        if (dltUnit == null)
                        {
                            var newUnit = new DtlUnit();
                            newUnit.Unit = sortList[i].MvcDedGUnit;
                            newUnit.Amount = sortList[i].DedGQty ?? 0;
                            newUnit.flag = true;
                            dtlUnitList.Add(newUnit);
                        }
                        else
                        {
                            dltUnit.Amount += sortList[i].DedGQty ?? 0;
                            dltUnit.flag = true;
                        }
                    }
                    //法定单位
                    if (!sortList[i].MvcDedUnit1.IsNullOrEmpty())
                    {
                        var dltUnit = dtlUnitList.FirstOrDefault(x => x.Unit == sortList[i].MvcDedUnit1);
                        if (dltUnit == null)
                        {
                            var newUnit = new DtlUnit();
                            newUnit.Unit = sortList[i].MvcDedUnit1;
                            newUnit.Amount = sortList[i].DedQty1 ?? 0;
                            dtlUnitList.Add(newUnit);
                        }
                        else
                        {
                            if (!dltUnit.flag)
                            {
                                dltUnit.Amount += sortList[i].DedQty1 ?? 0;
                            }
                        }
                    }
                    //第二单位
                    if (!sortList[i].MvcDedUnit2.IsNullOrEmpty())
                    {
                        var dltUnit = dtlUnitList.FirstOrDefault(x => x.Unit == sortList[i].MvcDedUnit2);
                        if (dltUnit == null)
                        {
                            var newUnit = new DtlUnit();
                            newUnit.Unit = sortList[i].MvcDedUnit2;
                            newUnit.Amount = sortList[i].DedQty2 ?? 0;
                            dtlUnitList.Add(newUnit);
                        }
                        else
                        {
                            if (!dltUnit.flag)
                            {
                                dltUnit.Amount += sortList[i].DedQty2 ?? 0;
                            }
                        }
                    }
                #endregion
                    //行数
                    int total = 0;
                    sortList[i].MvcNumber = i + 1;
                    //规格型号
                    if (!sortList[i].DedGModel.IsNullOrEmpty())
                    {
                        total = 1;
                        var DedGModel = sortList[i].DedGModel;
                        var newModel = "";
                        int num = 0;
                        try
                        {
                            for (int j = 0; j < DedGModel.Length; j++)
                            {
                                if (CharHelper.isChinese(DedGModel[j]))
                                {
                                    num += 2;
                                }
                                else
                                {
                                    num++;
                                }
                                //一行最多26个非中文字符
                                if (num > 26)
                                {
                                    total++;
                                    num = 1;
                                    newModel += "\r\n" + DedGModel[j];
                                }
                                else if (num == 26 && (j != DedGModel.Length - 1))
                                {
                                    num = 0;
                                    newModel += DedGModel[j] + "\r\n";
                                    total++;
                                }
                                else
                                {
                                    newModel += DedGModel[j];
                                }
                            }

                            sortList[i].DedGModel = newModel.ToString();//"123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890";//
                        }
                        catch (Exception ex)
                        {

                        }

                    }
                    else
                    {
                        total = 0;
                    }
                    //商品名称
                    if (!sortList[i].DedGName.IsNullOrEmpty())
                    {
                        total++;
                        var DedGName = sortList[i].DedGName;
                        var newName = "";
                        int num = 0;
                        try
                        {
                            for (int j = 0; j < DedGName.Length; j++)
                            {
                                if (CharHelper.isChinese(DedGName[j]))
                                {
                                    num += 2;
                                }
                                else
                                {
                                    num++;
                                }
                                //一行最多26个非中文字符
                                if (num > 26)
                                {
                                    total++;
                                    num = 1;
                                    newName += "\r\n" + DedGName[j];
                                }
                                else if (num == 26 && (j != DedGName.Length - 1))
                                {
                                    total++;
                                    num = 0;
                                    newName += DedGName[j] + "\r\n";
                                }
                                else
                                {
                                    newName += DedGName[j];
                                }
                            }
                            sortList[i].DedGName = newName;
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                    totalRow.Add(total);
                    head.DcEpDecDtls.Add(sortList[i]);
                }
                if (dtlUnitList.Count > 0)
                {
                    for (int i = 0; i < dtlUnitList.Count; i++)
                    {
                        var str = string.Format("{0:0.0000}", dtlUnitList[i].Amount) + dtlUnitList[i].Unit;
                        if ((i + 1) == 1)
                        {
                            UnitTotal1.Text = str;
                        }
                        else if ((i + 1) == 2)
                        {
                            UnitTotal2.Text = str;
                        }
                        else if ((i + 1) == 3)
                        {
                            UnitTotal3.Text = str;
                        }
                        else if ((i + 1) == 4)
                        {
                            UnitTotal4.Text = str;
                        }
                        else if ((i + 1) == 5)
                        {
                            UnitTotal5.Text = str;
                        }
                        else if ((i + 1) == 6)
                        {
                            UnitTotal6.Text = str;
                        }
                        else if ((i + 1) == 7)
                        {
                            UnitTotal7.Text = str;
                        }
                        else if ((i + 1) == 8)
                        {
                            UnitTotal8.Text = str;
                        }
                        else if ((i + 1) == 9)
                        {
                            UnitTotal9.Text = str;
                        }
                        else if ((i + 1) == 10)
                        {
                            UnitTotal10.Text = str;
                        }
                        else if ((i + 1) == 11)
                        {
                            UnitTotal11.Text = str;
                        }
                        else if ((i + 1) == 12)
                        {
                            UnitTotal12.Text = str;
                        }
                        else if ((i + 1) == 13)
                        {
                            UnitTotal13.Text = str;
                        }
                        else if ((i + 1) == 14)
                        {
                            UnitTotal14.Text = str;
                        }
                        else if ((i + 1) == 15)
                        {
                            UnitTotal15.Text = str;
                        }
                        else if ((i + 1) == 16)
                        {
                            UnitTotal16.Text = str;
                        }
                        if ((i + 1) > 16)
                        {
                            UnitTotals += string.Format("{0:0.0000}", dtlUnitList[i].Amount) + dtlUnitList[i].Unit + " / ";
                        }
                    }

                    UnitTotals = UnitTotals.TrimEnd(" / ".ToCharArray());
                    UnitTotalsLabel.Text = UnitTotals;
                    int unitNum = 0;
                    unitNum = Math.Ceiling(dtlUnitList.Count.ToDouble() / 4).ToInt();
                    if (unitNum > 4)
                    {
                        int num = 0;
                        for (int j = 0; j < UnitTotals.Length; j++)
                        {
                            if (CharHelper.isChinese(UnitTotals[j]))
                            {
                                num += 2;
                            }
                            else
                            {
                                num++;
                            }
                        }
                        dtlUnitNum -= Math.Ceiling(num.ToDouble() / 70).ToInt();
                    }
                    else
                    {
                        dtlUnitNum = 4 - unitNum;
                    }
                }
                else
                {
                    dtlUnitNum += 4;
                }
                dtlList = head.DcEpDecDtls;
                //for (int numbers = head.DcEpDecDtls.Count; numbers < 5; numbers++)
                //{
                //    head.DcEpDecDtls.AddNew();
                //}
            }
            #region 翻译
            //单证类型(有纸通关无纸.)
            if (!string.IsNullOrWhiteSpace(head.DehDecType))
            {
                DcBasDecType dectype = DcBasDecType.Fetch(new DcBasDecTypeCriteria { DdtDecCode = head.DehDecType });
                if (dectype != null)
                {
                    head.MvcDehDecName = dectype.DdtDecName;
                }
            }
            if (!string.IsNullOrEmpty(head.Inputer))
            {
                BasWorkerList list = BasWorkerList.Fetch(new BasWorkerCriteria { BwkCd = head.Inputer, SysCustomerCd = CurrentWorkerInfo.SysCustomerCd });
                if (list.Count > 0)
                    head.MvcInputer = list[0].BwkNm;
            }
            string DbcTradeCo = "";
            if (head.DehTradeCo.ToStringNoNull().Length > 6)
            {
                DbcTradeCo = head.DehTradeCo.Substring(5, 1);
                DcBasEnterpriseProperty property = DcBasEnterpriseProperty.Find(new DcBasEnterprisePropertyCriteria { DepCd = DbcTradeCo });
                head.MvcDehTradeNatureDisplay = property.DepNm;
            }
            if (!string.IsNullOrEmpty(head.DehIEPort.ToStringNoNull()))
            {
                var list = DcBasGuanquList.Fetch(new DcBasGuanquCriteria { DbgCd = head.DehIEPort });
                if (list.Count > 0)
                    head.MvcDehIEPortDisplay = list[0].DbgNm;//出口口岸
            }
            if (!string.IsNullOrEmpty(head.DehApplyPort.ToStringNoNull()))
            {
                var list = DcBasGuanquList.Fetch(new DcBasGuanquCriteria { DbgCd = head.DehApplyPort });
                if (list.Count > 0)
                    head.MvcDehApplyPort = list[0].DbgNm;//申报口岸
            }
            if (!string.IsNullOrEmpty(head.DehTradeMode.ToStringNoNull()))
            {
                var list = DcBasTradeTypeList.Fetch(new DcBasTradeTypeCriteria { DttCd = head.DehTradeMode });
                if (list.Count > 0)
                    head.MvcDehTradeMode = list[0].DttNm;//贸易方式
            }
            if (!string.IsNullOrEmpty(head.DehCutMode.ToStringNoNull()))
            {
                var list = DcBasFreedutyPropertyList.Fetch(new DcBasFreedutyPropertyCriteria { DfpCd = head.DehCutMode });
                if (list.Count > 0)
                    head.MvcDehCutMode = list[0].DfpNm;//征免性质
            }
            if (!string.IsNullOrEmpty(head.DehTransMode.ToStringNoNull()))
            {
                var list = DcBasTransactionTypeList.Fetch(new DcBasTransactionTypeCriteria { DttCd = head.DehTransMode });
                if (list.Count > 0)
                    head.MvcDehTransMode = list[0].DttNm;//成交方式
            }
            if (!string.IsNullOrEmpty(head.DehPayWay.ToStringNoNull()))
            {
                var list = DcBasExchangeSettlementList.Fetch(new DcBasExchangeSettlementCriteria { BesCd = head.DehPayWay });
                if (list.Count > 0)
                    head.MvcDehPayWay = list[0].BesNm;//结汇方式
            }
            if (!string.IsNullOrEmpty(head.DehDistrictCode.ToStringNoNull()))
            {
                var list = DcBasChinaAreaList.Fetch(new DcBasChinaAreaCriteria { DcaCd = head.DehDistrictCode });
                if (list.Count > 0)
                    head.MvcDehDistrictCode = list[0].DcaNm;//境内货源地
            }
            if (!string.IsNullOrEmpty(head.DehWrapType.ToStringNoNull()))
            {
                var list = DcBasWrapCodeList.Fetch(new DcBasWrapCodeCriteria { DwcWrapCode = head.DehWrapType });
                if (list.Count > 0)
                    head.MvcDehWrapType = list[0].DwcWrapName;//包装种类
            }
            if (!string.IsNullOrEmpty(head.DehTrafMode.ToStringNoNull()))
            {
                var list = DcBasTransportTypeList.Fetch(new DcBasTransportTypeCriteria { DbtCd = head.DehTrafMode });
                if (list.Count > 0)
                    head.MvcDehTrafModeDisplay = list[0].DbtNm;//运输方式
            }
            if (!string.IsNullOrEmpty(head.DehTradeCountry.ToStringNoNull()))
            {
                var list = DcBasCountryList.Fetch(new DcBasCountryCriteria { DbtKey = head.DehTradeCountry });
                if (list.Count > 0)
                    head.MvcDehTradeCountry = list[0].DbtNm;//运抵国地区
            }
            if (!string.IsNullOrEmpty(head.DehDistinatePort.ToStringNoNull()))
            {
                var list = DcBasPortList.Fetch(new DcBasPortCriteria { DbpCd = head.DehDistinatePort });
                if (list.Count > 0)
                    head.MvcDehDistinatePort = list[0].DbpNm;//指运港
            }
            if (!string.IsNullOrEmpty(head.DehDistrictCode.ToStringNoNull()))
            {
                var list = DcBasChinaAreaList.Fetch(new DcBasChinaAreaCriteria { DcaCd = head.DehDistrictCode });
                if (list.Count > 0)
                    head.MvcDehDistrictCode = list[0].DcaNm;//货主单位地区代码
            }
            #region 运保杂如果为空则不显示任何东西 2017-07-31
            //if (head.DehFeeCurr == null)
            //{
            //    head.MvcDehFeeCurrStr = "000/" + head.DehFeeRate + "/" + head.DehFeeMark;
            //}
            //else
            //    head.MvcDehFeeCurrStr = head.DehFeeCurr + "/" + head.DehFeeRate + "/" + head.DehFeeMark;
            //if (head.DehInsurCurr == null)
            //{
            //    head.MvcDehInsurCurrStr = "000/" + head.DehInsurRate + "/" + head.DehInsurMark;
            //}
            //else
            //    head.MvcDehInsurCurrStr = head.DehInsurCurr + "/" + head.DehInsurRate + "/" + head.DehInsurMark;

            //if (head.DehOtherCurr == null)
            //{
            //    head.MvcDehOtherCurrStr = "000/" + head.DehOtherRate + "/" + head.DehOtherMark;
            //}
            //else
            //    head.MvcDehOtherCurrStr = head.DehOtherCurr + "/" + head.DehOtherRate + "/" + head.DehOtherMark;
            #endregion
            #region 运保杂不为空显示值
            if (!string.IsNullOrWhiteSpace(head.DehFeeCurr))
            {
                head.MvcDehFeeCurrStr = head.DehFeeCurr + "/" + head.DehFeeRate + "/" + head.DehFeeMark;
            }
            if (!string.IsNullOrWhiteSpace(head.DehInsurCurr))
            {
                head.MvcDehInsurCurrStr = head.DehInsurCurr + "/" + head.DehInsurRate + "/" + head.DehInsurMark;
            }
            if (!string.IsNullOrWhiteSpace(head.DehOtherCurr))
            {
                head.MvcDehOtherCurrStr = head.DehOtherCurr + "/" + head.DehOtherRate + "/" + head.DehOtherMark;
            }
            #endregion
            head.DehTrafName = head.DehTrafName + @"/" + head.DehVoyageNo;
            #endregion
            //string decContainerNo="";
            //foreach (var x in head.DcEpDecContainers)
            //{
            //    decContainerNo += x.DecContainerNo + ",";
            //}

            //head.DehMemo = head.DehMemo + "  集装箱号:" + decContainerNo.TrimEnd(','); 
            string decContainerNo = "", decEdocrelation = "";
            foreach (var x in head.DcEpDecContainers)
            {
                decContainerNo += x.DecContainerNo + ",";
            }
            foreach (var y in head.DcEpDecCerts)
            {
                decEdocrelation += y.DdcDocuCode + ":" + y.DdcCertCode + ",";
            }
            if (decContainerNo == "" && decEdocrelation != "")
            {
                head.DehMemo = head.DehNoteS + "\n随附单证号:" + decEdocrelation.TrimEnd(',');
            }
            else if (decEdocrelation == "" && decContainerNo != "")
            {
                head.DehMemo = head.DehNoteS + "\n集装箱号:" + decContainerNo.TrimEnd(',');
            }
            else if (decContainerNo != "" && decEdocrelation != "")
            {
                head.DehMemo = head.DehNoteS + "\n集装箱号:" + decContainerNo.TrimEnd(',') + "\n随附单证号:" + decEdocrelation.TrimEnd(',');
            }
            else
            {
                head.DehMemo = head.DehNoteS;
            }
            head.DehMemo = head.DehMemo.TrimStart('\n');
            //计算备注行数
            var noteArr = (head.DehMemo ?? "").Split('\n');
            if (noteArr != null && noteArr.Length > 0)
            {
                for (int i = 0; i < noteArr.Length; i++)
                {
                    int num = 0;
                    for (int j = 0; j < noteArr[i].Length; j++)
                    {
                        if (CharHelper.isChinese(noteArr[i][j]))
                        {
                            num += 2;
                        }
                        else
                        {
                            num++;
                        }

                    }
                    NoteNum += Math.Ceiling(num.ToDouble() / 90).ToInt();
                }
            }
            else
            {
                NoteNum = 2;
            }
            //head.DehMemo = head.DehNoteS + "\n集装箱号:" + decContainerNo.TrimEnd(',') + "\n随附单证号:" + decEdocrelation.TrimEnd(',');
            this.bindingSource1.DataSource = head;
            //XtraReport report = new XtraReport();
            //SetTextWatermark(report);
        }
        //int RecordCount = 0; //累加每页的记录数
        //明细序号
        int dtlcount = 0;
        //一页可以放下的行数
        double sumrow = 0;
        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (dtlList.Count == 0)
            {
                return;
            }
            //var gmodel = dtlList[dtlcount].DedGModel;
            sumrow += (totalRow[dtlcount] < 3 ? 3 : totalRow[dtlcount]);
            if (dtlcount < dtlList.Count - 1)
            {
                //最多放22行
                var totals = (RowNum != 0 ? RowNum : 18) + dtlUnitNum - ((NoteNum < 2 ? 2 : NoteNum) - 2);
                if ((sumrow + totalRow[dtlcount + 1]) > (totals < 9 ? 9 : totals))
                {
                    sumrow = 0;
                    Detail.PageBreak = PageBreak.AfterBand;
                }
                else
                {
                    Detail.PageBreak = PageBreak.None;
                }
            }
            //double len = 0;
            ////RecordCount += 1;
            ////明细一页最多三条，一条规格型号最多60个字符
            //if (gmodel != null)
            //{
            //    len = gmodel.Length;
            //}
            //sum += len / 100 < 1 ? 1 : len / 100;
            //if (sum >= 3)//每页打3条记录(美设无底纹打印)
            //{
            //    Detail.PageBreak = PageBreak.AfterBand;
            //    sum = 0;
            //}
            //else
            //{
            //    Detail.PageBreak = PageBreak.None;
            //}
            ////如果下一页无法容纳，则分页
            //if (sum != 0 && (dtlcount + 1) < dtlList.Count)
            //{
            //    var gmodelNext = dtlList[dtlcount + 1].DedGModel;
            //    double lenNext = 0;
            //    if (gmodelNext != null)
            //    {
            //        lenNext = gmodelNext.Length;
            //    }
            //    double num = (lenNext / 100 < 1 ? 1 : lenNext / 100) + sum;
            //    if (num > 3)
            //    {
            //        Detail.PageBreak = PageBreak.AfterBand;
            //        sum = 0;
            //    }
            //}
            dtlcount++;

        }
    }
    /// <summary>
    /// 标记单位数量
    /// </summary>
    class DtlUnit
    {
        public string Unit { get; set; }
        public double Amount { get; set; }
        public bool flag { get; set; }
    }
    public static class CharHelper
    {
        /// <summary>
        /// 判断是不是中文
        /// </summary>
        /// <param name="ch"></param>
        /// <returns></returns>
        public static bool isChinese(char ch)
        {
            if ((int)ch > 127)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
