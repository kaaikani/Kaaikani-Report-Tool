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
	/// Summary description for StkAdjDB.
	/// </summary>
	/// 
	public class PurchaseDB
	{
    		public PurchaseDB()
		{
			//
			// TODO: Add constructor logic here
			//
          
		}



#region "Properties"
       
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

        int _PurNo;
        public int PurNo 
		{
			get
			{
                return _PurNo;
			}
			set
			{
                _PurNo = value;
			}
		}

        DateTime _PurDt;
        public DateTime PurDt
        {
            get
            {
                return _PurDt;
            }
            set
            {
                _PurDt = value;
            }
        }

		string _InvNo;
        public string InvNo 
		{
			get
			{
				return _InvNo;
			}
			set
			{
				_InvNo = value;
			}
		}

		DateTime _InvDt;
		public DateTime InvDt 
		{
			get
			{
				return _InvDt;
			}
			set
			{
				_InvDt = value;
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

      string _Narr;
        public string Narr
        {
            get
            {
                return _Narr;
            }
            set
            {
                _Narr = value;
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

        short _TaxId;
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
        decimal _Taxper;
        public decimal Taxper
        {
            get
            {
                return _Taxper;
            }
            set
            {
                _Taxper = value;
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

        string _UserName;
        public string UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                _UserName = value;
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

        DataTable _PurPostDet;
        public DataTable PurPostDet
		{
			get
			{
                return _PurPostDet;
			}
			set
			{
                _PurPostDet = value;
			}
		}
       
		DataTable _PurDet;
		public DataTable PurDet 
		{
			get
			{
				return _PurDet;
			}
			set
			{
				_PurDet = value;
			}
		}

#endregion
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

        public DataTable LastPurNo_Source()
        {

            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_LastPurNoSource", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_LastPurNoSource";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();

            return DTbl;

        }
		
# region "Selection Source"

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

        # region "ItemSource"

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

            MyParam = new SqlParameter("@ItemCode", SqlDbType.VarChar,20);
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
            
            tmp.Add(CommonView.GetGridViewColumn("Itemid", "Itemid", 0,1));
            tmp.Add(CommonView.GetGridViewColumn("ItemCode", "Itemcode", 80, 2, true));
            tmp.Add(CommonView.GetGridViewColumn("BrandId", "BrandId", 0, 3));
            tmp.Add(CommonView.GetGridViewColumn("Brand", "Brand", 90, 4, false));
            tmp.Add(CommonView.GetGridViewColumn("CategoryId", "CategoryId", 0, 5));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 0, 6, false ));
  
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 80, 7, false , DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("LastMRPRate", "MRPRate", 0, 8, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("LastPurRate", "Pur.Rate", 0, 9, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("LastSaleRate", "SaleRate", 0,10, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("LastBRate", "BRate", 0, 11, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("TaxId", "TaxId", 0, 12));
            tmp.Add(CommonView.GetGridViewColumn("TaxName", "TaxName", 80,13, true));
            tmp.Add(CommonView.GetGridViewColumn("TaxPer", "TaxPer", 0,14, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SGSTPer", "SGST", 0, 15, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("CGSTPer", "CGST%", 0, 16, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("CESSPer", "CESS%", 0, 17, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("IGSTPer", "IGST%", 0, 18, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewBoolColumn("WtItem", "WtItem", 0, 19));
            tmp.Add(CommonView.GetGridViewColumn("IncPer", "IncPer", 0, 20));
            tmp.Add(CommonView.GetGridViewColumn("IncAmt", "IncAmt", 0, 21));
            tmp.Add(CommonView.GetGridViewColumn("AllowExpiry", "AllowExpiry", 0, 22));
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
            tmp.Add(CommonView.GetGridViewBoolColumn("WtItem", "WtItem", 0, 11));
            tmp.Add(CommonView.GetGridViewColumn("IncPer", "IncPer", 0, 12));
            tmp.Add(CommonView.GetGridViewColumn("IncAmt", "IncAmt", 0, 13));
            tmp.Add(CommonView.GetGridViewColumn("DiscPer", "DiscPer", 0, 14));
            tmp.Add(CommonView.GetGridViewColumn("DiscAmt", "DiscAmt", 0, 15));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
#endregion
        #region "Tax"
        public DataTable TaxUpDate_Source(short Taxid, bool OtherState)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_PurTaxSelect_GST", MyCon);
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

            DTbl.TableName = "PurTaxSelect";
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
        public int TaxSelect_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();

            tmp.Add(CommonView.GetGridViewColumn("TaxId", "TaxId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("TaxName", "TaxName", 0, 2));
            tmp.Add(CommonView.GetGridViewColumn("TaxPer", "Tax%", 80, 3));
            tmp.Add(CommonView.GetGridViewColumn("CGSTPer", "CGST%", 80, 4));
            tmp.Add(CommonView.GetGridViewColumn("SGSTPer", "SGST%", 80, 5));
            tmp.Add(CommonView.GetGridViewColumn("IGSTPer", "IGST%", 80, 6));
            tmp.Add(CommonView.GetGridViewColumn("CESSPer", "CESS%", 0, 7));
            tmp.Add(CommonView.GetGridViewColumn("VAT", "VAT", 0, 8));
            tmp.Add(CommonView.GetGridViewColumn("CommCode", "CommCode", 0, 9));
            tmp.Add(CommonView.GetGridViewColumn("GstImplemented", "GstImplemented", 0, 10));           

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

        public int Tax_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();

            tmp.Add(CommonView.GetGridViewColumn("TaxId", "TaxId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("AccId", "AccId", 0, 2));
            tmp.Add(CommonView.GetGridViewColumn("Accode", "Accode", 0, 3));
            tmp.Add(CommonView.GetGridViewColumn("Ledger", "Ledger", 100, 4, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

        #endregion

        public DataTable ItemSizeDet_Source(int ItemId)
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
            tmp.Add(CommonView.GetGridViewColumn("OrderNo", "OrderNo", 0, 5));

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
               
# endregion



# region "Details"
        public DataTable PurDet_Source(int Id)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_PurDet", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@PurId", SqlDbType.Int);
            param.Value = Id;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "PurDet";
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
                }
            }
            return Tbl;

        }
        public int PurDet_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            
            tmp.Add(CommonView.GetGridViewColumn("PurId", "PurId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Itemcode", "Code", 70, 2, false, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("Brand", "Brand",  (Common.AllowBrand == true)?140:0, 3, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("CategoryId", "CategoryId", 0, 4));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category",(Common.AllowCategory == true)? 140:0, 5, false, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 6));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 70, 7, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("SerialNo", "SerialNo", (Common.ESales == true) ? 90 : 0, 8, false, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("SizeId", "SizeId", 0, 8));
            tmp.Add(CommonView.GetGridViewColumn("SizeName", "Size", (Common.AllowSize == true) ? 90 : 0, 9, false, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Description", "Cost", (Common.AllowPurDesc == true)?120:0, 10, false, DataGridViewContentAlignment.MiddleLeft, ""));
                     
            tmp.Add(CommonView.GetGridViewColumn("BatchNo", "BatchNo", (Common.AllowExpiryDt == true) ? 90 : 0, 11, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewDateColumn("ExpiryDt", "ExpiryDate", (Common.AllowExpiryDt == true) ? 80 : 0, 12, "dd/MM/yyyy", true));

            tmp.Add(CommonView.GetGridViewColumn("Qty", Common.HeaderName1 == "" ? "Qty" : Common.HeaderName1, 60, 13, false, DataGridViewContentAlignment.MiddleRight, Common.QtyFormat));

            tmp.Add(CommonView.GetGridViewColumn("Free", "Free", (Common.AllowPurFree == true) ? 70 : 0, 14, false, DataGridViewContentAlignment.MiddleRight, "#####0.000"));

            tmp.Add(CommonView.GetGridViewColumn("Wt", (Common.HeaderName2 == "") ? "Wgt" : Common.HeaderName2, (Common.WtItem == true) ? 70 : 0, 15, false, DataGridViewContentAlignment.MiddleRight, "#####0.000"));
            
            tmp.Add(CommonView.GetGridViewColumn("MRPRate", "MRPRate", (Common.AllowMRP == true) ? 80 : 0, 17, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("PurRate", "Pur.Rate", 70, 18, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("salemuper", "Margin%", 70, 19, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SaleRate", "SaleRate", 70, 20, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));

            tmp.Add(CommonView.GetGridViewColumn("BRate", "BRate", (Common.MultiSRate == true) ? 70 : 0, 20, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));

            tmp.Add(CommonView.GetGridViewColumn("Amount", "Amount", 70, 21, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));

            tmp.Add(CommonView.GetGridViewColumn("DiscPer", "Disc%", (Common.AllowPurDisc == true) ? 60 : 0, 22, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("DiscAmt", "DiscAmt", (Common.AllowPurDisc == true) ? 70 : 0, 23, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("TaxId", "TaxId", 0, 24, true));

            tmp.Add(CommonView.GetGridViewColumn("TaxName", "TaxName", 0, 25, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("TaxPer", "Tax%",  70 , 26, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("TaxAmt", "TaxAmt", (Common.AllowTax == true) ? 0 : 0, 27, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SGSTPer", "SGST%", (Common.AllowTax == true) ? 0 : 0, 28, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SGSTAmt", "SGST", (Common.AllowTax == true) ? 70 : 0, 29, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("CGSTPer", "CGST%", (Common.AllowTax == true) ? 0 : 0,30 , true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("CGSTAmt", "CGST", (Common.AllowTax == true) ? 70 : 0, 31, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("CESSPer", "CESS%", (Common.AllowTax == true) ? 0 : 0, 32, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("CESSAmt", "CESS", (Common.AllowTax == true) ? 0 : 0, 33, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("IGSTPer", "IGST%", (Common.AllowTax == true) ? 0 : 0, 34, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("IGSTAmt", "IGST", (Common.AllowTax == true) ? 70 : 0, 35, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));           
            tmp.Add(CommonView.GetGridViewColumn("SlNo", "SlNo", 0, 36, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("WtItem", "WtItem", 0, 37, true));
            tmp.Add(CommonView.GetGridViewColumn("Barcode", "Barcode", 0, 38, true));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

        public int GetItemtTagRate_Source(int Itemid, decimal SalesRate, int SizeId, DateTime PurDt)
        {
            int codes;
            try
            {
                SqlConnection MyCon = new SqlConnection();
                SqlCommand MyCmd = new SqlCommand();
                SqlParameter MyParam = new SqlParameter();
                SqlDataAdapter MyAdapt = new SqlDataAdapter();
                DataTable DTbl = new DataTable();

                MyCon = new SqlConnection(Common.ConStr);
                MyCon.Open();

                MyCmd = new SqlCommand("GetitemTagRateIDsp", MyCon);
                MyCmd.CommandType = CommandType.StoredProcedure;

                MyParam = new SqlParameter("@Itemid", SqlDbType.Int);
                MyParam.Value = Itemid;
                MyCmd.Parameters.Add(MyParam);

                MyParam = new SqlParameter("@Rate", SqlDbType.Decimal);
                MyParam.Value = SalesRate;
                MyCmd.Parameters.Add(MyParam);

                MyParam = new SqlParameter("@SizeId", SqlDbType.Int);
                MyParam.Value = SizeId;
                MyCmd.Parameters.Add(MyParam);

                MyParam = new SqlParameter("@PurDt", SqlDbType.DateTime);
                MyParam.Value = PurDt.ToString("dd/MMM/yyyy");
                MyCmd.Parameters.Add(MyParam);

                MyParam = new SqlParameter("@Rateid", SqlDbType.Int);
                MyParam.Direction = ParameterDirection.Output;
                MyCmd.Parameters.Add(MyParam);

                MyCmd.ExecuteNonQuery();
                codes = (int)MyCmd.Parameters["@Rateid"].Value;
                return codes;
                MyCmd.Dispose();
                MyCon.Close();

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
        public DataTable PrintPurTaxDet_Source(int PurId)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_PurTaxdet", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@PurId", SqlDbType.Int);
            param.Value = PurId;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "Qry_PurTaxdet";
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
        public DataTable PurTaxDet_Source(int PurId)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_PurPostDet", Con);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("@PurId", SqlDbType.Int);
            param.Value = PurId;
            Cmd.Parameters.Add(param);
            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);
            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "PurPostDet";
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
       
        # endregion   
 
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

        public DataTable Print(int PurId)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_PurHdr", Con);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("@PurId", SqlDbType.Int);
            param.Value = PurId;
            Cmd.Parameters.Add(param);
            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);
            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "Qry_PurHdr";
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

# region "Save"
        public string SaveFunction(Saving.SaveType Mode)
        {
            DataTable Tbl = new DataTable();
            DataSet Ds = new DataSet();
            string DetStr;
            Ds.Tables.Add(PurDet);
            Ds.Tables.Add(PurPostDet);
            DetStr = Ds.GetXml();
            DetStr = DetStr.Replace("'", "''");
            DetStr = DetStr.Replace("true", "1");
            DetStr = DetStr.Replace("false", "0");
            if (DetStr.IndexOf("T00:00:00") != -1)
                DetStr = DetStr.Replace(DetStr.Substring(DetStr.IndexOf("T00:00:00"), 15), "");
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
                Cmd = new SqlCommand("PurSP", Con);
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@Mode", SqlDbType.TinyInt);
                param.Value = Modeval;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@PurId", SqlDbType.Int);
                param.Value = _PurId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@AcYrId", SqlDbType.SmallInt);
                param.Value = _AcYrId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@PurNo", SqlDbType.Int);
                param.Value = _PurNo;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@PurDt", SqlDbType.DateTime);
                param.Value = _PurDt.ToString("dd/MMM/yyyy");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@InvNo", SqlDbType.VarChar,25);
                param.Value = _InvNo.Replace("'", "''"); 
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@InvDt", SqlDbType.DateTime);
                param.Value = _InvDt.ToString("dd/MMM/yyyy");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@PtyId", SqlDbType.Int);
                param.Value = _PtyId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@OtherState", SqlDbType.Bit);
                param.Value = (_OtherState == true ? 1 : 0);
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Cash", SqlDbType.Bit);
                param.Value = (_Cash == true ? 1 : 0);
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Narr", SqlDbType.VarChar);
                param.Value = _Narr.Replace("'", "''"); 
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Discper", SqlDbType.Decimal);
                param.Value = _Discper;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DiscAmt", SqlDbType.Decimal);
                param.Value = _DiscAmt;
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

                param = new SqlParameter("@TotAmt", SqlDbType.Decimal);
                param.Value = _TotAmt;
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

                param = new SqlParameter("@Est", SqlDbType.Bit);
                param.Value = _Est;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@EstId", SqlDbType.Int);
                param.Value = _EstId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Remarks", SqlDbType.VarChar,50);
                param.Value = _Remarks;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CSTTaxId", SqlDbType.Int);
                param.Value = _CSTTaxId;
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

# region "Show"
        public bool FetchRecord(int Id,bool All)
        {
            SqlConnection Con = new SqlConnection(Common.ConStr);
            Con.Open();

            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_PurNewHdr", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@PurId", SqlDbType.Int);
            param.Value = Id;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@All", SqlDbType.Bit);
            param.Value =All;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@CompId", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            SqlDataReader rd = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (rd.Read())
            {

                _PurId = (int)rd.GetValue(rd.GetOrdinal("PurId"));
                //_AcYrId = (short)rd.GetValue(rd.GetOrdinal("AcYrId"));
                _PurNo = (int)rd.GetValue(rd.GetOrdinal("PurNo"));
                _PurDt = (DateTime)rd.GetValue(rd.GetOrdinal("PurDt"));
                _InvNo = (string)rd.GetValue(rd.GetOrdinal("InvNo"));
                _InvDt = (DateTime)rd.GetValue(rd.GetOrdinal("InvDt"));
                _PtyId = (int)rd.GetValue(rd.GetOrdinal("PtyId"));
                _Cash = (bool)rd.GetValue(rd.GetOrdinal("Cash"));
                _Narr = (string)rd.GetValue(rd.GetOrdinal("Narr"));
                //_TransportId = (int)rd.GetValue(rd.GetOrdinal("TransportId"));
            _TotAmt  = (decimal)rd.GetValue(rd.GetOrdinal("TotAmt"));
            _Discper = (decimal)rd.GetValue(rd.GetOrdinal("Discper"));
            _DiscAmt = (decimal)rd.GetValue(rd.GetOrdinal("DiscAmt"));
            _TaxId = (short)rd.GetValue(rd.GetOrdinal("TaxId"));
            _Taxper = (decimal)rd.GetValue(rd.GetOrdinal("Taxper"));
            _TaxAmt  = (decimal)rd.GetValue(rd.GetOrdinal("TaxAmt"));
            _Est = (bool)rd.GetValue(rd.GetOrdinal("Est"));
            _EstId = (int)rd.GetValue(rd.GetOrdinal("EstId"));
           
                _NetAmt = (decimal)rd.GetValue(rd.GetOrdinal("NetAmt"));
                _UserId = (byte)rd.GetValue(rd.GetOrdinal("UserId"));
                _DocCancel = (bool)rd.GetValue(rd.GetOrdinal("DocCancel"));
                _Remarks = (string)rd.GetValue(rd.GetOrdinal("Remarks"));
                _CSTTaxId = (int)rd.GetValue(rd.GetOrdinal("CSTTaxId"));
                _Imode = (bool)rd.GetValue(rd.GetOrdinal("Imode"));
                

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
        public DataTable navigate(bool All, DateTime fdt1, DateTime tdt1)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Select Top 100 * From PurHdrNewVwFn('" + All + "','" + fdt1.ToString("dd/MMM/yyyy") + "','" + tdt1.ToString("dd/MMM/yyyy") + "'," + Common.CId + ") where PurId > 0 order by PurId Desc", Con);
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
		
		public System.Collections.Hashtable _FilteringValues =new System.Collections.Hashtable();
		_ViewValues _View;
		public struct _ViewValues
		{
			public	System.Collections.Hashtable FilteringValues;
			public string TableNames;
			public string Fields;
			public string Conditions;
			public string OrderBy;
			public string AdvVwTblName;
		}
        public void SetViewControl(bool All,DateTime fdt, DateTime tdt)
		{
			_FilteringValues.Clear();
			
			_View.FilteringValues = _FilteringValues;
            _View.TableNames = "PurHdrNewVwFn('" + All + "','" + fdt.ToString("dd/MMM/yyyy") + "','" + tdt.ToString("dd/MMM/yyyy") + "'," + Common.CId + ")";
			_View.Conditions = "";
			_View.OrderBy="PurNo";

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
            tmp.Add(CommonView.GetGridViewColumn("Purid", "Purid", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("PurNo", "PurNo", 80, 2, true));
            tmp.Add(CommonView.GetGridViewColumn("PurDt", "PurDate", 80, 3, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));
            tmp.Add(CommonView.GetGridViewColumn("RefNo", "RefNo", 80, 4, true,DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("InvNo", "InvNo", 80, 5, true));
            tmp.Add(CommonView.GetGridViewColumn("InvDt", "InvDate", 80, 6, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));
            tmp.Add(CommonView.GetGridViewColumn("Supplier", "Supplier", 100, 7, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewBoolColumn("Cash", "Cash", 50, 8));
            tmp.Add(CommonView.GetGridViewColumn("TotAmt", "Total", 75, 9, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("NetAmt", "NetAmt", 75, 10, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }


        public int Search_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("Purid", "Purid", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("PurNo", "PurNo", 80, 2, true));
            tmp.Add(CommonView.GetGridViewColumn("PurDt", "PurDate", 80, 3, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));
            tmp.Add(CommonView.GetGridViewColumn("InvNo", "InvNo", 80, 4, true));
            tmp.Add(CommonView.GetGridViewColumn("InvDt", "InvDate", 80, 5, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));
            tmp.Add(CommonView.GetGridViewColumn("PtyId", "PtyId", 0, 6, true));
            tmp.Add(CommonView.GetGridViewColumn("Supplier", "Supplier", 100, 6, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewBoolColumn("OtherState", "OtherState", 50, 7));
            tmp.Add(CommonView.GetGridViewBoolColumn("Cash", "Cash", 50, 8));
            tmp.Add(CommonView.GetGridViewColumn("Discper", "Disc%", 75, 9, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("DiscAmt", "DiscAmt", 75, 10, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("TaxId", "TaxId", 0, 11, true));
            tmp.Add(CommonView.GetGridViewColumn("Taxper", "Taxper", 80, 12, true));
            tmp.Add(CommonView.GetGridViewColumn("Taxamt", "Taxamt", 80, 13, true));
            tmp.Add(CommonView.GetGridViewColumn("TotAmt", "Total", 75, 14, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("NetAmt", "NetAmt", 75, 15, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Narr", "Narration", 100, 16, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 17, true));
            tmp.Add(CommonView.GetGridViewColumn("Username", "UserName", 80, 18, true));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 19));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
		#endregion
		
	}
}
