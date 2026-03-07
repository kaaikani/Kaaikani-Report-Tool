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

        public int GetReversFeedValue(int configid)
        {
            try
            {

                DataTable Tbl = new DataTable();
                SqlConnection Con = new SqlConnection(Common.ConStr);
                SqlDataAdapter Da = new SqlDataAdapter();
                Con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("Config_Qry_GetStringvalue", Con);
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@ConfigId", SqlDbType.Int);
                param.Value = configid;
                Cmd.Parameters.Add(param);
                param = new SqlParameter("@Compid", SqlDbType.TinyInt);
                param.Value = Common.CId;
                Cmd.Parameters.Add(param);

                Da.SelectCommand = Cmd;
                Da.Fill(Tbl);
                Tbl.TableName = "Config_Qry_GetStringvalue";
                Da.Dispose();
                Cmd.Dispose();
                Con.Close();
                return Convert.ToInt32(Tbl.Rows[0][0]);

            }
            catch (Exception ex)
            {
                throw ex;
            }


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


        public DataTable Config_SalRec(char FormType)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_Config_Sales", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@FormType", SqlDbType.Char,5);
            MyParam.Value = FormType;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_Config_BarModel";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }
        public DataTable Lisence_Source()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_License", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "Lisence";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }
        public void LicenseDeletion()
        {

            DataSet Ds = new DataSet();
            string DetStr;

            try
            {
                SqlConnection Con = new SqlConnection(Common.MasConStr);
                SqlDataAdapter Da = new SqlDataAdapter();
                Con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("DeleteMnuSp", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

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

        public DataTable DateLockSource()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.MasConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_DateLock", Con);
            Cmd.CommandType = CommandType.StoredProcedure;
            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }
        public DataTable UserDeletionSource()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.MasConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_UserDeletion", Con);
            Cmd.CommandType = CommandType.StoredProcedure;
            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }
      
        public Boolean getconfiqtax(int id)
        {
            Boolean Result;
            SqlConnection Con = new SqlConnection(Common.ConStr);
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Config_Qry_GetBitvalue", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@ConfigId", SqlDbType.Int);
            param.Value = id;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Result = Convert.ToBoolean(Cmd.ExecuteScalar());

            Cmd.Dispose();
            Con.Close();
            return Result;
        }

        #region "Client License"

        public void Save(string HostName, string MasDbName)
        {

            SqlConnection Con = new SqlConnection(Common.MasConStr);
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("HostSp", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@HostName", SqlDbType.VarChar, 100);
            param.Value = HostName;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@MasDBName", SqlDbType.VarChar, 100);
            param.Value = MasDbName;
            Cmd.Parameters.Add(param);

            Cmd.ExecuteNonQuery();
            Cmd.Dispose();
            Con.Close();

        }

        public DataTable NoofClient()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.MasConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_NoofClient", Con);
            Cmd.CommandType = CommandType.StoredProcedure;


            SqlParameter param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "NoofClient";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }
        #endregion
    }
}
