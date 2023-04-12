using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIWithSAPB1_Demo.Models.ItemMasterData
{
    public class response_odoc
    {
        public string ROWNUM { get; set; }
        public string ITEMCD { get; set; }
        public string ITEMNM { get; set; }
        public string ITEMGROUP { get; set; }
        public string ITEMGROUPNM { get; set; }
        public string LCLASS { get; set; }
        public string LCLASSNM { get; set; }
        public string MCLASS { get; set; }
        public string MCLASSNM { get; set; }
        public string SERIALMAN { get; set; }
        public string INVITEM { get; set; }
        public string MODEL { get; set; }
        public string RMODEL { get; set; }
        public string RMODELNM { get; set; }
        public string SPEC { get; set; }
        public string BASICCD { get; set; }
        public string BASICNM { get; set; }
        public string SELRA { get; set; }
        public string SELRANM { get; set; }
        public string CTSEQ { get; set; }
        public string DERNO { get; set; }
        public string ECNETC { get; set; }
        public string INVUOM { get; set; }
        public string VALIDFOR { get; set; }
        public string OLDITEMCD { get; set; }
    }
}