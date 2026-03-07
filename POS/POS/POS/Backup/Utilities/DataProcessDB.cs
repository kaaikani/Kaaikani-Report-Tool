using System;
using System.Data;
using System.Data.SqlClient;
using GridStructures;
using DBAccess;
using RLPOSDB;
using System.Windows.Forms;

namespace RLPOSDB
{
	/// <summary>
	/// Summary description for RptStockLedDB.
	/// </summary>
    public class DataProcessDB
    {
        public DataProcessDB()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        DataTable _Dst;
        public DataTable Dst
        {
            get
            {
                return _Dst;
            }
            set
            {
                _Dst = value;
            }
        }

        #region "Linked Server Creation"
        public DataTable LnkServersource(string LnkName,string DbName,string ServerName)
        {
            //qry_RptAnxSal(@Mode tinyint,@frmDt datetime,@ToDt Datetime,@VatMode varchar(5),@Compid tinyint)
            try
            {
                SqlConnection MyCon = new SqlConnection();
                SqlCommand MyCmd = new SqlCommand();
                SqlParameter MyParam = new SqlParameter();
                SqlDataAdapter MyAdapt = new SqlDataAdapter();
                DataTable DTbl = new DataTable();

                MyCon = new SqlConnection(Common.ConStr);
                MyCon.Open();

                MyCmd = new SqlCommand("LnkServerSqlCreatesp", MyCon);
                MyCmd.CommandType = CommandType.StoredProcedure;

                MyParam = new SqlParameter("@LnkName", SqlDbType.VarChar);
                MyParam.Value = LnkName;
                MyCmd.Parameters.Add(MyParam);

                MyParam = new SqlParameter("@DbName", SqlDbType.VarChar);
                MyParam.Value = DbName;
                MyCmd.Parameters.Add(MyParam);

                MyParam = new SqlParameter("@ServerName", SqlDbType.VarChar);
                MyParam.Value = ServerName;
                MyCmd.Parameters.Add(MyParam);

                MyAdapt.SelectCommand = MyCmd;
                MyAdapt.Fill(DTbl);

                DTbl.TableName = "LnkServerSqlCreatesp";
                MyAdapt.Dispose();
                MyCmd.Dispose();
                MyCon.Close();
                return DTbl;
            }

            catch (Exception Ex)
            {
                if (Ex.Message.IndexOf("COLUMN REFERENCE constraint") > -1)
                    throw new Exception("COLUMN REFERENCE constraint");
                else if (Ex.Message.IndexOf("Moved Up") > -1)
                    throw new Exception("Can't be Moved Up");
                else if (Ex.Message.IndexOf("Moved Down") > -1)
                    throw new Exception("Can't be Moved Down");
                else
                    throw Ex;
            }

        }
        public DataTable DropLnkServersource(string LnkName)
        {
            //qry_RptAnxSal(@Mode tinyint,@frmDt datetime,@ToDt Datetime,@VatMode varchar(5),@Compid tinyint)
            try
            {
                SqlConnection MyCon = new SqlConnection();
                SqlCommand MyCmd = new SqlCommand();
                SqlParameter MyParam = new SqlParameter();
                SqlDataAdapter MyAdapt = new SqlDataAdapter();
                DataTable DTbl = new DataTable();

                MyCon = new SqlConnection(Common.ConStr);
                MyCon.Open();

                MyCmd = new SqlCommand("LnkServerSqlDropsp", MyCon);
                MyCmd.CommandType = CommandType.StoredProcedure;

                MyParam = new SqlParameter("@LnkName", SqlDbType.VarChar);
                MyParam.Value = LnkName;
                MyCmd.Parameters.Add(MyParam);
             
                MyAdapt.SelectCommand = MyCmd;
                MyAdapt.Fill(DTbl);

                DTbl.TableName = "LnkServerSqlCreatesp";
                MyAdapt.Dispose();
                MyCmd.Dispose();
                MyCon.Close();
                return DTbl;
            }

            catch (Exception Ex)
            {
                if (Ex.Message.IndexOf("COLUMN REFERENCE constraint") > -1)
                    throw new Exception("COLUMN REFERENCE constraint");
                else if (Ex.Message.IndexOf("Moved Up") > -1)
                    throw new Exception("Can't be Moved Up");
                else if (Ex.Message.IndexOf("Moved Down") > -1)
                    throw new Exception("Can't be Moved Down");
                else
                    throw Ex;
            }

        }
        # endregion

