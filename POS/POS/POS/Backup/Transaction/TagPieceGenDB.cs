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
    public class TagPieceGenDB
    {
        public TagPieceGenDB()
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

        # endregion
        public int GetItemtTagRate_Source(int Itemid, decimal SalesRate, int SizeId, DateTime PurDt)
        {
            int codes;
            try
            {
                SqlConnection MyCon = new SqlConnection();
                SqlCommand MyCmd = new SqlCommand();
                SqlParameter MyParam = new SqlParameter();
                SqlDataAdapter MyAdapt = new SqlDataAdapter();
                DataTable DTbl = new DataTable();

                MyCon = new SqlConnection(Common.ConStr);
                MyCon.Open();

                MyCmd = new SqlCommand("GetitemTagRateIDsp", MyCon);
                MyCmd.CommandType = CommandType.StoredProcedure;

                MyParam = new SqlParameter("@Itemid", SqlDbType.Int);
                MyParam.Value = Itemid;
                MyCmd.Parameters.Add(MyParam);

                MyParam = new SqlParameter("@Rate", SqlDbType.Decimal);
                MyParam.Value = SalesRate;
                MyCmd.Parameters.Add(MyParam);

                MyParam = new SqlParameter("@SizeId", SqlDbType.Int);
                MyParam.Value = SizeId;
                MyCmd.Parameters.Add(MyParam);                

                MyParam = new SqlParameter("@PurDt", SqlDbType.DateTime);
                MyParam.Value = PurDt.ToString("dd/MMM/yyyy");
                MyCmd.Parameters.Add(MyParam);

                MyParam = new SqlParameter("@Rateid", SqlDbType.Int);
                MyParam.Direction = ParameterDirection.Output;
                MyCmd.Parameters.Add(MyParam);

                MyCmd.ExecuteNonQuery();
                codes = (int)MyCmd.Parameters["@Rateid"].Value;
                return codes;
                MyCmd.Dispose();
                MyCon.Close();

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
        public DataTable StickerPrint_Source(int PurId)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("qry_BatchTagGenerate", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@PurId", SqlDbType.Int);
            MyParam.Value = PurId;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "TagPieceGeneration";
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

        public int StickerPrint_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
           
            tmp.Add(CommonView.GetGridViewColumn("Selection", "Selection", 0,1));
            tmp.Add(CommonView.GetGridViewColumn("ItemCode", "ItemCode",70, 2, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("UpcCode", "UpcCode", 0, 3, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Brand", "Brand", 90, 4, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 160, 5, false, DataGridViewContentAlignment.MiddleLeft, "",DataGridViewAutoSizeColumnMode .Fill ));  ///DataGridViewContentAlignment.MiddleCenter
            tmp.Add(CommonView.GetGridViewColumn("SizeId", "SizeId", 0, 6,true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("SizeName", "Size", 90, 7,false, DataGridViewContentAlignment.MiddleLeft, ""));
            
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 0,8, true, DataGridViewContentAlignment.MiddleLeft, ""));

            tmp.Add(CommonView.GetGridViewColumn("ItemGrpName", "ItemGrpName", 0, 9, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Supplier", "Supplier", 0, 10));
           
            tmp.Add(CommonView.GetGridViewColumn("Qty", (Common.HeaderName1 == "") ? "Qty" : Common.HeaderName1, 75, 11, false, DataGridViewContentAlignment.MiddleRight, Common.QtyFormat));
            tmp.Add(CommonView.GetGridViewColumn("Cost", "Cost", 80, 12, false));
            tmp.Add(CommonView.GetGridViewColumn("MRPRate", "MRPRate", 0, 13, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SaleRate", "SaleRate", 75, 14, false, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("BarCode", "BarCode", 0, 15, true));
            tmp.Add(CommonView.GetGridViewColumn("DesignDet", "DesignDet", 0, 16, false));
            tmp.Add(CommonView.GetGridViewColumn("Itemid", "ItemId", 0, 17));
            
            //tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
           
            return 0;
        }
        public DataTable ItemSelect_Source()
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_ItemSelect", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Item";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public int ItemSelect_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();

            tmp.Add(CommonView.GetGridViewColumn("Itemid", "ItemId", 0, 1, false));
            tmp.Add(CommonView.GetGridViewColumn("Brand", "Brand", 90, 2, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 160, 3, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));  ///DataGridViewContentAlignment.MiddleCenter
            tmp.Add(CommonView.GetGridViewColumn("Itemcode", "ItemCode", 70, 4, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 0, 5, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Rate", "Rate", 0, 6, true, DataGridViewContentAlignment.MiddleLeft, ""));
            
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
            return 0;
        }
        public DataTable ItemSizeDet_Source(int ItemId)
        {

            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_ItemSizeDet", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@ItemId", SqlDbType.Int);
            MyParam.Value = ItemId;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Size";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }
        public int ItemSizeDet_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("SizeId", "SizeId", 0, 2));
            tmp.Add(CommonView.GetGridViewColumn("SizeName", "Size", 80, 3, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));            
            tmp.Add(CommonView.GetGridViewColumn("OrderNo", "OrderNo", 0, 5));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        public void RateSaveFunction(int ItemId, decimal Rate)
        {
           
            try
            {
                SqlConnection Con = new SqlConnection(Common.ConStr);
                SqlDataAdapter Da = new SqlDataAdapter();
                Con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("ItemSalUpdate", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@ItemId", SqlDbType.Int);
                param.Value = ItemId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Rate", SqlDbType.Decimal);
                param.Value = Rate;
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
        public void RateSizeSaveFunction(int ItemId,int SizeId, decimal Rate)
        {

            try
            {
                SqlConnection Con = new SqlConnection(Common.ConStr);
                SqlDataAdapter Da = new SqlDataAdapter();
                Con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("ItemSizeSalUpdate", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@ItemId", SqlDbType.Int);
                param.Value = ItemId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@SizeId", SqlDbType.Int);
                param.Value = SizeId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Rate", SqlDbType.Decimal);
                param.Value = Rate;
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
        public DataTable PrintName_Source()
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();
            int code;

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("BarCodePrintName", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            //MyParam = new SqlParameter("@BarCodeId", SqlDbType.Int);
            //MyParam.Value = BarCodeId;
            //MyCmd.Parameters.Add(MyParam);

            //MyParam = new SqlParameter("@compid", SqlDbType.TinyInt);
            //MyParam.Value = Common.CId;
            //MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "BarCodePrintName";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            //code = DTbl.Rows[0][0];
            return DTbl;
        }
        public DataTable BarCodeHdr_Source(int BarCodeId)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();
            int code;

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_BarcodeDesignHdr", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@BarCodeId", SqlDbType.Int);
            MyParam.Value = BarCodeId;
            MyCmd.Parameters.Add(MyParam);

            //MyParam = new SqlParameter("@compid", SqlDbType.TinyInt);
            //MyParam.Value = Common.CId;
            //MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_BarcodeDesignHdr";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            //code = DTbl.Rows[0][0];
            return DTbl;
        }

        public DataTable BarCodeDet_Source(int BarCodeId)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();
            int code;

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_BarcodeDesignDet", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@BarCodeId", SqlDbType.Int);
            MyParam.Value = BarCodeId;
            MyCmd.Parameters.Add(MyParam);

            //MyParam = new SqlParameter("@compid", SqlDbType.TinyInt);
            //MyParam.Value = Common.CId;
            //MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_BarcodeDesignDet";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            //code = DTbl.Rows[0][0];
            return DTbl;
        }
        public DataTable PurNoSource()
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            //MyCmd = new SqlCommand("Qry_PurStickerPrint", MyCon);
            MyCmd = new SqlCommand("Qry_PurNoSource", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "PurNo";
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
        public int PurNoSource_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("PurId", "PurId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("PurNo", "PurNo", 100, 2, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("PurDt", "PurDt", 0, 3, true));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
    }
}
