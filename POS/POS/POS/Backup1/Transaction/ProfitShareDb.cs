using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using GridStructures;
using DBAccess;
using AccountsDB;

namespace AccountsDB
{
    public class ProfitShareDb
    {
        #region "Property"

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

        decimal _Per;
        public decimal Per
        {
            get
            {
                return _Per;
            }
            set
            {
                _Per = value;
            }
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
        
        #endregion

        # region "FillGrid"

        public DataTable ProfitDetDs()
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();


            MyCmd = new SqlCommand("Acc_Qry_ProfitShareVw", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            MyCmd.Parameters.Add(param);

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
        public int ProfitDet_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("AccId", "AccId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Ledger", "Ledger", 100, 2, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Percentage", "Percentage", 100, 4, false, DataGridViewContentAlignment.MiddleRight, "######0.00"));
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 5));
            
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
            return 0;
        }

            # endregion

        # region "Save"

        public void SaveFunction(Saving.SaveType Mode)
        {
           
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

                    Cmd = new SqlCommand("Acc_ProfitShareSp", Con);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter param = new SqlParameter("@mode", SqlDbType.TinyInt);
                    param.Value = Modeval;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@id", SqlDbType.Int);
                    param.Value = _Id;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Per", SqlDbType.Decimal);
                    param.Value = _Per;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@usrid", SqlDbType.TinyInt);
                    param.Value = Common.UserId;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@CompId", SqlDbType.TinyInt);
                    param.Value = Common.CId;
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

    
        

    }
}