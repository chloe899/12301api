using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace PostDemo
{
    public class Team
    {




        public static string SynsChina(string jsonVal)
        {


            var url = "https://tgapi.12301e.com/team/china";
            return JSONPOst(url, jsonVal);

        }

        public static  bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {   // 总是接受  
            return true;
        }



        /// <summary>This function converts a dictionary to a JSON string and posts it as content to a website
        /// and then returns a JSONWebResponse object to the user with the content, statuscode, and any Exception.</summary>
        /// <param name="url">url where to post the data</param>
        /// <param name="dictionay">Dictionary<string,string> of key value to send to url</param>
        /// <param name="sendAsJSON">If set to true sends as JSON, otherwise sends as posted form fields</param>
        /// <returns>A JSONWebResponse object</returns>
        public static string JSONPOst(string url, string jsonVal)
        {
            try
            {


                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                //Set up the web request
                HttpWebRequest request = WebRequest.Create(new Uri(url)) as HttpWebRequest;
                request.Method = "POST";
                request.ContentType = "application/json";
                request.Headers["x-12301-key"] = "6657bab422cc67b9ee4f225440c07eab";
               


                //Convert the Dictionary to JSON
                string jsondata = jsonVal;

                // Encode the parameters as content data, and set the content length
                byte[] JSONContent = UTF8Encoding.UTF8.GetBytes(jsondata);
                request.ContentLength = JSONContent.Length;

                // Send the request:
                using (Stream post = request.GetRequestStream())
                {
                    post.Write(JSONContent, 0, JSONContent.Length);
                }

                // Pick up the response
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());

                    string result = reader.ReadToEnd();

                    return result;
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
    }

}

