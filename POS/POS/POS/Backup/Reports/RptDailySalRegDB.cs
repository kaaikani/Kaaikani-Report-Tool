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
    public class RptDailySalRegDB
    {
        public RptDailySalRegDB()
        {
            //
            // TODO: Add constructor logic here
            //
        }
 
        # region "Sales"
        public DataTable RptSalHdr_Source(DateTime Fdt, DateTime TDt, string Condition,bool All)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_RptSales", MyCon);
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
            MyParam.Value = (All == true ? 1 : 0);
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_RptSales";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public void RptSalHdr_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("SalId", "SalId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("BillNo", "BillNo", 50, 2, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("BillDt", "BillDt", 75, 3, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yy"));
            tmp.Add(CommonView.GetGridViewColumn("BillRefNo", "BillRefNo", 60, 4, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("PtyId", "PtyId", 0, 5, true, DataGridViewContentAlignment.MiddleLeft, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Party", "Party", 100, 6, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Total", "Total", 80, 7, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Cartage", "Cartage", 70, 8, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Packing", "Packing", 70, 9, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("NetAmt", "NetAmt", 90, 10, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("PaidAmt", "PaidAmt", 80, 11, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            
            tmp.Add(CommonView.GetGridViewColumn("Cash", "Cash", 40, 12, true, DataGridViewContentAlignment.MiddleLeft, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Retail", "Retail", 40, 13, true, DataGridViewContentAlignment.MiddleLeft, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 14, true, DataGridViewContentAlignment.MiddleLeft, "######0.00"));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }


        public DataTable RptSalItemWiseDet_Source(string Condition, bool Cumulative)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable Tbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_RptSalItemWiseDet", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Cond", SqlDbType.VarChar, 250);
            MyParam.Value = Condition;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Cumulative", SqlDbType.Bit);
            MyParam.Value = (Cumulative == true ? 1 : 0);
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(Tbl);

            Tbl.TableName = "Qry_RptSalDet";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return Tbl;
        }

        public void RptSalItemWiseDet_GridStyle(DataGridViewColumnCollection tmp)
        {
            
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("SalId", "SalId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("BillNo", "BillNo", 40, 1, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("BillDt", "BillDt", 60, 2, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yy"));
            tmp.Add(CommonView.GetGridViewColumn("CategoryId", "CategoryId", 0, 3));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 80, 4, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 5));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 100, 6, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Qty", "Qty", 50, 7, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Wt", "Weight", 70, 8, true, DataGridViewContentAlignment.MiddleRight, "######0.000"));
            tmp.Add(CommonView.GetGridViewColumn("Rate", "Rate", 60, 9, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("DiscPer", "Disc%", 40, 10, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("DiscAmt", "DiscAmt", 50, 11, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("CDiscPer", "CDisc%", 0, 12, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("CDiscAmt", "CDiscAmt", 0, 13, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SpDiscAmt", "Sp.Amt", 0, 14, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Amount", "Amount", 70, 15, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("TaxName", "TaxName", 0, 16, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("TaxPer", "Tax%", 40, 17, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("TaxAmt", "TaxAmt", 50, 18, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 19));
            
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }

        public void RptSalCumulativeDet_GridStyle(DataGridViewColumnCollection tmp)
        {

            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("CategoryId", "CategoryId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 150, 2, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 200, 3, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Qty", "Qty", 70, 4, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SalAmt", "Amount", 70, 5, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("TaxAmt", "TaxAmt", 70, 6, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 7, true, DataGridViewContentAlignment.MiddleLeft, "######0.00"));            
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }
        public DataTable RptSalCatWiseDet_Source(string Condition)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable Tbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_RptSalCatWiseDet", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Cond", SqlDbType.VarChar, 250);
            MyParam.Value = Condition;
            MyCmd.Parameters.Add(MyParam);

  
            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(Tbl);

            Tbl.TableName = "Qry_RptSalCatWiseDet";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return Tbl;
        }

        public void RptSalCatWiseDet_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();            
            tmp.Add(CommonView.GetGridViewColumn("CategoryId", "CategoryId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("BillDt", "BillDt", 80, 2, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 200, 3, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));            
            tmp.Add(CommonView.GetGridViewColumn("Qty", "Qty", 70, 4, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));            
            tmp.Add(CommonView.GetGridViewColumn("Amount", "Amount", 70, 5, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Retail", "Retail", 0, 6));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 7));
       
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }

        #endregion

        # region "Retail Sales"
        public DataTable RptRSalHdr_Source(DateTime Fdt, DateTime TDt, string Condition)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_RptRSales", MyCon);
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

            DTbl.TableName = "Qry_RptRSalHdr";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public void RptRSalHdr_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("SalId", "SalId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("BillNo", "BillNo", 50, 2, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("BillDt", "BillDt", 80, 3, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yy"));
            tmp.Add(CommonView.GetGridViewColumn("BillRefNo", "BillRefNo", 60, 4, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("PtyId", "PtyId", 0, 5, true, DataGridViewContentAlignment.MiddleLeft, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Party", "Party", 100, 6, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Total", "Total", 80, 7, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Cartage", "Cartage", 70, 8, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Packing", "Packing", 70, 9, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("NetAmt", "NetAmt", 90, 10, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("PaidAmt", "PaidAmt", 80, 11, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 12, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("Cash", "Cash", 40, 13, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("Retail", "Retail", 0, 14, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }


        public DataTable RptRSalItemWiseDet_Source(string Condition, bool Cumulative)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable Tbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_RptRSalItemWiseDet", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Cond", SqlDbType.VarChar, 250);
            MyParam.Value = Condition;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Cumulative", SqlDbType.Bit);
            MyParam.Value = (Cumulative == true ? 1 : 0);
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(Tbl);

            Tbl.TableName = "Qry_RptRSalDet";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return Tbl;
        }

        public void RptRSalItemWiseDet_GridStyle(DataGridViewColumnCollection tmp)
        {

            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("SalId", "SalId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("BillNo", "BillNo", 40, 1, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("BillDt", "BillDt", 60, 2, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yy"));
            tmp.Add(CommonView.GetGridViewColumn("CategoryId", "CategoryId", 0, 3));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 80, 4, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 5));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 100, 6, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Qty", "Qty", 50, 7, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Rate", "Rate", 60, 8, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("DiscPer", "Disc%", 40, 9, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("DiscAmt", "DiscAmt", 50, 10, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("CDiscPer", "CDisc%", 45, 11, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("CDiscAmt", "CDiscAmt", 60, 12, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SpDiscAmt", "Sp.Amt", 50, 13, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Amount", "Amount", 70, 14, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("TaxName", "TaxName", 0, 15, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("TaxPer", "Tax%", 40, 16, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("TaxAmt", "TaxAmt", 50, 17, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 18));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }

        public void RptRSalCumulativeDet_GridStyle(DataGridViewColumnCollection tmp)
        {

            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("CategoryId", "CategoryId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 150, 2, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 200, 3, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Qty", "Qty", 70, 4, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SalAmt", "Amount", 70, 5, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("TaxAmt", "TaxAmt", 70, 6, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 7, true, DataGridViewContentAlignment.MiddleLeft, "######0.00"));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }
        public DataTable RptRSalCatWiseDet_Source(string Condition)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable Tbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_RptRSalCatWiseDet", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Cond", SqlDbType.VarChar, 250);
            MyParam.Value = Condition;
            MyCmd.Parameters.Add(MyParam);


            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(Tbl);

            Tbl.TableName = "Qry_RptRSalCatWiseDet";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return Tbl;
        }

        public void RptRSalCatWiseDet_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("CategoryId", "CategoryId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("BillDt", "BillDt", 80, 2, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 200, 3, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Qty", "Qty", 70, 4, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Amount", "Amount", 70, 5, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Retail", "Retail", 0, 6));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 7));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }

          #endregion

        # region "Sales"
        public DataTable RptDailySal_Source(DateTime Fdt, DateTime TDt, bool Cumulative, bool @Cash)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_RptDailySal", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Fdt", SqlDbType.DateTime);
            MyParam.Value = Fdt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@TDt", SqlDbType.DateTime);
            MyParam.Value = TDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Cumulative", SqlDbType.Bit);
            MyParam.Value = (Cumulative == true ? 1 : 0);
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Cash", SqlDbType.Bit);
            MyParam.Value = (Cash == true ? 1 : 0);
            MyCmd.Parameters.Add(MyParam);


            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_RptDailySal";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }





        public DataTable RptSalTax_Source(DateTime Fdt, DateTime TDt, string cond, bool All)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_RptTaxWise", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Fdt", SqlDbType.DateTime);
            MyParam.Value = Fdt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@TDt", SqlDbType.DateTime);
            MyParam.Value = TDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@cond", SqlDbType.VarChar, 200);
            MyParam.Value = cond;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@All", SqlDbType.Bit);
            MyParam.Value = (All == true ? 1 : 0);
            MyCmd.Parameters.Add(MyParam);


            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_RptTaxWise";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }







        public DataTable RptMonSal_Source(DateTime Fdt, DateTime TDt)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_RptMonSal", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Fdt", SqlDbType.DateTime);
            MyParam.Value = Fdt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@TDt", SqlDbType.DateTime);
            MyParam.Value = TDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_RptMonSal";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }


        public DataTable RptMonSal_Source_GST(DateTime Fdt, DateTime TDt)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_MonthwiseGstDetail", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Frmdt", SqlDbType.DateTime);
            MyParam.Value = Fdt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@ToDt", SqlDbType.DateTime);
            MyParam.Value = TDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_MonthwiseGstDetail"; 
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public DataTable RptPtySal_Source(DateTime Fdt, DateTime TDt)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_RptPtySal", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Fdt", SqlDbType.DateTime);
            MyParam.Value = Fdt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@TDt", SqlDbType.DateTime);
            MyParam.Value = TDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_RptPtySal";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        #endregion

    }
}
