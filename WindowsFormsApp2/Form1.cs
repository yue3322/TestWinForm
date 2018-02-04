using DevExpress.XtraReports.UI;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using UNILOG.LIP.Business;
using WindowsFormsApp2.Model;
using Dos.Model;
using Dos.ORM;
using HtmlAgilityPack;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace WindowsFormsApp2
{

    public partial class Form1 : Form
    {
        private ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        ServiceHost host = null;
        public Form1()
        {
            string wt = "1278";
            var wtint = wt.ToIntNull();
            InitializeComponent();
            this.timer1.Tick += new System.EventHandler(addNum);
            this.timer1.Interval = 2;

            try
            {
                //创建服务网址
                Uri url = new Uri("http://localhost:5210/W/");
                //创建服务器主机
                host = new ServiceHost(typeof(W), url);
                //创建服务器主机
                host.AddServiceEndpoint(typeof(IW), new WSHttpBinding(), "serviceName");
                //启用元素交换
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                host.Description.Behaviors.Add(smb);
                var thread = new Thread(RunService);
                thread.Start();
                //打开服务  
                //host.Open();

                //Console.WriteLine("服务打开成功……");
                //Console.ReadKey();

            }
            catch (Exception ex)
            {

            }

            //  this.timer1.Start();
        }
        void RunService()
        {
            if (host != null)
            {
                host.Open();
            }
            else
            {
                MessageBox.Show("host异常");
            }
        }
        public int num = 0;
        public void addNum(object sender, EventArgs e)
        {
            num++;
            this.label1.Text = num.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var c = new Cookie();
            //System.Net.Cache.("test","aaa");
            //foreach (string name in Request.Cookies)

            //{

            //    info += string.Format("{0} = {1} \r\n ", name, Request.Cookies[name].Value);

            //}
            HttpWebRequest req1 = (HttpWebRequest)HttpWebRequest.Create("http://www.baidu.com");
            req1.Method = "GET";
            using (WebResponse wr1 = req1.GetResponse())
            {
                //在这里对接收到的页面内容进行处理
                using (var baidu = new StreamReader(wr1.GetResponseStream()))
                {
                    var baiduread = baidu.ReadToEnd();
                }
            }
            //WebProxy proxy = new WebProxy("112.65.140.14:8733", false);
            //proxy.Credentials = new NetworkCredential("User", "psd");
            //System.Net.HttpWebRequest.DefaultWebProxy = proxy;
            BasicHttpBinding bind = new BasicHttpBinding { Name = "basichttpbinding" };
            bind.ProxyAddress = new Uri("http://112.65.140.14:8733/");
            bind.UseDefaultWebProxy = false;
            // System.ServiceModel.EndpointAddress remoteAddress
            var ser = new WindowsFormsApp2.CustomerService.CustomerServiceWcfServiceClient("BasicHttpBinding_ICustomerServiceWcfService");
            //ser.
            var ediNOs = ser.importCDSystemDataStr("DFE6");
            var arr = ediNOs.Split(',');
            try
            {
                foreach (var item in arr)
                {
                    var retedi = ser.importCDSystemData(item);
                }
            }
            catch (Exception ex)
            {

            }

            var ret = ser.getEdiNo("HLE20171025");
            var data = ser.getData1("form_head", "client_no='178070681' or edi_no='EDI178000034570658' or job_no='HLE20171025'", "ygjirsoqoidmlmj3xzcaupq5");
            var list = JsonConvert.DeserializeObject<DataTable>(data);
            if (ret == null)
            {

            }
            else if (ret[0] == null || ret[0] == "")
            {

            }

            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("http://www.baidu.com");
            req.Method = "GET";
            //System.Net.HttpWebRequest.DefaultWebProxy = null;
            using (WebResponse wr = req.GetResponse())
            {
                //在这里对接收到的页面内容进行处理
                using (var baidu = new StreamReader(wr.GetResponseStream()))
                {
                    var baiduread = baidu.ReadToEnd();
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            var thread1 = System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                add();
            });
            var thread2 = System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                add();
            });
            System.Threading.Tasks.Task.Run(() =>
            {

            });
            var thread = new System.Threading.Tasks.Task(add);
            thread.Start();
            var sr40 = new WindowsFormsApp2.CustomsDeclarationService40.CustomsDeclarationServiceClient();
            var ret40 = sr40.getDeh("222920160799911921", "3120930459");
            // var retCustomerQuery = sr40.CustomsDeclarationQuery();
            var json40 = JsonConvert.DeserializeObject<CustomsDeclarationModelResult>(ret40);
            var taskstr = "";
            TaskAsyncHelper.RunAsync(add);
            string stri = "";
            //for (int i = 0; i < 100000; i++)
            //{
            //    stri += i;
            //}
            Task task = new Task(() =>
            {
                Console.WriteLine("使用System.Threading.Tasks.Task执行异步操作.");
                for (int i = 0; i < 10000; i++)
                {
                    taskstr += i;
                }
            });
            //启动任务,并安排到当前任务队列线程中执行任务(System.Threading.Tasks.TaskScheduler)
            task.Start();
            //var sr = new WindowsFormsApp2.CustomsDeclarationServiceReference.CustomsDeclarationServiceClient();
            ////var ret2 = sr.getDeh("222920160799911921", 0, "上海卡比特家饰地毯有限公司");
            //var json = JsonConvert.DeserializeObject<CustomsDeclarationModelResult>(ret2);



            ////var ret = sr.CustomsDeclarationQuery("1101919158", null, null, null, null, "1", "20");
            //var json1 = JsonConvert.DeserializeObject<CustomsDeclarationResult>(ret);
            //var days = (DateTime.Now - Convert.ToDateTime("2017-06-20")).TotalDays;
            //var day2 = DateTime.Now.AddDays(-166);
            //string str = "";
            //var arr = str.Split(',');
            //try
            //{
            //    log.Info(new Random().Next(0, 9999999));
            //    log.Error(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName + "错误信息");
            //}
            //catch (Exception ex)
            //{


            //}
        }
        public async void testasync()
        {
            add();
        }
        public void add()
        {
            string stri = "";
            for (int i = 0; i < 100000; i++)
            {
                stri += i;
            }
            int j = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // HtmlElement element = new HtmlElement("");
            Uri uri = new Uri("http://www.shuidio.com/user/1075874930/1");
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(uri);
            myReq.UserAgent = "User-Agent:Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705";
            myReq.Accept = "*/*";
            myReq.KeepAlive = true;
            myReq.Headers.Add("Accept-Language", "zh-cn,en-us;q=0.5");
            HttpWebResponse result = (HttpWebResponse)myReq.GetResponse();
            Stream receviceStream = result.GetResponseStream();
            //StreamReader readerOfStream = new StreamReader(receviceStream, System.Text.Encoding.GetEncoding("utf-8"));
            //string strHTML = readerOfStream.ReadToEnd();
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.Load(receviceStream);
            //readerOfStream.Close();
            receviceStream.Close();
            result.Close();

            //WebClient wc = new WebClient();
            //wc.OpenRead("http://www.shuidio.com/user/1075874930/1");//http://www.shuidio.com/user/1075874930/1
            ////wc.BaseAddress = "http://www.juedui100.com/";
            ////wc.Encoding = Encoding.UTF8;
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.13910.com/u/1075874930/share/page-1.html");
            //request.Method = "GET";
            //request.ContentType = "text/html;charset=UTF-8";
            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //Stream receviceStreammyResponseStream = response.GetResponseStream();
            //StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            ////string retString = myStreamReader.ReadToEnd();
            ////myStreamReader.Close();
            ////var doc = new HtmlAgilityPack.HtmlDocument();
            ////doc.Load(myResponseStream);
            //myResponseStream.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            // var by = new byte() { };
            var retUploadData = wc.UploadData("http://www.baidu.com", new byte[] { });
            var retUploadDataStr = Encoding.UTF8.GetString(retUploadData);
            //wc.BaseAddress = "";
            var html = wc.DownloadString("http://www.baidu.com");

            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            DcEpDecHead head = DcEpDecHead.Fetch(new DcEpDecHeadCriteria { DehId = 185369933545884 });
            //head.DehTradeCo = "1111";
            //var dtl = head.DcEpDecDtls.AddNew();
            //dtl.DedOriginCountry = "222";
            //head.DcEpDecDtls.Add(dtl);


            var report = new TestXtraReport(head);
            report.ShowPreview();
            var top = report.Margins;
            //report.PaperKind = new PaperKind("A4");
            //ReportPrintTool printTool = new ReportPrintTool(report);
            report.ExportToPdf(@"./PDF");


        }

        private void button6_Click(object sender, EventArgs e)
        {
            var url = this.textBox1.Text;
            if (url.IsNullOrEmpty())
            {
                MessageBox.Show("网址为空");
                return;
            }
            try
            {
                var db = DB.MysqlDB;
                var htmlweb = new HtmlAgilityPack.HtmlWeb();
                htmlweb.OverrideEncoding = Encoding.GetEncoding("utf-8");
                htmlweb.PreRequest = new HtmlAgilityPack.HtmlWeb.PreRequestHandler(PreRequest);
                var docweb = htmlweb.Load(url);
                var p = new pdf();
                var title = docweb.DocumentNode.SelectSingleNode("//div[@id='article']/h1");
                if (title != null)
                {
                    var existP = db.From<pdf>().Where(x => x.Titile == title.InnerText).ToFirst();
                    if (existP != null)
                    {
                        if (MessageBox.Show("已经存在的标题：" + title + "是否继续", "", MessageBoxButtons.OK) != DialogResult.OK)
                        {
                            return;
                        }
                    }
                    p.Titile = title.InnerText;
                }
                else
                {
                    MessageBox.Show("标题不存在");
                    return;
                }
                p.Brief_Introduction = docweb.DocumentNode.SelectSingleNode("//div[@id='iptcomContents']").InnerHtml;
                p.Id = GuidToLongID();
                db.Insert(p);
                var id = p.Id;
                var dtls = docweb.DocumentNode.SelectNodes("//table//tr");
                if (dtls != null && dtls.Count > 1)
                {
                    try
                    {
                        for (int i = 1; i < dtls.Count - 1; i++)
                        {
                            var td = dtls[i].SelectNodes("./td");
                            var d = new pdf_dtl();
                            if (td != null && td.Count > 0)
                            {
                                d.File_Nm = td[0].SelectSingleNode("a").InnerText;
                                d.File_Size = td[1].InnerText;
                                d.File_Url = td[0].SelectSingleNode("a").GetAttributeValue("ed2k", "");
                            }
                            d.id = p.Id;
                            db.Insert(d);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("明细异常：" + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("pdf处理异常");
            }
            MessageBox.Show("保存成功");

            //var DpaDocuNumber = Math.Ceiling(6.0 / 5).ToInt();
            //var mdDate = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");
            //var date = "31-1-2018".ToDateTime();
            // DateTimeFormatInfo dtFormat = new System.GlobalizationDateTimeFormatInfo();

            //dtFormat.ShortDatePattern = "yyyy/MM/dd";
            //var date2 = Convert.ToDateTime("31-1-2018","d-M-yyyy");
            //DateTime dt1;
            //var dt = DateTime.TryParseExact("1-1-2018", "d-M-yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.AdjustToUniversal, out dt1);


            //var db = 
            //string html = "<div id='test'><span>testspan1</span><span>testspan2</span><span id='span3'>testspan3</span><div><span>testspanA1</span></div></div>";
            //var doc = new HtmlAgilityPack.HtmlDocument();
            //doc.LoadHtml(html);
            //var span = doc.DocumentNode.SelectSingleNode("//div[@id='test']/span[@id='span3']");
            //var span2 = doc.DocumentNode.SelectNodes("//div[@id='test']/span");
            //var span3 = doc.DocumentNode.SelectNodes("./div//span");
        }
        bool PreRequest(HttpWebRequest request)
        {
            request.Headers[HttpRequestHeader.AcceptEncoding] = "gzip, deflate";
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            request.CookieContainer = new CookieContainer();
            return true;
        }
       
        private void wcf测试_Click(object sender, EventArgs e)
        {
            double? db = 10.05;
            int? dbint = (int?)db;
            var num = Regex.Matches("hellohellohellohello", "hello");
            double a = 1.00;
            var strDouble = a.ToString();
            string str = "";
            var collect = Convert.ToInt16(str);
            var dialogResult = MessageBox.Show("确定要退出吗?", "退出系统", MessageBoxButtons.OKCancel);
            var ser = new WindowsFormsApp2.CustomsDeclarationServiceReference.CustomsDeclarationServiceClient();
            var retdata = ser.getDeh("222920170001984785", "3226950095", "宜家", "宜家1");
            var retdata1 = ser.CustomsDeclarationQuery("3226950095", null, null, null, null, "宜家", "宜家", "1", "20");
            try
            {
                var strDate = "111日";

                var checkbox = this.checkBox1.CheckState;
                var date = DateTime.ParseExact("2017年12月14日", "yyyy年M月d日", System.Globalization.CultureInfo.CurrentCulture);
                var _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var username = _config.AppSettings.Settings["username"].Value;

                _config.AppSettings.Settings["username"].Value = "lily";
                var username2 = _config.AppSettings.Settings["username"].Value;
                _config.AppSettings.Settings.Remove("username");
                _config.AppSettings.Settings.Add("username", "lily");
                //_config.Save(); 
                _config.Save(ConfigurationSaveMode.Modified);
                //刷新
                ConfigurationManager.RefreshSection("appSettings");
                long nums = 0;
                //for (int i = 0; i < 100000000000; i++)
                //{
                //    nums += i;
                //}
                //MessageBox.Show(nums.ToString());

                //var promise = formHead.PROMISE_ITMES;
                //if (promise != null && promise.Length == 4)
                //{
                //    deh.DehSpecRelConfir = promise.Substring(0, 1) == "1" ? true : false;
                //    deh.DehPriceConfir = promise.Substring(1, 1) == "1" ? true : false;
                //    deh.DehPayOfLicenFees = promise.Substring(2, 1) == "1" ? true : false;
                //}
            }
            catch (Exception ex)
            {

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string strTest = "char peer0_0[] = { /* Packet 19 */0x50, 0x4f, 0x53, 0x54, 0x20, 0x2f, 0x44, 0x6f, 0x63, 0x41, 0x74, 0x74, 0x61,";
                var strMatch = Regex.Replace(strTest, @"char peer\d+_\d+.+/", "");
                strTest = Regex.Replace(strTest, " };", ",");
                var str = this.richTextBox1.Text;
                str = Regex.Replace(str, @"char peer\d+_\d+.+/", "");
                str = Regex.Replace(str, " };", ",");
                str = str.TrimEnd(',');
                var strArr = str.Split(',');
                var gb = Encoding.GetEncoding("gb2312");
                var by5 = new List<byte>();
                for (int i = 0; i < strArr.Length; i++)
                {
                    var hex = strArr[i].Trim().Trim("\r\n".ToCharArray()).Replace("0x", "");
                    int value = Convert.ToInt32(hex, 16);
                    // var hex = TaskAsyncHelper.strToToHexByte(strArr[i]);
                    by5.Add(Convert.ToByte(value));
                }

                //通关无纸化随附单据上传检索系统
                var by1 = new byte[36] { 0xcd, 0xa8, 0xb9, 0xd8, 0xce, 0xde, 0xd6, 0xbd, 0xbb, 0xaf, 0xcb, 0xe6, 0xb8, 0xbd, 0xb5, 0xa5, 0xbe, 0xdd, 0xc9, 0xcf, 0xb4, 0xab, 0xbc, 0xec, 0xcb, 0xf7, 0xcf, 0xb5, 0xcd, 0xb3, 0x3c, 0x2f, 0x54, 0x49, 0x54, 0x4c };
                var by2 = new byte[18] { 0x46, 0xb9, 0xab, 0xb8, 0xe6, 0xb0, 0xe5, 0x20, 0x3c, 0x2f, 0x54, 0x49, 0x54, 0x4c, 0x45, 0x3e, 0x0d, 0x0a };
                //var by3 = new byte[] { 0x0d, 0x0a };
                var by4 = new byte[25]{ /* Packet 3346 */
                0x48, 0x54, 0x54, 0x50, 0x2f, 0x31, 0x2e, 0x31,
        0x20, 0x31, 0x30, 0x30, 0x20, 0x43, 0x6f, 0x6e,
        0x74, 0x69, 0x6e, 0x75, 0x65, 0x0d, 0x0a, 0x0d,
        0x0a };
                //by[3] = 
                //int intw = 0xcd;
                //var bylist = Convert.ToByte(intw);

                var zhong = new string(gb.GetChars(by5.ToArray()));
                this.richTextBox2.Text = zhong;
                var timer = new System.Timers.Timer();
                timer.Interval = 5000;
                timer.Elapsed += new System.Timers.ElapsedEventHandler(Timer);
                timer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("异常101：" + ex.Message);
            }

        }
        public void Timer(object sender, ElapsedEventArgs e)
        {
            try
            {
                var ser = new WindowsFormsApp2.MiniService.ServiceWcfServiceClient();

                for (int i = 0; i < 100; i++)
                {
                    var str = ser.testUi();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                var id = new long?[2];
                var book = new BookModel();
                var h = DateTime.Now.Hour;
                book.Name = "program";
                var model = JsonConvert.SerializeObject(book);
                var json = JsonConvert.DeserializeObject<BookModel>(model);
                var json1 = JsonConvert.DeserializeObject<BookModelP>(model);
                var list = new List<string>();
                list.Add("111");
                list.Add("222");
                //var strList = list.;
                // var ser = new WindowsFormsApp2.zhengshiServiceReference.ServiceWcfServiceClient();
                //var ret = ser.GetData(111);
            }
            catch (Exception ex)
            {

            }
        }
        /// <summary>
        /// 测试HtmlAgilityPack的语法与使用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HtmlAgilityPack测试_Click(object sender, EventArgs e)
        {
            var webClient = new HtmlWeb();
            var html = webClient.Load(@"D:\access\html\test.html");
            var test = html.DocumentNode.SelectNodes("//p");
            var span = test[1].SelectSingleNode("span");
        }
        /// <summary>  
        /// 根据GUID获取16位的唯一字符串  
        /// </summary>  
        /// <param name=\"guid\"></param>  
        /// <returns></returns>  
        public static string GuidTo16String()
        {
            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
                i *= ((int)b + 1);
            return string.Format("{0:x}", i - DateTime.Now.Ticks);
        }
        /// <summary>  
        /// 根据GUID获取19位的唯一数字序列  
        /// </summary>  
        /// <returns></returns>  
        public static long GuidToLongID()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            return BitConverter.ToInt64(buffer, 0);
        }  

    }
    public class BookModel
    {
        public string Name { get; set; }
    }
    public class BookModelP
    {
        public string Name { get; set; }
        public int NO { get; set; }
    }
    public static class TaskAsyncHelper
    {
        public static void RunAsync(Action fn)
        {
            Func<System.Threading.Tasks.Task> taskFunc = () =>
            {
                return System.Threading.Tasks.Task.Run(() =>
                {
                    fn();
                });
            };
        }
        /// <summary>  
        /// 将一个方法function异步运行，在执行完毕时执行回调callback  
        /// </summary>  
        /// <param name="function">异步方法，该方法没有参数，返回类型必须是void</param>  
        /// <param name="callback">异步方法执行完毕时执行的回调方法，该方法没有参数，返回类型必须是void</param>  
        public static async void RunAsync(Action function, Action callback)
        {
            Func<System.Threading.Tasks.Task> taskFunc = () =>
            {
                return System.Threading.Tasks.Task.Run(() =>
                {
                    function();
                });
            };
            await taskFunc();
            if (callback != null)
                callback();
        }

        /// <summary>  
        /// 将一个方法function异步运行，在执行完毕时执行回调callback  
        /// </summary>  
        /// <typeparam name="TResult">异步方法的返回类型</typeparam>  
        /// <param name="function">异步方法，该方法没有参数，返回类型必须是TResult</param>  
        /// <param name="callback">异步方法执行完毕时执行的回调方法，该方法参数为TResult，返回类型必须是void</param>  
        public static async void RunAsync<TResult>(Func<TResult> function, Action<TResult> callback)
        {
            Func<System.Threading.Tasks.Task<TResult>> taskFunc = () =>
            {
                return System.Threading.Tasks.Task.Run(() =>
                {
                    return function();
                });
            };
            TResult rlt = await taskFunc();
            if (callback != null)
                callback(rlt);
        }
        #region 字符串转16进制
        /// <summary> 
        /// 字符串转16进制字节数组 
        /// </summary> 
        /// <param name="hexString"></param> 
        /// <returns></returns> 
        public static byte[] strToToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }

        /// <summary> 
        /// 字节数组转16进制字符串 
        /// </summary> 
        /// <param name="bytes"></param> 
        /// <returns></returns> 
        public static string byteToHexStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("X2");
                }
            }
            return returnStr;
        }

        /// <summary> 
        /// 从汉字转换到16进制 
        /// </summary> 
        /// <param name="s"></param> 
        /// <param name="charset">编码,如"utf-8","gb2312"</param> 
        /// <param name="fenge">是否每字符用逗号分隔</param> 
        /// <returns></returns> 
        public static string ToHex(string s, string charset, bool fenge)
        {
            if ((s.Length % 2) != 0)
            {
                s += " ";//空格 
                //throw new ArgumentException("s is not valid chinese string!"); 
            }
            System.Text.Encoding chs = System.Text.Encoding.GetEncoding(charset);
            byte[] bytes = chs.GetBytes(s);
            string str = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                str += string.Format("{0:X}", bytes[i]);
                if (fenge && (i != bytes.Length - 1))
                {
                    str += string.Format("{0}", ",");
                }
            }
            return str.ToLower();
        }

        ///<summary> 
        /// 从16进制转换成汉字 
        /// </summary> 
        /// <param name="hex"></param> 
        /// <param name="charset">编码,如"utf-8","gb2312"</param> 
        /// <returns></returns> 
        public static string UnHex(string hex, string charset)
        {
            if (hex == null)
                throw new ArgumentNullException("hex");
            hex = hex.Replace(",", "");
            hex = hex.Replace("\n", "");
            hex = hex.Replace("\\", "");
            hex = hex.Replace(" ", "");
            if (hex.Length % 2 != 0)
            {
                hex += "20";//空格 
            }
            // 需要将 hex 转换成 byte 数组。 
            byte[] bytes = new byte[hex.Length / 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                try
                {
                    // 每两个字符是一个 byte。 
                    bytes[i] = byte.Parse(hex.Substring(i * 2, 2),
                    System.Globalization.NumberStyles.HexNumber);
                }
                catch
                {
                    // Rethrow an exception with custom message. 
                    throw new ArgumentException("hex is not a valid hex number!", "hex");
                }
            }
            System.Text.Encoding chs = System.Text.Encoding.GetEncoding(charset);
            return chs.GetString(bytes);
        }
        #endregion
    }
}
////public string get
//[OutputCache(Duration = 0)]
//public ActionResult CompleteEntrustList(string name = "")
//{
//    //name = name;// Server.UrlDecode(name);
//    BasCustomerInfoVCriteria criteria = new BasCustomerInfoVCriteria();
//    criteria.BctFg = (int)CustomerType.OrderCustomer;
//    criteria.BscIsValidFg = false;
//    criteria.SysCustomerCd = null;//WorkerInfo.SysCd;
//    criteria.OrderByString = " order by length(BSC_CD),BSC_CD";
//    criteria.UseQuerySqlAndProperties = true;
//    criteria.QuerySqlCommand = " (UPPER(BSC_CD) like '%" + name.ToUpper().Replace("'", "''") + "%' or UPPER(BSC_COMP_NM) like '%" + name.ToUpper().Replace("'", "''") + "%')";
//    BasCustomerInfoVList list = BasCustomerInfoVList.Fetch(criteria);

//    list.PageSize = 10;
//    list = list.GetPage(1);
//    List<object> listjson = new List<object>();
//    foreach (var cus in list)
//    {
//        listjson.Add(new { id = cus.BscId, cd = cus.BscCd, name = cus.BscCompNm, salecd = cus.SaleCd, salename = cus.SaleBwkName, servicename = cus.ServiceBwkName, servicecd = cus.ServiceBwkCd });
//    }
//    return Json(listjson, JsonRequestBehavior.AllowGet);
//}