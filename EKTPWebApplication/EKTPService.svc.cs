using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EKTPWebApplication
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EKTPService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EKTPService.svc or EKTPService.svc.cs at the Solution Explorer and start debugging.
    public class EKTPService : IEKTPService
    {
        public void DoWork()
        {
        }
        public Content CekNIK(string nik)
        {
            try
            {
                var IP_USER = ConfigurationManager.AppSettings["IP_USER"];
                var password = ConfigurationManager.AppSettings["password"];
                var user_id = ConfigurationManager.AppSettings["user_id"];
                var urlService = ConfigurationManager.AppSettings["urlService"];
                WebRequest request = WebRequest.Create(urlService);
                // Set the Method property of the request to POST.  
                request.Method = "POST";

                // Create POST data and convert it to a byte array.  
                //string postData = "{\"Name\":\"John\",\"Address\":30,\"city\":\"New York\"}";

                //credentials["nik"] = "1212231402940001";
                //credentials["user_id"] = "devindosukses";
                //credentials["password"] = "SuDVjg0Z";
                //credentials["IP_USER"] = "10.162.122.111";

                var credential = new
                {
                    nik,
                    IP_USER,
                    password,
                    user_id
                };
                var serial = JsonConvert.SerializeObject(credential);
                byte[] byteArray = Encoding.UTF8.GetBytes(serial);

                // Set the ContentType property of the WebRequest.  
                request.ContentType = "application/json";
                // Set the ContentLength property of the WebRequest.  
                request.ContentLength = byteArray.Length;

                // Get the request stream.  
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.  
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.  
                dataStream.Close();

                // Get the response.  
                WebResponse response = request.GetResponse();
                // Display the status.  
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                string responseFromServer = "";
                // Get the stream containing content returned by the server.  
                // The using block ensures the stream is automatically closed.
                using (dataStream = response.GetResponseStream())
                {
                    // Open the stream using a StreamReader for easy access.  
                    StreamReader reader = new StreamReader(dataStream);
                    // Read the content.  
                    responseFromServer = reader.ReadToEnd();
                    // Display the content.  

                }

                // Close the response.  
                response.Close();
                var content = JsonConvert.DeserializeObject<Content>(responseFromServer);
                //Console.WriteLine(responseFromServer);
                return content;
            }
            catch (Exception e)
            {

            }
            var retval = new Content();
            return retval;
        }

        public string StringCekNIK(string nik)
        {

            try
            {
                var IP_USER = ConfigurationManager.AppSettings["IP_USER"];
                var password = ConfigurationManager.AppSettings["password"];
                var user_id = ConfigurationManager.AppSettings["user_id"];

                var urlService = ConfigurationManager.AppSettings["urlService"];
                WebRequest request = WebRequest.Create(urlService);
                // Set the Method property of the request to POST.  
                request.Method = "POST";

                // Create POST data and convert it to a byte array.  
                //string postData = "{\"Name\":\"John\",\"Address\":30,\"city\":\"New York\"}";

                //credentials["nik"] = "1212231402940001";
                //credentials["user_id"] = "devindosukses";
                //credentials["password"] = "SuDVjg0Z";
                //credentials["IP_USER"] = "10.162.122.111";

                var credential = new
                {
                    nik,
                    IP_USER,
                    password,
                    user_id
                };
                var serial = JsonConvert.SerializeObject(credential);
                byte[] byteArray = Encoding.UTF8.GetBytes(serial);

                // Set the ContentType property of the WebRequest.  
                request.ContentType = "application/json";
                // Set the ContentLength property of the WebRequest.  
                request.ContentLength = byteArray.Length;

                // Get the request stream.  
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.  
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.  
                dataStream.Close();

                // Get the response.  
                WebResponse response = request.GetResponse();
                // Display the status.  
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                string responseFromServer = "";
                // Get the stream containing content returned by the server.  
                // The using block ensures the stream is automatically closed.
                using (dataStream = response.GetResponseStream())
                {
                    // Open the stream using a StreamReader for easy access.  
                    StreamReader reader = new StreamReader(dataStream);
                    // Read the content.  
                    responseFromServer = reader.ReadToEnd();
                    // Display the content.  

                }

                // Close the response.  
                //response.Close();
                //var content = JsonConvert.DeserializeObject<RootObject>(responseFromServer);
                //Console.WriteLine(responseFromServer);
                return responseFromServer;
            }
            catch (Exception e)
            {

                //throw;
            }
            var retval = new RootObject();
            return JsonConvert.SerializeObject(retval);
        }
    }
}
