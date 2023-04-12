using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPIWithSAPB1_Demo.Models.BPMasterData
{
    public class para_odoc
    {
        [Required]
        public string CARDCD { get; set; }
        public string CARDNM { get; set; }
        public string VATREGNUM { get; set; }
        public string INDUSTRY { get; set; }
        public string BUSINESS { get; set; }
        public string OWNER { get; set; }
        public string ADDRESS { get; set; }
        public string EMAIL { get; set; }
        public DateTime CRUPDT { get; set; }
        public string RMK { get; set; }
        public string SFID { get; set; }
        public string SLPCD { get; set; }
        public string COUNTRY { get; set; }
        public List<para_arrBank> arrBANK { get; set; }
        public List<para_arrCONT> arrCONT { get; set; }

        public string APIERRCD { get; set; }
        public string APIERRMSG { get; set; }
    }
}