using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SAPbobsCOM;
using Sap.Data.Hana;
using System.Data;
using WebAPIWithSAPB1_Demo.Models;

namespace WebAPIWithSAPB1_Demo.Controllers
{
    public class ValuesController : ApiController
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // GET: api/values
        public IHttpActionResult Get()
        {

            Recordset oR_Project_Info = (Recordset)Info_Class.oCompany.GetBusinessObject(BoObjectTypes.BoRecordset);
            string str_sql = string.Format(@"SELECT TOP 10 * FROM ORDR;");
            oR_Project_Info.DoQuery(str_sql);

            var DT_Result = new DataTable();
            DT_Result.Columns.Add("DocEntry");
            DT_Result.Columns.Add("DocNum");
            while (!oR_Project_Info.EoF)
            {
                DataRow dr = DT_Result.NewRow();
                dr[0] = oR_Project_Info.Fields.Item("DocEntry").Value.ToString();
                dr[1] = oR_Project_Info.Fields.Item("DocNum").Value.ToString();
                DT_Result.Rows.Add(dr);

                oR_Project_Info.MoveNext();
            }    
            
            return Ok(DT_Result);
        }

        // GET api/values/5
        public IHttpActionResult Get(string id)
        {
            Recordset oR_Project_Info = (Recordset)Info_Class.oCompany.GetBusinessObject(BoObjectTypes.BoRecordset);
            string str_sql_item = string.Format(@"SELECT * FROM ""RDR1"" WHERE ""DocEntry"" in ({0});", id);
            oR_Project_Info.DoQuery(str_sql_item);
            var DT_Item = new DataTable();
            DT_Item.Columns.Add("DocEntry");
            DT_Item.Columns.Add("LineNum");
            DT_Item.Columns.Add("LineStatus");
            DT_Item.Columns.Add("ItemCode");
            while (!oR_Project_Info.EoF)
            {
                DataRow dr = DT_Item.NewRow();
                dr[0] = oR_Project_Info.Fields.Item("DocEntry").Value.ToString();
                dr[1] = oR_Project_Info.Fields.Item("LineNum").Value.ToString();
                dr[2] = oR_Project_Info.Fields.Item("LineStatus").Value.ToString();
                dr[3] = oR_Project_Info.Fields.Item("ItemCode").Value.ToString();
                DT_Item.Rows.Add(dr);

                oR_Project_Info.MoveNext();
            }
            List<PRQ1> listName_item = DT_Item.AsEnumerable().Select(m => new PRQ1()
            {
                DocEntry = m.Field<string>("DocEntry"),
                LineNum = m.Field<string>("LineNum"),
                LineStatus = m.Field<string>("LineStatus"),
                ItemCode = m.Field<string>("ItemCode"),
            }).ToList();


            string str_sql = string.Format(@"SELECT * FROM ""ORDR"" WHERE ""DocEntry"" in ({0});", id);
            oR_Project_Info.DoQuery(str_sql);

            var DT_Result = new DataTable();
            DT_Result.Columns.Add("DocEntry");
            DT_Result.Columns.Add("DocNum");
            DT_Result.Columns.Add("CardCode");
            DT_Result.Columns.Add("CardName");
            while (!oR_Project_Info.EoF)
            {
                DataRow dr = DT_Result.NewRow();
                dr[0] = oR_Project_Info.Fields.Item("DocEntry").Value.ToString();
                dr[1] = oR_Project_Info.Fields.Item("DocNum").Value.ToString();
                dr[2] = oR_Project_Info.Fields.Item("CardCode").Value.ToString();
                dr[3] = oR_Project_Info.Fields.Item("CardName").Value.ToString();
                DT_Result.Rows.Add(dr);

                oR_Project_Info.MoveNext();
            }


            List<OPRQ> listName = DT_Result.AsEnumerable().Select(m => new OPRQ()
            {
                DocEntry = m.Field<string>("DocEntry"),
                DocNum = m.Field<string>("DocNum"),
                CardCode = m.Field<string>("CardCode"),
                CardName = m.Field<string>("CardName"),
                Items = listName_item.Where(s => s.DocEntry == m.Field<string>("DocEntry")).ToList(),
            }).ToList();

            

            return Ok(listName);
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
