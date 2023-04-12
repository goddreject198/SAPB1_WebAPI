using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using SAPbobsCOM;
using Sap.Data.Hana;
using WebAPIWithSAPB1_Demo.Filters;

namespace WebAPIWithSAPB1_Demo
{
    public static class WebApiConfig
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Filters.Add(new BasicAuthenticationAttribute());

            #region connect to SAP B1
            try
            {
                log.Info("B1_Integration: Please Wait While Company Connecting ... ");

                Info_Class.oCompany = new SAPbobsCOM.Company();
                Info_Class.oCompany.SLDServer = System.Configuration.ConfigurationManager.AppSettings.Get("SLDServer");
                Info_Class.oCompany.Server = System.Configuration.ConfigurationManager.AppSettings.Get("Server");
                Info_Class.oCompany.DbServerType = BoDataServerTypes.dst_HANADB;
                Info_Class.oCompany.CompanyDB = System.Configuration.ConfigurationManager.AppSettings.Get("CompanyDB");
                Info_Class.oCompany.DbUserName = System.Configuration.ConfigurationManager.AppSettings.Get("DbUserName");
                Info_Class.oCompany.DbPassword = Info_Class.Decrypt(System.Configuration.ConfigurationManager.AppSettings.Get("DbPassword"));
                Info_Class.oCompany.UserName = System.Configuration.ConfigurationManager.AppSettings.Get("UserName");
                Info_Class.oCompany.Password = Info_Class.Decrypt(System.Configuration.ConfigurationManager.AppSettings.Get("Password"));
                Info_Class.oCompany.LicenseServer = System.Configuration.ConfigurationManager.AppSettings.Get("LicenseServer");
                Info_Class.oCompany.UseTrusted = false;

                int connect = Info_Class.oCompany.Connect();
                if (connect != 0)
                {
                    int temp_int = 0;
                    string temp_string = "";
                    Info_Class.oCompany.GetLastError(out temp_int, out temp_string);
                    log.Error(temp_int + ":" + temp_string);
                }

                if (Info_Class.oCompany.Connected)
                {
                    log.Info("Connect SAP B1");
                    //SAPbobsCOM.Recordset oR_RecordSet = (SAPbobsCOM.Recordset)Info_Class.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                    //oR_RecordSet.DoQuery(@"SELECT * FROM ""@CONFIG_ADDON""");
                    //if (oR_RecordSet.RecordCount > 0)
                    //{
                    //    while (!oR_RecordSet.EoF)
                    //    {
                    //        if (oR_RecordSet.Fields.Item("Code").Value.ToString() == "Uid")
                    //            Info_Class.Uid = Info_Class.Decrypt(oR_RecordSet.Fields.Item("Name").Value.ToString());
                    //        else if (oR_RecordSet.Fields.Item("Code").Value.ToString() == "Pwd")
                    //            Info_Class.Pwd = Info_Class.Decrypt(oR_RecordSet.Fields.Item("Name").Value.ToString());
                    //        else if (oR_RecordSet.Fields.Item("Code").Value.ToString() == "DMSUid")
                    //            Info_Class.DMSUsername = Info_Class.Decrypt(oR_RecordSet.Fields.Item("Name").Value.ToString());
                    //        else if (oR_RecordSet.Fields.Item("Code").Value.ToString() == "DMSPwd")
                    //            Info_Class.DMSPwd = Info_Class.Decrypt(oR_RecordSet.Fields.Item("Name").Value.ToString());
                    //        else if (oR_RecordSet.Fields.Item("Code").Value.ToString() == "DMSLink")
                    //            Info_Class.DMSLink = oR_RecordSet.Fields.Item("Name").Value.ToString();
                    //        else if (oR_RecordSet.Fields.Item("Code").Value.ToString() == "DMSPath")
                    //            Info_Class.DMSPath = oR_RecordSet.Fields.Item("Name").Value.ToString();
                    //        else if (oR_RecordSet.Fields.Item("Code").Value.ToString() == "iHRPServer")
                    //            Info_Class.iHRP_Server = oR_RecordSet.Fields.Item("Name").Value.ToString();
                    //        else if (oR_RecordSet.Fields.Item("Code").Value.ToString() == "iHRPUser")
                    //            Info_Class.iHRP_User = oR_RecordSet.Fields.Item("Name").Value.ToString();
                    //        else if (oR_RecordSet.Fields.Item("Code").Value.ToString() == "iHRPPwd")
                    //            Info_Class.iHRP_Pwd = Info_Class.Decrypt(oR_RecordSet.Fields.Item("Name").Value.ToString());
                    //        else if (oR_RecordSet.Fields.Item("Code").Value.ToString() == "iHRPDBName")
                    //            Info_Class.iHRP_DBName = oR_RecordSet.Fields.Item("Name").Value.ToString();
                    //        else if (oR_RecordSet.Fields.Item("Code").Value.ToString() == "SLcMSever")
                    //            Info_Class.SLcM_Sever = oR_RecordSet.Fields.Item("Name").Value.ToString();
                    //        else if (oR_RecordSet.Fields.Item("Code").Value.ToString() == "SLcMDatabase")
                    //            Info_Class.SLcM_Database = oR_RecordSet.Fields.Item("Name").Value.ToString();
                    //        else if (oR_RecordSet.Fields.Item("Code").Value.ToString() == "SLcMUid")
                    //            Info_Class.SLcM_Uid = oR_RecordSet.Fields.Item("Name").Value.ToString();
                    //        else if (oR_RecordSet.Fields.Item("Code").Value.ToString() == "SLcMPwd")
                    //            Info_Class.SLcM_Pwd = Info_Class.Decrypt(oR_RecordSet.Fields.Item("Name").Value.ToString());
                    //        else if (oR_RecordSet.Fields.Item("Code").Value.ToString() == "Host_Ip")
                    //            Info_Class.Host_Ip = oR_RecordSet.Fields.Item("Name").Value.ToString();
                    //        else if (oR_RecordSet.Fields.Item("Code").Value.ToString() == "B1Sever")
                    //            Info_Class.B1Sever = oR_RecordSet.Fields.Item("Name").Value.ToString();

                    //        oR_RecordSet.MoveNext();
                    //    }

                    //    Info_Class.Current_Schema = Info_Class.oCompany.CompanyDB;
                    //}
                    //else
                    //{
                    //    log.Error("B1_Integration: Error when get Hana DB Information ... ");
                    //}
                    //log.Info("B1_Integration: Company connected! ");
                }
                else
                {
                    log.Error("B1_Integration: Error when connect SAP B1 ... ");
                }
            }
            catch (Exception ex)
            {
                log.Error(string.Format("B1_Integration: Error when connect SAP B1 || {0}", ex.Message));
            }
            #endregion
        }
    }
}
