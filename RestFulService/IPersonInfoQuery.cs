using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

/************************************************************************************
* Autor：John
* Version：V1.0.0.0
* CreateTime：2020/10/30
* Copyright © 2020  All Rights Reserved
************************************************************************************/
namespace RestFulService
{
    /// <summary>
    /// 定義兩種方法，1、GetScore方法：通過GET請求傳入name，返回對應的成績；2、GetInfo方法：通過POST請求，傳入Info對象，查找對應的User並返回給客戶端
    /// </summary>
    [ServiceContract(Name = "PersonInfoQueryServices")]
    public interface IPersonInfoQuery
    {
        /// <summary>
        /// 說明：
        /// WebGet默認請求是GET方式
        /// UriTemplate(URL Routing)的參數名name必須要方法的參數名必須一致（不區分大小寫）
        /// RequestFormat規定客戶端必須是什麽數據格式請求的（JSon或者XML），不設置默認為XML
        /// ResponseFormat規定服務端返回給客戶端是以是什麽數據格返回的（JSon或者XML）
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "PersonInfoQuery/{name}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        User GetScore(string name);

        /// <summary>
        /// 說明：
        /// WebInvoke請求方式有POST、PUT、DELETE等，所以需要明確指定Method是哪種請求的。
        /// 注意：POST情況下，UriTemplate(URL Routing)一般是沒有參數（和上面GET的UriTemplate不一樣，因為POST參數都通過消息體傳送）
        /// RequestFormat規定客戶端必須是什麽數據格式請求的（JSon或者XML），不設置默認為XML
        /// ResponseFormat規定服務端返回給客戶端是以是什麽數據格返回的（JSon或者XML）
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "PersonInfoQuery/Info", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        User GetInfo(Info info);
    }
}
