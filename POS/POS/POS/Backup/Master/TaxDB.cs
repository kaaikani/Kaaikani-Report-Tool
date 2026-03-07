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
	public class TaxDB
	{
		public TaxDB()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		# region "Properties"
		
		short _TaxId;
		public short TaxId

		{
			get
			{
				return _TaxId;
			}
			set
			{
				_TaxId = value;
			}
		}

		string _TaxName;
		public string TaxName 
		{
			get
			{
				return _TaxName;
			}
			set
			{
				_TaxName = value;
			}
		}
		
        decimal _TaxPer;
        public decimal TaxPer
        {
            get
            {
                return _TaxPer;
            }
            set
            {
                _TaxPer = value;
            }
        }

        decimal _CGSTPer;
        public decimal CGSTPer
        {
            get
            {
                return _CGSTPer;
            }
            set
            {
                _CGSTPer = value;
            }
        }

        decimal _SGSTPer;
        public decimal SGSTPer
        {
            get
            {
                return _SGSTPer;
            }
            set
            {
                _SGSTPer = value;
            }
        }

        decimal _IGSTPer;
        public decimal IGSTPer
        {
            get
            {
                return _IGSTPer;
            }
            set
            {
                _IGSTPer = value;
            }
        }

        decimal _CESSPer;
        public decimal CESSPer
        {
            get
            {
                return _CESSPer;
            }
            set
            {
                _CESSPer = value;
            }
        }
      
        bool _Vat;
        public bool Vat
        {
            get
            {
                return _Vat;
            }
            set
            {
                _Vat = value;
            }
        }
        bool _GstImplemented;
        public bool GstImplemented
        {
            get
            {
                return _GstImplemented;
            }
            set
            {
                _GstImplemented = value;
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

        DataTable _TaxDet;
        public DataTable TaxDet
        {
            get
            {
                return _TaxDet;
            }
            set
            {
                _TaxDet = value;
            }
        }
		
# endregion
        public DataTable TaxDet_Source(int Id)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_TaxDet", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@TaxId", SqlDbType.SmallInt);
            param.Value = Id;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "TaxDet";
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
                    case "Boolean":
                        Col.DefaultValue = false;
                        Col.AllowDBNull = false;
                        break;
                }
            }          
            return Tbl;

        }
        public int TaxDet_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("TaxId", "TaxId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("HSNCode", "HSNCode", 100, 2, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
            return 0;
        }

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
				Cmd=new SqlCommand("TaxSP",Con); 
				Cmd.CommandType=CommandType.StoredProcedure; 
				SqlParameter param=new SqlParameter("@Mode",SqlDbType.TinyInt);
				param.Value=Modeval;
				Cmd.Parameters.Add(param);

				param=new SqlParameter("@TaxId", SqlDbType.SmallInt );
				param.Value=_TaxId;
				Cmd.Parameters.Add(param);

				param=new SqlParameter("@Tax", SqlDbType.VarChar, 50  );
				param.Value=_TaxName.Replace("'","''");
				Cmd.Parameters.Add(param);
                				
				param=new SqlParameter("@TaxPer", SqlDbType.Decimal );
				param.Value=_TaxPer;
				Cmd.Parameters.Add(param);
                                
                param = new SqlParameter("@Vat", SqlDbType.Bit);
                param.Value = (_Vat == true ? 1 : 0);
                Cmd.Parameters.Add(param);
             
				param=new SqlParameter("@UserId", SqlDbType.TinyInt );
				param.Value=Common.UserId ;
				Cmd.Parameters.Add(param);

				param=new SqlParameter("@CompId", SqlDbType.TinyInt );
				param.Value=Common.CId;
				Cmd.Parameters.Add(param);

                param = new SqlParameter("@MasDbName", SqlDbType.VarChar);
                param.Value = Common.MasDataBase;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CommCode", SqlDbType.VarChar, 15);
                param.Value = _CommCode.Replace("'", "''");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CGSTPer", SqlDbType.Decimal);
                param.Value = _CGSTPer;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@SGSTPer", SqlDbType.Decimal);
                param.Value = _SGSTPer;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@IGSTPer", SqlDbType.Decimal);
                param.Value = _IGSTPer;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CESSPer", SqlDbType.Decimal);
                param.Value = _CESSPer;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@GstImplemented", SqlDbType.Bit);
                param.Value = _GstImplemented;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                Cmd.Parameters.Add(param);

                Cmd.ExecuteNonQuery();
                code = (int)Cmd.Parameters["@TId"].Value;
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
			_View.TableNames = "TaxFn("+ Common.CId +")";			
			_View.Fields ="*";			
			_View.Conditions = "";
		}

        public DataTable Tax_Source()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("select * from Taxfn(" + Common.CId + ") where TaxId > 0 ", Con);
            Cmd.CommandType = CommandType.Text;

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "Tax";
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
            Tbl.Columns["Vat"].DefaultValue = true;
            return Tbl;
        }

        public int TaxView_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("TaxId", "TaxId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Taxname", "TaxName", 120, 2, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("TaxPer", "Tax%", 80, 3, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("CGSTPer", "CGST%", 80, 4, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SGSTPer", "SGST%", 80, 5, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("IGSTPer", "IGST%", 80, 6, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("CESSPer", "CESS%", 80, 7, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewBoolColumn("Vat", "Vat", 50, 8));
            tmp.Add(CommonView.GetGridViewBoolColumn("GstImplemented", "IsGST", 50, 9));
            tmp.Add(CommonView.GetGridViewColumn("CommCode", "CommCode", 0, 10,false, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 11));
            tmp.Add(CommonView.GetGridViewColumn("UserName", "UserName", 0, 12));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 13));
             //tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 9));

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
