using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIWithSAPB1_Demo.Models
{
    public class OPRQ
    {
        public string DocEntry { get; set; }
        public string DocNum { get; set; }
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public List<PRQ1> Items { get; set; }
    }
}