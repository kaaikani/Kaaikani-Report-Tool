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
	public class ItemwiseTaxSetDB
	{
        public ItemwiseTaxSetDB()
		{
			//
			// TODO: Add constructor logic here
			//
		}
        # region "Properties"

        int _ItemId;
        public int ItemId
        {
            get
            {
                return _ItemId;
            }
            set
            {
                _ItemId = value;
            }
        }

        string _ItemCode;
        public string ItemCode
        {
            get
            {
                return _ItemCode;
            }
            set
            {
                _ItemCode = value;
            }
        }

        string _ItemName;
        public string ItemName
        {
            get
            {
                return _ItemName;
            }
            set
            {
                _ItemName = value;
            }
        }
        
        decimal _Tax;
        public decimal Tax
        {
            get
            {
                return _Tax;
            }
            set
            {
                _Tax = value;
            }
        }
        
        Boolean _Change;
        public Boolean Change
        {
            get
            {
                return _Change;
            }
            set
            {
                _Change = value;
            }
        }
        Boolean _TaxChange;
        public Boolean TaxChange
        {
            get
            {
                return _TaxChange;
            }
            set
            {
                _TaxChange = value;
            }
        }
        int _CatId;
        public int CatId
        {
            get
            {
                return _CatId;
            }
            set
            {
                _CatId = value;
            }
        }
        int _CompanyId;
        public int CompanyId
        {
            get
            {
                return _CompanyId;
            }
            set
            {
                _CompanyId = value;
            }
        }
               
        int _TaxTypeId;
        public int TaxTypeId
        {
            get
            {
                return _TaxTypeId;
            }
            set
            {
                _TaxTypeId = value;
            }
        }
        string _TaxType;
        public string TaxType
        {
            get
            {
                return _TaxType;
            }
            set
            {
                _TaxType = value;
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


        bool _CatBit;
        public bool CatBit
        {
            get
            {
                return _CatBit;
            }
            set
            {
                _CatBit = value;
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

        
        string _CatName;
        public string CatName
        {
            get
            {
                return _CatName;
            }
            set
            {
                _CatName = value;
            }
        }

        
        DateTime _FrmDt;
        public DateTime FrmDt
        {
            get
            {
                return _FrmDt;
            }
            set
            {
                _FrmDt = value;
            }
        }

        DateTime _ToDt;
        public DateTime ToDt
        {
            get
            {
                return _ToDt;
            }
            set
            {
                _ToDt = value;
            }
        }
       
        # endregion

        # region "Detail Section"
        public DataTable CatTaxSource()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_CatTax", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@CompId", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "CatTax";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }
   
        public int CatTax_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("CategoryId", "CategoryId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 100, 2, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("TaxId", "TaxId", 0, 3));
            tmp.Add(CommonView.GetGridViewColumn("TaxName", "TaxName", 200, 4, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 5));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 6));
            
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

        public DataTable ItemTaxSource(int CatId)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_ItemTax", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@CategoryId", SqlDbType.Int);
            MyParam.Value = CatId;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "ItemTax";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }
    

        public int ItemTax_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("ItemCode", "ItemCode", 0, 2));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 100, 3, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("TaxId", "TaxId", 0, 4));
            tmp.Add(CommonView.GetGridViewColumn("TaxName", "TaxName", 200, 5, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewBoolColumn("TaxChange", "TaxChange", 70, 6));
            tmp.Add(CommonView.GetGridViewColumn("CategoryId", "CategoryId", 0, 7));
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 8));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 9));

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

            MyCmd = new SqlCommand("Qry_ItemTaxSelect", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@compid", SqlDbType.TinyInt);
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
            tmp.Add(CommonView.GetGridViewColumn("TaxName", "TaxName", 80, 2, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Taxper", "Tax%", 100, 3, true, DataGridViewContentAlignment.MiddleLeft, "0.00"));
            tmp.Add(CommonView.GetGridViewBoolColumn("Vat", "Vat", 50, 4));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        # endregion

        public void SaveFunction(bool CatBit)
       {
          
           try
            {
                SqlConnection Con = new SqlConnection(Common.ConStr);
                SqlDataAdapter Da = new SqlDataAdapter();
                Con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("TaxSettingSP", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@CategoryId", SqlDbType.Int);
                param.Value = _CatId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TaxId", SqlDbType.Int);
                param.Value = _TaxTypeId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@ItemId", SqlDbType.Int);
                param.Value = _ItemId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TaxChange", SqlDbType.Bit);
                param.Value = _TaxChange;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.TinyInt);
                param.Value = Common.UserId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CompId", SqlDbType.TinyInt);
                param.Value = Common.CId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CatBit", SqlDbType.Bit);
                param.Value = CatBit;
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

