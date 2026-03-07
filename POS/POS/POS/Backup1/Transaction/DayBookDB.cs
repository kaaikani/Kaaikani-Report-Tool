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
    public class DayBookDB : BooksDB
    {
        public DayBookDB() :base(BooksType.DayBook )
        {
            //
            // TODO: Add constructor logic here
            //
        }

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
        public string PrintSize_Source()
        {
            string Result;
            SqlConnection Con = new SqlConnection(Common.ConStr);
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Config_Qry_GetStringvalue", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@ConfigId", SqlDbType.Int);
            param.Value = 39;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Result = Convert.ToString(Cmd.ExecuteScalar());

            Cmd.Dispose();
            Con.Close();
            return Result;
        }
   
        public double OpBal(DateTime FromDt)
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
            Param.Value = 0;
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
    


        public DataTable DayBookDs(DateTime FromDt, DateTime ToDt, string Condn)
        {
            
            SqlConnection Con = new SqlConnection(Common.ConStr);
            DataTable Tbl = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Acc_Qry_DayBook", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@FromDt", SqlDbType.DateTime);
            param.Value = FromDt.ToString("dd/MMM/yyyy");
            Cmd.Parameters.Add(param);

            SqlParameter Param = new SqlParameter("@ToDt", SqlDbType.DateTime);
            Param.Value = ToDt.ToString ("dd/MMM/yyyy");
            Cmd.Parameters.Add(Param);
            
            Param = new SqlParameter("@Condn", SqlDbType.VarChar,50);
            Param.Value = Condn;
            Cmd.Parameters.Add(Param);

            Param = new SqlParameter("@DocRefId", SqlDbType.Int);
            Param.Value = 0;
            Cmd.Parameters.Add(Param);

            Param = new SqlParameter("@DocRef", SqlDbType.VarChar, 5);
            Param.Value = "";
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
            return Tbl;
        }

        public int DayBook_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            Boolean ctdt ;
            ctdt = CrDr();
            tmp.Add(CommonView.GetGridViewDateColumn("Dt", "Date", 80, 1,true ,DataGridViewContentAlignment.MiddleLeft,"dd/MM/yyyy", DataGridViewAutoSizeColumnMode.NotSet));
            tmp.Add(CommonView.GetGridViewColumn("DocType", "DocType", 0, 2));
            tmp.Add(CommonView.GetGridViewColumn("DocNo", "DocNo", 0, 3));
            tmp.Add(CommonView.GetGridViewColumn("Ledger", "Ledger", 170, 4,true, DataGridViewContentAlignment.MiddleLeft ,"", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Narration", "Narration", 170, 5, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            if (ctdt == true)
            {
                tmp.Add(CommonView.GetGridViewColumn("Debit", "Debit", 80, 6, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
                tmp.Add(CommonView.GetGridViewColumn("Credit", "Credit", 80, 7, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
            }
            else
            {
                tmp.Add(CommonView.GetGridViewColumn("Credit", "Credit", 80, 6, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
                tmp.Add(CommonView.GetGridViewColumn("Debit", "Debit", 80, 7, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
            }
            tmp.Add(CommonView.GetGridViewColumn("Balance", "Balance", 90, 8, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
            tmp.Add(CommonView.GetGridViewColumn("docRefId", "docRefId", 0,9));
            tmp.Add(CommonView.GetGridViewColumn("Updownno", "Updownno", 0, 10));
            tmp.Add(CommonView.GetGridViewColumn("AccId", "AccId", 0, 11));
            tmp.Add(CommonView.GetGridViewColumn("amount", "Amount", 0, 12));
            tmp.Add(CommonView.GetGridViewColumn("drcr", "drcr", 0, 13));
            tmp.Add(CommonView.GetGridViewColumn("party", "party", 0, 14));
            tmp.Add(CommonView.GetGridViewColumn("Nar1", "Nar1", 0, 15));
            tmp.Add(CommonView.GetGridViewColumn("Nar2", "Nar2", 0, 16));
            tmp.Add(CommonView.GetGridViewColumn("Nar3", "Nar3", 0, 17));
            tmp.Add(CommonView.GetGridViewColumn("Nar4", "Nar4", 0, 18));
            tmp.Add(CommonView.GetGridViewColumn("Nar5", "Nar5", 0, 19));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 20));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = true;
            return 0;
            
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
        


          public DataTable DaySumDs(DateTime FromDt, DateTime ToDt, string Condn)
        {
            
            SqlConnection Con = new SqlConnection(Common.ConStr);
            DataTable Tbl = new DataTable();
           
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Acc_Qry_Datesumfn", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@FromDt", SqlDbType.DateTime);
            param.Value = FromDt.ToString ("dd/MMM/yyyy");
            Cmd.Parameters.Add(param);

            SqlParameter Param = new SqlParameter("@ToDt", SqlDbType.DateTime);
            Param.Value = ToDt.ToString("dd/MMM/yyyy");
            Cmd.Parameters.Add(Param);

            Param = new SqlParameter("@condn", SqlDbType.VarChar,50);
            Param.Value = Condn;
            Cmd.Parameters.Add(Param);
 
            Param = new SqlParameter("@compid", SqlDbType.TinyInt);
            Param.Value = Common.CId;
            Cmd.Parameters.Add(Param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "DateSum";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }


        public int DaySum_GridStyle(DataGridViewColumnCollection tmp)
        {
            Boolean ctdt;
            ctdt = CrDr();
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewDateColumn("Dt", "Date",80,1,true,DataGridViewContentAlignment.MiddleLeft,"dd/MM/yyyy",DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Narration", "", 0, 2));
            if (ctdt == true)
            {
                tmp.Add(CommonView.GetGridViewColumn("Debit", "Debit", 100, 3, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
                tmp.Add(CommonView.GetGridViewColumn("Credit", "Credit", 100, 4, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
            }
            else
            {
                tmp.Add(CommonView.GetGridViewColumn("Credit", "Credit", 100, 3, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
                tmp.Add(CommonView.GetGridViewColumn("Debit", "Debit", 100, 4, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
            }
            tmp.Add(CommonView.GetGridViewColumn("Balance", "Balance", 90, 5, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
               
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = true;
            return 0;
           
        }
    }
}
