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
    public class RptSalMenIncentiveDB
    {
        public RptSalMenIncentiveDB()
        {
            //
            // TODO: Add constructor logic here
            //
        }
         
        # region "Sales"
        public DataTable RptSalesmanIncHdr_Source(DateTime Fdt, DateTime TDt, int salesmanid,string cond)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_RptSMIncentive", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@FrmDt", SqlDbType.DateTime);
            MyParam.Value = Fdt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@toDt", SqlDbType.DateTime);
            MyParam.Value = TDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@SalesManId", SqlDbType.Int);
            MyParam.Value =salesmanid;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Cond", SqlDbType.VarChar,50);
            MyParam.Value = cond;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_RptSMIncentive";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public DataTable RptSalesmanIncDetail_Source(DateTime Fdt, DateTime TDt, int salesmanid,bool Cumulative, string Condition)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_RptSMIncentiveDetail", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@FrmDt", SqlDbType.DateTime);
            MyParam.Value = Fdt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@toDt", SqlDbType.DateTime);
            MyParam.Value = TDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@SalesManId", SqlDbType.Int);
            MyParam.Value = salesmanid;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Cumulative", SqlDbType.Bit);
            MyParam.Value = Cumulative;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Cond", SqlDbType.VarChar, 50);
            MyParam.Value = Condition;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "RptSMIncentiveDetail";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public void RptSalesmanIncHdr_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("SalManId", "SalManId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("SalesMan", "SalesMan", 150, 2, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Party", "Party", 80, 3, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Cell", "Cell", 80, 4, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Total", "Total", 100, 5, true, DataGridViewContentAlignment.MiddleLeft, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("IncTot", "Incentive Total", 75, 6, true, DataGridViewContentAlignment.MiddleLeft,"#0.00",DataGridViewAutoSizeColumnMode.Fill ));
            tmp.Add(CommonView.GetGridViewColumn("DocRef", "DocRef", 0, 7, true));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 8, true));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }
        public DataTable Salesman_Source()
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_Employee", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "SalesMan";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }
        public int Salesman_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();

            tmp.Add(CommonView.GetGridViewColumn("EmpId", "EmpId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Employee", "SalesMan", 120, 2, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
           // tmp.Add(CommonView.GetGridViewColumn("UserName", "UserName", 0, 3));
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 4));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 5));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
            return 0;
        }

        public void RptSalesmanIncDetail_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("SalId", "SalId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("BillNo", "BillNo", 40, 2, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("BillDt", "BillDt", 60, 3, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yy"));
            tmp.Add(CommonView.GetGridViewColumn("SalManId", "SalManId", 0, 4));
            tmp.Add(CommonView.GetGridViewColumn("Salesman", "Salesman", 80, 5, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("PtyName", "Party", 150, 6, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("Cell", "Cell", 80, 7, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 100,8, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 100, 9, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Qty", "Qty", 30, 10, true, DataGridViewContentAlignment.MiddleRight, "######0"));
            tmp.Add(CommonView.GetGridViewColumn("Amount", "Amount", 60, 11, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("IncPer", "Inc%", 40, 12, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("IncAmt", "IncAmt", 50, 13, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("IncTot", "IncTot", 50, 14, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 15));
            tmp.Add(CommonView.GetGridViewColumn("DocRef", "DocRef", 0, 16, true));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }

        public void RptSalesmanIncCumulative_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("SalManId", "SalManId", 0, 1));          
            tmp.Add(CommonView.GetGridViewColumn("BillDt", "BillDt", 60, 2, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yy"));           
            tmp.Add(CommonView.GetGridViewColumn("Salesman", "Salesman", 80, 3, true, DataGridViewContentAlignment.MiddleLeft));          
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 100, 4, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 100, 5, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Qty", "Qty", 50, 6, true, DataGridViewContentAlignment.MiddleRight, "######0"));
            tmp.Add(CommonView.GetGridViewColumn("Free", "Free", 50,7, true, DataGridViewContentAlignment.MiddleRight, "######0"));
            tmp.Add(CommonView.GetGridViewColumn("Amount", "Amount", 60, 8, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));                      
            tmp.Add(CommonView.GetGridViewColumn("IncTot", "IncTot", 60, 9, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
         
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }

        public DataTable RptOutstandingWithItemwise_Source(int Accid, DateTime Fdt, DateTime TDt)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_RptOutstanding_WithItemwise", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Accid", SqlDbType.Int);
            MyParam.Value = Accid;
            MyCmd.Parameters.Add(MyParam);

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

            DTbl.TableName = "Qry_RptOutstanding_WithItemwise";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public void RptOutstandingWithItemwise_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("ITemName", "ITemName", 100, 1));
            tmp.Add(CommonView.GetGridViewColumn("TamilName", "TamilName", 100, 2, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Qty", "Qty", 60, 3, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Wt", "Wt", 60, 4, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Rate", "Rate", 60, 5, true, DataGridViewContentAlignment.MiddleRight, "#0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Amount", "Amount", 75, 6, true, DataGridViewContentAlignment.MiddleRight, "#0.00"));
            tmp.Add(CommonView.GetGridViewColumn("PtyId", "PtyId", 0, 7));
            tmp.Add(CommonView.GetGridViewColumn("Customer", "Customer", 200, 8, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Add1", "Add1", 80, 9, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Add2", "Add2", 0, 10, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Add3", "Add3", 0, 11, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("City", "City", 80, 12, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Area", "Area", 0, 13, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("SalMan", "SalMan", 0, 14, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Cell", "Cell", 80, 15, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Salid", "Salid", 0, 16, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("BillNo", "BillNo", 70, 17, true));
            tmp.Add(CommonView.GetGridViewColumn("BillDt", "BillDt", 70, 18, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));
            tmp.Add(CommonView.GetGridViewColumn("BillRefNo", "BillRefNo", 0, 19, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("DocRef", "DocRef", 0, 20, true, DataGridViewContentAlignment.MiddleRight, ""));
            tmp.Add(CommonView.GetGridViewColumn("BillAmt", "BillAmt", 100, 21, true, DataGridViewContentAlignment.MiddleRight, "####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("PaidAmt", "PaidAmt", 75, 22, true, DataGridViewContentAlignment.MiddleRight, "#0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Balance", "Balance", 80, 23, true));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 24, true));
            // tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = true;
        }
        public DataTable Customer_Source()
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_Customer", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "CustomerSelect";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public int Customer_GridStyle(DataGridViewColumnCollection tmp)
        {

            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("Accid", "Accid", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Customer", "Customer", 200, 2, true));
            tmp.Add(CommonView.GetGridViewColumn("AcCode", "AcCode", 0, 3));
            tmp.Add(CommonView.GetGridViewColumn("Add1", "Address", 80, 4, true));
            tmp.Add(CommonView.GetGridViewColumn("Add2", "Address1", 80, 5, true));
            tmp.Add(CommonView.GetGridViewColumn("Add3", "Address2", 80, 6, true));
            tmp.Add(CommonView.GetGridViewColumn("City", "City", 80, 7, true));
            tmp.Add(CommonView.GetGridViewColumn("Pincode", "Pincode", 80, 8, true));
            tmp.Add(CommonView.GetGridViewColumn("Ph1", "Phone", 80, 9, true));
            tmp.Add(CommonView.GetGridViewColumn("Ph2", "Phone1", 80, 10, true));
            tmp.Add(CommonView.GetGridViewColumn("TransportId", "TransportId", 0, 11));
            tmp.Add(CommonView.GetGridViewColumn("TransPort", "TransPort", 0, 12));
            tmp.Add(CommonView.GetGridViewColumn("Cell", "Cell", 0, 13));
            tmp.Add(CommonView.GetGridViewColumn("Tin", "Tin", 0, 14));
            tmp.Add(CommonView.GetGridViewColumn("Area", "Area", 0, 15));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

        #endregion
       

    }
}
