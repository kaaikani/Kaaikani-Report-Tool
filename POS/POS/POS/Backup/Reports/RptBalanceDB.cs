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
    /// Summary description for PartyDB.
    /// </summary>
    public class RptBalanceDB
    {
        public RptBalanceDB()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        # region "Customer Balance"
        public DataTable CustomerBalance_Source(string Cond)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_CustomerBalance", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Cond", SqlDbType.VarChar,100);
            MyParam.Value = Cond;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_CustomerBalance";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public int CustomerBalance_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("AccId", "AccId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Customer", "Customer", 100, 2, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Add1", "Address", 120, 3, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Add2", "Add2", 0, 4));
            tmp.Add(CommonView.GetGridViewColumn("Add3", "Add3", 0, 5));
            tmp.Add(CommonView.GetGridViewColumn("Area", "Area", 120, 6, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("City", "City", 120, 7, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("ph1", "ph1", 0, 8));
            tmp.Add(CommonView.GetGridViewColumn("ph2", "ph2", 0, 9));
            tmp.Add(CommonView.GetGridViewColumn("Cell", "Cell", 90, 10, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Balance", "Balance", 80, 11, true, DataGridViewContentAlignment.MiddleRight));
            tmp.Add(CommonView.GetGridViewColumn("Bal", "Bal", 0, 12));
            //tmp.Add(CommonView.GetGridViewColumn("GoldMetalBal", "GldBalance", 80, 10, true, DataGridViewContentAlignment.MiddleRight));
            //tmp.Add(CommonView.GetGridViewColumn("SlvMetalBal", "SlvBalance", 80, 11, true, DataGridViewContentAlignment.MiddleRight));
            //tmp.Add(CommonView.GetGridViewColumn("Bal", "Bal", 0, 9, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            //tmp.Add(CommonView.GetGridViewColumn("GoldBal", "GoldBal", 0, 9, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            //tmp.Add(CommonView.GetGridViewColumn("SlvBal", "SlvBal", 0, 9, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 12));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

      

        #endregion

        public Boolean getconfiqtax(int Id)
        {
            Boolean Result;
            SqlConnection Con = new SqlConnection(Common.ConStr);
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Config_Qry_GetBitvalue", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@ConfigId", SqlDbType.Int);
            param.Value = Id;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Result = Convert.ToBoolean(Cmd.ExecuteScalar());

            Cmd.Dispose();
            Con.Close();
            return Result;
        }

        # region "Supplier Balance"
        public DataTable SupplierBalance_Source(string Cond)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_SupplierBalance", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Cond", SqlDbType.VarChar, 200);
            MyParam.Value = Cond;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_SupplierBalance";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public int SupplierBalance_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("AccId", "AccId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Supplier", "Supplier", 100, 2, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Add1", "Address", 120, 3, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Add2", "Add2", 0, 4));
            tmp.Add(CommonView.GetGridViewColumn("Add3", "Add3", 0, 5));
            tmp.Add(CommonView.GetGridViewColumn("Area", "Area", 120, 6, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("City", "City", 120, 7, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("ph1", "ph1", 0, 8));
            tmp.Add(CommonView.GetGridViewColumn("ph2", "ph2", 0, 9));
            tmp.Add(CommonView.GetGridViewColumn("Cell", "Cell", 90, 10, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Balance", "Balance", 80, 11, true, DataGridViewContentAlignment.MiddleRight));
            tmp.Add(CommonView.GetGridViewColumn("Bal", "Bal", 0, 12));
            //tmp.Add(CommonView.GetGridViewColumn("GoldMetalBal", "GldBalance", 80, 10, true, DataGridViewContentAlignment.MiddleRight));
            //tmp.Add(CommonView.GetGridViewColumn("SlvMetalBal", "SlvBalance", 80, 11, true, DataGridViewContentAlignment.MiddleRight));
            //tmp.Add(CommonView.GetGridViewColumn("Bal", "Bal", 0, 9, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            //tmp.Add(CommonView.GetGridViewColumn("GoldBal", "GoldBal", 0, 9, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            //tmp.Add(CommonView.GetGridViewColumn("SlvBal", "SlvBal", 0, 9, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 12));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }



        #endregion


        public DataTable SmsTemplate(int TempId)
        {
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            DataTable DTbl = new DataTable();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_SMSTemplateAll", Con);
            Cmd.CommandType = CommandType.StoredProcedure;


            SqlParameter param = new SqlParameter("@TempId", SqlDbType.Int);
            param.Value = TempId;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(DTbl);
            DTbl.TableName = "SmsTemplate";

            Da.Dispose();
            Cmd.Dispose();
            Con.Close();

            return DTbl;

        }
     
    }
}
