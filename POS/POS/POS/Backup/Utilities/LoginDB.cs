using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using GridStructures;
using DBAccess;
using RLPOSDB;


namespace RLPOSDB
{
    public class LoginDB
    {


        public LoginDB()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public DataTable CompanySource()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.MasConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_Company", Con);
            Cmd.CommandType = CommandType.StoredProcedure;
            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }


        public DataTable AllCompanySource(bool Hide)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.MasConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_AllCompany", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@Hide", SqlDbType.Bit);
            param.Value = (Hide == true ? 1 : 0); ;

            Cmd.Parameters.Add(param);           
            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }



        public DataTable DBSelection()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.MasConStr);
            Con.Open();
            SqlCommand Cmd;
            SqlDataAdapter Da = new SqlDataAdapter();
            Cmd = new SqlCommand("Qry_DBSelection", Con);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("@compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            //			Cmd.Parameters.Add(param);		
            //			string ds;
            //			ds=(string)Cmd.ExecuteScalar();
            //			return ds;

            Cmd.Parameters.Add(param);
            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);


            //			//Da.SelectCommand=Cmd;
            //			//Da.Fill(Tbl);						
            //			//Tbl.TableName="Login";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;

        }


        public DataTable AccYrSelection()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.MasConStr);
            Con.Open();
            SqlCommand Cmd;
            SqlDataAdapter Da = new SqlDataAdapter();
            Cmd = new SqlCommand("Qry_AccYrSel", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@acyr", SqlDbType.VarChar, 20);
            param.Value = "";
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);


            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;

        }

        public DataTable AccYrSel(string Acyr)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.MasConStr);
            Con.Open();
            SqlCommand Cmd;
            SqlDataAdapter Da = new SqlDataAdapter();
            Cmd = new SqlCommand("Qry_AccYrSel", Con);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("@compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);
            Da.SelectCommand = Cmd;

            param = new SqlParameter("@Acyr", SqlDbType.VarChar, 20);
            param.Value = Acyr;
            Cmd.Parameters.Add(param);
            Da.SelectCommand = Cmd;

            Da.Fill(Tbl);


            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;

        }
        public string GetScript(string strObject, int ObjType)
        {
            string strScript = null;
            SqlDataAdapter ObjSqlDataAdapter=new SqlDataAdapter();
            SqlCommand ObjSqlCommand = new SqlCommand();
            int intCounter = 0;
            if (ObjType != 0)
            {
                SqlConnection Con = new SqlConnection(Common.ConStr);

                try
                {
                     strScript = " IF(SELECT 1 FROM SYSOBJECTS WHERE UPPER(NAME)='"+strObject+"')>0";
                     strScript +=  "  	DROP PROCEDURE "+strObject;
                     ObjSqlCommand = new SqlCommand(strScript, Con);
                     ObjSqlCommand.ExecuteNonQuery();

                    DataSet ObjDataSet = new DataSet();
                    ObjSqlCommand = new SqlCommand("exec sp_helptext [" + strObject + "]", Con);
                    ObjSqlDataAdapter = new SqlDataAdapter();
                    ObjSqlDataAdapter.SelectCommand = ObjSqlCommand;
                    ObjSqlDataAdapter.Fill(ObjDataSet);

                    foreach (DataRow ObjDataRow in ObjDataSet.Tables[0].Rows)
                    {
                        strScript += Convert.ToString(ObjDataSet.Tables[0].Rows[intCounter][0]);
                        intCounter++;
                    }
                }
                catch (Exception ex)
                {
                    strScript = ex.Message.ToString();
                }
                finally
                {
                    ObjSqlDataAdapter = null;
                    ObjSqlCommand = null;
                    Con = null;
                }
            }
            return strScript;
        }
        public void UpdateMasterProcessSource(bool RememLogin,short UserId)
        {
            try
            {
                SqlConnection Con = new SqlConnection(Common.MasConStr);
                SqlDataAdapter Da = new SqlDataAdapter();
                Con.Open();
                SqlCommand Cmd;
                SqlParameter param;
                Cmd = new SqlCommand("UpdateSecSP", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                param = new SqlParameter("@RememLogin", SqlDbType.Bit);
                param.Value = RememLogin;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.TinyInt);
                param.Value = UserId;
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
        public DataTable RememberLogin()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.MasConStr);
            Con.Open();
            SqlCommand Cmd;
            SqlDataAdapter Da = new SqlDataAdapter();

            Cmd = new SqlCommand("Qry_IsRememLogin", Con);
            Cmd.CommandType = CommandType.StoredProcedure;
            //SqlParameter param = new SqlParameter("@compid", SqlDbType.TinyInt);
            //param.Value = Common.CId;
            //Cmd.Parameters.Add(param);
            //Da.SelectCommand = Cmd;

            //param = new SqlParameter("@Acyr", SqlDbType.VarChar, 20);
            //param.Value = Acyr;
            //Cmd.Parameters.Add(param);
            Da.SelectCommand = Cmd;

            Da.Fill(Tbl);


            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;

        }
        public void ExecSp(string DetStr)
        {

            //qry_RptAnxSal(@Mode tinyint,@frmDt datetime,@ToDt Datetime,@VatMode varchar(5),@Compid tinyint)
            try
            {

                DetStr = DetStr.Replace("'", "''");
                DetStr = DetStr.Replace("true", "1");
                DetStr = DetStr.Replace("false", "0");

                SqlConnection Con = new SqlConnection(Common.ConStr);
                SqlDataAdapter Da = new SqlDataAdapter();
                Con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("UserKeyConfigSP", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@UserId", SqlDbType.TinyInt);
                param.Value = Common.UserId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CompId", SqlDbType.TinyInt);
                param.Value = Common.CId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DetStr", SqlDbType.Text);
                param.Value = DetStr;
                Cmd.Parameters.Add(param);

                Cmd.CommandTimeout = 5000;
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
    }
}
