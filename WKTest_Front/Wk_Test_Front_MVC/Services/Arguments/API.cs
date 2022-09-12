using System;
using System.IO;
using System.Net;
using Wk_Test_Front_MVC.Services.Contracts;

namespace Wk_Test_Front_MVC.Services
{
    public class API : IAPI
    {
        private const string hostname = "https://localhost:44360/";
        public string ExecuteRequest(string method, string url, dynamic content)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"{hostname}{url}");
            request.Method = method.ToUpper();

            request.ContentType = method != "GET" ? "application/json" : "application/x-www-form-urlencoded";

            if(method != "GET")
            {
                request.ContentLength = content.Length;
                using (Stream webStream = request.GetRequestStream())
                using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
                {
                    requestWriter.Write(content);
                }
            }

            try
            {
                WebResponse webResponse = request.GetResponse();
                using (Stream webStream = webResponse.GetResponseStream() ?? Stream.Null)
                using (StreamReader responseReader = new(webStream))
                {
                    try
                    {
                        return responseReader.ReadToEnd();
                    }
                    catch (Exception e)
                    {
                        return (new { error = e.Message, stack = e.StackTrace }).ToString();
                    }
                }
            }
            catch (WebException e)
            {
                return e.Message;
            }
        }
    }
}
