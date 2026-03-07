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
    public class RptStkRepDB
    {
        public RptStkRepDB()
        {
            //
            // TODO: Add constructor logic here
            //
        }
 

  

        # region "StockReport"
        public DataTable RptStockDtRep_Source(DateTime FromDt, DateTime ToDt, string Condition,bool Est)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_StockDtReport", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@FromDt", SqlDbType.DateTime);
            MyParam.Value = FromDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@ToDt", SqlDbType.DateTime);
            MyParam.Value = ToDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Cond", SqlDbType.VarChar, 250);
            MyParam.Value = Condition;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Est", SqlDbType.Bit);
            MyParam.Value = Est;
            MyCmd.Parameters.Add(MyParam);


            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_StockDtReport";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public void RptStockDtRep_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("ItemCode", "Code", 80, 2, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("UPCCode", "UPCCode", 0, 3, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("Brand", "Brand", 80, 4, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 80, 5, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 0, 6, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("SizeId", "SizeId", 0, 7, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("SizeName", "Size", 80, 8, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("BatchNo", "BatchNo", (Common.AllowExpiryDt == true) ? 80 : 0, 9, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("ExpiryDt", "ExpiryDt", (Common.AllowExpiryDt == true) ? 80 : 0, 10, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));

            tmp.Add(CommonView.GetGridViewColumn("OpQty", "OpQty", 60, 11, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("OpAmt", "OpAmt", 70, 12, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("PurQty", "PurQty", 60, 13, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("PurAmt", "PurRate", 70, 14, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));

            tmp.Add(CommonView.GetGridViewColumn("PurRetQty", "PRQty", 45, 15, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("PurRetAmt", "PRAmt", 50, 16, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SalQty", "SalQty", 60, 17, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SalAmt", "SalAmt", 70, 18, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SalRetQty", "SRQty", 50, 19, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SalRetAmt", "SRAmt", 45, 20, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("AddQty", "AddQty", 45, 21, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("LessQty", "LessQty", 50, 22, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("ClBal", "ClosingBal", 70, 23, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("ClAmt", "ClosingAmt", 100, 24, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 25, true, DataGridViewContentAlignment.MiddleLeft, "######0"));
            tmp.Add(CommonView.GetGridViewColumn("OrdBy", "OrdBy", 0, 26, true));
            tmp.Add(CommonView.GetGridViewColumn("Cost", "CostValue", 0, 27, true, DataGridViewContentAlignment.MiddleRight, "######0"));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }


        public DataTable RptStockDtItemRep_Source(DateTime FromDt, DateTime ToDt, string Condition, int ItemId,bool Est)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_StockDtItemwiseReport", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@FromDt", SqlDbType.DateTime);
            MyParam.Value = FromDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@ToDt", SqlDbType.DateTime);
            MyParam.Value = ToDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Cond", SqlDbType.VarChar, 250);
            MyParam.Value = Condition;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@ItemId", SqlDbType.Int);
            MyParam.Value = ItemId;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Est", SqlDbType.Bit);
            MyParam.Value = Est;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_StockDtItemwiseReport";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public void RptStockDtItemRep_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 150, 2, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 150, 3, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("OpQty", "OpQty", 45, 4, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("OpAmt", "OpAmt", 45, 5, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("PurQty", "PurQty", 50, 6, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("PurAmt", "PurAmt", 45, 7, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));

            tmp.Add(CommonView.GetGridViewColumn("PurRetQty", "PRQty", 50, 8, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("PurRetAmt", "PurRetAmt", 45, 9, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SalQty", "SalQty", 50, 10, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SalAmt", "SalAmt", 45, 11, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SalRetQty", "SRQty", 50, 12, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SalRetAmt", "SalRetAmt", 45, 13, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("AddQty", "AddQty", 50, 14, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("LessQty", "LessQty", 50, 15, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("ClBal", "ClosingBal", 70, 16, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 17, true, DataGridViewContentAlignment.MiddleLeft, "######0"));
            tmp.Add(CommonView.GetGridViewColumn("OrdBy", "OrdBy", 0, 18, true));
            tmp.Add(CommonView.GetGridViewColumn("Cost", "CostValue", 0, 19, true, DataGridViewContentAlignment.MiddleRight, "######0"));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }

        public DataTable RptStockWtDtRep_Source(DateTime FromDt, DateTime ToDt,string stkpoint, string Condition,bool Est)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_StockWtDtReport", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@FromDt", SqlDbType.DateTime);
            MyParam.Value = FromDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@ToDt", SqlDbType.DateTime);
            MyParam.Value = ToDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);


            MyParam = new SqlParameter("@StockPoint", SqlDbType.Char , 1);
            MyParam.Value = stkpoint;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Cond", SqlDbType.VarChar, 250);
            MyParam.Value = Condition;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Est", SqlDbType.Bit);
            MyParam.Value = Est;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_StockWtDtReport";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public void RptStockWtDtRep_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 150, 2, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 150, 3, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("OpWt", "OpWt", 45, 4, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("OpWtAmt", "OpWtAmt", 45, 5, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("PurWt", "PurWt", 50, 6, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("PurWtAmt", "PurWtAmt", 45, 7, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));

            tmp.Add(CommonView.GetGridViewColumn("PurRetWt", "PRWt", 50, 8, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("PurRetWtAmt", "PurRetWtAmt", 45, 9, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SalWt", "SalWt", 50, 10, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SalWtAmt", "SalWtAmt", 45, 11, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SalRetWt", "SRWt", 50, 12, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SalRetWtAmt", "SalRetWtAmt", 45, 13, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("AddWt", "AddWt", 50, 14, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("LessWt", "LessWt", 50, 15, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("ClBal", "ClosingBal", 70, 16, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("ClAmt", "ClosingAmt", 100, 17, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 18, true, DataGridViewContentAlignment.MiddleLeft, "######0"));
            tmp.Add(CommonView.GetGridViewColumn("OrdBy", "OrdBy", 0, 19, true));
            tmp.Add(CommonView.GetGridViewColumn("Cost", "CostValue", 0, 20, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }

        public DataTable RptCurrentStockDtRep_Source(DateTime FromDt, DateTime ToDt, string Condition, bool Est)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_CurrentStockDtReport", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@FromDt", SqlDbType.DateTime);
            MyParam.Value = FromDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@ToDt", SqlDbType.DateTime);
            MyParam.Value = ToDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Cond", SqlDbType.VarChar, 250);
            MyParam.Value = Condition;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Est", SqlDbType.Bit);
            MyParam.Value = Est;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_CurrentStockDtReport";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public void RptCurrentStockDtRep_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 200, 2, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 150, 3, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("OpQty", "OpQty", 0, 4, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("OpAmt", "OpAmt", 0, 5, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("PurQty", "PurQty", 0, 6, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("PurAmt", "PurAmt", 0, 7, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("PurRetQty", "PRQty", 0, 8, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("PurRetAmt", "PurRetAmt", 0, 9, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SalQty", "SalQty", 0, 10, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SalAmt", "SalAmt", 0, 11, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SalRetQty", "SRQty", 0, 12, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SalRetAmt", "SalRetAmt", 0, 13, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("AddQty", "AddQty", 0, 14, true, DataGridViewContentAlignment.MiddleRight, "######0"));
            tmp.Add(CommonView.GetGridViewColumn("LessQty", "LessQty", 0, 15, true, DataGridViewContentAlignment.MiddleRight, "######0"));
            tmp.Add(CommonView.GetGridViewColumn("ClBal", "ClosingBal", 80, 16, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("ClAmt", "ClAmt", 100, 17, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 18, true, DataGridViewContentAlignment.MiddleLeft, "######0"));
            tmp.Add(CommonView.GetGridViewColumn("OrdBy", "OrdBy", 0, 19, true));
            tmp.Add(CommonView.GetGridViewColumn("Cost", "CostValue", 0, 20, true, DataGridViewContentAlignment.MiddleRight, "######0"));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }

        public DataTable RptNoStockDtRep_Source(DateTime FromDt, DateTime ToDt, string Condition, bool Est)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_NoStockDtReport", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@FromDt", SqlDbType.DateTime);
            MyParam.Value = FromDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@ToDt", SqlDbType.DateTime);
            MyParam.Value = ToDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Cond", SqlDbType.VarChar, 250);
            MyParam.Value = Condition;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Est", SqlDbType.Bit);
            MyParam.Value = Est;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_CurrentStockDtReport";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public void RptNoStockDtRep_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 200, 2, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 150, 3, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("OpQty", "OpQty", 0, 4, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("OpAmt", "OpAmt", 0, 5, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("PurQty", "PurQty", 0, 6, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("PurAmt", "PurAmt", 0, 7, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("PurRetQty", "PRQty", 0, 8, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("PurRetAmt", "PurRetAmt", 0, 9, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SalQty", "SalQty", 0, 10, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SalAmt", "SalAmt", 0, 11, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SalRetQty", "SRQty", 0, 12, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SalRetAmt", "SalRetAmt", 0, 13, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("AddQty", "AddQty", 0, 14, true, DataGridViewContentAlignment.MiddleRight, "######0"));
            tmp.Add(CommonView.GetGridViewColumn("LessQty", "LessQty", 0, 15, true, DataGridViewContentAlignment.MiddleRight, "######0"));
            tmp.Add(CommonView.GetGridViewColumn("ClBal", "ClosingBal", 80, 16, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("ClAmt", "ClAmt", 100, 17, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 18, true, DataGridViewContentAlignment.MiddleLeft, "######0"));
            tmp.Add(CommonView.GetGridViewColumn("OrdBy", "OrdBy", 0, 19, true));
            tmp.Add(CommonView.GetGridViewColumn("Cost", "CostValue", 0, 20, true, DataGridViewContentAlignment.MiddleRight, "######0"));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }

        public DataTable RptStockLedDet_Source(DateTime FromDt, DateTime ToDt, int ItemId, string Condition)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable Tbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_StockLedger", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@FromDt", SqlDbType.DateTime);
            MyParam.Value = FromDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@ToDt", SqlDbType.DateTime);
            MyParam.Value = ToDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@ItemId", SqlDbType.Int);
            MyParam.Value = ItemId;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Cond", SqlDbType.VarChar, 250);
            MyParam.Value = Condition;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(Tbl);

            Tbl.TableName = "Qry_StockLeder";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return Tbl;
        }

        public void RptStockLedDet_GridStyle(DataGridViewColumnCollection tmp)
        {
            
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("Id", "Id", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Dt", "Dt", 0, 2, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yy"));
            tmp.Add(CommonView.GetGridViewColumn("Description", "Description", 100, 3, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 0, 4, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 0, 5, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("Inward", "Inward", 60, 6, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Outward", "Outward", 60, 7, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("ClBal", "ClosingBal", 70, 8, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 9));
            tmp.Add(CommonView.GetGridViewColumn("RefType", "RefType", 0, 10));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 11));
            tmp.Add(CommonView.GetGridViewColumn("OrdBy", "OrdBy", 0, 12));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }

        public DataTable StockDtAllReport_Source(DateTime FromDt, DateTime ToDt, string Condition, bool Est)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_StockDtAllReport", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@FromDt", SqlDbType.DateTime);
            MyParam.Value = FromDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@ToDt", SqlDbType.DateTime);
            MyParam.Value = ToDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Cond", SqlDbType.VarChar, 250);
            MyParam.Value = Condition;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Est", SqlDbType.Bit);
            MyParam.Value = Est;
            MyCmd.Parameters.Add(MyParam);


            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_StockDtAllReport";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public void StockDtAllReport_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("ItemCode", "Code", 80, 2, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("UPCCode", "UPCCode", 90, 3, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 80, 4, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 90, 5, true, DataGridViewContentAlignment.MiddleLeft, ""));

            tmp.Add(CommonView.GetGridViewColumn("BatchNo", "BatchNo", (Common.AllowExpiryDt == true) ? 80 : 0, 6, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("ExpiryDt", "ExpiryDt", (Common.AllowExpiryDt == true) ? 80 : 0, 7, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));

            tmp.Add(CommonView.GetGridViewColumn("OpQty", "OpQty", 60, 8, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("OpAmt", "OpAmt", 70, 9, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("PurQty", "PurQty", 60, 10, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("PurAmt", "PurRate", 70, 11, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));

            tmp.Add(CommonView.GetGridViewColumn("PurRetQty", "PRQty", 45, 12, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("PurRetAmt", "PRAmt", 50, 13, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SalQty", "SalQty", 60, 14, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SalAmt", "SalAmt", 70, 15, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SalRetQty", "SRQty", 50, 16, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SalRetAmt", "SRAmt", 45, 17, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("AddQty", "AddQty", 45, 18, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("LessQty", "LessQty", 50, 19, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("ClBal", "ClosingBal", 70, 20, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("ClAmt", "ClosingAmt", 100, 21, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 22, true, DataGridViewContentAlignment.MiddleLeft, "######0"));
            tmp.Add(CommonView.GetGridViewColumn("OrdBy", "OrdBy", 0, 23, true));
            tmp.Add(CommonView.GetGridViewColumn("Cost", "CostValue", 0, 24, true, DataGridViewContentAlignment.MiddleRight, "######0"));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }

        public DataTable RptStockLedAll_Source(DateTime FromDt, DateTime ToDt, int ItemId, string Condition)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable Tbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_StockLedgerAll", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@FromDt", SqlDbType.DateTime);
            MyParam.Value = FromDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@ToDt", SqlDbType.DateTime);
            MyParam.Value = ToDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@ItemId", SqlDbType.Int);
            MyParam.Value = ItemId;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Cond", SqlDbType.VarChar, 250);
            MyParam.Value = Condition;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(Tbl);

            Tbl.TableName = "Qry_StockLedgerAll";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return Tbl;
        }

        public void RptStockLedAll_GridStyle(DataGridViewColumnCollection tmp)
        {

            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("Id", "Id", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Dt", "Dt", 0, 2, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yy"));
            tmp.Add(CommonView.GetGridViewColumn("Description", "Description", 100, 3, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 0, 4, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 0, 5, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("Inward", "Inward", 60, 6, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Outward", "Outward", 60, 7, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("ClBal", "ClosingBal", 70, 8, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 9));
            tmp.Add(CommonView.GetGridViewColumn("RefType", "RefType", 0, 10));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 11));
            tmp.Add(CommonView.GetGridViewColumn("OrdBy", "OrdBy", 0, 12));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }



        #endregion
        #region "ItemSelect"
        public DataTable ItemNameSelect()
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_ItemSelect", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@compId", SqlDbType.TinyInt);
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

        public int ItemNameSelect_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("Itemid", "Itemid", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 200, 2, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Itemcode", "Itemcode", 0, 3));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 80, 4, true));
           
            
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        # endregion
        # region "TaxBasedReport"
        public DataTable RptTaxDtRep_Source(DateTime FromDt, DateTime ToDt)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_RptTax", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@FDt", SqlDbType.DateTime);
            MyParam.Value = FromDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@TDt", SqlDbType.DateTime);
            MyParam.Value = ToDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_RptTax";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }
        public void RptTaxDtRep_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("TaxId", "TaxId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("BillDt", "BillDt", 150, 2, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("TaxName", "TaxName", 250, 3, true, DataGridViewContentAlignment.MiddleLeft,"",DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Amount", "SaleValue", 100, 4, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }
        #endregion

        # region "Consolidated"
        public DataTable RptConsolidated_Source(DateTime FromDt, DateTime ToDt)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_RptConsolidated", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@FrmDt", SqlDbType.DateTime);
            MyParam.Value = FromDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@ToDt", SqlDbType.DateTime);
            MyParam.Value = ToDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

           
            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_RptConsolidated";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public void RptConsolidated_GridStyle(DataGridViewColumnCollection tmp)
        {

            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("Particular", "Particular", 650, 1,true,DataGridViewContentAlignment.MiddleLeft, "",DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("SalAmount", "SalAmount", 150, 2, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("PurAmount", "PurAmount", 150, 3, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SalTotBill", "SalTotBill", 150, 4, true, DataGridViewContentAlignment.MiddleRight, ""));
            tmp.Add(CommonView.GetGridViewColumn("PurTotBill", "PurTotBill", 150, 5, true, DataGridViewContentAlignment.MiddleRight, ""));
            tmp.Add(CommonView.GetGridViewColumn("OrdNo", "OrdNo", 0, 6));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = true;
        }


        # endregion

        # region "Profit Register"
        public DataTable Rptprofit_Source(DateTime FromDt, DateTime ToDt)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_RptConsolidated", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@FrmDt", SqlDbType.DateTime);
            MyParam.Value = FromDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@ToDt", SqlDbType.DateTime);
            MyParam.Value = ToDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);


            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_RptConsolidated";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public void Rptprofit_GridStyle(DataGridViewColumnCollection tmp)
        {

            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("Particular", "Particular", 650, 1, true, DataGridViewContentAlignment.MiddleLeft, "",DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("SalAmount", "SalAmount", 150, 2, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("PurAmount", "PurAmount", 150, 3, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SalTotBill", "SalTotBill", 150, 4, true, DataGridViewContentAlignment.MiddleRight, ""));
            tmp.Add(CommonView.GetGridViewColumn("PurTotBill", "PurTotBill", 150, 5, true, DataGridViewContentAlignment.MiddleRight, ""));
            tmp.Add(CommonView.GetGridViewColumn("OrdNo", "OrdNo", 0, 6));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = true;
        }


        # endregion



    }
}
