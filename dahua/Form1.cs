using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using dahua.InterfaceParams;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace dahua
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [ComVisible(true)]//COM+组件可见
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private dahuajk jk;
        private string baseUrl;
        private Dictionary<string, baseParamModels> paramDict;

        #region 图片流转换测试
        private void button2_Click(object sender, EventArgs e)
        {
            jk = new dahuajk("http://10.100.4.14/WPMS/login", "system", "admin123", false);
            string url;
            string _json;
            //url = "http://10.100.4.14/CardSolution/card/accessControl/device/bycondition/combined";
            //_json = jk.getDevice(url, 100, 1);
            //url = "http://10.100.4.14/CardSolution/card/accessControl/swingCardRecord/bycondition/combined";
            //_json = jk.getSwingCardRecord(url, "2018-11-01 17:50:00", "2018-11-04 17:53:00", 100, 1);
            url = "http://10.100.4.14/CardSolution/card/accessControl/doorAuthority";
            //_json = jk.getPersonKeyByCardNumber(url, 00000112);
            //_json = card.getPersonKeyByCardNumber(url, 00000112);
            url = "http://10.100.4.14/CardSolution/card/person/bycondition/combined";
            //_json = jk.getPersonInfo(url, 10);
            //_json = card.getPersonInfo(url, 10);
            //textBox1.Text = _json;
            string picString = changeImageTobase64();
            ToImage(picString);
        }
        /// <summary>
        /// 将图片数据转换为Base64字符串
        /// </summary>
        /// <returns>base64</returns>
        public string changeImageTobase64(){
            Image img = this.pictureBox1.Image;
            BinaryFormatter binFormatter = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream();
            binFormatter.Serialize(memStream, img);
            byte[] bytes = memStream.GetBuffer();
            //return bytes.ToString();
            string base64 = Convert.ToBase64String(bytes);
            textBox1.Text = base64;
            return base64;
        }

        /// <summary>
        /// 将Base64字符串转换为图片
        /// </summary>
        /// <param name="base64String"></param>
        private void ToImage(string base64String)
        {
            byte[] bytes = Convert.FromBase64String(base64String);
            MemoryStream memStream = new MemoryStream(bytes);
            BinaryFormatter binFormatter = new BinaryFormatter();
            Image img = (Image)binFormatter.Deserialize(memStream);
            pictureBox2.Image = img;
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            //jk = new dahuajk("http://10.100.4.14/WPMS", "system", "admin123", false);
            jk = new dahuajk("http://60.191.94.122:9331/WPMS", "8900yanshi", "8900yanshi1", false, true);
            CardParams cardParams = new CardParams();
            paramDict = jk.getParamDict(cardParams.modelList());
            baseUrl = cardParams.baseUrl;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string _json;
            if (e.Node.Level > 1)
            {
                toolStripStatusLabel1.Text = "操作中。。。";
                try
                {
                    var thisNode = paramDict[e.Node.Name];
                    if (!thisNode.isPost || string.IsNullOrWhiteSpace(thisNode.isPost.ToString()))
                    {
						if (!string.IsNullOrWhiteSpace(thisNode.hasUserId.ToString()))
						{
							_json = jk.doRequestWithGet(baseUrl, thisNode.url, thisNode.param, true);
						}
						else
						{
							_json = jk.doRequestWithGet(baseUrl, thisNode.url, thisNode.param);
						}
                    }
                    else
                    {
						if (!string.IsNullOrWhiteSpace(thisNode.hasUserId.ToString()))
						{
							_json = jk.doRequestWithPost(baseUrl, thisNode.url, thisNode.param, true);
						}
						else
						{
							_json = jk.doRequestWithPost(baseUrl, thisNode.url, thisNode.param);
						}
                    }
                }
                catch (Exception)
                {
                    _json = "未设置参数，请检查！";
                }
                textBox1.Text = _json;
                toolStripStatusLabel1.Text = "就绪";
            }
            //textBox1.Text = e.Node.Name;
        }
    }
}
