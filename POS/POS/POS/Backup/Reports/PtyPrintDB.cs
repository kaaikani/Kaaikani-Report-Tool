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
    /// Summary descriptions for PartyDB.
    /// </summary>
    public class PtyPrintDB
    {
        public PtyPrintDB()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        # region "Properties"
      
        int _SalId;
        public int SalId
        {
            get
            {
                return _SalId;
            }
            set
            {
                _SalId = value;
            }
        }
        
        Boolean _CODReceived;
        public Boolean CODReceived
        {
            get
            {
                return _CODReceived;
            }
            set
            {
                _CODReceived = value;
            }

        }
        int _AcYrId;
        public int AcYrId
        {
            get
            {
                return _AcYrId;
            }
            set
            {
                _AcYrId = value;
            }
        }

        bool _RecMode;
        public bool RecMode
        {
            get
            {
                return _RecMode;
            }
            set
            {
                _RecMode = value;
            }
        }
        int _RecNo;
        public int RecNo
        {
            get
            {
                return _RecNo;
            }
            set
            {
                _RecNo = value;
            }
        }
        DateTime _RecDt;
        public DateTime RecDt
        {
            get
            {
                return _RecDt;
            }
            set
            {
                _RecDt = value;
            }
        }
        string _Ptycode;
        public string Ptycode
        {
            get
            {
                return _Ptycode;
            }
            set
            {
                _Ptycode = value;
            }
        }
        string _LedgerAccode;
        public string LedgerAccode
        {
            get
            {
                return _LedgerAccode;
            }
            set
            {
                _LedgerAccode = value;
            }
        }
        bool _Cash;
        public bool Cash
        {
            get
            {
                return _Cash;
            }
            set
            {
                _Cash = value;
            }
        }
        string _ChqNo;
        public string ChqNo
        {
            get
            {
                return _ChqNo;
            }
            set
            {
                _ChqNo = value;
            }
        }
        DateTime _ChqDt;
        public DateTime ChqDt
        {
            get
            {
                return _ChqDt;
            }
            set
            {
                _ChqDt = value;
            }
        }
        Decimal _NetAmt;
        public Decimal NetAmt
        {
            get
            {
                return _NetAmt;
            }
            set
            {
                _NetAmt = value;
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
        DataTable _ReceiptDet;
        public DataTable ReceiptDet
        {
            get
            {
                return _ReceiptDet;
            }
            set
            {
                _ReceiptDet = value;
            }
        }
        string _AcCode;
        public string AcCode
        {
            get
            {
                return _AcCode;
            }
            set
            {
                _AcCode = value;
            }
        }
        # endregion


        # region " Detail Source "

    
    
       
        public DataTable LedgerSource(string Type)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Acc_Qry_LedgerSelectFn", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@Type", SqlDbType.VarChar, 50);
            param.Value = Type;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@accode", SqlDbType.VarChar);
            param.Value = "";
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@CompId", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);
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

            tmp.Add(CommonView.GetGridViewColumn("Accode", "Accode", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("LedgerHead", "Supplier", 150, 2, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Address", "Address", 100, 3, true));
            tmp.Add(CommonView.GetGridViewColumn("City", "City", 85, 4, true));
            tmp.Add(CommonView.GetGridViewColumn("Balance", "Balance", 90, 5, true));
            tmp.Add(CommonView.GetGridViewColumn("subled", "Subled", 0, 6, true));
            tmp.Add(CommonView.GetGridViewColumn("party", "Party", 0, 7, true));
            tmp.Add(CommonView.GetGridViewColumn("Costing", "Costing", 0, 8, true));
            tmp.Add(CommonView.GetGridViewColumn("BudgetId", "BudgetId", 0, 9, true));
            
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
            return 0;
            
        }
        public DataTable Address_Source()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_PartyAdd", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "Ledger";
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
            Tbl.Columns["Selection"].DefaultValue = false;
            return Tbl;
        }
        public int Address_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewBoolColumn("Selection", "Select", 60,1));
            tmp.Add(CommonView.GetGridViewColumn("AccId", "AccId", 0, 2, true));
            tmp.Add(CommonView.GetGridViewColumn("Ledger", "Ledger", 150, 3, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Add1", "Address", 100, 4, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("Add2", "Address", 0, 5, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("City", "City", 80, 6,true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("Pincode", "Pincode", 70, 7,true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("Ph1", "Ph1", 80, 8,true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("Ph2", "Ph2", 80, 9,true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("Tin", "Tin", 0, 10,true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("Cst", "Cst", 0, 11,true, DataGridViewContentAlignment.MiddleLeft));
            
            return 0;

        }
                
        # endregion


      
       
    }
}

