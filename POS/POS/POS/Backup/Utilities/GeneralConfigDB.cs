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
    public class GeneralConfigDB
    {
        public GeneralConfigDB()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        int _DocId;
        public int DocId
        {
            get
            {
                return _DocId;
            }
            set
            {
                _DocId = value;
            }
        }
                
        bool _Printermode;
        public bool Printermode
        {
            get
            {
                return _Printermode;
            }
            set
            {
                _Printermode = value;
            }
        }

        short _PrnModelId;
        public short PrnModelId
        {
            get
            {
                return _PrnModelId;
            }
            set
            {
                _PrnModelId = value;
            }
        }

         int _SalCharge1PostId;
        public int SalCharge1PostId
        {
            get
            {
                return _SalCharge1PostId;
            }
            set
            {
                _SalCharge1PostId = value;
            }
        }

        int _SalCharge2PostId;
        public int SalCharge2PostId
        {
            get
            {
                return _SalCharge2PostId;
            }
            set
            {
                _SalCharge2PostId = value;
            }
        }

        int _CSTTaxId;
        public int CSTTaxId
        {
            get
            {
                return _CSTTaxId;
            }
            set
            {
                _CSTTaxId = value;
            }
        }

        int _DefaultCatId;
        public int DefaultCatId
        {
            get
            {
                return _DefaultCatId;
            }
            set
            {
                _DefaultCatId = value;
            }
        }

        int _DefaultBookId;
        public int DefaultBookId
        {
            get
            {
                return _DefaultBookId;
            }
            set
            {
                _DefaultBookId = value;
            }
        }

        int _DefaultTaxId;
        public int DefaultTaxId
        {
            get
            {
                return _DefaultTaxId;
            }
            set
            {
                _DefaultTaxId = value;
            }
        }

        int _ConfigId;
        public int ConfigId
        {
            get
            {
                return _ConfigId;
            }
            set
            {
                _ConfigId = value;
            }
        }

        string _TLeft1;
        public string TLeft1
        {
            get
            {
                return _TLeft1;
            }
            set
            {
                _TLeft1 = value;
            }
        }
        string _TLeft2;
        public string TLeft2
        {
            get
            {
                return _TLeft2;
            }
            set
            {
                _TLeft2 = value;
            }
        }
        string _TLeft3;
        public string TLeft3
        {
            get
            {
                return _TLeft3;
            }
            set
            {
                _TLeft3 = value;
            }
        }
        string _TLeft4;
        public string TLeft4
        {
            get
            {
                return _TLeft4;
            }
            set
            {
                _TLeft4 = value;
            }
        }
        string _TLeft5;
        public string TLeft5
        {
            get
            {
                return _TLeft5;
            }
            set
            {
                _TLeft5 = value;
            }
        }
        string _TMid1;
        public string TMid1
        {
            get
            {
                return _TMid1;
            }
            set
            {
                _TMid1 = value;
            }
        }
        string _TMid2;
        public string TMid2
        {
            get
            {
                return _TMid2;
            }
            set
            {
                _TMid2 = value;
            }
        }
        string _TMid3;
        public string TMid3
        {
            get
            {
                return _TMid3;
            }
            set
            {
                _TMid3 = value;
            }
        }
        string _TMid4;
        public string TMid4
        {
            get
            {
                return _TMid4;
            }
            set
            {
                _TMid4 = value;
            }
        }
        string _TMid5;
        public string TMid5
        {
            get
            {
                return _TMid5;
            }
            set
            {
                _TMid5 = value;
            }
        }
        string _TRight1;
        public string TRight1
        {
            get
            {
                return _TRight1;
            }
            set
            {
                _TRight1 = value;
            }
        }
        string _TRight2;
        public string TRight2
        {
            get
            {
                return _TRight2;
            }
            set
            {
                _TRight2 = value;
            }
        }
        string _TRight3;
        public string TRight3
        {
            get
            {
                return _TRight3;
            }
            set
            {
                _TRight3 = value;
            }
        }
        string _TRight4;
        public string TRight4
        {
            get
            {
                return _TRight4;
            }
            set
            {
                _TRight4 = value;
            }
        }
        string _TRight5;
        public string TRight5
        {
            get
            {
                return _TRight5;
            }
            set
            {
                _TRight5 = value;
            }
        }
        DataTable _ConfigDet;
        public DataTable ConfigDet
        {
            get
            {
                return _ConfigDet;
            }
            set
            {
                _ConfigDet = value;
            }
        }

        
        public DataTable LedgerSource(string DocType)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Acc_Qry_LedgerSelection", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@DocType", SqlDbType.VarChar, 5);
            param.Value = DocType;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "Ledger";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }

        public int Ledger_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();

            tmp.Add(CommonView.GetGridViewColumn("AccId", "AccId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("LedgerHead", "LedgerHead", 200, 2, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Address", "Address", 200, 3, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Balance", "Balance", 100, 4, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        #region "Tax"
        public DataTable Tax_Source()
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_Tax", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Tax";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public int Tax_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();

            tmp.Add(CommonView.GetGridViewColumn("TaxId", "TaxId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("TaxName", "TaxName", 100, 2, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("TaxPer", "Tax%", 60, 3, true));
            tmp.Add(CommonView.GetGridViewBoolColumn("Vat", "Vat", 50, 4, false));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        #endregion

        public DataTable Book_Source()
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_DefaultBookDet", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Book";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }
        public int Book_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();

            tmp.Add(CommonView.GetGridViewColumn("BookId", "BookId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Book", "Book", 100, 2, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("StartBillNo", "StartBillNo", 0, 3));
            tmp.Add(CommonView.GetGridViewBoolColumn("Closed", "Closed", 50, 4, true));


            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        public DataTable TaxSource()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_Tax", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "Tax";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }
        public DataTable CategorySource()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_Category", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "Category";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }
        public DataTable ConfigDet_Source(int Id,bool Hide)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_GeneralConfig", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@ConfigId", SqlDbType.Int);
            param.Value = Id;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Hide", SqlDbType.Bit);
            param.Value = Hide;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "ConfigDet";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            foreach (DataColumn Col in Tbl.Columns)
            {
                switch (Col.DataType.UnderlyingSystemType.Name)
                {
                    case "String":
                        Col.AllowDBNull = false;
                        Col.DefaultValue = "";
                        break;
                    case "Byte":
                        Col.DefaultValue = 0;
                        Col.AllowDBNull = false;
                        break;
                    case "int":
                        Col.AllowDBNull = false;
                        Col.DefaultValue = 0;
                        break;
                    case "Int32":
                        Col.AllowDBNull = false;
                        Col.DefaultValue = 0;
                        break;
                    case "Int16":
                        Col.AllowDBNull = false;
                        Col.DefaultValue = 0;
                        break;
                    case "Single":
                        Col.AllowDBNull = false;
                        Col.DefaultValue = 0.0;
                        break;
                    case "Double":
                        Col.AllowDBNull = false;
                        Col.DefaultValue = 0.0;
                        break;
                    case "Decimal":
                        Col.DefaultValue = 0.0;
                        Col.AllowDBNull = false;
                        break;
                    case "DateTime":
                        Col.DefaultValue = "01/01/1900";
                        Col.AllowDBNull = true;
                        break;
                    case "Boolean":
                        Col.DefaultValue = 0;
                        Col.AllowDBNull = false;
                        break;
                }
            }
            return Tbl;

        }
        public int ConfigDet_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();

            tmp.Add(CommonView.GetGridViewColumn("ConfigId", "ConfigId", 90, 1,true));
            tmp.Add(CommonView.GetGridViewColumn("ConfigProperty", "ConfigProperty", 300, 2, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("StringValue", "StringValue", 100, 3, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewBoolColumn("BitValue", "BitValue", 80, 4, false));
           // tmp.Add(CommonView.GetGridViewColumn("Yes", "Yes", 80, 4, false));
            tmp.Add(CommonView.GetGridViewColumn("Type", "Type", 90, 5, true));
            //tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        public DataTable ConfigSelect_Source()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_SelectConfig", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "ConfigDet";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            foreach (DataColumn Col in Tbl.Columns)
            {
                switch (Col.DataType.UnderlyingSystemType.Name)
                {
                    case "String":
                        Col.AllowDBNull = false;
                        Col.DefaultValue = "";
                        break;
                    case "Byte":
                        Col.DefaultValue = 0;
                        Col.AllowDBNull = false;
                        break;
                    case "int":
                        Col.AllowDBNull = false;
                        Col.DefaultValue = 0;
                        break;
                    case "Int32":
                        Col.AllowDBNull = false;
                        Col.DefaultValue = 0;
                        break;
                    case "Int16":
                        Col.AllowDBNull = false;
                        Col.DefaultValue = 0;
                        break;
                    case "Single":
                        Col.AllowDBNull = false;
                        Col.DefaultValue = 0.0;
                        break;
                    case "Double":
                        Col.AllowDBNull = false;
                        Col.DefaultValue = 0.0;
                        break;
                    case "Decimal":
                        Col.DefaultValue = 0.0;
                        Col.AllowDBNull = false;
                        break;
                    case "DateTime":
                        Col.DefaultValue = "01/01/1900";
                        Col.AllowDBNull = true;
                        break;
                    case "Boolean":
                        Col.DefaultValue = 0;
                        Col.AllowDBNull = false;
                        break;
                }
            }
            return Tbl;
        }
        public int ConfigSelect_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();

            tmp.Add(CommonView.GetGridViewColumn("ConfigId", "ConfigId", 0, 1, true));
            tmp.Add(CommonView.GetGridViewColumn("ConfigProperty", "ConfigProperty", 200, 2, false, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("StringValue", "StringValue", 0, 3, false, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("BitValue", "BitValue", 0, 4, false));
           

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        public DataTable Config_PrnModel(bool PrnModel)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_Config_PrnModel", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Printermode", SqlDbType.Bit);
            MyParam.Value = PrnModel;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_Config_PrnModel";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }
        public int ConfigPrnModel_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();

            tmp.Add(CommonView.GetGridViewColumn("PrnModelId", "PrnModelId", 0, 1, true));
            tmp.Add(CommonView.GetGridViewColumn("PrnModel", "PrnModel", 200, 2, false, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("ModelCode", "ModelCode", 0, 3, false, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("PrinterMode", "PrinterMode", 0, 4, false));
            tmp.Add(CommonView.GetGridViewColumn("IsBarCode", "IsBarCode", 0, 5, false));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        public void SaveFunction()
        {
            DataTable Tbl = new DataTable();
            DataSet Ds = new DataSet();
            string DetStr;
            Ds.Tables.Add(ConfigDet);

            DetStr = Ds.GetXml();
            DetStr = DetStr.Replace("'", "''");
            DetStr = DetStr.Replace("true", "1");
            DetStr = DetStr.Replace("false", "0");
            if (DetStr.IndexOf("T00:00:00") != -1)
                DetStr = DetStr.Replace(DetStr.Substring(DetStr.IndexOf("T00:00:00"), 15), "");
            Ds.Tables.Clear();
            Ds.Tables.Clear();
            Ds.Dispose();
            //string code;

            try
            {
                SqlConnection Con = new SqlConnection(Common.ConStr);
                SqlDataAdapter Da = new SqlDataAdapter();
                Con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("GenConfigSp", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@ConfigId", SqlDbType.Int);
                param.Value = _ConfigId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TLeft1", SqlDbType.NVarChar, 300);
                param.Value = _TLeft1;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TLeft2", SqlDbType.NVarChar, 300);
                param.Value = _TLeft2;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TLeft3", SqlDbType.NVarChar, 300);
                param.Value = _TLeft3;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TLeft4", SqlDbType.NVarChar, 300);
                param.Value = _TLeft4;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TLeft5", SqlDbType.NVarChar, 300);
                param.Value = _TLeft5;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TRight1", SqlDbType.NVarChar, 300);
                param.Value = _TRight1;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TRight2", SqlDbType.NVarChar, 300);
                param.Value = _TRight2;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TRight3", SqlDbType.NVarChar, 300);
                param.Value = _TRight3;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TRight4", SqlDbType.NVarChar, 300);
                param.Value = _TRight4;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TRight5", SqlDbType.NVarChar, 300);
                param.Value = _TRight5;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TMid1", SqlDbType.NVarChar, 300);
                param.Value = _TMid1;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TMid2", SqlDbType.NVarChar, 300);
                param.Value = _TMid2;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TMid3", SqlDbType.NVarChar, 300);
                param.Value = _TMid3;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TMid4", SqlDbType.NVarChar, 300);
                param.Value = _TMid4;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TMid5", SqlDbType.NVarChar, 300);
                param.Value = _TMid5;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CompId", SqlDbType.TinyInt);
                param.Value = Common.CId;
                Cmd.Parameters.Add(param);                         

                param = new SqlParameter("@DetStr", SqlDbType.NText);
                param.Value = DetStr;
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
        public DataTable GetConfig_Source(byte CompId)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_GetConfig", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;
                  
            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = CompId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_GetConfig";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }
        public DataTable Config_Source(string FormType,int ConfigId)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_Config_Sales", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@FormTYpe", SqlDbType.Char, 5);
            MyParam.Value = FormType;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@ConfigId", SqlDbType.Int);
            MyParam.Value = ConfigId;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "CustomerSelect";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }
        public DataTable FetchRecord()
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_GenConfigHdr", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_GenConfigHdr";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

          public DataTable Config_DefaultFocus(string FormType)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_Config_DefaultFocus", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@DocTYpe", SqlDbType.Char, 3);
            MyParam.Value = FormType;
            MyCmd.Parameters.Add(MyParam);

            //MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            //MyParam.Value = Common.CId;
            //MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "DefaultFocus";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }
    }
}
