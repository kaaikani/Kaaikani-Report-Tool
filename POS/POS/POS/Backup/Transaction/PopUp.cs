using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using GridStructures;
using DBAccess;
using RLPOSDB;

namespace RLPOSDB
{
    public class PopUpDb
    {
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
        #region "ItemSource"
        public DataTable ItemSelect_Source(int CategoryId, string ItemCode, bool StkCheck, int BrandId)
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

            MyParam = new SqlParameter("@BrandId", SqlDbType.Int);
            MyParam.Value = BrandId;
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
            tmp.Add(CommonView.GetGridViewColumn("ItemCode", "Itemcode", 0, 4, true));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 100, 5, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
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
            tmp.Add(CommonView.GetGridViewColumn("NoofQty", "NoofQty", 0, 23, true));
            tmp.Add(CommonView.GetGridViewColumn("MarginPer", "MarginPer", 0, 24, true));
            tmp.Add(CommonView.GetGridViewColumn("ARatePer", "ARate%", 0, 25, true));
            tmp.Add(CommonView.GetGridViewColumn("BRatePer", "BRate%", 0, 26, true));
            tmp.Add(CommonView.GetGridViewColumn("CRatePer", "CRate%", 0, 27, true));
            tmp.Add(CommonView.GetGridViewColumn("DRatePer", "DRate%", 0, 28, true));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        #endregion

        public DataTable Ledger_Source()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Acc_Qry_achdallvw", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@CompId", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);
            Cmd.CommandTimeout = 1000000;
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
            tmp.Add(CommonView.GetGridViewColumn("Ledger", "Ledger", 120, 2, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("FirstLvl", "FirstLvl", 0, 3, false, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("SeniorI", "SeniorI", 0, 4, false, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("AcCode", "AcCode", 70, 5, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Compid", "Compid", 0, 6));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

       
    }
}
