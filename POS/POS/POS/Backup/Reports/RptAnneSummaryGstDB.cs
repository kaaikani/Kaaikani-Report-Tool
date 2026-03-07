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
    public class RptAnneSummaryGstDB
	{
        public RptAnneSummaryGstDB()
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

        public DataTable SaleAnnexRptSource(DateTime FrmDt, DateTime ToDt,string Yr)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_RptSalAnnexure_Gst", Con);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("@FrmDt", SqlDbType.DateTime);
            param.Value = FrmDt;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@ToDt", SqlDbType.DateTime);
            param.Value = ToDt;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Yr", SqlDbType.VarChar,20);
            param.Value = Yr;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "Qry_RptSalAnnexure_Gst";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }




        public DataTable SaleAnnexRptSourceSummary(DateTime FrmDt, DateTime ToDt)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_RptSalAnnexGSTSummary", Con);
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
            Tbl.TableName = "Qry_RptSalAnnexGSTSummary";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }

        #region"NeW Annxure"

        public DataTable SaleAnnexRptSourceGstNew(DateTime FrmDt, DateTime ToDt)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_RptGSTR1", Con);
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
            Tbl.TableName = "Qry_RptGSTR1";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }



        #endregion


        public DataTable SaleAnnexRptSourceGst2(DateTime FrmDt, DateTime ToDt,string Yr)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_RptSalAnnexure_Gst2", Con);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("@FrmDt", SqlDbType.DateTime);
            param.Value = FrmDt;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@ToDt", SqlDbType.DateTime);
            param.Value = ToDt;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Yr", SqlDbType.VarChar,20);
            param.Value = Yr;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "Qry_RptSalAnnexure_Gst2";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }

        public DataTable SaleAnnexRptSourceGst2Summary(DateTime FrmDt, DateTime ToDt, string Yr)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_RptSalAnnexure_Gst2Summary", Con);
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
            Tbl.TableName = "Qry_RptSalAnnexure_Gst2Summary";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }

        public DataTable SaleAnnexRptSource_Doc(DateTime FrmDt, DateTime ToDt)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_RptSalAnnexDoc", Con);
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
            Tbl.TableName = "Qry_RptSalAnnexDoc";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }
	}

}
