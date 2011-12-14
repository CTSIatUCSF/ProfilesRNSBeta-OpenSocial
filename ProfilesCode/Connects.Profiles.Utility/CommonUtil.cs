using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace Connects.Profiles.Utility
{
    public class CommonUtil
    {
        public string HttpPost(string myUri, string myXml, string contentType)
        {
            Uri uri = new Uri(myUri);
            WebRequest myRequest = WebRequest.Create(uri);
            myRequest.ContentType = contentType;
            //myRequest.ContentType = "application/x-www-form-urlencoded";
            myRequest.Method = "POST";

            byte[] bytes = Encoding.ASCII.GetBytes(myXml);
            Stream os = null;

            string err = null;
            try
            { // send the Post
                myRequest.ContentLength = bytes.Length;   //Count bytes to send
                os = myRequest.GetRequestStream();
                os.Write(bytes, 0, bytes.Length);         //Send it
            }
            catch (WebException ex)
            {
                err = "Input=" + ex.Message;
            }
            finally
            {
                if (os != null)
                { os.Close(); }
            }

            try
            { // get the response
                WebResponse myResponse = myRequest.GetResponse();
                if (myResponse == null)
                { return null; }
                StreamReader sr = new StreamReader(myResponse.GetResponseStream());
                return sr.ReadToEnd().Trim();
            }
            catch (WebException ex)
            {
                err = "Output=" + ex.Message;
            }
            return err;
        } // end HttpPost 
    }
}
