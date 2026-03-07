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
	/// Summary description for StkAdjDB.
	/// </summary>
	/// 
	public class DayBookSingleDB
	{
        public DayBookSingleDB()
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

       
        # endregion
		
# region " Detail Source "

        public DataTable LedgerSource(string DocType)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Acc_Qry_LedgerSelection", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@DocType", SqlDbType.VarChar, 5);
            param.Value = DocType;
            Cmd.Parameters.Add(param);

             param = new SqlParameter("@Compid", SqlDbType.TinyInt);
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
        
            tmp.Add(CommonView.GetGridViewColumn("AccId", "AccId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("LedgerHead", "LedgerHead", 200, 2, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Address", "Address", 200, 3, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Balance", "Balance", 100, 4, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
            
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

        public DataTable PrintSource(int TranId)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Acc_Qry_Voucher", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@TranId", SqlDbType.Int);
            param.Value = TranId;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@CompId", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "Acc_Qry_Voucher";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }

  
# endregion

# region "Save"
        public void SaveFunction(Saving.SaveType Mode)
		{
						
			int Modeval=0;
			if (Mode==Saving.SaveType.Add)
				Modeval=1;
			else if(Mode==Saving.SaveType.Edit)
				Modeval=2;
			else if(Mode==Saving.SaveType.Delete)
				Modeval=3;
			else if(Mode==Saving.SaveType.DocCancel)
				Modeval=8;
            
			try
			{
				SqlConnection Con=new SqlConnection(Common.ConStr); 
				SqlDataAdapter Da=new SqlDataAdapter(); 
				Con.Open(); 
				SqlCommand Cmd;
                Cmd = new SqlCommand("Acc_VoucherSP", Con); 
				Cmd.CommandType=CommandType.StoredProcedure; 
				SqlParameter param=new SqlParameter("@Mode",SqlDbType.TinyInt);
				param.Value=Modeval;
				Cmd.Parameters.Add(param);
                param = new SqlParameter("@TranId", SqlDbType.Int);
                param.Value = _TranId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DocNo", SqlDbType.Int);
                param.Value = _DocNo;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TranDt", SqlDbType.DateTime);
                param.Value = _TranDt.ToString("dd/MMM/yyyy");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@AccId", SqlDbType.Int);
                param.Value = _AccId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Nar1", SqlDbType.VarChar, 80);
                param.Value = _Nar1;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Nar2", SqlDbType.VarChar, 80);
                param.Value = _Nar2;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Nar3", SqlDbType.VarChar, 80);
                param.Value = _Nar3;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Nar4", SqlDbType.VarChar, 80);
                param.Value = _Nar4;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Nar5", SqlDbType.VarChar, 80);
                param.Value = _Nar5;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Amount", SqlDbType.Decimal);
                param.Value = _Amount;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DrCr", SqlDbType.Char, 1);
                param.Value = _DrCr;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.TinyInt);
                param.Value = Common.UserId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CompId", SqlDbType.TinyInt);
                param.Value = Common.CId;
                Cmd.Parameters.Add(param);

				Cmd.ExecuteNonQuery();
				Cmd.Dispose(); 
				Con.Close(); 				
			}
			catch (Exception Ex)
			{
				if (Ex.Message.IndexOf("COLUMN REFERENCE constraint") > -1 )
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

#region "FetchRecord"

        public bool FetchRecord(int Id)
		{
			SqlConnection Con = new SqlConnection(Common.ConStr);						
			Con.Open();
	
			SqlCommand Cmd;
            Cmd = new SqlCommand("Acc_Qry_Voucher", Con);		
			Cmd.CommandType=CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@TranId", SqlDbType.Int);
            param.Value = Id;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@CompId", SqlDbType.TinyInt);
			param.Value=Common.CId;
			Cmd.Parameters.Add(param);			
			
			SqlDataReader rd = Cmd.ExecuteReader(CommandBehavior.CloseConnection);			
            if (rd.Read())

			{

                _TranId = (int)rd.GetValue(rd.GetOrdinal("TranId"));
                _DocNo = (int)rd.GetValue(rd.GetOrdinal("DocNo"));
                _TranDt = (DateTime)rd.GetValue(rd.GetOrdinal("TranDt"));
                _AccId = (int)rd.GetValue(rd.GetOrdinal("AccId"));
                _Nar1 = (string)rd.GetValue(rd.GetOrdinal("Nar1"));
                _Nar2 = (string)rd.GetValue(rd.GetOrdinal("Nar2"));
                _Nar3 = (string)rd.GetValue(rd.GetOrdinal("Nar3"));
                _Nar4 = (string)rd.GetValue(rd.GetOrdinal("Nar4"));
                _Nar5 = (string)rd.GetValue(rd.GetOrdinal("Nar5"));
                _Amount = (decimal)rd.GetValue(rd.GetOrdinal("Amount"));
                _DrCr = (string)rd.GetValue(rd.GetOrdinal("DrCr"));
                _UserId = (byte)rd.GetValue(rd.GetOrdinal("UserId"));
                                               
				rd.Close();
				Cmd.Dispose();
				Con.Close();	
				return true;
			}
			else
			{
				rd.Close();
				Cmd.Dispose();
				Con.Close();	
				return false;
			}
        }
        # endregion

#region "For View Record"
        public DataTable navigate()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("select top 100 * from Acc_VoucherVwfn(" + Common.CId + ") where TranId> 0 order by TranId desc", Con);
            Cmd.CommandType = CommandType.Text;
            SqlParameter param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);
            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "navigate";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }

        public System.Collections.Hashtable _FilteringValues =new System.Collections.Hashtable();
		_ViewValues _View;
		public struct _ViewValues
		{
			public	System.Collections.Hashtable FilteringValues;
			public string TableNames;
			public string Fields;
			public string Conditions;
			public string OrderBy;
			public string AdvVwTblName;
		}
        public void SetViewControl()
		{
			_FilteringValues.Clear();
			
			_View.FilteringValues = _FilteringValues;
            _View.TableNames = "Acc_VoucherVwfn(" + Common.CId + ")";
            _View.Fields = "*";
			_View.Conditions = "";
            _View.OrderBy = "TranId";

		}
     
		public _ViewValues ViewValues
		{
			get
			{
				return _View;
			}
			set
			{
				_View = value;
			}

		}
        public int View_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("TranId", "TranId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("DocNo", "DocNo", 60, 2, true));
            tmp.Add(CommonView.GetGridViewColumn("TranDt", "TranDt", 70, 2, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));
            tmp.Add(CommonView.GetGridViewColumn("AccId", "AccId", 0, 3, true));
            tmp.Add(CommonView.GetGridViewColumn("Ledger", "Ledger", 100, 4, true,DataGridViewContentAlignment.MiddleLeft,"",DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Amount", "Amount", 100, 5,true,DataGridViewContentAlignment.MiddleRight,"######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("DrCr", "D or C", 50, 6,true));
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 7, true));
            
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
		
		#endregion


	}
}
