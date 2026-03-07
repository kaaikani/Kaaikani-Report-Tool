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
    public class RptSalesSubDB
    {
        public RptSalesSubDB()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable RptSalHdr_Source(DateTime Fdt, DateTime TDt, string Condition, bool All, bool Cumulative, bool Est)
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

            MyParam = new SqlParameter("@Cumulative", SqlDbType.Bit);
            MyParam.Value = (Cumulative == true ? 1 : 0);
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Est", SqlDbType.Bit);
            MyParam.Value = Est;
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
            tmp.Add(CommonView.GetGridViewColumn("BillRefNo", "RefNo", 60, 4, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("PtyId", "PtyId", 0, 5, true, DataGridViewContentAlignment.MiddleLeft, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Party", "Party", 100, 6, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("SalMan", "SalesMan", 80, 7, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("Area", "Area", 80, 8, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("TotAmt", "Total", 80, 9, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Taxper", "Tax%", 60, 10, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("TaxAmt", "TaxAmt", 70, 11, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("DiscPer", "Disc%", 70, 12, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("DiscAmt", "DiscAmt", 90, 13, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("RndOff", "RndOff", 70, 14, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("NetAmt", "NetAmt", 90, 15, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Charge1", "Charge1", 80, 16, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Charge2", "Charge2", 80, 17, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("ReceivedAmt", "ReceivedAmt", 90, 18, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SalRetAmt", "SalRetAmt", 0, 19, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Cash", "Cash", 60, 20, true, DataGridViewContentAlignment.MiddleLeft, "######0.00"));

            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 21, true));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }

        public void RptSalCumulativeHdr_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("PtyId", "PtyId", 0, 1, true, DataGridViewContentAlignment.MiddleLeft, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Party", "Party", 100, 2, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("SalMan", "SalesMan", 100, 3, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Area", "Area", 100, 4, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("TotAmt", "Total", 80, 5, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Taxper", "Taxper", 0, 6, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("TaxAmt", "TaxAmt", 90, 7, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("DiscPer", "DiscPer", 0, 8, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("DiscAmt", "DiscAmt", 90, 9, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("RndOff", "RndOff", 90, 10, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("NetAmt", "NetAmt", 90, 11, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Charge1", "Charge1", 90, 12, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Charge2", "Charge2", 90, 13, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("ReceivedAmt", "ReceivedAmt", 90, 14, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SalRetAmt", "SalRetAmt", 90, 15, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Cash", "Cash", 60, 16, true, DataGridViewContentAlignment.MiddleLeft, "######0.00"));

            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 17, true));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }

        public DataTable ItemSelect_Source(DateTime FromDt, DateTime ToDt,bool Cond)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_RptItemSelect", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@FDt", SqlDbType.DateTime);
            MyParam.Value = FromDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@TDt", SqlDbType.DateTime);
            MyParam.Value = ToDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Cond", SqlDbType.Bit);
            MyParam.Value = Cond;
            MyCmd.Parameters.Add(MyParam);         

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
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
        public void ItemSelect_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 80, 4, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
          
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }

        public DataTable SubGroupSelect_Source()
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Acc_Qry_SubGrp2Fill", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@SubGrpId1", SqlDbType.Int);
            MyParam.Value =2;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "SubGroupSelect";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }
        public void SubGroupSelect_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("SubgrpId2", "SubgrpId2", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("SubGroupName", "SubGroupName", 80, 4, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }
        # region "StockReport"
        public DataTable RptStockDtRep_Source(DateTime FromDt, DateTime ToDt, string Condition,bool Cumulative)
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

            MyParam = new SqlParameter("@Cumulative", SqlDbType.Bit);
            MyParam.Value = Cumulative;
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

        public void RptStockDtSUOMRep_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("GodownId", "GodownId", 0, 2));
            tmp.Add(CommonView.GetGridViewColumn("GodownName", "GodownName", 80, 3, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 80, 4, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 0, 5, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("OpSQty", "OP", 60, 6, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("PurSQty", "PU", 60, 7, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("InwSQty", "IW", 60, 8, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("StkTSQty", "TT", 60, 9, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("ULSQty", "UL", 60, 10, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SRSQty", "SR", 60, 11, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("MalSalSQty", "MAL", 60, 12, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            //tmp.Add(CommonView.GetGridViewColumn("VanSalSQty", "VanSalQty", 60, 11, true, DataGridViewContentAlignment.MiddleRight, "######0"));
            tmp.Add(CommonView.GetGridViewColumn("StkFSQty", "FT", 60, 13, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("LOSQty", "LO", 60, 14, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("OwSQty", "OW", 60, 15, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("ClSBal", "ClsQty", 70, 16, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SCostValue", "CostValue", 90, 17, true, DataGridViewContentAlignment.MiddleRight, "######0.00")); 
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 18, true, DataGridViewContentAlignment.MiddleLeft, "######0"));
            tmp.Add(CommonView.GetGridViewColumn("OrdBy", "OrdBy", 0, 19, true));
            //tmp.Add(CommonView.GetGridViewColumn("Cost", "CostValue", 70, 14, true, DataGridViewContentAlignment.MiddleRight, "######0"));
            //tmp.Add(CommonView.GetGridViewColumn("SaleCost", "SaleCost", 70, 15, true, DataGridViewContentAlignment.MiddleRight, "######0"));
             
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }

        public void RptStockDtSUOMCumRep_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("GodownId", "GodownId", 0, 2));
            tmp.Add(CommonView.GetGridViewColumn("GodownName", "GodownName", 150, 3, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 80, 4, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("SCostRate", "CostRate", 90, 5, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("ClSBal", "ClosingQty", 90, 6, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SCostValue", "ClosingValue", 100, 7, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 8, true, DataGridViewContentAlignment.MiddleLeft, "######0"));
            tmp.Add(CommonView.GetGridViewColumn("OrdBy", "OrdBy", 0, 9, true));
            //tmp.Add(CommonView.GetGridViewColumn("Cost", "CostValue", 70, 14, true, DataGridViewContentAlignment.MiddleRight, "######0"));
            //tmp.Add(CommonView.GetGridViewColumn("SaleCost", "SaleCost", 70, 15, true, DataGridViewContentAlignment.MiddleRight, "######0"));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }

        public void RptStockDtBUOMRep_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("GodownId", "GodownId", 0, 2));
            tmp.Add(CommonView.GetGridViewColumn("GodownName", "GodownName", 150, 3, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 80, 4, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 0, 5, true, DataGridViewContentAlignment.MiddleLeft));          
            tmp.Add(CommonView.GetGridViewColumn("OpBQty", "OP", 60, 6, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("PurBQty", "PU", 60, 7, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("InwBQty", "IW", 60, 8, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("StkTBQty", "TT", 60, 9, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("ULBQty", "UL", 60, 10, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SRBQty", "SR", 60, 11, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("MalSalBQty", "MAL", 60, 12, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            //tmp.Add(CommonView.GetGridViewColumn("VanSalBQty", "VanQty", 60, 12, true, DataGridViewContentAlignment.MiddleRight, "######0"));
            tmp.Add(CommonView.GetGridViewColumn("StkFBQty", "FT", 60, 13, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("LOBQty", "LO", 60, 14, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("OwBQty", "OW", 60, 15, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("ClBBal", "ClsQty", 70, 16, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("BCostValue", "CostValue", 90, 17, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 18, true, DataGridViewContentAlignment.MiddleLeft, "######0"));
            tmp.Add(CommonView.GetGridViewColumn("OrdBy", "OrdBy", 0, 19, true));
            //tmp.Add(CommonView.GetGridViewColumn("Cost", "CostValue", 70, 14, true, DataGridViewContentAlignment.MiddleRight, "######0"));
            //tmp.Add(CommonView.GetGridViewColumn("SaleCost", "SaleCost", 70, 15, true, DataGridViewContentAlignment.MiddleRight, "######0"));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }
        public void RptStockDtBUOMCumRep_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("GodownId", "GodownId", 0, 2));
            tmp.Add(CommonView.GetGridViewColumn("GodownName", "GodownName", 150, 3, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 80, 4, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("BCostRate", "CostRate", 90, 5, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("ClBBal", "ClosingQty", 90, 6, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("BCostValue", "ClosingValue", 100, 7, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 8, true, DataGridViewContentAlignment.MiddleLeft, "######0"));
            tmp.Add(CommonView.GetGridViewColumn("OrdBy", "OrdBy", 0, 9, true));
            //tmp.Add(CommonView.GetGridViewColumn("Cost", "CostValue", 70, 14, true, DataGridViewContentAlignment.MiddleRight, "######0"));
            //tmp.Add(CommonView.GetGridViewColumn("SaleCost", "SaleCost", 70, 15, true, DataGridViewContentAlignment.MiddleRight, "######0"));

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

            MyCmd = new SqlCommand("Qry_StockLedReport", MyCon);
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

            Tbl.TableName = "Qry_StockLedReport";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return Tbl;
        }

        public void RptSUOMStockLedDet_GridStyle(DataGridViewColumnCollection tmp)
        {
            
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("Id", "Id", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Dt", "Dt", 60, 2, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yy"));
            tmp.Add(CommonView.GetGridViewColumn("Description", "Description", 100, 3, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 0, 4, true, DataGridViewContentAlignment.MiddleLeft));
            //tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 0, 5, true, DataGridViewContentAlignment.MiddleLeft));
            //tmp.Add(CommonView.GetGridViewColumn("GodownName", "Godown", 100, 6, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("SInward", "Inward", 60, 7, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SOutward", "Outward", 60, 8, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));           
            tmp.Add(CommonView.GetGridViewColumn("ClSBal", "ClosingBal", 70, 9, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 10));
            tmp.Add(CommonView.GetGridViewColumn("Flag", "Flag", 0, 11));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 12));
            tmp.Add(CommonView.GetGridViewColumn("OrdBy", "OrdBy", 0, 13));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }

        public void RptBUOMStockLedDet_GridStyle(DataGridViewColumnCollection tmp)
        {

            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("Id", "Id", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Dt", "Dt", 60, 2, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yy"));
            tmp.Add(CommonView.GetGridViewColumn("Description", "Description", 100, 3, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 0, 4, true, DataGridViewContentAlignment.MiddleLeft));
            //tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 0, 5, true, DataGridViewContentAlignment.MiddleLeft));
            //tmp.Add(CommonView.GetGridViewColumn("GodownName", "Godown", 100, 6, true, DataGridViewContentAlignment.MiddleLeft));           
            tmp.Add(CommonView.GetGridViewColumn("BInward", "Inward", 60, 7, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("BOutward", "Outward", 60, 8, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("ClBBal", "ClosingBal", 70, 9, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 10));
            tmp.Add(CommonView.GetGridViewColumn("Flag", "Flag", 0, 11));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 12));
            tmp.Add(CommonView.GetGridViewColumn("OrdBy", "OrdBy", 0, 13));

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
            tmp.Add(CommonView.GetGridViewColumn("PackType", "PackType", 80, 5, true));
            tmp.Add(CommonView.GetGridViewColumn("TaxName", "TaxName", 80, 6, true));
            tmp.Add(CommonView.GetGridViewColumn("Taxper", "Taxper", 80, 7, true));
            
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        # endregion

        #region "BUOMStock Report"
        public DataTable RptBUOMStockDtRep_Source(DateTime FromDt, DateTime ToDt)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_RptBUOMStockDt", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@FromDt", SqlDbType.DateTime);
            MyParam.Value = FromDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@ToDt", SqlDbType.DateTime);
            MyParam.Value = ToDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            //MyParam = new SqlParameter("@Cond", SqlDbType.VarChar, 250);
            //MyParam.Value = Condition;
            //MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_RptBUOMStockDt";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public void RptBUOMStockDtRep_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 150, 2, true, DataGridViewContentAlignment.MiddleLeft,  "", DataGridViewAutoSizeColumnMode.Fill));            
            tmp.Add(CommonView.GetGridViewColumn("OpQty", "OP", 70, 3, true, DataGridViewContentAlignment.MiddleRight, "######0"));
            tmp.Add(CommonView.GetGridViewColumn("INQty", "IN", 70, 4, true, DataGridViewContentAlignment.MiddleRight, "######0"));
            tmp.Add(CommonView.GetGridViewColumn("Total", "TOTAL", 80, 5, true, DataGridViewContentAlignment.MiddleRight, "######0"));
            tmp.Add(CommonView.GetGridViewColumn("VSALQty", "VAN", 80, 6, true, DataGridViewContentAlignment.MiddleRight, "######0"));
            tmp.Add(CommonView.GetGridViewColumn("MSALQty", "MAL", 80, 7, true, DataGridViewContentAlignment.MiddleRight, "######0"));
            tmp.Add(CommonView.GetGridViewColumn("Tot", "TOT", 50, 80, true, DataGridViewContentAlignment.MiddleRight, "######0"));
            tmp.Add(CommonView.GetGridViewColumn("Closing", "Closing", 90, 9, true, DataGridViewContentAlignment.MiddleRight, "######0"));
           // tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 12, true, DataGridViewContentAlignment.MiddleLeft, "######0"));
            //tmp.Add(CommonView.GetGridViewColumn("OrdBy", "OrdBy", 0, 13, true));
            //tmp.Add(CommonView.GetGridViewColumn("Cost", "CostValue", 70, 14, true, DataGridViewContentAlignment.MiddleRight, "######0"));
            //tmp.Add(CommonView.GetGridViewColumn("SaleCost", "SaleCost", 70, 15, true, DataGridViewContentAlignment.MiddleRight, "######0"));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }
        # endregion

        #region "Vehicle Stock Report"
        public DataTable RptVehicleStockDtRep_Source(DateTime FromDt, DateTime ToDt,string Condition,int VehicleId,int SalManId,int RouteId,bool IMode)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_VehicleStockDtReport", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@FromDt", SqlDbType.DateTime);
            MyParam.Value = FromDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@ToDt", SqlDbType.DateTime);
            MyParam.Value = ToDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@VehicleId", SqlDbType.Int);
            MyParam.Value = VehicleId;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@SalManId", SqlDbType.Int);
            MyParam.Value = SalManId;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@RouteId", SqlDbType.Int);
            MyParam.Value = RouteId;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Cond", SqlDbType.VarChar, 250);
            MyParam.Value = Condition;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Est", SqlDbType.Bit);
            MyParam.Value = IMode;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_VehicleStockDtReport";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public void RptVehicleStockDtRep_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 100, 2, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("TaxName", "TaxName", 90, 3, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("OPQty", "Opening", 90, 4, true, DataGridViewContentAlignment.MiddleRight, "######0.000"));
            tmp.Add(CommonView.GetGridViewColumn("LOQty", "Loading", 90,5, true, DataGridViewContentAlignment.MiddleRight, "######0.000"));
            tmp.Add(CommonView.GetGridViewColumn("VSalQty", "Van Sales", 90,6, true, DataGridViewContentAlignment.MiddleRight, "######0.000"));
            tmp.Add(CommonView.GetGridViewColumn("ULQty", "UnLoading", 90, 7, true, DataGridViewContentAlignment.MiddleRight, "######0.000"));
            tmp.Add(CommonView.GetGridViewColumn("SRQty", "S.Return", 90, 8, true, DataGridViewContentAlignment.MiddleRight, "######0.000"));
            tmp.Add(CommonView.GetGridViewColumn("ClBal", "Closing", 90, 9, true, DataGridViewContentAlignment.MiddleRight, "######0.000"));
            tmp.Add(CommonView.GetGridViewColumn("ClsValue", "Cls.Value", 90, 10, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 11, true, DataGridViewContentAlignment.MiddleLeft, "######0"));
            tmp.Add(CommonView.GetGridViewColumn("OrdBy", "OrdBy", 0, 12, true));
            tmp.Add(CommonView.GetGridViewColumn("SSaleRate", "SSaleRatee", 0, 13, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            //tmp.Add(CommonView.GetGridViewColumn("Cost", "CostValue", 70, 14, true, DataGridViewContentAlignment.MiddleRight, "######0"));
            //tmp.Add(CommonView.GetGridViewColumn("SaleCost", "SaleCost", 70, 15, true, DataGridViewContentAlignment.MiddleRight, "######0"));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }

        public DataTable VehicleSales_Source()
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            //MyCmd = new SqlCommand("Qry_SalItemSelect", MyCon);
            //MyCmd.CommandType = CommandType.StoredProcedure;

            MyCmd = new SqlCommand("Qry_Vehicle", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "VehicleSource";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public int VehicleSalesSource_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("VehicleId", "VehicleId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("VehicleNo", "VehicleNo", 90, 2, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("VehicleName", "VehicleName", 0, 3));
            tmp.Add(CommonView.GetGridViewColumn("SalManId", "SalManId", 0, 4));
            tmp.Add(CommonView.GetGridViewColumn("SalMan", "SalMan", 90, 5, true));
            tmp.Add(CommonView.GetGridViewColumn("RouteId", "RouteId", 0, 6));
            tmp.Add(CommonView.GetGridViewColumn("Route", "Route", 90, 7, true));
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 8, true));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 9, true));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

        public DataTable SalesMan_Source()
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_SalMan", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@SalManId", SqlDbType.Int);
            MyParam.Value = 0;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "SalManSelect";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public int SalesMan_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("SalManId", "SalManId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("SalManName", "SalManName", 100, 2, true));
            tmp.Add(CommonView.GetGridViewColumn("Age", "Age", 0, 3));
            tmp.Add(CommonView.GetGridViewColumn("DesigId", "DesigId", 0, 4));
            tmp.Add(CommonView.GetGridViewColumn("Designation", "Designation", 90, 5, true));
            tmp.Add(CommonView.GetGridViewColumn("DOJ", "DOJ", 0, 6, true));
            tmp.Add(CommonView.GetGridViewColumn("DOR", "DOR", 0, 7, true));
            tmp.Add(CommonView.GetGridViewColumn("RouteId", "RouteId", 0, 8, true));
            tmp.Add(CommonView.GetGridViewColumn("RouteName", "RouteName", 0, 9, true));
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 10, true));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 11, true));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

        public DataTable RouteSales_Source()
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_Route", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "RouteSelect";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public int RouteSales_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("RouteId", "RouteId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("RouteName", "RouteName", 100, 2, true));
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 3, true));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 4, true));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

        public DataTable Godown_Source()
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_Godown", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;
        
            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Godown";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }
        public int Godown_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("GodownId", "GodownId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("GodownName", "Godown", 100, 2, true));
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 3, true));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 4, true));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

        # endregion

        # region "TaxStockReport"
        public DataTable RptStockTaxDtRep_Source(DateTime FromDt, DateTime ToDt, string Condition)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_StockTaxDtReport", MyCon);
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

            //MyParam = new SqlParameter("@Cumulative", SqlDbType.Bit);
            //MyParam.Value = Cumulative;
            //MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_StockTaxDtReport";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }    

        public void RptStockTaxDtSUOMRep_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("GodownId", "GodownId", 0, 2));
            tmp.Add(CommonView.GetGridViewColumn("GodownName", "GodownName", 150, 3, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 80, 4, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("TaxName", "TaxName", 150, 5, true, DataGridViewContentAlignment.MiddleLeft,""));
            tmp.Add(CommonView.GetGridViewColumn("SCostRate", "CostRate", 90, 6, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("ClSBal", "ClosingQty", 90, 7, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SCostValue", "ClosingValue", 100, 8, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 9, true, DataGridViewContentAlignment.MiddleLeft, "######0"));
            tmp.Add(CommonView.GetGridViewColumn("OrdBy", "OrdBy", 0, 10, true));
            //tmp.Add(CommonView.GetGridViewColumn("Cost", "CostValue", 70, 14, true, DataGridViewContentAlignment.MiddleRight, "######0"));
            //tmp.Add(CommonView.GetGridViewColumn("SaleCost", "SaleCost", 70, 15, true, DataGridViewContentAlignment.MiddleRight, "######0"));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }

        public void RptStockTaxDtBUOMRep_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("GodownId", "GodownId", 0, 2));
            tmp.Add(CommonView.GetGridViewColumn("GodownName", "GodownName", 150, 3, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 80, 4, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("TaxName", "TaxName", 150, 5, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("BCostRate", "CostRate", 90, 6, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("ClBBal", "ClosingQty", 90, 7, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("BCostValue", "ClosingValue", 100, 8, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 9, true, DataGridViewContentAlignment.MiddleLeft, "######0"));
            tmp.Add(CommonView.GetGridViewColumn("OrdBy", "OrdBy", 0, 10, true));
            //tmp.Add(CommonView.GetGridViewColumn("Cost", "CostValue", 70, 14, true, DataGridViewContentAlignment.MiddleRight, "######0"));
            //tmp.Add(CommonView.GetGridViewColumn("SaleCost", "SaleCost", 70, 15, true, DataGridViewContentAlignment.MiddleRight, "######0"));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }
      
        #endregion
    }
}
