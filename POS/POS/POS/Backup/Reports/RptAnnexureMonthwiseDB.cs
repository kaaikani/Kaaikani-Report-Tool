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
	/// Summary description for SalesDb.
	/// </summary>
    public class RptAnnexureMonthwiseDb
	{
        public RptAnnexureMonthwiseDb()
		{
			//
			// TODO: Add constructor logic here
			//
		}


        public DataTable PurAnnexRptSource(DateTime FrmDt, DateTime ToDt)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_RptPurAnnexure", Con);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("@FrmDt", SqlDbType.DateTime);
            param.Value = FrmDt;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@ToDt", SqlDbType.DateTime);
            param.Value = ToDt;
            Cmd.Parameters.Add(param);
            
            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "Qry_RptPurAnnexure";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }
        public DataTable SaleAnnexRptSource(DateTime FrmDt, DateTime ToDt, String Mode)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_RptSalAnnexureMon", Con);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("@FrmDt", SqlDbType.DateTime);
            param.Value = FrmDt;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@ToDt", SqlDbType.DateTime);
            param.Value = ToDt;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Mode", SqlDbType.VarChar,2);
            param.Value = Mode;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "Qry_RptSalAnnexureMon";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }
	}
}
