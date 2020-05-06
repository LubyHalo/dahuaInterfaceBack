using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Xml;
using Newtonsoft.Json;
using System.Data;
using System.Security.Cryptography;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.OpenSsl;

namespace dahua
{
    public enum HttpVerbNew
    {
        GET,            //method  常用的就这几样，可以添加其他的   get：获取    post：修改    put：写入    delete：删除
        POST,
        PUT,
        DELETE
    }

    public class ContentType//根据Postman整理，可以添加
    {
        public string Text = "text/plain";
        public string JSON = "application/json";
        public string Javascript = "application/javascript";
        public string XML = "application/xml";
        public string TextXML = "text/xml";
        public string HTML = "text/html";
    }
   
    public class Dahuajk
    {
		public string testString;
        #region 大华接口处理
        // token获取
        public string Token { get; private set; }
        // userID获取
        public string UserID { get; private set; }

        /// <summary>
        /// 初始化Dahuajk类
        /// </summary>
        /// <param name="serviceAddress">服务器地址</param>
        /// <param name="loginName">登录名</param>
        /// <param name="loginPass">登陆密码</param>
        /// <param name="isEncrypted">密码是否加密</param>
        /// <param name="encryptMode">加密方式(RSA或Base64)</param>
        public Dahuajk(string serviceAddress, string loginName, string loginPass, bool isEncrypted, string encryptMode = "Base64")
        {
            string publicKey = "";
            if (encryptMode == "RSA")
            {
                publicKey = getPublicKey(serviceAddress + @"/getPublicKey", JsonConvert.SerializeObject(new { loginName = loginName }));
            }
            string pwd = isEncrypted == true ? loginPass : (encryptMode == "RSA" ? RSAEncrypt(publicKey, loginPass) : Base64Encode(loginPass));
            string _para = @"{""loginName"":""" + loginName + @""",""loginPass"":""" + pwd + @"""}";
			getToken(serviceAddress + @"/login", _para);
        }
        public void getToken(string serviceAddress, string para)
        {
            string _json= PostFunction(serviceAddress, para);
			JObject loginResObj = JObject.Parse(_json);
			//Regex reg = new Regex(@"""token"":""(\w+)");            
   //         Match match = reg.Match(_json);
            //_token = match.Groups[1].Value;
			Token = loginResObj["token"].ToString();
			UserID = loginResObj["id"].ToString();
		}
        // 获取登录publicKey，用于加密
        public string getPublicKey(string serviceAddress, string para)
        {
            string publicKey = PostFunction(serviceAddress, para);
            JObject jobj = JObject.Parse(publicKey);
            string Data = jobj["publicKey"].ToString();
            return Data;
			//Regex reg = new Regex(@"""publicKey"":""(\w+)");
			//Match match = reg.Match(publicKey);
			//return match.Groups[1].Value;
		}

		// 获取加密后的密码
		public string getRSAEncryptPassWord(string url, string content)
		{
			string data = GetFunction(url + "?token=" + Token, "");
			JObject jobj = JObject.Parse(data);
			string publicKey = jobj["data"].ToString();
			string encryptString = RSAEncrypt(publicKey, content);
			return encryptString;
		}

		#endregion 大华接口处理

		#region 字符Base64加解密
		/// <summary>
		/// Base64加密，采用utf8编码方式加密
		/// </summary>
		/// <param name="source">待加密的明文</param>
		/// <returns>加密后的字符串</returns>
		public static string Base64Encode(string source)
        {
            return Base64Encode(Encoding.UTF8, source);
        }

        /// <summary>
        /// Base64加密
        /// </summary>
        /// <param name="encodeType">加密采用的编码方式</param>
        /// <param name="source">待加密的明文</param>
        /// <returns></returns>
        public static string Base64Encode(Encoding encodeType, string source)
        {
            string encode = string.Empty;
            byte[] bytes = encodeType.GetBytes(source);
            try
            {
                encode = Convert.ToBase64String(bytes);
            }
            catch
            {
                encode = source;
            }
            return encode;
        }

