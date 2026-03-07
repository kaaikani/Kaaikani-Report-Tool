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
    public class ItemDeletionDB
    {
        public ItemDeletionDB()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        # region "Properties"

        DataTable _ItemDet;
        public DataTable ItemDet
        {
            get
            {
                return _ItemDet;
            }
            set
            {
                _ItemDet = value;
            }
        }

       
        # endregion

        #region "RateType"

      

        public DataTable RateTypeSelect_Source()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_RateType", Con);
            Cmd.CommandType = CommandType.StoredProcedure;


            SqlParameter param = new SqlParameter("@compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "RateSelect";
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
        public int RateTypeSelect_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear(); tmp.Add(CommonView.GetGridViewColumn("RateTypeId", "RateTypeId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("RateType", "RateType", 150, 2, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId",0, 3, false, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 4, false, DataGridViewContentAlignment.MiddleLeft));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

#endregion
        # region "Detail"
        public DataTable ItemSelect_Source()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_ItemDeletion", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "ItemDeletion";
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

        public int ItemSelect_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();


            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 1));
            tmp.Add(CommonView.GetGridViewBoolColumn("Selection", "Select", 50,2, false));
            tmp.Add(CommonView.GetGridViewColumn("ItemCode", "Code", 90, 3, true));
            tmp.Add(CommonView.GetGridViewColumn("UpcCode", "UPCCode", 90, 4, true));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 300, 5, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("TamilName", "TamilName", 90, 6, true));
            tmp.Add(CommonView.GetGridViewColumn("CategoryId", "CategoryId", 0, 7));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 90, 8, true));
            tmp.Add(CommonView.GetGridViewColumn("TaxName", "Tax", (Common.AllowTax == true) ? 70 : 0 , 9, true)); 
            tmp.Add(CommonView.GetGridViewColumn("Rate", "Sales Rate", 100, 10, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));
           
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        #endregion
       
        public void SaveFunction()
        {
            DataTable Tbl = new DataTable();
            DataSet Ds = new DataSet();
            DataSet Ds1 = new DataSet();
            string DetStr;
            string DetStr1;
            Ds.Tables.Add(ItemDet);
         
            DetStr = Ds.GetXml();
            DetStr = DetStr.Replace("'", "''");
            DetStr = DetStr.Replace("true", "1");
            DetStr = DetStr.Replace("false", "0");
            if (DetStr.IndexOf("T00:00:00") != -1)
                DetStr = DetStr.Replace(DetStr.Substring(DetStr.IndexOf("T00:00:00"), 15), "");
            Ds.Tables.Clear();
            Ds.Tables.Clear();
            Ds.Dispose();

            try
            {
                SqlConnection Con = new SqlConnection(Common.ConStr);
                SqlDataAdapter Da = new SqlDataAdapter();
                Con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("ItemDeleteSp", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@DetStr", SqlDbType.Text);
                param.Value = DetStr;
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

 
    }
}
