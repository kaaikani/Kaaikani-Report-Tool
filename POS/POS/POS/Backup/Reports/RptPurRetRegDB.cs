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
    public class RptPurRetRegDB
    {
        public RptPurRetRegDB()
        {
            //
            // TODO: Add constructor logic here
            //
        }
 

  

        # region "Purchase"
        public DataTable RptPurHdr_Source(DateTime Fdt, DateTime TDt, string Condition,bool All)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_RptPurchase", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Fdt", SqlDbType.DateTime);
            MyParam.Value = Fdt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@TDt", SqlDbType.DateTime);
            MyParam.Value = TDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Cond", SqlDbType.VarChar, 250);
            MyParam.Value = Condition;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@All", SqlDbType.Bit);
            MyParam.Value = All;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_RptPurchase";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public void RptPurHdr_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("PurId", "PurId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("PurNo", "PurNo", 50, 2, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("PurDt", "PurDt", 80, 3, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));
            tmp.Add(CommonView.GetGridViewColumn("InvNo", "InvNo", 60, 4, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("InvDt", "InvDt", 80, 5, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));
            tmp.Add(CommonView.GetGridViewColumn("PtyId", "PtyId", 0, 6, true, DataGridViewContentAlignment.MiddleLeft, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Party", "Party", 100, 7, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Totamt", "Total", 80, 8, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("NetAmt", "NetAmt", 80, 9, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Type", "Type", 70, 10, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 11, true));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }


        public DataTable RptPurRetItemWiseDet_Source(string Condition, bool Cumulative,bool All)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable Tbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_RptRetPurItemWiseDet", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Cond", SqlDbType.VarChar, 250);
            MyParam.Value = Condition;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Cumulative", SqlDbType.Bit);
            MyParam.Value = (Cumulative == true ? 1 : 0);
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@All", SqlDbType.Bit);
            MyParam.Value =All;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(Tbl);

            Tbl.TableName = "Qry_RptPurRetDet";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return Tbl;
        }

        public void RptPurRetItemWiseDet_GridStyle(DataGridViewColumnCollection tmp)
        {

            tmp.Clear();
           
            tmp.Add(CommonView.GetGridViewColumn("PurRetId", "PurRetId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("PurRetNo", "PurRetNo", 40, 1, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("PurRetDt", "PurRetDt", 70, 2, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));
            tmp.Add(CommonView.GetGridViewColumn("CategoryId", "CategoryId", 0, 3));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 80, 4, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 5));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 100, 6, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));

            tmp.Add(CommonView.GetGridViewColumn("BatchNo", "BatchNo", (Common.AllowExpiryDt == true) ? 90 : 0, 7, false, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewDateColumn("ExpiryDt", "ExpiryDate", (Common.AllowExpiryDt == true) ? 80 : 0, 8, "dd/MM/yyyy", false));

            tmp.Add(CommonView.GetGridViewColumn("Qty", "Qty", 50, 9, true, DataGridViewContentAlignment.MiddleRight, Common.QtyFormat));
            tmp.Add(CommonView.GetGridViewColumn("Wt", "Weight", (Common.WtItem == true) ? 80 : 0, 10, true, DataGridViewContentAlignment.MiddleRight, "######0.000"));
            tmp.Add(CommonView.GetGridViewColumn("Free", "Free", (Common.AllowPurFree == true) ? 80 : 0, 11, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));

            tmp.Add(CommonView.GetGridViewColumn("Rate", "Rate", 65, 12, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("DiscPer", "Disc%", 40, 13, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("DiscAmt", "DiscAmt", 50, 14, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Amount", "Amount", 70, 15, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("TaxName", "TaxName", 0, 16, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("TaxPer", "Tax%", 40, 17, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("TaxAmt", "TaxAmt", 50, 18, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 19));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }

        public void RptPurCumulativeDet_GridStyle(DataGridViewColumnCollection tmp)
        {

            tmp.Clear();
         
            tmp.Add(CommonView.GetGridViewColumn("CategoryId", "CategoryId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 150, 2, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 200, 3, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Qty", "Qty", 70, 4, true, DataGridViewContentAlignment.MiddleRight, Common.QtyFormat));
            tmp.Add(CommonView.GetGridViewColumn("Wt", "Weight", (Common.WtItem == true) ? 80 : 0, 5, true, DataGridViewContentAlignment.MiddleRight, "######0.000"));
            tmp.Add(CommonView.GetGridViewColumn("Free", "Free", (Common.AllowFree == true) ? 80 : 0, 5, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));

            tmp.Add(CommonView.GetGridViewColumn("PurAmt", "Amount", 70, 6, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("TaxAmt", "TaxAmt", 70, 7, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 8, true, DataGridViewContentAlignment.MiddleLeft, "######0.00"));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }
        public DataTable RptPurRetCatWiseDet_Source(string Condition,bool All)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable Tbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_RptPurRetCatWiseDet", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Cond", SqlDbType.VarChar, 250);
            MyParam.Value = Condition;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@All", SqlDbType.Bit);
            MyParam.Value = All;
            MyCmd.Parameters.Add(MyParam);
  
            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(Tbl);

            Tbl.TableName = "Qry_RptPurRetCatWiseDet";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return Tbl;
        }

        public void RptPurRetCatWiseDet_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();

            tmp.Add(CommonView.GetGridViewColumn("CategoryId", "CategoryId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("PurRetDt", "PurRetDt", 80, 2, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 200, 3, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Qty", "Qty", 70, 4, true, DataGridViewContentAlignment.MiddleRight, Common.QtyFormat));
            tmp.Add(CommonView.GetGridViewColumn("Wt", "Weight", (Common.WtItem == true) ? 80 : 0, 5, true, DataGridViewContentAlignment.MiddleRight, "######0.000"));

            tmp.Add(CommonView.GetGridViewColumn("Free", "Free", (Common.AllowPurFree == true) ? 80 : 0, 6, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));

            tmp.Add(CommonView.GetGridViewColumn("Amount", "Amount", 70, 7, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 8));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }

        public DataTable RptPurRetHdr_Source(DateTime Fdt, DateTime TDt, string Condition)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_RptPurchaseReturn", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Fdt", SqlDbType.DateTime);
            MyParam.Value = Fdt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@TDt", SqlDbType.DateTime);
            MyParam.Value = TDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Cond", SqlDbType.VarChar, 250);
            MyParam.Value = Condition;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_RptPurchaseReturn";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public void RptPurRetHdr_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("PurRetId", "PurRetId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("PurRetNo", "PurRetNo", 50, 2, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("PurRetDt", "PurRetDt", 80, 3, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));
            tmp.Add(CommonView.GetGridViewColumn("PurRetInvNo", "PurRetInvNo", 60, 4, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("PurRetInvDt", "PurRetInvDt", 80, 5, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));
            tmp.Add(CommonView.GetGridViewColumn("PtyId", "PtyId", 0, 6, true, DataGridViewContentAlignment.MiddleLeft, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Party", "Party", 100, 7, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Totamt", "Total", 80, 8, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("DiscPer", "DiscPer", 80, 9, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("DiscAmt", "DiscAmt", 80, 10, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("TaxPer", "TaxPer", 80, 11, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("TaxAmt", "TaxAmt", 80, 12, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("TaxId", "TaxId", 0, 13));
            tmp.Add(CommonView.GetGridViewColumn("NetAmt", "NetAmt", 80, 14, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Type", "Type", 70, 15, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 16, true));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }

        #endregion

    }
}