        #region "Master Process Creation"
        public DataTable MasProcesssource(string Server, string DbName)
        {
            //qry_RptAnxSal(@Mode tinyint,@frmDt datetime,@ToDt Datetime,@VatMode varchar(5),@Compid tinyint)
            try
            {
                SqlConnection MyCon = new SqlConnection();
                SqlCommand MyCmd = new SqlCommand();
                SqlParameter MyParam = new SqlParameter();
                SqlDataAdapter MyAdapt = new SqlDataAdapter();
                DataTable DTbl = new DataTable();

                MyCon = new SqlConnection(Common.ConStr);
                MyCon.Open();

                MyCmd = new SqlCommand("MasterProcessSp", MyCon);
                MyCmd.CommandType = CommandType.StoredProcedure;

                MyParam = new SqlParameter("@Server", SqlDbType.VarChar);
                MyParam.Value = Server;
                MyCmd.Parameters.Add(MyParam);

                MyParam = new SqlParameter("@DBName", SqlDbType.VarChar);
                MyParam.Value = DbName;
                MyCmd.Parameters.Add(MyParam);

                MyAdapt.SelectCommand = MyCmd;
                MyAdapt.Fill(DTbl);

                DTbl.TableName = "MasterProcessSp";
                MyAdapt.Dispose();
                MyCmd.Dispose();
                MyCon.Close();
                return DTbl;
            }

            catch (Exception Ex)
            {
                if (Ex.Message.IndexOf("COLUMN REFERENCE constraint") > -1)
                    throw new Exception("COLUMN REFERENCE constraint");
                else if (Ex.Message.IndexOf("Moved Up") > -1)
                    throw new Exception("Can't be Moved Up");
                else if (Ex.Message.IndexOf("Moved Down") > -1)
                    throw new Exception("Can't be Moved Down");
                else
                    throw Ex;
            }

        }
        # endregion

