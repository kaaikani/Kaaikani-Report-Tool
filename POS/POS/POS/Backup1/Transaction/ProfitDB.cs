using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using GridStructures;
using DBAccess;
using AccountsDB;

namespace AccountsDB
{
    /// <summary>
    /// Summary description for PartyDB.
    /// </summary>
    public class ProfitDB 
    {
      
        public ProfitDB() 
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #region "Property

        ADODB.Recordset LedRS;
        string _Accode1;
        public string Accode1
        {
            get
            {

                return  (string)LedRS.Fields["Accode"].Value;  //LedRS("Accode");
            }

        }
        
        string _Acdesc1;
        public string Acdesc1
        {
            get
            {
                return (string)LedRS.Fields["Acdesc"].Value;
            }

        }

          Boolean _LedEOF;
        public Boolean LedEOF
        {
            get
            {
                return (Boolean)LedRS.EOF;
            }

        }
           public void Ledmovenext()
           {
             LedRS.MoveNext();
           }
        ADODB.Recordset subledrs = new ADODB.Recordset();
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

        public Boolean CrDr()
        {
            Boolean Result;
            SqlConnection Con = new SqlConnection(Common.ConStr);
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Config_Qry_GetBitvalue", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@ConfigId", SqlDbType.Int);
            param.Value = 38;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Result = Convert.ToBoolean(Cmd.ExecuteScalar());

            Cmd.Dispose();
            Con.Close();
            return Result;
        }

        public DataTable PrLossDs(DateTime UpDt)
        {

            SqlConnection Con = new SqlConnection(Common.ConStr);
            DataTable Tbl = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Acc_Qry_PrLossFn", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@Dt", SqlDbType.DateTime);
            param.Value = UpDt.ToString("dd/MMM/yyyy");
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@CompId", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "PrLoss";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }

