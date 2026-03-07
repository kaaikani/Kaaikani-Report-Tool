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
    public class SalesDb
	{


        public SalesDb()
        {
            //
            // TODO: Add constructor logic here
            //
        }

# region "Properties"
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

		int _BillNo;
		public int BillNo
		{
			get
			{
                return _BillNo;
			}
			set
			{
                _BillNo = value;
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
        bool _CustRate;
        public bool CustRate
        {
            get
            {
                return _CustRate;
            }
            set
            {
                _CustRate = value;
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
        string _Add2;
        public string Add2
        {
            get
            {
                return _Add2;
            }
            set
            {
                _Add2 = value;
            }
        }
        string _Add3;
        public string Add3
        {
            get
            {
                return _Add3;
            }
            set
            {
                _Add3 = value;
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

        bool _WtItem;
        public bool WtItem
        {
            get
            {
                return _WtItem;
            }
            set
            {
                _WtItem = value;
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
        decimal _RecAmt;
        public decimal RecAmt
        {
            get
            {
                return _RecAmt;
            }
            set
            {
                _RecAmt = value;
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

        decimal _SalRetAmt;
        public decimal SalRetAmt
        {
            get
            {
                return _SalRetAmt;
            }
            set
            {
                _SalRetAmt = value;
            }
        }

        bool _Est;
        public bool Est
        {
            get
            {
                return _Est;
            }
            set
            {
                _Est = value;
            }
        }

        int _EstId;
        public int EstId
        {
            get
            {
                return _EstId;
            }
            set
            {
                _EstId = value;
            }
        }

        int _SalManId;
        public int SalManId
        {
            get
            {
                return _SalManId;
            }
            set
            {
                _SalManId = value;
            }
        }

        decimal _CustBal;
        public decimal CustBal
        {
            get
            {
                return _CustBal;
            }
            set
            {
                _CustBal = value;
            }
        }

        decimal _AdvAmt;
        public decimal AdvAmt
        {
            get
            {
                return _AdvAmt;
            }
            set
            {
                _AdvAmt = value;
            }
        }

        bool _Imode;
        public bool Imode
        {
            get
            {
                return _Imode;
            }
            set
            {
                _Imode = value;
            }
        }


		DataTable _SalDet;
		public DataTable SalDet 
		{
			get
			{
				return _SalDet;
			}
			set
			{
				_SalDet = value;
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
        DataTable _CustRateDet;
        public DataTable CustRateDet
        {
            get
            {
                return _CustRateDet;
            }
            set
            {
                _CustRateDet = value;
            }
        }


        int _DeliveryPtyId;
        public int DeliveryPtyId
        {
            get
            {
                return _DeliveryPtyId;
            }
            set
            {
                _DeliveryPtyId = value;
            }
        }
		# endregion
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

        public DataTable SerialList_Source(int ItemId)
        {

            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_GetSerialNo", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@ItemId", SqlDbType.Int);
            MyParam.Value = ItemId;
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
        public int SerialListSource_GridStyle(DataGridViewColumnCollection tmp)
        {

            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("SerialNo", "SerialNo", 200, 2, true));
            
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

        public DataTable CodeList_Source()
        {

            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_CodeList", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            //MyParam = new SqlParameter("@itemcode", SqlDbType.VarChar, 20);
            //MyParam.Value = Itemcode;
            //MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Code";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
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
        public DataTable GetLastPurRate_Source(int ItemId,string Barcode)
        {

            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_GetPurRate", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@ItemId", SqlDbType.Int);
            MyParam.Value = ItemId;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Barcode", SqlDbType.VarChar,15);
            MyParam.Value = Barcode;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_remarks";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }
        public DataTable LastBillNo_Source()
        {

            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_LastBillNoSource", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;
        
            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_LastBillNoSource";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();

            return DTbl;

        }
        public DataTable Employee_Source()
        {

            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_Employee", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_Employee";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public int Employee_GridStyle(DataGridViewColumnCollection tmp)
        {

            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("EmpId", "EmpId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Employee", "Employee", 200, 2, true));          
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 3));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 4));


            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

        # region "Selection Source"

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
            tmp.Add(CommonView.GetGridViewColumn("Cell", "Cell", 0, 13));
            tmp.Add(CommonView.GetGridViewColumn("Tin", "Tin", 0, 14));
            tmp.Add(CommonView.GetGridViewColumn("Area", "Area", 0, 15));
            tmp.Add(CommonView.GetGridViewColumn("RateTypeId", "RateTypeId", 0, 16));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

        #region "ItemSource"
        public DataTable ItemSelect_Source(int CategoryId, string ItemCode,bool StkCheck)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_SaleItemSelect", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@CategoryId", SqlDbType.Int);
            MyParam.Value = CategoryId;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@ItemCode", SqlDbType.VarChar, 10);
            MyParam.Value = ItemCode;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@StockCheck", SqlDbType.Bit);
            MyParam.Value = StkCheck;
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
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 100, 3, false));           
            tmp.Add(CommonView.GetGridViewColumn("ItemCode", "Itemcode", 90, 4, true));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 100, 5, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("LastMRPRate", "MRPRate", 0, 6, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("LastPurRate", "Pur.Rate", 0, 7, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("LastSaleRate", "SaleRate", 90, 8, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("TaxId", "TaxId", 0, 9));
            tmp.Add(CommonView.GetGridViewColumn("TaxName", "TaxName", 0, 10, true));
            tmp.Add(CommonView.GetGridViewColumn("TaxPer", "TaxPer", 0, 11, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SGSTPer", "SGSTPer", 0, 12, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("CGSTPer", "CGSTPer", 0, 13, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("IGSTPer", "IGSTPer", 0, 14, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewBoolColumn("WtItem", "WtItem", 0, 15));
            tmp.Add(CommonView.GetGridViewColumn("IncPer", "IncPer", 0, 16, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("IncAmt", "IncAmt", 0, 17, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("AllowExpiry", "AllowExpiry", 0, 18, true, DataGridViewContentAlignment.MiddleRight, ""));
            tmp.Add(CommonView.GetGridViewColumn("DiscPer", "DiscPer", 0, 19, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("DiscAmt", "DiscAmt", 0, 20, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Unit", "Unit", 0, 21));
            tmp.Add(CommonView.GetGridViewColumn("CESSPer", "CESSPer", 0, 22, true));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }


        public DataTable ItemDetail_Source(string ItemCode,DateTime SpDt)
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

        public DataTable ItemCodeSelect_Source(string ItemCode,int SizeId,int RateId)
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

            MyParam = new SqlParameter("@SizeId", SqlDbType.Int);
            MyParam.Value = SizeId;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@RateId", SqlDbType.Int);
            MyParam.Value = RateId;
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
            tmp.Add(CommonView.GetGridViewColumn("LastMRPRate", "MRPRate", 0, 6, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("LastPurRate", "Pur.Rate", 0, 7, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("LastSaleRate", "SaleRate", 75, 8, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("TaxId", "TaxId", 0, 9));
            tmp.Add(CommonView.GetGridViewColumn("TaxName", "TaxName", 80, 10, true));
            tmp.Add(CommonView.GetGridViewColumn("TaxPer", "TaxPer", 0, 11, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SGSTPer", "SGSTPer", 0, 12, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("CGSTPer", "CGSTPer", 0, 13, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("IGSTPer", "IGSTPer", 0, 14, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewBoolColumn("WtItem", "WtItem", 0, 15));
            tmp.Add(CommonView.GetGridViewBoolColumn("IncPer", "IncPer", 0, 16));
            tmp.Add(CommonView.GetGridViewBoolColumn("IncAmt", "IncAmt", 0, 17));
            tmp.Add(CommonView.GetGridViewBoolColumn("DiscPer", "DiscPer", 0, 18));
            tmp.Add(CommonView.GetGridViewBoolColumn("DiscAmt", "DiscAmt", 0, 19));
            tmp.Add(CommonView.GetGridViewColumn("Unit", "Unit", 0, 20));
            tmp.Add(CommonView.GetGridViewColumn("CessPer", "CessPer", 0, 21));
            tmp.Add(CommonView.GetGridViewColumn("NoofQty", "NoofQty", 0, 22));
            tmp.Add(CommonView.GetGridViewColumn("SizeId", "SizeId", 0, 23));
            tmp.Add(CommonView.GetGridViewColumn("SizeName", "SizeName", 0, 24));
            
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        public DataTable ItemRateSelect_Source(int ItemId,int RateTypeId,int PtyId)
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
            MyParam.Value = RateTypeId;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@PtyId", SqlDbType.Int);
            MyParam.Value = PtyId;
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
#endregion

        #region "CustomerRateSelectSource"
        public DataTable CustRateSelect_Source(int PtyId)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_CustRateSelect", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@PtyId", SqlDbType.Int);
            MyParam.Value = PtyId;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "SalDet";//"ItemSelect";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public int CustRateSelect_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("SalId", "SalId", 0, 1));

            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 2));
            tmp.Add(CommonView.GetGridViewColumn("SlNo", "SlNo", 50, 3, false, DataGridViewContentAlignment.MiddleLeft, "####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Itemcode", "ItemCode", 70, 4, false, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 80, 5, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("TamilName", "TamilName", 0, 6, false, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Descript", "Descript", 150, 7, false, DataGridViewContentAlignment.MiddleLeft, ""));

            //tmp.Add(CommonView.GetGridViewColumn("Descript", "SerialNo", 150, 5, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));  //RSPower // 
            tmp.Add(CommonView.GetGridViewColumn("CategoryId", "CategoryId", 0, 8));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 0, 9, true));//,true,DataGridViewContentAlignment.MiddleLeft)); 
            if (Common.configqty == 1)
            {
                tmp.Add(CommonView.GetGridViewColumn("Qty", "Qty", 80, 10, false, DataGridViewContentAlignment.MiddleRight, "#0"));
            }
            else if (Common.configqty == 2)
            {
                tmp.Add(CommonView.GetGridViewColumn("Qty", "Qty", 80, 10, false, DataGridViewContentAlignment.MiddleRight, "#0.00"));
            }
            else
            {
                tmp.Add(CommonView.GetGridViewColumn("Qty", "Qty", 80, 10, false, DataGridViewContentAlignment.MiddleRight, "#0.000"));
            }

            tmp.Add(CommonView.GetGridViewColumn("Free", "Free", 0, 11, false, DataGridViewContentAlignment.MiddleRight, "#####0.000"));
            tmp.Add(CommonView.GetGridViewColumn("RateTypeId", "RateTypeId", 0, 12));
            tmp.Add(CommonView.GetGridViewColumn("RateType", "RateType", 0, 13, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Wt", "Weight", 70, 14, false, DataGridViewContentAlignment.MiddleRight, "#####0.000"));

            tmp.Add(CommonView.GetGridViewColumn("Rate", "Rate", 60, 15, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Amount", "Amount", 70, 16, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("DiscPer", "DiscPer", 60, 17, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("DiscAmt", "DiscAmt", 60, 18, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("TotAmount", "TotAmount", 60, 19, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("TaxId", "TaxId", 0, 20, true));
            tmp.Add(CommonView.GetGridViewColumn("TaxName", "TaxName", 80, 21, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("TaxPer", "TaxPer", 60, 22, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("TaxAmt", "TaxAmt", 60, 23, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));


            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        #endregion

        public DataTable Wtfill_Source()
        {

            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_WtFill", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_WtFill";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
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
                    case "Float":
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
            return DTbl;

        }


        public int Wtfill_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            if (Common.configqty == 1)
            {
                tmp.Add(CommonView.GetGridViewColumn("Qty", "Qty", 60, 1, false, DataGridViewContentAlignment.MiddleRight, "#0"));
            }
            else if (Common.configqty == 2)
            {
                tmp.Add(CommonView.GetGridViewColumn("Qty", "Qty", 60, 1, false, DataGridViewContentAlignment.MiddleRight, "#0.00"));
            }
            else
            {
                tmp.Add(CommonView.GetGridViewColumn("Qty", "Qty", 60, 1, false, DataGridViewContentAlignment.MiddleRight, "#0.000"));
            }
            //tmp.Add(CommonView.GetGridViewColumn("Qty", "Qty", 50, 1, false, DataGridViewContentAlignment.MiddleRight, "#0.000"));
            tmp.Add(CommonView.GetGridViewColumn("Wt", "Wt", 100, 2, false, DataGridViewContentAlignment.MiddleRight, "#0.000"));

            //tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 3));
            //tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 4));

            //tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

        public DataTable Brand_Source()
        {

            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_BrandMaster", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Brand";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }
        public int Brand_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("BrandId", "BrandId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("BrandName", "Brand", 80, 2, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("ARatePer", "ARatePer", 0, 3));
            tmp.Add(CommonView.GetGridViewColumn("BRatePer", "BRatePer", 0, 4));
            tmp.Add(CommonView.GetGridViewColumn("CRatePer", "CRatePer", 0, 5));
            tmp.Add(CommonView.GetGridViewColumn("DRatePer", "DRatePer", 0, 6));
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 7));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 8));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

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
            tmp.Add(CommonView.GetGridViewBoolColumn("NonTax", "NonTax", 0, 5, true));

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
            tmp.Add(CommonView.GetGridViewColumn("SGSTPer", "SGST%", 60, 5, true));
            tmp.Add(CommonView.GetGridViewColumn("CGSTPer", "CGST%", 60, 6, true));
            tmp.Add(CommonView.GetGridViewColumn("IGSTPer", "IGST%", 60, 7, true));
            tmp.Add(CommonView.GetGridViewColumn("CESSPer", "CESS%", 60, 8, true));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        # endregion

        # region "Save Function"

        public string SaveFunction(Saving.SaveType Mode)
        {
            DataTable Tbl = new DataTable();
            DataSet Ds = new DataSet();
            DataSet Ds1 = new DataSet();
            string DetStr;
            string DetStr1;  
            Ds.Tables.Add(SalDet);
            Ds.Tables.Add(SalPostDet);
           
            DetStr = Ds.GetXml();
            DetStr = DetStr.Replace("'", "''");
            DetStr = DetStr.Replace("true", "1");
            DetStr = DetStr.Replace("false", "0");
            if (DetStr.IndexOf("T00:00:00") != -1)
                DetStr = DetStr.Replace(DetStr.Substring(DetStr.IndexOf("T00:00:00"), 15), "");
            Ds.Tables.Clear();
            Ds.Tables.Clear();
            Ds.Dispose();

            if (CustRate==true)
            {
                if (PtyId > 0)
                {
                    CustRateDet.TableName = "SalDet";
                    Ds1.Tables.Add(CustRateDet);
                }
            }

            DetStr1 = Ds1.GetXml();
            DetStr1 = DetStr1.Replace("'", "''");
            DetStr1 = DetStr1.Replace("true", "1");
            DetStr1 = DetStr1.Replace("false", "0");
            if (DetStr1.IndexOf("T00:00:00") != -1)
                DetStr1 = DetStr1.Replace(DetStr1.Substring(DetStr1.IndexOf("T00:00:00"), 15), "");
            Ds1.Tables.Clear();
            Ds1.Tables.Clear();
            Ds1.Dispose();

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
                Cmd = new SqlCommand("SalSP", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@Mode", SqlDbType.TinyInt);
                param.Value = Modeval;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@SalId", SqlDbType.Int);
                param.Value = _SalId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@AcYrId", SqlDbType.SmallInt);
                param.Value = _AcYrId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@BillNo", SqlDbType.Int);
                param.Value = _BillNo;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@BillDt", SqlDbType.DateTime);
                param.Value = _BillDt.ToString("dd/MMM/yyyy"); ;
                Cmd.Parameters.Add(param);


                param = new SqlParameter("@OtherState", SqlDbType.Bit);
                param.Value = (_OtherState == true ? 1 : 0);
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@BookId", SqlDbType.SmallInt);
                param.Value = _BookId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Cash", SqlDbType.Char, 2);
                param.Value = _Cash;
                Cmd.Parameters.Add(param);


                param = new SqlParameter("@BillRefNo", SqlDbType.VarChar , 15);
                param.Value = _BillRefNo.Replace("'", "''"); 
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@PtyId", SqlDbType.SmallInt);
                param.Value = _PtyId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@PtyName", SqlDbType.NVarChar, 75);
                param.Value = _PtyName.Replace("'", "''"); 
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Add1", SqlDbType.NVarChar, 75);
                param.Value = _Add1.Replace("'", "''"); 
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@City", SqlDbType.NVarChar, 75);
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

                param = new SqlParameter("@TaxId", SqlDbType.Decimal);
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

                param = new SqlParameter("@DocCancel", SqlDbType.Bit);
                param.Value = (DocCancel == true ? 1 : 0);
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Charge1", SqlDbType.Decimal);
                param.Value = _Charge1;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Charge2", SqlDbType.Decimal);
                param.Value = _Charge2;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@ReceivedAmt", SqlDbType.Decimal);
                param.Value = _RecAmt;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@SalRetNo", SqlDbType.Int);
                param.Value = _SalRetNo;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@SalRetAmt", SqlDbType.Decimal);
                param.Value = _SalRetAmt;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Est", SqlDbType.Bit);
                param.Value = _Est;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@EstId", SqlDbType.Int);
                param.Value = _EstId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@SalManId", SqlDbType.Int);
                param.Value = _SalManId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CustBal", SqlDbType.Decimal);
                param.Value = _CustBal;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@AdvAmt", SqlDbType.Decimal);
                param.Value = _AdvAmt;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DeliveryPtyId", SqlDbType.Int );
                param.Value = _DeliveryPtyId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Add2", SqlDbType.NVarChar, 50);
                param.Value = _Add2.Replace("'", "''");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DetStr", SqlDbType.Text);
                param.Value = DetStr;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DetStr1", SqlDbType.Text);
                param.Value = DetStr1;
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

        # region "Sales"
        # region "Details"
   
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
        public DataTable CustomerBalance_Source(int PtyId)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_CustBalance", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@PtyId", SqlDbType.Int);
            MyParam.Value = PtyId;
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
        public DataTable Config_PrnModel(int PrnModel)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_Config_PrintModel", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Printermode", SqlDbType.Int);
            MyParam.Value = PrnModel;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_Config_PrintModel";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }
        public int PrnModelDet_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();

            tmp.Add(CommonView.GetGridViewColumn("PrnModelId", "PrnModelId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("PrnModel", "PrnModel", 70, 2, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("ModelCode", "ModelCode", 90, 3, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("PrinterMode", "PrinterMode", 0, 4, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("IsBarcode", "IsBarcode", 0, 5, true, DataGridViewContentAlignment.MiddleLeft));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
            return 0;
        }
        public DataTable Print_Model()
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_PrintModel", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_PrintModel";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }
        public int PrintModel_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();

            tmp.Add(CommonView.GetGridViewColumn("PrnModelId", "PrnModelId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("PrnModel", "PrnModel", 70, 2, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("ModelCode", "ModelCode", 0, 3, true, DataGridViewContentAlignment.MiddleLeft));
           
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
            return 0;
        }




        public DataTable SalDet_Source(int Id)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_SalDet", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@SalId", SqlDbType.Int);
            param.Value = Id;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "SalDet";
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
                        Common.GenConfig = Common.comobj.Config_Source("G");
                        if (Common.AllowExpiryDt == true)
                        {
                            Col.DefaultValue = DateTime.Now.Date.ToString("dd/MMM/yyyy");
                        }
                        else
                        {
                            Col.DefaultValue = "01/jan/1900";
                        }
                        Col.AllowDBNull = true;
                        break;
                    case "Boolean":
                        Col.DefaultValue =false;
                        Col.AllowDBNull = false;
                        break;
                }
            }
            Tbl.Columns["IsreflectStk"].DefaultValue = true;
            return Tbl;

        }




        public DataTable PrintSalDet_Source(int Id)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_SalPrintSalDet", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@SalId", SqlDbType.Int);
            param.Value = Id;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "SalDet";
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
                        Common.GenConfig = Common.comobj.Config_Source("G");
                        if (Common.AllowExpiryDt == true)
                        {
                            Col.DefaultValue = DateTime.Now.Date.ToString("dd/MMM/yyyy");
                        }
                        else
                        {
                            Col.DefaultValue = "01/jan/1900";
                        }
                        Col.AllowDBNull = true;
                        break;
                    case "Boolean":
                        Col.DefaultValue = false;
                        Col.AllowDBNull = false;
                        break;
                }
            }
            Tbl.Columns["IsreflectStk"].DefaultValue = true;
            return Tbl;

        }
        public int SalDet_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            int ColCount;
                  
            tmp.Add(CommonView.GetGridViewColumn("SalId", "SalId", 0, 1));

            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 2));
            tmp.Add(CommonView.GetGridViewColumn("SlNo", "SlNo", 0, 3, false, DataGridViewContentAlignment.MiddleLeft, "####0.00"));

            tmp.Add(CommonView.GetGridViewColumn("Itemcode", "Code", (Common.ShowBrandinSales == false)? 90:0, 4, false, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("Brand", "Brand", (Common.ShowBrandinSales == true) ? 90 : 0, 5, false, DataGridViewContentAlignment.MiddleLeft));//,true,DataGridViewContentAlignment.MiddleLeft)); 
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", (Common.ShowCategoryinSales == true) ? 120 : 0, 6, false, DataGridViewContentAlignment.MiddleLeft));//,true,DataGridViewContentAlignment.MiddleLeft)); 
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 50, 7, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("TamilName", "TamilName", 0, 8, false, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("SerialNo", "SerialNo", (Common.ESales == true) ? 90 : 0, 9, false, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("SizeId", "SizeId", 0, 9, true));
            tmp.Add(CommonView.GetGridViewColumn("SizeName", "Size", (Common.AllowSize == true) ? 90:0, 10, false, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Descript", "Desc", (Common.AllowSalDesc == true) ? 90 : 0, 11, false, DataGridViewContentAlignment.MiddleLeft, ""));  
            tmp.Add(CommonView.GetGridViewColumn("Unit", "Unit", (Common.AllowUnit == true) ? 80 : 0, 12, true, DataGridViewContentAlignment.MiddleLeft, ""));            
            tmp.Add(CommonView.GetGridViewColumn("CategoryId", "CategoryId", 0, 13));            
            tmp.Add(CommonView.GetGridViewColumn("BatchNo", "BatchNo", (Common.AllowExpiryDt == true) ? 90 : 0, 14, false, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewDateColumn("ExpiryDt", "ExpiryDate", (Common.AllowExpiryDt == true) ? 120 : 0, 15, "dd/MM/yyyy", false));
            tmp.Add(CommonView.GetGridViewColumn("Qty", (Common.HeaderName1 == "") ? "Qty" : Common.HeaderName1, 80, 16, false, DataGridViewContentAlignment.MiddleRight, Common.QtyFormat));
            tmp.Add(CommonView.GetGridViewColumn("Free", "Free", (Common.AllowSalFree == true) ? 80 : 0, 17, false, DataGridViewContentAlignment.MiddleRight, "#####0.000"));
            tmp.Add(CommonView.GetGridViewBoolColumn("IsReflectStk", "MillStock", (Common.IsAutoSaleStk == false) ? 75 : 0, 18));
            tmp.Add(CommonView.GetGridViewColumn("RateTypeId", "RateTypeId", 0, 19));
            tmp.Add(CommonView.GetGridViewColumn("RateType", "RateType", 0, 20, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Wt", (Common.HeaderName1 == "") ? "Wt" : Common.HeaderName2, (Common.WtItem == true) ? 70 : 0, 21, false, DataGridViewContentAlignment.MiddleRight, "#####0.000"));

            tmp.Add(CommonView.GetGridViewColumn("MRPRate", "MRP", (Common.AllowMRP == true) ? 90 : 0, 22, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("MrpDiscPer", "Disc%", (Common.ShowBrandinSales == true) ? 90 : 0, 23, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            if (Common.RateLock == false)
            {
                tmp.Add(CommonView.GetGridViewColumn("Rate", "Rate", 90, 24, (Common.RateEnter == true) ? false : true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            }
            else if (Common.RateLock == true)
            {
                tmp.Add(CommonView.GetGridViewColumn("Rate", "Rate", 90, 24, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            }
            tmp.Add(CommonView.GetGridViewColumn("Amount", "Amount", 100, 25, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));

            tmp.Add(CommonView.GetGridViewColumn("DiscPer", "Disc%", (Common.AllowSalDisc == true) ? 60 : 0, 26, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("DiscAmt", "DiscAmt", (Common.AllowSalDisc == true) ? 90 : 0, 27, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));


            tmp.Add(CommonView.GetGridViewColumn("TotAmount", "Total", (Common.AllowTax == true) ? 100 : 0, 28, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));

            tmp.Add(CommonView.GetGridViewColumn("TaxId", "TaxId", 0, 29, true));

            tmp.Add(CommonView.GetGridViewColumn("TaxName", "TaxName", 0, 30, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("TaxPer", "Tax%", (Common.AllowTax == true) ? 80 : 80, 31, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("TaxAmt", "TaxAmt", (Common.AllowTax == true) ? 0 : 0, 32, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SGSTPer", "SGST%", (Common.AllowTax == true) ? 0 : 0, 33, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SGSTAmt", "SGST", (Common.AllowTax == true) ? 70 : 0, 34, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("CGSTPer", "CGST%", (Common.AllowTax == true) ? 0 : 0,35, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("CGSTAmt", "CGST", (Common.AllowTax == true) ? 70 : 0, 36, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("IGSTPer", "IGST%", (Common.AllowTax == true) ? 0 : 0, 37, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("IGSTAmt", "IGST", (Common.AllowTax == true) ? 70 : 0, 38, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));

            tmp.Add(CommonView.GetGridViewColumn("CESSPer", "CESS%", (Common.AllowTax == true) ? 0 : 0, 39, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("CESSAmt", "CESS", (Common.AllowCess == true) ? 70 : 0, 40, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));

            tmp.Add(CommonView.GetGridViewColumn("StkQty", "StkQty", 0, 41, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));

            tmp.Add(CommonView.GetGridViewColumn("IncPer", "IncPer", 0, 42, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("IncAmt", "IncAmt", 0, 43, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("IncTot", "IncTot", 0, 44, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));

            tmp.Add(CommonView.GetGridViewColumn("TotMRP", "TotMRP", 0, 45, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("WtItem", "WtItem", 0, 46, true));
            tmp.Add(CommonView.GetGridViewColumn("PurValue", "PurValue", 0, 47, true));
            tmp.Add(CommonView.GetGridViewColumn("BrandId", "BrandId", 0, 48, true));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
            return 0;
        }
        public int SalWtDet_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            int ColCount;
            string HeaderName1, HeaderName2;
            Common.GenConfig = Common.comobj.Config_Source("G");
            Common.SalConfig = Common.comobj.Config_Source("S");
            if (Common.GenConfig.Rows.Count > 0)
            {
                Common.WtItem = (bool)Common.GenConfig.Rows[0]["WtItem"];
                Common.AllowTax = (bool)Common.GenConfig.Rows[0]["AllowTax"];
                Common.ShowSalMan = (bool)Common.GenConfig.Rows[0]["ShowSalMan"];
                Common.AllowMRP = (bool)Common.GenConfig.Rows[0]["AllowMRP"];
            }
            if (Common.SalConfig.Rows.Count > 0)
            {
                Common.AllowDisc = (bool)Common.SalConfig.Rows[0]["AllowDisc"];
                Common.HeaderName1 = (string)Common.SalConfig.Rows[0]["HeaderName1"];
                Common.HeaderName2 = (string)Common.SalConfig.Rows[0]["HeaderName2"];
                Common.AllowFree = (bool)Common.SalConfig.Rows[0]["AllowFree"];
                Common.RateEnter = (bool)Common.SalConfig.Rows[0]["RateEnter"]; 
            }
            if (Common.HeaderName1 == "")
            { HeaderName1 = "Qty"; }
            else { HeaderName1 = Common.HeaderName1; }
            if (Common.HeaderName2 == "")
            { HeaderName2 = "Weight"; }
            else { HeaderName2 = Common.HeaderName2; }

            tmp.Add(CommonView.GetGridViewColumn("SalId", "SalId", 0, 1));

            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 2));
            tmp.Add(CommonView.GetGridViewColumn("SlNo", "SlNo", 0, 3, false, DataGridViewContentAlignment.MiddleLeft, "####0.00"));

            if (Common.WtItem == true)
            { tmp.Add(CommonView.GetGridViewColumn("Wt", HeaderName2, 70, 4, false, DataGridViewContentAlignment.MiddleRight, "#####0.000")); }
            else { tmp.Add(CommonView.GetGridViewColumn("Wt", HeaderName2, 0, 4, false, DataGridViewContentAlignment.MiddleRight, "#####0.000")); }

            tmp.Add(CommonView.GetGridViewColumn("Itemcode", "Code", 70, 5, false, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 50, 6, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("TamilName", "TamilName", 0, 7, false, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Descript", "Description", 60, 8, false, DataGridViewContentAlignment.MiddleLeft, ""));

            //tmp.Add(CommonView.GetGridViewColumn("Descript", "SerialNo", 150, 5, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));  //RSPower // 
            tmp.Add(CommonView.GetGridViewColumn("CategoryId", "CategoryId", 0, 9));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 0, 10, true));//,true,DataGridViewContentAlignment.MiddleLeft)); 
            if (Common.AllowExpiryDt == true)
            {
                tmp.Add(CommonView.GetGridViewColumn("BatchNo", "BatchNo", 90, 9, false, DataGridViewContentAlignment.MiddleLeft));
                tmp.Add(CommonView.GetGridViewDateColumn("ExpiryDt", "ExpiryDate", 120, 10, "dd/MM/yyyy", true)); 
            }
            else
            {
                tmp.Add(CommonView.GetGridViewColumn("BatchNo", "BatchNo", 0, 9, false, DataGridViewContentAlignment.MiddleLeft));
                tmp.Add(CommonView.GetGridViewDateColumn("ExpiryDt", "ExpiryDate", 0, 10, "dd/MM/yyyy", false)); 
            }
            if (Common.configqty == 1)
            {
                tmp.Add(CommonView.GetGridViewColumn("Qty", HeaderName1, 80, 11, false, DataGridViewContentAlignment.MiddleRight, "#0"));
            }
            else if (Common.configqty == 2)
            {
                tmp.Add(CommonView.GetGridViewColumn("Qty", HeaderName1, 80, 11, false, DataGridViewContentAlignment.MiddleRight, "#0.00"));
            }
            else
            {
                tmp.Add(CommonView.GetGridViewColumn("Qty", HeaderName1, 80, 11, false, DataGridViewContentAlignment.MiddleRight, "#0.000"));
            }
            if (Common.AllowFree == true)
            {
                tmp.Add(CommonView.GetGridViewColumn("Free", "Free", 80, 12, false, DataGridViewContentAlignment.MiddleRight, "#####0.000"));
            }
            else { tmp.Add(CommonView.GetGridViewColumn("Free", "Free", 0, 12, false, DataGridViewContentAlignment.MiddleRight, "#####0.000")); }
            tmp.Add(CommonView.GetGridViewColumn("RateTypeId", "RateTypeId", 0, 13));
            tmp.Add(CommonView.GetGridViewColumn("RateType", "RateType", 0, 14, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));

            if (Common.AllowMRP == true)
            {
                tmp.Add(CommonView.GetGridViewColumn("MRPRate", "MRPRate", 90, 15, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            }
            else { tmp.Add(CommonView.GetGridViewColumn("MRPRate", "MRPRate", 0, 15, true, DataGridViewContentAlignment.MiddleRight, "#####0.00")); }

            if (Common.RateEnter == true)
            { tmp.Add(CommonView.GetGridViewColumn("Rate", "Rate", 90, 16, false, DataGridViewContentAlignment.MiddleRight, "#####0.00")); }
            else { tmp.Add(CommonView.GetGridViewColumn("Rate", "Rate", 90, 16, true, DataGridViewContentAlignment.MiddleRight, "#####0.00")); }
            tmp.Add(CommonView.GetGridViewColumn("Amount", "Amount", 100, 17, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            if (Common.AllowDisc == true)
            {
                tmp.Add(CommonView.GetGridViewColumn("DiscPer", "Disc%", 70, 18, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
                tmp.Add(CommonView.GetGridViewColumn("DiscAmt", "DiscAmt", 80, 19, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            }
            else
            {
                tmp.Add(CommonView.GetGridViewColumn("DiscPer", "Disc%", 0, 18, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
                tmp.Add(CommonView.GetGridViewColumn("DiscAmt", "DiscAmt", 0, 19, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            }
            tmp.Add(CommonView.GetGridViewColumn("TotAmount", "Total", 100, 20, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("TaxId", "TaxId", 0, 21, true));
            if (Common.AllowTax == true)
            {
                tmp.Add(CommonView.GetGridViewColumn("TaxName", "TaxName", 80, 22, true, DataGridViewContentAlignment.MiddleLeft));
                tmp.Add(CommonView.GetGridViewColumn("TaxPer", "Tax%", 60, 23, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
                tmp.Add(CommonView.GetGridViewColumn("TaxAmt", "TaxAmt", 80, 24, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            }
            else
            {
                tmp.Add(CommonView.GetGridViewColumn("TaxName", "TaxName", 0, 22, true, DataGridViewContentAlignment.MiddleLeft));
                tmp.Add(CommonView.GetGridViewColumn("TaxPer", "Tax%", 0, 23, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
                tmp.Add(CommonView.GetGridViewColumn("TaxAmt", "TaxAmt", 0, 24, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            }
            tmp.Add(CommonView.GetGridViewColumn("StkQty", "StkQty", 0, 25, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            if (Common.ShowSalMan == true)
            {
                tmp.Add(CommonView.GetGridViewColumn("IncPer", "IncPer", 0, 26, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
                tmp.Add(CommonView.GetGridViewColumn("IncAmt", "IncAmt", 0, 27, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
                tmp.Add(CommonView.GetGridViewColumn("IncTot", "IncTot", 0, 28, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            }
            else
            {
                tmp.Add(CommonView.GetGridViewColumn("IncPer", "IncPer", 0, 26, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
                tmp.Add(CommonView.GetGridViewColumn("IncAmt", "IncAmt", 0, 27, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
                tmp.Add(CommonView.GetGridViewColumn("IncTot", "IncTot", 0, 28, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            }
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
  

        public DataTable Print(int SalId)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_SalHdr", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@SalId", SqlDbType.Int);
            MyParam.Value = SalId;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_SalHdr";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }
        public DataTable PrintSalDet_Source(int Id,string Query)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_PrintSalDet", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@SalId", SqlDbType.Int);
            param.Value = Id;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Query", SqlDbType.NVarChar );
            param.Value = Query;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "SalDet";
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
                        Common.GenConfig = Common.comobj.Config_Source("G");
                        if (Common.AllowExpiryDt == true)
                        {
                            Col.DefaultValue = DateTime.Now.Date.ToString("dd/MMM/yyyy");
                        }
                        else
                        {
                            Col.DefaultValue = "01/jan/1900";
                        }
                        Col.AllowDBNull = true;
                        break;
                    case "Boolean":
                        Col.DefaultValue = false;
                        Col.AllowDBNull = false;
                        break;
                }
            }
            //Tbl.Columns["IsreflectStk"].DefaultValue = true;
            return Tbl;

        }
        public DataTable EstimateBook()
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_EstimateBook", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;          

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_EstimateBook";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        # endregion
        public DataTable ItemSizeDet_Source(int ItemId,int SizeId)
        {

            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_ItemSizeDet", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@ItemId", SqlDbType.Int);
            MyParam.Value = ItemId;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@SizeId", SqlDbType.Int);
            MyParam.Value = SizeId;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Size";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }
        public int ItemSizeDet_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("SizeId", "SizeId", 0, 2));
            tmp.Add(CommonView.GetGridViewColumn("SizeName", "Size", 80, 3, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Rate", "Rate", 90, 5));
            tmp.Add(CommonView.GetGridViewColumn("OrderNo", "OrderNo", 0, 6));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        public DataTable Size_Source(int sizeId)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_Size", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@SizeId", SqlDbType.SmallInt);
            param.Value =sizeId;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "SizeFill";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();

            return Tbl;

        }
        # region "SalesRet Fetch Selection"
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
        public int SalRetFetch_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("SalRetId", "SalRetId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("SalRetNo", "SalRetNo", 80, 2, true, DataGridViewContentAlignment.MiddleLeft,""));
            tmp.Add(CommonView.GetGridViewColumn("SalRetDt", "SalRetDt", 80, 3, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));           
            tmp.Add(CommonView.GetGridViewColumn("NetAmt", "Amount", 90, 4, true, DataGridViewContentAlignment.MiddleRight, "#####0.000"));         
            
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
  
             # endregion
        # region "Fetch Record"

        public bool FetchRecord(int Id, bool All)
        {
            SqlConnection Con = new SqlConnection(Common.ConStr);
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_SalNewHdr", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@SalId", SqlDbType.Int);
            param.Value = Id;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@All", SqlDbType.Bit);
            param.Value = All;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            SqlDataReader rd = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (rd.Read())
            {

                _SalId = (int)rd.GetValue(rd.GetOrdinal("SalId"));
                _BillNo = (int)rd.GetValue(rd.GetOrdinal("Billno"));
                _BillDt = (DateTime)rd.GetValue(rd.GetOrdinal("BillDt"));
                _BookId = (short)rd.GetValue(rd.GetOrdinal("BookId"));
                _Cash = (string)rd.GetValue(rd.GetOrdinal("Cash"));
              
                _PtyId = (int)rd.GetValue(rd.GetOrdinal("PtyId"));
                _PtyName = (string)rd.GetValue(rd.GetOrdinal("Customer"));
                _Add1 = (string)rd.GetValue(rd.GetOrdinal("Add1"));
                _Add2 = (string)rd.GetValue(rd.GetOrdinal("Add2"));
                _Add3 = (string)rd.GetValue(rd.GetOrdinal("Add3"));
                _City = (string)rd.GetValue(rd.GetOrdinal("City"));
         
                _OtherState = (bool)rd.GetValue(rd.GetOrdinal("OtherState"));
                _DocCancel = (bool)rd.GetValue(rd.GetOrdinal("DocCancel"));
                _TotAmt  = (decimal)rd.GetValue(rd.GetOrdinal("TotAmt"));
                _TaxId = (short)rd.GetValue(rd.GetOrdinal("TaxId"));
                _Taxper = (decimal)rd.GetValue(rd.GetOrdinal("Taxper"));
                _TaxAmt = (decimal)rd.GetValue(rd.GetOrdinal("TaxAmt"));
                _Discper  = (decimal)rd.GetValue(rd.GetOrdinal("Discper"));
               _DiscAmt  = (decimal)rd.GetValue(rd.GetOrdinal("DiscAmt"));
               _Charge1 = (decimal)rd.GetValue(rd.GetOrdinal("Charge1"));
               _Charge2 = (decimal)rd.GetValue(rd.GetOrdinal("Charge2"));
               _RecAmt = (decimal)rd.GetValue(rd.GetOrdinal("ReceivedAmt"));
                _RndOff = (decimal)rd.GetValue(rd.GetOrdinal("RndOff"));
                _NetAmt = (decimal)rd.GetValue(rd.GetOrdinal("NetAmt"));
                _BillRefNo = (string)rd.GetValue(rd.GetOrdinal("BillRefNo"));
                _Remarks = (string)rd.GetValue(rd.GetOrdinal("Remarks"));
                _UserId = (byte)rd.GetValue(rd.GetOrdinal("UserId"));
                _SalRetNo = (int)rd.GetValue(rd.GetOrdinal("SalRetNo"));
                _SalRetAmt = (decimal)rd.GetValue(rd.GetOrdinal("SalRetAmt"));
                _Est = (bool)rd.GetValue(rd.GetOrdinal("Est"));
                _EstId = (int)rd.GetValue(rd.GetOrdinal("EstId"));
                _SalManId = (int)rd.GetValue(rd.GetOrdinal("SalManId"));
                _CustBal = (decimal)rd.GetValue(rd.GetOrdinal("CustBal"));
                _AdvAmt = (decimal)rd.GetValue(rd.GetOrdinal("AdvAmt"));
                _Imode = (bool)rd.GetValue(rd.GetOrdinal("Imode"));

                _DeliveryPtyId = (int)rd.GetValue(rd.GetOrdinal("DeliveryPtyId"));

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
        public void SetViewControl(bool All,DateTime FrmDt, DateTime ToDt)
        {
            _FilteringValues.Clear();

            _View.FilteringValues = _FilteringValues;
            _View.TableNames = "SalHdrNewVwFn('" + All + "','" + FrmDt.ToString("dd/MMM/yyyy") + "','" + ToDt.ToString("dd/MMM/yyyy") + "'," + Common.CId + ")";
            _View.Fields = "*";
            _View.Conditions = "";
            _View.OrderBy = "BillNo";

        }
        public DataTable navigate(bool All,DateTime fdt1, DateTime tdt1)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("select top 100 * from SalHdrNewVwFn('" + All + "','" + fdt1.ToString("dd/MMM/yyyy") + "','" + tdt1.ToString("dd/MMM/yyyy") + "'," + Common.CId + ") where BillNo > 0 order by SalId desc", Con);
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

            tmp.Add(CommonView.GetGridViewColumn("SalId", "SalId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("BillNo", "BillNo", 50, 2, true));
            tmp.Add(CommonView.GetGridViewColumn("BillDt", "BillDt", 70, 3, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));
            //tmp.Add(CommonView.GetGridViewColumn("Book", "Book", 50, 4, true));

            tmp.Add(CommonView.GetGridViewColumn("BillRefNo", "BillRefNo", 70, 4, true));
            tmp.Add(CommonView.GetGridViewColumn("Customer", "Customer", 100, 5, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Add1", "Add1", 100, 6, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("City", "City", 100,7, true, DataGridViewContentAlignment.MiddleLeft, ""));
           
            //tmp.Add(CommonView.GetGridViewColumn("Total", "Total", 75, 8, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            //tmp.Add(CommonView.GetGridViewColumn("PackingCharge", "PackingCharge", 0, 9));
            //tmp.Add(CommonView.GetGridViewColumn("BDiscAmt", "DiscAmt", 60, 10, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            //tmp.Add(CommonView.GetGridViewColumn("RndOff", "RndOff", 60, 11, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("NetAmt", "NetAmt", 75, 8, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
        
            tmp.Add(CommonView.GetGridViewColumn("Remarks", "Remarks", 0,9, true, DataGridViewContentAlignment.MiddleLeft, ""));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

        public int Search_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();

            tmp.Add(CommonView.GetGridViewColumn("SalId", "SalId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("BillNo", "BillNo", 50, 2, true));
            tmp.Add(CommonView.GetGridViewColumn("BillDt", "BillDt", 70, 3, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));
            tmp.Add(CommonView.GetGridViewColumn("BookId", "BookId", 0, 4, true));
            tmp.Add(CommonView.GetGridViewColumn("Cash", "Cash", 70, 5, true));
            tmp.Add(CommonView.GetGridViewColumn("PtyId", "PtyId", 0, 6));
            ;
            tmp.Add(CommonView.GetGridViewColumn("Customer", "Customer", 100, 7, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Add1", "Add1", 100, 8, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("City", "City", 50, 9, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("TIN", "TIN", 70, 10, true));
            tmp.Add(CommonView.GetGridViewBoolColumn("OtherState", "OtherState", 10, 11));

            tmp.Add(CommonView.GetGridViewBoolColumn("DocCancel", "DocCancel", 10, 12));
            tmp.Add(CommonView.GetGridViewColumn("TotAmt", "TotalAmt", 75, 13, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("TaxId", "TaxId", 0, 14, true));
            tmp.Add(CommonView.GetGridViewColumn("TaxName", "TaxName", 50, 15, true));
            tmp.Add(CommonView.GetGridViewColumn("Taxper", "Tax%", 50, 16, true));
            tmp.Add(CommonView.GetGridViewColumn("Taxamt", "TaxAmt", 80, 17, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Discper", "Disc%", 75, 18, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("DiscAmt", "DiscAmt", 75, 19, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));

            
            //tmp.Add(CommonView.GetGridViewColumn("BDiscAmt", "DiscAmt", 60, 10, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("RndOff", "RndOff", 60, 20, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("NetAmt", "NetAmt", 75, 21, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));

            tmp.Add(CommonView.GetGridViewColumn("Remarks", "Remarks", 100, 22, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("BillRefNo", "BillRefNo", 70, 23, true));
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 24, true));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 25));

            tmp.Add(CommonView.GetGridViewColumn("Charge1", "Charge1", 75, 26, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Charge2", "Charge2", 75, 27, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        #endregion
        # endregion

        public DataTable RateType_Source(int ItemId,int RateTypeId)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_SalRateSelect", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@ItemId", SqlDbType.Int);
            param.Value = ItemId;
            Cmd.Parameters.Add(param);


            param = new SqlParameter("@RateTypeId", SqlDbType.Int);
            param.Value = RateTypeId;
            Cmd.Parameters.Add(param);


            param = new SqlParameter("@compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "SalRateSelect";
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
        public int RateType_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear(); tmp.Add(CommonView.GetGridViewColumn("RateTypeId", "RateTypeId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("RateType", "RateType", 150, 2, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Rate", "Rate", 200, 3, false, DataGridViewContentAlignment.MiddleLeft, "#####0.00", DataGridViewAutoSizeColumnMode.Fill));
                    tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }


        public DataTable RateTypeSelect_Source()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_RateType", Con);
            Cmd.CommandType = CommandType.StoredProcedure;


            SqlParameter param = new SqlParameter("@compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "RateSelect";
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
        public int RateTypeSelect_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear(); tmp.Add(CommonView.GetGridViewColumn("RateTypeId", "RateTypeId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("RateType", "RateType", 150, 2, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId",0, 3, false, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 4, false, DataGridViewContentAlignment.MiddleLeft));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

        #region "TaxDet"
        public DataTable SalTaxDet_Source(int SalId)
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
        public int SalTaxDet_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("SalId", "SalId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("AccId", "AccId", 0, 2));
            tmp.Add(CommonView.GetGridViewColumn("LedgerHeader", "LedgerHeader", 100, 3, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Credit", "Credit", 80, 4, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
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
        public DataTable PrintSalTaxDet_Source(int SalId,bool OtherState)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_SalTaxdet_GST", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@SalId", SqlDbType.Int);
            param.Value = SalId;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@OtherState", SqlDbType.Bit);
            param.Value = OtherState;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "Qry_SalTaxdet_GST";
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
        public DataTable TaxCrossPrint(int SalId, bool OtherState)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_SalTaxdet_Cross", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@SalId", SqlDbType.Int);
            MyParam.Value = SalId;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@OtherState", SqlDbType.Bit);
            MyParam.Value = OtherState;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_SalTaxdet_Cross";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }
        public DataTable SalesPrint_Source(int SalId)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;

            Cmd = new SqlCommand("Qry_SalBillPrint", Con);
            Cmd.CommandType = CommandType.StoredProcedure;


            SqlParameter param = new SqlParameter("@SalId", SqlDbType.Int);
            param.Value = SalId;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "Rpt_DataSet_Qry_SalBillPrint";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }
        public DataTable SalesPrint(int Id)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_SalHdr", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@SalId", SqlDbType.Int);
            param.Value = Id;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "SalHdr";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }
        public DataTable SalesPrintDet_Source(int SalId)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;

            Cmd = new SqlCommand("Qry_SalPrintDet", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@SalId", SqlDbType.Int);
            param.Value = SalId;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "Qry_SalDet";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }
        #endregion
        public DataTable SQty(int ItemId)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("qry_ItemStock", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@ItemId", SqlDbType.Int);
            MyParam.Value = ItemId;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "ItemStock";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }
        public DataTable SizeSQty(int ItemId,int SizeId)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("qry_ItemSizeStock", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@ItemId", SqlDbType.Int);
            MyParam.Value = ItemId;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@SizeId", SqlDbType.Int);
            MyParam.Value = SizeId;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "ItemStock";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }
        public DataTable DefaultBook_Source(int BookId)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_BookDet", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@BookId", SqlDbType.Int);
            MyParam.Value = BookId;
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

        #region "Item Pack"

        public DataTable ItemPack_Source()
        {

            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_ItemPackMaster", MyCon);
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


        public int ItemPack_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("ItemPackId", "ItemPackId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("ItemPack", "ItemPack", 120, 2, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("ItemPackCode", "ItemPackCode", 120, 3, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 4));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 5));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        #endregion

        #region "ItemFillSource"
        public DataTable FillItemPackDet_Source(int RateTypeId,int PackId)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_SalItemPackDet", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@RateTypeId", SqlDbType.Int);
            param.Value = RateTypeId;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@ItemPackId", SqlDbType.Int);
            param.Value = PackId;
            Cmd.Parameters.Add(param);


            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "SalDet";
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
                        Col.DefaultValue = DateTime.Now.Date.ToString("dd/MMM/yyyy");
                        Col.AllowDBNull = true;
                        break;
                }
            }
            return Tbl;
        }
        #endregion

        public DataTable QuotHdrFill_Source(int QuotId)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_SalQuotHdrFill", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@SalId", SqlDbType.Int);
            MyParam.Value = QuotId;
            MyCmd.Parameters.Add(MyParam);

            //MyParam = new SqlParameter("@TaxId", SqlDbType.Int);
            //MyParam.Value = TaxId;
            //MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "SalQuotHdrFill";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }
        public int QuotHdrFill_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("QuotId", "QuotId", 0, 1));
            tmp.Add(CommonView.GetGridViewBoolColumn("Selection", "Select", 30, 2,false));
            tmp.Add(CommonView.GetGridViewColumn("QuotNo", "QuotNo", 50, 3, true));
            tmp.Add(CommonView.GetGridViewColumn("QuotDt", "QuotDt", 60, 4, true, DataGridViewContentAlignment.MiddleLeft, "dd/MMM/yyyy"));                                           
            tmp.Add(CommonView.GetGridViewColumn("PtyId", "PtyId", 0, 5));
            tmp.Add(CommonView.GetGridViewColumn("Customer", "Customer", 120, 6, true));
            tmp.Add(CommonView.GetGridViewColumn("Add1", "Address", 80, 7, true));         
            tmp.Add(CommonView.GetGridViewColumn("City", "City", 0, 8, true));
            tmp.Add(CommonView.GetGridViewColumn("Remarks", "Remarks", 0, 9, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("TotAmt", "TotAmt", 0, 10, true, DataGridViewContentAlignment.MiddleRight, "####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("TaxAmt", "TaxAmt", 0, 11, true, DataGridViewContentAlignment.MiddleRight, "####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("RndOff", "RndOff", 0, 12, true, DataGridViewContentAlignment.MiddleRight, "####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("DiscPer", "Disc%", 0, 13, true, DataGridViewContentAlignment.MiddleRight, "####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("DiscAmt", "DiscAmt", 0, 14, true, DataGridViewContentAlignment.MiddleRight, "####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Charge1", "Charge1", 0, 15, true, DataGridViewContentAlignment.MiddleRight, "####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Charge2", "Charge2", 0, 16, true, DataGridViewContentAlignment.MiddleRight, "####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("NetAmt", "NetAmt", 90, 17, true, DataGridViewContentAlignment.MiddleRight, "####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("AdvanceAmt", "AdvanceAmt", 90, 18, true, DataGridViewContentAlignment.MiddleRight, "####0.00"));
          
            //tmp.Add(CommonView.GetGridViewColumn("SGId", "SGId", 0, 21));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        public DataTable QuotDetFill_Source(int QuotId)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_SalQuotDetFill", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@QuotId", SqlDbType.Int);
            MyParam.Value = QuotId;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "SalDet";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            SetDefaults(DTbl);
            return DTbl;
        }
        # region "SetDefaults"
        public void SetDefaults(DataTable Dtbl)
        {
            foreach (DataColumn Col in Dtbl.Columns)
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
                    case "Boolean":
                        Col.DefaultValue = false;
                        Col.AllowDBNull = false;
                        break;
                }
            }
        }
        # endregion
    }
}
