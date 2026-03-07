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
    public class ItemGroupDB
	{
        public ItemGroupDB()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		# region "Properties"

        short _ItemGrpId;
        public short ItemGrpId

		{
			get
			{
                return _ItemGrpId;
			}
			set
			{
                _ItemGrpId = value;
			}
		}

        string _ItemGrpName;
        public string ItemGrpName
		{
			get
			{
                return _ItemGrpName;
			}
			set
			{
                _ItemGrpName = value;
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
                Cmd = new SqlCommand("ItemGrpSp", Con); 
				Cmd.CommandType=CommandType.StoredProcedure; 
				SqlParameter param=new SqlParameter("@mode",SqlDbType.TinyInt);
				param.Value=Modeval;
				Cmd.Parameters.Add(param);

                param = new SqlParameter("@ItemGrpId", SqlDbType.SmallInt);
                param.Value = _ItemGrpId;
				Cmd.Parameters.Add(param);

                param = new SqlParameter("@ItemGrpName", SqlDbType.VarChar, 50);
                param.Value = _ItemGrpName.Replace("'", "''");
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
            _View.TableNames = "ItemGrpfn(" + Common.CId + ")";			
			_View.Fields ="*";			
			_View.Conditions = "";
		}

        public DataTable ItemGroupDet_Source()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("select * from ItemGrpfn(" + Common.CId + ") where ItemGrpId > 0 ", Con);
            Cmd.CommandType = CommandType.Text;

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "ItemGrp";
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

        public int ItemGrpDet_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("ItemGrpId", "ItemGrpId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("ItemGrpName", "ItemGrpName", 120, 2, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 3));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 4));

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
