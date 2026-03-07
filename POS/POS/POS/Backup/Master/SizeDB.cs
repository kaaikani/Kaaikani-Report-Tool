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
    public class SizeDB
	{
		public SizeDB()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		# region "Properties"
		
		short _SizeId;
		public short SizeId

		{
			get
			{
				return _SizeId;
			}
			set
			{
				_SizeId = value;
			}
		}

		string _SizeName;
		public string SizeName 
		{
			get
			{
				return _SizeName;
			}
			set
			{
				_SizeName = value;
			}
		}


		
        int _OrderNo;
        public int OrderNo
        {
            get
            {
                return _OrderNo;
            }
            set
            {
                _OrderNo = value;
            }
        }
      
      	
# endregion

		public int SaveFunction(Saving.SaveType Mode)
		{

            int code;
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
				Cmd=new SqlCommand("SizeSP",Con); 
				Cmd.CommandType=CommandType.StoredProcedure; 
				SqlParameter param=new SqlParameter("@Mode",SqlDbType.TinyInt);
				param.Value=Modeval;
				Cmd.Parameters.Add(param);

				param=new SqlParameter("@SizeId", SqlDbType.SmallInt );
				param.Value=_SizeId;
				Cmd.Parameters.Add(param);

				param=new SqlParameter("@SizeName", SqlDbType.VarChar, 50  );
				param.Value=_SizeName.Replace("'","''");
				Cmd.Parameters.Add(param);
                				
				param=new SqlParameter("@OrderNo", SqlDbType.Int );
				param.Value=_OrderNo;
				Cmd.Parameters.Add(param);
                                
           
				param=new SqlParameter("@UserId", SqlDbType.TinyInt );
				param.Value=Common.UserId ;
				Cmd.Parameters.Add(param);

				param=new SqlParameter("@CompId", SqlDbType.TinyInt );
				param.Value=Common.CId;
				Cmd.Parameters.Add(param);

              

                param = new SqlParameter("@SId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                Cmd.Parameters.Add(param);

                Cmd.ExecuteNonQuery();
                code = (int)Cmd.Parameters["@SId"].Value;
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
			_View.TableNames = "fn_Size("+ Common.CId +")";			
			_View.Fields ="*";			
			_View.Conditions = "";
		}

        public DataTable Size_Source()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("select * from fn_Size(" + Common.CId + ") where SizeId > 0 order by orderno", Con);
            Cmd.CommandType = CommandType.Text;

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "Size";
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
            //Tbl.Columns["Vat"].DefaultValue = true;
            return Tbl;
        }

        public int SizeView_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("SizeId", "SizeId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Sizename", "SizeName", 120, 2, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("OrderNo", "OrderNo", 80, 3, false, DataGridViewContentAlignment.MiddleRight));
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 6));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 8));
            
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
