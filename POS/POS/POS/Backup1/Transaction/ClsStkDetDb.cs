using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using GridStructures;
using DBAccess;
using AccountsDB;

namespace AccountsDB
{
    public class ClsStkDetDb
    {
        #region "First"

        private bool disposed = false;


        int _Id;
        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }

        int _ClsStkid;
        public int ClsStkid
        {
            get
            {
                return _ClsStkid;
            }
            set
            {
                _ClsStkid = value;
            }
        }


        int _OpStkid;
        public int OpStkid
        {
            get
            {
                return _OpStkid;
            }
            set
            {
                _OpStkid = value;
            }
        }

        decimal _Amt;
        public decimal Amt
        {
            get
            {
                return _Amt;
            }
            set
            {
                _Amt = value;
            }
        }


        #endregion

        #region "Property"

        public DateTime FetchFromDt(string Month, int Accode)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();
            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Acc_Qry_FromDtFn", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Month", SqlDbType.VarChar, 15);
            MyParam.Value = Month;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@AccId", SqlDbType.Int);
            MyParam.Value = Accode;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "RecDet";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return ((DTbl.Rows[0][0].ToString() == "") ? DateTime.Now.Date : (DateTime)DTbl.Rows[0][0]);
            //return DTbl;
        }

        public DateTime FetchToDt(string Month, int Accode)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();


            MyCmd = new SqlCommand("Acc_Qry_ToDtFn", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Month", SqlDbType.VarChar, 15);
            MyParam.Value = Month;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@AccId", SqlDbType.Int);
            MyParam.Value = Accode;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "RecDet";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return ((DTbl.Rows[0][0].ToString() == "") ? DateTime.Now.Date : (DateTime)DTbl.Rows[0][0]);
        }
        public double OpBal(DateTime FromDt, int Accode)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();


            MyCmd = new SqlCommand("Acc_Qry_OpBalance", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Dt", SqlDbType.DateTime);
            MyParam.Value = FromDt;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@AccId", SqlDbType.Int);
            MyParam.Value = Accode;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "TrBalRpt";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return ((DTbl.Rows[0][0] == null) ? 0 : (double)DTbl.Rows[0][0]);
        }
        #endregion

        # region "Selection"
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
        public DataTable Item_Source()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_ItemSelect", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@Itemcode", SqlDbType.VarChar);
            param.Value = "";
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "ItemSelect";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }

        public int Item_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();

            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 200, 2, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Itemcode", "Itemcode", 0, 3));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 0, 4));
            tmp.Add(CommonView.GetGridViewColumn("Mtype", "Mtype", 100, 5, true, DataGridViewContentAlignment.MiddleLeft));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        #endregion
        # region "FillGrid"

        public DataTable ClsStkDetDs()
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();


            MyCmd = new SqlCommand("Acc_Qry_clsstkdetvw", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "ClsStkdetVw";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            foreach (DataColumn Col in DTbl.Columns)
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
            return DTbl;
        }
        public int ClsStkDet_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("clsstkdetid", "clsstkdetid", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("ClosingStock", "ClosingStock", 100, 2, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("OpeningStock", "OpeningStock", 100, 3, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Amount", "Amount", 100, 4, false, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("clsstkid", "clsstkid", 0, 5));
            tmp.Add(CommonView.GetGridViewColumn("opstkid", "opstkid", 0, 6));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
            return 0;
        }


        public DataTable ItemDetDs()
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();


            MyCmd = new SqlCommand("Acc_qry_ClsStk", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "ClsStkdetVw";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            foreach (DataColumn Col in DTbl.Columns)
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
            return DTbl;
        }
        public int ItemDet_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 100, 2, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("ClsWt", "Closing.Wt", 100, 3, true, DataGridViewContentAlignment.MiddleRight, "######0.000"));
            tmp.Add(CommonView.GetGridViewColumn("Rate", "Rate", 100, 4, false, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Amount", "Amount", 100, 4, true, DataGridViewContentAlignment.MiddleRight, "######0.00"));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
            return 0;
        }
            # endregion
        # region "Save"

        public int SaveFunction(Saving.SaveType Mode)
        {
            int CId;
                int Modeval = 0;
                if (Mode == Saving.SaveType.Add)
                    Modeval = 1;
                else if (Mode == Saving.SaveType.Edit)
                    Modeval = 2;
                else if (Mode == Saving.SaveType.Delete)
                    Modeval = 3;
                else if (Mode == Saving.SaveType.DocCancel)
                    Modeval = 8;

                try
                {
                    SqlConnection Con = new SqlConnection(Common.ConStr);
                    SqlDataAdapter Da = new SqlDataAdapter();
                    Con.Open();
                    SqlCommand Cmd;
                    Cmd = new SqlCommand("Acc_ClsStkDetSp", Con);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter param = new SqlParameter("@mode", SqlDbType.TinyInt);
                    param.Value = Modeval;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@id", SqlDbType.Int);
                    param.Value = _Id;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@ClsStkid", SqlDbType.Int);
                    param.Value = _ClsStkid;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@OpStkId", SqlDbType.Int);
                    param.Value = _OpStkid;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Amount", SqlDbType.Decimal);
                    param.Value = _Amt;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@usrid", SqlDbType.TinyInt);
                    param.Value = Common.UserId;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@CompId", SqlDbType.TinyInt);
                    param.Value = Common.CId;
                    Cmd.Parameters.Add(param);


                   param = new SqlParameter("@CId", SqlDbType.Int);
                    param.Direction = ParameterDirection.Output;
                    Cmd.Parameters.Add(param);

                    Cmd.ExecuteNonQuery ();
                    CId = (int)Cmd.Parameters["@CId"].Value;
                   
                    return CId;
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

    
        

    }
}