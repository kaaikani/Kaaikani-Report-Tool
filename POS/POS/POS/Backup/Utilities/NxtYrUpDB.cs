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
    public class NxtYrUpDB
    {
        public NxtYrUpDB()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region "NextYear-Updation "
        public DataTable NextYear_Stocksource(string ToDbName)
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

                MyCmd = new SqlCommand("NextYear_StockUpdSp", MyCon);
                MyCmd.CommandType = CommandType.StoredProcedure;

                MyParam = new SqlParameter("@ToDbName", SqlDbType.VarChar);
                MyParam.Value = ToDbName;
                MyCmd.Parameters.Add(MyParam);


                MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
                MyParam.Value = Common.CId;
                MyCmd.Parameters.Add(MyParam);

                MyAdapt.SelectCommand = MyCmd;
                MyAdapt.Fill(DTbl);

                DTbl.TableName = "NextYear_StockUpdSp";
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

        public DataTable NextYear_OpBalsource( DateTime Updt,string ToDbName)
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

                MyCmd = new SqlCommand("NextYear_OpBalUpdSp", MyCon);
                MyCmd.CommandType = CommandType.StoredProcedure;

                MyParam = new SqlParameter("@Updt", SqlDbType.DateTime );
                MyParam.Value = Updt;
                MyCmd.Parameters.Add(MyParam);

                MyParam = new SqlParameter("@ToDbName", SqlDbType.VarChar);
                MyParam.Value = ToDbName;
                MyCmd.Parameters.Add(MyParam);


                MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
                MyParam.Value = Common.CId;
                MyCmd.Parameters.Add(MyParam);

                MyAdapt.SelectCommand = MyCmd;
                MyAdapt.Fill(DTbl);

                DTbl.TableName = "NextYear_OpBalUpdSp";
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

        
    }
}
