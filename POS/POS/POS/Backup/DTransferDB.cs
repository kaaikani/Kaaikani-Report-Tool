using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using GridStructures;
using DBAccess;

namespace RLPOSDB
{
    public class DTransferDB
    {

       
            public DTransferDB()
            {
                //
                // TODO: Add constructor logic here
                //
            }

            string bckDatabase;
            public string BckDatabase
            {
                get
                {
                    return bckDatabase;
                }
                set
                {
                    bckDatabase = value;
                }
            }

            string TobckDatabase;
            public string ToBckDatabase
            {
                get
                {
                    return TobckDatabase;
                }
                set
                {
                    TobckDatabase = value;
                }
            }

            #region "Method"


            public void AttBck(string dbname, String BckPath,String BckString)
            {
                string filename;
                DataTable Tbl = new DataTable();
                SqlConnection Con = new SqlConnection(Common.MasConStr);
                Con.Open();

                SqlCommand Cmd;
                //dbname = dbname + 'A';
                dbname = dbname + BckString ;
                filename = BckPath + "data\\" + dbname + "_Data.mdf";

                Cmd = new SqlCommand("sp_attach_db", Con);
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param;

                param = new SqlParameter("@dbname", SqlDbType.VarChar, 20);
                param.Value = dbname;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@filename1", SqlDbType.NVarChar, 260);
                param.Value = filename;
                Cmd.Parameters.Add(param);
                
                 bckDatabase = dbname;
                

                Cmd.ExecuteNonQuery();

                try
                {


                    Cmd = new SqlCommand("UserAdd", Con);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    param = new SqlParameter("@dbname", SqlDbType.VarChar, 20);
                    param.Value = dbname;
                    Cmd.Parameters.Add(param);
                    Cmd.ExecuteNonQuery();
                }
                catch
                {
                }
                Cmd.Dispose();
                Con.Close();

            }

        public void TranferAttBck(string FrmDbName,string ToDbname, String BckPath, String BckString,byte UserId,byte CompId)
        {
            string filename;
            DataTable Tbl = new DataTable();
            SqlConnection MasCon = new SqlConnection(Common.MasConStr);
            MasCon.Open();

            SqlCommand Cmd;
            //dbname = dbname + 'A';
            ToDbname = ToDbname + BckString;
            filename = BckPath + "data\\" + ToDbname + "_Data.mdf";

            Cmd = new SqlCommand("sp_attach_db", MasCon);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            param = new SqlParameter("@dbname", SqlDbType.VarChar, 20);
            param.Value = ToDbname;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@filename1", SqlDbType.NVarChar, 260);
            param.Value = filename;
            Cmd.Parameters.Add(param);

            bckDatabase = ToDbname;
            Cmd.ExecuteNonQuery();

         
            try
            {


                Cmd = new SqlCommand("UserAdd", MasCon );
                Cmd.CommandType = CommandType.StoredProcedure;
                param = new SqlParameter("@dbname", SqlDbType.VarChar, 20);
                param.Value = ToDbname;
                Cmd.Parameters.Add(param);
                Cmd.ExecuteNonQuery();
            }
            catch
            {
            }
            Cmd.Dispose();
            MasCon.Close();

        }

        public void TransferDataSp(string Frmdbname,string TodbName,byte CompId)
        {

            try
            {


                DataTable Tbl = new DataTable();
                SqlConnection Con = new SqlConnection(Common.ConStr );
                Con.Open();
                SqlCommand Cmd;

                Cmd = new SqlCommand("pendrivesp", Con);
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param;

                param = new SqlParameter("@FrmDbName", SqlDbType.VarChar, 30);
                param.Value = Frmdbname;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@ToDbName", SqlDbType.VarChar, 30);
                param.Value = TodbName;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CompId", SqlDbType.TinyInt );
                param.Value = CompId ;
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

            public void DeatBck(string dbname)
            {

                try
                {

                    DataTable Tbl = new DataTable();
                    SqlConnection Con = new SqlConnection(Common.MasConStr);
                    Con.Open();
                    SqlCommand Cmd;

                    Cmd = new SqlCommand("sp_detach_db", Con);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param;

                    param = new SqlParameter("@dbname", SqlDbType.VarChar, 20);
                    param.Value = dbname;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@keepfulltextindexfile", SqlDbType.VarChar, 20);
                    param.Value = true;
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

            #endregion




       


    }


}
