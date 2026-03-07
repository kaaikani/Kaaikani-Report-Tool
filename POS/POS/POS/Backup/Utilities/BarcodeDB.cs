using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using GridStructures;
using DBAccess;
using RLPOSDB;

namespace RLPOSDB
{
    /// <summary>
    /// Summary description for SalesDb.
    /// </summary>
    public class BarcodeDB
    {
        public BarcodeDB()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    

        # region "Properties"


        int _BarCodeId;
        public int BarCodeId
        {
            get
            {
                return _BarCodeId;
            }
            set
            {
                _BarCodeId = value;
            }
        }

        int _RSalId;
        public int RSalId
        {
            get
            {
                return _RSalId;
            }
            set
            {
                _RSalId = value;
            }
        }


        string _DataSerperator;
        public string DataSerperator
        {
            get
            {
                return _DataSerperator;
            }
            set
            {
                _DataSerperator = value;
            }
        }


        DateTime _BillDt;
        public DateTime BillDt
        {
            get
            {
                return _BillDt;
            }
            set
            {
                _BillDt = value;
            }
        }

        bool _Retail;
        public bool Retail
        {
            get
            {
                return _Retail;
            }
            set
            {
                _Retail = value;
            }
        }
        bool _OtherState;

        string _Caption;
        public string Caption 
        {
            get
            {
                return _Caption;
            }
            set
            {
                _Caption = value;
            }
        }
        byte _ColumnNo;
        public byte ColumnNo
        {
            get
            {
                return _ColumnNo;
            }
            set
            {
                _ColumnNo = value;
            }
        }
        string _HeaderDet;
        public string HeaderDet
        {
            get
            {
                return _HeaderDet;
            }
            set
            {
                _HeaderDet = value;
            }
        }


        string _FooterDet;
        public string FooterDet
        {
            get
            {
                return _FooterDet;
            }
            set
            {
                _FooterDet = value;
            }
        }


        DataTable _BarCodeDesignDet;
        public DataTable BarCodeDesignDet
        {
            get
            {
                return _BarCodeDesignDet;
            }
            set
            {
                _BarCodeDesignDet = value;
            }
        }


        string _CustomerCardNo;

        public string CustomerCardNo
        {
            get { return _CustomerCardNo; }
            set { _CustomerCardNo = value; }
        }

        string _BasketNo;

        public string BasketNo
        {
            get { return _BasketNo; }
            set { _BasketNo = value; }
        }

        string _Add2;

        public string Add2
        {
            get { return _Add2; }
            set { _Add2 = value; }
        }

        string _Add3;

        public string Add3
        {
            get { return _Add3; }
            set { _Add3 = value; }
        }

        string _CellNo;

        public string CellNo
        {
            get { return _CellNo; }
            set { _CellNo = value; }
        }


        # endregion

        

        # region "Save Function"

       

        public void SaveFunction(Saving.SaveType Mode)
        {
            DataTable Tbl = new DataTable();
            DataSet Ds = new DataSet();
            string DetStr;
            Ds.Tables.Add(BarCodeDesignDet);
            DetStr = Ds.GetXml();
            DetStr = DetStr.Replace("'", "''");
            DetStr = DetStr.Replace("true", "1");
            DetStr = DetStr.Replace("false", "0");
            if (DetStr.IndexOf("T00:00:00") != -1)
                DetStr = DetStr.Replace(DetStr.Substring(DetStr.IndexOf("T00:00:00"), 15), "");
            Ds.Tables.Clear();
            Ds.Tables.Clear();
            Ds.Dispose();
            string code;
            int Modeval = 0;
            if (Mode == Saving.SaveType.Add)
                Modeval = 1;
            else if (Mode == Saving.SaveType.Edit)
                Modeval = 2;
            else if (Mode == Saving.SaveType.Delete)
                Modeval = 3;
            else if (Mode == Saving.SaveType.DocCancel)
                Modeval = 8;
            try
            {
                SqlConnection Con = new SqlConnection(Common.ConStr);
                SqlDataAdapter Da = new SqlDataAdapter();
                Con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("BarCodeDesignSP", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@Mode", SqlDbType.TinyInt);
                param.Value = Modeval;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@BarCodeId", SqlDbType.Int);
                param.Value = _BarCodeId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Caption", SqlDbType.VarChar,50);
                param.Value = _Caption;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@HeaderDet", SqlDbType.Text);
                param.Value = _HeaderDet;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@FooterDet", SqlDbType.Text);
                param.Value = _FooterDet;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DataSerperator", SqlDbType.VarChar,5);
                param.Value = _DataSerperator;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@ColumnNo", SqlDbType.TinyInt);
                param.Value = _ColumnNo;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DetStr", SqlDbType.Text);
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

        # endregion
    
        # region "DesignDet Details"
        public DataTable BCodeDesignDet_Source(int Id)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_BarcodeDesignDet", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@BarCodeId", SqlDbType.Int);
            param.Value = Id;
            Cmd.Parameters.Add(param);


            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "BarcodeDesignDet";
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
                }
            }
            return Tbl;
        }


