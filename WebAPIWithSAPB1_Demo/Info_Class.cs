using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using SAPbouiCOM.Framework;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Data;
using System.Threading.Tasks;
using SAPbobsCOM;
using Sap.Data.Hana;

namespace WebAPIWithSAPB1_Demo
{
    public static class Info_Class
    {
        
        public static string B1Sever = "";
        public static string Uid = "";
        public static string Pwd = "";
        public static string Current_Schema = "";
        public static string Host_Ip = "";
        public static string DMSUsername = "";
        public static string DMSPwd = "";
        public static string DMSLink = "";
        public static string DMSPath = "";
        public static string iHRP_Server = "";
        public static string iHRP_User = "";
        public static string iHRP_Pwd = "";
        public static string iHRP_DBName = "";
        public static string SLcM_Sever = "";
        public static string SLcM_Database = "";
        public static string SLcM_Uid = "";
        public static string SLcM_Pwd = "";
        public static string Session_DocNum = "";
        public static string Session_Key = "";
        public static int Session_Button = 0;
        public static int Session_Close = 0;
        public static int AP_Inv_Session_Button = 0;
        public static int PR_Session_Button = 0;
        public static string Attachment_Screen = "";
        public static SAPbouiCOM.Form oForm_Att;
        public static string B1Approve_User = "";
        public static string B1Approve_Pwd = "";

        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static SAPbobsCOM.Company oCompany;

