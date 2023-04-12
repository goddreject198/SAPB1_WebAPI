using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SAPbobsCOM;
using WebAPIWithSAPB1_Demo.Models.ItemMasterData;

namespace WebAPIWithSAPB1_Demo.Controllers
{
    public class ItemMasterDataController : ApiController
    {
        public IHttpActionResult Get([FromBody] Parameter para)
        { 
            

            #region old

            //string str_sql = "";
            //if (string.IsNullOrEmpty(para.ItemName))
            //{
            //    if (string.IsNullOrEmpty(para.LCLASS))
            //    {
            //        if (string.IsNullOrEmpty(para.MCLASS))
            //        {
            //            str_sql = string.Format(@"SELECT T0.""ItemCode""
            //                                        ,T0.""ItemName""
            //                                        ,T0.""ItmsGrpCod""
            //                                        ,T1.""ItmsGrpNam""
            //                                        ,T0.""TaxCtg""
            //                                        ,T0.""GstTaxCtg"" 
            //                                        ,T0.""U_LCLASS"" 
            //                                        ,T0.""U_MCLASS""
            //                                  ,T0.""U_MODEL""
            //                                  ,T0.""U_SPEC""
            //                                  ,T0.""U_BASICCD""
            //                                  ,T0.""U_SELRA""
            //                                  ,T0.""U_CTSEQ""
            //                                  ,T0.""U_DERNO""
            //                                  ,T0.""U_ECNETC""
            //                                FROM OITM T0 LEFT JOIN OITB T1 ON T0.""ItmsGrpCod"" = T1.""ItmsGrpCod""
            //                                WHERE T0.""ItemCode"" BETWEEN '{0}' AND '{1}' ORDER BY T0.""ItemCode"";", para.ItemCodeStart, para.ItemCodeEnd);
            //        }
            //        else
            //        {
            //            str_sql = string.Format(@"SELECT T0.""ItemCode""
            //                                        ,T0.""ItemName""
            //                                        ,T0.""ItmsGrpCod""
            //                                        ,T1.""ItmsGrpNam""
            //                                        ,T0.""TaxCtg""
            //                                        ,T0.""GstTaxCtg"" 
            //                                        ,T0.""U_LCLASS"" 
            //                                        ,T0.""U_MCLASS""
            //                                  ,T0.""U_MODEL""
            //                                  ,T0.""U_SPEC""
            //                                  ,T0.""U_BASICCD""
            //                                  ,T0.""U_SELRA""
            //                                  ,T0.""U_CTSEQ""
            //                                  ,T0.""U_DERNO""
            //                                  ,T0.""U_ECNETC""
            //                                FROM OITM T0 LEFT JOIN OITB T1 ON T0.""ItmsGrpCod"" = T1.""ItmsGrpCod""
            //                                WHERE (T0.""ItemCode"" BETWEEN '{0}' AND '{1}') AND T0.""U_MCLASS"" = '{2}' ORDER BY T0.""ItemCode"";", para.ItemCodeStart, para.ItemCodeEnd, para.MCLASS);
            //        }
            //    }
            //    else
            //    {
            //        if (string.IsNullOrEmpty(para.MCLASS))
            //        {
            //            str_sql = string.Format(@"SELECT T0.""ItemCode""
            //                                        ,T0.""ItemName""
            //                                        ,T0.""ItmsGrpCod""
            //                                        ,T1.""ItmsGrpNam""
            //                                        ,T0.""TaxCtg""
            //                                        ,T0.""GstTaxCtg"" 
            //                                        ,T0.""U_LCLASS"" 
            //                                        ,T0.""U_MCLASS""
            //                                  ,T0.""U_MODEL""
            //                                  ,T0.""U_SPEC""
            //                                  ,T0.""U_BASICCD""
            //                                  ,T0.""U_SELRA""
            //                                  ,T0.""U_CTSEQ""
            //                                  ,T0.""U_DERNO""
            //                                  ,T0.""U_ECNETC""
            //                                FROM OITM T0 LEFT JOIN OITB T1 ON T0.""ItmsGrpCod"" = T1.""ItmsGrpCod""
            //                                WHERE (T0.""ItemCode"" BETWEEN '{0}' AND '{1}') AND T0.""U_LCLASS"" = '{2}' ORDER BY T0.""ItemCode"";", para.ItemCodeStart, para.ItemCodeEnd, para.LCLASS);
            //        }
            //        else
            //        {
            //            str_sql = string.Format(@"SELECT T0.""ItemCode""
            //                                        ,T0.""ItemName""
            //                                        ,T0.""ItmsGrpCod""
            //                                        ,T1.""ItmsGrpNam""
            //                                        ,T0.""TaxCtg""
            //                                        ,T0.""GstTaxCtg"" 
            //                                        ,T0.""U_LCLASS"" 
            //                                        ,T0.""U_MCLASS""
            //                                  ,T0.""U_MODEL""
            //                                  ,T0.""U_SPEC""
            //                                  ,T0.""U_BASICCD""
            //                                  ,T0.""U_SELRA""
            //                                  ,T0.""U_CTSEQ""
            //                                  ,T0.""U_DERNO""
            //                                  ,T0.""U_ECNETC""
            //                                FROM OITM T0 LEFT JOIN OITB T1 ON T0.""ItmsGrpCod"" = T1.""ItmsGrpCod""
            //                                WHERE (T0.""ItemCode"" BETWEEN '{0}' AND '{1}') AND T0.""U_LCLASS"" = '{2}' AND T0.""U_MCLASS"" = '{3}' ORDER BY T0.""ItemCode"";", para.ItemCodeStart, para.ItemCodeEnd, para.LCLASS, para.MCLASS);
            //        }
            //    }
            //}
            //else
            //{
            //    if (string.IsNullOrEmpty(para.LCLASS))
            //    {
            //        if (string.IsNullOrEmpty(para.MCLASS))
            //        {
            //            str_sql = string.Format(@"SELECT T0.""ItemCode""
            //                                        ,T0.""ItemName""
            //                                        ,T0.""ItmsGrpCod""
            //                                        ,T1.""ItmsGrpNam""
            //                                        ,T0.""TaxCtg""
            //                                        ,T0.""GstTaxCtg"" 
            //                                        ,T0.""U_LCLASS"" 
            //                                        ,T0.""U_MCLASS""
            //                                  ,T0.""U_MODEL""
            //                                  ,T0.""U_SPEC""
            //                                  ,T0.""U_BASICCD""
            //                                  ,T0.""U_SELRA""
            //                                  ,T0.""U_CTSEQ""
            //                                  ,T0.""U_DERNO""
            //                                  ,T0.""U_ECNETC""
            //                                FROM OITM T0 LEFT JOIN OITB T1 ON T0.""ItmsGrpCod"" = T1.""ItmsGrpCod""
            //                                WHERE (T0.""ItemCode"" BETWEEN '{0}' AND '{1}') AND T0.""ItemName"" like '%{2}%' ORDER BY T0.""ItemCode"";", para.ItemCodeStart, para.ItemCodeEnd, para.ItemName);
            //        }
            //        else
            //        {
            //            str_sql = string.Format(@"SELECT T0.""ItemCode""
            //                                        ,T0.""ItemName""
            //                                        ,T0.""ItmsGrpCod""
            //                                        ,T1.""ItmsGrpNam""
            //                                        ,T0.""TaxCtg""
            //                                        ,T0.""GstTaxCtg"" 
            //                                        ,T0.""U_LCLASS"" 
            //                                        ,T0.""U_MCLASS""
            //                                  ,T0.""U_MODEL""
            //                                  ,T0.""U_SPEC""
            //                                  ,T0.""U_BASICCD""
            //                                  ,T0.""U_SELRA""
            //                                  ,T0.""U_CTSEQ""
            //                                  ,T0.""U_DERNO""
            //                                  ,T0.""U_ECNETC""
            //                                FROM OITM T0 LEFT JOIN OITB T1 ON T0.""ItmsGrpCod"" = T1.""ItmsGrpCod""
            //                                WHERE (T0.""ItemCode"" BETWEEN '{0}' AND '{1}') AND T0.""ItemName"" like '%{2}%' AND T0.""U_MCLASS"" = '{3}' ORDER BY T0.""ItemCode"";", para.ItemCodeStart, para.ItemCodeEnd, para.ItemName, para.MCLASS);
            //        }
            //    }
            //    else
            //    {
            //        if (string.IsNullOrEmpty(para.MCLASS))
            //        {
            //            str_sql = string.Format(@"SELECT T0.""ItemCode""
            //                                        ,T0.""ItemName""
            //                                        ,T0.""ItmsGrpCod""
            //                                        ,T1.""ItmsGrpNam""
            //                                        ,T0.""TaxCtg""
            //                                        ,T0.""GstTaxCtg"" 
            //                                        ,T0.""U_LCLASS"" 
            //                                        ,T0.""U_MCLASS""
            //                                  ,T0.""U_MODEL""
            //                                  ,T0.""U_SPEC""
            //                                  ,T0.""U_BASICCD""
            //                                  ,T0.""U_SELRA""
            //                                  ,T0.""U_CTSEQ""
            //                                  ,T0.""U_DERNO""
            //                                  ,T0.""U_ECNETC""
            //                                FROM OITM T0 LEFT JOIN OITB T1 ON T0.""ItmsGrpCod"" = T1.""ItmsGrpCod""
            //                                WHERE (T0.""ItemCode"" BETWEEN '{0}' AND '{1}') AND T0.""ItemName"" like '%{2}%' AND T0.""U_LCLASS"" = '{3}' ORDER BY T0.""ItemCode"";", para.ItemCodeStart, para.ItemCodeEnd, para.ItemName, para.LCLASS);
            //        }
            //        else
            //        {
            //            str_sql = string.Format(@"SELECT T0.""ItemCode""
            //                                        ,T0.""ItemName""
            //                                        ,T0.""ItmsGrpCod""
            //                                        ,T1.""ItmsGrpNam""
            //                                        ,T0.""TaxCtg""
            //                                        ,T0.""GstTaxCtg"" 
            //                                        ,T0.""U_LCLASS"" 
            //                                        ,T0.""U_MCLASS""
            //                                  ,T0.""U_MODEL""
            //                                  ,T0.""U_SPEC""
            //                                  ,T0.""U_BASICCD""
            //                                  ,T0.""U_SELRA""
            //                                  ,T0.""U_CTSEQ""
            //                                  ,T0.""U_DERNO""
            //                                  ,T0.""U_ECNETC""
            //                                FROM OITM T0 LEFT JOIN OITB T1 ON T0.""ItmsGrpCod"" = T1.""ItmsGrpCod""
            //                                WHERE (T0.""ItemCode"" BETWEEN '{0}' AND '{1}') AND T0.""ItemName"" like '%{2}%' AND T0.""U_LCLASS"" = '{3}' AND T0.""U_MCLASS"" = '{4}' ORDER BY T0.""ItemCode"";", para.ItemCodeStart, para.ItemCodeEnd, para.ItemName, para.LCLASS, para.MCLASS);
            //        }
            //    }
            //}

            #endregion

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
                if (para.sFUNCNM != "Wjsif_stditemmaster_jsm")
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
                respose.oDOC = new List<response_odoc>();
                foreach (var odoc in para.oDoc)
                {
                    Recordset oR_Project_Info =
                        (Recordset) Info_Class.oCompany.GetBusinessObject(BoObjectTypes.BoRecordset);

                    string str_sql =
                        string.Format("CALL ODOO_WebAPI_DEMO_ItemMasterData('{0}','{1}','{2}','{3}','{4}');",
                            odoc.PRAM01, odoc.PRAM02, odoc.PRAM03, odoc.PRAM04, odoc.PRAM05);

                    oR_Project_Info.DoQuery(str_sql);

                    //var DT_Result = new DataTable();
                    //DT_Result.Columns.Add("ROWNUM");
                    //DT_Result.Columns.Add("ITEMCD");
                    //DT_Result.Columns.Add("ITEMNM");
                    //DT_Result.Columns.Add("ITEMGROUP");
                    //DT_Result.Columns.Add("ITEMGROUPNM");
                    //DT_Result.Columns.Add("LCLASS");
                    //DT_Result.Columns.Add("LCLASSNM");
                    //DT_Result.Columns.Add("MCLASS");
                    //DT_Result.Columns.Add("MCLASSNM");
                    //DT_Result.Columns.Add("SERIALMAN");
                    //DT_Result.Columns.Add("INVITEM");
                    //DT_Result.Columns.Add("MODEL");
                    //DT_Result.Columns.Add("RMODEL");
                    //DT_Result.Columns.Add("RMODELNM");
                    //DT_Result.Columns.Add("SPEC");
                    //DT_Result.Columns.Add("BASICCD");
                    //DT_Result.Columns.Add("BASICNM");
                    //DT_Result.Columns.Add("SELRA");
                    //DT_Result.Columns.Add("SELRANM");
                    //DT_Result.Columns.Add("CTSEQ");
                    //DT_Result.Columns.Add("DERNO");
                    //DT_Result.Columns.Add("ECNETC");
                    //DT_Result.Columns.Add("INVUOM");
                    //DT_Result.Columns.Add("VALIDFOR");
                    //DT_Result.Columns.Add("OLDITEMCD");
                    
                    while (!oR_Project_Info.EoF)
                    {
                        //DataRow dr = DT_Result.NewRow();
                        //dr[0] = oR_Project_Info.Fields.Item("ROWNUM").Value.ToString();
                        //dr[1] = oR_Project_Info.Fields.Item("ITEMCD").Value.ToString();
                        //dr[2] = oR_Project_Info.Fields.Item("ITEMNM").Value.ToString();
                        //dr[3] = oR_Project_Info.Fields.Item("ITEMGROUP").Value.ToString();
                        //dr[4] = oR_Project_Info.Fields.Item("ITEMGROUPNM").Value.ToString();
                        //dr[5] = oR_Project_Info.Fields.Item("LCLASS").Value.ToString();
                        //dr[6] = oR_Project_Info.Fields.Item("LCLASSNM").Value.ToString();
                        //dr[7] = oR_Project_Info.Fields.Item("MCLASS").Value.ToString();
                        //dr[8] = oR_Project_Info.Fields.Item("MCLASSNM").Value.ToString();
                        //dr[9] = oR_Project_Info.Fields.Item("SERIALMAN").Value.ToString();
                        //dr[10] = oR_Project_Info.Fields.Item("INVITEM").Value.ToString();
                        //dr[11] = oR_Project_Info.Fields.Item("MODEL").Value.ToString();
                        //dr[12] = oR_Project_Info.Fields.Item("RMODEL").Value.ToString();
                        //dr[13] = oR_Project_Info.Fields.Item("RMODELNM").Value.ToString();
                        //dr[14] = oR_Project_Info.Fields.Item("SPEC").Value.ToString();
                        //dr[15] = oR_Project_Info.Fields.Item("BASICCD").Value.ToString();
                        //dr[16] = oR_Project_Info.Fields.Item("BASICNM").Value.ToString();
                        //dr[17] = oR_Project_Info.Fields.Item("SELRA").Value.ToString();
                        //dr[18] = oR_Project_Info.Fields.Item("SELRANM").Value.ToString();
                        //dr[19] = oR_Project_Info.Fields.Item("CTSEQ").Value.ToString();
                        //dr[20] = oR_Project_Info.Fields.Item("DERNO").Value.ToString();
                        //dr[21] = oR_Project_Info.Fields.Item("ECNETC").Value.ToString();
                        //dr[22] = oR_Project_Info.Fields.Item("INVUOM").Value.ToString();
                        //dr[23] = oR_Project_Info.Fields.Item("VALIDFOR").Value.ToString();
                        //dr[24] = oR_Project_Info.Fields.Item("OLDITEMCD").Value.ToString();
                        //DT_Result.Rows.Add(dr);
                        response_odoc rp_odoc = new response_odoc();
                        rp_odoc.ROWNUM = oR_Project_Info.Fields.Item("ROWNUM").Value.ToString();
                        rp_odoc.ITEMCD = oR_Project_Info.Fields.Item("ITEMCD").Value.ToString();
                        rp_odoc.ITEMNM = oR_Project_Info.Fields.Item("ITEMNM").Value.ToString();
                        rp_odoc.ITEMGROUP = oR_Project_Info.Fields.Item("ITEMGROUP").Value.ToString();
                        rp_odoc.ITEMGROUPNM = oR_Project_Info.Fields.Item("ITEMGROUPNM").Value.ToString();
                        rp_odoc.LCLASS = oR_Project_Info.Fields.Item("LCLASS").Value.ToString();
                        rp_odoc.LCLASSNM = oR_Project_Info.Fields.Item("LCLASSNM").Value.ToString();
                        rp_odoc.MCLASS = oR_Project_Info.Fields.Item("MCLASS").Value.ToString();
                        rp_odoc.MCLASSNM = oR_Project_Info.Fields.Item("MCLASSNM").Value.ToString();
                        rp_odoc.SERIALMAN = oR_Project_Info.Fields.Item("SERIALMAN").Value.ToString();
                        rp_odoc.INVITEM = oR_Project_Info.Fields.Item("INVITEM").Value.ToString();
                        rp_odoc.MODEL = oR_Project_Info.Fields.Item("MODEL").Value.ToString();
                        rp_odoc.RMODEL = oR_Project_Info.Fields.Item("RMODEL").Value.ToString();
                        rp_odoc.RMODELNM = oR_Project_Info.Fields.Item("RMODELNM").Value.ToString();
                        rp_odoc.SPEC = oR_Project_Info.Fields.Item("SPEC").Value.ToString();
                        rp_odoc.BASICCD = oR_Project_Info.Fields.Item("BASICCD").Value.ToString();
                        rp_odoc.BASICNM = oR_Project_Info.Fields.Item("BASICNM").Value.ToString();
                        rp_odoc.SELRA = oR_Project_Info.Fields.Item("SELRA").Value.ToString();
                        rp_odoc.SELRANM = oR_Project_Info.Fields.Item("SELRANM").Value.ToString();
                        rp_odoc.CTSEQ = oR_Project_Info.Fields.Item("CTSEQ").Value.ToString();
                        rp_odoc.DERNO = oR_Project_Info.Fields.Item("DERNO").Value.ToString();
                        rp_odoc.ECNETC = oR_Project_Info.Fields.Item("ECNETC").Value.ToString();
                        rp_odoc.INVUOM = oR_Project_Info.Fields.Item("INVUOM").Value.ToString();
                        rp_odoc.VALIDFOR = oR_Project_Info.Fields.Item("VALIDFOR").Value.ToString();
                        rp_odoc.OLDITEMCD = oR_Project_Info.Fields.Item("OLDITEMCD").Value.ToString();
                        respose.oDOC.Add(rp_odoc);

                        oR_Project_Info.MoveNext();
                    }
                }
            }
            respose.sCode = "S";
            respose.sMSG = "Accepted";
            return Ok(respose);
        }
    }
}
