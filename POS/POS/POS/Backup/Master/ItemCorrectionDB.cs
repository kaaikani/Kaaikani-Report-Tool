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
    public class ItemCorrectionDB
    {
        public ItemCorrectionDB()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        # region "Properties"

        int _RateTypeId;
        public int RateTypeId
        {
            get
            {
                return _RateTypeId;
            }
            set
            {
                _RateTypeId= value;
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


        Boolean  _DefaultRate;
        public Boolean DefaultRate
        {
            get
            {
                return _DefaultRate;
            }
            set
            {
                _DefaultRate = value;
            }
        }

        decimal _MRPRate;
        public decimal MRPRate
        {
            get
            {
                return _MRPRate;
            }
            set
            {
                _MRPRate = value;
            }
        }

        bool _WtItem;
        public bool WtItem
        {
            get
            {
                return _WtItem;
            }
            set
            {
                _WtItem = value;
            }
        }

        decimal _SalRate;
        public decimal SalRate
        {
            get
            {
                return _SalRate;
            }
            set
            {
                _SalRate = value;
            }
        }

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

        int _SizeId;
        public int SizeId
        {
            get
            {
                return _SizeId;
            }
            set
            {
                _SizeId = value;
            }
        }

        decimal _CostRate;
        public decimal CostRate
        {
            get
            {
                return _CostRate;
            }
            set
            {
                _CostRate = value;
            }
        }

        string _ItemCode;
        public string ItemCode
        {
            get
            {
                return _ItemCode;
            }
            set
            {
                _ItemCode = value;
            }
        }

        string _UPCCode;
        public string UPCCode
        {
            get
            {
                return _UPCCode;
            }
            set
            {
                _UPCCode = value;
            }
        }

        string _TamilName;
        public string TamilName
        {
            get
            {
                return _TamilName;
            }
            set
            {
                _TamilName = value;
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
        public DataTable PriceFix_Source(short CatId)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_ItemUpdationDetail", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@CategoryId", SqlDbType.SmallInt);
            param.Value = CatId;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "ItemUpdation";
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

        public DataTable RateDet_Source()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_RateType", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@RateTypeId", SqlDbType.Int);
            param.Value = 0;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "RateType";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();

            return Tbl;
        }

        public int PriceFix_GridStyle(DataGridViewColumnCollection tmp)
        {
            DataTable dtTemp = new DataTable();
            string Rate1, Rate2, Rate3, Rate4 = "";
            tmp.Clear();
            dtTemp = RateDet_Source();
            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 1, false));
            tmp.Add(CommonView.GetGridViewColumn("ItemCode", "Code", 90, 2, (Common.AutoGenCode == true) ? true : false));

            tmp.Add(CommonView.GetGridViewColumn("UPCCode", "UPCCode", 90, 3, false));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 300, 4, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("TamilName", "TamilName", 90, 5, false));
            tmp.Add(CommonView.GetGridViewColumn("CategoryId", "CategoryId", 0, 6));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 90, 7, false));
            tmp.Add(CommonView.GetGridViewColumn("SizeId", "SizeId", 0, 8, true));
            tmp.Add(CommonView.GetGridViewColumn("SizeName", "Size", 0, 9, (Common.AllowSize == true) ? false : true));

            tmp.Add(CommonView.GetGridViewColumn("TaxId", "TaxId", 0, 10));
            tmp.Add(CommonView.GetGridViewColumn("Tax", "Tax", (Common.AllowTax == true) ? 90 : 0, 11, false));

            tmp.Add(CommonView.GetGridViewColumn("MRPRate", "MRP", (Common.AllowMRP == true) ? 90 : 0, 12, false, DataGridViewContentAlignment.MiddleRight, "###0.00"));

            tmp.Add(CommonView.GetGridViewBoolColumn("WtItem", "WeightItem", 0, 13, false));

            tmp.Add(CommonView.GetGridViewColumn("SalRate", "Sales Rate", (Common.ShowCalcPer == true) ? 100 : 0, 14, false, DataGridViewContentAlignment.MiddleRight, "###0.00"));
            tmp.Add(CommonView.GetGridViewColumn("CostRate", "CostRate", 90, 15, false, DataGridViewContentAlignment.MiddleRight, "###0.00"));

            if (dtTemp.Rows.Count > 0)
            {
                int count = 1;
                int ColCount = 17;
                int ColIdCount = 16;
                for (int i = 0; i <= dtTemp.Rows.Count - 1; i++)
                {
                    Rate1 = dtTemp.Rows[i]["RateType"].ToString();
                    tmp.Add(CommonView.GetGridViewColumn("RateId" + count, "RateId" + count, 0, ColIdCount));
                    tmp.Add(CommonView.GetGridViewColumn(Rate1, Rate1, (Common.SingleRate == false) ? 90 : 0, ColCount, false, DataGridViewContentAlignment.MiddleRight, "###0.00"));

                    count = count + 1;
                    ColIdCount = ColIdCount + 2;
                    ColCount = ColCount + 2;
                }
                //else if (dtTemp.Rows.Count == 2)
                //{
                //    Rate1 = dtTemp.Rows[0]["RateType"].ToString();
                //    tmp.Add(CommonView.GetGridViewColumn("RateId1", "RateId1", 0, 6));
                //    tmp.Add(CommonView.GetGridViewColumn(Rate1, Rate1, 90, 7, false, DataGridViewContentAlignment.MiddleRight, "###0.00"));
                //    Rate2 = dtTemp.Rows[1]["RateType"].ToString();
                //    tmp.Add(CommonView.GetGridViewColumn("RateId2", "RateId2", 0, 8));
                //    tmp.Add(CommonView.GetGridViewColumn(Rate2, Rate2, 90, 8, false, DataGridViewContentAlignment.MiddleRight, "###0.00"));
                //}
                //else if (dtTemp.Rows.Count == 3)
                //{
                //    Rate1 = dtTemp.Rows[0]["RateType"].ToString();
                //    tmp.Add(CommonView.GetGridViewColumn("RateId1", "RateId1", 0, 6));
                //    tmp.Add(CommonView.GetGridViewColumn(Rate1, Rate1, 90, 7, false, DataGridViewContentAlignment.MiddleRight, "###0.00"));
                //    Rate2 = dtTemp.Rows[1]["RateType"].ToString();
                //    tmp.Add(CommonView.GetGridViewColumn("RateId2", "RateId2", 0, 8));
                //    tmp.Add(CommonView.GetGridViewColumn(Rate2, Rate2, 90, 8, false, DataGridViewContentAlignment.MiddleRight, "###0.00"));
                //    Rate3 = dtTemp.Rows[2]["RateType"].ToString();
                //    tmp.Add(CommonView.GetGridViewColumn("RateId3", "RateId3", 0, 9));
                //    tmp.Add(CommonView.GetGridViewColumn(Rate3, Rate3, 90, 10, false, DataGridViewContentAlignment.MiddleRight, "###0.00"));
                //}
                //else if (dtTemp.Rows.Count == 4) 
                //{ 
                //    Rate4 = dtTemp.Rows[3]["RateType"].ToString();
                //    tmp.Add(CommonView.GetGridViewColumn("RateId4", "RateId4", 0, 11));
                //    tmp.Add(CommonView.GetGridViewColumn(Rate4, Rate4, 90, 12, false, DataGridViewContentAlignment.MiddleRight, "###0.00"));
                //}                                                           
            }
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        #endregion
        #region "Category"
        public DataTable CategorySelect_Source()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_Category", Con);
            Cmd.CommandType = CommandType.StoredProcedure;


            SqlParameter param = new SqlParameter("@compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "CategorySelect";
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
        public int CategorySelect_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("CategoryId", "CategoryId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 150, 2, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("MarginPer", "MarginPer", 0, 3, false, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("HSNCode", "HSNCode", 0, 4, false, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("ARatePer", "ARatePer", 0, 5, false, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("BRatePer", "BRatePer", 0, 6, false, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("CRatePer", "CRatePer", 0,7, false, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("DRatePer", "DRatePer", 0, 8, false, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 9, false, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 10, false, DataGridViewContentAlignment.MiddleLeft));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

        #endregion
        #region "Tax"
        public DataTable TaxSelect_Source()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_Tax", Con);
            Cmd.CommandType = CommandType.StoredProcedure;


            SqlParameter param = new SqlParameter("@compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "TaxSelect";
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
        public int TaxSelect_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("TaxId", "TaxId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("TaxName", "TaxName", 150, 2, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("TaxPer", "TaxPer", 0, 3, false, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("Vat", "Vat", 0, 4, false, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("CommCode", "CommCode", 0, 5, false, DataGridViewContentAlignment.MiddleLeft));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

             #endregion
        #region "Size"
        public DataTable SizeSelect_Source()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_Size", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@SizeId", SqlDbType.Int);
            param.Value = 0;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "SizeSelect";
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
        public int SizeSelect_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("SizeId", "SizeId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("SizeName", "Size", 150, 2, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("OrderNo", "OrderNo", 0, 3, false, DataGridViewContentAlignment.MiddleLeft));
            //tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 4, false, DataGridViewContentAlignment.MiddleLeft));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

               #endregion
        public DataTable OPItem_Source()
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
        public int OPItem_GridStyle(DataGridViewColumnCollection tmp)
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

        public void SaveFunction(Saving.SaveType Mode)
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
                Cmd = new SqlCommand("ItemCorrectionSp", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@ItemId", SqlDbType.Int);
                param.Value = _ItemId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@RateTypeId", SqlDbType.Int );
                param.Value = _RateTypeId ;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Rate", SqlDbType.Decimal );
                param.Value = _Rate ;
                Cmd.Parameters.Add(param);
             
                param = new SqlParameter("@DefaultRate", SqlDbType.Bit );
                param.Value = _DefaultRate;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@MRPRate", SqlDbType.Decimal);
                param.Value = _MRPRate;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@WtItem", SqlDbType.Bit);
                param.Value = _WtItem;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@SalRate", SqlDbType.Decimal);
                param.Value = _SalRate;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@ItemCode", SqlDbType.VarChar,20);
                param.Value = _ItemCode;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@UPCCode", SqlDbType.VarChar,20);
                param.Value = _UPCCode;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TamilName", SqlDbType.NVarChar, 200);
                param.Value = _TamilName;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CategoryId", SqlDbType.SmallInt);
                param.Value = _CategoryId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TaxId", SqlDbType.SmallInt);
                param.Value = _TaxId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@SizeId", SqlDbType.Int);
                param.Value = _SizeId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CostRate", SqlDbType.Decimal);
                param.Value = _CostRate;
                Cmd.Parameters.Add(param);

                //param = new SqlParameter("@ItemName", SqlDbType.VarChar, 50);
                //param.Value = _ItemName;
                //Cmd.Parameters.Add(param);

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

        public void UpdateCatwiseRate(int catId,decimal aRatePer,decimal bRatePer,decimal cRatePer,decimal dRatePer,DataTable tbl)
        {
            try
            {
                DataSet Ds = new DataSet();                
                string DetStr;
                Ds.Tables.Add(tbl);                

                DetStr = Ds.GetXml();
                DetStr = DetStr.Replace("'", "''");
                DetStr = DetStr.Replace("true", "1");
                DetStr = DetStr.Replace("false", "0");
                if (DetStr.IndexOf("T00:00:00") != -1)
                    DetStr = DetStr.Replace(DetStr.Substring(DetStr.IndexOf("T00:00:00"), 15), "");
                Ds.Tables.Clear();
                Ds.Tables.Clear();
                Ds.Dispose();

                SqlConnection Con = new SqlConnection(Common.ConStr);
                SqlDataAdapter Da = new SqlDataAdapter();
                Con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("UpdateCatRateSp", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@CategoryId", SqlDbType.Int);
                param.Value = catId;
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

                param = new SqlParameter("@DetStr", SqlDbType.Text);
                param.Value = DetStr;
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
