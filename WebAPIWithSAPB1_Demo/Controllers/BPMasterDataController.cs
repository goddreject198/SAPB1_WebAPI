using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SAPbobsCOM;
using WebAPIWithSAPB1_Demo.Models.BPMasterData;

namespace WebAPIWithSAPB1_Demo.Controllers
{
    public class BPMasterDataController : ApiController
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public IHttpActionResult Post([FromBody] Parameter para)
        {
            var DT_Result = new DataTable();
            Respose respose = new Respose();
            if (para != null)
            {
                if (para.sID != "JSM01_20210727")
                {
                    respose.sCode = "F";
                    respose.sMSG = "Wrong ID";
                    respose.sUID = para.sUID;
                    respose.sIFSYS = para.sIFSYS;
                    respose.sFUNCNM = para.sFUNCNM;
                    respose.sBUSINESSNM = para.sBUSINESSNM;
                    return Ok(respose);
                }
                if (para.sFUNCNM != "Wjsif_stdocrd01_jsm")
                {
                    respose.sCode = "F";
                    respose.sMSG = "Wrong function";
                    respose.sUID = para.sUID;
                    respose.sIFSYS = para.sIFSYS;
                    respose.sFUNCNM = para.sFUNCNM;
                    respose.sBUSINESSNM = para.sBUSINESSNM;
                    return Ok(respose);
                }

                respose.sUID = para.sUID;
                respose.sIFSYS = para.sIFSYS;
                respose.sFUNCNM = para.sFUNCNM;
                respose.sBUSINESSNM = para.sBUSINESSNM;
                respose.oDOC = new List<para_odoc>();
                foreach (var odoc in para.oDoc)
                {
                    SAPbobsCOM.BusinessPartners vBP = (SAPbobsCOM.BusinessPartners)Info_Class.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oBusinessPartners);
                    if (vBP.GetByKey(odoc.CARDCD))
                    {
                        odoc.APIERRCD = "Duplicate";
                        odoc.APIERRMSG = "This customer already exist in SAP B1";
                    }

                    vBP.CardCode = odoc.CARDCD;
                    vBP.CardName = odoc.CARDNM;
                    if (!string.IsNullOrEmpty(odoc.VATREGNUM))
                        vBP.CompanyRegistrationNumber = odoc.VATREGNUM;
                    if (!string.IsNullOrEmpty(odoc.INDUSTRY))
                        vBP.BusinessType = odoc.INDUSTRY;
                    if (!string.IsNullOrEmpty(odoc.BUSINESS))
                        vBP.IndustryType = odoc.BUSINESS;
                    if (!string.IsNullOrEmpty(odoc.OWNER))
                        vBP.RepresentativeName = odoc.OWNER;
                    if (!string.IsNullOrEmpty(odoc.ADDRESS))
                        vBP.Address = odoc.ADDRESS;
                    if (!string.IsNullOrEmpty(odoc.EMAIL))
                        vBP.EmailAddress = odoc.EMAIL;
                    if (!string.IsNullOrEmpty(odoc.RMK))
                        vBP.Notes = odoc.RMK;
                    if (!string.IsNullOrEmpty(odoc.COUNTRY))
                        vBP.Country = odoc.COUNTRY;
                    if (odoc.arrCONT != null)
                    {
                        foreach (var arrCONT in odoc.arrCONT)
                        {
                            vBP.ContactEmployees.Name = arrCONT.CARDCD;
                            vBP.ContactEmployees.FirstName = arrCONT.CONTNM;
                            vBP.ContactEmployees.E_Mail = arrCONT.EMAIL;
                            vBP.ContactEmployees.Remarks1 = arrCONT.RMK;
                            vBP.ContactEmployees.Add();
                        }
                    }

                    int kq = vBP.Add();
                    if (kq == 0)
                    {
                        if (vBP.GetByKey(odoc.CARDCD))
                        {
                            log.InfoFormat("BP Master Data, Create successfully, CardCode: {0}", odoc.CARDCD);
                            odoc.APIERRCD = "Successfully";
                            odoc.APIERRMSG = "Create customer successfully in SAP B1";

                            //Recordset oR_Project_Info = (Recordset)Info_Class.oCompany.GetBusinessObject(BoObjectTypes.BoRecordset);
                            //string str_sql = string.Format(@"SELECT * FROM OCRD WHERE ""CardCode"" = '{0}';", odoc.CARDCD);
                            //oR_Project_Info.DoQuery(str_sql);

                            //DT_Result.Columns.Add("CARDCD");
                            //DT_Result.Columns.Add("CARDNM");
                            //DT_Result.Columns.Add("VATREGNUM");
                            //DT_Result.Columns.Add("INDUSTRY");
                            //DT_Result.Columns.Add("BUSINESS");
                            //DT_Result.Columns.Add("OWNER");
                            //DT_Result.Columns.Add("ADDRESS");
                            //DT_Result.Columns.Add("EMAIL");
                            //DT_Result.Columns.Add("RMK");
                            //DT_Result.Columns.Add("COUNTRY");
                            //while (!oR_Project_Info.EoF)
                            //{
                            //    DataRow dr = DT_Result.NewRow();
                            //    dr[0] = oR_Project_Info.Fields.Item("CardCode").Value.ToString();
                            //    dr[1] = oR_Project_Info.Fields.Item("CardName").Value.ToString();
                            //    dr[2] = oR_Project_Info.Fields.Item("NINum").Value.ToString();
                            //    dr[3] = oR_Project_Info.Fields.Item("CardType").Value.ToString();
                            //    dr[4] = oR_Project_Info.Fields.Item("Industry").Value.ToString();
                            //    dr[5] = oR_Project_Info.Fields.Item("RepName").Value.ToString();
                            //    dr[6] = oR_Project_Info.Fields.Item("Address").Value.ToString();
                            //    dr[7] = oR_Project_Info.Fields.Item("E_Mail").Value.ToString();
                            //    dr[8] = oR_Project_Info.Fields.Item("Notes").Value.ToString();
                            //    dr[9] = oR_Project_Info.Fields.Item("Country").Value.ToString();
                            //    DT_Result.Rows.Add(dr);

                            //    oR_Project_Info.MoveNext();
                            //}
                        }
                        else
                        {
                            log.ErrorFormat("BP Master Data, Post Error: {0}", Info_Class.oCompany.GetLastErrorDescription());
                            odoc.APIERRCD = "Failed";
                            odoc.APIERRMSG = Info_Class.oCompany.GetLastErrorDescription();
                        }
                    }
                    else
                    {
                        //string error = Info_Class.oCompany.GetLastErrorDescription();
                        //return BadRequest("Create failed, Error: " + error);
                        odoc.APIERRCD = "Failed";
                        odoc.APIERRMSG = Info_Class.oCompany.GetLastErrorDescription();
                    }

                    respose.oDOC.Add(odoc);
                }
            }
            else
            {
                return BadRequest();
            }
            //return Created("Created", DT_Result);
            respose.sCode = "S";
            respose.sMSG = "Accepted";
            return Ok(respose);
        }
    }
}
