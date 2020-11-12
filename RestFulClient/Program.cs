using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RestFulClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Restful Client端Demo測試";

            RestClient client = new RestClient();
            client.EndPoint = @"http://127.0.0.1:8080/";

            client.Method = EnumHttpVerb.GET;
            string resultGet = client.HttpRequest("PersonInfoQuery/王二麻子");
            Console.WriteLine("GET方式獲取結果：" + resultGet);

            client.Method = EnumHttpVerb.POST;
            Info info = new Info();
            info.ID = 1;
            info.Name = "張三";
            client.PostData = JsonConvert.SerializeObject(info);//JSon序列化我們用到第三方Newtonsoft.Json.dll
            var resultPost = client.HttpRequest("PersonInfoQuery/Info");
            Console.WriteLine("POST方式獲取結果：" + resultPost);
            Console.Read();
        }
    }

    [Serializable]
    public class Info
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