        /// <summary>
        /// Base64解密，采用utf8编码方式解密
        /// </summary>
        /// <param name="result">待解密的密文</param>
        /// <returns>解密后的字符串</returns>
        public static string Base64Decode(string result)
        {
            return Base64Decode(Encoding.UTF8, result);
        }

        /// <summary>
        /// Base64解密
        /// </summary>
        /// <param name="encodeType">解密采用的编码方式，注意和加密时采用的方式一致</param>
        /// <param name="result">待解密的密文</param>
        /// <returns>解密后的字符串</returns>
        public static string Base64Decode(Encoding encodeType, string result)
        {
            string decode = string.Empty;
            byte[] bytes = Convert.FromBase64String(result);
            try
            {
                decode = encodeType.GetString(bytes);
            }
            catch
            {
                decode = result;
            }
            return decode;
        }

        #endregion 字符Base64加解密

        #region 字符RSA加解密
        /// <summary>
        /// RSA加密
        /// </summary>
        /// <param name="publickey"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        //public static string RSAEncrypt(string publickey, string content, string exponent = "RSA")
        //{
        //    //try
        //    //{
        //    //publickey = string.Format(@"<RSAKeyValue><Modulus>{0}</Modulus><Exponent>{1}</Exponent></RSAKeyValue>", publickey, exponent);
        //    RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
        //    //创建RSA参数对象并加入参数  
        //    RSAParameters RSAKeyInfo = new RSAParameters();
        //    RSAKeyInfo.Modulus = Encoding.UTF8.GetBytes(publickey);
        //    RSAKeyInfo.Exponent = new byte[] { 01, 00, 01 };
        //    //RSAKeyInfo.Exponent = Encoding.UTF8.GetBytes(exponent);
        //    //RSAKeyInfo.Modulus = FromHex(publickey);
        //    //RSAKeyInfo.Exponent = Encoding.UTF8.GetBytes(exponent);
        //    //将参数转载如RSA对象中  
        //    RSA.ImportParameters(RSAKeyInfo);
        //    //RSA.FromXmlString(publickey);
        //    byte[] cipherbytes = RSA.Encrypt(Encoding.UTF8.GetBytes(content), false);

        //    return Convert.ToBase64String(cipherbytes);
        //    //}
        //    //catch (Exception e)
        //    //{

        //    //    return e.Message;
        //    //}
        //}

