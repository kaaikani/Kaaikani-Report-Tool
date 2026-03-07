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
    public class SalesRetDb
	{
        public SalesRetDb()
		{
			//
			// TODO: Add constructor logic here
			//
		}

# region "Properties"
		int _SalRetId;
		public int SalRetId
		{
			get
			{
				return _SalRetId;
			}
			set
			{
				_SalRetId = value;
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

        short _BookId;
        public short BookId
        {
            get
            {
                return _BookId;
            }
            set
            {
                _BookId = value;
            }
        }

		int _SalRetNo;
		public int SalRetNo
		{
			get
			{
                return _SalRetNo;
			}
			set
			{
                _SalRetNo = value;
			}
		}
        
		DateTime _SalRetDt;
        public DateTime SalRetDt
		{
			get
			{
                return _SalRetDt;
			}
			set
			{
                _SalRetDt = value;
			}
		}

        string _Add1;
        public string Add1
		{
			get
			{
                return _Add1;
			}
			set
			{
                _Add1 = value;
			}
		}

        string _City;
        public string City
        {
            get
            {
                return _City;
            }
            set
            {
                _City = value;
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
        string _Cash;
        public string Cash
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
        

		string _PtyName;
		public string PtyName
		{
			get
			{
				return _PtyName;
			}
			set
			{
				_PtyName = value;
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

		decimal _RndOff;
		public decimal RndOff
		{
			get
			{
				return _RndOff;
			}
			set
			{
				_RndOff = value;
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
        string _BillRefNo;
        public string BillRefNo
		{
			get
			{
                return _BillRefNo;
			}
			set
			{
                _BillRefNo = value;
			}
		}

        int _SalId;
        public int SalId
        {
            get
            {
                return _SalId;
            }
            set
            {
                _SalId = value;
            }
        }

        int _SalBillNo;
        public int SalBillNo
        {
            get
            {
                return _SalBillNo;
            }
            set
            {
                _SalBillNo = value;
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

		DataTable _SalRetDet;
		public DataTable SalRetDet 
		{
			get
			{
                return _SalRetDet;
			}
			set
			{
                _SalRetDet = value;
			}
		}
        DataTable _SalRetPostDet;
        public DataTable SalRetPostDet
        {
            get
            {
                return _SalRetPostDet;
            }
            set
            {
                _SalRetPostDet = value;
            }
        }
        DataTable _SalRetRecDet;
        public DataTable SalRetRecDet
        {
            get
            {
                return _SalRetRecDet;
            }
            set
            {
                _SalRetRecDet = value;
            }
        }
		# endregion

# region "Selection Source"

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
            tmp.Add(CommonView.GetGridViewColumn("Customer", "Customer", 200, 4, true));
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

        public DataTable ItemRateSelect_Source(int ItemId, int PtyId)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            //MyCmd = new SqlCommand("Qry_ItemSalRate", MyCon);
            //MyCmd.CommandType = CommandType.StoredProcedure;

            MyCmd = new SqlCommand("Qry_ItemLastRate", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            //MyParam = new SqlParameter("@CategoryId", SqlDbType.Int);
            //MyParam.Value = CategoryId;
            //MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@ItemId", SqlDbType.Int);
            MyParam.Value = ItemId;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@RateTypeId", SqlDbType.Int);
            MyParam.Value = 0;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@PtyId", SqlDbType.Int);
            MyParam.Value = PtyId;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "SalRate";//"ItemSelect";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }


    
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
        public DataTable TaxSelect_Source(short Taxid, bool OtherState)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_SalRetTaxSelect_GST", MyCon);
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

            DTbl.TableName = "SalRetTaxSelect";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public DataTable PrintSalTaxDet_Source(int SalId)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_SalRetTaxdet", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@SalRetId", SqlDbType.Int);
            param.Value = SalId;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "Qry_SalRetTaxdet";
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
        public DataTable PrintSalRetTaxDet_Source(int SalRetId, bool OtherState)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_SalRetTaxdet_GST", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@SalRetId", SqlDbType.Int);
            param.Value = SalRetId;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@OtherState", SqlDbType.Bit);
            param.Value = OtherState;
            Cmd.Parameters.Add(param);


            //param = new SqlParameter("@Hsnbased", SqlDbType.Bit);
            //param.Value = Hsnbased;
            //Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "Qry_SalRetTaxdet_GST";
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
        //public int Tax_GridStyle(DataGridViewColumnCollection tmp)
        //{
        //    tmp.Clear();

        //    tmp.Add(CommonView.GetGridViewColumn("TaxId", "TaxId", 0, 1));
        //    tmp.Add(CommonView.GetGridViewColumn("AccId", "AccId", 0, 2));
        //    tmp.Add(CommonView.GetGridViewColumn("Accode", "Accode", 0, 3));
        //    tmp.Add(CommonView.GetGridViewColumn("Ledger", "Ledger", 100, 4, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
        //    tmp.Add(CommonView.GetGridViewColumn("TaxPer", "Tax%", 60, 4, true));
        //    tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

        //    return 0;
        //}
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

        public DataTable BillNo_Source(int PtyId, DateTime Dt, short AcYrId, bool Retail, short CAcYrId)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_NonReturnedBills", MyCon);
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

            MyParam = new SqlParameter("@Retail", SqlDbType.Bit);
            MyParam.Value = Retail;
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
            tmp.Add(CommonView.GetGridViewColumn("SalId", "SalId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("BillRefNo", "BillRefNo", 120, 2, true));
            tmp.Add(CommonView.GetGridViewColumn("BillNo", "BillNo", 70, 3, true));
            tmp.Add(CommonView.GetGridViewColumn("BillDt", "BillDt", 80, 4, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));
            tmp.Add(CommonView.GetGridViewColumn("NetAmt", "NetAmt", 80, 5, true, DataGridViewContentAlignment.MiddleRight, "####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("PtyId", "PtyId", 0, 6));
            tmp.Add(CommonView.GetGridViewColumn("AcYrId", "AcYrId", 0, 7));
            
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

        # endregion

        public DataTable LastBillNo_Source()
        {

            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_LastSalRetNoSource", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_LastSalRetNoSource";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();

            return DTbl;

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

# region "Save Function"

        public string  SaveFunction(Saving.SaveType Mode)
        {
            DataTable Tbl = new DataTable();
            DataSet Ds = new DataSet();
            string DetStr;
            Ds.Tables.Add(SalRetDet);
            Ds.Tables.Add(SalRetPostDet);
            Ds.Tables.Add(SalRetRecDet);
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
                Cmd = new SqlCommand("SalRetSP", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@Mode", SqlDbType.TinyInt);
                param.Value = Modeval;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@SalRetId", SqlDbType.Int);
                param.Value = _SalRetId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@SalRetNo", SqlDbType.Int);
                param.Value = _SalRetNo;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@SalRetDt", SqlDbType.DateTime);
                param.Value = _SalRetDt.ToString("dd/MMM/yyyy");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@BookId", SqlDbType.SmallInt);
                param.Value =_BookId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@AcYrId", SqlDbType.SmallInt);
                param.Value = _AcYrId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@PtyId", SqlDbType.SmallInt);
                param.Value = _PtyId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@PtyName", SqlDbType.VarChar, 75);
                param.Value = _PtyName;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Cash", SqlDbType.Char, 2);
                param.Value = _Cash;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@OtherState", SqlDbType.Bit);
                param.Value = (_OtherState == true ? 1 : 0);
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TotAmt", SqlDbType.Decimal);
                param.Value = _Total;
                Cmd.Parameters.Add(param);


                param = new SqlParameter("@TaxAmt", SqlDbType.Decimal);
                param.Value = _TaxAmt;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@RndOff", SqlDbType.Decimal);
                param.Value = _RndOff;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@NetAmt", SqlDbType.Decimal);
                param.Value = _NetAmt;
                Cmd.Parameters.Add(param);

    
                param = new SqlParameter("@UserId", SqlDbType.TinyInt);
                param.Value = Common.UserId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CompId", SqlDbType.TinyInt);
                param.Value = Common.CId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@BillRefNo", SqlDbType.VarChar, 15);
                param.Value = _BillRefNo;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Add1", SqlDbType.VarChar, 75);
                param.Value = _Add1;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Remarks", SqlDbType.VarChar, 50);
                param.Value = _Narration;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TaxId", SqlDbType.SmallInt);
                param.Value = _TaxId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@City", SqlDbType.VarChar, 75);
                param.Value = _City;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TaxPer", SqlDbType.Decimal);
                param.Value = _TaxPer;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DiscAmt", SqlDbType.Decimal);
                param.Value = _DiscAmt;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DiscPer", SqlDbType.Decimal);
                param.Value = _DiscPer;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@SalId", SqlDbType.Int);
                param.Value = _SalId ;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@SalBillNo", SqlDbType.Int);
                param.Value = _SalBillNo;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DetStr", SqlDbType.Text);
                param.Value = DetStr;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Id", SqlDbType.VarChar, 10);
                param.Direction = ParameterDirection.Output;
                Cmd.Parameters.Add(param);


                Cmd.ExecuteNonQuery();
                code = (string)Cmd.Parameters["@Id"].Value;
                return code;
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

        public DataTable SalRetDet_Source(int Id)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_SalRetDet", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@SalRetId", SqlDbType.Int);
            param.Value = Id;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "SalRetDet";
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
        public int SalRetDet_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();

            tmp.Add(CommonView.GetGridViewColumn("SalRetId", "SalRetId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 2));
            tmp.Add(CommonView.GetGridViewColumn("Itemcode", "Code", 70, 3, false, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 80, 4, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("CategoryId", "CategoryId", 0, 5));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 150, 6, true, DataGridViewContentAlignment.MiddleLeft));//,true,DataGridViewContentAlignment.MiddleLeft));     
            
            tmp.Add(CommonView.GetGridViewColumn("BatchNo", "BatchNo", (Common.AllowExpiryDt == true) ? 90 : 0, 7, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewDateColumn("ExpiryDt", "ExpiryDate", (Common.AllowExpiryDt == true) ? 80 : 0, 8, "dd/MM/yyyy", true));

            tmp.Add(CommonView.GetGridViewColumn("Qty", (Common.HeaderName1 == "") ? "Qty" : Common.HeaderName1, 80, 9, false, DataGridViewContentAlignment.MiddleRight, Common.QtyFormat));

            tmp.Add(CommonView.GetGridViewColumn("Wt", (Common.HeaderName2 == "") ? "Wt" : Common.HeaderName2, (Common.WtItem == true) ? 70 : 0, 10, false, DataGridViewContentAlignment.MiddleRight, "#####0.000"));

            tmp.Add(CommonView.GetGridViewColumn("Free", "Free", (Common.AllowSalRetFree == true) ? 70 : 0, 11, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));

            tmp.Add(CommonView.GetGridViewColumn("Rate", "Rate", 60, 12, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));

            tmp.Add(CommonView.GetGridViewColumn("Amount", "Amount", 70, 13, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));

            tmp.Add(CommonView.GetGridViewColumn("DiscPer", "Disc%", (Common.AllowSalRetDisc == true) ? 60 : 0, 14, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("DiscAmt", "DiscAmt", (Common.AllowSalRetDisc == true) ? 90 : 0, 15, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));

            tmp.Add(CommonView.GetGridViewColumn("TaxId", "TaxId", 0, 16, true));

            // tmp.Add(CommonView.GetGridViewColumn("TaxName", "TaxName", 0, 13, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("TaxPer", "Tax%", (Common.AllowTax == true) ? 0 : 0, 17, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("TaxAmt", "TaxAmt", (Common.AllowTax == true) ? 0 : 0, 18, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SGSTPer", "SGST%", (Common.AllowTax == true) ? 70 : 0, 19, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SGSTAmt", "SGSTAmt", (Common.AllowTax == true) ? 70 : 0, 20, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("CGSTPer", "CGST%", (Common.AllowTax == true) ? 70 : 0, 21, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("CGSTAmt", "CGSTAmt", (Common.AllowTax == true) ? 70 : 0, 22, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("IGSTPer", "IGST%", (Common.AllowTax == true) ? 70 : 0, 23, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("IGSTAmt", "IGSTAmt", (Common.AllowTax == true) ? 70 : 0, 24, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewBoolColumn("WtItem", "WtItem", 0, 25, true));

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
            Cmd = new SqlCommand("Qry_SalRetHdr", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@SalRetId", SqlDbType.Int);
            param.Value = Id;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@CompId", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            SqlDataReader rd = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (rd.Read())
            {

                _SalRetId = (int)rd.GetValue(rd.GetOrdinal("SalRetId"));
                _SalRetNo = (int)rd.GetValue(rd.GetOrdinal("SalRetNo"));
                _SalRetDt = (DateTime)rd.GetValue(rd.GetOrdinal("SalRetDt"));
                _PtyId = (int)rd.GetValue(rd.GetOrdinal("PtyId"));
                _PtyName = (string)rd.GetValue(rd.GetOrdinal("Customer"));
                _Cash = (string)rd.GetValue(rd.GetOrdinal("Cash"));
                _OtherState = (bool)rd.GetValue(rd.GetOrdinal("OtherState"));
                _TaxId = (short)rd.GetValue(rd.GetOrdinal("TaxId"));
                _TaxPer = (decimal)rd.GetValue(rd.GetOrdinal("TaxPer"));
                _DiscPer = (decimal)rd.GetValue(rd.GetOrdinal("DiscPer"));
                _DiscAmt = (decimal)rd.GetValue(rd.GetOrdinal("DiscAmt"));
                _Total = (decimal)rd.GetValue(rd.GetOrdinal("TotAmt"));
                _TaxAmt = (decimal)rd.GetValue(rd.GetOrdinal("TaxAmt"));
                _City = (string)rd.GetValue(rd.GetOrdinal("City"));
                _Add1 = (string)rd.GetValue(rd.GetOrdinal("Add1"));
                _RndOff = (decimal)rd.GetValue(rd.GetOrdinal("RndOff"));
                _NetAmt = (decimal)rd.GetValue(rd.GetOrdinal("NetAmt"));
                _BookId = (short)rd.GetValue(rd.GetOrdinal("BookId"));
                //_SalRetInvNo = (string)rd.GetValue(rd.GetOrdinal("SalRetInvNo"));
                _UserId = (byte)rd.GetValue(rd.GetOrdinal("UserId"));
                _Narration = (string)rd.GetValue(rd.GetOrdinal("Narration"));
                _SalId = (int)rd.GetValue(rd.GetOrdinal("SalId"));
                _SalBillNo = (int)rd.GetValue(rd.GetOrdinal("SalBillNo"));
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
        public void SetViewControl()
        {
            _FilteringValues.Clear();

            _View.FilteringValues = _FilteringValues;
            _View.TableNames = "SalRetHdrVwFn(" + Common.CId + ")";
            _View.Fields = "*";
            _View.Conditions = "";
            _View.OrderBy = "SalRetNo";

        }
        public DataTable navigate()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("select top 100 * from SalRetHdrVwFn(" + Common.CId + ") where SalRetNo > 0 order by SalRetId desc", Con);
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

            tmp.Add(CommonView.GetGridViewColumn("SalRetId", "SalRetId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("SalRetNo", "SalRetNo", 120, 2, true));
            tmp.Add(CommonView.GetGridViewColumn("SalRetDt", "SalRetDt", 80, 3, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));
            tmp.Add(CommonView.GetGridViewColumn("PtyId", "PtyId", 0, 4));
            tmp.Add(CommonView.GetGridViewColumn("Customer", "Customer", 100, 5, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("NetAmt", "NetAmt", 100, 6, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
   
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 7));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 8));
            tmp.Add(CommonView.GetGridViewColumn("BillRefNo", "BillRefNo", 70,9, true, DataGridViewContentAlignment.MiddleLeft, ""));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        #endregion
        # region "Book"
        public DataTable Book_Source(int SalId)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_BookSelect", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@SalId", SqlDbType.Int);
            MyParam.Value = SalId;
            MyCmd.Parameters.Add(MyParam);

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
        #endregion
        # region "ItemSelect"
        //public DataTable ItemSelect_Source(int CategoryId, string ItemCode)
        //{
        //    SqlConnection MyCon = new SqlConnection();
        //    SqlCommand MyCmd = new SqlCommand();
        //    SqlParameter MyParam = new SqlParameter();
        //    SqlDataAdapter MyAdapt = new SqlDataAdapter();
        //    DataTable DTbl = new DataTable();

        //    MyCon = new SqlConnection(Common.ConStr);
        //    MyCon.Open();

        //    MyCmd = new SqlCommand("Qry_PurItemSelect", MyCon);
        //    MyCmd.CommandType = CommandType.StoredProcedure;

        //    MyParam = new SqlParameter("@CategoryId", SqlDbType.Int);
        //    MyParam.Value = CategoryId;
        //    MyCmd.Parameters.Add(MyParam);

        //    MyParam = new SqlParameter("@ItemCode", SqlDbType.VarChar, 10);
        //    MyParam.Value = ItemCode;
        //    MyCmd.Parameters.Add(MyParam);

        //    MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
        //    MyParam.Value = Common.CId;
        //    MyCmd.Parameters.Add(MyParam);

        //    MyAdapt.SelectCommand = MyCmd;
        //    MyAdapt.Fill(DTbl);

        //    DTbl.TableName = "PurDet";//"ItemSelect";
        //    MyAdapt.Dispose();
        //    MyCmd.Dispose();
        //    MyCon.Close();
        //    return DTbl;
        //}

        //public int ItemSelect_GridStyle(DataGridViewColumnCollection tmp)
        //{
        //    tmp.Clear();
        //    tmp.Add(CommonView.GetGridViewColumn("CategoryId", "CategoryId", 0, 1));
        //    tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 0, 2, false));

        //    tmp.Add(CommonView.GetGridViewColumn("Itemid", "Itemid", 0, 3));
        //    tmp.Add(CommonView.GetGridViewColumn("ItemCode", "Itemcode", 80, 4, true));
        //    tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 80, 5, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
        //    tmp.Add(CommonView.GetGridViewColumn("LastPurRate", "Pur.Rate", 0, 6, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
        //    tmp.Add(CommonView.GetGridViewColumn("LastSaleRate", "SaleRate", 0, 7, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
        //    tmp.Add(CommonView.GetGridViewColumn("TaxId", "TaxId", 0, 8));
        //    tmp.Add(CommonView.GetGridViewColumn("TaxName", "TaxName", 80, 9, true));
        //    tmp.Add(CommonView.GetGridViewColumn("TaxPer", "TaxPer", 50, 10, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
        //    tmp.Add(CommonView.GetGridViewBoolColumn("WtItem", "WtItem", 0, 11));
        //    tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

        //    return 0;
        //}

        public DataTable ItemSelect_Source(bool Product, int SalId, int AcYrId,int PtyId)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_NonReturnedItems", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Product", SqlDbType.Bit);
            MyParam.Value = 0;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@SalId", SqlDbType.Int);
            MyParam.Value = SalId;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@AcYrId", SqlDbType.Int);
            MyParam.Value = AcYrId;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@PtyId", SqlDbType.Int);
            MyParam.Value = PtyId;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "ItemSelect";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public int ItemSelect_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();        
            tmp.Add(CommonView.GetGridViewColumn("Itemid", "Itemid", 0, 1));
            tmp.Add(CommonView.GetGridViewBoolColumn("Selection", "Selection", 80, 2));
            tmp.Add(CommonView.GetGridViewColumn("ItemCode", "Itemcode", 80, 3, true));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 80, 4, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("CategoryId", "CategoryId", 0, 5));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 0,6, false));
            tmp.Add(CommonView.GetGridViewColumn("Qty", "Qty", 80, 8, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Rate", "Rate", 80, 9, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("DiscPer", "Disc%", 0, 10, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("TaxId", "TaxId", 0,11));
            tmp.Add(CommonView.GetGridViewColumn("TaxName", "TaxName", 0, 12, true));
            tmp.Add(CommonView.GetGridViewColumn("TaxPer", "Tax%", 0, 13, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SGSTPer", "SGST%", 50, 14, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("CGSTPer", "CGST%", 50, 15, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("IGSTPer", "IGST%", 50, 16, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("WtItem", "WtItem", 0, 17, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            //tmp.Add(CommonView.GetGridViewBoolColumn("WtItem", "WtItem", 0, 12));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
           }

        public DataTable OpenItemSelect_Source()
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
            MyParam.Value = 0;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@ItemCode", SqlDbType.VarChar,20);
            MyParam.Value = "";
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "ItemSelect";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }
        public int OpenItemSelect_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("Itemid", "Itemid", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("CategoryId", "CategoryId", 0, 2));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 0, 3, false));           
            tmp.Add(CommonView.GetGridViewColumn("ItemCode", "Itemcode", 0, 4, true));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 80, 5, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("LastMRPRate", "Mrp.Rate", 0, 6, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("LastPurRate", "Pur.Rate", 0, 7, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("LastSaleRate", "SaleRate", 0, 8, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("LastBRate", "BRate", 0, 9, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("TaxId", "TaxId", 0, 10));
            tmp.Add(CommonView.GetGridViewColumn("TaxName", "TaxName", 0, 11));
            tmp.Add(CommonView.GetGridViewColumn("TaxPer", "TaxPer", 0, 12));
            tmp.Add(CommonView.GetGridViewColumn("SGSTPer", "SGST%", 0, 13));
            tmp.Add(CommonView.GetGridViewColumn("CGSTPer", "CGST%", 0, 14));
            tmp.Add(CommonView.GetGridViewColumn("IGSTPer", "IGST%", 0, 15));
            tmp.Add(CommonView.GetGridViewColumn("WtItem", "WtItem", 0, 16));
            tmp.Add(CommonView.GetGridViewColumn("IncPer", "IncPer", 0, 17));
            tmp.Add(CommonView.GetGridViewColumn("IncAmt", "IncAmt", 0, 18));
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
            tmp.Add(CommonView.GetGridViewColumn("LastPurRate", "Pur.Rate", 0, 6, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("LastSaleRate", "SaleRate", 0, 7, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("TaxId", "TaxId", 0, 8));
            tmp.Add(CommonView.GetGridViewColumn("TaxName", "TaxName", 80, 9, true));
            tmp.Add(CommonView.GetGridViewColumn("TaxPer", "TaxPer", 0, 10, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SGSTPer", "SGSTPer", 0, 11, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("CGSTPer", "CGSTPer", 0, 12, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("IGSTPer", "IGSTPer", 0, 13, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewBoolColumn("WtItem", "WtItem", 0, 14));
            tmp.Add(CommonView.GetGridViewColumn("IncPer", "IncPer", 0, 15));
            tmp.Add(CommonView.GetGridViewColumn("IncAmt", "IncAmt", 0, 16));
            tmp.Add(CommonView.GetGridViewColumn("AllowExpiry", "AllowExpiry", 0, 17));
            tmp.Add(CommonView.GetGridViewColumn("DiscPer", "DiscPer", 0, 18));
            tmp.Add(CommonView.GetGridViewColumn("DiscAmt", "DiscAmt", 0, 19));
            tmp.Add(CommonView.GetGridViewColumn("Unit", "Unit", 0, 20));
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

        public DataTable Print(int SalRetId)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_SalRetHdr", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@SalRetId", SqlDbType.Int);
            MyParam.Value = SalRetId;
            MyCmd.Parameters.Add(MyParam);



            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_SalRetHdr";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public DataTable OfferItemSelect_Source(bool Product, int SalId, int AcYrId)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_NonReturnedItemsoffer", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Product", SqlDbType.Bit);
            MyParam.Value = 0;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@SalId", SqlDbType.Int);
            MyParam.Value = SalId;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@AcYrId", SqlDbType.Int);
            MyParam.Value = AcYrId;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "ItemSelect";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public int OfferItemSelect_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            //tmp.Add(CommonView.GetGridViewColumn("SalId", "SalId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 1));
            tmp.Add(CommonView.GetGridViewBoolColumn("Selection", "Selection", 50, 2));
            tmp.Add(CommonView.GetGridViewColumn("Itemcode", "Code", 0, 3, false, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 120, 4, false, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("CategoryId", "CategoryId", 0, 5));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 80, 6));//,true,DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("Qty", "Qty", 60, 7, false, DataGridViewContentAlignment.MiddleRight, "#####0"));
            tmp.Add(CommonView.GetGridViewColumn("Rate", "Rate", 60, 8, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            //tmp.Add(CommonView.GetGridViewColumn("ItemDiscPer", "Disc%", 50, 13, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            //tmp.Add(CommonView.GetGridViewColumn("ItemDiscValue", "DiscAmt", 60, 14, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            //tmp.Add(CommonView.GetGridViewColumn("CashDiscPer", "CashDisc%", 50, 15, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            //tmp.Add(CommonView.GetGridViewColumn("CashDiscValue", "C.D.Amt", 50, 16, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            //tmp.Add(CommonView.GetGridViewColumn("SpDiscValue", "S.D.Amt", 60, 17, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            //tmp.Add(CommonView.GetGridViewColumn("Amount", "Amount", 70, 18, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("TaxId", "TaxId", 0, 9));
            tmp.Add(CommonView.GetGridViewColumn("TaxName", "TaxName", 80, 10, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("TaxPer", "TaxPer", 0, 11));//, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            //tmp.Add(CommonView.GetGridViewColumn("TaxAmt", "TaxAmt", 60, 22, true, DataGridViewContentAlignment.MiddleRight, "####0.00"));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

        public DataTable SalRetFetch_Source(int SalRetNo)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_SalRetNoFetch", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@SalRetNo", SqlDbType.Int);
            param.Value = SalRetNo;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "SalRetNo";
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
                        Col.DefaultValue = false;
                        Col.AllowDBNull = false;
                        break;
                }
            }
            return Tbl;

        }

        #region "TaxDet"
        public DataTable SalTaxDet_Source(int SalId)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_SalRetPostDet", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@SalRetId", SqlDbType.Int);
            param.Value = SalId;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "SalRetPostDet";
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
        public int SalTaxDet_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("SalId", "SalId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("AccId", "AccId", 0, 2));
            tmp.Add(CommonView.GetGridViewColumn("LedgerHeader", "LedgerHeader", 100, 3, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Credit", "Credit", 80, 4, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Debit", "Debit", 80, 5, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Amount", "Amount", 0, 6));
            tmp.Add(CommonView.GetGridViewColumn("AcCode", "AcCode", 0, 7));
            tmp.Add(CommonView.GetGridViewColumn("DrCr", "DrCr", 0, 8));
            tmp.Add(CommonView.GetGridViewColumn("TaxId", "TaxId", 0, 9));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        #endregion

        public DataTable SalRetRecDet_Source(int Id)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_SalRetRecDet", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@SalRetId", SqlDbType.Int);
            param.Value = Id;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "SalRetRecDet";
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
        public int SalRetRecDet_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("SalRetId", "SalRetId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("RefId", "RefId", 0, 2));
            tmp.Add(CommonView.GetGridViewColumn("RefType", "RefType", 0, 3));
            tmp.Add(CommonView.GetGridViewColumn("RefNo", "RefNo", 90, 4, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("RefDate", "RefDate", 100, 5, true, DataGridViewContentAlignment.MiddleRight, "dd/MM/yyyy"));
            tmp.Add(CommonView.GetGridViewColumn("BillAmt", "BillAmt", 100, 6, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Balance", "Balance", 90, 7, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("ReceivedAmt", "ReceivedAmt", 100, 8, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Discount", "Discount", 90, 9, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));

            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 10));
            tmp.Add(CommonView.GetGridViewColumn("AcYrId", "AcYrId", 0, 11));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        public DataTable BillPending_Source(int payID, int AccID, bool Mode)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();


            MyCmd = new SqlCommand("Qry_SalRetPending", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@RecID", SqlDbType.Int);
            MyParam.Value = payID;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@AccID", SqlDbType.Int);
            MyParam.Value = AccID;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Mode", SqlDbType.Bit);
            MyParam.Value = Mode;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@compID", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "SalRetRecDet";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            //return DTbl;
            foreach (DataColumn Col in DTbl.Columns)
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
                }
            }
            return DTbl;
        }
        public int BillPending_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("SalRetId", "SalRetId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("RefId", "RefId", 0, 2));
            tmp.Add(CommonView.GetGridViewColumn("RefType", "RefType", 0, 3));
            tmp.Add(CommonView.GetGridViewColumn("RefNo", "RefNo", 70, 4, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("RefDate", "RefDate", 80, 5, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));
            tmp.Add(CommonView.GetGridViewColumn("BillAmt", "BillAmt", 100, 6, true, DataGridViewContentAlignment.MiddleRight, "#####0.000"));
            tmp.Add(CommonView.GetGridViewColumn("Balance", "Balance", 100, 7, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("ReceivedAmt", "ReceivedAmt", 100, 8, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Discount", "Discount", 100, 9, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 10));
            tmp.Add(CommonView.GetGridViewColumn("AcYrId", "AcYrId", 0, 11));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
    }
}
