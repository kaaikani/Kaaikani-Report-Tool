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
    public class QuotationDb
	{
        public QuotationDb()
		{
			//
			// TODO: Add constructor logic here
			//
		}

# region "Properties"
        int _QuotId;
        public int QuotId
		{
			get
			{
                return _QuotId;
			}
			set
			{
                _QuotId = value;
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

        int _QuotNo;
        public int QuotNo
		{
			get
			{
                return _QuotNo;
			}
			set
			{
                _QuotNo = value;
			}
		}

        DateTime _QuotDt;
        public DateTime QuotDt
		{
			get
			{
                return _QuotDt;
			}
			set
			{
                _QuotDt = value;
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


        String _TIN;
        public String TIN
		{
			get
			{
                return _TIN;
			}
			set
			{
                _TIN = value;
			}
		}


        String _CST;
        public String CST
        {
            get
            {
                return _CST;
            }
            set
            {
                _CST = value;
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
        decimal _Taxper;
        public decimal Taxper
        {
            get
            {
                return _Taxper;
            }
            set
            {
               _Taxper  = value;
            }
        }
        decimal _Discper;
        public decimal Discper
        {
            get
            {
                return _Discper;
            }
            set
            {
                _Discper = value;
            }
        }

        decimal _AdvanceAmt;
        public decimal AdvanceAmt
        {
            get
            {
                return _AdvanceAmt;
            }
            set
            {
                _AdvanceAmt = value;
            }
        }

        decimal _BalanceAmt;
        public decimal BalanceAmt
        {
            get
            {
                return _BalanceAmt;
            }
            set
            {
                _BalanceAmt = value;
            }
        }
        bool _Dc;
        public bool Dc
        {
            get
            {
                return _Dc;
            }
            set
            {
                _Dc = value;
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
		string _Remarks;
		public string Remarks
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


        decimal _Charge1;
        public decimal Charge1
        {
            get
            {
                return _Charge1;
            }
            set
            {
                _Charge1 = value;
            }
        }

        decimal _Charge2;
        public decimal Charge2
        {
            get
            {
                return _Charge2;
            }
            set
            {
                _Charge2 = value;
            }
        }


        bool _DocCancel;
        public bool DocCancel
        {
            get
            {
                return _DocCancel;
            }
            set
            {
                _DocCancel = value;
            }
        }

        DataTable _QuotDet;
        public DataTable QuotDet
        {
            get
            {
                return _QuotDet;
            }
            set
            {
                _QuotDet = value;
            }
        }
        DataTable _SalPostDet;
        public DataTable SalPostDet
        {
            get
            {
                return _SalPostDet;
            }
            set
            {
                _SalPostDet = value;
            }
        }
		# endregion

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


        public DataTable DescriptList_Source(string Itemcode)
        {

            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_DescriptList", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@itemcode", SqlDbType.VarChar, 20);
            MyParam.Value = Itemcode;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Description";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public DataTable SmsTemplate(int TempId)
        {
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            DataTable DTbl = new DataTable();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_SMSTemplateAll", Con);
            Cmd.CommandType = CommandType.StoredProcedure;


            SqlParameter param = new SqlParameter("@TempId", SqlDbType.Int);
            param.Value = TempId;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(DTbl);
            DTbl.TableName = "SmsTemplate";

            Da.Dispose();
            Cmd.Dispose();
            Con.Close();

            return DTbl;

        }
     
    

        public DataTable remarks_Source()
        {

            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_remarks", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_remarks";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }



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
            tmp.Add(CommonView.GetGridViewColumn("TransPort", "TransPort", 0, 12));


            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

        #region "ItemSource"
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

            MyParam = new SqlParameter("@ItemCode", SqlDbType.VarChar, 10);
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
            tmp.Add(CommonView.GetGridViewColumn("CategoryId", "CategoryId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 100, 2, false));

            tmp.Add(CommonView.GetGridViewColumn("Itemid", "Itemid", 0, 3));
            tmp.Add(CommonView.GetGridViewColumn("ItemCode", "Itemcode", 0, 4, true));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 100, 5, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("LastMRPRate", "MRP.Rate", 0, 6, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("LastPurRate", "Pur.Rate", 0, 7, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("LastSaleRate", "SaleRate", 0, 8, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("TaxId", "TaxId", 0, 9));
            tmp.Add(CommonView.GetGridViewColumn("TaxName", "TaxName", 80,10, true));
            tmp.Add(CommonView.GetGridViewColumn("TaxPer", "TaxPer", 50, 11, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("WtItem", "WtItem", 0, 12));
            tmp.Add(CommonView.GetGridViewColumn("IncPer", "IncPer", 0, 13));
            tmp.Add(CommonView.GetGridViewColumn("IncAmt", "IncAmt", 0, 14));
            tmp.Add(CommonView.GetGridViewColumn("AllowExpiry", "AllowExpiry", 0, 15));
            tmp.Add(CommonView.GetGridViewColumn("SGSTPer", "SGSTPer", 0, 16));
            tmp.Add(CommonView.GetGridViewColumn("CGSTPer", "CGSTPer", 0, 17));
            tmp.Add(CommonView.GetGridViewColumn("IGSTPer", "IGSTPer", 0, 18));
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
            tmp.Add(CommonView.GetGridViewColumn("TaxPer", "TaxPer", 50, 10, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
#endregion

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

            MyCmd = new SqlCommand("Qry_SalTaxSelect_GST", MyCon);
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

            DTbl.TableName = "SalTaxSelect";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public int Tax_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();

            tmp.Add(CommonView.GetGridViewColumn("TaxId", "TaxId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("AccId", "AccId", 0, 2));
            tmp.Add(CommonView.GetGridViewColumn("Accode", "Accode", 0, 3));
            tmp.Add(CommonView.GetGridViewColumn("Ledger", "Ledger", 100, 4, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("TaxPer", "Tax%", 60, 4, true));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        # endregion

        # region "Save Function"

        public string SaveFunction(Saving.SaveType Mode)
        {
            DataTable Tbl = new DataTable();
            DataSet Ds = new DataSet();
            string DetStr;
            Ds.Tables.Add(QuotDet);
           //Ds.Tables.Add(SalPostDet);
            DetStr = Ds.GetXml();
            DetStr = DetStr.Replace("'", "''");
            DetStr = DetStr.Replace("true", "1");
            DetStr = DetStr.Replace("false", "0");
            if (DetStr.IndexOf("T00:00:00") != -1)
                DetStr = DetStr.Replace(DetStr.Substring(DetStr.IndexOf("T00:00:00"), 15), "");
            //Ds.Tables.Clear();
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
                Cmd = new SqlCommand("QuotSP", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@Mode", SqlDbType.TinyInt);
                param.Value = Modeval;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@QuotId", SqlDbType.Int);
                param.Value = _QuotId;
                Cmd.Parameters.Add(param);


                param = new SqlParameter("@QuotNo", SqlDbType.Int);
                param.Value = _QuotNo;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@QuotDt", SqlDbType.DateTime);
                param.Value = _QuotDt.ToString("dd/MMM/yyyy"); ;
                Cmd.Parameters.Add(param);


                param = new SqlParameter("@PtyId", SqlDbType.Int);
                param.Value = _PtyId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@PtyName", SqlDbType.VarChar, 75);
                param.Value = _PtyName.Replace("'", "''"); 
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Add1", SqlDbType.VarChar, 75);
                param.Value = _Add1.Replace("'", "''"); 
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@City", SqlDbType.VarChar, 75);
                param.Value = _City.Replace("'", "''"); 
                Cmd.Parameters.Add(param);


                param = new SqlParameter("@DiscPer", SqlDbType.Decimal);
                param.Value = _Discper ;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DiscAmt", SqlDbType.Decimal);
                param.Value = _DiscAmt;
                Cmd.Parameters.Add(param);            


                param = new SqlParameter("@TotAmt", SqlDbType.Decimal);
                param.Value = _TotAmt;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TaxId", SqlDbType.SmallInt);
                param.Value = _TaxId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Taxper", SqlDbType.Decimal);
                param.Value = _Taxper;
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

                param = new SqlParameter("@Remarks", SqlDbType.VarChar, 150);
                param.Value = _Remarks.Replace("'", "''");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.TinyInt);
                param.Value = Common.UserId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CompId", SqlDbType.TinyInt);
                param.Value = Common.CId;
                Cmd.Parameters.Add(param);

                //param = new SqlParameter("@DocCancel", SqlDbType.Bit);
                //param.Value = (DocCancel == true ? 1 : 0);
                //Cmd.Parameters.Add(param);

                param = new SqlParameter("@Charge1", SqlDbType.Decimal);
                param.Value = _Charge1;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Charge2", SqlDbType.Decimal);
                param.Value = _Charge2;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@AdvanceAmt", SqlDbType.Decimal);
                param.Value = _AdvanceAmt ;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@BalanceAmt", SqlDbType.Decimal);
                param.Value = _BalanceAmt ;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Dc", SqlDbType.Bit);
                param.Value = _Dc;
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


        # region "Quotation"
        # region "Details"

        public Boolean getconfiqtax(int Id)
        {
            Boolean Result;
            SqlConnection Con = new SqlConnection(Common.ConStr);
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Config_Qry_GetBitvalue", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@ConfigId", SqlDbType.Int);
            param.Value = Id;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Result = Convert.ToBoolean(Cmd.ExecuteScalar());

            Cmd.Dispose();
            Con.Close();
            return Result;
        }
        public DataTable QuotDet_Source(int Id)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_QuotDet", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@QuotId", SqlDbType.Int);
            param.Value = Id;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "QuotDet";
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
        public int QuotDet_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            string HeaderName1, HeaderName2;
            tmp.Add(CommonView.GetGridViewColumn("QuotId", "QuotId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Itemcode", "ItemCode", 80, 2, false, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 3));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 120, 4, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));

            tmp.Add(CommonView.GetGridViewColumn("CategoryId", "CategoryId", 0, 5));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 0, 6, true));//,true,DataGridViewContentAlignment.MiddleLeft)); 
            tmp.Add(CommonView.GetGridViewColumn("BatchNo", "BatchNo", (Common.AllowExpiryDt == true) ? 90 : 0, 7, false, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewDateColumn("ExpiryDt", "ExpiryDate", (Common.AllowExpiryDt == true) ? 80 : 0, 8, "dd/MM/yyyy", false));

            tmp.Add(CommonView.GetGridViewColumn("Qty", (Common.HeaderName1 == "") ? "Qty" : Common.HeaderName1, 80, 9, false, DataGridViewContentAlignment.MiddleRight, Common.QtyFormat));

            tmp.Add(CommonView.GetGridViewColumn("Wt", (Common.HeaderName2 == "") ? "Wt" : Common.HeaderName2, (Common.WtItem == true) ? 70 : 0, 10, false, DataGridViewContentAlignment.MiddleRight, "#####0.000"));


            tmp.Add(CommonView.GetGridViewColumn("Free", "Free", (Common.AllowSalFree == true) ? 80 : 0, 11, false, DataGridViewContentAlignment.MiddleRight, "#####0.000"));
            tmp.Add(CommonView.GetGridViewColumn("Rate", "Rate", 60, 12, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Amount", "Amount", 70, 13, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("TaxId", "TaxId", 0, 14, true));

            tmp.Add(CommonView.GetGridViewColumn("TaxName", "TaxName", (Common.AllowTax == true) ? 0 : 0, 15, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("TaxPer", "TaxPer", (Common.AllowTax == true) ? 60 : 0, 16, true, DataGridViewContentAlignment.MiddleRight));
            tmp.Add(CommonView.GetGridViewColumn("TaxAmt", "TaxAmt", (Common.AllowTax == true) ? 0 : 0, 17, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SGSTPer", "SGST%", (Common.AllowTax == true) ? 0 : 0, 18, true, DataGridViewContentAlignment.MiddleRight));
            tmp.Add(CommonView.GetGridViewColumn("SGSTAmt", "SGST", (Common.AllowTax == true) ? 70 : 0, 19, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("CGSTPer", "CGST%", (Common.AllowTax == true) ? 0 : 0,20, true, DataGridViewContentAlignment.MiddleRight));
            tmp.Add(CommonView.GetGridViewColumn("CGSTAmt", "CGST", (Common.AllowTax == true) ? 70 : 0, 21, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("IGSTPer", "IGST%", (Common.AllowTax == true) ? 0 : 0, 22, true, DataGridViewContentAlignment.MiddleRight));
            tmp.Add(CommonView.GetGridViewColumn("IGSTAmt", "IGST", (Common.AllowTax == true) ? 70 : 0, 23, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        public DataTable Print(int QuotId)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_Quothdr", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@QuotId", SqlDbType.Int);
            MyParam.Value = QuotId;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_Quothdr";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        # endregion

        # region "Fetch Record"

        public bool FetchRecord(int Id)
        {
            SqlConnection Con = new SqlConnection(Common.ConStr);
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_QuotHdr", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@QuotId", SqlDbType.Int);
            param.Value = Id;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            SqlDataReader rd = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (rd.Read())
            {

                _QuotId = (int)rd.GetValue(rd.GetOrdinal("QuotId"));
                _QuotNo = (int)rd.GetValue(rd.GetOrdinal("QuotNo"));
                _QuotDt = (DateTime)rd.GetValue(rd.GetOrdinal("QuotDt"));
                //_BookId = (short)rd.GetValue(rd.GetOrdinal("BookId"));
                //_Cash = (string)rd.GetValue(rd.GetOrdinal("Cash"));

                _PtyId = (int)rd.GetValue(rd.GetOrdinal("PtyId"));
                _PtyName = (string)rd.GetValue(rd.GetOrdinal("Customer"));
                _Add1 = (string)rd.GetValue(rd.GetOrdinal("Add1"));
                _City = (string)rd.GetValue(rd.GetOrdinal("City"));
                _TIN = (String)rd.GetValue(rd.GetOrdinal("TIN"));
                //_CST = (String)rd.GetValue(rd.GetOrdinal("CST"));

                //_OtherState = (bool)rd.GetValue(rd.GetOrdinal("OtherState"));
                //_DocCancel = (bool)rd.GetValue(rd.GetOrdinal("DocCancel"));
                _TotAmt = (decimal)rd.GetValue(rd.GetOrdinal("TotAmt"));
                //_TaxId = (short)rd.GetValue(rd.GetOrdinal("TaxId"));
                //_Taxper = (decimal)rd.GetValue(rd.GetOrdinal("Taxper"));
                _TaxAmt = (decimal)rd.GetValue(rd.GetOrdinal("TaxAmt"));
                _Discper = (decimal)rd.GetValue(rd.GetOrdinal("Discper"));
                _DiscAmt = (decimal)rd.GetValue(rd.GetOrdinal("DiscAmt"));
             

                _RndOff = (decimal)rd.GetValue(rd.GetOrdinal("RndOff"));
                _NetAmt = (decimal)rd.GetValue(rd.GetOrdinal("NetAmt"));
                
                _Remarks = (string)rd.GetValue(rd.GetOrdinal("Remarks"));
                _UserId = (byte)rd.GetValue(rd.GetOrdinal("UserId"));
                _CompId = (byte)rd.GetValue(rd.GetOrdinal("CompId"));
                _Charge1 = (decimal)rd.GetValue(rd.GetOrdinal("Charge1"));
                _Charge2 = (decimal)rd.GetValue(rd.GetOrdinal("Charge2"));
                _AdvanceAmt = (decimal)rd.GetValue(rd.GetOrdinal("AdvanceAmt"));
                _BalanceAmt = (decimal)rd.GetValue(rd.GetOrdinal("BalanceAmt"));
                _Dc = (bool)rd.GetValue(rd.GetOrdinal("Dc"));


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
            _View.TableNames = "QuothdrvwFn('" + FrmDt.ToString("dd/MMM/yyyy") + "','" + ToDt.ToString("dd/MMM/yyyy") + "'," + Common.CId + ")";
       
            _View.Fields = "*";
            _View.Conditions = "";
            _View.OrderBy = "QuotNo";

        }
        public DataTable navigate(DateTime fdt1, DateTime tdt1)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("select top 100 * from QuothdrvwFn('" + fdt1.ToString("dd/MMM/yyyy") + "','" + tdt1.ToString("dd/MMM/yyyy") + "'," + Common.CId + ") where QuotNo > 0 order by QuotNo desc", Con);
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

            tmp.Add(CommonView.GetGridViewColumn("QuotId", "QuotId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("QuotNo", "QuotNo", 50, 2, true));
            tmp.Add(CommonView.GetGridViewColumn("QuotDt", "QuotDt", 50, 3, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));
            //tmp.Add(CommonView.GetGridViewColumn("Book", "Book", 50, 4, true));
            tmp.Add(CommonView.GetGridViewColumn("PtyId", "PtyId", 0, 4));
            //tmp.Add(CommonView.GetGridViewColumn("BillRefNo", "BillRefNo", 70, 4, true));
            tmp.Add(CommonView.GetGridViewColumn("Customer", "Customer", 150, 5, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Add1", "Add1", 80, 6, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("City", "City", 80,7, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("TotAmt", "TotalAmt", 80, 8, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Taxamt", "TaxAmt", 80, 9, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Discper", "Disc%", 0, 10, true, DataGridViewContentAlignment.MiddleRight));
            tmp.Add(CommonView.GetGridViewColumn("DiscAmt", "DiscAmt", 0, 11, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));

            tmp.Add(CommonView.GetGridViewColumn("RndOff", "RndOff", 0, 12, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
                       tmp.Add(CommonView.GetGridViewColumn("NetAmt", "NetAmt", 80, 13, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
              
            tmp.Add(CommonView.GetGridViewColumn("Remarks", "Remarks", 0,14, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 15, true));
            tmp.Add(CommonView.GetGridViewColumn("UserName", "UserName", 0, 16, true));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 17));

            tmp.Add(CommonView.GetGridViewColumn("Add2", "Add2", 0, 18, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Add3", "Add3", 0, 19, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("TIN", "TIN", 0, 20, true));
            tmp.Add(CommonView.GetGridViewColumn("CST", "CST", 0, 21, true));
            tmp.Add(CommonView.GetGridViewColumn("Charge1", "Charge1", 0, 22, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Charge2", "Charge2", 0, 23, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

        public int Search_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();

            tmp.Add(CommonView.GetGridViewColumn("QuotId", "QuotId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("QuotNo", "QuotNo", 50, 2, true));
            tmp.Add(CommonView.GetGridViewColumn("QuotDt", "QuotDt", 70, 3, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));
                    tmp.Add(CommonView.GetGridViewColumn("PtyId", "PtyId", 0, 4));
            tmp.Add(CommonView.GetGridViewColumn("Customer", "Customer", 100, 5, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("Add1", "Add1", 100, 6, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("City", "City", 50, 7, true, DataGridViewContentAlignment.MiddleLeft));
                   tmp.Add(CommonView.GetGridViewColumn("TotAmt", "TotalAmt", 75, 8, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
                  tmp.Add(CommonView.GetGridViewColumn("Taxamt", "TaxAmt", 80, 9, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
             tmp.Add(CommonView.GetGridViewColumn("Discper", "Disc%", 75, 10, true, DataGridViewContentAlignment.MiddleRight));
             tmp.Add(CommonView.GetGridViewColumn("DiscAmt", "DiscAmt", 75, 11, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));

            
            //tmp.Add(CommonView.GetGridViewColumn("BDiscAmt", "DiscAmt", 60, 10, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
             tmp.Add(CommonView.GetGridViewColumn("RndOff", "RndOff", 60, 12, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("NetAmt", "NetAmt", 75, 13, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Remarks", "Remarks", 0, 14, true, DataGridViewContentAlignment.MiddleLeft, ""));
                  tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 15, true));
                  tmp.Add(CommonView.GetGridViewColumn("UserName", "UserName", 0, 16, true));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 17));
            tmp.Add(CommonView.GetGridViewColumn("Add2", "Add2", 0, 18, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Add3", "Add3", 0, 19, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("TIN", "TIN", 0, 20, true));
            tmp.Add(CommonView.GetGridViewColumn("CST", "CST", 0, 21, true));
            tmp.Add(CommonView.GetGridViewColumn("Charge1", "Charge1", 75, 22, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Charge2", "Charge2", 75, 23, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        #endregion
        # endregion

        #region "TaxDet"
        public DataTable QuotTaxDet_Source(int SalId)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_SalPostDet", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@SalId", SqlDbType.Int);
            param.Value = SalId;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "SalPostDet";
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
        public int QuotTaxDet_GridStyle(DataGridViewColumnCollection tmp)
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

        #region "Print"
        public DataTable PrintSalTaxDet_Source(int QuotId)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_QuotTaxdet", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@QuotId", SqlDbType.Int);
            param.Value = QuotId;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "Qry_QuotTaxdet";
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
        public DataTable QuotPrint_Source(int SalId)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;

            Cmd = new SqlCommand("Qry_QuotBillPrint", Con);
            Cmd.CommandType = CommandType.StoredProcedure;


            SqlParameter param = new SqlParameter("@QuotId", SqlDbType.Int);
            param.Value = SalId;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "Rpt_DataSet_Qry_QuotBillPrint";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }
        public DataTable QuotPrint(int Id)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_QuotHdr", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@QuotId", SqlDbType.Int);
            param.Value = Id;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "QuotHdr";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }
        public DataTable PrintQuotTaxDet_Source(int QuotId, bool OtherState)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_QuotTaxdet_GST", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@QuotId", SqlDbType.Int);
            param.Value = QuotId;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@OtherState", SqlDbType.Bit);
            param.Value = OtherState;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "Qry_QuotTaxdet_GST";
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
        #endregion
        public DataTable Config_Source(string FormType, int ConfigId)
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
    }
}
