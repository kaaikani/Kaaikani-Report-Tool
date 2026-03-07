using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using GridStructures;
using DBAccess;
using AccountsDB;

namespace AccountsDB
{
    public class TrialBalanceDB
    {
        #region "First"

        private bool disposed = false;

        #endregion

        #region "Property"

        public DateTime FetchFromDt(string Month, int Accode)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();
            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Acc_Qry_FromDtFn", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Month", SqlDbType.VarChar, 15);
            MyParam.Value = Month;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@AccId", SqlDbType.Int);
            MyParam.Value = Accode;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "RecDet";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return ((DTbl.Rows[0][0].ToString() == "") ? DateTime.Now.Date : (DateTime)DTbl.Rows[0][0]);
            //return DTbl;
        }

        public DateTime FetchToDt(string Month, int Accode)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();


            MyCmd = new SqlCommand("Acc_Qry_ToDtFn", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Month", SqlDbType.VarChar, 15);
            MyParam.Value = Month;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@AccId", SqlDbType.Int);
            MyParam.Value = Accode;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "RecDet";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return ((DTbl.Rows[0][0].ToString() == "") ? DateTime.Now.Date : (DateTime)DTbl.Rows[0][0]);
        }
        public double OpBal(DateTime FromDt, int Accode)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();


            MyCmd = new SqlCommand("Acc_Qry_OpBalance", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Dt", SqlDbType.DateTime);
            MyParam.Value = FromDt;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@AccId", SqlDbType.Int);
            MyParam.Value = Accode;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "TrBalRpt";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return ((DTbl.Rows[0][0] == null) ? 0 : (double)DTbl.Rows[0][0]);
        }
        #endregion
        # region "GetConfig"
        public Boolean GetConfigValuefor(int ConfigId)
        {
            Boolean Result;
            SqlConnection Con = new SqlConnection(Common.ConStr);
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Config_Qry_Getbitvalue", Con);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("@ConfigId", SqlDbType.Int);
            param.Value = ConfigId;
            Cmd.Parameters.Add(param);
            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Result = Convert.ToBoolean(Cmd.ExecuteScalar());

            Cmd.Dispose();
            Con.Close();
            return Result;
        }
        # endregion
    
        # region "TrBalGrp"


        public DataTable TrbalGrpDs(DateTime Dt)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();


            MyCmd = new SqlCommand("Acc_Qry_TrBalrptgrpLed", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;
            MyParam = new SqlParameter("@UpDt", SqlDbType.DateTime);
            MyParam.Value = Dt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "TrBalRpt";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }
        public void TrBalGrpDs_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            Boolean DrCr;
            DrCr = GetConfigValuefor(38);
            tmp.Add(CommonView.GetGridViewColumn("Ledger", "Ledger", 510, 1, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            if (DrCr == true)
            {
                tmp.Add(CommonView.GetGridViewColumn("Debit", "Debit", 100, 2, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
                tmp.Add(CommonView.GetGridViewColumn("Credit", "Credit", 100, 3, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));

            }
            else
            {
              tmp.Add(CommonView.GetGridViewColumn("Credit", "Credit", 100, 2, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
              tmp.Add(CommonView.GetGridViewColumn("Debit", "Debit", 100,3, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            }

            tmp.Add(CommonView.GetGridViewColumn("AccId", "AccId", 0, 4));
            tmp.Add(CommonView.GetGridViewColumn("Accode", "Accode", 0, 5));
            tmp.Add(CommonView.GetGridViewColumn("SubGrpId", "SubGrpId", 0, 6));
            tmp.Add(CommonView.GetGridViewColumn("subGroupName", "subGroupName", 0, 7));
            tmp.Add(CommonView.GetGridViewColumn("SubGrpId1", "SubGrpId", 0, 8));
            tmp.Add(CommonView.GetGridViewColumn("SubGrpId2", "SubGrpId", 0, 9));
            tmp.Add(CommonView.GetGridViewColumn("SubLvl", "SubLvl", 0, 10));
            tmp.Add(CommonView.GetGridViewColumn("updownno", "num", 0, 11));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 12));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = true;
        }

        # endregion

        # region "TrBalLed"
        
        public DataTable  TrbalLedDs(DateTime Dt)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();


            MyCmd = new SqlCommand("Acc_Qry_TrBalRptLed", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;
            MyParam = new SqlParameter("@UpDt", SqlDbType.DateTime);
            MyParam.Value = Dt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "TrBalRpt";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }
        public void TrBalLedDs_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            Boolean DrCr;
            DrCr = GetConfigValuefor(38);
            tmp.Add(CommonView.GetGridViewColumn("Ledger", "Ledger", 510, 1, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            if (DrCr == true)
            {
                tmp.Add(CommonView.GetGridViewColumn("Debit", "Debit", 100, 2, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
                tmp.Add(CommonView.GetGridViewColumn("Credit", "Credit", 100, 3, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            }
            else
            {                
                tmp.Add(CommonView.GetGridViewColumn("Credit", "Credit", 100, 2, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
                tmp.Add(CommonView.GetGridViewColumn("Debit", "Debit", 100, 3, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            }
            tmp.Add(CommonView.GetGridViewColumn("AccId", "AccId", 0, 4));
            tmp.Add(CommonView.GetGridViewColumn("Accode", "Accode", 0, 5));
            tmp.Add(CommonView.GetGridViewColumn("updownno", "num", 0, 7));
            tmp.Add(CommonView.GetGridViewColumn("SenFlag", "SenFlag", 0, 9));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0,10));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = true;
        }
        # endregion
        

        #region "TrBalForPeriod"

        public DataTable TrBalForPeriods(DateTime FrmDt, DateTime ToDt)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();


            MyCmd = new SqlCommand("Acc_TrBalBreakingDetRpt", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@FrmDt", SqlDbType.DateTime);
            MyParam.Value = FrmDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@ToDt", SqlDbType.DateTime);
            MyParam.Value = ToDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);


            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "TrBalPeriod";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;

        }

        public void TrBalForPeriods_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            Boolean DrCr;
            DrCr = GetConfigValuefor(38);
            tmp.Add(CommonView.GetGridViewColumn("AccId", "AccId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Accode", "Accode", 0, 2));
            tmp.Add(CommonView.GetGridViewColumn("Ledger", "Ledger", 200, 3, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Opening", "Opening", 100, 4, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            if (DrCr == true)
            {
                tmp.Add(CommonView.GetGridViewColumn("Debit", "Debit", 100, 5, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
                tmp.Add(CommonView.GetGridViewColumn("Credit", "Credit", 100, 6, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            }
            else
            {
                tmp.Add(CommonView.GetGridViewColumn("Credit", "Credit", 100, 5, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
                tmp.Add(CommonView.GetGridViewColumn("Debit", "Debit", 100, 6, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
                
            }
            tmp.Add(CommonView.GetGridViewColumn("Balance", "Balance", 100, 7, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("UpdownNo", "UpdownNo", 0, 8));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 9));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }

        # endregion
        # region "TrBalGrpWgt"


        public DataTable TrbalGrpWgtDs(DateTime Dt)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();


            MyCmd = new SqlCommand("Acc_Qry_TrBalrptgrpLedWgt", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;
            MyParam = new SqlParameter("@UpDt", SqlDbType.DateTime);
            MyParam.Value = Dt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "TrBalWgtRpt";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }
        public void TrBalGrpWgtDs_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            Boolean DrCr;
            DrCr = GetConfigValuefor(38);
            tmp.Add(CommonView.GetGridViewColumn("Ledger", "Ledger", 510, 1, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            if (DrCr == true)
            {
                tmp.Add(CommonView.GetGridViewColumn("Debit", "Debit", 90, 2, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
                tmp.Add(CommonView.GetGridViewColumn("Credit", "Credit", 90, 3, true, DataGridViewContentAlignment.MiddleRight, "######0.000"));
                tmp.Add(CommonView.GetGridViewColumn("DebitGWt", "GoldDebit", 90, 4, true, DataGridViewContentAlignment.MiddleRight, "######0.000"));
                tmp.Add(CommonView.GetGridViewColumn("CreditGWt", "GoldCredit", 90, 5, true, DataGridViewContentAlignment.MiddleRight, "######0.000"));

                tmp.Add(CommonView.GetGridViewColumn("DebitSWt", "SilverDebit", 90, 6, true, DataGridViewContentAlignment.MiddleRight, "######0.000"));
                tmp.Add(CommonView.GetGridViewColumn("CreditSWt", "SilverCredit", 90, 7, true, DataGridViewContentAlignment.MiddleRight, "######0.000"));
            }
            else
            {
                tmp.Add(CommonView.GetGridViewColumn("Credit", "Credit", 90, 2, true, DataGridViewContentAlignment.MiddleRight, "######0.000"));
                tmp.Add(CommonView.GetGridViewColumn("Debit", "Debit", 90, 3, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));

                tmp.Add(CommonView.GetGridViewColumn("CreditGWt", "GoldCredit", 90, 4, true, DataGridViewContentAlignment.MiddleRight, "######0.000"));
                tmp.Add(CommonView.GetGridViewColumn("DebitGWt", "GoldDebit", 90, 5, true, DataGridViewContentAlignment.MiddleRight, "######0.000"));

                tmp.Add(CommonView.GetGridViewColumn("CreditSWt", "SilverCredit", 90, 6, true, DataGridViewContentAlignment.MiddleRight, "######0.000"));
                tmp.Add(CommonView.GetGridViewColumn("DebitSWt", "SilverDebit", 90, 7, true, DataGridViewContentAlignment.MiddleRight, "######0.000"));
                
            }

            tmp.Add(CommonView.GetGridViewColumn("AccId", "AccId", 0, 8));
            tmp.Add(CommonView.GetGridViewColumn("Accode", "Accode", 0, 9));
            tmp.Add(CommonView.GetGridViewColumn("SubGrpId", "SubGrpId", 0, 10));
            tmp.Add(CommonView.GetGridViewColumn("subGroupName", "subGroupName", 0, 11));
            tmp.Add(CommonView.GetGridViewColumn("SubGrpId1", "SubGrpId", 0, 12));
            tmp.Add(CommonView.GetGridViewColumn("SubGrpId2", "SubGrpId", 0, 13));
            tmp.Add(CommonView.GetGridViewColumn("SubLvl", "SubLvl", 0, 14));
            tmp.Add(CommonView.GetGridViewColumn("updownno", "num", 0, 15));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = true;
        }

      # endregion
        # region "TrBalLedWgt"

        public DataTable TrbalLedWgtDs(DateTime Dt)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();


            MyCmd = new SqlCommand("Acc_Qry_TrBalRptLedWgt", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;
            MyParam = new SqlParameter("@UpDt", SqlDbType.DateTime);
            MyParam.Value = Dt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "TrBalWgtRpt";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }
        public void TrBalLedWgtDs_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            Boolean DrCr;
            DrCr = GetConfigValuefor(38);
            tmp.Add(CommonView.GetGridViewColumn("Ledger", "Ledger", 400, 1, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            if (DrCr == true)
            {
                tmp.Add(CommonView.GetGridViewColumn("Debit", "Debit", 90, 2, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
                tmp.Add(CommonView.GetGridViewColumn("Credit", "Credit", 90, 3, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
                tmp.Add(CommonView.GetGridViewColumn("DebitGWt", "GoldDebit", 90, 4, true, DataGridViewContentAlignment.MiddleRight, "######0.000"));
                tmp.Add(CommonView.GetGridViewColumn("CreditGWt", "GoldCredit", 90, 5, true, DataGridViewContentAlignment.MiddleRight, "######0.000"));
                tmp.Add(CommonView.GetGridViewColumn("DebitSWt", "SilverDebit", 90, 6, true, DataGridViewContentAlignment.MiddleRight, "######0.000"));
                tmp.Add(CommonView.GetGridViewColumn("CreditSWt", "SilverCredit", 90, 7, true, DataGridViewContentAlignment.MiddleRight, "######0.000"));
            }
            else
            {
                tmp.Add(CommonView.GetGridViewColumn("Credit", "Credit", 90, 2, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
                tmp.Add(CommonView.GetGridViewColumn("Debit", "Debit", 90, 3, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));

                tmp.Add(CommonView.GetGridViewColumn("CreditGWt", "GoldCredit", 90, 4, true, DataGridViewContentAlignment.MiddleRight, "######0.000"));
                tmp.Add(CommonView.GetGridViewColumn("DebitGWt", "GoldDebit", 90, 5, true, DataGridViewContentAlignment.MiddleRight, "######0.000"));

                tmp.Add(CommonView.GetGridViewColumn("CreditSWt", "SilverCredit", 90, 6, true, DataGridViewContentAlignment.MiddleRight, "######0.000"));
                tmp.Add(CommonView.GetGridViewColumn("DebitSWt", "SilverDebit", 90, 7, true, DataGridViewContentAlignment.MiddleRight, "######0.000"));
                
            }
            tmp.Add(CommonView.GetGridViewColumn("AccId", "AccId", 0, 8));
            tmp.Add(CommonView.GetGridViewColumn("Accode", "Accode", 0, 9));
            tmp.Add(CommonView.GetGridViewColumn("updownno", "num", 0, 10));
            tmp.Add(CommonView.GetGridViewColumn("SenFlag", "SenFlag", 0, 11));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = true;
        }
        # endregion

    }
}