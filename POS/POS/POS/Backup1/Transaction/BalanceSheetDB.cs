using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using GridStructures;
using DBAccess;
using AccountsDB;

namespace AccountsDB
{
    public class BalanceSheetDB
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

        public DateTime FetchToDt()
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
            MyParam.Value = 0;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@AccId", SqlDbType.Int);
            MyParam.Value = 0;
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

        public DataTable BalLedDs(DateTime UpDt,Char  UnderGroup )
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();


            MyCmd = new SqlCommand("Acc_Qry_BalRptLed", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Dt", SqlDbType.DateTime);
            MyParam.Value = UpDt.ToString("dd/MMM/yyy");
            MyCmd.Parameters.Add(MyParam);



            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Credit", SqlDbType.Bit);
            MyParam.Value = 0;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@UnderGroup", SqlDbType.Char);
            MyParam.Value = UnderGroup ;
            MyCmd.Parameters.Add(MyParam);


            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "BalRpt";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public void BalRptDs_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("Liablities", "Liablities", 175, 1, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Credit", "", 100, 2, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("TotalCredit", "Total", 100, 3, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Assets", "Assets", 175, 4, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Debit", "", 100, 5, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("TotalDebit", "Total", 100, 6, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("CrAccode", "CrAccode", 0, 7));
            tmp.Add(CommonView.GetGridViewColumn("DrAccode", "DrAccode", 0, 8));
            tmp.Add(CommonView.GetGridViewColumn("num", "num", 0, 9));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 10));
            //tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = true;
        }

        public DataTable BalGrpDs(DateTime UpDt, Char UnderGroup)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();


            MyCmd = new SqlCommand("Acc_Qry_BalRptLedBalGrp", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Dt", SqlDbType.DateTime);
            MyParam.Value  = UpDt.ToString("dd/MMM/yyy");
            MyCmd.Parameters.Add(MyParam);



            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Credit", SqlDbType.Bit);
            MyParam.Value = 0;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@UnderGroup", SqlDbType.Char);
            MyParam.Value = UnderGroup;
            MyCmd.Parameters.Add(MyParam);


            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "BalRpt";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public void BalRptGrpDs_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("Liablities", "Liablities", 225, 1, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Credit", "", 100, 2, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Assets", "Assets", 225, 3, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Debit", "", 100, 4, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("num", "num", 0, 5));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = true;
        }

        public DataTable ClsStkDs()
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();


            MyCmd = new SqlCommand("Acc_Qry_clsstkdetvw", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            
            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);


            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "clsstkdetvw";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public DataTable PrLossDs(DateTime UpDt)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();


            MyCmd = new SqlCommand("Acc_Qry_PrLossFn", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Dt", SqlDbType.DateTime);
            MyParam.Value = UpDt.ToString("dd/MMM/yyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);


            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "clsstkdetvw";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public decimal  PrLossAmt(DateTime UpDt)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();


            MyCmd = new SqlCommand("Acc_Qry_PrLossAmtFn", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Dt", SqlDbType.DateTime);
            MyParam.Value = UpDt.ToString("dd/MMM/yyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);


            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "clsstkdetvw";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return Convert.ToDecimal(DTbl.Rows[0]["Amt"]);
        }

        public decimal ClsStkSumAmt()
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();


            MyCmd = new SqlCommand("Acc_Qry_Sumclsstkdetvw", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;


            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);


            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Sumclsstkdetvw";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return Convert.ToDecimal(DTbl.Rows[0]["Amt"]);
        }

        public DataTable BalRptGrpDs(DateTime UpDt, Char UnderGroup)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();


            MyCmd = new SqlCommand("Acc_Qry_BalrptgrpBalRptGrpFn", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Dt", SqlDbType.DateTime);
            MyParam.Value = UpDt.ToString("dd/MMM/yyy");
            MyCmd.Parameters.Add(MyParam);



            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Credit", SqlDbType.Bit);
            MyParam.Value = 0;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@UnderGroup", SqlDbType.Char);
            MyParam.Value = UnderGroup;
            MyCmd.Parameters.Add(MyParam);


            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "BalRpt";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        #endregion

        public void BalClsStkUpdation(DateTime ToDt)
        {           
            try
            {
                SqlConnection Con = new SqlConnection(Common.ConStr);
                SqlDataAdapter Da = new SqlDataAdapter();
                Con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("ACC_CLSSTKUPDSP", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@TODT", SqlDbType.DateTime);
                param.Value = ToDt.ToString("dd/MMM/yyyy");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.TinyInt);
                param.Value = Common.UserId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CompId", SqlDbType.TinyInt);
                param.Value = Common.CId;
                Cmd.Parameters.Add(param);

                Cmd.ExecuteNonQuery();
                Cmd.Dispose();
                Con.Close();                
            }

            catch (Exception Ex)
            {
              
                if (Ex.Message.IndexOf("COLUMN REFERENCE constraint") > -1)
                    throw new Exception("COLUMN REFERENCE constraint");
                else if (Ex.Message.IndexOf("Moved Up") > -1)
                    throw new Exception("Can't be Moved Up");
                else if (Ex.Message.IndexOf("Moved Down") > -1)
                    throw new Exception("Can't be Moved Down");
                else
                    throw Ex;
            }

        }                
    }
}