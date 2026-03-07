using System;
using System.Data;
using System.Data.SqlClient;
using GridStructures;
using DBAccess;
using RLPOSDB;
using System.Windows.Forms;

namespace RLPOSDB
{
	/// <summary>
	/// Summary description for RptStockLedDB.
	/// </summary>
    public class RptAgewiseDB
    {
        public RptAgewiseDB()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region "Report Section - SalesDetail"
        public DataTable Agewise_Source(DateTime dt)
        //public DataTable Agewise(DateTime dt, char Mode)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("qry_rptagewiseoutstanding", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@dt", SqlDbType.DateTime);
            MyParam.Value = dt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);


            //MyParam = new SqlParameter("@Mode", SqlDbType.Char,1);
            //MyParam.Value = Mode;
            //MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_RptAgewise";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
                   
        }
        public int Agewise_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("PtyName", "PtyName", 200, 1, true,DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Amount", "Amount", 150, 2, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Days0_30", "0_30 Days", 120, 3, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Days30_45", "30-45 Days", 120, 4, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Days45_60", "45-60 Days", 120, 5, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Days60_90", "60-90 Days", 120, 6, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Days90_120", "90-120 Days", 120, 7, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("DaysAbove120", ">120 Days", 120, 8, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            //tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
            return 0;
        }

        # endregion

        #region "Report Section - PurchaseDetail"
        public DataTable AgewiseSupplier_Source(DateTime dt)
        //public DataTable Agewise(DateTime dt, char Mode)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_RptAgewiseSupOutstanding", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@dt", SqlDbType.DateTime);
            MyParam.Value = dt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);


            //MyParam = new SqlParameter("@Mode", SqlDbType.Char,1);
            //MyParam.Value = Mode;
            //MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_RptSupAgewise";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;

        }
        public int AgewiseSupplier_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("PtyName", "Supplier", 200, 1, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Amount", "Amount", 150, 2, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Days0_30", "0_30 Days", 120, 3, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Days30_45", "30-45 Days", 120, 4, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Days45_60", "45-60 Days", 120, 5, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Days60_90", "60-90 Days", 120, 6, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Days90_120", "90-120 Days", 120, 7, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("DaysAbove120", ">120 Days", 120, 8, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            //tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
            return 0;
        }

        # endregion
    }
}
