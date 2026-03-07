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
	public class JournalDB
	{
        public JournalDB()
		{
			//
			// TODO: Add constructor logic here
			//
		}

# region "Properties"

        int _JouId;
        public int JouId
        {
            get
            {
                return _JouId;
            }
            set
            {
                _JouId = value;
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

        DateTime _DocDt;
        public DateTime DocDt
        {
            get
            {
                return _DocDt;
            }
            set
            {
                _DocDt = value;
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
        string _DocType;
        public string DocType
        {
            get
            {
                return _DocType;
            }
            set
            {
                _DocType = value;
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

        DataTable _JournalDet;
        public DataTable JournalDet
        {
            get
            {
                return _JournalDet;
            }
            set
            {
                _JournalDet = value;
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

            SqlParameter param = new SqlParameter("@DocType", SqlDbType.VarChar,5);
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
        public DataTable JournalDetSource(int Id) 
		{
			DataTable Tbl=new DataTable(); 
			SqlConnection Con=new SqlConnection(Common.ConStr); 
			SqlDataAdapter Da=new SqlDataAdapter(); 
			Con.Open(); 
			SqlCommand Cmd;
            Cmd = new SqlCommand("Acc_Qry_JournalDet", Con); 
			Cmd.CommandType=CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@jouid", SqlDbType.Int );
            param.Value = Id;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
			param.Value=Common.CId;
			Cmd.Parameters.Add(param);

			Da.SelectCommand=Cmd; 
			Da.Fill(Tbl);
            Tbl.TableName = "Acc_JournalDet"; 
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
						Col.AllowDBNull=false;
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
						Col.AllowDBNull=false;
						break;
				}			
			}
			return Tbl; 


		}
        public int JournalDet_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            Boolean ctdt;
            ctdt = CrDr();
            tmp.Add(CommonView.GetGridViewColumn("JouId", "JouId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("AccId", "AccId", 0, 2));
            tmp.Add(CommonView.GetGridViewColumn("LedgerHeader", "LedgerHeader", 200, 3, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            if (ctdt == true)
            {
                tmp.Add(CommonView.GetGridViewColumn("Debit", "Debit", 100, 4, false, DataGridViewContentAlignment.MiddleRight, "###0.00"));
                tmp.Add(CommonView.GetGridViewColumn("Credit", "Credit", 100, 5, false, DataGridViewContentAlignment.MiddleRight, "###0.00"));
            }
            else
            {
                tmp.Add(CommonView.GetGridViewColumn("Credit", "Credit", 100, 4, false, DataGridViewContentAlignment.MiddleRight, "###0.00"));
                tmp.Add(CommonView.GetGridViewColumn("Debit", "Debit", 100, 5, false, DataGridViewContentAlignment.MiddleRight, "###0.00"));
            }
            //tmp.Add(CommonView.GetGridViewColumn("Credit", "Credit", 100, 4, false, DataGridViewContentAlignment.MiddleRight, "#####0.000"));
            //tmp.Add(CommonView.GetGridViewColumn("Debit", "Debit", 100, 5, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Amount", "Amount", 0, 6));
            tmp.Add(CommonView.GetGridViewColumn("DrCr", "DrCr", 0, 7));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        

# endregion

# region "Save"
        public void SaveFunction(Saving.SaveType Mode)
		{
			DataSet Ds =new DataSet();
			string  DetStr;
            Ds.Tables.Add(JournalDet); 
			DetStr=Ds.GetXml();
			DetStr=DetStr.Replace("'","''");
			DetStr=DetStr.Replace("true","1");
			DetStr=DetStr.Replace("false","0");
            if (DetStr.IndexOf("T00:00:00") != -1)
                DetStr = DetStr.Replace(DetStr.Substring(DetStr.IndexOf("T00:00:00"), 15), "");
			Ds.Tables.Clear();
			Ds.Dispose();
			
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
                Cmd = new SqlCommand("Acc_JournalSP", Con); 
				Cmd.CommandType=CommandType.StoredProcedure; 
				SqlParameter param=new SqlParameter("@Mode",SqlDbType.TinyInt);
				param.Value=Modeval;
				Cmd.Parameters.Add(param);
                param = new SqlParameter("@JouId", SqlDbType.Int );
                param.Value = _JouId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DocNo", SqlDbType.Int);
                param.Value = _DocNo;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DocDt", SqlDbType.DateTime);
                param.Value = _DocDt.ToString("dd/MMM/yyyy");
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

                param = new SqlParameter("@UserId", SqlDbType.TinyInt);
                param.Value = Common.UserId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CompId", SqlDbType.TinyInt);
                param.Value = Common.CId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DocType", SqlDbType.VarChar, 5);
                param.Value = _DocType;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DetStr", SqlDbType.Text);
                param.Value = DetStr;
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
            Cmd = new SqlCommand("Acc_Qry_Journalhdr", Con);		
			Cmd.CommandType=CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@JouId", SqlDbType.Int);
            param.Value = Id;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@CompId", SqlDbType.TinyInt);
			param.Value=Common.CId;
			Cmd.Parameters.Add(param);			
			
			SqlDataReader rd = Cmd.ExecuteReader(CommandBehavior.CloseConnection);			
            if (rd.Read())

			{
                _JouId = (int)rd.GetValue(rd.GetOrdinal("JouId"));
                _DocNo = (int)rd.GetValue(rd.GetOrdinal("DocNo"));
                _DocDt = (DateTime)rd.GetValue(rd.GetOrdinal("DocDt"));
                _Nar1 = (string)rd.GetValue(rd.GetOrdinal("Nar1"));
                _Nar2 = (string)rd.GetValue(rd.GetOrdinal("Nar2"));
                _Nar3 = (string)rd.GetValue(rd.GetOrdinal("Nar3"));
                _Nar4 = (string)rd.GetValue(rd.GetOrdinal("Nar4"));
                _Nar5 = (string)rd.GetValue(rd.GetOrdinal("Nar5"));
                _UserId = (byte)rd.GetValue(rd.GetOrdinal("UserId"));
                _DocType = (string)rd.GetValue(rd.GetOrdinal("DocType"));                                               
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
        public DataTable navigate(string DocType)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("select top 100 * from Acc_JournalhdrVwFn('" + DocType + "'," + Common.CId + ") where DocNo> 0 order by DocNo desc", Con);
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
        public void SetViewControl(string DocType1)
		{
			_FilteringValues.Clear();
			
			_View.FilteringValues = _FilteringValues;
            _View.TableNames = "Acc_JournalhdrVwFn('" + DocType1 + "'," + Common.CId + ")";
            _View.Fields = "*";
			_View.Conditions = "";
            _View.OrderBy = "DocNo";

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
            tmp.Add(CommonView.GetGridViewColumn("JouId", "JouId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("DocNo", "DocNo", 60, 2,true));
            tmp.Add(CommonView.GetGridViewColumn("DocDt", "DocDt", 70, 3, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));
            tmp.Add(CommonView.GetGridViewColumn("Nar1", "Nar1", 100, 4, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Nar2", "Nar2", 100, 5, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Nar3", "Nar3", 100, 6, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Nar4", "Nar4", 100, 7, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Nar5", "Nar5", 100, 8, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 9, true));
            tmp.Add(CommonView.GetGridViewColumn("UserName", "UserName", 0, 10, true));
            
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
		
		#endregion

#region "Navigation"
   
        #endregion
	}
}
