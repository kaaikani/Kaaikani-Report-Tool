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
    public class ItemDB
    {
        public ItemDB()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        # region "Properties"


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

        int _ItemPackId;
        public int ItemPackId
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


        decimal _MinStk;
        public decimal MinStk
        {
            get
            {
                return _MinStk;
            }
            set
            {
                _MinStk = value;
            }
        }

        decimal _MaxStk;
        public decimal MaxStk
        {
            get
            {
                return _MaxStk;
            }
            set
            {
                _MaxStk = value;
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

        string _ItemName;
        public string ItemName
        {
            get
            {
                return _ItemName;
            }
            set
            {
                _ItemName = value;
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


        string _HSCCode;
        public string HSCCode
        {
            get
            {
                return _HSCCode;
            }
            set
            {
                _HSCCode = value;
            }
        }






















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

        short _ItemGrpId;
        public short ItemGrpId
        {
            get
            {
                return _ItemGrpId;
            }
            set
            {
                _ItemGrpId = value;
            }
        }


        Boolean _WtItem;
        public Boolean WtItem
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

        Boolean _IsChargeHead;
        public Boolean IsChargeHead
        {
            get
            {
                return _IsChargeHead;
            }
            set
            {
                _IsChargeHead = value;
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

        decimal _IncPer;
        public decimal IncPer
        {
            get
            {
                return _IncPer;
            }
            set
            {
                _IncPer = value;
            }
        }

        decimal _IncAmt;
        public decimal IncAmt
        {
            get
            {
                return _IncAmt;
            }
            set
            {
                _IncAmt = value;
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
        string _CRate;
        public string CRate
        {
            get
            {
                return _CRate;
            }
            set
            {
                _CRate = value;
            }
        }

        bool _EcItem;
        public bool EcItem
        {
            get
            {
                return _EcItem;
            }
            set
            {
                _EcItem = value;
            }
        }

        decimal _EcPer;
        public decimal EcPer
        {
            get
            {
                return _EcPer;
            }
            set
            {
                _EcPer = value;
            }
        }

        bool _IsEstimate;
        public bool IsEstimate
        {
            get
            {
                return _IsEstimate;
            }
            set
            {
                _IsEstimate = value;
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

        Boolean _AllowExpiry;
        public Boolean AllowExpiry
        {
            get
            {
                return _AllowExpiry;
            }
            set
            {
                _AllowExpiry = value;
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

        decimal _OPQty;
        public decimal OPQty
        {
            get
            {
                return _OPQty;
            }
            set
            {
                _OPQty = value;
            }
        }

        decimal _OpWt;
        public decimal OpWt
        {
            get
            {
                return _OpWt;
            }
            set
            {
                _OpWt = value;
            }
        }

        int _UnitId;
        public int UnitId
        {
            get
            {
                return _UnitId;
            }
            set
            {
                _UnitId = value;
            }
        }

        bool _UpcCodeItem;
        public bool UpcCodeItem
        {
            get
            {
                return _UpcCodeItem;
            }
            set
            {
                _UpcCodeItem = value;
            }
        }

        decimal _DiscPer;
        public decimal DiscPer
        {
            get
            {
                return _DiscPer;
            }
            set
            {
                _DiscPer = value;
            }
        }

        decimal _DiscAmt;
        public decimal DiscAmt
        {
            get
            {
                return _DiscAmt;
            }
            set
            {
                _DiscAmt = value;
            }
        }

        int _BrandId;
        public int BrandId
        {
            get
            {
                return _BrandId;
            }
            set
            {
                _BrandId = value;
            }
        }

        DataTable _ItemRateDet;
        public DataTable ItemRateDet
        {
            get
            {
                return _ItemRateDet;
            }
            set
            {
                _ItemRateDet = value;
            }
        }

        DataTable _ItemSizeDet;
        public DataTable ItemSizeDet
        {
            get
            {
                return _ItemSizeDet;
            }
            set
            {
                _ItemSizeDet = value;
            }
        }

        # endregion

        # region "Save"
        public string SaveFunction(Saving.SaveType Mode)
        {
            string code;

            DataSet Ds = new DataSet();
            string DetStr;

            if (ItemRateDet.Rows.Count > 0)
                Ds.Tables.Add(ItemRateDet);
            if (ItemSizeDet != null)
                Ds.Tables.Add(ItemSizeDet);

            DetStr = Ds.GetXml();
            DetStr = DetStr.Replace("'", "''");
            DetStr = DetStr.Replace("true", "1");
            DetStr = DetStr.Replace("false", "0");

            Ds.Tables.Clear();
            Ds.Dispose();

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
                Cmd = new SqlCommand("ItemSP", Con);
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@Mode", SqlDbType.TinyInt);
                param.Value = Modeval;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@ItemId", SqlDbType.Int);
                param.Value = _ItemId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@ItemCode", SqlDbType.VarChar, 20);
                param.Value = _ItemCode.Replace("'", "''");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@ItemName", SqlDbType.NVarChar, 250);
                param.Value = _ItemName.Replace("'", "''");
                Cmd.Parameters.Add(param);


                param = new SqlParameter("@CategoryId", SqlDbType.SmallInt);
                param.Value = _CategoryId;
                Cmd.Parameters.Add(param);

                //param = new SqlParameter("@ItemPackId", SqlDbType.Int);
                //param.Value = _ItemPackId;
                //Cmd.Parameters.Add(param);

                param = new SqlParameter("@ItemGrpId", SqlDbType.SmallInt);
                param.Value = _ItemGrpId;
                Cmd.Parameters.Add(param);


                param = new SqlParameter("@AccId", SqlDbType.Int);
                param.Value = _AccId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TaxId", SqlDbType.SmallInt);
                param.Value = _TaxId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@WtItem", SqlDbType.Bit);
                param.Value = _WtItem;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Rate", SqlDbType.Decimal);
                param.Value = _Rate;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@MinStkQty", SqlDbType.Decimal);
                param.Value = _MinStk;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@MaxStkQty", SqlDbType.Decimal);
                param.Value = _MaxStk;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.TinyInt);
                param.Value = Common.UserId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CompId", SqlDbType.TinyInt);
                param.Value = Common.CId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TamilName", SqlDbType.NVarChar, 100);
                param.Value = _TamilName;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@UPCCode", SqlDbType.VarChar, 20);
                param.Value = _UPCCode;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@MasDB", SqlDbType.VarChar, 50);
                param.Value = Common.MasDataBase;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@IncPer", SqlDbType.Decimal);
                param.Value = _IncPer;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@IncAmt", SqlDbType.Decimal);
                param.Value = _IncAmt;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@AllowExpiry", SqlDbType.Bit);
                param.Value = _AllowExpiry;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@MRPRate", SqlDbType.Decimal);
                param.Value = _MRPRate;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@SizeId", SqlDbType.Int);
                param.Value = _SizeId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@OpQty", SqlDbType.Decimal);
                param.Value = _OPQty;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@UnitId", SqlDbType.Int);
                param.Value = _UnitId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@UpcCodeItem", SqlDbType.Bit);
                param.Value = _UpcCodeItem;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DiscPer", SqlDbType.Decimal);
                param.Value = _DiscPer;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DiscAmt", SqlDbType.Decimal);
                param.Value = _DiscAmt;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@BrandId", SqlDbType.Int);
                param.Value = _BrandId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@OpWt", SqlDbType.Decimal);
                param.Value = _OpWt;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DetStr", SqlDbType.Text);
                param.Value = DetStr;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@code", SqlDbType.VarChar, 20);
                param.Direction = ParameterDirection.Output;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@HSCCode", SqlDbType.VarChar, 20);
                param.Value = _HSCCode;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@IsChargeHead", SqlDbType.Bit);
                param.Value = _IsChargeHead;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CostRate", SqlDbType.Decimal);
                param.Value = _CostRate;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CRate", SqlDbType.NVarChar,50);
                param.Value = _CRate;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@EcItem", SqlDbType.Bit);
                param.Value = _EcItem;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@EcPer", SqlDbType.Decimal);
                param.Value = _EcPer;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@IsEstimate", SqlDbType.Bit);
                param.Value = _IsEstimate;
                Cmd.Parameters.Add(param);

                Cmd.ExecuteNonQuery();
                code = (string)Cmd.Parameters["@code"].Value;

                return code;

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
        # endregion

        public DataTable ItemList_Source()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_ItemSearch", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@ItemId", SqlDbType.Int);
            param.Value = 0;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@CompId", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);
            Cmd.CommandTimeout = 1000000;
            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "Itemm";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();

            return Tbl;
        }
        public int ItemList_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("ItemCode", "Code", 70, 2, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("UpcCode", "UpcCode", 0, 3, true));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 90, 4, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("TamilName", "TamilName", 0, 5, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("ItemGrpId", "ItemGrpId", 0, 6, true));
            tmp.Add(CommonView.GetGridViewColumn("ItemGrpName", "ItemGrpName", 0, 7, true));            
            tmp.Add(CommonView.GetGridViewColumn("CategoryId", "CategoryId", 0, 8, true));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 80, 9, true));
            tmp.Add(CommonView.GetGridViewColumn("TaxId", "TaxId", 0, 10, true));
            tmp.Add(CommonView.GetGridViewColumn("TaxName", "TaxName", 0, 11, true));
            tmp.Add(CommonView.GetGridViewColumn("AccId", "AccId", 0, 12, true));
            tmp.Add(CommonView.GetGridViewColumn("Supplier", "Supplier", 0, 13, true));
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 14, true));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 15, true));
            tmp.Add(CommonView.GetGridViewColumn("Rate", "Rate", 0, 16, true));
            tmp.Add(CommonView.GetGridViewColumn("BrandId", "BrandId", 0, 17, true));
            tmp.Add(CommonView.GetGridViewColumn("Brand", "Brand", 0, 18, true));
            tmp.Add(CommonView.GetGridViewColumn("MinStkQty", "MinStkQty", 0, 19, true));
            tmp.Add(CommonView.GetGridViewColumn("MaxStkQty", "MaxStkQty", 0, 20, true));
            tmp.Add(CommonView.GetGridViewColumn("WtItem", "WtItem", 0, 21, true));
            tmp.Add(CommonView.GetGridViewColumn("IncPer", "IncPer", 0, 22, true));
            tmp.Add(CommonView.GetGridViewColumn("IncAmt", "IncAmt", 0, 23, true));
            tmp.Add(CommonView.GetGridViewColumn("AllowExpiry", "AllowExpiry", 0, 24, true));
            tmp.Add(CommonView.GetGridViewColumn("MRPRate", "MRPRate", 0, 25, true));
            tmp.Add(CommonView.GetGridViewColumn("SizeId", "SizeId", 0, 26, true));
            tmp.Add(CommonView.GetGridViewColumn("OpQty", "OpQty", 0, 27, true));
            tmp.Add(CommonView.GetGridViewColumn("UnitId", "UnitId", 0, 28, true));
            tmp.Add(CommonView.GetGridViewColumn("UpcCodeItem", "UpcCodeItem", 0, 29, true));
            tmp.Add(CommonView.GetGridViewColumn("DiscPer", "DiscPer", 0, 30, true));
            tmp.Add(CommonView.GetGridViewColumn("DiscAmt", "DiscAmt", 0, 31, true));
            tmp.Add(CommonView.GetGridViewColumn("OpWt", "OpWt", 0, 32, true));
            tmp.Add(CommonView.GetGridViewColumn("HscCode", "HscCode", 0, 33, true));
            tmp.Add(CommonView.GetGridViewColumn("IsChargeHead", "IsChargeHead", 0, 34, true));
            tmp.Add(CommonView.GetGridViewColumn("NoofQty", "NoofQty", 0, 35, true));
            tmp.Add(CommonView.GetGridViewColumn("LastPurRate", "LastPurRate", 0, 36, true));
            tmp.Add(CommonView.GetGridViewColumn("CostRate", "CostRate", 0, 37, true));
            tmp.Add(CommonView.GetGridViewColumn("Profit", "Profit", 0, 38, true));
            tmp.Add(CommonView.GetGridViewColumn("CRate", "CRate", 0, 39, true));
            tmp.Add(CommonView.GetGridViewColumn("IsEstimate", "IsEstimate", 0, 40, true));
            
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

        # region "Selection"

        public DataTable Category_Source()
        {

            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_Category", MyCon);
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


        public int Category_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("CategoryId", "CategoryId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 80, 2, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("HSNCode", "HSNCode", 0, 3));
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 4));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 5));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

        public DataTable Brand_Source()
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_BrandMaster", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Brand";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public int Brand_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("BrandId", "BrandId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("BrandName", "BrandName", 120, 2, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("ARatePer", "ARate%", 0, 3, true, DataGridViewContentAlignment.MiddleRight, ""));
            tmp.Add(CommonView.GetGridViewColumn("BRatePer", "BRate%", 0, 4, true, DataGridViewContentAlignment.MiddleRight, ""));
            tmp.Add(CommonView.GetGridViewColumn("CRatePer", "CRate%", 0, 5, true, DataGridViewContentAlignment.MiddleRight, ""));
            tmp.Add(CommonView.GetGridViewColumn("DRatePer", "DRate%", 0, 6, true, DataGridViewContentAlignment.MiddleRight, ""));
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 7, false, DataGridViewContentAlignment.MiddleRight, "0.00"));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 8, false, DataGridViewContentAlignment.MiddleRight, "0.00"));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
            return 0;
        }

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

            DTbl.TableName = "ItemPack";
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



        public DataTable Supplier_Source()
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

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
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

        public int Supplier_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("Accid", "Accid", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Supplier", "Supplier", 200, 4, true));
            tmp.Add(CommonView.GetGridViewColumn("AcCode", "AcCode", 0, 3));
            tmp.Add(CommonView.GetGridViewColumn("Add1", "Address", 80, 4, true));
            tmp.Add(CommonView.GetGridViewColumn("Add2", "Address1", 80, 5, true));
            tmp.Add(CommonView.GetGridViewColumn("Add3", "Address2", 80, 6, true));
            tmp.Add(CommonView.GetGridViewColumn("City", "City", 80, 7, true));
            tmp.Add(CommonView.GetGridViewColumn("Pincode", "Pincode", 80, 8, true));
            tmp.Add(CommonView.GetGridViewColumn("Ph1", "Phone", 80, 9, true));
            tmp.Add(CommonView.GetGridViewColumn("Ph2", "Phone1", 80, 10, true));
            tmp.Add(CommonView.GetGridViewColumn("TransportId", "TransportId", 0, 11));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }


        public DataTable ItemGroup_Source()
        {

            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_ItemGroup", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "ItemGrp";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }


        public int ItemGroup_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("ItemGrpId", "ItemGrpId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("ItemGrpName", "ItemGrpName", 80, 2, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));

            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 4));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 5));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }


        public DataTable Itemcode_cheking(int configid)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Config_Qry_GetBitvalue", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@ConfigId", SqlDbType.Int);
            MyParam.Value = configid;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@compId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);


            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Itemcode";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public DataTable RateDet_Source(int RateTypeId)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_RateType", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@RateTypeId", SqlDbType.Int);
            param.Value = RateTypeId;
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
        public int Rate_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();

            tmp.Add(CommonView.GetGridViewColumn("RateTypeId", "RateTypeId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("RateType", "RateType", 300, 2, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Percentage", "%", 90, 3, false, DataGridViewContentAlignment.MiddleRight, "0.000"));
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 4));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 5));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

        # endregion

        # region "Fetch Section"
        public bool FetchRecord(int Id)
        {
            SqlConnection Con = new SqlConnection(Common.ConStr);
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_Item", Con);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("@ItemID", SqlDbType.Int);
            param.Value = Id;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);


            SqlDataReader rd = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (rd.Read())
            {
                _ItemId = (int)rd.GetValue(rd.GetOrdinal("ItemId"));
                _ItemCode = (string)rd.GetValue(rd.GetOrdinal("ItemCode"));
                _ItemName = (string)rd.GetValue(rd.GetOrdinal("ItemName"));
                _ItemGrpId = (short)rd.GetValue(rd.GetOrdinal("ItemGrpId"));
                _MinStk = (decimal)rd.GetValue(rd.GetOrdinal("MinStkQty"));
                _MaxStk = (decimal)rd.GetValue(rd.GetOrdinal("MaxStkQty"));
                _CategoryId = (short)rd.GetValue(rd.GetOrdinal("CategoryId"));
                //_ItemPackId = (short)rd.GetValue(rd.GetOrdinal("ItemPackId"));
                _TaxId = (short)rd.GetValue(rd.GetOrdinal("TaxId"));
                _AccId = (int)rd.GetValue(rd.GetOrdinal("AccId"));
                _WtItem = (Boolean)rd.GetValue(rd.GetOrdinal("WtItem"));
                _Rate = (decimal)rd.GetValue(rd.GetOrdinal("Rate"));
                _TamilName = (string)rd.GetValue(rd.GetOrdinal("tamilName"));
                _UPCCode = (string)rd.GetValue(rd.GetOrdinal("UPCCode"));
                _IncPer = (decimal)rd.GetValue(rd.GetOrdinal("IncPer"));
                _IncAmt = (decimal)rd.GetValue(rd.GetOrdinal("IncAmt"));
                _AllowExpiry = (bool)rd.GetValue(rd.GetOrdinal("AllowExpiry"));
                _MRPRate = (decimal)rd.GetValue(rd.GetOrdinal("MRPRate"));
                _SizeId = (int)rd.GetValue(rd.GetOrdinal("SizeId"));
                _OPQty = (decimal)rd.GetValue(rd.GetOrdinal("OpQty"));
                _UnitId = (int)rd.GetValue(rd.GetOrdinal("UnitId"));
                _UpcCodeItem = (bool)rd.GetValue(rd.GetOrdinal("UpcCodeItem"));
                _DiscPer = (decimal)rd.GetValue(rd.GetOrdinal("DiscPer"));
                _DiscAmt = (decimal)rd.GetValue(rd.GetOrdinal("DiscAmt"));
                _BrandId = (int)rd.GetValue(rd.GetOrdinal("BrandId"));
                _OpWt = (decimal)rd.GetValue(rd.GetOrdinal("OpWt"));
                _IsChargeHead = (Boolean)rd.GetValue(rd.GetOrdinal("IsChargeHead"));
                _CostRate = (decimal)rd.GetValue(rd.GetOrdinal("CostRate"));
                _CRate = (string)rd.GetValue(rd.GetOrdinal("CRate"));
                _EcItem = (bool)rd.GetValue(rd.GetOrdinal("EcItem"));
                _EcPer = (decimal)rd.GetValue(rd.GetOrdinal("EcPer"));
                _IsEstimate = (bool)rd.GetValue(rd.GetOrdinal("IsEstimate"));
                _UserId = (byte)rd.GetValue(rd.GetOrdinal("UserId"));
                _CompId = (Byte)rd.GetValue(rd.GetOrdinal("CompId"));


                _HSCCode = (string)rd.GetValue(rd.GetOrdinal("HSCCode"));
                //_UserName = (string)rd.GetValue(rd.GetOrdinal("AccId"));



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
        #endregion

        #region "For View Record"
        public DataTable navigate()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Select Top 100 * From ItemVwFn(" + Common.CId + ") where ItemId > 0 order by ItemId desc", Con);
            Cmd.CommandType = CommandType.Text;

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "Item";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }

        public System.Collections.Hashtable _FilteringValues = new System.Collections.Hashtable();
        _ViewValues _View;
        public struct _ViewValues
        {
            public System.Collections.Hashtable FilteringValues;
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
            _View.TableNames = "ItemVwFn(" + Common.CId + ")";
            _View.Fields = "*";
            _View.Conditions = "";
            _View.OrderBy = "ItemId";
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
            tmp.Add(CommonView.GetGridViewColumn("Itemid", "Itemid", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Itemcode", "Itemcode", 60, 2, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("UPCCode", "UPCCode", 0, 3, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("CategoryId", "CategoryId", 0, 4));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 90, 5, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("BrandId", "BrandId", 0, 6));
            tmp.Add(CommonView.GetGridViewColumn("Brand", "Brand", 90, 7, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 60, 8, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Unit", "Unit", 80, 9, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("TamilName", "TamilName", 80, 10, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("TaxId", "TaxId", 0, 11));
            tmp.Add(CommonView.GetGridViewColumn("TaxPer", "Tax%", 70, 12, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("itemGrpId", "ItemGrpId", 0, 13));
            tmp.Add(CommonView.GetGridViewColumn("itemGrpName", "ItemGrpName", 0, 14, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("AccId", "AccId", 0, 15));
            tmp.Add(CommonView.GetGridViewColumn("supplier", "SupplierName", 0, 16, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Rate", "Rate", 80, 17, true, DataGridViewContentAlignment.MiddleRight, "0.00"));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }


        public int Search_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("Itemid", "Itemid", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Itemcode", "Itemcode", 80, 2, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("UPCCode", "UPCCode", 90, 3, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 100, 4, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("CategoryId", "CategoryId", 0, 5));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 80, 6, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("TaxId", "TaxId", 0, 7));
            tmp.Add(CommonView.GetGridViewColumn("TaxName", "TaxName", 80, 8, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("itemGrpId", "ItemGrpId", 0, 9));
            tmp.Add(CommonView.GetGridViewColumn("itemGrpName", "ItemGrpName", 0, 10, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("AccId", "AccId", 0, 11));
            tmp.Add(CommonView.GetGridViewColumn("supplier", "SupplierName", 0, 12, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Rate", "Rate", 60, 13, true, DataGridViewContentAlignment.MiddleRight, "0.00"));
            tmp.Add(CommonView.GetGridViewColumn("LastPurRate", "LastPurchaseRate", 0, 14, true, DataGridViewContentAlignment.MiddleLeft, "0.00"));
            tmp.Add(CommonView.GetGridViewColumn("LastSaleRate", "LastSaleRate", 0, 15, true, DataGridViewContentAlignment.MiddleLeft, "0.00"));



            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }


        #endregion
        public DataTable RateType_Source(int RateTypeId)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_RateType", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@RateTypeId", SqlDbType.Int);
            param.Value = RateTypeId;
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
        public int RateType_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();

            tmp.Add(CommonView.GetGridViewColumn("RateTypeId", "RateTypeId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("RateType", "RateType", 300, 2, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 3));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 4));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

        public DataTable RateTypeFill_Source(int RateTypeId)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_RateTypeSource", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@RateTypeId", SqlDbType.Int);
            param.Value = RateTypeId;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "ItemRateDet";
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
        public int RateTypeFill_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("RateTypeId", "RateTypeId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("RateType", "Rate Type", 200, 2, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 3));
            tmp.Add(CommonView.GetGridViewColumn("Rate", "Rate", 120, 4, false, DataGridViewContentAlignment.MiddleRight, "##0.00"));
            tmp.Add(CommonView.GetGridViewBoolColumn("DefaultRate", "DefaultRate", 120, 6));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

        public DataTable ItemDet_Source(int Id)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_ItemRateDet", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@ItemId", SqlDbType.Int);
            param.Value = Id;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "ItemRateDet";
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
                        Col.DefaultValue = "01/01/1900";
                        Col.AllowDBNull = true;
                        break;
                    case "Boolean":
                        Col.DefaultValue = 0;
                        Col.AllowDBNull = false;
                        break;
                }
            }
            return Tbl;

        }
        public int ItemDet_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("RateTypeId", "RateTypeId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("RateType", "Rate Type", 200, 2, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 3));
            //tmp.Add(CommonView.GetGridViewColumn("Unit", "Unit", 0, 4));
            //tmp.Add(CommonView.GetGridViewColumn("UnitId", "UnitId", 0, 5));
            tmp.Add(CommonView.GetGridViewColumn("Rate", "Rate", 120, 4, false, DataGridViewContentAlignment.MiddleRight, "##0.00"));
            tmp.Add(CommonView.GetGridViewBoolColumn("DefaultRate", "DefaultRate", 120, 5));


            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        public DataTable Unit_Source(int UnitId)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_Unit", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@UnitId", SqlDbType.Int);
            MyParam.Value = UnitId;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Unit";
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

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
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

        #region "Tax"
        public DataTable Tax_Source()
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_Tax", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Tax";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public int Tax_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();

            tmp.Add(CommonView.GetGridViewColumn("TaxId", "TaxId", 0, 1));


            tmp.Add(CommonView.GetGridViewColumn("TaxName", "TaxName", 100, 2, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("TaxPer", "Tax%", 60, 3, true));
            tmp.Add(CommonView.GetGridViewBoolColumn("Vat", "Vat", 50, 4, false));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        #endregion
        # region "Detail"
        public DataTable QuickItemDet_Source()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_QuickItem", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "Item";
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
        public int QuickItem_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("ItemCode", "ItemCode", 0, 2));
            tmp.Add(CommonView.GetGridViewColumn("UPCCode", "UPCCode", 90, 3, false, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("BrandId", "BrandId", 0, 4));
            tmp.Add(CommonView.GetGridViewColumn("Brand", "Brand", 100, 5, false, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 100, 6, false, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 100, 7, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("TamilName", "TamilName", 190, 8, false, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("CategoryId", "CategoryId", 0, 9));
            tmp.Add(CommonView.GetGridViewColumn("TaxId", "TaxId", 0, 10));
            tmp.Add(CommonView.GetGridViewColumn("TaxName", "Tax", 80, 11, false, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("OpQty", "OpQty", 0, 12, false, DataGridViewContentAlignment.MiddleRight, "###0.00"));
            tmp.Add(CommonView.GetGridViewColumn("OpWt", "OpWt", 0, 13, false, DataGridViewContentAlignment.MiddleRight, "###0.000"));
            tmp.Add(CommonView.GetGridViewColumn("MRPRate", "MRP", (Common.AllowMRP == true) ? 90 : 0, 14, false, DataGridViewContentAlignment.MiddleRight, "###0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Rate", "Rate", 80, 15, false, DataGridViewContentAlignment.MiddleRight, "###0.00"));
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 16));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 17));
            tmp.Add(CommonView.GetGridViewColumn("ARateTypeId", "ARateTypeId", 0, 18));
            tmp.Add(CommonView.GetGridViewColumn("ARate", "ARate", 80, 19, false, DataGridViewContentAlignment.MiddleRight, "###0.00"));
            tmp.Add(CommonView.GetGridViewColumn("BRateTypeId", "BRateTypeId", 0, 20));
            tmp.Add(CommonView.GetGridViewColumn("BRate", "BRate", 80, 21, false, DataGridViewContentAlignment.MiddleRight, "###0.00"));
            tmp.Add(CommonView.GetGridViewColumn("CRateTypeId", "CRateTypeId", 0, 22));
            tmp.Add(CommonView.GetGridViewColumn("CRate", "CRate", 80, 23, false, DataGridViewContentAlignment.MiddleRight, "###0.00"));
            tmp.Add(CommonView.GetGridViewColumn("DRateTypeId", "DRateTypeId", 0, 24));
            tmp.Add(CommonView.GetGridViewColumn("DRate", "DRate", 80, 25, false, DataGridViewContentAlignment.MiddleRight, "###0.00"));
            tmp.Add(CommonView.GetGridViewColumn("catARatePer", "catARatePer", 0, 26));
            tmp.Add(CommonView.GetGridViewColumn("catBRatePer", "catBRatePer", 0, 27));
            tmp.Add(CommonView.GetGridViewColumn("catCRatePer", "catCRatePer", 0, 28));
            tmp.Add(CommonView.GetGridViewColumn("catDRatePer", "catDRatePer", 0, 29));
            tmp.Add(CommonView.GetGridViewColumn("brARatePer", "brARatePer", 0, 30));
            tmp.Add(CommonView.GetGridViewColumn("brBRatePer", "brBRatePer", 0, 31));
            tmp.Add(CommonView.GetGridViewColumn("brCRatePer", "brCRatePer", 0, 32));
            tmp.Add(CommonView.GetGridViewColumn("brDRatePer", "brDRatePer", 0, 33));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        #endregion

        public DataTable ItemSizeDetSource(int Itemid)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_ItemSizeDet", Con);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("@Itemid", SqlDbType.Int);
            param.Value = Itemid;
            Cmd.Parameters.Add(param);
            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);
            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "ItemSizeDet";
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
        public int ItemSizeDet_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();

            tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 1, false));
            tmp.Add(CommonView.GetGridViewColumn("SizeId", "SizeId", 0, 2, false));
            tmp.Add(CommonView.GetGridViewColumn("SizeName", "Size", 90, 3, false, DataGridViewContentAlignment.MiddleLeft, ""));
            //tmp.Add(CommonView.GetGridViewColumn("UPCCode", "UPCCode", 0, 3, false, DataGridViewContentAlignment.MiddleLeft,""));
            tmp.Add(CommonView.GetGridViewColumn("Rate", "Rate", 90, 4, false, DataGridViewContentAlignment.MiddleRight, "####0.00"));
            //tmp.Add(CommonView.GetGridViewColumn("MRPRate", "MRP", 0, 5, false, DataGridViewContentAlignment.MiddleRight,"####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("OrderNo", "OrderNo", 0, 5, true, DataGridViewContentAlignment.MiddleRight));


            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        public DataTable SizeFill_Source()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_SizeFill", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "SizeFill";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();

            return Tbl;

        }

        public int SizeFill_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();



            tmp.Add(CommonView.GetGridViewColumn("SizeId", "SizeId", 0, 1));
            tmp.Add(CommonView.GetGridViewBoolColumn("Selection", "Select", 30, 2));
            //tmp.Add(CommonView.GetGridViewColumn("ItemId", "ItemId", 0, 2));
            tmp.Add(CommonView.GetGridViewColumn("SizeName", "Size Name", 120, 4, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("OrderNo", "OrderNo", 120, 5, true, DataGridViewContentAlignment.MiddleRight));


            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        public DataTable Size_Source(int Id)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_Size", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@SizeId", SqlDbType.Int);
            param.Value = Id;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "Size";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();

            return Tbl;

        }
        public DataTable ItemChecking_Source()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_ItemCheck", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "Item";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();

            return Tbl;

        }
    }
}
