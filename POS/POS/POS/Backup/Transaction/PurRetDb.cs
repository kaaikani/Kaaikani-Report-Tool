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
    public class PurRetDb
	{
        public PurRetDb()
		{
			//
			// TODO: Add constructor logic here
			//
		}

# region "Properties"
		int _PurRetId;
		public int PurRetId
		{
			get
			{
				return _PurRetId;
			}
			set
			{
				_PurRetId = value;
			}
		}
        short _AcYrId;
        public short AcYrId
        {
            get
            {
                return _AcYrId;
            }
            set
            {
                _AcYrId = value;
            }
        }

		int _PurRetNo;
		public int PurRetNo
		{
			get
			{
                return _PurRetNo;
			}
			set
			{
                _PurRetNo = value;
			}
		}

        string  _PurRetInvNo;
        public string PurRetInvNo
        {
            get
            {
                return _PurRetInvNo;
            }
            set
            {
                _PurRetInvNo = value;
            }
        }
		DateTime _PurRetDt;
        public DateTime PurRetDt
		{
			get
			{
                return _PurRetDt;
			}
			set
			{
                _PurRetDt = value;
			}
		}

        DateTime _PurRetInvDt;
        public DateTime PurRetInvDt
        {
            get
            {
                return _PurRetInvDt;
            }
            set
            {
                _PurRetInvDt = value;
            }
        }
       
        bool _OtherState;
        public bool OtherState
        {
            get
            {
                return _OtherState;
            }
            set
            {
                _OtherState = value;
            }
        }

        int _PurId;
        public int PurId
        {
            get
            {
                return _PurId;
            }
            set
            {
                _PurId = value;
            }
        }
        bool _Cash;
        public bool Cash
        {
            get
            {
                return _Cash;
            }
            set
            {
                _Cash = value;
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
        
       
        decimal _Total;
        public decimal Total
        {
            get
            {
                return _Total;
            }
            set
            {
                _Total = value;
            }
        }

        decimal _TaxPer;
        public decimal TaxPer
        {
            get
            {
                return _TaxPer;
            }
            set
            {
                _TaxPer = value;
            }
        }

        decimal _TaxAmt;
        public decimal TaxAmt
        {
            get
            {
                return _TaxAmt;
            }
            set
            {
                _TaxAmt = value;
            }
        }
        short  _TaxId;
        public short TaxId
        {
            get
            {
                return _TaxId;
            }
            set
            {
                _TaxId = value;
            }
        }

        decimal _DiscPer;
        public decimal DiscPer
        {
            get
            {
                return _DiscPer;
            }
            set
            {
                _DiscPer = value;
            }
        }
        decimal _DiscAmt;
        public decimal DiscAmt
        {
            get
            {
                return _DiscAmt;
            }
            set
            {
                _DiscAmt = value;
            }
        }
		decimal _NetAmt;
		public decimal NetAmt
		{
			get
			{
				return _NetAmt;
			}
			set
			{
				_NetAmt = value;
			}
		}
        string _Narration;
        public string Narration
        {
            get
            {
                return _Narration;
            }
            set
            {
                _Narration = value;
            }
        }

        short _CSTTaxId;
        public short CSTTaxId
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

		DataTable _PurRetDet;
		public DataTable PurRetDet 
		{
			get
			{
                return _PurRetDet;
			}
			set
			{
                _PurRetDet = value;
			}
		}
        DataTable _PurRetPostDet;
        public DataTable PurRetPostDet
        {
            get
            {
                return _PurRetPostDet;
            }
            set
            {
                _PurRetPostDet = value;
            }
        }
		# endregion

# region "Selection Source"

        public DataTable Supplier_Source()
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_Supplier", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "SupplierSelect";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public int Supplier_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("Accid", "Accid", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Supplier", "Supplier", 200, 4, true));
            tmp.Add(CommonView.GetGridViewColumn("AcCode", "AcCode", 0, 3));
            tmp.Add(CommonView.GetGridViewColumn("Add1", "Address", 80, 4, true));
            tmp.Add(CommonView.GetGridViewColumn("Add2", "Address1", 80, 5, true));
            tmp.Add(CommonView.GetGridViewColumn("Add3", "Address2", 80, 6, true));
            tmp.Add(CommonView.GetGridViewColumn("City", "City", 80, 7, true));
            tmp.Add(CommonView.GetGridViewColumn("Pincode", "Pincode", 80, 8, true));
            tmp.Add(CommonView.GetGridViewColumn("Ph1", "Phone", 80, 9, true));
            tmp.Add(CommonView.GetGridViewColumn("Ph2", "Phone1", 80, 10, true));
            tmp.Add(CommonView.GetGridViewColumn("TransportId", "TransportId", 0, 11));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }


        //public DataTable ItemSelect_Source(bool Product, int PurId, int AcYrId)
        //{
        //    SqlConnection MyCon = new SqlConnection();
        //    SqlCommand MyCmd = new SqlCommand();
        //    SqlParameter MyParam = new SqlParameter();
        //    SqlDataAdapter MyAdapt = new SqlDataAdapter();
        //    DataTable DTbl = new DataTable();

        //    MyCon = new SqlConnection(Common.ConStr);
        //    MyCon.Open();

        //    MyCmd = new SqlCommand("Qry_NonPurReturneditems", MyCon);
        //    MyCmd.CommandType = CommandType.StoredProcedure;

        //    MyParam = new SqlParameter("@Product", SqlDbType.Bit);
        //    MyParam.Value = Product;
        //    MyCmd.Parameters.Add(MyParam);

        //    MyParam = new SqlParameter("@PurId", SqlDbType.Int);
        //    MyParam.Value = PurId;
        //    MyCmd.Parameters.Add(MyParam);

        //    MyParam = new SqlParameter("@AcYrId", SqlDbType.Int);
        //    MyParam.Value = AcYrId;
        //    MyCmd.Parameters.Add(MyParam);

        //    MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
        //    MyParam.Value = Common.CId;
        //    MyCmd.Parameters.Add(MyParam);

        //    MyAdapt.SelectCommand = MyCmd;
        //    MyAdapt.Fill(DTbl);

        //    DTbl.TableName = "ItemSelect";
        //    MyAdapt.Dispose();
        //    MyCmd.Dispose();
        //    MyCon.Close();
        //    return DTbl;
        //}


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
        public DataTable TaxUpDate_Source(short Taxid, bool OtherState)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_PurRetTaxSelect_GST", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Taxid", SqlDbType.SmallInt);
            MyParam.Value = Taxid;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@OtherState", SqlDbType.Bit);
            MyParam.Value = (OtherState == true ? 1 : 0);
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "PurRetTaxSelect";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }
        public DataTable BillNo_Source(int PtyId, DateTime Dt, short AcYrId, short CAcYrId)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_NonPurReturnedBills", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@PtyId", SqlDbType.Int);
            MyParam.Value = PtyId;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Dt", SqlDbType.DateTime);
            MyParam.Value = Dt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@AcYrId", SqlDbType.SmallInt);
            MyParam.Value = AcYrId;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CAcYrId", SqlDbType.SmallInt);
            MyParam.Value = CAcYrId;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "BillNo";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public int BillNo_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("PurId", "PurId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("PurNo", "PurNo", 70, 2, true));
            tmp.Add(CommonView.GetGridViewColumn("PurDt", "PurDt", 80, 3, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));
            tmp.Add(CommonView.GetGridViewColumn("InvNo", "InvNo", 70, 4, true));
            tmp.Add(CommonView.GetGridViewColumn("InvDt", "InvDt", 80, 5, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));
            tmp.Add(CommonView.GetGridViewColumn("NetAmt", "NetAmt", 80, 6, true, DataGridViewContentAlignment.MiddleRight, "####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("PtyId", "PtyId", 0, 7));
            tmp.Add(CommonView.GetGridViewColumn("AcYrId", "AcYrId", 0, 8));
            
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

        # endregion

        public DataTable LastPurRetNo_Source()
        {

            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_LastPurRetNoSource", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_LastPurRetNoSource";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();

            return DTbl;

        }

# region "Save Function"

        public void SaveFunction(Saving.SaveType Mode)
        {
            DataTable Tbl = new DataTable();
            DataSet Ds = new DataSet();
            string DetStr;
            Ds.Tables.Add(PurRetDet);
            Ds.Tables.Add(PurRetPostDet);
            DetStr = Ds.GetXml();
            DetStr = DetStr.Replace("'", "''");
            DetStr = DetStr.Replace("true", "1");
            DetStr = DetStr.Replace("false", "0");
            if (DetStr.IndexOf("T00:00:00") != -1)
                DetStr = DetStr.Replace(DetStr.Substring(DetStr.IndexOf("T00:00:00"), 15), "");
            Ds.Tables.Clear();
            Ds.Tables.Clear();
            Ds.Dispose();

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
                Cmd = new SqlCommand("PurRetSP", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@Mode", SqlDbType.TinyInt);
                param.Value = Modeval;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@PurRetId", SqlDbType.Int);
                param.Value = _PurRetId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@AcYrId", SqlDbType.SmallInt);
                param.Value = _AcYrId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@PurRetNo", SqlDbType.Int);
                param.Value = _PurRetNo;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@PurRetDt", SqlDbType.DateTime);
                param.Value = _PurRetDt.ToString("dd/MMM/yyyy");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@PurRetInvNo", SqlDbType.VarChar,25);
                param.Value = _PurRetInvNo;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@PurRetInvDt", SqlDbType.DateTime);
                param.Value = _PurRetInvDt.ToString("dd/MMM/yyyy");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@PtyId", SqlDbType.Int);
                param.Value = _PtyId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@OtherState", SqlDbType.Bit);
                param.Value = (_OtherState == true ? 1 : 0);
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Cash", SqlDbType.Bit);
                param.Value = _Cash;
                Cmd.Parameters.Add(param);


                param = new SqlParameter("@Narr", SqlDbType.VarChar, 100);
                param.Value = _Narration.Replace("'", "''");
                Cmd.Parameters.Add(param);


                param = new SqlParameter("@TotAmt", SqlDbType.Decimal);
                param.Value = _Total;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@NetAmt", SqlDbType.Decimal);
                param.Value = _NetAmt;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DiscPer", SqlDbType.Decimal);
                param.Value = _DiscPer;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DiscAmt", SqlDbType.Decimal);
                param.Value = _DiscAmt;
                Cmd.Parameters.Add(param);

                 param = new SqlParameter("@TaxId", SqlDbType.SmallInt);
                 param.Value = _TaxId;
                Cmd.Parameters.Add(param);

                 param = new SqlParameter("@TaxPer", SqlDbType.Decimal);
                 param.Value = _TaxPer;
                Cmd.Parameters.Add(param);

                 param = new SqlParameter("@TaxAmt", SqlDbType.Decimal);
                 param.Value = _TaxAmt;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CSTTaxId", SqlDbType.SmallInt);
                param.Value = _CSTTaxId;
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

# region "Details"

        public DataTable ItemDetail_Source(string ItemCode, DateTime SpDt)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_ItemDetail", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;



            MyParam = new SqlParameter("@ItemCode", SqlDbType.VarChar, 20);
            MyParam.Value = ItemCode;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@SpDt", SqlDbType.DateTime);
            MyParam.Value = SpDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);


            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_ItemDetail";//"ItemSelect";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public DataTable PurRetDet_Source(int Id)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_PurRetDet", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@PurRetId", SqlDbType.Int);
            param.Value = Id;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "PurRetDet";
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
        public int purRetDet_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("PurRetId", "PurRetId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Itemcode", "ItemCode", 80, 2, false, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("CategoryId", "CategoryId", 0, 3));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 150, 4, false, DataGridViewContentAlignment.MiddleLeft));//,true,DataGridViewContentAlignment.MiddleLeft));            
            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 5));

            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 70, 6, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("BatchNo", "BatchNo", (Common.AllowExpiryDt == true) ? 90 : 0, 7, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewDateColumn("ExpiryDt", "ExpiryDate", (Common.AllowExpiryDt == true) ? 90 : 0, 8, "dd/MM/yyyy", true));
            tmp.Add(CommonView.GetGridViewColumn("Qty", (Common.HeaderName1 == "") ? "Qty" : Common.HeaderName1, 50, 9, false, DataGridViewContentAlignment.MiddleRight, "#####0.000"));
            tmp.Add(CommonView.GetGridViewColumn("Wt", (Common.HeaderName2 == "") ? "Wt" : Common.HeaderName2, (Common.WtItem == true) ? 70 : 0, 10, false, DataGridViewContentAlignment.MiddleRight, "#####0.000"));

            tmp.Add(CommonView.GetGridViewColumn("Free", "Free", (Common.AllowPurRetFree == true) ? 70 : 0, 11, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));

            tmp.Add(CommonView.GetGridViewColumn("PurRate", "Rate", 60, 12, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            //tmp.Add(CommonView.GetGridViewColumn("SaleRate", "SaleRate", 0, 9, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));            
            tmp.Add(CommonView.GetGridViewColumn("Amount", "Amount", 70, 13, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("TaxId", "TaxId", 0, 14, true));

            tmp.Add(CommonView.GetGridViewColumn("TaxName", "TaxName", 0, 15, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("TaxPer", "Tax%", (Common.AllowTax == true) ? 0 : 0, 16, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("TaxAmt", "TaxAmt", (Common.AllowTax == true) ? 0 : 0, 17, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SGSTPer", "SGST%", (Common.AllowTax == true) ? 70 : 0, 18, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SGSTAmt", "SGSTAmt", (Common.AllowTax == true) ? 70 : 0, 19, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("CGSTPer", "CGST%", (Common.AllowTax == true) ? 70 : 0, 20, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("CGSTAmt", "CGSTAmt", (Common.AllowTax == true) ? 70 : 0, 21, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("IGSTPer", "IGST%", (Common.AllowTax == true) ? 70 : 0, 22, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("IGSTAmt", "IGSTAmt", (Common.AllowTax == true) ? 70 : 0, 23, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SlNo", "SlNo", 0, 24, true));
            tmp.Add(CommonView.GetGridViewColumn("WtItem", "WtItem", 0, 25, true));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

         # endregion

        public DataTable PurTaxDet_Source(int PurId)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_PurRetPostDet", Con);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("@PurRetId", SqlDbType.Int);
            param.Value = PurId;
            Cmd.Parameters.Add(param);
            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);
            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "PurRetPostDet";
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
                        Col.DefaultValue = DateTime.Today;
                        Col.AllowDBNull = true;
                        break;
                }
            }

            return Tbl;
        }
        public int PurTaxDet_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("PurId", "PurId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("AccId", "AccId", 0, 2));
            tmp.Add(CommonView.GetGridViewColumn("LedgerHeader", "LedgerHeader", 100, 3, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Credit", "Credit", 80, 4, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Debit", "Debit", 80, 5, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Amount", "Amount", 0, 6));
            tmp.Add(CommonView.GetGridViewColumn("AcCode", "AcCode", 0, 7));
            tmp.Add(CommonView.GetGridViewColumn("DrCr", "DrCr", 0, 8));
            tmp.Add(CommonView.GetGridViewColumn("TaxId", "TaxId", 0, 9));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

        public DataTable CSTTax_Source(bool Vat)
        {

            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("CSTTaxSelect", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Vat", SqlDbType.Bit);
            MyParam.Value = Vat;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
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

        public int CSTTax_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("TaxId", "TaxId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("TaxName", "TaxName", 80, 2, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));

            tmp.Add(CommonView.GetGridViewColumn("TaxPer", "TaxPer", 0, 3));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

# region "Fetch Record"

        public bool FetchRecord(int Id)
        {
            SqlConnection Con = new SqlConnection(Common.ConStr);
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_PurRetHdr", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@PurRetId", SqlDbType.Int);
            param.Value = Id;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@CompId", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            SqlDataReader rd = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (rd.Read())
            {

                _PurRetId = (int)rd.GetValue(rd.GetOrdinal("PurRetId"));
                _PurRetNo = (int)rd.GetValue(rd.GetOrdinal("PurRetNo"));
                _PurRetDt = (DateTime)rd.GetValue(rd.GetOrdinal("PurRetDt"));
                _PurRetInvNo = (string)rd.GetValue(rd.GetOrdinal("PurRetInvNo"));
                _PurRetInvDt = (DateTime)rd.GetValue(rd.GetOrdinal("PurRetInvDt"));
                _PtyId = (int)rd.GetValue(rd.GetOrdinal("PtyId"));
                _Cash = (bool)rd.GetValue(rd.GetOrdinal("Cash"));
                _OtherState = (bool)rd.GetValue(rd.GetOrdinal("OtherState"));
                   
             
                _Total = (decimal)rd.GetValue(rd.GetOrdinal("TotAmt"));
                _NetAmt = (decimal)rd.GetValue(rd.GetOrdinal("NetAmt"));
                _TaxId = (short)rd.GetValue(rd.GetOrdinal("TaxId"));
                _TaxPer = (decimal)rd.GetValue(rd.GetOrdinal("TaxPer"));
                _TaxAmt = (decimal)rd.GetValue(rd.GetOrdinal("TaxAmt"));
                _DiscPer = (decimal)rd.GetValue(rd.GetOrdinal("DiscPer"));
                _DiscAmt = (decimal)rd.GetValue(rd.GetOrdinal("DiscAmt"));
                _UserId = (byte)rd.GetValue(rd.GetOrdinal("UserId"));
                _Narration = (string)rd.GetValue(rd.GetOrdinal("Narr"));
                _CSTTaxId = (short)rd.GetValue(rd.GetOrdinal("CSTTaxId"));
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
        public void SetViewControl(DateTime FrmDt, DateTime ToDt)
        {
            _FilteringValues.Clear();

            _View.FilteringValues = _FilteringValues;
            _View.TableNames = "PurRetVwFn(" + Common.CId + ",'" + FrmDt.ToString("dd/MMM/yyyy") + "','" + ToDt.ToString("dd/MMM/yyyy") + "')";
            _View.Fields = "*";
            _View.Conditions = "";
            _View.OrderBy = "PurRetNo";

        }
        public DataTable navigate(DateTime fdt1, DateTime tdt1)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("select top 100 * from PurRetVwFn(" + Common.CId + ",'" + fdt1.ToString("dd/MMM/yyyy") + "','" + tdt1.ToString("dd/MMM/yyyy") + "') where PurRetNo > 0 order by PurRetId desc", Con);
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

            tmp.Add(CommonView.GetGridViewColumn("PurRetId", "PurRetId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("PurRetNo", "PurRetNo", 120, 2, true));
            tmp.Add(CommonView.GetGridViewColumn("PurRetDt", "PurRetDt", 80, 3, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));
            tmp.Add(CommonView.GetGridViewColumn("PtyId", "PtyId", 0, 4));
            tmp.Add(CommonView.GetGridViewColumn("Supplier", "Supplier", 100, 5, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("NetAmt", "NetAmt", 100, 6, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 8));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 9));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        public int Search_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("PurRetId", "PurRetId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("PurRetNo", "PurRetNo", 80, 2, true));
            tmp.Add(CommonView.GetGridViewColumn("PurRetDt", "PurRetDt", 80, 3, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));
            tmp.Add(CommonView.GetGridViewColumn("PurRetInvDt", "PurRetInvDt", 80, 4, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));
            tmp.Add(CommonView.GetGridViewColumn("PurRetInvNo", "PurRetInvNo", 80, 5, true));
            
            tmp.Add(CommonView.GetGridViewColumn("PtyId", "PtyId", 0, 6, true));
            tmp.Add(CommonView.GetGridViewColumn("Supplier", "Supplier", 100, 7, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("TaxId", "TaxId", 0, 8, true));
            tmp.Add(CommonView.GetGridViewColumn("Taxper", "Taxper", 80, 9, true));
            tmp.Add(CommonView.GetGridViewColumn("Taxamt", "Taxamt", 80, 10, true));
           
           
            tmp.Add(CommonView.GetGridViewColumn("Discper", "Disc%", 75, 11, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("DiscAmt", "DiscAmt", 75, 12, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewBoolColumn("Cash", "Cash", 50, 13));
            tmp.Add(CommonView.GetGridViewBoolColumn("OtherState", "OtherState", 50, 14));
            
            tmp.Add(CommonView.GetGridViewColumn("TotAmt", "Total", 75, 15, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("NetAmt", "NetAmt", 75, 16, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
           
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 18, true));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 19));
            tmp.Add(CommonView.GetGridViewColumn("Narr", "Narration", 100, 20, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            //tmp.Add(CommonView.GetGridViewColumn("Username", "UserName", 80, 18, true));
           

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }


        #endregion

        # region "ItemSelect"
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
            tmp.Add(CommonView.GetGridViewColumn("CategoryId", "CategoryId", 0, 2));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 0, 3, false));           
            tmp.Add(CommonView.GetGridViewColumn("ItemCode", "Itemcode", 80, 4, true));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 80, 5, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("LastMrpRate", "Mrp.Rate", 0, 6, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("LastPurRate", "Pur.Rate", 0, 7, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("LastSaleRate", "SaleRate", 0, 8, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("LastBRate", "BRate", 0, 9, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("TaxId", "TaxId", 0, 10));
            tmp.Add(CommonView.GetGridViewColumn("TaxName", "TaxName", 80, 11, true));
            tmp.Add(CommonView.GetGridViewColumn("TaxPer", "TaxPer", 0, 12, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SGSTPer", "SGSTPer", 0, 13, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("CGSTPer", "CGSTPer", 0, 14, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("IGSTPer", "IGSTPer", 0, 15, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewBoolColumn("WtItem", "WtItem", 0, 16));
            tmp.Add(CommonView.GetGridViewBoolColumn("IncPer", "IncPer", 0, 17));
            tmp.Add(CommonView.GetGridViewBoolColumn("IncAmt", "IncAmt", 0, 18));
            tmp.Add(CommonView.GetGridViewColumn("AllowExpiry", "AllowExpiry", 0, 19));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }


        public DataTable ItemCodeSelect_Source(string ItemCode)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_ItemCodeSelect", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;



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

        public int ItemCodeSelect_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("CategoryId", "CategoryId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 0, 2, false));

            tmp.Add(CommonView.GetGridViewColumn("Itemid", "Itemid", 0, 3));
            tmp.Add(CommonView.GetGridViewColumn("ItemCode", "Itemcode", 80, 4, true));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 80, 5, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("LastMrpRate", "Mrp.Rate", 0, 6, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("LastPurRate", "Pur.Rate", 0, 7, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("LastSaleRate", "SaleRate", 0, 8, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("TaxId", "TaxId", 0, 9));
            tmp.Add(CommonView.GetGridViewColumn("TaxName", "TaxName", 80,10, true));
            tmp.Add(CommonView.GetGridViewColumn("TaxPer", "TaxPer", 0, 11, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SGSTPer", "SGSTPer", 0, 12, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("CGSTPer", "CGSTPer", 0, 13, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("IGSTPer", "IGSTPer", 0, 14, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewBoolColumn("WtItem", "WtItem", 0, 15));
            tmp.Add(CommonView.GetGridViewColumn("IncPer", "IncPer", 0, 16));
            tmp.Add(CommonView.GetGridViewColumn("IncAmt", "IncAmt", 0, 17));
            tmp.Add(CommonView.GetGridViewColumn("AllowExpiry", "AllowExpiry", 0,18));
            tmp.Add(CommonView.GetGridViewColumn("DiscPer", "DiscPer", 0, 19));
            tmp.Add(CommonView.GetGridViewColumn("DiscAmt", "DiscAmt", 0, 20));
            tmp.Add(CommonView.GetGridViewColumn("Unit", "Unit", 0,21));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;


            return 0;
        }
        #endregion
        # region "Category"
        public DataTable Category_Source()
        {

            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_Category", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Category";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }


        public int Category_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("CategoryId", "CategoryId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 80, 2, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));

            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 3));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 4));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        #endregion
        public DataTable Print(int Id)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_PurRetHdr", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@PurRetId", SqlDbType.Int);
            MyParam.Value = Id;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "PurRet";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }
        public DataTable PrintPurRetTaxDet_Source(int PurRetId, bool OtherState)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_PurRetTaxdet_GST", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@PurRetId", SqlDbType.Int);
            param.Value = PurRetId;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@OtherState", SqlDbType.Bit);
            param.Value = OtherState;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "Qry_PurRetTaxdet_GST";
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
                        Col.DefaultValue = DateTime.Today;
                        Col.AllowDBNull = true;
                        break;
                }
            }

            return Tbl;
        }
        public Boolean getconfiqtax(int id)
        {
            Boolean Result;
            SqlConnection Con = new SqlConnection(Common.ConStr);
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Config_Qry_GetBitvalue", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@ConfigId", SqlDbType.Int);
            param.Value = id;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Result = Convert.ToBoolean(Cmd.ExecuteScalar());

            Cmd.Dispose();
            Con.Close();
            return Result;
        }

    }
}
