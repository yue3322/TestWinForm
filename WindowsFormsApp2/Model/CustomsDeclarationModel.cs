using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2.Model
{
    #region 根据经营单位查询
    public class CustomsDeclarationResult
    {
       
        public CustomsDeclarationResult()
        {
            CustomsDeclarationInfo = new List<CustomsDeclarationServiceModel>();
        }
        public bool Success { get; set; }
        public string Message { get; set; }
        public string count { get; set; }
        public List<CustomsDeclarationServiceModel> CustomsDeclarationInfo { get; set; }
    }
    public class CustomsDeclarationServiceModel
    {
        //<column name="EntryNo"  visible="报关单号"/>
        //<column name="DeclData"  caption="申报日期"/>
        //<column name="IEFlag"  caption="进出口标识"/>
        //<column name="OWNERName"  caption="收货单位"/>
        //<column name="IEPort"  caption="进出口岸"/>
        //<column name="RecordNo"  caption="备案号"/>
        //<column name="BillNo"  caption="提单号"/>
        //<column name="PackagesNo"  caption="件数"/>
        //<column name="GrossWeight"  caption="毛重"/>
        //<column name="NetWeight"  caption="净重"/>
        public string EntryNo { get; set; }
        public string DeclData { get; set; }
        public string IEFlag { get; set; }
        public string OWNERName { get; set; }
        public string IEPort { get; set; }
        public string RecordNo { get; set; }
        public string BillNo { get; set; }
        public string PackagesNo { get; set; }
        public string GrossWeight { get; set; }
        public string NetWeight { get; set; }
    }
    #endregion
    #region 根据经营单位和报关单号查询
    public class CustomsDeclarationModelResult
    {
        public CustomsDeclarationModelResult()
        {
            model = new CustomsDeclarationModel();
        }
        public bool Success { get; set; }
        public string Message { get; set; }
        // public string count { get; set; }
        public CustomsDeclarationModel model { get; set; }
    }
    public class CustomsDeclarationModel
    {
        public CustomsDeclarationModel()
        {
            dtlList = new List<CustomsDeclarationDtl>();
        }
        #region
        public List<CustomsDeclarationDtl> dtlList { get; set; }
        public string MvcDehIEPortDisplay { get; set; }
        public string MvcDehApplyPort { get; set; }
        public string MvcDehTradeNatureDisplay { get; set; }
        public string MvcDehTrafModeDisplay { get; set; }
        public string MvcDcEpDecContainerCountDisplay { get; set; }//集装箱数(DcEpDecContainer表算出来的)
        public string MvcDcEpDecEdocrelationDisplay { get; set; }//随附单据(DcEpDecEdocrelation表中代码集合)
        public string MvcDcEpDecDecContainerNoDisplay { get; set; }//集装箱数合计(DcEpDecDecContainer表中代码集合)
        public string MvcUsoJobNo { get; set; }
        public string MvcUsoClientNo { get; set; }//业务编号(美设)
        public string MvcUesSendCode { get; set; }
        public string MvcUesEdiCode { get; set; }
        public string MvcDehTradeMode { get; set; }//贸易方式全称
        public string MvcDehTradeAbbreviationMode { get; set; }//贸易方式简称
        public string MvcDehCutMode { get; set; }
        public string MvcDehTransMode { get; set; }
        public string MvcDehPayWay { get; set; }
        public string MvcDehEurope { get; set; }
        public string MvcDehWrapType { get; set; }
        /// <summary>
        /// 运费类型
        /// </summary>
        public string MvcDehFeeMark { get; set; }
        public string MvcDehFeeCurr { get; set; }
        /// <summary>
        /// 保费类型
        /// </summary>
        public string MvcDehInsurMark { get; set; }
        public string MvcDehInsurCurr { get; set; }
        /// <summary>
        /// 杂费类型
        /// </summary>
        public string MvcDehOtherMark { get; set; }
        public string MvcDehOtherCurr { get; set; }
        public string MvcDehFeeCurrStr { get; set; }//用于报表显示字段运费
        public string MvcDehInsurCurrStr { get; set; }//保费
        public string MvcDehOtherCurrStr { get; set; }//杂费
        public string MvcDehTradeCountry { get; set; }
        public string MvcDehDistinatePort { get; set; }
        public string MvcDehDistrictCode { get; set; }
        public string MvcDcEpDecResultStates { get; set; }
        public string MvcDehPrinter { get; set; }
        public string MvcInputer { get; set; }
        public string MvcDehChecker { get; set; }
        public string MvcDehReChecker { get; set; }
        public bool IsCreate { get; set; }
        public int MvcSaveflag { get; set; }//是否继续保持参数
        /// <summary>
        /// 是否特殊关系确认
        /// </summary>
        public string MvcDehSpecRelConfir
        { get; set; }
        /// <summary>
        /// 是否支付特许权使用费确认
        /// </summary>
        public string MvcDehPayOfLicenFees { get; set; }
        /// <summary>
        /// 是否价格影响确认
        /// </summary>
        public string MvcDehPriceConfir { get; set; }
        /// <summary>
        /// 贸易国别
        /// </summary>
        public string MvcDehTradeAreaCode { get; set; }
        /// <summary>
        /// 当前日期字符串（年月日）
        /// </summary>
        public string NowTimeStr
        { get; set; }
        /// <summary>
        /// 进出口日期（年月日）
        /// </summary>
        public string MvcDehIEDate
        { get; set; }
        /// <summary>
        /// 申报日期（yyyy年MM月dd日）
        /// </summary>
        public string MvcDehDDate
        { get; set; }
        /// <summary>
        /// 单证类型翻译字段
        /// </summary>
        public string MvcDehDecName { get; set; }
        #endregion
        public System.String DehTradeCo { get; set; }

        public System.String DehTradeName { get; set; }

        public System.String DehDistrictCode { get; set; }

        public System.String DehOwnerCode { get; set; }

        public System.String DehOwnerName { get; set; }

        public System.String DehAgentCode { get; set; }

        public System.String DehAgentName { get; set; }

        public System.String DehTrafMode { get; set; }

        public System.String DehIEPort { get; set; }

        public System.String DehDistinatePort { get; set; }

        public System.String DehTrafName { get; set; }

        public System.String DehContrNo { get; set; }

        public System.Double? DehInRatio { get; set; }

        public System.String DehBillNo { get; set; }

        public System.String DehTradeCountry { get; set; }

        public System.String DehTradeMode { get; set; }

        public System.String DehCutMode { get; set; }

        public System.String DehPayMode { get; set; }

        public System.String DehTransMode { get; set; }

        public System.String DehPayWay { get; set; }

        public System.String DehFeeMark { get; set; }

        public System.String DehFeeCurr { get; set; }

        public System.Double? DehFeeRate { get; set; }

        public System.String DehOtherMark { get; set; }

        public System.String DehOtherCurr { get; set; }

        public System.Double? DehOtherRate { get; set; }

        public System.String DehInsurMark { get; set; }

        public System.String DehInsurCurr { get; set; }

        public System.Double? DehInsurRate { get; set; }

        public System.Double? DehPackNo { get; set; }

        public System.Double? DehGrossWt { get; set; }

        public System.Double? DehNetWt { get; set; }

        public System.String DehLicenseNo { get; set; }

        public System.String DehApprNo { get; set; }

        public System.String DehManualNo { get; set; }

        public System.DateTime? DehIEDate { get; set; }

        public System.String DehWrapType { get; set; }

        public System.String DehNoteS { get; set; }

        public System.DateTime? DehDDate { get; set; }

        public System.String DehExSource { get; set; }

        public System.String DehVoyageNo { get; set; }

        public System.String DehIeFlag { get; set; }

        public System.String DehPrdtid { get; set; }

        public System.String DehStoreno { get; set; }

        public System.String DehRamanualno { get; set; }

        public System.String DehRadeclno { get; set; }

        public System.String DehStatus { get; set; }

        public System.String DehMemo { get; set; }
        public System.String DehApplyPort { get; set; }

        public System.String DehYear { get; set; }

        public System.Int32? DehIeType { get; set; }

        public System.String DehChNo { get; set; }

        public System.String DehEurope { get; set; }


        public System.String DehDecType { get; set; }


        public System.DateTime? DehPassTm { get; set; }


        public System.Boolean DehPaperlessTax { get; set; }

        public System.Boolean DehSpecRelConfir { get; set; }

        public System.Boolean DehPriceConfir { get; set; }

        public System.Boolean DehPayOfLicenFees { get; set; }

        public System.String DehTradeCoScc { get; set; }

        public System.String DehDeclPort { get; set; }

        public System.String DehTradeAreaCode { get; set; }

        public System.String DehOwnerCodeScc { get; set; }

        public System.String DehAgentCodeScc { get; set; }

        public System.String DehEdiNo { get; set; }



        public System.String DehEntryId { get; set; }


    }
    public class CustomsDeclarationDtl
    {
        /// <summary>
        /// 币制代码
        /// </summary>
        public string MvcDedTradeCurrCode { get; set; }
        public string MvcDedTradeCurr { get; set; }
        public string MvcDedTradeE { get; set; }
        /// <summary>
        /// 原产国
        /// </summary>
        public string MvcDedOriginCountry { get; set; }
        /// <summary>
        /// 目的国
        /// </summary>
        public string MvcDedDestinationCountry { get; set; }
        public string MvcDedTradeCountryDtlCode { get; set; }//在详细列表中的运抵国代码字段
        public string MvcDedTradeCountryDtl { get; set; }//在详细列表中的运抵国字段
        public string MvcDedGUnit { get; set; }
        public string MvcDedUseTo { get; set; }
        public string MvcDedDutyMode { get; set; }
        public string MvcDedUnit1 { get; set; }//法定单位翻译
        public string MvcDedUnit2 { get; set; }//第二单位翻译
        public int? MvcNumber { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public int ISerialNumber { get; set; }
        public string MvcDbpControlMa
        { get; set; }

        /// <summary>
        /// 原产国
        /// </summary>
        public string DedOriginCountryDtl
        { get; set; }
        /// <summary>
        /// 目的国
        /// </summary>
        public string DedDestinationCountryDtl
        {
            get;set;
        }

        /// <summary>
        /// 商品编号与编码
        /// </summary>
        public string MvcDedCodeAndS
       
            { get; set; }
        
        /// <summary>
        /// 商品是否排序
        /// </summary>
        public bool MvcCommercialInspection { get; set; }
        /// <summary>
        /// 新茂序号
        /// </summary>
        public string MvcDedContrItem { get; set; }
        public System.Double? DedGNo { get; set; }

        public System.Double? DedContrItem { get; set; }

        public System.String DedCodeTt { get; set; }

        public System.String DedCodeS { get; set; }

        public System.String DedGName { get; set; }

        public System.String DedGModel { get; set; }

        public System.String DedOriginCountry { get; set; }

        public System.Double? DedGQty { get; set; }

        public System.String DedGUnit { get; set; }

        public System.Double? DedQty1 { get; set; }

        public System.String DedUnit1 { get; set; }

        public System.Double? DedQty2 { get; set; }

        public System.String DedUnit2 { get; set; }

        public System.String DedTradeCurr { get; set; }

        public System.Double? DedDeclPrice { get; set; }

        public System.Double? DedTradeTotal { get; set; }

        public System.String DedDutyMode { get; set; }

        public System.String DedUseTo { get; set; }

        public System.String DedPrdtNo { get; set; }

        public System.String DedGoodsNo { get; set; }

        public System.Double? DedGrossWt { get; set; }

        public System.Double? DedNetWt { get; set; }

        public System.Double? DedWorkUsd { get; set; }

        public System.String DedIngredients { get; set; }

        public System.String DedDestinationCountry { get; set; }

        public System.String DedGoodNo { get; set; }

        public System.Int64? DedXNo { get; set; }


    }
    #endregion
}
