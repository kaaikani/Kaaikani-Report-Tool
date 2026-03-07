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
	public class TaxDetailDB
	{
        public TaxDetailDB()
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

		public void SaveFunction()
		{
            DataTable Tbl = new DataTable();
            DataSet Ds = new DataSet();
            string DetStr;
            Ds.Tables.Add(TaxDet);
            
            DetStr = Ds.GetXml();
            DetStr = DetStr.Replace("'", "''");
            DetStr = DetStr.Replace("true", "1");
            DetStr = DetStr.Replace("false", "0");
            if (DetStr.IndexOf("T00:00:00") != -1)
                DetStr = DetStr.Replace(DetStr.Substring(DetStr.IndexOf("T00:00:00"), 15), "");
            Ds.Tables.Clear();
            Ds.Tables.Clear();
            Ds.Dispose();

            int Modeval=0;
			
			try
			{
				SqlConnection Con=new SqlConnection(Common.ConStr); 
				SqlDataAdapter Da=new SqlDataAdapter(); 
				Con.Open(); 
				SqlCommand Cmd;
                Cmd = new SqlCommand("TaxDetSP", Con); 
				Cmd.CommandType=CommandType.StoredProcedure; 

				SqlParameter param=new SqlParameter("@TaxId", SqlDbType.SmallInt );
				param.Value=_TaxId;
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
        
        
		
	
        public DataTable Tax_Source()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_Tax", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "TaxDet";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
          
            return Tbl;

        }

        public int Tax_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("TaxId", "TaxId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Taxname", "TaxName", 120, 2, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("TaxPer", "Tax%", 80, 3, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("CGSTPer", "CGST%", 0, 4, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SGSTPer", "SGST%", 0, 5, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("IGSTPer", "IGST%", 0, 6, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewBoolColumn("Vat", "Vat", 0, 7));
            tmp.Add(CommonView.GetGridViewColumn("CommCode", "CommCode", 0, 8,false, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("GSTImplemented", "GSTImplemented", 0, 9));
         
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

	
	}
}