        #region "Transaction Process Creation"
        public bool PurProcessSource(DateTime Dt,DataSet Ds)
        {
            bool Process = false;
            try
            {
                string DetStr;
                Ds.Tables.Add();
                DetStr = Ds.GetXml();
                DetStr = DetStr.Replace("'", "''");
                DetStr = DetStr.Replace("true", "1");
                DetStr = DetStr.Replace("false", "0");
                if (DetStr.IndexOf("T00:00:00") != -1)
                    DetStr = DetStr.Replace(DetStr.Substring(DetStr.IndexOf("T00:00:00"), 15), "");
                Ds.Tables.Clear();               
                Ds.Dispose();

                SqlConnection Con = new SqlConnection(Common.LnkConStr);
                SqlDataAdapter Da = new SqlDataAdapter();
                Con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("PurProcessNewSP", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@Dt", SqlDbType.DateTime);
                param.Value = Dt.ToString("dd/MMM/yyyy");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DetStr", SqlDbType.Text);
                param.Value = DetStr;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CompId", SqlDbType.TinyInt);
                param.Value = Common.CId;
                Cmd.Parameters.Add(param);

                Cmd.CommandTimeout = 5000;
                Cmd.ExecuteNonQuery();
                Cmd.Dispose();
                Con.Close();
                return Process = true;
            }

            catch (Exception Ex)
            {
                Process = false;
                if (Ex.Message.IndexOf("COLUMN REFERENCE constraint") > -1)
                    throw new Exception("COLUMN REFERENCE constraint");
                else if (Ex.Message.IndexOf("Moved Up") > -1)
                    throw new Exception("Can't be Moved Up");
                else if (Ex.Message.IndexOf("Moved Down") > -1)
                    throw new Exception("Can't be Moved Down");
                else
                    throw Ex;
            }

        }
        public bool SalProcessSource(DateTime Dt,DataSet Ds)
        {          
             bool Process = false;            
            try
            {
                string DetStr;                
                Ds.Tables.Add();             
                DetStr = Ds.GetXml();
                DetStr = DetStr.Replace("'", "''");
                DetStr = DetStr.Replace("true", "1");
                DetStr = DetStr.Replace("false", "0");
                if (DetStr.IndexOf("T00:00:00") != -1)
                    DetStr = DetStr.Replace(DetStr.Substring(DetStr.IndexOf("T00:00:00"), 15), "");
                Ds.Tables.Clear();              
                Ds.Dispose();
              

                SqlConnection Con = new SqlConnection(Common.LnkConStr);
                SqlDataAdapter Da = new SqlDataAdapter();
                Con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("SalProcessNewSP", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@Dt", SqlDbType.DateTime);
                param.Value = Dt.ToString("dd/MMM/yyyy");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DetStr", SqlDbType.Text);
                param.Value = DetStr;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CompId", SqlDbType.TinyInt);
                param.Value = Common.CId;
                Cmd.Parameters.Add(param);

                Cmd.CommandTimeout = 5000;
                Cmd.ExecuteNonQuery();
                Cmd.Dispose();
                Con.Close();
                return Process = true;
            }

            catch (Exception Ex)
            {
                Process = false;
                if (Ex.Message.IndexOf("COLUMN REFERENCE constraint") > -1)
                    throw new Exception("COLUMN REFERENCE constraint");
                else if (Ex.Message.IndexOf("Moved Up") > -1)
                    throw new Exception("Can't be Moved Up");
                else if (Ex.Message.IndexOf("Moved Down") > -1)
                    throw new Exception("Can't be Moved Down");
                else
                    throw Ex;
            }

        }         
        public bool SalRetProcessSource(DateTime Dt, DataSet Ds)
        {
            bool Process = false;
            try
            {
                string DetStr;
                Ds.Tables.Add();
                DetStr = Ds.GetXml();
                DetStr = DetStr.Replace("'", "''");
                DetStr = DetStr.Replace("true", "1");
                DetStr = DetStr.Replace("false", "0");
                if (DetStr.IndexOf("T00:00:00") != -1)
                    DetStr = DetStr.Replace(DetStr.Substring(DetStr.IndexOf("T00:00:00"), 15), "");
                Ds.Tables.Clear();                
                Ds.Dispose();

                SqlConnection Con = new SqlConnection(Common.LnkConStr);
                SqlDataAdapter Da = new SqlDataAdapter();
                Con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("SalRetProcessNewSP", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@Dt", SqlDbType.DateTime);
                param.Value = Dt.ToString("dd/MMM/yyyy");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DetStr", SqlDbType.Text);
                param.Value = DetStr;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CompId", SqlDbType.TinyInt);
                param.Value = Common.CId;
                Cmd.Parameters.Add(param);

                Cmd.CommandTimeout = 5000;
                Cmd.ExecuteNonQuery();
                Cmd.Dispose();
                Con.Close();
                return Process = true;
            }

            catch (Exception Ex)
            {
                Process = false;
                if (Ex.Message.IndexOf("COLUMN REFERENCE constraint") > -1)
                    throw new Exception("COLUMN REFERENCE constraint");
                else if (Ex.Message.IndexOf("Moved Up") > -1)
                    throw new Exception("Can't be Moved Up");
                else if (Ex.Message.IndexOf("Moved Down") > -1)
                    throw new Exception("Can't be Moved Down");
                else
                    throw Ex;
            }

        }
        public bool PurRetProcessSource(DateTime Dt, DataSet Ds)
        {
            bool Process = false;
            try
            {
                string DetStr;
                Ds.Tables.Add();
                DetStr = Ds.GetXml();
                DetStr = DetStr.Replace("'", "''");
                DetStr = DetStr.Replace("true", "1");
                DetStr = DetStr.Replace("false", "0");
                if (DetStr.IndexOf("T00:00:00") != -1)
                    DetStr = DetStr.Replace(DetStr.Substring(DetStr.IndexOf("T00:00:00"), 15), "");
                Ds.Tables.Clear();                
                Ds.Dispose();

                SqlConnection Con = new SqlConnection(Common.LnkConStr);
                SqlDataAdapter Da = new SqlDataAdapter();
                Con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("PurRetProcessNewSP", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@Dt", SqlDbType.DateTime);
                param.Value = Dt.ToString("dd/MMM/yyyy");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DetStr", SqlDbType.Text);
                param.Value = DetStr;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CompId", SqlDbType.TinyInt);
                param.Value = Common.CId;
                Cmd.Parameters.Add(param);

                Cmd.CommandTimeout = 5000;
                Cmd.ExecuteNonQuery();
                Cmd.Dispose();
                Con.Close();
                return Process = true;
            }

            catch (Exception Ex)
            {
                Process = false;
                if (Ex.Message.IndexOf("COLUMN REFERENCE constraint") > -1)
                    throw new Exception("COLUMN REFERENCE constraint");
                else if (Ex.Message.IndexOf("Moved Up") > -1)
                    throw new Exception("Can't be Moved Up");
                else if (Ex.Message.IndexOf("Moved Down") > -1)
                    throw new Exception("Can't be Moved Down");
                else
                    throw Ex;
            }

        }
        public bool PayProcessSource(DateTime Dt, DataSet Ds)
        {
            bool Process = false;
            try
            {
                string DetStr;
                Ds.Tables.Add();
                DetStr = Ds.GetXml();
                DetStr = DetStr.Replace("'", "''");
                DetStr = DetStr.Replace("true", "1");
                DetStr = DetStr.Replace("false", "0");
                if (DetStr.IndexOf("T00:00:00") != -1)
                    DetStr = DetStr.Replace(DetStr.Substring(DetStr.IndexOf("T00:00:00"), 15), "");
                Ds.Tables.Clear();                
                Ds.Dispose();

                SqlConnection Con = new SqlConnection(Common.LnkConStr);
                SqlDataAdapter Da = new SqlDataAdapter();
                Con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("PayProcessNewSP", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@Dt", SqlDbType.DateTime);
                param.Value = Dt.ToString("dd/MMM/yyyy");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DetStr", SqlDbType.Text);
                param.Value = DetStr;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CompId", SqlDbType.TinyInt);
                param.Value = Common.CId;
                Cmd.Parameters.Add(param);

                Cmd.CommandTimeout = 5000;
                Cmd.ExecuteNonQuery();
                Cmd.Dispose();
                Con.Close();
                return Process = true;
            }

            catch (Exception Ex)
            {
                Process = false;
                if (Ex.Message.IndexOf("COLUMN REFERENCE constraint") > -1)
                    throw new Exception("COLUMN REFERENCE constraint");
                else if (Ex.Message.IndexOf("Moved Up") > -1)
                    throw new Exception("Can't be Moved Up");
                else if (Ex.Message.IndexOf("Moved Down") > -1)
                    throw new Exception("Can't be Moved Down");
                else
                    throw Ex;
            }

        }
        public bool RecProcessSource(DateTime Dt, DataSet Ds)
        {
            bool Process = false;
            try
            {
                string DetStr;
                Ds.Tables.Add();
                DetStr = Ds.GetXml();
                DetStr = DetStr.Replace("'", "''");
                DetStr = DetStr.Replace("true", "1");
                DetStr = DetStr.Replace("false", "0");
                if (DetStr.IndexOf("T00:00:00") != -1)
                    DetStr = DetStr.Replace(DetStr.Substring(DetStr.IndexOf("T00:00:00"), 15), "");
                Ds.Tables.Clear();               
                Ds.Dispose();

                SqlConnection Con = new SqlConnection(Common.LnkConStr);
                SqlDataAdapter Da = new SqlDataAdapter();
                Con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("RecProcessNewSP", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@Dt", SqlDbType.DateTime);
                param.Value = Dt.ToString("dd/MMM/yyyy");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DetStr", SqlDbType.Text);
                param.Value = DetStr;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CompId", SqlDbType.TinyInt);
                param.Value = Common.CId;
                Cmd.Parameters.Add(param);

                Cmd.CommandTimeout = 5000;
                Cmd.ExecuteNonQuery();
                Cmd.Dispose();
                Con.Close();
                return Process = true;
            }

            catch (Exception Ex)
            {
                if (Ex.Message.IndexOf("COLUMN REFERENCE constraint") > -1)
                    throw new Exception("COLUMN REFERENCE constraint");
                else if (Ex.Message.IndexOf("Moved Up") > -1)
                    throw new Exception("Can't be Moved Up");
                else if (Ex.Message.IndexOf("Moved Down") > -1)
                    throw new Exception("Can't be Moved Down");
                else
                    throw Ex;
            }

        }      
        # endregion

        #region "GetProcessData"
        public DataSet GetMasterData()
        {
            //qry_RptAnxSal(@Mode tinyint,@frmDt datetime,@ToDt Datetime,@VatMode varchar(5),@Compid tinyint)
            try
            {
                SqlConnection MyCon = new SqlConnection();
                SqlCommand MyCmd = new SqlCommand();
                SqlParameter MyParam = new SqlParameter();
                SqlDataAdapter MyAdapt = new SqlDataAdapter();
                //DataTable DTbl = new DataTable();
                DataSet Ds = new DataSet();

                MyCon = new SqlConnection(Common.ConStr);
                MyCon.Open();

                MyCmd = new SqlCommand("Qry_MasterData", MyCon);
                MyCmd.CommandType = CommandType.StoredProcedure;

                MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
                MyParam.Value = Common.CId;
                MyCmd.Parameters.Add(MyParam);

                MyAdapt.SelectCommand = MyCmd;
                MyAdapt.Fill(Ds);

                //DTbl.TableName = "MasterProcessSp";
                MyAdapt.Dispose();
                MyCmd.Dispose();
                MyCon.Close();
                return Ds;
            }

            catch (Exception Ex)
            {
                if (Ex.Message.IndexOf("COLUMN REFERENCE constraint") > -1)
                    throw new Exception("COLUMN REFERENCE constraint");
                else if (Ex.Message.IndexOf("Moved Up") > -1)
                    throw new Exception("Can't be Moved Up");
                else if (Ex.Message.IndexOf("Moved Down") > -1)
                    throw new Exception("Can't be Moved Down");
                else
                    throw Ex;
            }

        }
        public DataSet GetSalesData(DateTime Dt)
        {
            //qry_RptAnxSal(@Mode tinyint,@frmDt datetime,@ToDt Datetime,@VatMode varchar(5),@Compid tinyint)
            try
            {
                SqlConnection MyCon = new SqlConnection();
                SqlCommand MyCmd = new SqlCommand();
                SqlParameter MyParam = new SqlParameter();
                SqlDataAdapter MyAdapt = new SqlDataAdapter();
                //DataTable DTbl = new DataTable();
                DataSet Ds = new DataSet();

                MyCon = new SqlConnection(Common.ConStr);
                MyCon.Open();

                MyCmd = new SqlCommand("Qry_GetSalesData", MyCon);
                MyCmd.CommandType = CommandType.StoredProcedure;

                MyParam = new SqlParameter("@Dt", SqlDbType.DateTime);
                MyParam.Value = Dt.ToString("dd/MMM/yyyy");
                MyCmd.Parameters.Add(MyParam);

                MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
                MyParam.Value = Common.CId;
                MyCmd.Parameters.Add(MyParam);

                MyAdapt.SelectCommand = MyCmd;
                MyAdapt.Fill(Ds);

                //DTbl.TableName = "MasterProcessSp";
                MyAdapt.Dispose();
                MyCmd.Dispose();
                MyCon.Close();
                return Ds;
            }

            catch (Exception Ex)
            {
                if (Ex.Message.IndexOf("COLUMN REFERENCE constraint") > -1)
                    throw new Exception("COLUMN REFERENCE constraint");
                else if (Ex.Message.IndexOf("Moved Up") > -1)
                    throw new Exception("Can't be Moved Up");
                else if (Ex.Message.IndexOf("Moved Down") > -1)
                    throw new Exception("Can't be Moved Down");
                else
                    throw Ex;
            }

        }
        public DataSet GetPurchaseData(DateTime Dt)
        {
           
            try
            {
                SqlConnection MyCon = new SqlConnection();
                SqlCommand MyCmd = new SqlCommand();
                SqlParameter MyParam = new SqlParameter();
                SqlDataAdapter MyAdapt = new SqlDataAdapter();
                //DataTable DTbl = new DataTable();
                DataSet Ds = new DataSet();

                MyCon = new SqlConnection(Common.ConStr);
                MyCon.Open();

                MyCmd = new SqlCommand("Qry_GetPurchaseData", MyCon);
                MyCmd.CommandType = CommandType.StoredProcedure;

                MyParam = new SqlParameter("@Dt", SqlDbType.DateTime);
                MyParam.Value = Dt.ToString("dd/MMM/yyyy");
                MyCmd.Parameters.Add(MyParam);

                MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
                MyParam.Value = Common.CId;
                MyCmd.Parameters.Add(MyParam);

                MyAdapt.SelectCommand = MyCmd;
                MyAdapt.Fill(Ds);

                //DTbl.TableName = "MasterProcessSp";
                MyAdapt.Dispose();
                MyCmd.Dispose();
                MyCon.Close();
                return Ds;
            }

            catch (Exception Ex)
            {
                if (Ex.Message.IndexOf("COLUMN REFERENCE constraint") > -1)
                    throw new Exception("COLUMN REFERENCE constraint");
                else if (Ex.Message.IndexOf("Moved Up") > -1)
                    throw new Exception("Can't be Moved Up");
                else if (Ex.Message.IndexOf("Moved Down") > -1)
                    throw new Exception("Can't be Moved Down");
                else
                    throw Ex;
            }

        }
        public DataSet GetPurRetData(DateTime Dt)
        {
            //qry_RptAnxSal(@Mode tinyint,@frmDt datetime,@ToDt Datetime,@VatMode varchar(5),@Compid tinyint)
            try
            {
                SqlConnection MyCon = new SqlConnection();
                SqlCommand MyCmd = new SqlCommand();
                SqlParameter MyParam = new SqlParameter();
                SqlDataAdapter MyAdapt = new SqlDataAdapter();
                //DataTable DTbl = new DataTable();
                DataSet Ds = new DataSet();

                MyCon = new SqlConnection(Common.ConStr);
                MyCon.Open();

                MyCmd = new SqlCommand("Qry_GetPurRetData", MyCon);
                MyCmd.CommandType = CommandType.StoredProcedure;

                MyParam = new SqlParameter("@Dt", SqlDbType.DateTime);
                MyParam.Value = Dt.ToString("dd/MMM/yyyy");
                MyCmd.Parameters.Add(MyParam);

                MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
                MyParam.Value = Common.CId;
                MyCmd.Parameters.Add(MyParam);

                MyAdapt.SelectCommand = MyCmd;
                MyAdapt.Fill(Ds);

                //DTbl.TableName = "MasterProcessSp";
                MyAdapt.Dispose();
                MyCmd.Dispose();
                MyCon.Close();
                return Ds;
            }

            catch (Exception Ex)
            {
                if (Ex.Message.IndexOf("COLUMN REFERENCE constraint") > -1)
                    throw new Exception("COLUMN REFERENCE constraint");
                else if (Ex.Message.IndexOf("Moved Up") > -1)
                    throw new Exception("Can't be Moved Up");
                else if (Ex.Message.IndexOf("Moved Down") > -1)
                    throw new Exception("Can't be Moved Down");
                else
                    throw Ex;
            }

        }
        public DataSet GetSalRetData(DateTime Dt)
        {
            //qry_RptAnxSal(@Mode tinyint,@frmDt datetime,@ToDt Datetime,@VatMode varchar(5),@Compid tinyint)
            try
            {
                SqlConnection MyCon = new SqlConnection();
                SqlCommand MyCmd = new SqlCommand();
                SqlParameter MyParam = new SqlParameter();
                SqlDataAdapter MyAdapt = new SqlDataAdapter();
                //DataTable DTbl = new DataTable();
                DataSet Ds = new DataSet();

                MyCon = new SqlConnection(Common.ConStr);
                MyCon.Open();

                MyCmd = new SqlCommand("Qry_GetSalRetData", MyCon);
                MyCmd.CommandType = CommandType.StoredProcedure;

                MyParam = new SqlParameter("@Dt", SqlDbType.DateTime);
                MyParam.Value = Dt.ToString("dd/MMM/yyyy");
                MyCmd.Parameters.Add(MyParam);

                MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
                MyParam.Value = Common.CId;
                MyCmd.Parameters.Add(MyParam);

                MyAdapt.SelectCommand = MyCmd;
                MyAdapt.Fill(Ds);

                //DTbl.TableName = "MasterProcessSp";
                MyAdapt.Dispose();
                MyCmd.Dispose();
                MyCon.Close();
                return Ds;
            }

            catch (Exception Ex)
            {
                if (Ex.Message.IndexOf("COLUMN REFERENCE constraint") > -1)
                    throw new Exception("COLUMN REFERENCE constraint");
                else if (Ex.Message.IndexOf("Moved Up") > -1)
                    throw new Exception("Can't be Moved Up");
                else if (Ex.Message.IndexOf("Moved Down") > -1)
                    throw new Exception("Can't be Moved Down");
                else
                    throw Ex;
            }

        }
        public DataSet GetReceiptData(DateTime Dt)
        {
            //qry_RptAnxSal(@Mode tinyint,@frmDt datetime,@ToDt Datetime,@VatMode varchar(5),@Compid tinyint)
            try
            {
                SqlConnection MyCon = new SqlConnection();
                SqlCommand MyCmd = new SqlCommand();
                SqlParameter MyParam = new SqlParameter();
                SqlDataAdapter MyAdapt = new SqlDataAdapter();
                //DataTable DTbl = new DataTable();
                DataSet Ds = new DataSet();

                MyCon = new SqlConnection(Common.ConStr);
                MyCon.Open();

                MyCmd = new SqlCommand("Qry_GetReceiptData", MyCon);
                MyCmd.CommandType = CommandType.StoredProcedure;

                MyParam = new SqlParameter("@Dt", SqlDbType.DateTime);
                MyParam.Value = Dt.ToString("dd/MMM/yyyy");
                MyCmd.Parameters.Add(MyParam);

                MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
                MyParam.Value = Common.CId;
                MyCmd.Parameters.Add(MyParam);

                MyAdapt.SelectCommand = MyCmd;
                MyAdapt.Fill(Ds);

                //DTbl.TableName = "MasterProcessSp";
                MyAdapt.Dispose();
                MyCmd.Dispose();
                MyCon.Close();
                return Ds;
            }

            catch (Exception Ex)
            {
                if (Ex.Message.IndexOf("COLUMN REFERENCE constraint") > -1)
                    throw new Exception("COLUMN REFERENCE constraint");
                else if (Ex.Message.IndexOf("Moved Up") > -1)
                    throw new Exception("Can't be Moved Up");
                else if (Ex.Message.IndexOf("Moved Down") > -1)
                    throw new Exception("Can't be Moved Down");
                else
                    throw Ex;
            }

        }
        public DataSet GetPaymentData(DateTime Dt)
        {
            //qry_RptAnxSal(@Mode tinyint,@frmDt datetime,@ToDt Datetime,@VatMode varchar(5),@Compid tinyint)
            try
            {
                SqlConnection MyCon = new SqlConnection();
                SqlCommand MyCmd = new SqlCommand();
                SqlParameter MyParam = new SqlParameter();
                SqlDataAdapter MyAdapt = new SqlDataAdapter();
                //DataTable DTbl = new DataTable();
                DataSet Ds = new DataSet();

                MyCon = new SqlConnection(Common.ConStr);
                MyCon.Open();

                MyCmd = new SqlCommand("Qry_GetPaymentData", MyCon);
                MyCmd.CommandType = CommandType.StoredProcedure;

                MyParam = new SqlParameter("@Dt", SqlDbType.DateTime);
                MyParam.Value = Dt.ToString("dd/MMM/yyyy");
                MyCmd.Parameters.Add(MyParam);

                MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
                MyParam.Value = Common.CId;
                MyCmd.Parameters.Add(MyParam);

                MyAdapt.SelectCommand = MyCmd;
                MyAdapt.Fill(Ds);

                //DTbl.TableName = "MasterProcessSp";
                MyAdapt.Dispose();
                MyCmd.Dispose();
                MyCon.Close();
                return Ds;
            }

            catch (Exception Ex)
            {
                if (Ex.Message.IndexOf("COLUMN REFERENCE constraint") > -1)
                    throw new Exception("COLUMN REFERENCE constraint");
                else if (Ex.Message.IndexOf("Moved Up") > -1)
                    throw new Exception("Can't be Moved Up");
                else if (Ex.Message.IndexOf("Moved Down") > -1)
                    throw new Exception("Can't be Moved Down");
                else
                    throw Ex;
            }

        }
# endregion       

        #region "DeleteProcessData"   
        public void DeleteSalProcessSource(DateTime Dt)
        {            
            try
            {               
                SqlConnection Con = new SqlConnection(Common.ConStr);
                SqlDataAdapter Da = new SqlDataAdapter();
                Con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("DeleteSalProcessSP", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@Dt", SqlDbType.DateTime);
                param.Value = Dt.ToString("dd/MMM/yyyy");
                Cmd.Parameters.Add(param);                

                param = new SqlParameter("@CompId", SqlDbType.TinyInt);
                param.Value = Common.CId;
                Cmd.Parameters.Add(param);

                Cmd.ExecuteNonQuery();
                Cmd.Dispose();
                Con.Close();               
            }

            catch (Exception Ex)
            {                
                if (Ex.Message.IndexOf("COLUMN REFERENCE constraint") > -1)
                    throw new Exception("COLUMN REFERENCE constraint");
                else if (Ex.Message.IndexOf("Moved Up") > -1)
                    throw new Exception("Can't be Moved Up");
                else if (Ex.Message.IndexOf("Moved Down") > -1)
                    throw new Exception("Can't be Moved Down");
                else
                    throw Ex;
            }

        }
        public void DeletePurProcessSource(DateTime Dt)
        {
            try
            {
                SqlConnection Con = new SqlConnection(Common.ConStr);
                SqlDataAdapter Da = new SqlDataAdapter();
                Con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("DeletePurProcessSP", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@Dt", SqlDbType.DateTime);
                param.Value = Dt.ToString("dd/MMM/yyyy");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CompId", SqlDbType.TinyInt);
                param.Value = Common.CId;
                Cmd.Parameters.Add(param);

                Cmd.ExecuteNonQuery();
                Cmd.Dispose();
                Con.Close();
            }

            catch (Exception Ex)
            {
                if (Ex.Message.IndexOf("COLUMN REFERENCE constraint") > -1)
                    throw new Exception("COLUMN REFERENCE constraint");
                else if (Ex.Message.IndexOf("Moved Up") > -1)
                    throw new Exception("Can't be Moved Up");
                else if (Ex.Message.IndexOf("Moved Down") > -1)
                    throw new Exception("Can't be Moved Down");
                else
                    throw Ex;
            }

        }
        public void DeleteSalRetProcessSource(DateTime Dt)
        {
            try
            {
                SqlConnection Con = new SqlConnection(Common.ConStr);
                SqlDataAdapter Da = new SqlDataAdapter();
                Con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("DeleteSalRetProcessSP", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@Dt", SqlDbType.DateTime);
                param.Value = Dt.ToString("dd/MMM/yyyy");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CompId", SqlDbType.TinyInt);
                param.Value = Common.CId;
                Cmd.Parameters.Add(param);

                Cmd.ExecuteNonQuery();
                Cmd.Dispose();
                Con.Close();
            }

            catch (Exception Ex)
            {
                if (Ex.Message.IndexOf("COLUMN REFERENCE constraint") > -1)
                    throw new Exception("COLUMN REFERENCE constraint");
                else if (Ex.Message.IndexOf("Moved Up") > -1)
                    throw new Exception("Can't be Moved Up");
                else if (Ex.Message.IndexOf("Moved Down") > -1)
                    throw new Exception("Can't be Moved Down");
                else
                    throw Ex;
            }

        }
        public void DeletePurRetProcessSource(DateTime Dt)
        {
            try
            {
                SqlConnection Con = new SqlConnection(Common.ConStr);
                SqlDataAdapter Da = new SqlDataAdapter();
                Con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("DeletePurRetProcessSP", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@Dt", SqlDbType.DateTime);
                param.Value = Dt.ToString("dd/MMM/yyyy");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CompId", SqlDbType.TinyInt);
                param.Value = Common.CId;
                Cmd.Parameters.Add(param);

                Cmd.ExecuteNonQuery();
                Cmd.Dispose();
                Con.Close();
            }

            catch (Exception Ex)
            {
                if (Ex.Message.IndexOf("COLUMN REFERENCE constraint") > -1)
                    throw new Exception("COLUMN REFERENCE constraint");
                else if (Ex.Message.IndexOf("Moved Up") > -1)
                    throw new Exception("Can't be Moved Up");
                else if (Ex.Message.IndexOf("Moved Down") > -1)
                    throw new Exception("Can't be Moved Down");
                else
                    throw Ex;
            }

        }
        public void DeleteRecProcessSource(DateTime Dt)
        {
            try
            {
                SqlConnection Con = new SqlConnection(Common.ConStr);
                SqlDataAdapter Da = new SqlDataAdapter();
                Con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("DeleteRecProcessSP", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@Dt", SqlDbType.DateTime);
                param.Value = Dt.ToString("dd/MMM/yyyy");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CompId", SqlDbType.TinyInt);
                param.Value = Common.CId;
                Cmd.Parameters.Add(param);

                Cmd.ExecuteNonQuery();
                Cmd.Dispose();
                Con.Close();
            }

            catch (Exception Ex)
            {
                if (Ex.Message.IndexOf("COLUMN REFERENCE constraint") > -1)
                    throw new Exception("COLUMN REFERENCE constraint");
                else if (Ex.Message.IndexOf("Moved Up") > -1)
                    throw new Exception("Can't be Moved Up");
                else if (Ex.Message.IndexOf("Moved Down") > -1)
                    throw new Exception("Can't be Moved Down");
                else
                    throw Ex;
            }

        }
        public void DeletePayProcessSource(DateTime Dt)
        {
            try
            {
                SqlConnection Con = new SqlConnection(Common.ConStr);
                SqlDataAdapter Da = new SqlDataAdapter();
                Con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("DeletePayProcessSP", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@Dt", SqlDbType.DateTime);
                param.Value = Dt.ToString("dd/MMM/yyyy");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CompId", SqlDbType.TinyInt);
                param.Value = Common.CId;
                Cmd.Parameters.Add(param);

                Cmd.ExecuteNonQuery();
                Cmd.Dispose();
                Con.Close();
            }

            catch (Exception Ex)
            {
                if (Ex.Message.IndexOf("COLUMN REFERENCE constraint") > -1)
                    throw new Exception("COLUMN REFERENCE constraint");
                else if (Ex.Message.IndexOf("Moved Up") > -1)
                    throw new Exception("Can't be Moved Up");
                else if (Ex.Message.IndexOf("Moved Down") > -1)
                    throw new Exception("Can't be Moved Down");
                else
                    throw Ex;
            }

        }                   
         # endregion       
         public bool MasterProcessNewSource(DataSet Ds)
         {
             bool Process = false;   
            //qry_RptAnxSal(@Mode tinyint,@frmDt datetime,@ToDt Datetime,@VatMode varchar(5),@Compid tinyint)
            try
            {                   
                string DetStr;
                Ds.Tables.Add();
                DetStr = Ds.GetXml();
                DetStr = DetStr.Replace("'", "''");
                DetStr = DetStr.Replace("true", "1");
                DetStr = DetStr.Replace("false", "0");

                Ds.Tables.Clear();
                Ds.Dispose();

                SqlConnection Con = new SqlConnection(Common.LnkConStr);
                SqlDataAdapter Da = new SqlDataAdapter();
                Con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("MasterProcessNewSP", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@DetStr", SqlDbType.NText);
                param.Value = DetStr;
                Cmd.Parameters.Add(param);

                Cmd.CommandTimeout = 5000;
                Cmd.ExecuteNonQuery();
                Cmd.Dispose();
                Con.Close();
                return Process=true;
            }

            catch (Exception Ex)
            {
                Process = false;
                if (Ex.Message.IndexOf("COLUMN REFERENCE constraint") > -1)
                    throw new Exception("COLUMN REFERENCE constraint");
                else if (Ex.Message.IndexOf("Moved Up") > -1)
                    throw new Exception("Can't be Moved Up");
                else if (Ex.Message.IndexOf("Moved Down") > -1)
                    throw new Exception("Can't be Moved Down");
                else
                    throw Ex;
            }

        }
        public void UpdateMasterProcessSource()
        {           
            try
            {               
                SqlConnection Con = new SqlConnection(Common.ConStr);
                SqlDataAdapter Da = new SqlDataAdapter();
                Con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("UpdateMasterSP", Con);
                Cmd.CommandType = CommandType.StoredProcedure;
              
                Cmd.ExecuteNonQuery();
                Cmd.Dispose();
                Con.Close();              
            }

            catch (Exception Ex)
            {
                if (Ex.Message.IndexOf("COLUMN REFERENCE constraint") > -1)
                    throw new Exception("COLUMN REFERENCE constraint");
                else if (Ex.Message.IndexOf("Moved Up") > -1)
                    throw new Exception("Can't be Moved Up");
                else if (Ex.Message.IndexOf("Moved Down") > -1)
                    throw new Exception("Can't be Moved Down");
                else
                    throw Ex;
            }
        }

        public void ConnectionCloseSp(string dbname)
        {

            try
            {

                DataTable Tbl = new DataTable();
                SqlConnection Con = new SqlConnection(Common.MasConStr);
                Con.Open();
                SqlCommand Cmd;

                Cmd = new SqlCommand("DropConnection", Con);
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param;

                param = new SqlParameter("@dbname", SqlDbType.VarChar, 20);
                param.Value = dbname;
                Cmd.Parameters.Add(param);

                Cmd.ExecuteNonQuery();
                Cmd.Dispose();
                Con.Close();
            }
            catch (Exception Ex)
            {
                if (Ex.Message.IndexOf("COLUMN REFERENCE constraint") > -1)
                    throw new Exception("COLUMN REFERENCE constraint");
                else if (Ex.Message.IndexOf("Moved Up") > -1)
                    throw new Exception("Can't be Moved Up");
                else if (Ex.Message.IndexOf("Moved Down") > -1)
                    throw new Exception("Can't be Moved Down");
                else
                    throw Ex;
            }


        }
    }
}
