using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetKUTUMBAdetails
{
    internal class GetData
    {
        SqlHelper sh = new SqlHelper();
        Utilities utility = new Utilities();
        String Ip = "console_application";
        String AddedBy = "console_application";
        public string RationCard(string InputJson)
        {
            int resCode = 0;
            string PostUrl = Convert.ToString(ConfigurationManager.AppSettings["FamilyUrl"]);
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(PostUrl + "GetBeneficiaryData");
            req.Timeout = 200000;
            req.Method = "POST";
            req.ProtocolVersion = HttpVersion.Version11;
            req.ContentType = "application/json";
            // req.Headers.Add("Authorization", licensekey);
            req.Headers.Add("ContentType", "application/json");
            req.Accept = "application/json";
            string content = InputJson;


            try
            {
                req.ContentLength = content.Length;
                Stream wri = req.GetRequestStream();
                byte[] array = Encoding.UTF8.GetBytes(content);
                wri.Write(array, 0, array.Length);
                wri.Flush();
                wri.Close();
                HttpWebResponse HttpWResp = (HttpWebResponse)req.GetResponse();
                resCode = Convert.ToInt32(HttpWResp.StatusCode);
                StreamReader reader = new StreamReader(HttpWResp.GetResponseStream(), System.Text.Encoding.UTF8);
                string resultData = reader.ReadToEnd();

                string decodedresult = resultData;

                return decodedresult;
            }
            catch (Exception ex)
            {
                //ExceptionManager.Publish(ex);

                return "Error-" + ex.Message;
            }

        }
        internal string HashHMACHex(string hMACKey, string InputValue)
        {
            string hashHMACHex = string.Empty;
            try
            {
                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] keyByte = encoding.GetBytes(hMACKey);
                HMACSHA256 hmacsha1 = new HMACSHA256(keyByte);
                byte[] messageBytes = encoding.GetBytes(InputValue);
                byte[] hash = HashHMAC(keyByte, messageBytes);
                hashHMACHex = HashEncode(hash);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "document.getElementById('ContentPlaceHolder1_modalbody').innerHTML='" + ex.Message + "';Confirm();", true);
                //modalheader.Attributes.Add("class", "modal-header alert-danger");

                ////SimpleLog.Error("Error Message: [" + ex.Message.ToString() + "]");
                //string errorstr = "ErrorPage.aspx?ErrorMsg=" + Server.UrlEncode(Request.Url.AbsolutePath.ToString()) + Server.UrlEncode(ex.Message.ToString());
                //Response.Redirect(errorstr, false);

            }
            finally
            {
            }
            return hashHMACHex;
        }
        private byte[] HashHMAC(byte[] key, byte[] message)
        {
            var hash = new HMACSHA256(key);
            return hash.ComputeHash(message);
        }
        private string HashEncode(byte[] hash)
        {
            return Convert.ToBase64String(hash);
        }
        public string DecryptString(string key, string IV, string cipherText)
        {
            byte[] buffer = Convert.FromBase64String(cipherText);
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = Encoding.UTF8.GetBytes(IV);
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new
                   CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new
                       StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
        public class ListtoDataTableConverter
        {
            public DataTable ToDataTable<T>(List<T> items)

            {

                DataTable dataTable = new DataTable(typeof(T).Name);

                //Get all the properties

                PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

                foreach (PropertyInfo prop in Props)

                {

                    //Setting column names as Property names

                    dataTable.Columns.Add(prop.Name);

                }

                foreach (T item in items)

                {

                    var values = new object[Props.Length];

                    for (int i = 0; i < Props.Length; i++)

                    {

                        //inserting property values to datatable rows

                        values[i] = Props[i].GetValue(item, null);

                    }

                    dataTable.Rows.Add(values);

                }

                //put a breakpoint here and check datatable

                return dataTable;

            }
        }

    }
}
