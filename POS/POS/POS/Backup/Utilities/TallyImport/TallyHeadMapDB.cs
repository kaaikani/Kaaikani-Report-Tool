using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using GridStructures;
using DBAccess;
using  RLPOSDB ;

namespace RLPOSDB 
{
	/// <summary>
	/// Summary description for PartyDB.
	/// </summary>
	public class TallyHeadMapDB
	{
        public TallyHeadMapDB()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		# region "Properties"

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

        int _SubGrpId;
        public int SubGrpId
        {
            get
            {
                return _SubGrpId;
            }
            set
            {
                _SubGrpId = value;
            }
        }

        string _TallyHeadName;
        public string TallyHeadName 
		{
			get
			{
                return _TallyHeadName;
			}
			set
			{
                _TallyHeadName = value;
			}
		}

        string _TallySubGrpNAme;
        public string TallySubGrpNAme
        {
            get
            {
                return _TallySubGrpNAme;
            }
            set
            {
                _TallySubGrpNAme = value;
            }
        }

        decimal _ChargeAmt;
        public decimal ChargeAmt
        {
            get
            {
                return _ChargeAmt;
            }
            set
            {
                _ChargeAmt = value;
            }
        }


       //decimal _RentPerDay;
       // public decimal RentPerDay
       // {
       //     get
       //     {
       //         return _RentPerDay;
       //     }
       //     set
       //     {
       //         _RentPerDay = value;
       //     }
       // }	
      
     


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

		public void  SaveFunction(Saving.SaveType Mode)
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
                Cmd = new SqlCommand("Tallyheadsp", Con); 
				Cmd.CommandType=CommandType.StoredProcedure; 
                //SqlParameter param=new SqlParameter("@Mode",SqlDbType.TinyInt);
                //param.Value=Modeval;
                //Cmd.Parameters.Add(param);

                SqlParameter param = new SqlParameter("@AccId", SqlDbType.Int);
                param.Value = _AccId;
				Cmd.Parameters.Add(param);

                param = new SqlParameter("@TallyHeadName", SqlDbType.NVarChar ,150);
                param.Value = _TallyHeadName;
				Cmd.Parameters.Add(param);


                param = new SqlParameter("@SubGrpId", SqlDbType.Int);
                param.Value = _SubGrpId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TallySubGrpNAme ", SqlDbType.NVarChar, 250);
                param.Value = _TallySubGrpNAme ;
                Cmd.Parameters.Add(param);



               Cmd.ExecuteNonQuery();
               //code = (int)Cmd.Parameters["@OutChgId"].Value;
               //return code;
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
            _View.TableNames = "fn_TallyHeadMap(" + Common.CId + ")";			
			_View.Fields ="*";			
			_View.Conditions = "";
		}

        public DataTable  navigate()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("select * from fn_TallyHeadMap("+ Common.CId  +") where AccId > 0 ", Con);
            Cmd.CommandType = CommandType.Text;


          //SqlParameter param = new SqlParameter("@CompId", SqlDbType.TinyInt);
          //  param.Value = 0;
          //  Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "fn_TallyHeadMap";
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

        public int TallyHeadMapView_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("AccId", "AccId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("LedgerName", "LedgerName", 120, 2, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("TallyHeadName", "TallyHeadName", 120, 3, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("SubGrpId", "SubGrpId", 0, 4));
            tmp.Add(CommonView.GetGridViewColumn("subGroup", "SubGroup", 120, 5, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("TallySubGrpName", "TallySubGroup", 120, 6, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));     


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

        public DataTable LedgerSource()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Acc_Qry_LedgerSelection", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@Compid", SqlDbType.TinyInt);
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
		#endregion

	}
}
