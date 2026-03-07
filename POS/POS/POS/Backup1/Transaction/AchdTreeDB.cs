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
    /// Summary description for PartyDB.
    /// </summary>
    public class AchdTreeDB 
    {
        public AchdTreeDB()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        # region "Properties"

        ADODB.Recordset LedRS;

        string _Accode1;
        public string Accode1
        {
            get
            {
                return (string)LedRS.Fields["Accode"].Value;
            }

        }

        string _Acdesc1;
        public string Acdesc1
        {
            get
            {
                return (string)LedRS.Fields["Acdesc"].Value;
            }

        }
        string _senior;
        public string senior
        {
            get
            {
                return (string)LedRS.Fields["SeniorI"].Value;
            }

        }

        string _Led;
        public string Led
        {
            get
            {
                return (string)LedRS.Fields["ledgr"].Value;
            }

        }
#endregion

        public DataTable AllLedDs()
        {

            SqlConnection Con = new SqlConnection(Common.ConStr);
            DataTable Tbl = new DataTable();

            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Acc_Qry_AchdAll", Con);
            Cmd.CommandType = CommandType.StoredProcedure;



            SqlParameter Param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            Param.Value = Common.CId;
            Cmd.Parameters.Add(Param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "achd";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }
        public DataTable AllLedDs(int SubGrpId1)
        {

            SqlConnection Con = new SqlConnection(Common.ConStr);
            DataTable Tbl = new DataTable();

            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            //Cmd = new SqlCommand("Acc_Qry_AchdAll", Con);
            Cmd = new SqlCommand("Acc_Qry_SubGrpWise_achdallvw", Con);
            Cmd.CommandType = CommandType.StoredProcedure;



            SqlParameter Param = new SqlParameter("@SubGrpId1", SqlDbType.Int);
            Param.Value = SubGrpId1;
            Cmd.Parameters.Add(Param);

            Param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            Param.Value = Common.CId;
            Cmd.Parameters.Add(Param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "achd";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }
        public DataTable LedDs()
        {

            SqlConnection Con = new SqlConnection(Common.ConStr);
            DataTable Tbl = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Acc_Qry_achdvw", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

           SqlParameter Param = new SqlParameter("@compid", SqlDbType.TinyInt);
            Param.Value = Common.CId;
            Cmd.Parameters.Add(Param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "LedRpt";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }

   }
}
