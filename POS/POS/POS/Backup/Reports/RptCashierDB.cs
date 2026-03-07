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
    public class RptCashierDB
    {
        public RptCashierDB()
        {
            //
            // TODO: Add constructor logic here
            //
        }
 

  

       # region "Cashier"
        public DataTable RptCashier_Source(DateTime Fdt, DateTime TDt,bool Cumulative,int Estimation)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_RptCashier", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Frmdt", SqlDbType.DateTime);
            MyParam.Value = Fdt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@ToDt", SqlDbType.DateTime);
            MyParam.Value = TDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Cumulative", SqlDbType.Bit);
            MyParam.Value = (Cumulative == true ? 1 : 0);
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Est", SqlDbType.Int);
            MyParam.Value = Estimation;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_RptCashier";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public void RptCashier_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("SalId", "SalId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Username", "Username", 100, 2, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("BillNo", "BillNo", 0, 3, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("BillRefNo", "BillNo", 80,4, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("BillDt", "BillDt", 80, 5, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));                      
            tmp.Add(CommonView.GetGridViewColumn("NetAmt", "NetAmount", 80, 6, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            //tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 10, true, DataGridViewContentAlignment.MiddleLeft, "######0.00"));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }
        public void RptCashierCumm_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("SalId", "SalId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Username", "Username", 100, 2, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
          
            tmp.Add(CommonView.GetGridViewColumn("BillDt", "BillDt", 80, 4, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));
            
            tmp.Add(CommonView.GetGridViewColumn("NetAmt", "NetAmount", 80, 6, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            //tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 10, true, DataGridViewContentAlignment.MiddleLeft, "######0.00"));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }


        #endregion

        # region "Fast-Moving Sales"
        public DataTable RptFastMove_Source(int Count,DateTime Fdt, DateTime TDt)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_RptFastMoving", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Count", SqlDbType.Int);
            MyParam.Value = Count;
            MyCmd.Parameters.Add(MyParam);


            MyParam = new SqlParameter("@FrmDt", SqlDbType.DateTime);
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

            DTbl.TableName = "Qry_RptFastMoving";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public void RptFastMove_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("ItemCode", "ItemCode", 90, 1));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 100, 2, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));

            tmp.Add(CommonView.GetGridViewColumn("NoOfTimesSold", "NoOfTimesSold", 85, 3, true, DataGridViewContentAlignment.MiddleRight, "######0"));

            tmp.Add(CommonView.GetGridViewColumn("TotalQtySold", "TotalQtySold", 80, 4, true, DataGridViewContentAlignment.MiddleRight, "######0"));
            //tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 10, true, DataGridViewContentAlignment.MiddleLeft, "######0.00"));
            //tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }

#endregion

        # region "Slow-Moving Sales"
        public DataTable RptSlowMove_Source(int Count, DateTime Fdt, DateTime TDt)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_RptSlowMoving", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Count", SqlDbType.Int);
            MyParam.Value = Count;
            MyCmd.Parameters.Add(MyParam);


            MyParam = new SqlParameter("@FrmDt", SqlDbType.DateTime);
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

            DTbl.TableName = "Qry_RptSlowMoving";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public void RptSlowMove_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("ItemCode", "ItemCode", 90, 1));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 100, 2, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("NoOfTimesSold", "NoOfTimesSold", 85, 3, true, DataGridViewContentAlignment.MiddleRight, "######0"));
            tmp.Add(CommonView.GetGridViewColumn("TotalQtySold", "TotalQtySold", 80, 4, true, DataGridViewContentAlignment.MiddleRight, "######0"));
            //tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 10, true, DataGridViewContentAlignment.MiddleLeft, "######0.00"));
            //tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }

        #endregion

        # region "Profit"
        public DataTable RptProfit_Source( DateTime Fdt, DateTime TDt)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_RptProfit", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;



            MyParam = new SqlParameter("@FrmDt", SqlDbType.DateTime);
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

            DTbl.TableName = "Qry_RptProfit";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public void RptProfit_GridStyle(DataGridViewColumnCollection tmp)
        {

            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 50, 1));
            tmp.Add(CommonView.GetGridViewColumn("Billno", "Billno", 50, 2));
            tmp.Add(CommonView.GetGridViewColumn("ItemCode", "ItemCode", 50, 3));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 100, 4, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Qty", "Qty", 60,5, true, DataGridViewContentAlignment.MiddleRight, "######0.000"));
            tmp.Add(CommonView.GetGridViewColumn("Purrate", "PurValue", 85, 6, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            //tmp.Add(CommonView.GetGridViewColumn("PurConvFact", "PurConvFact", 0, 7, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            //tmp.Add(CommonView.GetGridViewColumn("PuRate", "Convtd.PurRate", 80, 8, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Salerate", "SaleValue", 85, 9, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            //tmp.Add(CommonView.GetGridViewColumn("Salconvact", "Salconvact", 0, 10, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
           
            //tmp.Add(CommonView.GetGridViewColumn("SaRate", "Convtd.SalRate", 80, 11, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Profit", "Profit", 80, 12, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            //tmp.Add(CommonView.GetGridViewColumn("TotalProfit", "TotalProfit", 80, 13, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }

        #endregion


        # region "MinimumStock"
        public DataTable RptMinstk_Source()
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_MinStk", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;


            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_MinStk";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public void RptMinstk_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 50, 1));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 100, 2, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("stkqty", "StkQty", 85, 3, true, DataGridViewContentAlignment.MiddleRight, "######0.000"));
            tmp.Add(CommonView.GetGridViewColumn("Minstock", "Minstock", 80, 4, true, DataGridViewContentAlignment.MiddleRight, "######0.000"));         
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }

        #endregion

        # region "TotalSales"
        public DataTable RptTotalSale_Source(DateTime Fdt, DateTime TDt,int Est)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_RptTotalSales", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;
                        
            MyParam = new SqlParameter("@FrmDt", SqlDbType.DateTime);
            MyParam.Value = Fdt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@ToDt", SqlDbType.DateTime);
            MyParam.Value = TDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Est", SqlDbType.Int);
            MyParam.Value = Est;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_RptTotalSales";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public void RptTotalSale_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("Salid", "Salid", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("BillNo", "BillNo", 150, 2, true, DataGridViewContentAlignment.MiddleLeft , ""));
            tmp.Add(CommonView.GetGridViewColumn("BillDt", "BillDt", 100, 3, true, DataGridViewContentAlignment.MiddleRight, "dd/MMM/yyyy"));
            tmp.Add(CommonView.GetGridViewColumn("NetAmt", "NetAmt", 100, 4, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }

        #endregion
    }
}
