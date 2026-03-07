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
    public class ItemPackSetDB
    {
        public ItemPackSetDB()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        # region "Properties"

        int _DetId;
        public int DetId
        {
            get
            {
                return _DetId;
            }
            set
            {
                _DetId = value;
            }

        }

      
        short _ItemPackId;
        public short ItemPackId
        {
            get
            {
                return _ItemPackId;
            }
            set
            {
                _ItemPackId = value;
            }

        }

        int _ItemId;
        public int ItemId
        {
            get
            {
                return _ItemId;
            }
            set
            {
                _ItemId = value;
            }

        }

       

        decimal _Qty;
        public decimal Qty
        {
            get
            {
                return _Qty;
            }
            set
            {
                _Qty = value;
            }
        }

        decimal _Free;
        public decimal Free
        {
            get
            {
                return _Free;
            }
            set
            {
                _Free = value;
            }
        }

        decimal _Rate;
        public decimal Rate
        {
            get
            {
                return _Rate;
            }
            set
            {
                _Rate = value;
            }
        }

        decimal _Wt;
        public decimal Wt
        {
            get
            {
                return _Wt;
            }
            set
            {
                _Wt = value;
            }
        }

        decimal _PurRate;
        public decimal PurRate
        {
            get
            {
                return _PurRate;
            }
            set
            {
                _PurRate = value;
            }
        }

        DateTime _ExpiryDt;
        public DateTime ExpiryDt
        {
            get
            {
                return _ExpiryDt;
            }
            set
            {
                _ExpiryDt = value;
            }
        }

        string _BatchNo;
        public string BatchNo
        {
            get
            {
                return _BatchNo;
            }
            set
            {
                _BatchNo = value;
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

        #region "Category"

        public DataTable ItemPack_Source()
        {

            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_ItemPackMaster", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Category";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }


        public int ItemPack_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("ItemPackId", "ItemPackId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("ItemPack", "ItemPack", 120, 2, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("ItemPackCode", "ItemPackCode", 120, 3, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 4));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 5));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
#endregion
        # region "Detail"
        public DataTable ItemPackDet_Source(short CategoryId)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_ItemPackDet", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@ItemPackId", SqlDbType.SmallInt);
            param.Value = CategoryId;
            Cmd.Parameters.Add(param);
         
            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "ItemPackDet";
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
                        Col.DefaultValue = DateTime.Now.Date.ToString("dd/MMM/yyyy");
                        Col.AllowDBNull = true;
                        break;
                }
            }
            return Tbl;           
        }
        public int ItemPackDet_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            string HeaderName1, HeaderName2;
            tmp.Add(CommonView.GetGridViewColumn("DetId", "DetId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("ItemPackId", "ItemPackId", 0, 2));
            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 3));
            tmp.Add(CommonView.GetGridViewColumn("ItemCode", "ItemCode", 120, 4, false));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 300, 5, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Qty", "Qty", 80, 10, false, DataGridViewContentAlignment.MiddleRight, "#0"));
            tmp.Add(CommonView.GetGridViewColumn("Wgt", "Wgt", 80, 10, false, DataGridViewContentAlignment.MiddleRight, "#0.000"));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        #endregion

        public DataTable ItemCodeSelect_Source(string ItemCode)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;

            Cmd = new SqlCommand("Qry_ItemCodeSelect", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@ItemCode", SqlDbType.VarChar, 20);
            param.Value = ItemCode;
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
        public DataTable Item_Source()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;

            Cmd = new SqlCommand("Qry_ItemSelect", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@Compid", SqlDbType.TinyInt);
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
            tmp.Add(CommonView.GetGridViewColumn("ItemID", "ItemId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 300, 2));
            tmp.Add(CommonView.GetGridViewColumn("ItemCode", "ItemCode", 160, 3));
            
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 0, 4));
          
            //tmp.Add(CommonView.GetGridViewColumn("Rate", "Rate", 0,7));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

        public string SaveFunction(Saving.SaveType Mode)
        {
            string code;
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
                Cmd = new SqlCommand("ItemPackDetSP", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@Mode", SqlDbType.TinyInt);
                param.Value = Modeval;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DetId", SqlDbType.Int);
                param.Value = _DetId;
                Cmd.Parameters.Add(param);


                param = new SqlParameter("@ItemPackId", SqlDbType.SmallInt);
                param.Value = _ItemPackId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@ItemId", SqlDbType.Int);
                param.Value = _ItemId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Qty", SqlDbType.Int);
                param.Value = _Qty;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Wgt", SqlDbType.Decimal);
                param.Value = _Wt;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Detcode", SqlDbType.VarChar,100);
                param.Direction = ParameterDirection.Output;
                Cmd.Parameters.Add(param);

                Cmd.ExecuteNonQuery();
                code = (string)Cmd.Parameters["@Detcode"].Value;

                return code;
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
