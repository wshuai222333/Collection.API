using System;
using System.Net;
using System.Text;

namespace Collection.DDD.Utils.Http {
    public static class HtttApiRequest
    {
        /// <summary>
        /// Post提交
        /// </summary>
        /// <param name="requestURL">请求地址</param>
        /// <param name="requestData">请求数据</param>
        /// <returns></returns>
        public static string apiPost(string requestURL, string requestData) {
            byte[] byteArray = Encoding.UTF8.GetBytes(requestData);
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(new Uri(requestURL));
            webRequest.Method = "POST";
            webRequest.ContentType = "application/json";
            webRequest.Timeout = 30000;
            System.IO.Stream newStream = webRequest.GetRequestStreamAsync().Result;
            newStream.Write(byteArray, 0, byteArray.Length);
            newStream.Dispose();
            HttpWebResponse response;
            try {
                response = (HttpWebResponse)webRequest.GetResponseAsync().Result;
            } catch (WebException ex) {
                response = (HttpWebResponse)ex.Response;
            }
            var data = new System.IO.StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8")).ReadToEnd();
            response.Close();
            return data;
        }
    }
}
