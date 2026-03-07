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
    public class SmsDB
    {
        public SmsDB()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable PhonePartyDet_Source()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_PhoneParty", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@CompId", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "PhoneParty";
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
            //Tbl.Columns["PieceBased"].DefaultValue = false;
            return Tbl;

           
        }
        public int PhonePartyDet_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();

            tmp.Add(CommonView.GetGridViewColumn("AccId", "AccId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("AcCode", "AcCode", 0, 2));
            tmp.Add(CommonView.GetGridViewColumn("Party", "Party", 100, 3, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Address", "Address", 100, 4, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("City", "City", 70, 5, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("AreaId", "AreaId", 0, 6));
            tmp.Add(CommonView.GetGridViewColumn("Ph1", "Phone1", 90, 7, false, DataGridViewContentAlignment.MiddleLeft,""));
            tmp.Add(CommonView.GetGridViewColumn("Ph2", "Phone2", 90, 8, false, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Cell", "Cell", 90, 9,false, DataGridViewContentAlignment.MiddleLeft, ""));
           
            
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        public DataTable SupplierSource()
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_Supplier", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@compId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "SupplierSelect";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public int SupplierSource_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("Accid", "Accid", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("AcCode", "AcCode", 0, 2));
            tmp.Add(CommonView.GetGridViewColumn("Supplier", "Supplier", 100, 3, true));
            tmp.Add(CommonView.GetGridViewColumn("Add1", "Address", 80, 4, true));
            tmp.Add(CommonView.GetGridViewColumn("Add2", "Address1", 80, 5, true));
            tmp.Add(CommonView.GetGridViewColumn("Add3", "Address2", 80, 6, true));
            tmp.Add(CommonView.GetGridViewColumn("City", "City", 80, 7, true));
            tmp.Add(CommonView.GetGridViewColumn("Pincode", "Pincode", 80, 8, true));
            tmp.Add(CommonView.GetGridViewColumn("Ph1", "Phone", 80, 9, true));
            tmp.Add(CommonView.GetGridViewColumn("Ph2", "Phone1", 80, 10, true));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
   
        public void SaveFunction(Saving.SaveType Mode)
        {
            int code;
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
                Cmd = new SqlCommand("PhonePartySp", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                //SqlParameter param = new SqlParameter("@Mode", SqlDbType.TinyInt);
                //param.Value = Modeval;
                //Cmd.Parameters.Add(param);

                SqlParameter param = new SqlParameter("@AccId", SqlDbType.Int);
                param.Value = _AccId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Ph1", SqlDbType.VarChar,20);
                param.Value = _Ph1.Replace("'", "''");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Ph2", SqlDbType.VarChar,20);
                param.Value = _Ph2.Replace("'", "''");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Cell", SqlDbType.VarChar,14);
                param.Value = _Cell.Replace("'", "''");
                Cmd.Parameters.Add(param);

              
                param = new SqlParameter("@Compid", SqlDbType.TinyInt);
                param.Value = Common.CId;
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

 
      
        #region  "Properties"
        private int _AccId;

        public int AccId
        {
            get { return _AccId; }
            set { _AccId = value; }
        }
        private string _Ph1;

        public string Ph1
        {
            get { return _Ph1; }
            set { _Ph1 = value; }
        }

        private string _Ph2;

        public string Ph2
        {
            get { return _Ph2; }
            set { _Ph2 = value; }
        }

        private string _Cell;

        public string Cell
        {
            get { return _Cell; }
            set { _Cell = value; }
        }

        private byte _CompId;

        public byte CompId
        {
            get { return _CompId; }
            set { _CompId = value; }
        }
        #endregion
    }
}
