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
	/// Summary description for CompDelDB.
	/// </summary>
	public class CompDelDB
	{
		public CompDelDB()
		{
			//
			// TODO: Add constructor logic here
			//
		}


		
		# region "Properties"

		

	
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


		bool _Deleted;
		public bool Deleted
		{
			get
			{
				return _Deleted;
			}
			set
			{
				_Deleted = value;
			}
		}
		
		
	
# endregion

		#region "Detail Section"
		public DataTable Comp_Source() 
		{
			DataTable Tbl=new DataTable(); 
			SqlConnection Con=new SqlConnection(Common.MasConStr); 
			SqlDataAdapter Da=new SqlDataAdapter(); 
			Con.Open(); 
			
			SqlCommand Cmd; 
			Cmd=new SqlCommand("qry_CompanyAll",Con); 
			Cmd.CommandType=CommandType.StoredProcedure;
 
			
				Da.SelectCommand=Cmd; 
			Da.Fill(Tbl); 
			Tbl.TableName="Comp"; 
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
					case "DateTime":
						Col.DefaultValue=DateTime.Today;
						Col.AllowDBNull=true;
						break;
				}	
			}
			return Tbl; 
		} 



		public DataGridTableStyle CompSource_GridStyle()
		
		{
			DataGridTableStyle Temp=new DataGridTableStyle();
			Temp.MappingName="Comp";
			Temp.GridColumnStyles.Add(Common.GetColumn("CompId", "CompId", 0));
			Temp.GridColumnStyles.Add(Common.GetColumn("Compname","Company",200,true));
			Temp.GridColumnStyles.Add(Common.GetBoolColumn("Deleted","Hide",45 ));

			return Common.SetColor(Temp,Common.ProdColorStyle );
		}
		#endregion

		public void SaveFunction(Saving.SaveType Mode)
		{
           
			int  Modeval=0;
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
				SqlConnection Con=new SqlConnection(Common.MasConStr); 
				SqlDataAdapter Da=new SqlDataAdapter(); 
				Con.Open(); 
				SqlCommand Cmd; 
				Cmd=new SqlCommand("CompanyDelSp",Con); 
				Cmd.CommandType=CommandType.StoredProcedure;
                						
				SqlParameter param =new SqlParameter("@CompId", SqlDbType.TinyInt  );
				param.Value=_CompId;
				Cmd.Parameters.Add(param);

				param=new SqlParameter("@NotShow", SqlDbType.Bit);
				param.Value= _Deleted==true? 1 : 0;
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

	}
}