        public static string RSAEncrypt(string publickey, string content, string exponent = "RSA")
        {
            try
            {
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                byte[] publicKeyBytes = Convert.FromBase64String(publickey);
                AsymmetricKeyParameter privateKey = PublicKeyFactory.CreateKey(publicKeyBytes);
                IBufferedCipher c = CipherUtilities.GetCipher("RSA/None/PKCS1Padding");
                //加密 
                c.Init(true, privateKey);
                byte[] byteData = Encoding.UTF8.GetBytes(content);
                byteData = c.DoFinal(byteData, 0, byteData.Length);
                return Convert.ToBase64String(byteData);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        /// <summary>
        /// RSA解密
        /// </summary>
        /// <param name="privatekey"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string RSADecrypt(string privatekey, string content)
        {
            privatekey = @"<RSAKeyValue><Modulus>5m9m14XH3oqLJ8bNGw9e4rGpXpcktv9MSkHSVFVMjHbfv+SJ5v0ubqQxa5YjLN4vc49z7SVju8s0X4gZ6AzZTn06jzWOgyPRV54Q4I0DCYadWW4Ze3e+BOtwgVU1Og3qHKn8vygoj40J6U85Z/PTJu3hN1m75Zr195ju7g9v4Hk=</Modulus><Exponent>AQAB</Exponent><P>/hf2dnK7rNfl3lbqghWcpFdu778hUpIEBixCDL5WiBtpkZdpSw90aERmHJYaW2RGvGRi6zSftLh00KHsPcNUMw==</P><Q>6Cn/jOLrPapDTEp1Fkq+uz++1Do0eeX7HYqi9rY29CqShzCeI7LEYOoSwYuAJ3xA/DuCdQENPSoJ9KFbO4Wsow==</Q><DP>ga1rHIJro8e/yhxjrKYo/nqc5ICQGhrpMNlPkD9n3CjZVPOISkWF7FzUHEzDANeJfkZhcZa21z24aG3rKo5Qnw==</DP><DQ>MNGsCB8rYlMsRZ2ek2pyQwO7h/sZT8y5ilO9wu08Dwnot/7UMiOEQfDWstY3w5XQQHnvC9WFyCfP4h4QBissyw==</DQ><InverseQ>EG02S7SADhH1EVT9DD0Z62Y0uY7gIYvxX/uq+IzKSCwB8M2G7Qv9xgZQaQlLpCaeKbux3Y59hHM+KpamGL19Kg==</InverseQ><D>vmaYHEbPAgOJvaEXQl+t8DQKFT1fudEysTy31LTyXjGu6XiltXXHUuZaa2IPyHgBz0Nd7znwsW/S44iql0Fen1kzKioEL3svANui63O3o5xdDeExVM6zOf1wUUh/oldovPweChyoAdMtUzgvCbJk1sYDJf++Nr0FeNW1RB1XG30=</D></RSAKeyValue>";
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            byte[] cipherbytes;
            rsa.FromXmlString(privatekey);
            cipherbytes = rsa.Decrypt(Convert.FromBase64String(content), false);

            return Encoding.UTF8.GetString(cipherbytes);
        }
        #endregion

        #region 图片二进制数据与Base64字符串相互转换

        /// <summary>
        /// 将图片二进制数据转换为Base64字符串
        /// </summary>
        /// <param name="imageByte"></param>
        /// <returns>转换后的Base64字符串</returns>
        public static string changeImageTobase64(byte[] imageByte)
        {
            try
            {
                return Convert.ToBase64String(imageByte);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 将图片Base64字符串为二进制数据转换
        /// </summary>
        /// <param name="imageBase64String"></param>
        /// <returns>转换后的二进制数据</returns>
        public static byte[] changeBase64ToImage(string imageBase64String)
        {
            try
            {
                return Convert.FromBase64String(imageBase64String);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion

        #region 调用url接口
        ///post方法调用接口获取json文件内容
        public string PostFunction(string serviceAddress, string strContent)
        {
            try
            {
                //string  serviceAddress= "http://222.111.999.444:8687/tttr/usercrd/uuu/12/dfd7e4";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceAddress);

                request.Method = "POST";
                request.ContentType = "application/json";
                request.KeepAlive = false;
                request.ProtocolVersion = HttpVersion.Version10;
                //string strContent = @"{ ""mmmm"": ""89e"",""nnnnnn"": ""0101943"",""kkkkkkk"": ""e8sodijf9""}";
                using (StreamWriter dataStream = new StreamWriter(request.GetRequestStream()))
                {
                    dataStream.Write(strContent);
                    dataStream.Close();
                }
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string encoding = response.ContentEncoding;
                if (encoding == null || encoding.Length < 1)
                {
                    encoding = "UTF-8"; //默认编码
                }
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encoding));
                string retString = reader.ReadToEnd();
                return retString;
                ////解析josn
                //JObject jo = JObject.Parse(retString);
                //Response.Write(jo["message"]["mmmm"].ToString());
            }
            catch (Exception e)
            {
                //return e.StackTrace;
                return "{\"code\":403,\"data\":\"http://127.0.0.1:80/WPMS\",\"errMsg\":\"" + System.Security.SecurityElement.Escape(e.Message) + "\",\"success\":false}";
            }

        }
        ///get方法调用接口获取json文件内容
        public string GetFunction(string serviceAddress, string strContent)
        {
            try
            {
                //string  serviceAddress= "http://222.111.999.444:8687/tttr/usercrd/uuu/12/dfd7e4";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceAddress + strContent);
                request.Method = "GET";
                request.ContentType = "application/json";
                request.KeepAlive = false;
                request.ProtocolVersion = HttpVersion.Version10;
                //string strContent = @"{ ""mmmm"": ""89e"",""nnnnnn"": ""0101943"",""kkkkkkk"": ""e8sodijf9""}";
                //using (StreamWriter dataStream = new StreamWriter(request.GetRequestStream()))
                //{
                //    dataStream.Write(strContent);
                //    dataStream.Close();
                //}
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string encoding = response.ContentEncoding;
                if (encoding == null || encoding.Length < 1)
                {
                    encoding = "UTF-8"; //默认编码  
                }
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encoding));
                string retString = reader.ReadToEnd();
                return retString;
                ////解析josn
                //JObject jo = JObject.Parse(retString);
                //Response.Write(jo["message"]["mmmm"].ToString());
            }
            catch (Exception e)
            {
                return "{\"code\":403,\"data\":\"http://127.0.0.1:80/WPMS\",\"errMsg\":\"" + System.Security.SecurityElement.Escape(e.Message) + "\",\"success\":false}";
            }

        }
        #endregion 调用url接口

        #region XML处理函数
        /// <summary>
        /// 将XML转为字符串
        /// </summary>
        /// <param name="xmlDoc"></param>
        /// <returns></returns>
        public string ConvertXmlToString(XmlDocument xmlDoc)
        {
            MemoryStream stream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(stream, null);
            writer.Formatting = System.Xml.Formatting.Indented;
            xmlDoc.Save(writer);
            StreamReader sr = new StreamReader(stream, Encoding.UTF8);
            stream.Position = 0;
            string xmlString = sr.ReadToEnd();
            sr.Close();
            stream.Close();
            return xmlString;
        }
        /// <summary>
        /// 将Json字符串转为XML
        /// </summary>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public string ConvertJsonToXml(string jsonString, string rootName = "root")
        {
            XmlDocument xmlDoc = JsonConvert.DeserializeXmlNode(jsonString, rootName);
            //未格式化XML
            //string xmlString = xmlDoc.OuterXml;
            //格式化XML
            MemoryStream stream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(stream, null);
            writer.Formatting = System.Xml.Formatting.Indented;
            xmlDoc.Save(writer);
            StreamReader sr = new StreamReader(stream, Encoding.UTF8);
            stream.Position = 0;
            string xmlString = sr.ReadToEnd();
            sr.Close();
            stream.Close();
            return xmlString;
        }
        /// <summary>
        /// 将XML字符串转为Json
        /// </summary>
        /// <param name="xmlString"></param>
        /// <param name="rootNodeName"></param>
        /// <returns></returns>
        public string ConvertXmlToJson(string xmlString, string rootNodeName= "root")
        {
            string result = null;
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(xmlString);
            XmlNode node = xmldoc.SelectSingleNode(rootNodeName);
            result = JsonConvert.SerializeXmlNode(node);
            return result;
        }

        /// <summary>
        /// 将xml转为Datable
        /// </summary>
        public static DataTable XmlToDataTable(string xmlStr)
        {
            if (!string.IsNullOrEmpty(xmlStr))
            {
                StringReader StrStream = null;
                XmlTextReader Xmlrdr = null;
                try
                {
                    DataSet ds = new DataSet();
                    //读取字符串中的信息  
                    StrStream = new StringReader(xmlStr);
                    //获取StrStream中的数据  
                    Xmlrdr = new XmlTextReader(StrStream);
                    //ds获取Xmlrdr中的数据                 
                    ds.ReadXml(Xmlrdr);
                    return ds.Tables[0];
                }
                catch (Exception e)
                {
                    return null;
                }
                finally
                {
                    //释放资源  
                    if (Xmlrdr != null)
                    {
                        Xmlrdr.Close();
                        StrStream.Close();
                        StrStream.Dispose();
                    }
                }
            }
            return null;
        }
        private string ConvertDataTableToXML(DataTable xmlDS)
        {
            MemoryStream stream = null;
            XmlTextWriter writer = null;
            try
            {
                stream = new MemoryStream();
                writer = new XmlTextWriter(stream, Encoding.Default);
                xmlDS.WriteXml(writer);
                int count = (int)stream.Length;
                byte[] arr = new byte[count];
                stream.Seek(0, SeekOrigin.Begin);
                stream.Read(arr, 0, count);
                UTF8Encoding utf = new UTF8Encoding();
                return utf.GetString(arr).Trim();
            }
            catch
            {
                return String.Empty;
            }
            finally
            {
                if (writer != null) writer.Close();
            }
        }
        #endregion XML处理函数

        #region 参数数组解析
        /// <summary>
        /// 解析各接口参数（键值对形式）
        /// </summary>
        /// <param name="list"></param>
        /// <returns>键值对形式</returns>
        public Dictionary<string, baseParamModels> getParamDict(baseParamModels[] list)
        {
            try
            {
                List<baseParamModels> paramList = new List<baseParamModels>();
                paramList.AddRange(list);
                //Dictionary<string, baseParamModels> dict = new Dictionary<string, baseParamModels>();
                //foreach (var modelItem in paramList)
                //{
                //    dict.Add(modelItem.nodeName, modelItem);
                //}
                Dictionary<string, baseParamModels> dict = paramList.ToDictionary(item => item.nodeName, item => item);
                return dict;
            }
            catch (Exception)
            {
                return new Dictionary<string, baseParamModels>();
            }
        }
        #endregion

        #region 请求参数格式化及返回数据格式化
        /// <summary>
        /// 以POST方式请求返回数据
        /// </summary>
        /// <param name="baseUrl">服务器地址</param>
        /// <param name="serviceAddress">方法名称</param>
        /// <param name="param">参数（对象）</param>
        /// <param name="hasUserId">是否带userID进行请求</param>
        /// <returns></returns>
        public string doRequestWithPost(string baseUrl, string serviceAddress, object param, bool hasUserId=false)
        {
            try
            {
                if (serviceAddress == "")
                {
                    return "请求接口不能为空，请检查！";
                }
                string paramString = JsonConvert.SerializeObject(param);
				//return _token;
				//return UserID;
				//return paramString;
				string _json = hasUserId ? PostFunction(baseUrl + serviceAddress + "?token=" + Token + "&userId=" + UserID, paramString) : PostFunction(baseUrl + serviceAddress + "?token=" + Token, paramString);
                //return ConvertXmlToString(doc);
                return ConvertJsonToXml(_json);
                //return ConvertXmlToJson(ConvertJsonToXml(_json));
            }
            catch (Exception e)
            {
                return "运行出错，错误信息为：" + e.Message;
            }
        }
        /// <summary>
        /// 以POST方式请求返回数据
        /// </summary>
        /// <param name="baseUrl">服务器地址</param>
        /// <param name="serviceAddress">方法名称</param>
        /// <param name="param">参数（字符串）</param>
        /// <param name="hasUserId">是否带userID进行请求</param>
        /// <returns></returns>
        public string doRequestWithPost(string baseUrl, string serviceAddress, string param, bool hasUserId = false)
        {
            try
            {
                if (serviceAddress == "")
                {
                    return "请求接口不能为空，请检查！";
                }
                //string paramString = JsonConvert.SerializeObject(param);
                //return _token;
                //return UserID;
                //return paramString;
                string _json = hasUserId ? PostFunction(baseUrl + serviceAddress + "?token=" + Token + "&userId=" + UserID, param) : PostFunction(baseUrl + serviceAddress + "?token=" + Token, param);
                //return ConvertXmlToString(doc);
                return ConvertJsonToXml(_json);
                //return ConvertXmlToJson(ConvertJsonToXml(_json));
            }
            catch (Exception e)
            {
                return "运行出错，错误信息为：" + e.Message;
            }
        }
        /// <summary>
        /// 以POST方式请求返回数据
        /// </summary>
        /// <param name="serviceAddress">请求完整地址</param>
        /// <param name="param">参数（字符串）</param>
        /// <param name="hasUserId">是否带userID进行请求</param>
        /// <returns></returns>
        public string doRequestWithPost(string serviceAddress, string param, bool hasUserId = false)
        {
            try
            {
                if (serviceAddress == "")
                {
                    return "请求接口不能为空，请检查！";
                }
                string _json = hasUserId ? PostFunction(serviceAddress + "?token=" + Token + "&userId=" + UserID + "&", param) : PostFunction(serviceAddress + "?token=" + Token + "&", param);
                return ConvertJsonToXml(_json);
                //return ConvertXmlToJson(ConvertJsonToXml(_json));
            }
            catch (Exception e)
            {
                return "运行出错，错误信息为：" + e.Message;
            }
        }

        /// <summary>
        /// 以GET方式请求返回数据
        /// </summary>
        /// <param name="baseUrl">服务器地址</param>
        /// <param name="serviceAddress">方法名称</param>
        /// <param name="param">参数（对象）</param>
        /// <param name="hasUserId">是否带userID进行请求</param>
        /// <returns></returns>
        public string doRequestWithGet(string baseUrl, string serviceAddress, object param, bool hasUserId = false)
        {
            try
            {
                if (serviceAddress == "")
                {
                    return "请求接口不能为空，请检查！";
                }
                string paramString = "";
                foreach (var item in param.GetType().GetProperties())
                {
                    paramString += "&" + item.Name + "=" + item.GetValue(param).ToString();
                }
				//return getParamString;
				string _json = hasUserId ? GetFunction(baseUrl + serviceAddress + "?token=" + Token + "&userId=" + UserID, paramString) : GetFunction(baseUrl + serviceAddress + "?token=" + Token, paramString);
				//XmlDocument doc = JsonConvert.DeserializeXmlNode(_json, "root");
                return ConvertJsonToXml(_json);
            }
            catch (Exception e)
            {
                return "运行出错，错误信息为：" + e.Message;
            }
        }
        /// <summary>
        /// 以GET方式请求返回数据
        /// </summary>
        /// <param name="baseUrl">服务器地址</param>
        /// <param name="serviceAddress">方法名称</param>
        /// <param name="param">参数（字符串）</param>
        /// <param name="hasUserId">是否带userID进行请求</param>
        /// <returns></returns>
        public string doRequestWithGet(string baseUrl, string serviceAddress, string param, bool hasUserId = false)
        {
            try
            {
                if (serviceAddress == "")
                {
                    return "请求接口不能为空，请检查！";
                }
                string _json = hasUserId ? GetFunction(baseUrl + serviceAddress + "?token=" + Token + "&userId=" + UserID + "&", param) : GetFunction(baseUrl + serviceAddress + "?token=" + Token + "&", param);
                //XmlDocument doc = JsonConvert.DeserializeXmlNode(_json, "root");
                return ConvertJsonToXml(_json);
            }
            catch (Exception e)
            {
                return "运行出错，错误信息为：" + e.Message;
            }
        }
        /// <summary>
        /// 以GET方式请求返回数据
        /// </summary>
        /// <param name="serviceAddress">请求完整地址</param>
        /// <param name="param">参数（字符串）</param>
        /// <param name="hasUserId">是否带userID进行请求</param>
        /// <returns></returns>
        public string doRequestWithGet(string serviceAddress, string param, bool hasUserId = false)
        {
            try
            {
                if (serviceAddress == "")
                {
                    return "请求接口不能为空，请检查！";
                }
                string _json = hasUserId ? GetFunction(serviceAddress + "?token=" + Token + "&userId=" + UserID + "&", param) : GetFunction(serviceAddress + "?token=" + Token + "&", param);
                //XmlDocument doc = JsonConvert.DeserializeXmlNode(_json, "root");
                return ConvertJsonToXml(_json);
            }
            catch (Exception e)
            {
                return "运行出错，错误信息为：" + e.Message;
            }
        }
        #endregion

        #region 格式化请求结果
        public string FormattingJsonString (string jsonString)
        {

            return "";
        }
        #endregion

    }
}
