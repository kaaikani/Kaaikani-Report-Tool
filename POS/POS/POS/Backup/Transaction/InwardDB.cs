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
    /// Summary description for PartyDB.
    /// </summary>
    public class InwardDB
    {
        public InwardDB()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        # region "Properties"

        int _InwId;
        public int InwId
        {
            get
            {
                return _InwId;
            }
            set
            {
                _InwId = value;
            }
        }
        int _CustId;
        public int CustId
        {
            get
            {
                return _CustId;
            }
            set
            {
                _CustId = value;
            }
        }
        

        int _InwNo;
        public int InwNo
        {
            get
            {
                return _InwNo;
            }
            set
            {
                _InwNo = value;
            }
        }


        int _RefId;
        public int RefId
        {
            get
            {
                return _RefId;
            }
            set
            {
                _RefId = value;
            }
        }


        String _Remarks;
        public String Remarks
        {
            get
            {
                return _Remarks;
            }
            set
            {
                _Remarks = value;
            }
        }


        String _CustName;
        public String CustName
        {
            get
            {
                return _CustName;
            }
            set
            {
                _CustName = value;
            }
        }


        DateTime _InwDt;
        public DateTime InwDt
        {
            get
            {
                return _InwDt;
            }
            set
            {
                _InwDt = value;
            }
        }

        DateTime _DelDt;
        public DateTime DelDt
        {
            get
            {
                return _DelDt;
            }
            set
            {
                _DelDt = value;
            }
        }


      

    
        decimal _TotQty;
        public decimal TotQty
        {
            get
            {
                return _TotQty;
            }
            set
            {
                _TotQty = value;
            }
        }

        decimal _TotAmt;
        public decimal TotAmt
        {
            get
            {
                return _TotAmt;
            }
            set
            {
                _TotAmt = value;
            }
        }

        byte _UserId;
        public byte UserId
        {
            get
            {
                return _UserId;
            }
            set
            {
                _UserId = value;
            }
        }

        int _PtyId;
        public int PtyId
        {
            get
            {
                return _PtyId;
            }
            set
            {
                _PtyId = value;
            }
        }


        byte _CompId;
        public byte CompId
        {
            get
            {
                return _CompId;
            }
            set
            {
                _CompId = value;
            }
        }
        DataTable _InwardDet;
        public DataTable InwardDet
        {
            get
            {
                return _InwardDet;
            }
            set
            {
                _InwardDet = value;
            }
        }
        
        # endregion

        # region "Save"
        
        public void  SaveFunction(Saving.SaveType Mode)
        {


            DataSet Ds = new DataSet();
            string DetStr;
            Ds.Tables.Add(InwardDet);
            DetStr = Ds.GetXml();
            DetStr = DetStr.Replace("'", "''");
            DetStr = DetStr.Replace("true", "1");
            DetStr = DetStr.Replace("false", "0");
          
            Ds.Tables.Clear();
            Ds.Dispose();

            string code;
            string codeNo;


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
                Cmd = new SqlCommand("InwSP", Con);
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@Mode", SqlDbType.TinyInt);
                param.Value = Modeval;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@InwId", SqlDbType.Int);
                param.Value = _InwId ;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@InwNo", SqlDbType.Int);
                param.Value = _InwNo ;
                Cmd.Parameters.Add(param);


                param = new SqlParameter("@InwDt", SqlDbType.DateTime);
                param.Value = _InwDt .ToString("dd/MM/yyyy");
                Cmd.Parameters.Add(param);


                param = new SqlParameter("@Remarks", SqlDbType.VarChar, 150);
                param.Value = _Remarks ;
                Cmd.Parameters.Add(param);             

                
                param = new SqlParameter("@TotQty", SqlDbType.Decimal);
                param.Value = _TotQty;
                Cmd.Parameters.Add(param);



                param = new SqlParameter("@TotAmt", SqlDbType.Decimal);
                param.Value = _TotAmt ;
                Cmd.Parameters.Add(param);


                param = new SqlParameter("@UserId", SqlDbType.TinyInt);
                param.Value = Common.UserId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CompId", SqlDbType.TinyInt);
                param.Value = Common.CId;
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

  
       
        # region "Selection"

      
       public DataTable Cuscode_cheking(int configid)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Config_Qry_GetBitvalue", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@ConfigId", SqlDbType.Int);
            MyParam.Value = configid;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@compId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);


            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "PBillRetNo";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }
        # endregion

        public DataTable Customer_Source()
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_Customer", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

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

        public int Customer_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("Accid", "Accid", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Customer", "Customer", 200, 2, true));
            tmp.Add(CommonView.GetGridViewColumn("AcCode", "AcCode", 0, 3));
            tmp.Add(CommonView.GetGridViewColumn("Add1", "Address", 80, 4, true));
            tmp.Add(CommonView.GetGridViewColumn("Add2", "Address1", 80, 5, true));
            tmp.Add(CommonView.GetGridViewColumn("Add3", "Address2", 80, 6, true));
            tmp.Add(CommonView.GetGridViewColumn("City", "City", 80, 7, true));
            tmp.Add(CommonView.GetGridViewColumn("Pincode", "Pincode", 80, 8, true));
            tmp.Add(CommonView.GetGridViewColumn("Ph1", "Phone", 80, 9, true));
            tmp.Add(CommonView.GetGridViewColumn("Ph2", "Phone1", 80, 10, true));
            tmp.Add(CommonView.GetGridViewColumn("TransportId", "TransportId", 0, 11));
            tmp.Add(CommonView.GetGridViewColumn("Transport", "Transport", 0, 12));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }


        public DataTable ItemSelect_Source(int CategoryId, string ItemCode)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_PurItemSelect", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@CategoryId", SqlDbType.Int);
            MyParam.Value = CategoryId;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@ItemCode", SqlDbType.VarChar, 20);
            MyParam.Value = ItemCode;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "PurDet";//"ItemSelect";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public int ItemSelect_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();

            tmp.Add(CommonView.GetGridViewColumn("Itemid", "Itemid", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("ItemCode", "Itemcode", 80, 2, true));
            tmp.Add(CommonView.GetGridViewColumn("CategoryId", "CategoryId", 0, 3));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 80, 4, false));

            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 80, 5, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("LastMRPRate", "MRPRate", 0, 6, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("LastPurRate", "Pur.Rate", 0, 7, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("LastSaleRate", "SaleRate", 0, 8, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("TaxId", "TaxId", 0, 9));
            tmp.Add(CommonView.GetGridViewColumn("TaxName", "TaxName", 80, 10, true));
            tmp.Add(CommonView.GetGridViewColumn("TaxPer", "TaxPer", 50, 11, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewBoolColumn("WtItem", "WtItem", 0, 12));
            tmp.Add(CommonView.GetGridViewColumn("AllowExpiry", "AllowExpiry", 0, 13));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }


        
        # region "Fetch Section"
        public bool FetchRecord(int Id)
        {
            SqlConnection Con = new SqlConnection(Common.ConStr);
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_InwHdr", Con);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("@InwId", SqlDbType.Int);
            param.Value = Id;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            
            SqlDataReader rd = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (rd.Read())
            {
                _InwId  = (int)rd.GetValue(rd.GetOrdinal("InwId"));
                _InwNo  = (int)rd.GetValue(rd.GetOrdinal("Inwno"));
                _InwDt  = (DateTime)rd.GetValue(rd.GetOrdinal("InwDt"));
                //_CustId = (int)rd.GetValue(rd.GetOrdinal("CustId"));
                //_DelDt = (DateTime)rd.GetValue(rd.GetOrdinal("DelDt"));
                //_RefId = (int)rd.GetValue(rd.GetOrdinal("RefId"));
                _PtyId = (int)rd.GetValue(rd.GetOrdinal("PtyId"));
                _Remarks  = (String)rd.GetValue(rd.GetOrdinal("Remarks"));
                //_CustId = (int)rd.GetValue(rd.GetOrdinal("CustId"));
                //_CustId = (int)rd.GetValue(rd.GetOrdinal("CustId"));
                _TotQty = (decimal)rd.GetValue(rd.GetOrdinal("TotQty"));
                _TotAmt  = (decimal)rd.GetValue(rd.GetOrdinal("TotAmt"));
                _UserId = (byte)rd.GetValue(rd.GetOrdinal("UserId"));
                _CompId = (byte)rd.GetValue(rd.GetOrdinal("CompId"));
                
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
        #endregion

        #region "For View Record"
        public DataTable navigate()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Select Top 100 * From inwHdrVwFn(" + Common.CId + ") where InwId > 0 order by InwId desc", Con);
            Cmd.CommandType = CommandType.Text;

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "inwHdrVwFn";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }

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
            _View.TableNames = "inwHdrVwFn(" + Common.CId + ")";
            _View.Fields = "*";
            _View.Conditions = "";
            _View.OrderBy = "InwId";
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
            tmp.Add(CommonView.GetGridViewColumn("InwId", "InwId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Inwno", "Inwno", 100, 2));
            tmp.Add(CommonView.GetGridViewColumn("InwDt", "InwDt", 100, 3, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));        
            tmp.Add(CommonView.GetGridViewColumn("TotQty", "TotQty", 100, 6, true, DataGridViewContentAlignment.MiddleLeft, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("TotAmt", "TotAmt", 0, 7, true, DataGridViewContentAlignment.MiddleLeft, "#####0.000"));
            tmp.Add(CommonView.GetGridViewColumn("Remarks", "Remarks", 150, 7, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));            
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }


        public int Search_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("InwardId", "BatchId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("InwardNo", "BatchNo", 80, 2));
            tmp.Add(CommonView.GetGridViewColumn("InwardDate", "Date", 100, 3, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));            
            tmp.Add(CommonView.GetGridViewColumn("TotQty", "TotQty", 100, 4, true, DataGridViewContentAlignment.MiddleLeft, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("TotWt", "TotWt", 100, 5, true, DataGridViewContentAlignment.MiddleLeft, "######0.000"));
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 6));
            //tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 19));
            
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }


        #endregion
        

        public DataTable InwardDet_Source(int Id)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_InwDet", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@InwId", SqlDbType.Int);
            param.Value = Id;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "InwDet";
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
                        Col.DefaultValue = 0 ;
                        Col.AllowDBNull = false;
                        break;
                }
            }
            return Tbl;

        }
        public int InwardDet_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
                               
            tmp.Add(CommonView.GetGridViewColumn("InwId", "InwId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("CategoryId", "CategoryId", 0, 2, false, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 200, 3, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 4));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "Item Name", 200, 5, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Qty", (Common.HeaderName1 == "") ? "Qty" : Common.HeaderName1, 80, 6, false, DataGridViewContentAlignment.MiddleRight, Common.QtyFormat));
            tmp.Add(CommonView.GetGridViewColumn("Wt", (Common.HeaderName2 == "") ? "Wt" : Common.HeaderName2, (Common.WtItem == true) ? 80 : 0, 7, false, DataGridViewContentAlignment.MiddleRight, "#####0.000"));
            tmp.Add(CommonView.GetGridViewColumn("Rate", "Rate", 0, 8, false, DataGridViewContentAlignment.MiddleLeft, "#####0.000"));
            tmp.Add(CommonView.GetGridViewColumn("Amount", "Amount", 0, 9, true, DataGridViewContentAlignment.MiddleLeft, "#####0.000"));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

        #region"BatchNo"
        public DataTable BatchNo_Source()
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_BatchNo", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "BatchNo";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public int BatchNo_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("BatchId", "BatchId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("BatchName", "BatchName", 100, 2, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("BatchNo", "BatchNo", 0, 3));            
            tmp.Add(CommonView.GetGridViewColumn("PtyName", "PtyName", 100, 4, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("PtyId", "PtyId", 0, 5));
            tmp.Add(CommonView.GetGridViewColumn("Qty", "Qty", 80, 6, true, DataGridViewContentAlignment.BottomRight, "##0"));
            tmp.Add(CommonView.GetGridViewColumn("Validfrom", "ValidFrom", 80, 7, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));
            tmp.Add(CommonView.GetGridViewColumn("Validto", "ValidTo", 80, 8, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 9));
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 10));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

        public DataTable BatchNoParty_Source(int BId)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_Batch", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Bid", SqlDbType.TinyInt);
            MyParam.Value =BId;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "BatchNo";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        #endregion

    }
}
