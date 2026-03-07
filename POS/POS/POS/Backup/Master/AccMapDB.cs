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
    public class AccMapDB
	{
        public AccMapDB()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		# region "Properties"

        short _MapId;
        public short MapId

		{
			get
			{
                return _MapId;
			}
			set
			{
                _MapId = value;
			}
		}

        string _MapType;
        public string MapType 
		{
			get
			{
                return _MapType;
			}
			set
			{
                _MapType = value;
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
	
       	string _UserName;
		public string UserName
		{
			get
			{
				return _UserName;
			}
			set
			{
				_UserName = value;
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

		public int SaveFunction(Saving.SaveType Mode)
		{

            short code;
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
                Cmd = new SqlCommand("Acc_PostingMapDetSp", Con); 
				Cmd.CommandType=CommandType.StoredProcedure; 

				SqlParameter param=new SqlParameter("@Mode",SqlDbType.TinyInt);
				param.Value=Modeval;
				Cmd.Parameters.Add(param);

                param = new SqlParameter("@MapId", SqlDbType.SmallInt);
                param.Value = _MapId;
				Cmd.Parameters.Add(param);

                param = new SqlParameter("@MapType", SqlDbType.Char, 5);
                param.Value = _MapType;
				Cmd.Parameters.Add(param);

                param = new SqlParameter("@AccId", SqlDbType.Int);
                param.Value = _AccId;
				Cmd.Parameters.Add(param);
                 
				param=new SqlParameter("@UserId", SqlDbType.TinyInt );
				param.Value=Common.UserId ;
				Cmd.Parameters.Add(param);

				param=new SqlParameter("@CompId", SqlDbType.TinyInt );
				param.Value=Common.CId;
				Cmd.Parameters.Add(param);

                param = new SqlParameter("@Id", SqlDbType.SmallInt);
                param.Direction = ParameterDirection.Output;
                Cmd.Parameters.Add(param);

                Cmd.ExecuteNonQuery();
                code = (short)Cmd.Parameters["@Id"].Value;
                return code;
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

        public DataTable LedgerSource()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Acc_Qry_LedgerSelection", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@DocType", SqlDbType.VarChar,5);
            param.Value = "PUR";
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

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
		#region "For View Record"

		
		public System.Collections.Hashtable _FilteringValues =new System.Collections.Hashtable();
		_ViewValues _View;
		public struct _ViewValues
		{
			public	System.Collections.Hashtable FilteringValues;
			public string TableNames;
			public string Fields;
			public string Conditions;
		}
		public void SetViewControl()
		{
			_FilteringValues.Clear();
			
			_View.FilteringValues = _FilteringValues;
            _View.TableNames = "Acc_Qry_PostingMapDet(" + Common.CId + ")";			
			_View.Fields ="*";			
			_View.Conditions = "";
		}

        public DataTable MapDet_Source(string Id)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Acc_Qry_PostingMapDet", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@MapType", SqlDbType.Char,5);
            param.Value = Id;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "PostingMapDet";
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
                }
            }
            return Tbl;


        }

        public int View_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("MapId", "MapId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("MapType", "MapType", 0, 2));
            tmp.Add(CommonView.GetGridViewColumn("AccId", "AccId", 0, 3));
            tmp.Add(CommonView.GetGridViewColumn("Ledger", "Ledger", 120, 4, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 5));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 6));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
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
		#endregion

	}
}
