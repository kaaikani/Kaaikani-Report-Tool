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
	/// Summary description for StkAdjDB.
	/// </summary>
	public class StkAdjDB
	{
		public StkAdjDB()
		{
			//
			// TODO: Add constructor logic here
			//
		}

# region "Properties"

		
        short _AcYrId;
        public short AcYrId
        {
            get
            {
                return _AcYrId;
            }
            set
            {
                _AcYrId = value;
            }
        }

        short _UserId;
        public short UserId
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
        int _DocId;
        public int DocId
        {
            get
            {
                return _DocId;
            }
            set
            {
                _DocId = value;
            }
        }
        string _Reason;
        public string Reason
        {
            get
            {
                return _Reason;
            }
            set
            {
                _Reason = value;
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




        String _Username;
        public String Username 
		{
			get
			{
                return _Username;
			}
			set
			{
                _Username = value;
			}
		}
        DataTable _StkAdjDet;
        public DataTable StkAdjDet
        {
            get
            {
                return _StkAdjDet;
            }
            set
            {
                _StkAdjDet = value;
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

# region " Detail Source "

        public DataTable ItemSelect_Source(string Itemcode)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_AdjItemSelect", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Itemcode", SqlDbType.VarChar,20);
            MyParam.Value = Itemcode;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "ItemSelect";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public int ItemSelect_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
           
            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 120, 2, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));//, DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Itemcode", "Code", 0, 3, false, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("CategoryId", "CategoryId", 0, 4));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 0, 5));//,true,DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("AllowExpiry", "AllowExpiry", 0, 6));
            //tmp.Add(CommonView.GetGridViewColumn("PackTypeId", "PackTypeId", 0, 6));
            //tmp.Add(CommonView.GetGridViewColumn("PackType", "PackType", 80, 7, true, DataGridViewContentAlignment.MiddleLeft, ""));
            //tmp.Add(CommonView.GetGridViewColumn("BuomId", "BuomId", 0, 8));
            //tmp.Add(CommonView.GetGridViewColumn("Buom", "Buom", 70, 9, true, DataGridViewContentAlignment.MiddleLeft));
            //tmp.Add(CommonView.GetGridViewColumn("ConvFact", "ConvFact", 0, 10));
            

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

        public DataTable Unit_Source(int ItemId)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_UnitSelect", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@ItemId", SqlDbType.TinyInt);
            MyParam.Value = ItemId;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "UnitSelect";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public int Unit_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("UnitId", "UnitId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Unit", "Unit", 100, 2, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("ConvFact", "ConvFact", 0, 3));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        public DataTable StkAdjDet_source(int Id)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_StkAdjdet", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@DocId", SqlDbType.Int);
            param.Value = Id;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "StkAdjDet";
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
            Tbl.Columns["AddLess"].DefaultValue = false;
            return Tbl;
        }

        public int StkAdjDet_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            string HeaderName1, HeaderName2;
            tmp.Add(CommonView.GetGridViewColumn("DocId", "DocId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 2));
            tmp.Add(CommonView.GetGridViewColumn("ItemCode", "Code", 100, 3, false, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 120, 4, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("CategoryId", "CategoryId", 0, 5));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 80, 6, true, DataGridViewContentAlignment.MiddleLeft));//,true,DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("PackTypeId", "PackTypeId", 0, 7));

            tmp.Add(CommonView.GetGridViewColumn("UnitId", "UnitId", 0, 8));
            tmp.Add(CommonView.GetGridViewColumn("BatchNo", "BatchNo", (Common.AllowExpiryDt == true) ? 90 : 0, 9, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewDateColumn("ExpiryDt", "ExpiryDate", (Common.AllowExpiryDt == true) ? 100 : 0, 10, "dd/MM/yyyy", true));
            tmp.Add(CommonView.GetGridViewColumn("Qty", (Common.HeaderName1 == "") ? "Qty" : Common.HeaderName1, 60, 11, false, DataGridViewContentAlignment.MiddleRight, Common.QtyFormat));

            tmp.Add(CommonView.GetGridViewColumn("Wt", (Common.HeaderName2 == "") ? "Wt" : Common.HeaderName2, (Common.WtItem == true) ? 70 : 0, 12, false, DataGridViewContentAlignment.MiddleRight, "#####0.000"));

            tmp.Add(CommonView.GetGridViewColumn("Free", "Free", (Common.AllowSalFree == true) ? 70 : 0, 13, false, DataGridViewContentAlignment.MiddleRight, "#####0.000"));

            tmp.Add(CommonView.GetGridViewBoolColumn("AddLess", "Add/Less", 50, 14));
            tmp.Add(CommonView.GetGridViewColumn("ConvFact", "ConvFact", 0, 15));
            tmp.Add(CommonView.GetGridViewColumn("SQty", "SQty", 0, 16));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
# endregion

        # region "Save"

        public void SaveFunction(Saving.SaveType Mode)
		{
					
			DataSet Ds =new DataSet();
			string  DetStr;
            Ds.Tables.Add(StkAdjDet);
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
				Cmd=new SqlCommand("StkAdjSP",Con); 
				Cmd.CommandType=CommandType.StoredProcedure; 
				SqlParameter param=new SqlParameter("@Mode",SqlDbType.TinyInt);
				param.Value=Modeval;
				Cmd.Parameters.Add(param);

                param = new SqlParameter("@DocId", SqlDbType.Int);
                param.Value = _DocId;
				Cmd.Parameters.Add(param);

                param = new SqlParameter("@AcYrId", SqlDbType.SmallInt);
                param.Value =_AcYrId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DocNo", SqlDbType.Int);
                param.Value = _DocNo;
				Cmd.Parameters.Add(param);

                param = new SqlParameter("@DocDt", SqlDbType.DateTime);
                param.Value = _DocDt.ToString("dd/MMM/yyyy");
				Cmd.Parameters.Add(param);

                param = new SqlParameter("@Reason", SqlDbType.VarChar,100);
                param.Value = _Reason;
				Cmd.Parameters.Add(param);
                           
                param=new SqlParameter("@UserId", SqlDbType.TinyInt );
                param.Value=Common.UserId;
				Cmd.Parameters.Add(param);

				param=new SqlParameter("@CompId", SqlDbType.TinyInt );
				param.Value=Common.CId;
				Cmd.Parameters.Add(param);
                
				param=new SqlParameter("@DetStr",SqlDbType.Text);
				param.Value=DetStr;
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

       			
 		public bool FetchRecord(int Id)
		{
			SqlConnection Con = new SqlConnection(Common.ConStr);						
			Con.Open();
			SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_StkAdjHdr", Con);		
			Cmd.CommandType=CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("@DocId", SqlDbType.Int);
			param.Value=Id;
			Cmd.Parameters.Add(param);
			param=new SqlParameter("@CompId",SqlDbType.TinyInt);
            param.Value = Common.CId;
			Cmd.Parameters.Add(param);			
			SqlDataReader rd = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (rd.Read())
			{
                _DocId = (int)rd.GetValue(rd.GetOrdinal("DocId"));				
				_DocNo  = (int)rd.GetValue(rd.GetOrdinal("DocNo"));
                _DocDt = (DateTime)rd.GetValue(rd.GetOrdinal("DocDt"));
                _Reason = (string)rd.GetValue(rd.GetOrdinal("Reason"));
                _UserId = (byte)rd.GetValue(rd.GetOrdinal("UserId"));

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

        public DataTable SQty(int ItemId)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("qry_StockBal", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@ItemId", SqlDbType.Int);
            MyParam.Value = ItemId;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "ItemStock";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }
		

#region "For View Record"

        public DataTable navigate()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Select Top 100 * From StkAdjVwFn(" + Common.CId + ") where DocId > 0 order by DocId desc", Con);
            Cmd.CommandType = CommandType.Text;

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "View";
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


		public void SetViewControl()
		{
			_FilteringValues.Clear();
			
			_View.FilteringValues = _FilteringValues;
            _View.TableNames = "StkAdjVwFn(" + Common.CId + ")";
			_View.Fields = "*";
			_View.Conditions = "";
			_View.OrderBy="DocNo";
			
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

            tmp.Add(CommonView.GetGridViewColumn("DocId", "DocId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("DocNo", "DocNo", 120, 2, true));
            tmp.Add(CommonView.GetGridViewColumn("DocDt", "DocDt", 80, 3, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));
            tmp.Add(CommonView.GetGridViewColumn("AcYrId", "AcYrId", 0, 4));
            tmp.Add(CommonView.GetGridViewColumn("Reason", "Reason", 100, 6, true, DataGridViewContentAlignment.MiddleRight, "", DataGridViewAutoSizeColumnMode.Fill));
            
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

		#endregion
	}
}
