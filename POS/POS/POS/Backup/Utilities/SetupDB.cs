using System;
using System.Data;
using System.Data.SqlClient;
using GridStructures;
using DBAccess;
using RLPOSDB;
using System.Windows.Forms;

namespace RLPOSDB
{
	/// <summary>
	/// Summary description for RptStockLedDB.
	/// </summary>
    public class SetupDB
    {
        public SetupDB()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        DataTable _Dst;
        public DataTable Dst
        {
            get
            {
                return _Dst;
            }
            set
            {
                _Dst = value;
            }
        }
        public DataTable ImportListofTablesSource()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.CustConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Import_Qry_ListofTables", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            //SqlParameter param = new SqlParameter("@TransFrmDB", SqlDbType.VarChar, 50);
            //param.Value = TransferFrmDB;
            //Cmd.Parameters.Add(param);

            //param = new SqlParameter("@TblName", SqlDbType.VarChar, 50);
            //param.Value = TblName;
            //Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "AllTables";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }

        public DataTable ImportListofColumnsSource(string TransferFrmDB,string TblName)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Import_Qry_ColumnsList", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@TransFrmDB", SqlDbType.VarChar, 50);
            param.Value = TransferFrmDB;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@TblName", SqlDbType.VarChar, 50);
            param.Value = TblName;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "AllColumns";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }

        public DataTable ImportMatchSource(string TransferFrmDB,string TblName)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Import_Qry_MatchFields", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@TransFrmDB", SqlDbType.VarChar, 50);
            param.Value = TransferFrmDB;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@TblName", SqlDbType.VarChar, 50);
            param.Value = TblName;
            Cmd.Parameters.Add(param);
          
            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "Import";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }
        public void ImportInsertProcessSource(string TransferFrmDB,string TransferToDB,string TblName,string ColName,string ExtraFields,string Type)
        {
            try
            {
                SqlConnection Con = new SqlConnection(Common.ConStr);
                SqlDataAdapter Da = new SqlDataAdapter();
                Con.Open();
                SqlCommand Cmd;

                Cmd = new SqlCommand("Import_Qry_Insert", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@TransferFrmDB", SqlDbType.VarChar, 50);
                param.Value = TransferFrmDB;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TransferToDB", SqlDbType.VarChar, 50);
                param.Value = TransferToDB;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TblName", SqlDbType.VarChar, 50);
                param.Value = TblName;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@ColName", SqlDbType.VarChar, 200);
                param.Value = ColName;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@ExtraFields", SqlDbType.VarChar, 200);
                param.Value = ExtraFields;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.VarChar, 50);
                param.Value = Type;
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
        #region "Delete Process"
        public DataTable DelProcesssource(string DBName)
        {
            //qry_RptAnxSal(@Mode tinyint,@frmDt datetime,@ToDt Datetime,@VatMode varchar(5),@Compid tinyint)
            try
            {
                SqlConnection MyCon = new SqlConnection();
                SqlCommand MyCmd = new SqlCommand();
                SqlParameter MyParam = new SqlParameter();
                SqlDataAdapter MyAdapt = new SqlDataAdapter();
                DataTable DTbl = new DataTable();

                MyCon = new SqlConnection(Common.ConStr);
                MyCon.Open();

                MyCmd = new SqlCommand("DeleteProcessSp", MyCon);
                MyCmd.CommandType = CommandType.StoredProcedure;
              
                MyParam = new SqlParameter("@DBName", SqlDbType.VarChar);
                MyParam.Value = DBName;
                MyCmd.Parameters.Add(MyParam);

                MyAdapt.SelectCommand = MyCmd;
                MyAdapt.Fill(DTbl);

                DTbl.TableName = "DeleteProcessSp";
                MyAdapt.Dispose();
                MyCmd.Dispose();
                MyCon.Close();
                return DTbl;
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
        # endregion

        public DataTable ImportListofTblCountSource(string TblName)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Import_Qry_CheckTblCount", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@TblName", SqlDbType.VarChar, 50);
            param.Value = TblName;
            Cmd.Parameters.Add(param);

            //param = new SqlParameter("@TblName", SqlDbType.VarChar, 50);
            //param.Value = TblName;
            //Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "AllTables";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }
        public DataTable ImportListofCustTblCountSource(string TblName)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.CustConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Import_Qry_CheckTblCount", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@TblName", SqlDbType.VarChar, 50);
            param.Value = TblName;
            Cmd.Parameters.Add(param);

            //param = new SqlParameter("@TblName", SqlDbType.VarChar, 50);
            //param.Value = TblName;
            //Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "AllTables";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }
    }
}
