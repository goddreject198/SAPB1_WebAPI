using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIWithSAPB1_Demo.Models.BPMasterData
{
    public class Parameter
    {
        public string sID { get; set; }
        public string sPW { get; set; }
        public string sUID { get; set; }
        public string sIFSYS { get; set; }
        public string sFUNCNM { get; set; }
        public string sBUSINESSNM { get; set; }
        public List<para_odoc> oDoc { get; set; }
    }
}