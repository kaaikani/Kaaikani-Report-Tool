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
	/// Summary description for SalesDb.
	/// </summary>
	public class CommonTransDb
	{
        public CommonTransDb()
		{
			//
			// TODO: Add constructor logic here
			//
		}
        public DataTable QtyDicimalPlace()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Config_Qry_GetStringvalue", Con);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("@ConfigId", SqlDbType.Int);
            param.Value = 18;
            Cmd.Parameters.Add(param);
            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "QtyDicimalPlace";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }
        public DataTable MaxSalno(bool Retail,bool cash,int BookId )
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_MaxSalNo", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@Retail", SqlDbType.Bit);
            param.Value = (Retail==true? 1:0) ;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Cash", SqlDbType.Bit);
            param.Value = (cash == true ? 1 : 0);
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@BookId", SqlDbType.Int);
            param.Value = BookId;
            Cmd.Parameters.Add(param);


            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "MaxNo";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }

        public DataTable CMSbankLisence_Source()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("CMSbankLisence_Source", Con);
            Cmd.CommandType = CommandType.StoredProcedure;
            

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "Lisence";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }
    }
}