        public int BCodeDesignDet_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("BarCodeId", "BarCodeId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("ColumnNo", "ColumnNo", 0, 2));
            tmp.Add(CommonView.GetGridViewColumn("BarcodeDet", "BarcodeDet", 160, 3, false, DataGridViewContentAlignment.MiddleLeft,"",DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("FieldName", "FieldName", 150, 4, false, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Format", "Format", 100, 5));
            tmp.Add(CommonView.GetGridViewColumn("ColSize", "ColSize", 100, 6));//,true,DataGridViewContentAlignment.MiddleLeft));
         
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
            return 0;
        }

      
        # endregion

        # region "Fetch Record"

        public bool FetchRecord(int Id)
        {
            SqlConnection Con = new SqlConnection(Common.ConStr);
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_BarcodeDesignHdr", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@BarCodeId", SqlDbType.Int);
            param.Value = Id;
            Cmd.Parameters.Add(param);

            //param = new SqlParameter("@compid", SqlDbType.TinyInt);
            //param.Value = Common.CId;
            //Cmd.Parameters.Add(param);

            SqlDataReader rd = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (rd.Read())
            {

                _BarCodeId = (int)rd.GetValue(rd.GetOrdinal("BarCodeId"));
                //_BillNo = (int)rd.GetValue(rd.GetOrdinal("Billno"));
                //_BillDt = (DateTime)rd.GetValue(rd.GetOrdinal("BillDt"));
                //_BookId = (short)rd.GetValue(rd.GetOrdinal("BookId"));
                _Caption = (string)rd.GetValue(rd.GetOrdinal("Caption"));
                //_OrdNo = (string)rd.GetValue(rd.GetOrdinal("OrdNo"));
                _HeaderDet = (string)rd.GetValue(rd.GetOrdinal("HeaderDet"));
                _FooterDet = (string)rd.GetValue(rd.GetOrdinal("FooterDet"));
                _DataSerperator = (string)rd.GetValue(rd.GetOrdinal("DataSerperator"));
                 _ColumnNo = (byte)rd.GetValue(rd.GetOrdinal("ColumnNo"));
                rd.Close();
                Cmd.Dispose();
                Con.Close();
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

        # endregion
        public DataTable FieldType_Source()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_FieldType", Con);
            Cmd.CommandType = CommandType.StoredProcedure;
            //SqlParameter param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            //param.Value = Common.CId;
            //Cmd.Parameters.Add(param);
            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "Qry_FieldType";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }

        #region "For View Record"

        public System.Collections.Hashtable _FilteringValues = new System.Collections.Hashtable();
        _ViewValues _View;
        public struct _ViewValues
        {
            public System.Collections.Hashtable FilteringValues;
            public string TableNames;
            public string Fields;
            public string Conditions;
            public string OrderBy;
            public string AdvVwTblName;
        }
        public void SetViewControl()
        {
            _FilteringValues.Clear();

            _View.FilteringValues = _FilteringValues;
            _View.TableNames = "Fn_BarcodeDesignHdr()";
            _View.Fields = "*";
            _View.Conditions = "";
            _View.OrderBy = "BarCodeId";

        }
        public DataTable navigate()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("select top 100 * from Fn_BarcodeDesignHdr() order by BarCodeId desc", Con);
            Cmd.CommandType = CommandType.Text;
            SqlParameter param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);
            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "navigate";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }
        public _ViewValues ViewValues
        {
            get
            {
                return _View;
            }
            set
            {
                _View = value;
            }

        }
        public int View_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();

            tmp.Add(CommonView.GetGridViewColumn("BarCodeId", "BarCodeId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Caption", "Caption", 50, 2, true));
            tmp.Add(CommonView.GetGridViewColumn("HeaderDet", "HeaderDet", 170, 3, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));
            tmp.Add(CommonView.GetGridViewColumn("FooterDet", "FooterDet", 120, 4, true));
            tmp.Add(CommonView.GetGridViewColumn("DataSerperator", "DataSerperator", 100, 5, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("ColumnNo", "ColumnNo", 50, 6));//, true, DataGridViewContentAlignment.MiddleLeft, ""));
         
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        #endregion




        #region "Field Source"

        public DataTable FieldSelect_Source(string Type)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_Barcode_FieldSelect", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;


            MyParam = new SqlParameter("@Type", SqlDbType.VarChar, 50);
            MyParam.Value = Type;
            MyCmd.Parameters.Add(MyParam);


            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_Barcode_FieldSelect";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public int FieldSelect_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            //tmp.Add(CommonView.GetGridViewColumn("column_name", "column_name", 50, 1, true));
            //tmp.Add(CommonView.GetGridViewColumn("Data_Type", "Data_Type", 70, 2, true));//, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));
            //tmp.Add(CommonView.GetGridViewColumn("Ordinal_position", "Ordinal_position", 0, 3, true));        
            tmp.Add(CommonView.GetGridViewColumn("Id", "Id", 0, 1, true));
            tmp.Add(CommonView.GetGridViewColumn("FieldName", "FieldName", 70, 2, true));
            //tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
            return 0;
        }
        #endregion


      



    }
}
