using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace RestFulService
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Title = "RestfulServer端測試";
                PersonInfoQueryServices service = new PersonInfoQueryServices();
                //WebServiceHost _serviceHost = new WebServiceHost(service, new Uri("http://127.0.0.1:8081/"));
                //或者第二種方法
                WebServiceHost _serviceHost = new WebServiceHost(typeof(PersonInfoQueryServices), new Uri("http://127.0.0.1:8081/"));

                _serviceHost.Open();
                Console.WriteLine("Web服務已開啟...");
                Console.WriteLine("輸入任意鍵關閉程序！");
                Console.ReadKey();
                _serviceHost.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Web服務開啟失敗：{0}\r\n{1}", ex.Message, ex.StackTrace);
            }
            Console.ReadKey();
        }
    }
}