        public static System.Data.DataTable GetDataFilter(string p_dept)
        {
            HanaConnection conn = null;
            DataTable dt = new DataTable();
            String connStr = string.Format(@"Server={0};UserName={1};Password={2};CS={3}", Info_Class.Host_Ip, Info_Class.Uid, Info_Class.Pwd, Info_Class.Current_Schema);
            conn = new HanaConnection(connStr);
            try
            {
                HanaCommand cmd = new HanaCommand("Z_FILTER_EMP", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(":p_dept", p_dept);
                conn.Open();
                HanaDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
            }
            catch (Exception ex)
            {
                Application.SBO_Application.MessageBox(ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return dt;
        }

        public static string Decrypt(string pEncrypt_Str)
        {
            try
            {
                bool useHashing = true;
                byte[] keyArray;
                byte[] toEncryptArray = Convert.FromBase64String(pEncrypt_Str);

                if (useHashing)
                {
                    MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes("JEISYS"));
                }
                else
                    keyArray = UTF8Encoding.UTF8.GetBytes("JEISYS");

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                return UTF8Encoding.UTF8.GetString(resultArray);
            }
            catch (Exception ex)
            {
                Application.SBO_Application.MessageBox(ex.Message);
                return "";
            }
        }
        public static SAPbouiCOM.DataTable Convert_SAP_DataTable(System.Data.DataTable pDataTable, String pDataTableID)
        {
            SAPbouiCOM.DataTable oDT = null;
            try
            {
                SAPbouiCOM.Form oForm = SAPbouiCOM.Framework.Application.SBO_Application.Forms.ActiveForm;
                if (CheckExistUniqueID(oForm, pDataTableID))
                {
                    oDT = oForm.DataSources.DataTables.Item(pDataTableID);
                    oDT.Clear();
                }
                else
                {
                    oDT = oForm.DataSources.DataTables.Add(pDataTableID);
                }
                //Add column to DataTable
                foreach (System.Data.DataColumn c in pDataTable.Columns)
                {
                    try
                    {
                        if (c.DataType.ToString() == "System.DateTime")
                            oDT.Columns.Add(c.ColumnName, SAPbouiCOM.BoFieldsType.ft_Date);
                        else
                            oDT.Columns.Add(c.ColumnName, SAPbouiCOM.BoFieldsType.ft_Text);
                    }
                    catch
                    { }

                }
                //Add row to DataTable
                SAPbouiCOM.ProgressBar oProgressBar = Application.SBO_Application.StatusBar.CreateProgressBar("Loading...", pDataTable.Rows.Count, false);
                oProgressBar.Text = "Loading...";
                int i = 0;
                foreach (System.Data.DataRow r in pDataTable.Rows)
                {
                    oDT.Rows.Add();
                    foreach (System.Data.DataColumn c in pDataTable.Columns)
                    {
                        if (c.DataType.ToString() == "System.DateTime")
                            oDT.SetValue(c.ColumnName, oDT.Rows.Count - 1, r[c.ColumnName]);
                        else
                            oDT.SetValue(c.ColumnName, oDT.Rows.Count - 1, r[c.ColumnName].ToString());
                    }
                    oProgressBar.Value = i + 1;
                    i++;
                }
                oProgressBar.Stop();
            }
            catch
            {

            }
            return oDT;
        }
        public static bool CheckExistUniqueID(SAPbouiCOM.Form pForm, string pItemID)
        {
            if (pForm.DataSources.DataTables.Count > 0)
            {
                for (int i = 0; i < pForm.DataSources.DataTables.Count; i++)
                {
                    if (pForm.DataSources.DataTables.Item(i).UniqueID == pItemID)
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }
        public static bool CheckExistUniqueCheckBoxID(SAPbouiCOM.Form pForm, string pItemID)
        {
            if (pForm.DataSources.UserDataSources.Count > 0)
            {
                for (int i = 0; i < pForm.DataSources.UserDataSources.Count; i++)
                {
                    if (pForm.DataSources.UserDataSources.Item(i).UID == pItemID)
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        //Kiem tra string co convert thanh JSON duoc khong
        public static bool IsValidJson(string strInput)
        {
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || //For object
                (strInput.StartsWith("[") && strInput.EndsWith("]"))) //For array
            {
                try
                {
                    var obj = JToken.Parse(strInput);
                    return true;
                }
                catch (JsonReaderException jex)
                {
                    //Exception in parsing json
                    log.Error(jex.Message);
                    return false;
                }
                catch (Exception ex) //some other exception
                {
                    log.Error(ex.ToString());
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool MoveFile(string srcPath, string tarPath)
        {
            try
            {
                string DirectoryDF = srcPath;
                string DirectoryDT = tarPath;

                String path = DirectoryDF;
                if (!File.Exists(path))
                {
                    Application.SBO_Application.MessageBox(string.Format("File {0} does not exist!", DirectoryDF));
                    return false;
                }


                //move file to forder NewFiles
                String dirPath = DirectoryDF;
                String dirPath1 = DirectoryDT;

                File.Copy(dirPath, dirPath1);
                if (!File.Exists(dirPath1))
                {

                    Application.SBO_Application.SetStatusBarMessage(string.Format("Copy failed!"));
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.MessageBox(ex.Message);
                return false;
            }

            return true;
        }

        public static string GetUserId(string pId)
        {
            string result = "";
            Recordset oR_Project_Info = (Recordset)Info_Class.oCompany.GetBusinessObject(BoObjectTypes.BoRecordset);
            string str_sql = string.Format("SELECT \"USERID\" FROM OUSR where \"USER_CODE\"='{0}'", pId);
            oR_Project_Info.DoQuery(str_sql);
            result = oR_Project_Info.Fields.Item("USERID").Value.ToString();
            return result;
        }

        public static System.Data.DataTable Get_MenuUID(string pReportName)
        {
            String connStr = string.Format(@"Server={0};UserName={1};Password={2};CS={3}", Info_Class.Host_Ip, Info_Class.Uid, Info_Class.Pwd, Info_Class.Current_Schema);
            HanaConnection conn = null;
            DataTable result = new DataTable();
            HanaCommand cmd = null;
            conn = new HanaConnection(connStr);

            try
            {
                cmd = new HanaCommand(@"SELECT top 1 ""MenuUID"" FROM OCMN WHERE ""Name""=N'" + pReportName + "'", conn);
                cmd.CommandTimeout = 0;

                conn.Open();
                HanaDataReader dr = cmd.ExecuteReader();
                result.Load(dr);
            }
            catch (Exception ex)
            {
                Application.SBO_Application.MessageBox(ex.Message);
            }
            finally
            {
                //this.UIAPIRawForm.Freeze(false);
                conn.Close();
                cmd.Dispose();
            }

            return result;
        }
    }
}