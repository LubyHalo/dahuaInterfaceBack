using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace dahua.Card
{
    class AccessControl
    {
        private dahuajk _jk;
        public AccessControl(dahuajk dahuajk)
        {
            _jk = dahuajk;
        }
        
        

        // node1_4：查询设备
        //public string getDevice(string serviceAddress, int pageSize, int pageNum)
        //{
        //    string _para = "{\"pageNum\":" + pageNum.ToString() + ",\"pageSize\":" + pageSize.ToString() + "}";
        //    string _json = _jk.PostFunction(serviceAddress + "?token=" + _jk.Token, _para);
        //    XmlDocument doc = (XmlDocument)JsonConvert.DeserializeXmlNode(_json, "root");
        //    return _jk.ConvertXmlToString(doc);
        //}

        // node8_1：刷卡记录查询
        //public string getSwingCardRecord(string serviceAddress, string startSwingTime, string EndSwingTime, int pageSize, int pageNum)
        //{
        //    string _para = "{\"pageNum\":" + pageNum.ToString() + ",\"pageSize\":" + pageSize.ToString() +
        //    ",\"startSwingTime\":\"" + startSwingTime + "\",\"endSwingTime\":\"" + EndSwingTime + "\",\"openType\":61}";
        //    string _json = _jk.PostFunction(serviceAddress + "?token=" + _jk.Token, _para);
        //    XmlDocument doc = (XmlDocument)JsonConvert.DeserializeXmlNode(_json, "root");
        //    return _jk.ConvertXmlToString(doc);
        //}

        //public string getPersonKeyByCardNumber(string serviceAddress, int cardNumber)
        //{
        //    dahuajk jk = new dahuajk("http://10.100.4.14/WPMS/login", "system", "admin123", false);
        //    string _para = "{\"cardNumber\":" + cardNumber.ToString() + "}";
        //    string _json = jk.PostFunction(serviceAddress + "?token=" + jk.Token, _para);
        //    XmlDocument doc = (XmlDocument)JsonConvert.DeserializeXmlNode(_json, "root");
        //    return jk.ConvertXmlToString(doc);
        //}

        //public string getPersonInfo(string serviceAddress, int pageSize)
        //{
        //    string _para = "{\"pageSize\":" + pageSize.ToString() + "}";
        //    string _json = _jk.PostFunction(serviceAddress + "?token=" + _jk.Token, _para);
        //    XmlDocument doc = (XmlDocument)JsonConvert.DeserializeXmlNode(_json, "root");
        //    return _jk.ConvertXmlToString(doc);
        //}
    }
}
