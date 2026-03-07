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
    public class RptAgewiseOutstandingDB
    {
        public RptAgewiseOutstandingDB()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        # region "AgewiseOutstandingCreditSale"

        public DataTable CustomerSelect_Source(DateTime tilDate)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_AgeWiseRpt", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Dt", SqlDbType.DateTime);
            MyParam.Value = tilDate.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

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
        public DataTable AgewiseOutstandingCreditSale_Source(int AccId,DateTime tilDate)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("qry_AgewiseCreditSales", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@accid", SqlDbType.Int);
            MyParam.Value = AccId;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@TranDt", SqlDbType.DateTime);
            MyParam.Value = tilDate.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "CreditSales";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }
        public DataTable AgewiseRecSale_Source(int AccId,DateTime tilDate)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("qry_AgewiseCreditSalesReceipt", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@accid", SqlDbType.Int);
            MyParam.Value = AccId;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@TranDt", SqlDbType.DateTime);
            MyParam.Value = tilDate.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "ReceiptSales";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        //public int AgewiseOutstandingCreditSale_GridStyle(DataGridViewColumnCollection tmp)
        //{
        //    tmp.Clear();
        //    tmp.Add(CommonView.GetGridViewColumn("DocrefId", "DocrefId", 0, 1));
        //    tmp.Add(CommonView.GetGridViewColumn("Docref", "Docref", 0, 2, true, DataGridViewContentAlignment.MiddleLeft, ""));
        //    tmp.Add(CommonView.GetGridViewColumn("TranDt", "TranDt", 0, 3, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));
        //    tmp.Add(CommonView.GetGridViewColumn("AccId", "AccId", 0, 4));
        //    tmp.Add(CommonView.GetGridViewColumn("Accode", "Accode", 0, 5));
        //    tmp.Add(CommonView.GetGridViewColumn("Party", "Party", 120, 6, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
        //    tmp.Add(CommonView.GetGridViewColumn("Area", "Area", 140, 7, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
        //    tmp.Add(CommonView.GetGridViewColumn("Amount", "Amount", 150, 8, true, DataGridViewContentAlignment.MiddleLeft, "#####0.00"));
        //    tmp.Add(CommonView.GetGridViewColumn("DrCr", "DrCr", 0, 9));
        //    tmp.Add(CommonView.GetGridViewColumn("30days", "0-30 Days", 120, 10, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
        //    tmp.Add(CommonView.GetGridViewColumn("45days", "30-45 Days", 120, 11, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
        //    tmp.Add(CommonView.GetGridViewColumn("60days", "45-60 Days", 120, 12, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
        //    tmp.Add(CommonView.GetGridViewColumn("90days", "60-90 Days", 120, 13, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
        //    tmp.Add(CommonView.GetGridViewColumn("120days", "90-120 Days", 120, 14, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
        //    tmp.Add(CommonView.GetGridViewColumn("A120days", ">120 Days", 120, 15, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
        //   // tmp.Add(CommonView.GetGridViewColumn("recsale", "recsale", 120, 14, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
        //    tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

        //    return 0;
        //}
        public int AgewiseOutstandingCreditSale_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("DocrefId", "DocrefId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Docref", "Docref", 0, 2, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("TranDt", "TranDt", 0, 3, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));
            tmp.Add(CommonView.GetGridViewColumn("AccId", "AccId", 0, 4));
            tmp.Add(CommonView.GetGridViewColumn("Accode", "Accode", 0, 5));
            tmp.Add(CommonView.GetGridViewColumn("Party", "Party", 120, 6, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Area", "Area", 140, 7, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("City", "City", 0, 7, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Amount", "Amount", 100, 8, true, DataGridViewContentAlignment.MiddleLeft, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("DrCr", "DrCr", 0, 9));
            tmp.Add(CommonView.GetGridViewColumn("Days1", "0-30 Days", 120, 10, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Days2", "30-45 Days", 120, 11, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Days3", "45-60 Days", 120, 12, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Days4", "60-90 Days", 120, 13, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Days5", "90-120 Days", 120, 14, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Days6", ">120 Days", 120, 15, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            // tmp.Add(CommonView.GetGridViewColumn("recsale", "recsale", 120, 14, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        public DataTable AgewiseGrouping_Source(DataTable Dt)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();
            DataSet Ds = new DataSet();
            string DetStr;
            Ds.Tables.Add(Dt);

            DetStr = Ds.GetXml();
            DetStr = DetStr.Replace("'", "''");
            DetStr = DetStr.Replace("true", "1");
            DetStr = DetStr.Replace("false", "0");
            if (DetStr.IndexOf("T00:00:00") != -1)
                DetStr = DetStr.Replace(DetStr.Substring(DetStr.IndexOf("T00:00:00"), 15), "");
            Ds.Tables.Clear();
            Ds.Tables.Clear();
            Ds.Dispose();


            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_RptAgeGrouping", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@DetStr", SqlDbType.Text);
            MyParam.Value = DetStr;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "AgeGroup";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }     
        #endregion

        # region "Supplier Source"
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
            tmp.Add(CommonView.GetGridViewColumn("Customer", "Customer", 100, 4, true));
            tmp.Add(CommonView.GetGridViewColumn("AcCode", "AcCode", 0, 3));
            tmp.Add(CommonView.GetGridViewColumn("Add1", "Address", 80, 4, true));
            tmp.Add(CommonView.GetGridViewColumn("Add2", "Address1", 80, 5, true));
            tmp.Add(CommonView.GetGridViewColumn("Add3", "Address2", 80, 6, true));
            tmp.Add(CommonView.GetGridViewColumn("City", "City", 80, 7, true));
            tmp.Add(CommonView.GetGridViewColumn("Pincode", "Pincode", 80, 8, true));
            tmp.Add(CommonView.GetGridViewColumn("Ph1", "Phone", 80, 9, true));
            tmp.Add(CommonView.GetGridViewColumn("Ph2", "Phone1", 80, 10, true));
            tmp.Add(CommonView.GetGridViewColumn("TransportId", "TransportId", 0, 11));
            tmp.Add(CommonView.GetGridViewColumn("Name", "Name", 0, 12));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }


        #endregion
     
    }
}