        public double PrLossAmt(DateTime UpDt)
        {

            SqlConnection Con = new SqlConnection(Common.ConStr);
            DataTable Tbl = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Acc_Qry_PrLossAmtFn", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@Dt", SqlDbType.DateTime);
            param.Value = UpDt.ToString("dd/MMM/yyyy");
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "PrLoss";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return (double)Tbl.Rows[0][0];
        }




        public string PrintSize_Source()
        {
            string Result;
            SqlConnection Con = new SqlConnection(Common.ConStr);
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Config_Qry_GetStringvalue", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@ConfigId", SqlDbType.Int);
            param.Value = 40;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Result = Convert.ToString(Cmd.ExecuteScalar());

            Cmd.Dispose();
            Con.Close();
            return Result;
        }
   
       
      
        public DataTable LedDs(DateTime FromDt, DateTime ToDt, int AccId)
        {
            
            SqlConnection Con = new SqlConnection(Common.ConStr);
            DataTable Tbl = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Acc_Qry_LedRpt", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@FromDt", SqlDbType.DateTime);
            param.Value = FromDt.ToString("dd/MMM/yyyy");
            Cmd.Parameters.Add(param);

            SqlParameter Param = new SqlParameter("@ToDt", SqlDbType.DateTime);
            Param.Value = ToDt.ToString ("dd/MMM/yyyy");
            Cmd.Parameters.Add(Param);

            Param = new SqlParameter("@AccId", SqlDbType.Int);
            Param.Value = AccId;
            Cmd.Parameters.Add(Param);

            Param = new SqlParameter("@DocRefId", SqlDbType.Int);
            Param.Value = 0;
            Cmd.Parameters.Add(Param);

            Param = new SqlParameter("@DocType", SqlDbType.VarChar, 5);
            Param.Value = "";
            Cmd.Parameters.Add(Param);

            Param = new SqlParameter("@CompId", SqlDbType.TinyInt);
            Param.Value = Common.CId;
            Cmd.Parameters.Add(Param);
           
            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "LedRpt";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }

        public int LedRptDs_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            
            tmp.Add(CommonView.GetGridViewDateColumn("Dt", "Date", 75, 1,true ,DataGridViewContentAlignment.MiddleLeft,"dd/MM/yyyy", DataGridViewAutoSizeColumnMode.NotSet));
            tmp.Add(CommonView.GetGridViewColumn("DocType", "DocType", 0, 2));
            tmp.Add(CommonView.GetGridViewColumn("DocNo", "DocNo", 65, 3));
            tmp.Add(CommonView.GetGridViewColumn("Acdesc", "Ledger", 0, 4, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Narration", "Narration", 170, 5, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Debit", "Debit", 90, 6,true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Credit", "Credit", 90, 7, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
            tmp.Add(CommonView.GetGridViewColumn("DayId", "DayId", 0, 8));
            tmp.Add(CommonView.GetGridViewColumn("LocId", "LocId", 0, 9));
            tmp.Add(CommonView.GetGridViewColumn("DocRefId", "DocRefId", 0, 10));
            tmp.Add(CommonView.GetGridViewColumn("AccId", "AccId", 0, 11));
            tmp.Add(CommonView.GetGridViewColumn("Accode", "Accode", 0, 12));
          //  tmp.Add(CommonView.GetGridViewColumn("Acdesc", "Acdesc", 0, 13));
            tmp.Add(CommonView.GetGridViewColumn("Nar1", "Nar1", 0, 14));
            tmp.Add(CommonView.GetGridViewColumn("Nar2", "Nar2", 0, 15));
            tmp.Add(CommonView.GetGridViewColumn("Nar3", "Nar3", 0, 16));
            tmp.Add(CommonView.GetGridViewColumn("Nar4", "Nar4", 0, 17));
            tmp.Add(CommonView.GetGridViewColumn("Nar5", "Nar5", 0, 18));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 19));
            tmp.Add(CommonView.GetGridViewColumn("TranDt", "TranDt", 0, 20));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = true;
            return 0;
            
        }

        public DateTime FetchToDt(string Month, int AccId)
        {

            SqlConnection Con = new SqlConnection(Common.ConStr);
            DataTable Tbl = new DataTable();

            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Acc_Qry_FetchToDt", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@Month", SqlDbType.VarChar, 12);
            param.Value = Month;
            Cmd.Parameters.Add(param);

            SqlParameter Param = new SqlParameter("@AccId", SqlDbType.Int);
            Param.Value = AccId;
            Cmd.Parameters.Add(Param);


            Param = new SqlParameter("@CompId", SqlDbType.TinyInt);
            Param.Value = Common.CId;
            Cmd.Parameters.Add(Param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "CompId";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return (DateTime)Tbl.Rows[0][0];
        }

        public DataTable balGrpDs(DateTime UpDt, string BsGrp, bool Credit)
        {

            SqlConnection Con = new SqlConnection(Common.ConStr);
            DataTable Tbl = new DataTable();

            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Acc_Qry_ProfitLossLedBalGrpFn", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@Dt", SqlDbType.DateTime);
            param.Value = UpDt.ToString("dd/MMM/yyyy");
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@BsGrp", SqlDbType.Char, 1);
            param.Value = BsGrp;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Credit", SqlDbType.Bit);
            param.Value = Credit;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "BalRpt";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }

        public DataTable balGrpDetDs(DateTime UpDt, string BsGrp, bool Credit)
        {

            SqlConnection Con = new SqlConnection(Common.ConStr);
            DataTable Tbl = new DataTable();

            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Acc_Qry_ProfitLossLedBalGrpFn", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@Dt", SqlDbType.DateTime);
            param.Value = UpDt.ToString("dd/MMM/yyyy");
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@BsGrp", SqlDbType.Char, 1);
            param.Value = BsGrp;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Credit", SqlDbType.Bit);
            param.Value = Credit;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "BalRpt";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }

        public DataTable balLedDs(DateTime UpDt, string BsGrp, bool Credit)
        {
            
            SqlConnection Con = new SqlConnection(Common.ConStr);
            DataTable Tbl = new DataTable();
           
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Acc_Qry_ProfitLossLedFn", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@Dt", SqlDbType.DateTime);
            param.Value = UpDt.ToString ("dd/MMM/yyyy");
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@BsGrp", SqlDbType.Char, 1);
            param.Value = BsGrp;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Credit", SqlDbType.Bit);
            param.Value = Credit;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "BalRpt";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }

        public DataTable balLedDetDs(DateTime UpDt, string BsGrp, bool Credit)
        {

            SqlConnection Con = new SqlConnection(Common.ConStr);
            DataTable Tbl = new DataTable();

            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Acc_Qry_ProfitLossLedFn", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@Dt", SqlDbType.DateTime);
            param.Value = UpDt.ToString("dd/MMM/yyyy");
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@BsGrp", SqlDbType.Char, 1);
            param.Value = BsGrp;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Credit", SqlDbType.Bit);
            param.Value = Credit;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "BalRpt";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }


        public int BalRptDs_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("Assets", "Details", 100, 1, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Debit", "Value", 90, 2, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("TotalDebit", "Total", 90, 3, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Liablities", "Details", 90, 4, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Credit", "Value", 90, 5, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("TotalCredit", "Total", 100, 6, true, DataGridViewContentAlignment.MiddleLeft, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("DrAccode", "DrAccode", 0, 7));
            tmp.Add(CommonView.GetGridViewColumn("CrAccode", "CrAccode", 0, 8));
            tmp.Add(CommonView.GetGridViewColumn("num", "num", 0, 9));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 10));
           
            return 0;
           
        }


        public DataTable balRptGrpDs(DateTime UpDt, string BsGrp, bool Credit)
        {

            SqlConnection Con = new SqlConnection(Common.ConStr);
            DataTable Tbl = new DataTable();

            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Acc_Qry_ProfitLossLedFn", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@Dt", SqlDbType.DateTime);
            param.Value = UpDt.ToString("dd/MMM/yyyy");
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@BsGrp", SqlDbType.Char, 1);
            param.Value = BsGrp;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Credit", SqlDbType.Bit);
            param.Value = Credit;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "BalRpt";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }

        public int BalRptGrpDs_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("Assets", "Details", 100, 1, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Debit", "Value", 90, 2, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("TotalDebit", "Total", 0, 3));
            tmp.Add(CommonView.GetGridViewColumn("Liablities", "Details", 90, 4, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Credit", "Value", 90, 5, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("TotalCredit", "Total", 0, 6));
            tmp.Add(CommonView.GetGridViewColumn("DrAccode", "DrAccode", 0, 7));
            tmp.Add(CommonView.GetGridViewColumn("CrAccode", "CrAccode", 0, 8));
            tmp.Add(CommonView.GetGridViewColumn("num", "num", 0, 9));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 10));
        

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = true;
            return 0;

        }

      
            
    }
}
