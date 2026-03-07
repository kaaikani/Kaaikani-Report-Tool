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
    public class OpBalDB
    {
        public OpBalDB()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable OPBal_Source()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Acc_Qry_OpBalUpd", Con);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "OPBalDet";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            foreach (DataColumn Col in Tbl.Columns)
            {
                switch (Col.DataType.UnderlyingSystemType.Name)
                {
                    case "String":
                        Col.AllowDBNull = false;
                        Col.DefaultValue = "";
                        break;
                    case "Byte":
                        Col.DefaultValue = 0;
                        Col.AllowDBNull = false;
                        break;
                    case "int":
                        Col.AllowDBNull = false;
                        Col.DefaultValue = 0;
                        break;
                    case "Int32":
                        Col.AllowDBNull = false;
                        Col.DefaultValue = 0;
                        break;
                    case "Int16":
                        Col.AllowDBNull = false;
                        Col.DefaultValue = 0;
                        break;
                    case "Single":
                        Col.AllowDBNull = false;
                        Col.DefaultValue = 0.0;
                        break;
                    case "Double":
                        Col.AllowDBNull = false;
                        Col.DefaultValue = 0.0;
                        break;
                    case "Decimal":
                        Col.DefaultValue = 0.0;
                        Col.AllowDBNull = false;
                        break;
                    case "Boolean":
                        Col.DefaultValue = true;
                        Col.AllowDBNull = false;
                        break;

                    case "DateTime":
                        Col.DefaultValue = "01/01/1900";
                        Col.AllowDBNull = false;
                        break;
                    case "Guid":
                        Col.DefaultValue = "00000000-0000-0000-0000-000000000000";
                        Col.AllowDBNull = false;
                        break;

                }
            }
            return Tbl;
        }
        public int OPbal_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            Boolean DrCr;
            DrCr = GetConfigValuefor(38);
            tmp.Add(CommonView.GetGridViewColumn("AccId", "AccId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Accode", "Accode", 0, 2));
            tmp.Add(CommonView.GetGridViewColumn("Ledger", "Ledger", 140, 3, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("SubGroupName", "GroupName", 140, 4, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            if (DrCr == true)
            {
                tmp.Add(CommonView.GetGridViewColumn("Debit", "Debit", 70, 5, false, DataGridViewContentAlignment.MiddleRight, "###0.00", DataGridViewAutoSizeColumnMode.NotSet));
                tmp.Add(CommonView.GetGridViewColumn("Credit", "Credit", 70, 6, false, DataGridViewContentAlignment.MiddleRight, "###0.00", DataGridViewAutoSizeColumnMode.NotSet));
                
            }
            else
            {
                tmp.Add(CommonView.GetGridViewColumn("Credit", "Credit", 70, 5, false, DataGridViewContentAlignment.MiddleRight, "###0.00", DataGridViewAutoSizeColumnMode.NotSet));
                tmp.Add(CommonView.GetGridViewColumn("Debit", "Debit", 70, 6, false, DataGridViewContentAlignment.MiddleRight, "###0.00", DataGridViewAutoSizeColumnMode.NotSet));
            
            }
            tmp.Add(CommonView.GetGridViewColumn("Subgrpid1", "Subgrpid1", 0, 7));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        public Boolean GetConfigValuefor(int ConfigId)
        {
            Boolean Result;
            SqlConnection Con = new SqlConnection(Common.ConStr);
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Config_Qry_Getbitvalue", Con);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("@ConfigId", SqlDbType.Int);
            param.Value = ConfigId;
            Cmd.Parameters.Add(param);
            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Result = Convert.ToBoolean(Cmd.ExecuteScalar());

            Cmd.Dispose();
            Con.Close();
            return Result;
        }

    

        public void SaveFunction()
        {

            int Modeval = 0;
            //if (Mode == Saving.SaveType.Add)
            //    Modeval = 1;
            //else if (Mode == Saving.SaveType.Edit)
            //    Modeval = 2;
            //else if (Mode == Saving.SaveType.Delete)
            //    Modeval = 3;
            //else if (Mode == Saving.SaveType.DocCancel)
            //    Modeval = 8;

            try
            {
                SqlConnection Con = new SqlConnection(Common.ConStr);
                SqlDataAdapter Da = new SqlDataAdapter();
                Con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("Acc_OpBalUpdsp", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@AccId", SqlDbType.Int);
                param.Value = _AccId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Debit", SqlDbType.Decimal);
                param.Value = _Debit;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Credit", SqlDbType.Decimal);
                param.Value = _Credit;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.TinyInt);
                param.Value = Common.UserId;
                Cmd.Parameters.Add(param);


                param = new SqlParameter("@Compid", SqlDbType.TinyInt);
                param.Value = Common.CId;
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



        #region  "Proeprties"
        private int _AccId;

        public int AccId
        {
            get { return _AccId; }
            set { _AccId = value; }
        }
        private decimal _Debit;

        public decimal Debit
        {
            get { return _Debit; }
            set { _Debit = value; }
        }
        private decimal _Credit;

        public decimal Credit
        {
            get { return _Credit; }
            set { _Credit = value; }
        }
        private decimal _GoldDebitWt;

        public decimal GoldDebitWt
        {
            get { return _GoldDebitWt; }
            set { _GoldDebitWt = value; }
        }
        private decimal _GoldCreditWt;

        public decimal GoldCreditWt
        {
            get { return _GoldCreditWt; }
            set { _GoldCreditWt = value; }
        }
        private decimal _SilverDebitWt;

        public decimal SilverDebitWt
        {
            get { return _SilverDebitWt; }
            set { _SilverDebitWt = value; }
        }
        private decimal _SilverCreditWt;

        public decimal SilverCreditWt
        {
            get { return _SilverCreditWt; }
            set { _SilverCreditWt = value; }
        }
        #endregion
    }
}
