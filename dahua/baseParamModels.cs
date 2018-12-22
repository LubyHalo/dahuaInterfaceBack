using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dahua
{
    public class baseParamModels
    {
        public string nodeName { get; set; }
        public string url { get; set; }
        public object param { get; set; }
        public bool isPost { get; set; }
		public bool hasUserId { get; set; }
    }
}
