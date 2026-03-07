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
    public class PrintSettingsDB
    {
        public PrintSettingsDB()
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

        string _FieldName;
        public string FieldName
        {
            get
            {
                return _FieldName;
            }
            set
            {
                _FieldName = value;
            }
        }

        bool _BitValue;
        public bool BitValue
        {
            get
            {
                return _BitValue;
            }
            set
            {
                _BitValue = value;
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
        
        byte _PrnModelId;
        public byte PrnModelId
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
        DataTable _PrintSettingDet;
        public DataTable PrintSettingDet
        {
            get
            {
                return _PrintSettingDet;
            }
            set
            {
                _PrintSettingDet = value;
            }
        }

        public void SaveFunction()
        {
            DataTable Tbl = new DataTable();
            DataSet Ds = new DataSet();
            string DetStr;
            Ds.Tables.Add(PrintSettingDet);

            DetStr = Ds.GetXml();
            DetStr = DetStr.Replace("'", "''");
            DetStr = DetStr.Replace("true", "1");
            DetStr = DetStr.Replace("false", "0");
            if (DetStr.IndexOf("T00:00:00") != -1)
                DetStr = DetStr.Replace(DetStr.Substring(DetStr.IndexOf("T00:00:00"), 15), "");
            Ds.Tables.Clear();
            Ds.Tables.Clear();
            Ds.Dispose();
            try
            {
                SqlConnection Con = new SqlConnection(Common.ConStr);
                SqlDataAdapter Da = new SqlDataAdapter();
                Con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("PrintSettingsSp", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@DetStr", SqlDbType.Text);
                param.Value = DetStr;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@PrinterMode", SqlDbType.Bit);
                param.Value = _Printermode;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@PrnModelId", SqlDbType.TinyInt);
                param.Value = _PrnModelId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@ConfigId", SqlDbType.Int);
                param.Value = _ConfigId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CompId", SqlDbType.TinyInt);
                param.Value = Common.CId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.TinyInt);
                param.Value = Common.UserId;
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
        public DataTable prnSettingsSource()
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_PrintSettings", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_PrintSettings";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }
        public DataTable PrintSettingsDet_Source()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_PrintSettings", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "PrintSettings";
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
        public int PrintSettingsDet_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();

            tmp.Add(CommonView.GetGridViewColumn("DocId", "DocId", 90, 1, true));
            tmp.Add(CommonView.GetGridViewColumn("FieldName", "FieldName", 200, 2, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));           
            tmp.Add(CommonView.GetGridViewBoolColumn("BitValue", "BitValue", 80, 3, false));
            tmp.Add(CommonView.GetGridViewColumn("OrderNo", "OrderNo", 80, 4, false));

            //tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        public bool PrnModelFetchRecord(string FormType)
        {
            SqlConnection Con = new SqlConnection(Common.ConStr);
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_Config_Sales", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@FormType", SqlDbType.Char, 5);
            param.Value = FormType;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@ConfigId", SqlDbType.Int);
            param.Value = 0;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            SqlDataReader rd = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (rd.Read())
            {
                _ConfigId = (int)rd.GetValue(rd.GetOrdinal("ConfigId"));               
                _Printermode = (bool)rd.GetValue(rd.GetOrdinal("Printermode"));
                _PrnModelId = (byte)rd.GetValue(rd.GetOrdinal("PrnModelId"));
                return true;
            }
            else
            {
                rd.Close();
                Cmd.Dispose();
                Con.Close();
                return false;
            }
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
    }
}
