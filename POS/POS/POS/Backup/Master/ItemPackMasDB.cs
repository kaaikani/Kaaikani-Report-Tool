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
    public class ItemPackMasDB
	{
        public ItemPackMasDB()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		# region "Properties"

        short _ItemPackId;
        public short ItemPackId

		{
			get
			{
                return _ItemPackId;
			}
			set
			{
                _ItemPackId = value;
			}
		}

        int _ItemPackCode;
        public int ItemPackCode
        {
            get
            {
                return _ItemPackCode;
            }
            set
            {
                _ItemPackCode = value;
            }
        }

        string _ItemPack;
        public string ItemPack 
		{
			get
			{
                return _ItemPack;
			}
			set
			{
                _ItemPack = value;
			}
		}

        string _CommCode;
        public string CommCode
        {
            get
            {
                return _CommCode;
            }
            set
            {
                _CommCode = value;
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
                Cmd = new SqlCommand("ItemPackSp", Con); 
				Cmd.CommandType=CommandType.StoredProcedure; 
				SqlParameter param=new SqlParameter("@mode",SqlDbType.TinyInt);
				param.Value=Modeval;
				Cmd.Parameters.Add(param);

                param = new SqlParameter("@ItemPackId", SqlDbType.SmallInt);
                param.Value = _ItemPackId;
				Cmd.Parameters.Add(param);

                param = new SqlParameter("@ItemPackCode", SqlDbType.Int);
                param.Value = _ItemPackCode;
                Cmd.Parameters.Add(param);
                
                param = new SqlParameter("@ItemPack", SqlDbType.VarChar, 50);
                param.Value = _ItemPack.Replace("'", "''");
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
            _View.TableNames = "ItemPackFn(" + Common.CId + ")";			
			_View.Fields ="*";			
			_View.Conditions = "";
		}

        public DataTable ItemPack_Source()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("select * from ItemPackfn(" + Common.CId + ") where ItemPackId > 0 ", Con);
            Cmd.CommandType = CommandType.Text;

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "ItemPack";
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

        public int ItemPack_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("ItemPackId", "ItemPackId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("ItemPackCode", "ItemPackCode", 120, 2, true, DataGridViewContentAlignment.MiddleLeft, ""));           
            tmp.Add(CommonView.GetGridViewColumn("ItemPack", "ItemPack", 120, 3, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));           
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 4));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 5));

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
