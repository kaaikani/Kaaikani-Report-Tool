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
    public class DayBookLedgerDB
    {
        public DayBookLedgerDB()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        # region "Properties"

        int _TranId;
        public int TranId
        {
            get
            {
                return _TranId;
            }
            set
            {
                _TranId = value;
            }
        }

        int _DocNo;
        public int DocNo
        {
            get
            {
                return _DocNo;
            }
            set
            {
                _DocNo = value;
            }
        }

        DateTime _TranDt;
        public DateTime TranDt
        {
            get
            {
                return _TranDt;
            }
            set
            {
                _TranDt = value;
            }
        }

        int _AccId;
        public int AccId
        {
            get
            {
                return _AccId;
            }
            set
            {
                _AccId = value;
            }
        }

        string _Nar1;
        public string Nar1
        {
            get
            {
                return _Nar1;
            }
            set
            {
                _Nar1 = value;
            }
        }

        string _Nar2;
        public string Nar2
        {
            get
            {
                return _Nar2;
            }
            set
            {
                _Nar2 = value;
            }
        }

        string _Nar3;
        public string Nar3
        {
            get
            {
                return _Nar3;
            }
            set
            {
                _Nar3 = value;
            }
        }

        string _Nar4;
        public string Nar4
        {
            get
            {
                return _Nar4;
            }
            set
            {
                _Nar4 = value;
            }
        }

        string _Nar5;
        public string Nar5
        {
            get
            {
                return _Nar5;
            }
            set
            {
                _Nar5 = value;
            }
        }

        decimal _Amount;
        public decimal Amount
        {
            get
            {
                return _Amount;
            }
            set
            {
                _Amount = value;
            }
        }

        decimal _Debit;
        public decimal Debit
        {
            get
            {
                return _Debit;
            }
            set
            {
                _Debit = value;
            }
        }

        decimal _Credit;
        public decimal Credit
        {
            get
            {
                return _Credit;
            }
            set
            {
                _Credit = value;
            }
        }

        string _DrCr;
        public string DrCr
        {
            get
            {
                return _DrCr;
            }
            set
            {
                _DrCr = value;
            }
        }

        byte _UserId;
        public byte UserId
        {
            get
            {
                return _UserId;
            }
            set
            {
                _UserId = value;
            }
        }

        byte _CompId;
        public byte CompId
        {
            get
            {
                return _CompId;
            }
            set
            {
                _CompId = value;
            }
        }
        int _No;
        public int No
        {
            get
            {
                return _No;
            }
            set
            {
                _No = value;
            }
        }

        # endregion

        public int SaveFunction(Saving.SaveType Mode)
        {
            int code = 0;
            int Modeval = 0;
            if (Mode == Saving.SaveType.Add)
                Modeval = 1;
            else if (Mode == Saving.SaveType.Edit)
                Modeval = 2;
            else if (Mode == Saving.SaveType.Delete)
                Modeval = 3;
            else if (Mode == Saving.SaveType.DocCancel)
                Modeval = 8;

            try
            {
                SqlConnection Con = new SqlConnection(Common.ConStr);
                SqlDataAdapter Da = new SqlDataAdapter();
                Con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("Acc_VoucherSP", Con);
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@mode", SqlDbType.TinyInt);
                param.Value = Modeval;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TranId", SqlDbType.Int);
                param.Value = TranId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DocNo", SqlDbType.Int);
                param.Value = DocNo;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TranDt", SqlDbType.DateTime);
                param.Value = TranDt.Date.ToString("dd/MMM/yyyy");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@AccId", SqlDbType.Int);
                param.Value = AccId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Nar1", SqlDbType.VarChar, 80);
                param.Value = _Nar1.Replace("'", "''");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Nar2", SqlDbType.VarChar, 80);
                param.Value = _Nar2.Replace("'", "''");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Nar3", SqlDbType.VarChar, 80);
                param.Value = _Nar3.Replace("'", "''");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Nar4", SqlDbType.VarChar, 80);
                param.Value = _Nar4.Replace("'", "''");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Nar5", SqlDbType.VarChar, 80);
                param.Value = _Nar5.Replace("'", "''");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Amount", SqlDbType.Decimal);
                param.Value = _Amount;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DrCr", SqlDbType.Char, 1);
                param.Value = _DrCr;
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

                param = new SqlParameter("@CompId", SqlDbType.TinyInt);
                param.Value = Common.CId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Id", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                Cmd.Parameters.Add(param);

                Cmd.ExecuteNonQuery();
                code = (int)Cmd.Parameters["@Id"].Value;

                return code;
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


        #region "For View Record"


        public System.Collections.Hashtable _FilteringValues = new System.Collections.Hashtable();
        _ViewValues _View;
        public struct _ViewValues
        {
            public System.Collections.Hashtable FilteringValues;
            public string TableNames;
            public string Fields;
            public string Conditions;
        }
        public void SetViewControl()
        {
            _FilteringValues.Clear();

            _View.FilteringValues = _FilteringValues;
            _View.TableNames = "Acc_VoucherFn(" + Common.CId + ")";
            _View.Fields = "*";
            _View.Conditions = "";
        }

        public DataTable Acc_Voucher_Source(DateTime FrmDt,DateTime ToDt)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("select TranId,TranDt,DocNo,AccId,Ledger,Nar1,Nar2,Nar3,Nar4,Nar5,Case When Debit>0 then Debit else 0 End as Debit,Case When Credit>0 then Credit else 0 end as Credit  from Acc_VoucherFn(" + Common.CId + ") where TranDt between '" + FrmDt.Date.ToString("dd/MMM/yyyy") + "' and '" + ToDt.Date.ToString("dd/MMM/yyyy") + "' order by TranId", Con);
            Cmd.CommandType = CommandType.Text;

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "Voucher";
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
                    case "DateTime":
                        Col.DefaultValue = DateTime.Today;
                        Col.AllowDBNull = true;
                        break;
                }
            }

            return Tbl;
        }

        public int Acc_Voucher_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("TranId", "TranId", 0, 1));
            tmp.Add(CommonView.GetGridViewDateColumn("TranDt", "TranDt", 0, 2, ""));
            tmp.Add(CommonView.GetGridViewColumn("DocNo", "DocNo", 0, 3));
            tmp.Add(CommonView.GetGridViewColumn("AccId", "AccId", 0, 4));
            tmp.Add(CommonView.GetGridViewColumn("Ledger", "Ledger", 90, 5, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Nar1", "Narration", 300, 6, false, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Nar2", "Nar2", 0, 7, false, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Nar3", "Nar3", 0, 8, false, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Nar4", "Nar4", 0, 9, false, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Nar5", "Nar5", 0, 10, false, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Debit", "Debit", 90, 11, false, DataGridViewContentAlignment.MiddleRight, "####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Credit", "Credit", 90, 12, false, DataGridViewContentAlignment.MiddleRight, "####0.00"));
           // tmp.Add(CommonView.GetGridViewColumn("ClBal", "Closing", 0, 13, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
           // tmp.Add(CommonView.GetGridViewColumn("ClBal1", "Closing", 90, 14, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

        public DataTable Ledger_Source()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Acc_Qry_achdallvw", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@CompId", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);
            Cmd.CommandTimeout = 1000000;
            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "Ledger";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();

            return Tbl;
        }

        public int Ledger_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("AccId", "AccId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Ledger", "Ledger", 120, 2, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("FirstLvl", "FirstLvl", 0, 3, false, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("SeniorI", "SeniorI", 0, 4, false, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("AcCode", "AcCode", 70, 5, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Compid", "Compid", 0, 6));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        #endregion

        public DataTable Acc_Voucher_Source(int TranId)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("acc_Qry_Voucher", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@TranId", SqlDbType.Int);
            param.Value = TranId;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@CompId", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Cmd.CommandTimeout = 1000000;
            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "Ledger";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();

            return Tbl;
        }
        public double OpBal(DateTime FromDt, int Accid)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Acc_Qry_OpBalance", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter Param = new SqlParameter("@Dt", SqlDbType.DateTime);
            Param.Value = FromDt.ToString("dd/MMM/yyyy");
            Cmd.Parameters.Add(Param);

            Param = new SqlParameter("@Accid", SqlDbType.Int);
            Param.Value = Accid;
            Cmd.Parameters.Add(Param);

            Param = new SqlParameter("@compid", SqlDbType.TinyInt);
            Param.Value = Common.CId;
            Cmd.Parameters.Add(Param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "OPBalDet";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();

            return (double)Tbl.Rows[0][0];
        }
        public DataTable LedDs(DateTime FromDt, DateTime ToDt, int AccId)
        {


            SqlConnection Con = new SqlConnection(Common.ConStr);
            DataTable Tbl = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Acc_Qry_LedRpt", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@FromDt", SqlDbType.DateTime);
            param.Value = FromDt.ToString("dd/MMM/yyyy");
            Cmd.Parameters.Add(param);

            SqlParameter Param = new SqlParameter("@ToDt", SqlDbType.DateTime);
            Param.Value = ToDt.ToString("dd/MMM/yyyy");
            Cmd.Parameters.Add(Param);

            Param = new SqlParameter("@AccId", SqlDbType.Int);
            Param.Value = AccId;
            Cmd.Parameters.Add(Param);

            Param = new SqlParameter("@DocRefId", SqlDbType.Int);
            Param.Value = 0;
            Cmd.Parameters.Add(Param);

            Param = new SqlParameter("@DocType", SqlDbType.VarChar, 5);
            Param.Value = "";
            Cmd.Parameters.Add(Param);

            Param = new SqlParameter("@CompId", SqlDbType.TinyInt);
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
        public Boolean CrDr()
        {
            Boolean Result;
            SqlConnection Con = new SqlConnection(Common.ConStr);
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Config_Qry_GetBitvalue", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@ConfigId", SqlDbType.Int);
            param.Value = 38;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Result = Convert.ToBoolean(Cmd.ExecuteScalar());

            Cmd.Dispose();
            Con.Close();
            return Result;
        }

        public int LedRptDs_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            Boolean drcr;
            drcr = CrDr();
            tmp.Add(CommonView.GetGridViewDateColumn("Dt", "Date", 90, 1, "dd/MM/yyyy"));
            tmp.Add(CommonView.GetGridViewColumn("DocType", "DocType", 0, 2));
            tmp.Add(CommonView.GetGridViewColumn("DocNo", "DocNo", 0, 3));
            tmp.Add(CommonView.GetGridViewColumn("Acdesc", "Ledger", 0, 4, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Narration", "Narration", 150, 5, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Debit", "Debit", 90, 6, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Credit", "Credit", 90, 7, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
            tmp.Add(CommonView.GetGridViewColumn("ClBal", "Closing", 0, 8, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
            tmp.Add(CommonView.GetGridViewColumn("ClBal1", "Closing", 90, 9, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
            tmp.Add(CommonView.GetGridViewColumn("DayId", "DayId", 0, 10));
            tmp.Add(CommonView.GetGridViewColumn("LocId", "LocId", 0, 11));
            tmp.Add(CommonView.GetGridViewColumn("DocRefId", "DocRefId", 0, 12));
            tmp.Add(CommonView.GetGridViewColumn("AccId", "AccId", 0, 13));
            tmp.Add(CommonView.GetGridViewColumn("Accode", "Accode", 0, 14));
            //   tmp.Add(CommonView.GetGridViewColumn("Acdesc", "Acdesc", 0, 13));
            tmp.Add(CommonView.GetGridViewColumn("Nar1", "Nar1", 0, 15));
            tmp.Add(CommonView.GetGridViewColumn("Nar2", "Nar2", 0, 16));
            tmp.Add(CommonView.GetGridViewColumn("Nar3", "Nar3", 0, 17));
            tmp.Add(CommonView.GetGridViewColumn("Nar4", "Nar4", 0, 18));
            tmp.Add(CommonView.GetGridViewColumn("Nar5", "Nar5", 0, 19));
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 20));
            tmp.Add(CommonView.GetGridViewColumn("TranDt", "TranDt", 0, 2));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = true;
            return 0;
        }
        public DataTable NarrationList_Source()
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_NarrationList", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Narration";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }
        public DataTable OpBalPrint(DateTime FromDt, int Accid)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Acc_Qry_OpBalance", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter Param = new SqlParameter("@Dt", SqlDbType.DateTime);
            Param.Value = FromDt.ToString("dd/MMM/yyyy");
            Cmd.Parameters.Add(Param);

            Param = new SqlParameter("@Accid", SqlDbType.Int);
            Param.Value = Accid;
            Cmd.Parameters.Add(Param);

            Param = new SqlParameter("@compid", SqlDbType.TinyInt);
            Param.Value = Common.CId;
            Cmd.Parameters.Add(Param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "Acc_Qry_OpBalance";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();

            return Tbl;
        }
    }
}
