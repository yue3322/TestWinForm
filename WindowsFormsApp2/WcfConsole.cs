using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    [ServiceContract]
    //[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    interface IW
    {
        [OperationContract]
        string HelloWorld();
        [OperationContract]
        string GetData();
    }
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class W : IW
    {
        public string HelloWorld()
        {
            return "Hello World";
        }
        public string GetData()
        {
            Thread.Sleep(5000);
            return DateTime.Now.ToString("HH:mm:ss fff");
        }
    }
}
