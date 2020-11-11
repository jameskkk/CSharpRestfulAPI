using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

/************************************************************************************
* Autor：John
* Version：V1.0.0.0
* CreateTime：2020/10/30
* Copyright © 2020  All Rights Reserved
************************************************************************************/
namespace RestFulClient
{
    /// <summary>
    /// 請求類型
    /// </summary>
    public enum EnumHttpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    public class RestClient
    {
        #region 屬性
        /// <summary>
        /// 端點路徑
        /// </summary>
        public string EndPoint { get; set; }

        /// <summary>
        /// 請求方式
        /// </summary>
        public EnumHttpVerb Method { get; set; }

        /// <summary>
        /// 文本類型（1、application/json 2、txt/html）
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// 請求的數據(一般為JSon格式)
        /// </summary>
        public string PostData { get; set; }
        #endregion

        #region 初始化
        public RestClient()
        {
            EndPoint = "";
            Method = EnumHttpVerb.GET;
            ContentType = "application/json";
            PostData = "";
        }

        public RestClient(string endpoint)
        {
            EndPoint = endpoint;
            Method = EnumHttpVerb.GET;
            ContentType = "application/json";
            PostData = "";
        }

        public RestClient(string endpoint, EnumHttpVerb method)
        {
            EndPoint = endpoint;
            Method = method;
            ContentType = "application/json";
            PostData = "";
        }

        public RestClient(string endpoint, EnumHttpVerb method, string postData)
        {
            EndPoint = endpoint;
            Method = method;
            ContentType = "application/json";
            PostData = postData;
        }
        #endregion

        #region 方法
        /// <summary>
        /// http請求(不帶參數請求)
        /// </summary>
        /// <returns></returns>
        public string HttpRequest()
        {
            return HttpRequest("");
        }

        /// <summary>
        /// http請求(帶參數)
        /// </summary>
        /// <param name="parameters">parameters例如：?name=LiLei</param>
        /// <returns></returns>
        public string HttpRequest(string parameters)
        {
            var request = (HttpWebRequest)WebRequest.Create(EndPoint + parameters);

            request.Method = Method.ToString();
            request.ContentLength = 0;
            request.ContentType = ContentType;

            if (!string.IsNullOrEmpty(PostData) && Method == EnumHttpVerb.POST)
            {
                var bytes = Encoding.UTF8.GetBytes(PostData);
                request.ContentLength = bytes.Length;

                using (var writeStream = request.GetRequestStream())
                {
                    writeStream.Write(bytes, 0, bytes.Length);
                }
            }

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                var responseValue = string.Empty;

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    var message = string.Format("請求數據失敗. 返回的 HTTP 狀態碼：{0}", response.StatusCode);
                    throw new ApplicationException(message);
                }

                using (var responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                        using (var reader = new StreamReader(responseStream))
                        {
                            responseValue = reader.ReadToEnd();
                        }
                }
                return responseValue;
            }
        }
        #endregion
    }
}
