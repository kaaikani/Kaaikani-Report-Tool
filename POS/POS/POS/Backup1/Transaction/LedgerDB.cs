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
    public class LedgerDB 
    {
        Boolean disposed = false;
        
        public LedgerDB() 
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

        #region "Ledger"
        public string GetFromName_Source(int FrmId)
        {
            string Result;
            SqlConnection Con = new SqlConnection(Common.MasConStr);
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_GetFormName", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@Frmid", SqlDbType.Int);
            param.Value = FrmId;
            Cmd.Parameters.Add(param);

            Result = Convert.ToString(Cmd.ExecuteScalar());

            Cmd.Dispose();
            Con.Close();
            return Result;
        }

        public Boolean FetchRsLedger()
        {
            string Result;
            SqlConnection Con = new SqlConnection(Common.ConStr);
            Con.Open();
            SqlCommand Cmd;
            DataTable Tbl = new DataTable();
            Cmd = new SqlCommand("Acc_Qry_achdallvw", Con);
            SqlDataAdapter Da = new SqlDataAdapter();
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter Param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            Param.Value = Common.CId;
            Cmd.Parameters.Add(Param);
            
            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "acdesc";

            SqlDataReader rs = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
            //rs = new SqlDataReader(CommandBehavior.CloseConnection);
           //rs = 
           return ! (rs.Read());
           Cmd.Dispose();
            Con.Close();
           
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
   
        public double OpBal(DateTime FromDt, int Accid)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Acc_Qry_OpBalance", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter Param = new SqlParameter("@Dt", SqlDbType.DateTime);
            Param.Value = FromDt.ToString("dd/MMM/yyyy");
            Cmd.Parameters.Add(Param);

            Param = new SqlParameter("@Accid", SqlDbType.Int);
            Param.Value = Accid;
            Cmd.Parameters.Add(Param);

            Param = new SqlParameter("@compid", SqlDbType.TinyInt);
            Param.Value = Common.CId;
            Cmd.Parameters.Add(Param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "OPBalDet";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
         
            return (double)Tbl.Rows[0][0];
        }

        public DataTable OpBalPrint(DateTime FromDt, int Accid)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Acc_Qry_OpBalance", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter Param = new SqlParameter("@Dt", SqlDbType.DateTime);
            Param.Value = FromDt.ToString("dd/MMM/yyyy");
            Cmd.Parameters.Add(Param);

            Param = new SqlParameter("@Accid", SqlDbType.Int);
            Param.Value = Accid;
            Cmd.Parameters.Add(Param);

            Param = new SqlParameter("@compid", SqlDbType.TinyInt);
            Param.Value = Common.CId;
            Cmd.Parameters.Add(Param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "Acc_Qry_OpBalance";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();

            return Tbl;
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

        public DataTable AllCompanyLedDs(DateTime FromDt, DateTime ToDt, int AccId)
        {


            SqlConnection Con = new SqlConnection(Common.ConStr);
            DataTable Tbl = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Acc_Qry_AllComp_LedRpt", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@FromDt", SqlDbType.DateTime);
            param.Value = FromDt.ToString("dd/MMM/yyyy");
            Cmd.Parameters.Add(param);

            SqlParameter Param = new SqlParameter("@ToDt", SqlDbType.DateTime);
            Param.Value = ToDt.ToString("dd/MMM/yyyy");
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

            //Param = new SqlParameter("@CompId", SqlDbType.TinyInt);
            //Param.Value = Common.CId;
            //Cmd.Parameters.Add(Param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "LedRpt";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }

        public DataTable MasConfig()
        {


            SqlConnection Con = new SqlConnection(Common.ConStr);
            DataTable Tbl = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter(); 
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("CreateMasSynonySP 'MAS','" + Common.MasDataBase + "'", Con);
            Cmd.CommandType = CommandType.Text;

         

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "MasRpt";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;

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


     

        public int LedRptDs_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            Boolean dtct ;
            dtct = CrDr();
            tmp.Add(CommonView.GetGridViewDateColumn("Dt", "Date", 100, 1,true ,DataGridViewContentAlignment.MiddleLeft,"dd/MM/yyyy", DataGridViewAutoSizeColumnMode.NotSet));
            tmp.Add(CommonView.GetGridViewColumn("DocType", "DocType", 0, 2));
            tmp.Add(CommonView.GetGridViewColumn("DocNo", "DocNo", 100, 3));
            tmp.Add(CommonView.GetGridViewColumn("Acdesc", "Ledger", 0, 4, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Narration", "Narration", 170, 5, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            if (dtct == true)
            {
                tmp.Add(CommonView.GetGridViewColumn("Debit", "Debit", 90, 6, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
                tmp.Add(CommonView.GetGridViewColumn("Credit", "Credit", 90, 7, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
            }
            else
            {
                tmp.Add(CommonView.GetGridViewColumn("Credit", "Credit", 90, 6, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
                tmp.Add(CommonView.GetGridViewColumn("Debit", "Debit", 90, 7, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
            }
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

        public int LedRptDs_GridStyle(DataGridViewColumnCollection tmp,Boolean Ledger)
        {
            tmp.Clear();
            Boolean drcr;
            drcr = CrDr();
            tmp.Add(CommonView.GetGridViewDateColumn("Dt", "Date", 100, 1, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy", DataGridViewAutoSizeColumnMode.NotSet));
            tmp.Add(CommonView.GetGridViewColumn("DocType", "DocType", 0, 2));
            tmp.Add(CommonView.GetGridViewColumn("DocNo", "DocNo", 100, 3));
            tmp.Add(CommonView.GetGridViewColumn("Acdesc", "Ledger", (Ledger == true ? 220 : 0), 4, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Narration", "Narration", 170, 5, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            if (drcr == true)
            {
                tmp.Add(CommonView.GetGridViewColumn("Debit", "Debit", 90, 6, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
                tmp.Add(CommonView.GetGridViewColumn("Credit", "Credit", 90, 7, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
            }
            else
            {
                tmp.Add(CommonView.GetGridViewColumn("Credit", "Credit", 90, 6, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
                tmp.Add(CommonView.GetGridViewColumn("Debit", "Debit", 90, 7, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
            }
            tmp.Add(CommonView.GetGridViewColumn("DayId", "DayId", 0, 8));
            tmp.Add(CommonView.GetGridViewColumn("LocId", "LocId", 0, 9));
            tmp.Add(CommonView.GetGridViewColumn("DocRefId", "DocRefId", 0, 10));
            tmp.Add(CommonView.GetGridViewColumn("AccId", "AccId", 0, 11));
            tmp.Add(CommonView.GetGridViewColumn("Accode", "Accode", 0, 12));
         //   tmp.Add(CommonView.GetGridViewColumn("Acdesc", "Acdesc", 0, 13));
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

        public DataTable LedMonDs(DateTime FromDt, DateTime ToDt, int AccId)
        {
            
            SqlConnection Con = new SqlConnection(Common.ConStr);
            DataTable Tbl = new DataTable();
           
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Acc_Qry_LedMonRpt", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@FromDt", SqlDbType.DateTime);
            param.Value = FromDt.ToString ("dd/MMM/yyyy");
            Cmd.Parameters.Add(param);

            SqlParameter Param = new SqlParameter("@ToDt", SqlDbType.DateTime);
            Param.Value = ToDt.ToString("dd/MMM/yyyy");
            Cmd.Parameters.Add(Param);

            Param = new SqlParameter("@AccId", SqlDbType.Int);
            Param.Value = AccId;
            Cmd.Parameters.Add(Param);
 
            Param = new SqlParameter("@compid", SqlDbType.TinyInt);
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


        public int LedMonRptDs_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("Mth", "Month", 100, 1, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Narration", "", 0, 2));
            tmp.Add(CommonView.GetGridViewColumn("Debit", "Debit", 90, 3, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Credit", "Credit", 90, 4,true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Mth1", "Mth1", 0, 5));
               
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = true;
            return 0;
           
        }

        public DateTime FetchFromDt(string Month, int AccId)
        {

            SqlConnection Con = new SqlConnection(Common.ConStr);
            DataTable Tbl = new DataTable();

            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Acc_Qry_FetchFromDt", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@Month", SqlDbType.VarChar,12);
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

        public DataTable AllLedDs()
        {

            SqlConnection Con = new SqlConnection(Common.ConStr);
            DataTable Tbl = new DataTable();

            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Acc_Qry_achdVw", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter Param = new SqlParameter("@compid", SqlDbType.TinyInt);
            Param.Value = Common.CId;
            Cmd.Parameters.Add(Param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "achdVw";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }
        #endregion

        #region "Ledger With Weight Based"

        public DataTable LedWgtDs(DateTime FromDt, DateTime ToDt, int AccId)
        {

            SqlConnection Con = new SqlConnection(Common.ConStr);
            DataTable Tbl = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Acc_Qry_LedRptWgt", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@FromDt", SqlDbType.DateTime);
            param.Value = FromDt.ToString("dd/MMM/yyyy");
            Cmd.Parameters.Add(param);

            SqlParameter Param = new SqlParameter("@ToDt", SqlDbType.DateTime);
            Param.Value = ToDt.ToString("dd/MMM/yyyy");
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

        public int LedRptWgtDs_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();

            Boolean drcr;
            drcr = CrDr();

            tmp.Add(CommonView.GetGridViewDateColumn("Dt", "Date", 75, 1, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy", DataGridViewAutoSizeColumnMode.NotSet));
            tmp.Add(CommonView.GetGridViewColumn("DocType", "DocType", 0, 2));
            tmp.Add(CommonView.GetGridViewColumn("DocNo", "DocNo", 65, 3));
            tmp.Add(CommonView.GetGridViewColumn("Acdesc", "Ledger", 0, 4, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Narration", "Narration", 170, 5, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));

            if (drcr == true)
            {
                tmp.Add(CommonView.GetGridViewColumn("Debit", "Debit", 90, 6, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
                tmp.Add(CommonView.GetGridViewColumn("Credit", "Credit", 90, 7, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
                tmp.Add(CommonView.GetGridViewColumn("DebitGWt", "GoldDebit", 90, 8, true, DataGridViewContentAlignment.MiddleRight, "###0.000"));
                tmp.Add(CommonView.GetGridViewColumn("CreditGWt", "GoldCredit", 90, 9, true, DataGridViewContentAlignment.MiddleRight, "###0.000"));
                tmp.Add(CommonView.GetGridViewColumn("DebitSWt", "SilverDebit", 90, 10, true, DataGridViewContentAlignment.MiddleRight, "###0.000"));
                tmp.Add(CommonView.GetGridViewColumn("CreditSWt", "SilverCredit", 90, 11, true, DataGridViewContentAlignment.MiddleRight, "###0.000"));
            }
            else
            {
                tmp.Add(CommonView.GetGridViewColumn("Credit", "Credit", 90, 6, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
                tmp.Add(CommonView.GetGridViewColumn("Debit", "Debit", 90, 7, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
                tmp.Add(CommonView.GetGridViewColumn("CreditGWt", "GoldCredit", 90, 8, true, DataGridViewContentAlignment.MiddleRight, "###0.000"));
                tmp.Add(CommonView.GetGridViewColumn("DebitGWt", "GoldDebit", 90, 9, true, DataGridViewContentAlignment.MiddleRight, "###0.000"));
                tmp.Add(CommonView.GetGridViewColumn("CreditSWt", "SilverCredit", 90, 10, true, DataGridViewContentAlignment.MiddleRight, "###0.000"));
                tmp.Add(CommonView.GetGridViewColumn("DebitSWt", "SilverDebit", 90, 11, true, DataGridViewContentAlignment.MiddleRight, "###0.000"));
            }

            tmp.Add(CommonView.GetGridViewColumn("DayId", "DayId", 0, 12));
            tmp.Add(CommonView.GetGridViewColumn("DocRefId", "DocRefId", 0, 13));
            tmp.Add(CommonView.GetGridViewColumn("AccId", "AccId", 0, 14));
            tmp.Add(CommonView.GetGridViewColumn("Accode", "Accode", 0, 15));
            //  tmp.Add(CommonView.GetGridViewColumn("Acdesc", "Acdesc", 0, 13));
            tmp.Add(CommonView.GetGridViewColumn("Nar1", "Nar1", 0, 16));
            tmp.Add(CommonView.GetGridViewColumn("Nar2", "Nar2", 0, 17));
            tmp.Add(CommonView.GetGridViewColumn("Nar3", "Nar3", 0, 18));
            tmp.Add(CommonView.GetGridViewColumn("Nar4", "Nar4", 0, 19));
            tmp.Add(CommonView.GetGridViewColumn("Nar5", "Nar5", 0, 20));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 21));
            tmp.Add(CommonView.GetGridViewColumn("TranDt", "TranDt", 0, 22));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = true;
            return 0;

        }

        public DataTable LedMonWgtDs(DateTime FromDt, DateTime ToDt, int AccId)
        {

            SqlConnection Con = new SqlConnection(Common.ConStr);
            DataTable Tbl = new DataTable();

            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Acc_Qry_LedMonRptWgt", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@FromDt", SqlDbType.DateTime);
            param.Value = FromDt.ToString("dd/MMM/yyyy");
            Cmd.Parameters.Add(param);

            SqlParameter Param = new SqlParameter("@ToDt", SqlDbType.DateTime);
            Param.Value = ToDt.ToString("dd/MMM/yyyy");
            Cmd.Parameters.Add(Param);

            Param = new SqlParameter("@AccId", SqlDbType.Int);
            Param.Value = AccId;
            Cmd.Parameters.Add(Param);

            Param = new SqlParameter("@compid", SqlDbType.TinyInt);
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

        public int LedMonRptWgtDs_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            Boolean drcr;
            drcr = CrDr();
            tmp.Add(CommonView.GetGridViewColumn("Mth", "Month", 100, 1, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Narration", "", 0, 2));

            if (drcr == true)
            {
                tmp.Add(CommonView.GetGridViewColumn("Debit", "Debit", 90, 3, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
                tmp.Add(CommonView.GetGridViewColumn("Credit", "Credit", 90, 4, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
                tmp.Add(CommonView.GetGridViewColumn("DebitGWt", "GoldDebit", 90, 5, true, DataGridViewContentAlignment.MiddleRight, "###0.000"));
                tmp.Add(CommonView.GetGridViewColumn("CreditGWt", "GoldCredit", 90, 6, true, DataGridViewContentAlignment.MiddleRight, "###0.000"));
                tmp.Add(CommonView.GetGridViewColumn("DebitSWt", "SilverDebit", 90, 7, true, DataGridViewContentAlignment.MiddleRight, "###0.000"));
                tmp.Add(CommonView.GetGridViewColumn("CreditSWt", "SilverCredit", 90, 8, true, DataGridViewContentAlignment.MiddleRight, "###0.000"));
            }
            else
            {
                tmp.Add(CommonView.GetGridViewColumn("Credit", "Credit", 90, 3, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
                tmp.Add(CommonView.GetGridViewColumn("Debit", "Debit", 90, 4, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
                tmp.Add(CommonView.GetGridViewColumn("CreditGWt", "GoldCredit", 90, 5, true, DataGridViewContentAlignment.MiddleRight, "###0.000"));
                tmp.Add(CommonView.GetGridViewColumn("DebitGWt", "GoldDebit", 90, 6, true, DataGridViewContentAlignment.MiddleRight, "###0.000"));
                tmp.Add(CommonView.GetGridViewColumn("CreditSWt", "SilverCredit", 90, 7, true, DataGridViewContentAlignment.MiddleRight, "###0.000"));
                tmp.Add(CommonView.GetGridViewColumn("DebitSWt", "SilverDebit", 90, 8, true, DataGridViewContentAlignment.MiddleRight, "###0.000"));
            }

            tmp.Add(CommonView.GetGridViewColumn("Mth1", "Mth1", 0, 9));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = true;
            return 0;

        }

        public DataTable OpBalWgt(DateTime FromDt, int Accid)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Acc_Qry_OpBalanceWgt", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter Param = new SqlParameter("@Dt", SqlDbType.DateTime);
            Param.Value = FromDt.ToString("dd/MMM/yyyy");
            Cmd.Parameters.Add(Param);

            Param = new SqlParameter("@Accid", SqlDbType.Int);
            Param.Value = Accid;
            Cmd.Parameters.Add(Param);

            Param = new SqlParameter("@compid", SqlDbType.TinyInt);
            Param.Value = Common.CId;
            Cmd.Parameters.Add(Param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "OPBalWgtDet";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();

            return Tbl;
        }

        public int LedRptWgtDs_GridStyle(DataGridViewColumnCollection tmp, Boolean Ledger,string Mode)
        {
            tmp.Clear();
            Boolean drcr;
            drcr = CrDr();

            tmp.Add(CommonView.GetGridViewDateColumn("Dt", "Date", 75, 1, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy", DataGridViewAutoSizeColumnMode.NotSet));
            tmp.Add(CommonView.GetGridViewColumn("DocType", "DocType", 0, 2));
            tmp.Add(CommonView.GetGridViewColumn("DocNo", "DocNo", 65, 3));
            tmp.Add(CommonView.GetGridViewColumn("Acdesc", "Ledger", (Ledger == true ? 220 : 0), 4, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Narration", "Narration", 170, 5, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));

            if (drcr == true)
            {
                tmp.Add(CommonView.GetGridViewColumn("Debit", "Debit", 80, 6, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
                tmp.Add(CommonView.GetGridViewColumn("Credit", "Credit", 80, 7, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
                if (Mode == "A")
                {
                    tmp.Add(CommonView.GetGridViewColumn("DebitGWt", "GoldDebit", 80, 8, true, DataGridViewContentAlignment.MiddleRight, "###0.000"));
                    tmp.Add(CommonView.GetGridViewColumn("CreditGWt", "GoldCredit", 80, 9, true, DataGridViewContentAlignment.MiddleRight, "###0.000"));
                    tmp.Add(CommonView.GetGridViewColumn("DebitSWt", "SilverDebit", 80, 10, true, DataGridViewContentAlignment.MiddleRight, "###0.000"));
                    tmp.Add(CommonView.GetGridViewColumn("CreditSWt", "SilverCredit", 80, 11, true, DataGridViewContentAlignment.MiddleRight, "###0.000"));
                }
                else if (Mode == "G")
                {
                    tmp.Add(CommonView.GetGridViewColumn("DebitGWt", "GoldDebit", 80, 8, true, DataGridViewContentAlignment.MiddleRight, "###0.000"));
                    tmp.Add(CommonView.GetGridViewColumn("CreditGWt", "GoldCredit", 80, 9, true, DataGridViewContentAlignment.MiddleRight, "###0.000"));
                    tmp.Add(CommonView.GetGridViewColumn("DebitSWt", "SilverDebit", 0, 10));
                    tmp.Add(CommonView.GetGridViewColumn("CreditSWt", "SilverCredit", 0, 11));
                }
                else if (Mode == "S")
                {
                    tmp.Add(CommonView.GetGridViewColumn("DebitGWt", "GoldDebit", 0, 8));
                    tmp.Add(CommonView.GetGridViewColumn("CreditGWt", "GoldCredit", 0, 9));
                    tmp.Add(CommonView.GetGridViewColumn("DebitSWt", "SilverDebit", 80, 10, true, DataGridViewContentAlignment.MiddleRight, "###0.000"));
                    tmp.Add(CommonView.GetGridViewColumn("CreditSWt", "SilverCredit", 80, 11, true, DataGridViewContentAlignment.MiddleRight, "###0.000"));
                }
                
            }
            else
            {
                tmp.Add(CommonView.GetGridViewColumn("Credit", "Credit", 80, 6, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
                tmp.Add(CommonView.GetGridViewColumn("Debit", "Debit", 80, 7, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
                if (Mode == "A")
                {
                    tmp.Add(CommonView.GetGridViewColumn("CreditGWt", "GoldCredit", 80, 8, true, DataGridViewContentAlignment.MiddleRight, "###0.000"));
                    tmp.Add(CommonView.GetGridViewColumn("DebitGWt", "GoldDebit", 80, 9, true, DataGridViewContentAlignment.MiddleRight, "###0.000"));
                    tmp.Add(CommonView.GetGridViewColumn("CreditSWt", "SilverCredit", 80, 10, true, DataGridViewContentAlignment.MiddleRight, "###0.000"));
                    tmp.Add(CommonView.GetGridViewColumn("DebitSWt", "SilverDebit", 80, 11, true, DataGridViewContentAlignment.MiddleRight, "###0.000"));
                }
                else if (Mode == "G")
                {
                    tmp.Add(CommonView.GetGridViewColumn("CreditGWt", "GoldCredit", 80, 8, true, DataGridViewContentAlignment.MiddleRight, "###0.000"));
                    tmp.Add(CommonView.GetGridViewColumn("DebitGWt", "GoldDebit", 80, 9, true, DataGridViewContentAlignment.MiddleRight, "###0.000"));
                    tmp.Add(CommonView.GetGridViewColumn("CreditSWt", "SilverCredit", 0, 10));
                    tmp.Add(CommonView.GetGridViewColumn("DebitSWt", "SilverDebit", 0, 11));
                }
                else if (Mode == "S")
                {
                    tmp.Add(CommonView.GetGridViewColumn("CreditGWt", "GoldCredit", 0, 8));
                    tmp.Add(CommonView.GetGridViewColumn("DebitGWt", "GoldDebit", 0, 9));
                    tmp.Add(CommonView.GetGridViewColumn("CreditSWt", "SilverCredit", 80, 10, true, DataGridViewContentAlignment.MiddleRight, "###0.000"));
                    tmp.Add(CommonView.GetGridViewColumn("DebitSWt", "SilverDebit", 80, 11, true, DataGridViewContentAlignment.MiddleRight, "###0.000"));
                }

            }


            tmp.Add(CommonView.GetGridViewColumn("DayId", "DayId", 0, 12));
            tmp.Add(CommonView.GetGridViewColumn("LocId", "LocId", 0, 13));
            tmp.Add(CommonView.GetGridViewColumn("DocRefId", "DocRefId", 0, 14));
            tmp.Add(CommonView.GetGridViewColumn("AccId", "AccId", 0, 15));
            tmp.Add(CommonView.GetGridViewColumn("Accode", "Accode", 0, 16));
            tmp.Add(CommonView.GetGridViewColumn("Nar1", "Nar1", 0, 17));
            tmp.Add(CommonView.GetGridViewColumn("Nar2", "Nar2", 0, 18));
            tmp.Add(CommonView.GetGridViewColumn("Nar3", "Nar3", 0, 19));
            tmp.Add(CommonView.GetGridViewColumn("Nar4", "Nar4", 0, 20));
            tmp.Add(CommonView.GetGridViewColumn("Nar5", "Nar5", 0, 21));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 22));
            tmp.Add(CommonView.GetGridViewColumn("TranDt", "TranDt", 0, 23));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = true;
            return 0;

        }

        #endregion  

        #region RateLedger
        public DataTable LedRateDs(DateTime FromDt, DateTime ToDt, int AccId)
        {


            SqlConnection Con = new SqlConnection(Common.ConStr);
            DataTable Tbl = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_RateBasedLedRpt", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@FromDt", SqlDbType.DateTime);
            param.Value = FromDt.ToString("dd/MMM/yyyy");
            Cmd.Parameters.Add(param);

            SqlParameter Param = new SqlParameter("@ToDt", SqlDbType.DateTime);
            Param.Value = ToDt.ToString("dd/MMM/yyyy");
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
            Tbl.TableName = "Qry_RateBasedLedRpt";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }

        public int LedRateRptDs_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            Boolean dtct;
            dtct = CrDr();
            tmp.Add(CommonView.GetGridViewDateColumn("Dt", "Date", 90, 1, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy", DataGridViewAutoSizeColumnMode.NotSet));
            tmp.Add(CommonView.GetGridViewColumn("DocType", "DocType", 0, 2));
            tmp.Add(CommonView.GetGridViewColumn("DocNo", "DocNo", 80, 3));
            tmp.Add(CommonView.GetGridViewColumn("Rate", "Rate", 80, 4, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Narration", "Narration", 50, 5, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Qty", "Qty", 80, 6, true, DataGridViewContentAlignment.MiddleRight, "###0"));
            tmp.Add(CommonView.GetGridViewColumn("Wt", "Wgt", 80, 7, true, DataGridViewContentAlignment.MiddleRight, "###0.000"));

            if (dtct == true)
            {
                tmp.Add(CommonView.GetGridViewColumn("Debit", "Debit", 90, 8, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
                tmp.Add(CommonView.GetGridViewColumn("Credit", "Credit", 90, 9, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
            }
            else
            {
                tmp.Add(CommonView.GetGridViewColumn("Credit", "Credit", 90, 8, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
                tmp.Add(CommonView.GetGridViewColumn("Debit", "Debit", 90, 9, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
            }
            tmp.Add(CommonView.GetGridViewColumn("ClBal", "Closing", 0, 10, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
            tmp.Add(CommonView.GetGridViewColumn("ClBal1", "Closing", 110, 11, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
            tmp.Add(CommonView.GetGridViewColumn("DocRefId", "DocRefId", 0, 12));
            tmp.Add(CommonView.GetGridViewColumn("AccId", "AccId", 0, 13));
            tmp.Add(CommonView.GetGridViewColumn("Accode", "Accode", 0, 14));
            tmp.Add(CommonView.GetGridViewColumn("Acdesc", "Ledger", 0, 15, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            //tmp.Add(CommonView.GetGridViewColumn("Acdesc", "Acdesc", 0, 13));
            //tmp.Add(CommonView.GetGridViewColumn("Nar1", "Nar1", 0, 14));
            //tmp.Add(CommonView.GetGridViewColumn("Nar2", "Nar2", 0, 15));
            //tmp.Add(CommonView.GetGridViewColumn("Nar3", "Nar3", 0, 16));
            //tmp.Add(CommonView.GetGridViewColumn("Nar4", "Nar4", 0, 17));
            //tmp.Add(CommonView.GetGridViewColumn("Nar5", "Nar5", 0, 18));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 16));
            tmp.Add(CommonView.GetGridViewColumn("tranDt", "TranDt", 0, 17));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = true;
            return 0;

        }

        public int LedRateRptDs_GridStyle(DataGridViewColumnCollection tmp, Boolean Ledger)
        {
            tmp.Clear();
            Boolean drcr;
            drcr = CrDr();
            tmp.Add(CommonView.GetGridViewDateColumn("Dt", "Date", 75, 1, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy", DataGridViewAutoSizeColumnMode.NotSet));
            tmp.Add(CommonView.GetGridViewColumn("DocType", "DocType", 0, 2));
            tmp.Add(CommonView.GetGridViewColumn("DocNo", "DocNo", 65, 3));
            tmp.Add(CommonView.GetGridViewColumn("Narration", "Narration", 170, 4, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Wt", "Wgt", 0, 5, true, DataGridViewContentAlignment.MiddleRight, "###0.000"));
            tmp.Add(CommonView.GetGridViewColumn("Qty", "Qty", 100, 6, true, DataGridViewContentAlignment.MiddleRight, "###0"));
            tmp.Add(CommonView.GetGridViewColumn("Rate", "Rate", 100, 7, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
            if (drcr == true)
            {
                tmp.Add(CommonView.GetGridViewColumn("Debit", "Debit", 90, 8, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
                tmp.Add(CommonView.GetGridViewColumn("Credit", "Credit", 90, 9, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
            }
            else
            {
                tmp.Add(CommonView.GetGridViewColumn("Credit", "Credit", 90, 8, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
                tmp.Add(CommonView.GetGridViewColumn("Debit", "Debit", 90, 9, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
            }

            tmp.Add(CommonView.GetGridViewColumn("DocRefId", "DocRefId", 0, 10));
            tmp.Add(CommonView.GetGridViewColumn("AccId", "AccId", 0, 11));
            tmp.Add(CommonView.GetGridViewColumn("Accode", "Accode", 0, 12));
            tmp.Add(CommonView.GetGridViewColumn("Acdesc", "Ledger", 0, 13, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            //tmp.Add(CommonView.GetGridViewColumn("Acdesc", "Acdesc", 0, 13));
            //tmp.Add(CommonView.GetGridViewColumn("Nar1", "Nar1", 0, 14));
            //tmp.Add(CommonView.GetGridViewColumn("Nar2", "Nar2", 0, 15));
            //tmp.Add(CommonView.GetGridViewColumn("Nar3", "Nar3", 0, 16));
            //tmp.Add(CommonView.GetGridViewColumn("Nar4", "Nar4", 0, 17));
            //tmp.Add(CommonView.GetGridViewColumn("Nar5", "Nar5", 0, 18));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 14));
            tmp.Add(CommonView.GetGridViewColumn("tranDt", "TranDt", 0, 15));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = true;
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = true;
            return 0;

        }


        #endregion
        public DataTable AllLedDs(int SubGrpId1)
        {

            SqlConnection Con = new SqlConnection(Common.ConStr);
            DataTable Tbl = new DataTable();

            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            //Cmd = new SqlCommand("Acc_Qry_achdVw", Con);
            Cmd = new SqlCommand("Acc_Qry_SubGrpWise_achdallvw", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter Param = new SqlParameter("@SubGrpId1", SqlDbType.Int);
            Param.Value = SubGrpId1;
            Cmd.Parameters.Add(Param);

            Param = new SqlParameter("@compid", SqlDbType.TinyInt);
            Param.Value = Common.CId;
            Cmd.Parameters.Add(Param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "achdVw";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }
    }
}
