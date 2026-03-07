using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using GridStructures;
using DBAccess;
using RLPOSDB;


namespace RLPOSDB
{
    public class RptSaleProfitDB
    {
        public RptSaleProfitDB()
        {
        }

        public DataTable RptCatWise_Profit(DateTime FrmDt, DateTime ToDt)
        {

            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            //MyCmd = new SqlCommand("qry_rptcatwiseprofit", MyCon);
            MyCmd = new SqlCommand("qry_rptprofitcatwise", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;


            MyParam = new SqlParameter("@FDt", SqlDbType.DateTime);
            MyParam.Value = FrmDt;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@TDt", SqlDbType.DateTime);
            MyParam.Value = ToDt;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "CatWise_Profit";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }
      
        public void RptCatWise_Profit_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("CategoryId", "CategoryId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 200, 2, true, DataGridViewContentAlignment.MiddleLeft,"",DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("CostValue", "CostValue", 120, 3, true, DataGridViewContentAlignment.MiddleRight));
            tmp.Add(CommonView.GetGridViewColumn("SalQty", "SalQty", 100, 4, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SaleValue", "SaleValue", 120, 5, true, DataGridViewContentAlignment.MiddleRight));
            tmp.Add(CommonView.GetGridViewColumn("Profit", "Profit", 120, 6, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Profit%", "Profit%", 120, 7, true, DataGridViewContentAlignment.MiddleRight));
            
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }

        public DataTable RptCatWiseWgt_Profit(DateTime FrmDt, DateTime ToDt)
        {

            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            //MyCmd = new SqlCommand("qry_rptcatwiseprofit", MyCon);
            MyCmd = new SqlCommand("Qry_RptProfitWtCatwise", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;


            MyParam = new SqlParameter("@FDt", SqlDbType.DateTime);
            MyParam.Value = FrmDt;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@TDt", SqlDbType.DateTime);
            MyParam.Value = ToDt;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "CatWiseWgt_Profit";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public void RptCatWiseWgt_Profit_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("CategoryId", "CategoryId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 200, 2, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("CostValue", "CostValue", 120, 3, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SaleValue", "SaleValue", 120, 4, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Profit", "Profit", 120, 5, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Profit%", "Profit%", 120, 6, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }

        public DataTable RptItemWise_Profit(DateTime FrmDt, DateTime ToDt)
        {

            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            //MyCmd = new SqlCommand("qry_rptitemwiseprofit", MyCon);
            MyCmd = new SqlCommand("qry_rptprofititemwise", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;


            MyParam = new SqlParameter("@FDt", SqlDbType.DateTime);
            MyParam.Value = FrmDt;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@TDt", SqlDbType.DateTime);
            MyParam.Value = ToDt;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "ItemWise_Profit";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public void RptItemWise_Profit_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();           
            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("ItemCode", "Code", 50, 2));
            tmp.Add(CommonView.GetGridViewColumn("UPCCode", "UPCCode", 100, 3));
            tmp.Add(CommonView.GetGridViewColumn("CategoryId", "CategoryId", 0, 4));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 200, 5, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 200, 6, true, DataGridViewContentAlignment.MiddleLeft,"",DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("CostValue", "CostValue", 100, 7, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SalQty", "SalQty", 100, 8, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SaleValue", "SaleValue", 120, 9, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Profit", "Profit", 100, 10, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Profit%", "Profit%", 100, 11, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }

        public DataTable RptItemWiseWgt_Profit(DateTime FrmDt, DateTime ToDt)
        {

            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            //MyCmd = new SqlCommand("qry_rptitemwiseprofit", MyCon);
            MyCmd = new SqlCommand("qry_rptprofitWtitemwise", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;


            MyParam = new SqlParameter("@FDt", SqlDbType.DateTime);
            MyParam.Value = FrmDt;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@TDt", SqlDbType.DateTime);
            MyParam.Value = ToDt;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "ItemWiseWgt_Profit";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public void RptItemWiseWgt_Profit_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("ItemCode", "Code", 50, 2));
            tmp.Add(CommonView.GetGridViewColumn("UPCCode", "UPCCode", 100, 3));
            tmp.Add(CommonView.GetGridViewColumn("CategoryId", "CategoryId", 0, 4));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 200, 5, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 200, 6, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("CostValue", "CostValue", 100, 7, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));           
            tmp.Add(CommonView.GetGridViewColumn("SaleValue", "SaleValue", 120, 9, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Profit", "Profit", 100, 10, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Profit%", "Profit%", 100, 11, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }
        public DataTable RptBillWise_Profit(DateTime FrmDt, DateTime ToDt)
        {

            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            //MyCmd = new SqlCommand("qry_rptitemwiseprofit", MyCon);
            MyCmd = new SqlCommand("Qry_RptBillWiseProfit", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;


            MyParam = new SqlParameter("@FDt", SqlDbType.DateTime);
            MyParam.Value = FrmDt;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@TDt", SqlDbType.DateTime);
            MyParam.Value = ToDt;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "BillWise_Profit";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public void RptBillWise_Profit_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("SalId", "SalId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("BillNo", "BillNo", 50, 2));
            tmp.Add(CommonView.GetGridViewColumn("BillDt", "BillDt", 100, 3, true, DataGridViewContentAlignment.MiddleLeft,"dd/MM/yyyy"));
            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 4));            
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 200, 5, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("PurValue", "CostValue", 100, 6, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));            
            tmp.Add(CommonView.GetGridViewColumn("SalValue", "SaleValue", 120, 7, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Profit", "Profit", 100, 8, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            //tmp.Add(CommonView.GetGridViewColumn("Profit%", "Profit%", 100, 11, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }
    }
}
