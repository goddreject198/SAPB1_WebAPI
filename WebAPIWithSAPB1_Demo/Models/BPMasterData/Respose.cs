using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIWithSAPB1_Demo.Models.BPMasterData
{
    public class Respose
    {
        public string sCode { get; set; }
        public string sMSG { get; set; }
        public string sUID { get; set; }
        public string sIFSYS { get; set; }
        public string sFUNCNM { get; set; }
        public string sBUSINESSNM { get; set; }
        public List<para_odoc> oDOC { get; set; }
    }
}