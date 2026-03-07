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
    public class RptRegDB
    {
        public RptRegDB()
        {
            //
            // TODO: Add constructor logic here
            //
        }
         # region "Receipt"
        public DataTable RptRec_Source(DateTime Fdt, DateTime TDt, string Cond)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_ReceiptReg", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@FrmDt", SqlDbType.DateTime);
            MyParam.Value = Fdt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@ToDt", SqlDbType.DateTime);
            MyParam.Value = TDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("Cond", SqlDbType.VarChar,100);
            MyParam.Value = Cond;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_ReceiptReg";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public int RptRec_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("RecId", "RecId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("RecNo", "RecNo", 80, 2));//, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));

            tmp.Add(CommonView.GetGridViewColumn("RecDt", "RecDt", 80, 3, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));
            tmp.Add(CommonView.GetGridViewColumn("CashRecNo", "CashRecNo", 80, 4));
            tmp.Add(CommonView.GetGridViewColumn("PartyName", "PartyName", 120, 5, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("LedgerName", "LedgerName", 150, 6, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Area", "Area", 90, 7, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("ChqNo", "ChqNo", 80, 8, true, DataGridViewContentAlignment.MiddleRight, ""));
            tmp.Add(CommonView.GetGridViewColumn("ChqDt", "ChqDt", 80, 9, true, DataGridViewContentAlignment.MiddleRight, ""));
            tmp.Add(CommonView.GetGridViewColumn("CashDisc", "CashDisc", 80, 10, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Commission", "Commission", 80, 11, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("NetAmt", "NetAmt", 100, 12, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 13));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 14));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 15));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
       
        #endregion

        # region "Payment"
        public DataTable RptPay_Source(DateTime Fdt, DateTime TDt, string Cond)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_PaymentReg", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@FrmDt", SqlDbType.DateTime);
            MyParam.Value = Fdt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@ToDt", SqlDbType.DateTime);
            MyParam.Value = TDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("Cond", SqlDbType.VarChar, 100);
            MyParam.Value = Cond;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_PaymentReg";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public int RptPay_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("PayId", "PayId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("PayNo", "PayNo", 80, 2));//, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));

            tmp.Add(CommonView.GetGridViewColumn("PayDt", "PayDt", 80, 3, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));
            
            tmp.Add(CommonView.GetGridViewColumn("PartyName", "PartyName", 120, 4, true, DataGridViewContentAlignment.MiddleLeft, "",DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("LedgerName", "LedgerName", 150, 5, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Area", "Area", 90, 6, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("ChqNo", "ChqNo", 80, 7, true, DataGridViewContentAlignment.MiddleRight, ""));
            tmp.Add(CommonView.GetGridViewColumn("ChqDt", "ChqDt", 80, 8, true, DataGridViewContentAlignment.MiddleRight, ""));
            tmp.Add(CommonView.GetGridViewColumn("CashDisc", "CashDisc", 80, 9, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Commission", "Commission", 80, 10, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("NetAmt", "NetAmt", 100, 11, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 12));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 13));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 14));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
          #endregion

        # region "Journal"
        public DataTable RptJournal_Source(DateTime Fdt, DateTime TDt, string Cond)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_JournalReg", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@FrmDt", SqlDbType.DateTime);
            MyParam.Value = Fdt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@ToDt", SqlDbType.DateTime);
            MyParam.Value = TDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("Cond", SqlDbType.VarChar, 100);
            MyParam.Value = Cond;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_JournalReg";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public int RptJournal_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("JouId", "JouId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("DocNo", "DocNo", 80, 2));//, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("DocDt", "DocDt", 80, 3, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));
            tmp.Add(CommonView.GetGridViewColumn("AccId", "AccId", 0, 4));
            tmp.Add(CommonView.GetGridViewColumn("LedgerHead", "LedgerHead", 120, 5, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Nar1", "Narration", 150, 6, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Credit", "Credit", 100, 7, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Debit", "Debit", 100, 8, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("DocType", "DocType", 0, 9, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 10));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 11));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 12));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        #endregion

        # region "Contra"
        public DataTable RptContra_Source(DateTime Fdt, DateTime TDt, string Cond)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_ContraReg", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@FrmDt", SqlDbType.DateTime);
            MyParam.Value = Fdt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@ToDt", SqlDbType.DateTime);
            MyParam.Value = TDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("Cond", SqlDbType.VarChar, 100);
            MyParam.Value = Cond;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_ContraReg";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public int RptContra_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("JouId", "JouId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("DocNo", "DocNo", 80, 2));//, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("DocDt", "DocDt", 80, 3, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));
            tmp.Add(CommonView.GetGridViewColumn("AccId", "AccId", 0, 4));
            tmp.Add(CommonView.GetGridViewColumn("LedgerHead", "LedgerHead", 120, 5, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Nar1", "Narration", 150, 6, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Credit", "Credit", 100, 7, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Debit", "Debit", 100, 8, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("DocType", "DocType", 0, 9, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 10));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 11));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 12));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        #endregion

    }
}
