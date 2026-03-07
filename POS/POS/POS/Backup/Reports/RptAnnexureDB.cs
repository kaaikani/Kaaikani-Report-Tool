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
    public class RptAnnexureDb
	{
        public RptAnnexureDb()
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

        public DataTable PurAnnexRptGstSource(DateTime FrmDt, DateTime ToDt, string Yr)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_RptPurAnnexure_Gst", Con);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("@FrmDt", SqlDbType.DateTime);
            param.Value = FrmDt;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@ToDt", SqlDbType.DateTime);
            param.Value = ToDt;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Yr", SqlDbType.VarChar, 20);
            param.Value = Yr;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "Qry_RptPurAnnexure_Gst";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }


        public DataTable PurAnnexRptSource_Hsn(DateTime FrmDt, DateTime ToDt)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_RptPurAnnexure_Hsn", Con);
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
            Tbl.TableName = "Qry_RptPurAnnexure_Hsn";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }

        public DataTable SaleAnnexRptSource(DateTime FrmDt, DateTime ToDt)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_RptSalAnnexure", Con);
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
            Tbl.TableName = "Qry_RptSalAnnexure";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }

        public DataTable SaleAnnexRptSource_Hsn(DateTime FrmDt, DateTime ToDt)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_RptSalAnnexure_Hsn", Con);
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
            Tbl.TableName = "Qry_RptSalAnnexure_Hsn";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }

        public DataTable SaleAnnexRptSource_Hsn_Cess(DateTime FrmDt, DateTime ToDt)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_RptSalAnnexure_Hsn_CESS", Con);
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
            Tbl.TableName = "Qry_RptSalAnnexure_Hsn_CESS";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }
	}

}
