using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using GridStructures;
using System.Globalization;
using DBAccess;

using RLPOSDB;

namespace RLPOSDB
{
    /// <summary>
    /// Summary description for PartyDB.
    /// </summary>
    public class ComInfoDB
    {
        public ComInfoDB()
        {
            //
                       // TODO: Add constructor logic here
            //
        }


        
        public void  SaveFunction(int ActId,string ActName,DateTime  ActDt)
        {
                        
            try
            {
                SqlConnection Con = new SqlConnection(Common.ConStr);
                SqlDataAdapter Da = new SqlDataAdapter();
                Con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("ComInfoSp", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@ActId", SqlDbType.Int);
                param.Value = ActId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Actname", SqlDbType.DateTime);
                param.Value = ActName.ToString();
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@ActDt", SqlDbType.DateTime);
                param.Value = ActDt.ToString("dd/MMM/yyyy");
                Cmd.Parameters.Add(param);

             
                param = new SqlParameter("@UserId", SqlDbType.TinyInt);
                param.Value = Common.UserId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CompId", SqlDbType.TinyInt);
                param.Value = Common.CId;
                Cmd.Parameters.Add(param);

                               //Cmd.ExecuteNonQuery();
                Cmd.ExecuteScalar();
               
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




