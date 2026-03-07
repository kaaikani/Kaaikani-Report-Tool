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
    public class PriceFixDB
    {
        public PriceFixDB()
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
        public DataTable PriceFix_Source(int BrandId,short CategoryId)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_ItemRateDetail", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@BrandId", SqlDbType.Int);
            param.Value = BrandId;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@CategoryId", SqlDbType.SmallInt);
            param.Value = CategoryId;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "Brand";
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
            string Rate1,Rate2,Rate3,Rate4 ="";
            tmp.Clear();
            dtTemp=RateDet_Source();

            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("ItemCode", "Code", 90, 2, true));
            tmp.Add(CommonView.GetGridViewColumn("UPCCode", "UPCCode", 90, 3, true));
            tmp.Add(CommonView.GetGridViewColumn("Brand", "Brand", 100, 4, true));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 200, 5, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("TamilName", "TamilName", 300, 6, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("SalRate", "Sales Rate", (Common.CalcRatePer == true) ? 100 : 0, 7, false, DataGridViewContentAlignment.MiddleRight, "###0.00"));
           
            if (dtTemp.Rows.Count > 0)
            {
                int count = 1;
                int ColCount = 9;
                int ColIdCount = 8;
                for (int i = 0; i<=dtTemp.Rows.Count-1; i++)
                {      
                        Rate1 = dtTemp.Rows[i]["RateType"].ToString();
                        tmp.Add(CommonView.GetGridViewColumn("RateId"+count, "RateId"+count, 0, ColIdCount));
                        tmp.Add(CommonView.GetGridViewColumn(Rate1, Rate1, 90, ColCount, false, DataGridViewContentAlignment.MiddleRight, "###0.00"));
                   count= count+1;
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
            tmp.Add(CommonView.GetGridViewColumn("BrandId", "BrandId", 0, 12));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 0, 13, true));
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

        public DataTable Brand_Source()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;

            Cmd = new SqlCommand("Qry_Brand", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "Brand";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }

        public int Brand_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("BrandId", "BrandId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Brand", "Brand", 300, 2));
           
            //tmp.Add(CommonView.GetGridViewColumn("Rate", "Rate", 0,7));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

        public DataTable Category_Source()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;

            Cmd = new SqlCommand("Qry_Category", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "Category";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }

        public int Category_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("CategoryId", "CategoryId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 300, 2));
            tmp.Add(CommonView.GetGridViewColumn("HSNCode", "HSNCode", 0, 3));
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 4));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 5));

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
                Cmd = new SqlCommand("PriceFixSp", Con);
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

                param = new SqlParameter("@SalRate", SqlDbType.Decimal);
                param.Value = _SalRate;
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

        public void ItemRateUpdation(bool Inc,decimal Per,int BrandId,short CategoryId)
        {            
            try
            {
                SqlConnection Con = new SqlConnection(Common.ConStr);
                SqlDataAdapter Da = new SqlDataAdapter();
                Con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("Qry_ItemRateUpdation", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@Increment", SqlDbType.Bit);
                param.Value = Inc;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Per", SqlDbType.Decimal);
                param.Value = Per;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@BrandId", SqlDbType.Int);
                param.Value = BrandId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CategoryId", SqlDbType.SmallInt);
                param.Value = CategoryId;
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
