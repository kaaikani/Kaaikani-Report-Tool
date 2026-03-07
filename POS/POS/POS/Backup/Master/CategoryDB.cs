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
    public class CategoryDB
	{
        public CategoryDB()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		# region "Properties"

        short _CategoryId;
        public short CategoryId

		{
			get
			{
                return _CategoryId;
			}
			set
			{
                _CategoryId = value;
			}
		}

        string _Category;
        public string Category 
		{
			get
			{
                return _Category;
			}
			set
			{
                _Category = value;
			}
		}

        string _HSNCode;
        public string HSNCode
        {
            get
            {
                return _HSNCode;
            }
            set
            {
                _HSNCode = value;
            }
        }

        decimal _ARatePer;
        public decimal ARatePer
        {
            get
            {
                return _ARatePer;
            }
            set
            {
                _ARatePer = value;
            }
        }

        decimal _BRatePer;
        public decimal BRatePer
        {
            get
            {
                return _BRatePer;
            }
            set
            {
                _BRatePer = value;
            }
        }

        decimal _CRatePer;
        public decimal CRatePer
        {
            get
            {
                return _CRatePer;
            }
            set
            {
                _CRatePer = value;
            }
        }

        decimal _DRatePer;
        public decimal DRatePer
        {
            get
            {
                return _DRatePer;
            }
            set
            {
                _DRatePer = value;
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
                Cmd = new SqlCommand("CategorySp", Con); 
				Cmd.CommandType=CommandType.StoredProcedure; 
				SqlParameter param=new SqlParameter("@mode",SqlDbType.TinyInt);
				param.Value=Modeval;
				Cmd.Parameters.Add(param);

                param = new SqlParameter("@CategoryId", SqlDbType.SmallInt);
                param.Value = _CategoryId;
				Cmd.Parameters.Add(param);

                param = new SqlParameter("@Category", SqlDbType.VarChar, 50);
                param.Value = _Category.Replace("'", "''");
				Cmd.Parameters.Add(param);

                param = new SqlParameter("@MarginPer", SqlDbType.Decimal);
                param.Value =0;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@HSNCode", SqlDbType.VarChar, 20);
                param.Value = _HSNCode.Replace("'", "''");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@ARatePer", SqlDbType.Decimal);
                param.Value = _ARatePer;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@BRatePer", SqlDbType.Decimal);
                param.Value = _BRatePer;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CRatePer", SqlDbType.Decimal);
                param.Value = _CRatePer;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DRatePer", SqlDbType.Decimal);
                param.Value = _DRatePer;
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
            _View.TableNames = "CategoryFn(" + Common.CId + ")";			
			_View.Fields ="*";			
			_View.Conditions = "";
		}

        public DataTable Category_Source()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("select * from Categoryfn(" + Common.CId + ") where CategoryId > 0 ", Con);
            Cmd.CommandType = CommandType.Text;

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "Category";
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

        public int Category_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("CategoryId", "CategoryId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 120, 2, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("ARatePer", "ARate%", 70, 3, false, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("BRatePer", "BRate%", 70, 4, false, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("CRatePer", "CRate%", 70, 5, false, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("DRatePer", "DRate%", 70, 6, false, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("HSNCode", "HSNCode", 90, 7, false, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("TaxId", "TaxId", 0, 8));
            tmp.Add(CommonView.GetGridViewColumn("TaxName", "TaxName", 0, 9));
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 10));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 11));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

        public void UpdateCategorywiseRate(int categoryId, decimal aRatePer, decimal bRatePer,decimal cRatePer,decimal dRatePer)
        {
            try
            {
                SqlConnection Con = new SqlConnection(Common.ConStr);
                SqlDataAdapter Da = new SqlDataAdapter();
                Con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("UpdateCategoryRateSp", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@CategoryId", SqlDbType.Int);
                param.Value = categoryId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@ARatePer", SqlDbType.Decimal);
                param.Value = aRatePer;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@BRatePer", SqlDbType.Decimal);
                param.Value = bRatePer;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CRatePer", SqlDbType.Decimal);
                param.Value = cRatePer;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DRatePer", SqlDbType.Decimal);
                param.Value = dRatePer;
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
