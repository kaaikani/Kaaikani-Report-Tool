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
	/// Summary description for SalesDb.
	/// </summary>
    public class ConfigurationDB
    {
        public ConfigurationDB()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        # region "Properties"

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

        string _FormType;
        public string FormType
        {
            get
            {
                return _FormType;
            }
            set
            {
                _FormType = value;
            }
        }

        bool _Printermode;
        public bool Printermode
        {
            get
            {
                return _Printermode;
            }
            set
            {
                _Printermode = value;
            }
        }

        bool _PrintConfirmation;
        public bool PrintConfirmation
        {
            get
            {
                return _PrintConfirmation;
            }
            set
            {
                _PrintConfirmation = value;
            }
        }




        bool _SalRecAmt;
        public bool SalRecAmt
        {
            get
            {
                return _SalRecAmt;
            }
            set
            {
                _SalRecAmt = value;
            }
        }

        bool _AutoCustRate;
        public bool AutoCustRate
        {
            get
            {
                return _AutoCustRate;
            }
            set
            {
                _AutoCustRate = value;
            }
        }

        bool _DefaultSalRate;
        public bool DefaultSalRate
        {
            get
            {
                return _DefaultSalRate;
            }
            set
            {
                _DefaultSalRate = value;
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

        bool _AllowDisc;
        public bool AllowDisc
        {
            get
            {
                return _AllowDisc;
            }
            set
            {
                _AllowDisc = value;
            }
        }

        bool _AllowFree;
        public bool AllowFree
        {
            get
            {
                return _AllowFree;
            }
            set
            {
                _AllowFree = value;
            }
        }

        bool _CalcAmt;
        public bool CalcAmt
        {
            get
            {
                return _CalcAmt;
            }
            set
            {
                _CalcAmt = value;
            }
        }

        bool _StkChecking;
        public bool StkChecking
        {
            get
            {
                return _StkChecking;
            }
            set
            {
                _StkChecking = value;
            }
        }

        bool _PrintPrev;
        public bool PrintPrev
        {
            get
            {
                return _PrintPrev;
            }
            set
            {
                _PrintPrev = value;
            }
        }

        byte _PrnModelId;
        public byte PrnModelId
        {
            get
            {
                return _PrnModelId;
            }
            set
            {
                _PrnModelId = value;
            }
        }
        string _PrnModel;
        public string PrnModel
        {
            get
            {
                return _PrnModel;
            }
            set
            {
                _PrnModel = value;
            }
        }
        byte _NoOfCopy;
        public byte NoOfCopy
        {
            get
            {
                return _NoOfCopy;
            }
            set
            {
                _NoOfCopy = value;
            }
        }

        string _PrnMessage;
        public string PrnMessage
        {
            get
            {
                return _PrnMessage;
            }
            set
            {
                _PrnMessage = value;
            }
        }
        string _TLeft1;
        public string TLeft1
        {
            get
            {
                return _TLeft1;
            }
            set
            {
                _TLeft1 = value;
            }
        }
        string _TLeft2;
        public string TLeft2
        {
            get
            {
                return _TLeft2;
            }
            set
            {
                _TLeft2 = value;
            }
        }
        string _TLeft3;
        public string TLeft3
        {
            get
            {
                return _TLeft3;
            }
            set
            {
                _TLeft3 = value;
            }
        }
        string _TLeft4;
        public string TLeft4
        {
            get
            {
                return _TLeft4;
            }
            set
            {
                _TLeft4 = value;
            }
        }
        string _TLeft5;
        public string TLeft5
        {
            get
            {
                return _TLeft5;
            }
            set
            {
                _TLeft5 = value;
            }
        }
        string _TMid1;
        public string TMid1
        {
            get
            {
                return _TMid1;
            }
            set
            {
                _TMid1 = value;
            }
        }
        string _TMid2;
        public string TMid2
        {
            get
            {
                return _TMid2;
            }
            set
            {
                _TMid2 = value;
            }
        }
        string _TMid3;
        public string TMid3
        {
            get
            {
                return _TMid3;
            }
            set
            {
                _TMid3 = value;
            }
        }
        string _TMid4;
        public string TMid4
        {
            get
            {
                return _TMid4;
            }
            set
            {
                _TMid4 = value;
            }
        }
        string _TMid5;
        public string TMid5
        {
            get
            {
                return _TMid5;
            }
            set
            {
                _TMid5 = value;
            }
        }
        string _TRight1;
        public string TRight1
        {
            get
            {
                return _TRight1;
            }
            set
            {
                _TRight1 = value;
            }
        }
        string _TRight2;
        public string TRight2
        {
            get
            {
                return _TRight2;
            }
            set
            {
                _TRight2 = value;
            }
        }
        string _TRight3;
        public string TRight3
        {
            get
            {
                return _TRight3;
            }
            set
            {
                _TRight3 = value;
            }
        }
        string _TRight4;
        public string TRight4
        {
            get
            {
                return _TRight4;
            }
            set
            {
                _TRight4 = value;
            }
        }
        string _TRight5;
        public string TRight5
        {
            get
            {
                return _TRight5;
            }
            set
            {
                _TRight5 = value;
            }
        }
        string _BarcodeType;
        public string BarcodeType
        {
            get
            {
                return _BarcodeType;
            }
            set
            {
                _BarcodeType = value;
            }
        }
        string _GrnMessage;
        public string GrnMessage
        {
            get
            {
                return _GrnMessage;
            }
            set
            {
                _GrnMessage = value;
            }
        }


        string _SalChargeCaption1;
        public string SalChargeCaption1
        {
            get
            {
                return _SalChargeCaption1;
            }
            set
            {
                _SalChargeCaption1 = value;
            }
        }

        string _SalChargeCaption2;
        public string SalChargeCaption2
        {
            get
            {
                return _SalChargeCaption2;
            }
            set
            {
                _SalChargeCaption2 = value;
            }
        }

        string _SalDown1;
        public string SalDown1
        {
            get
            {
                return _SalDown1;
            }
            set
            {
                _SalDown1 = value;
            }
        }

        string _HeaderName1;
        public string HeaderName1
        {
            get
            {
                return _HeaderName1;
            }
            set
            {
                _HeaderName1 = value;
            }
        }

        string _HeaderName2;
        public string HeaderName2
        {
            get
            {
                return _HeaderName2;
            }
            set
            {
                _HeaderName2 = value;
            }
        }

        int _SalCharge1PostId;
        public int SalCharge1PostId
        {
            get
            {
                return _SalCharge1PostId;
            }
            set
            {
                _SalCharge1PostId = value;
            }
        }


        int _SalCharge2PostId;
        public int SalCharge2PostId
        {
            get
            {
                return _SalCharge2PostId;
            }
            set
            {
                _SalCharge2PostId = value;
            }
        }


        string _QtyDigit;
        public string QtyDigit
        {
            get
            {
                return _QtyDigit;
            }
            set
            {
                _QtyDigit = value;
            }
        }

        byte _BPrnModelId;
        public byte BPrnModelId
        {
            get
            {
                return _BPrnModelId;
            }
            set
            {
                _BPrnModelId = value;
            }
        }

        string _DwnColumn;
        public string DwnColumn
        {
            get
            {
                return _DwnColumn;
            }
            set
            {
                _DwnColumn = value;
            }
        }

        string _NxtColumn;
        public string NxtColumn
        {
            get
            {
                return _NxtColumn;
            }
            set
            {
                _NxtColumn = value;
            }
        }

        bool _Type;
        public bool Type
        {
            get
            {
                return _Type;
            }
            set
            {
                _Type = value;
            }
        }

        bool _AllowTax;
        public bool AllowTax
        {
            get
            {
                return _AllowTax;
            }
            set
            {
                _AllowTax = value;
            }
        }

        bool _ShowPurRate;
        public bool ShowPurRate
        {
            get
            {
                return _ShowPurRate;
            }
            set
            {
                _ShowPurRate = value;
            }
        }

        bool _CalcRatePer;
        public bool CalcRatePer
        {
            get
            {
                return _CalcRatePer;
            }
            set
            {
                _CalcRatePer = value;
            }
        }

        bool _ShowSalMan;
        public bool ShowSalMan
        {
            get
            {
                return _ShowSalMan;
            }
            set
            {
                _ShowSalMan = value;
            }
        }

        bool _IncDecValue;
        public bool IncDecValue
        {
            get
            {
                return _IncDecValue;
            }
            set
            {
                _IncDecValue = value;
            }
        }

        bool _WtColumn;
        public bool WtColumn
        {
            get
            {
                return _WtColumn;
            }
            set
            {
                _WtColumn = value;
            }
        }

        bool _DtWiseBillNo;
        public bool DtWiseBillNo
        {
            get
            {
                return _DtWiseBillNo;
            }
            set
            {
                _DtWiseBillNo = value;
            }
        }

        bool _RndOff;
        public bool RndOff
        {
            get
            {
                return _RndOff;
            }
            set
            {
                _RndOff = value;
            }
        }

        bool _AutoGenCode;
        public bool AutoGenCode
        {
            get
            {
                return _AutoGenCode;
            }
            set
            {
                _AutoGenCode = value;
            }
        }

        bool _AutoBackUp;
        public bool AutoBackUp
        {
            get
            {
                return _AutoBackUp;
            }
            set
            {
                _AutoBackUp = value;
            }
        }

        string _DefaultFocus;
        public string DefaultFocus
        {
            get
            {
                return _DefaultFocus;
            }
            set
            {
                _DefaultFocus = value;
            }
        }

        bool _Rate1;
        public bool Rate1
        {
            get
            {
                return _Rate1;
            }
            set
            {
                _Rate1 = value;
            }
        }

        bool _Rate2;
        public bool Rate2
        {
            get
            {
                return _Rate2;
            }
            set
            {
                _Rate2 = value;
            }
        }

        bool _Rate3;
        public bool Rate3
        {
            get
            {
                return _Rate3;
            }
            set
            {
                _Rate3 = value;
            }
        }

        bool _Rate4;
        public bool Rate4
        {
            get
            {
                return _Rate4;
            }
            set
            {
                _Rate4 = value;
            }
        }

        bool _None;
        public bool None
        {
            get
            {
                return _None;
            }
            set
            {
                _None = value;
            }
        }


        bool _AutoMasterCode;
        public bool AutoMasterCode
        {
            get
            {
                return _AutoMasterCode;
            }
            set
            {
                _AutoMasterCode = value;
            }
        }

        bool _SingleRate;
        public bool SingleRate
        {
            get
            {
                return _SingleRate;
            }
            set
            {
                _SingleRate = value;
            }
        }

        int _DefaultTaxId;
        public int DefaultTaxId
        {
            get
            {
                return _DefaultTaxId;
            }
            set
            {
                _DefaultTaxId = value;
            }
        }

        int _DefaultCatId;
        public int DefaultCatId
        {
            get
            {
                return _DefaultCatId;
            }
            set
            {
                _DefaultCatId = value;
            }
        }


        DataTable _SalPostDet;
        public DataTable SalPostDet
        {
            get
            {
                return _SalPostDet;
            }
            set
            {
                _SalPostDet = value;
            }
        }

        bool _AllowExpiryDt;
        public bool AllowExpiryDt
        {
            get
            {
                return _AllowExpiryDt;
            }
            set
            {
                _AllowExpiryDt = value;
            }
        }

        bool _RateEnter;
        public bool RateEnter
        {
            get
            {
                return _RateEnter;
            }
            set
            {
                _RateEnter = value;
            }
        }

        int _CSTTaxId;
        public int CSTTaxId
        {
            get
            {
                return _CSTTaxId;
            }
            set
            {
                _CSTTaxId = value;
            }
        }

        int _DefaultBookId;
        public int DefaultBookId
        {
            get
            {
                return _DefaultBookId;
            }
            set
            {
                _DefaultBookId = value;
            }
        }

        bool _PackDet;
        public bool PackDet
        {
            get
            {
                return _PackDet;
            }
            set
            {
                _PackDet = value;
            }
        }

        bool _TaxPattern;
        public bool TaxPattern
        {
            get
            {
                return _TaxPattern;
            }
            set
            {
                _TaxPattern = value;
            }
        }

        bool _AllowMRP;
        public bool AllowMRP
        {
            get
            {
                return _AllowMRP;
            }
            set
            {
                _AllowMRP = value;
            }
        }

        bool _AllowSize;
        public bool AllowSize
        {
            get
            {
                return _AllowSize;
            }
            set
            {
                _AllowSize = value;
            }
        }

        bool _FromQuot;
        public bool FromQuot
        {
            get
            {
                return _FromQuot;
            }
            set
            {
                _FromQuot = value;
            }
        }

        bool _RndOffPs;
        public bool RndOffPs
        {
            get
            {
                return _RndOffPs;
            }
            set
            {
                _RndOffPs = value;
            }
        }

        bool _AllowUpcCode;
        public bool AllowUpcCode
        {
            get
            {
                return _AllowUpcCode;
            }
            set
            {
                _AllowUpcCode = value;
            }
        }

        bool _RateLock;
        public bool RateLock
        {
            get
            {
                return _RateLock;
            }
            set
            {
                _RateLock = value;
            }
        }

        bool _AllowUnit;
        public bool AllowUnit
        {
            get
            {
                return _AllowUnit;
            }
            set
            {
                _AllowUnit = value;
            }
        }

        bool _AllowDesc;
        public bool AllowDesc
        {
            get
            {
                return _AllowDesc;
            }
            set
            {
                _AllowDesc = value;
            }
        }


        string _Stockpoint;
        public string Stockpoint
        {
            get
            {
                return _Stockpoint;
            }
            set
            {
                _Stockpoint = value;
            }
        }

        bool _MultiSalRate;
        public bool MultiSalRate
        {
            get
            {
                return _MultiSalRate;
            }
            set
            {
                _MultiSalRate = value;
            }
        }

        bool _AllowPrint;
        public bool AllowPrint
        {
            get
            {
                return _AllowPrint;
            }
            set
            {
                _AllowPrint = value;
            }
        }


        bool _IsAutoSaleStk;
        public bool IsAutoSaleStk
        {
            get
            {
                return _IsAutoSaleStk;
            }
            set
            {
                _IsAutoSaleStk = value;
            }
        }


        bool _IsAutoItemSelect;
        public bool IsAutoItemSelect
        {
            get
            {
                return _IsAutoItemSelect;
            }
            set
            {
                _IsAutoItemSelect = value;
            }
        }

        bool _DiscSharing;
        public bool DiscSharing
        {
            get
            {
                return _DiscSharing;
            }
            set
            {
                _DiscSharing = value;
            }
        }

        bool _CustRateType;
        public bool CustRateType
        {
            get
            {
                return _CustRateType;
            }
            set
            {
                _CustRateType = value;
            }
        }

        # endregion

        # region "Selection Source"

        public DataTable Config_Source(string FormType)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_Config_Sales", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@FormTYpe", SqlDbType.Char, 5);
            MyParam.Value = FormType;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "CustomerSelect";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public DataTable Config_PrnModel(bool PrnModel)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_Config_PrnModel", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Printermode", SqlDbType.Bit);
            MyParam.Value = PrnModel;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_Config_PrnModel";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }


        public DataTable Config_BarModel()
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_Config_BarModel", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            //MyParam = new SqlParameter("@Printermode", SqlDbType.Bit);
            //MyParam.Value = PrnModel;
            //MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_Config_BarModel";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public DataTable Config_PrnModelDet_Source(byte PrnModelId)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_Config_PrnModelDet", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@PrnModelId", SqlDbType.TinyInt);
            param.Value = PrnModelId;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "PrnModelDet";
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
                   case "Boolean":
                        Col.DefaultValue = false;
                        Col.AllowDBNull = false;
                        break;
                }
            }
            return Tbl;

        }
        public int PrnModelDet_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();

            tmp.Add(CommonView.GetGridViewColumn("PrnModelId", "PrnModelId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("PrnModel", "PrnModel", 70, 2, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("ModelCode", "ModelCode", 90, 3, false, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewBoolColumn("DefaultPrint", "DefaultPrint", 80, 4, false));
        
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
            return 0;
        }


        # endregion

        # region "Save Function"

        public void SaveFunction()
        {
            DataTable Tbl = new DataTable();
            DataSet Ds = new DataSet();
            string DetStr;
            //Ds.Tables.Add(SalDet);

            //DetStr = Ds.GetXml();
            //DetStr = DetStr.Replace("'", "''");
            //DetStr = DetStr.Replace("true", "1");
            //DetStr = DetStr.Replace("false", "0");
            //if (DetStr.IndexOf("T00:00:00") != -1)
            //    DetStr = DetStr.Replace(DetStr.Substring(DetStr.IndexOf("T00:00:00"), 15), "");
            //Ds.Tables.Clear();
            //Ds.Tables.Clear();
            //Ds.Dispose();
            //string code;

            try
            {
                SqlConnection Con = new SqlConnection(Common.ConStr);
                SqlDataAdapter Da = new SqlDataAdapter();
                Con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("Config_SalSp", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@DocId", SqlDbType.Int);
                param.Value = _DocId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@FormType", SqlDbType.Char, 5);
                param.Value = _FormType;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Printermode", SqlDbType.Bit);
                param.Value = _Printermode;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@PrnModelId", SqlDbType.TinyInt);
                param.Value = _PrnModelId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@NoOfCopy", SqlDbType.TinyInt);
                param.Value = _NoOfCopy;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@BarcodeType", SqlDbType.Char, 5);
                param.Value = _BarcodeType;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@BPrnModelId", SqlDbType.TinyInt);
                param.Value = _BPrnModelId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@QtyDigit", SqlDbType.VarChar, 5);
                param.Value = _QtyDigit;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@GrnMessage", SqlDbType.NVarChar, 100);
                param.Value = _GrnMessage;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@PrnMessage", SqlDbType.NVarChar, 100);
                param.Value = _PrnMessage;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@SalChargeCaption1", SqlDbType.VarChar, 100);
                param.Value = _SalChargeCaption1;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@SalChargeCaption2", SqlDbType.VarChar, 100);
                param.Value = _SalChargeCaption2;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@SalCharge1PostId", SqlDbType.Int);
                param.Value = _SalCharge1PostId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@SalCharge2PostId", SqlDbType.Int);
                param.Value = _SalCharge2PostId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TLeft1", SqlDbType.NVarChar, 300);
                param.Value = _TLeft1;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TLeft2", SqlDbType.NVarChar, 300);
                param.Value = _TLeft2;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TLeft3", SqlDbType.NVarChar, 300);
                param.Value = _TLeft3;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TLeft4", SqlDbType.NVarChar, 300);
                param.Value = _TLeft4;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TLeft5", SqlDbType.NVarChar, 300);
                param.Value = _TLeft5;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TRight1", SqlDbType.VarChar, 300);
                param.Value = _TRight1;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TRight2", SqlDbType.VarChar, 300);
                param.Value = _TRight2;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TRight3", SqlDbType.VarChar, 300);
                param.Value = _TRight3;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TRight4", SqlDbType.VarChar, 300);
                param.Value = _TRight4;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TRight5", SqlDbType.VarChar, 300);
                param.Value = _TRight5;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TMid1", SqlDbType.VarChar, 300);
                param.Value = _TMid1;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TMid2", SqlDbType.VarChar, 300);
                param.Value = _TMid2;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TMid3", SqlDbType.VarChar, 300);
                param.Value = _TMid3;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TMid4", SqlDbType.VarChar, 300);
                param.Value = _TMid4;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TMid5", SqlDbType.VarChar, 300);
                param.Value = _TMid5;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CompId", SqlDbType.TinyInt);
                param.Value = Common.CId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@PrintConformation", SqlDbType.Bit);
                param.Value = _PrintConfirmation;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@SalRecAmt", SqlDbType.Bit);
                param.Value = _SalRecAmt;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@AutoCustRate", SqlDbType.Bit);
                param.Value = _AutoCustRate;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DefaultSalRate", SqlDbType.Bit);
                param.Value = _DefaultSalRate;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DwnColumn", SqlDbType.VarChar, 50);
                param.Value = _DwnColumn;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@NxtColumn", SqlDbType.VarChar, 50);
                param.Value = _NxtColumn;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@WtItem", SqlDbType.Bit);
                param.Value = _WtItem;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@AllowDisc", SqlDbType.Bit);
                param.Value = _AllowDisc;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DwnColumn1", SqlDbType.VarChar, 50);
                param.Value = _SalDown1;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@HeaderName1", SqlDbType.VarChar, 50);
                param.Value = _HeaderName1;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@HeaderName2", SqlDbType.VarChar, 50);
                param.Value = _HeaderName2;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Type", SqlDbType.Bit);
                param.Value = _Type;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@AllowTax", SqlDbType.Bit);
                param.Value = _AllowTax;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@AllowFree", SqlDbType.Bit);
                param.Value = _AllowFree;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CalcAmt", SqlDbType.Bit);
                param.Value = _CalcAmt;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@StkChecking", SqlDbType.Bit);
                param.Value = _StkChecking;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@PrintPrev", SqlDbType.Bit);
                param.Value = _PrintPrev;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@ShowPurRate", SqlDbType.Bit);
                param.Value = _ShowPurRate;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CalcRatePer", SqlDbType.Bit);
                param.Value = _CalcRatePer;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@ShowSalMan", SqlDbType.Bit);
                param.Value = _ShowSalMan;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@IncDecValue", SqlDbType.Bit);
                param.Value = _IncDecValue;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@WtColumn", SqlDbType.Bit);
                param.Value = _WtColumn;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DtWiseBillNo", SqlDbType.Bit);
                param.Value = _DtWiseBillNo;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@RndOff", SqlDbType.Bit);
                param.Value = _RndOff;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@AutoGenCode", SqlDbType.Bit);
                param.Value = _AutoGenCode;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@AutoBackUp", SqlDbType.Bit);
                param.Value = _AutoBackUp;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DefaultFocus", SqlDbType.VarChar, 50);
                param.Value = _DefaultFocus;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Rate1", SqlDbType.Bit);
                param.Value = _Rate1;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Rate2", SqlDbType.Bit);
                param.Value = _Rate2;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Rate3", SqlDbType.Bit);
                param.Value = _Rate3;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Rate4", SqlDbType.Bit);
                param.Value = _Rate4;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@None", SqlDbType.Bit);
                param.Value = _None;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@AutoMasterCode", SqlDbType.Bit);
                param.Value = _AutoMasterCode;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@SingleRate", SqlDbType.Bit);
                param.Value = _SingleRate;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DefaultTaxId", SqlDbType.Int);
                param.Value = _DefaultTaxId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DefaultCatId", SqlDbType.Int);
                param.Value = _DefaultCatId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@AllowExpiryDt", SqlDbType.Bit);
                param.Value = _AllowExpiryDt;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@RateEnter", SqlDbType.Bit);
                param.Value = _RateEnter;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CSTTaxId", SqlDbType.Int);
                param.Value = _CSTTaxId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DefaultBookId", SqlDbType.Int);
                param.Value = _DefaultBookId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@PackDet", SqlDbType.Bit);
                param.Value = _PackDet;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TaxPattern", SqlDbType.Bit);
                param.Value = _TaxPattern;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@AllowMRP", SqlDbType.Bit);
                param.Value = _AllowMRP;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@AllowSize", SqlDbType.Bit);
                param.Value = _AllowSize;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@FromQuot", SqlDbType.Bit);
                param.Value = _FromQuot;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@RndOffPs", SqlDbType.Bit);
                param.Value = _RndOffPs;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@AllowUpcCode", SqlDbType.Bit);
                param.Value = _AllowUpcCode ;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@RateLock", SqlDbType.Bit);
                param.Value = _RateLock;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@AllowDesc", SqlDbType.Bit);
                param.Value = _AllowDesc;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@AllowUnit", SqlDbType.Bit);
                param.Value = _AllowUnit;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@stockpoint", SqlDbType.Char);
                param.Value = _Stockpoint;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@MultiSalRate", SqlDbType.Bit);
                param.Value = _MultiSalRate;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@AllowPrint", SqlDbType.Bit);
                param.Value = _AllowPrint;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@IsAutoSaleStk", SqlDbType.Bit);
                param.Value = _IsAutoSaleStk;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@IsAutoItemSelect", SqlDbType.Bit);
                param.Value = _IsAutoItemSelect;
                Cmd.Parameters.Add(param);
                
                param = new SqlParameter("@DiscSharing", SqlDbType.Bit);
                param.Value = _DiscSharing;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CustRateType", SqlDbType.Bit);
                param.Value = _CustRateType;
                Cmd.Parameters.Add(param);     

                
                //param = new SqlParameter("@DetStr", SqlDbType.Text);
                //param.Value = DetStr;
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

        # endregion


        public bool FetchRecord(string FormType)
        {
            SqlConnection Con = new SqlConnection(Common.ConStr);
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_Config_Sal", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@FormType", SqlDbType.Char, 5);
            param.Value = FormType;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            SqlDataReader rd = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (rd.Read())
            {

                _DocId = (int)rd.GetValue(rd.GetOrdinal("DocId"));
                _FormType = (string)rd.GetValue(rd.GetOrdinal("FormType"));
                _Printermode = (bool)rd.GetValue(rd.GetOrdinal("Printermode"));
                _PrnModelId = (byte)rd.GetValue(rd.GetOrdinal("PrnModelId"));
                _PrnModel = (string)rd.GetValue(rd.GetOrdinal("PrnModel"));

                _NoOfCopy = (byte)rd.GetValue(rd.GetOrdinal("NoOfCopy"));
                _BarcodeType = (string)rd.GetValue(rd.GetOrdinal("BarcodeType"));
                _BPrnModelId = (byte)rd.GetValue(rd.GetOrdinal("BPrnModelId"));
                _QtyDigit = (string)rd.GetValue(rd.GetOrdinal("QtyDigit"));

                _GrnMessage = (string)rd.GetValue(rd.GetOrdinal("GrnMessage"));
                _PrnMessage = (string)rd.GetValue(rd.GetOrdinal("PrnMessage"));

                _SalChargeCaption1 = (string)rd.GetValue(rd.GetOrdinal("SalChargeCaption1"));
                _SalChargeCaption2 = (string)rd.GetValue(rd.GetOrdinal("SalChargeCaption2"));


                _SalCharge1PostId = (int)rd.GetValue(rd.GetOrdinal("SalCharge1PostId"));
                _SalCharge2PostId = (int)rd.GetValue(rd.GetOrdinal("SalCharge2PostId"));


                _TLeft1 = (string)rd.GetValue(rd.GetOrdinal("TLeft1"));
                _TLeft2 = (string)rd.GetValue(rd.GetOrdinal("TLeft2"));
                _TLeft3 = (string)rd.GetValue(rd.GetOrdinal("TLeft3"));

                _TLeft4 = (string)rd.GetValue(rd.GetOrdinal("TLeft4"));
                _TLeft5 = (string)rd.GetValue(rd.GetOrdinal("TLeft5"));
                _TRight1 = (string)rd.GetValue(rd.GetOrdinal("TRight1"));
                _TRight2 = (string)rd.GetValue(rd.GetOrdinal("TRight2"));

                _TRight3 = (string)rd.GetValue(rd.GetOrdinal("TRight3"));

                _TRight4 = (string)rd.GetValue(rd.GetOrdinal("TRight4"));
                _TRight5 = (string)rd.GetValue(rd.GetOrdinal("TRight5"));
                _TMid1 = (string)rd.GetValue(rd.GetOrdinal("TMid1"));
                _TMid2 = (string)rd.GetValue(rd.GetOrdinal("TMid2"));
                _TMid3 = (string)rd.GetValue(rd.GetOrdinal("TMid3"));
                _TMid4 = (string)rd.GetValue(rd.GetOrdinal("TMid4"));
                _TMid5 = (string)rd.GetValue(rd.GetOrdinal("TMid5"));
                _PrintConfirmation = (bool)rd.GetValue(rd.GetOrdinal("PrintConformation"));
                _SalRecAmt = (bool)rd.GetValue(rd.GetOrdinal("SalRecAmt"));
                _AutoCustRate = (bool)rd.GetValue(rd.GetOrdinal("AutoCustRate"));
                _DefaultSalRate = (bool)rd.GetValue(rd.GetOrdinal("DefaultSalRate"));
                _DwnColumn = (string)rd.GetValue(rd.GetOrdinal("DwnColumn"));
                _NxtColumn = (string)rd.GetValue(rd.GetOrdinal("NxtColumn"));
                _WtItem = (bool)rd.GetValue(rd.GetOrdinal("WtItem"));
                _AllowDisc = (bool)rd.GetValue(rd.GetOrdinal("AllowDisc"));
                _SalDown1 = (string)rd.GetValue(rd.GetOrdinal("DwnColumn1"));
                _HeaderName1 = (string)rd.GetValue(rd.GetOrdinal("HeaderName1"));
                _HeaderName2 = (string)rd.GetValue(rd.GetOrdinal("HeaderName2"));
                _Type = (bool)rd.GetValue(rd.GetOrdinal("Type"));
                _AllowTax = (bool)rd.GetValue(rd.GetOrdinal("AllowTax"));
                _AllowFree = (bool)rd.GetValue(rd.GetOrdinal("AllowFree"));
                _CalcAmt = (bool)rd.GetValue(rd.GetOrdinal("CalcAmt"));
                _StkChecking = (bool)rd.GetValue(rd.GetOrdinal("StkChecking"));
                _PrintPrev = (bool)rd.GetValue(rd.GetOrdinal("PrintPrev"));
                _ShowPurRate = (bool)rd.GetValue(rd.GetOrdinal("ShowPurRate"));
                _CalcRatePer = (bool)rd.GetValue(rd.GetOrdinal("CalcRatePer"));
                _ShowSalMan = (bool)rd.GetValue(rd.GetOrdinal("ShowSalMan"));
                _IncDecValue = (bool)rd.GetValue(rd.GetOrdinal("IncDecValue"));
                _WtColumn = (bool)rd.GetValue(rd.GetOrdinal("WtColumn"));
                _DtWiseBillNo = (bool)rd.GetValue(rd.GetOrdinal("DtWiseBillNo"));
                _RndOff = (bool)rd.GetValue(rd.GetOrdinal("RndOff"));
                _AutoGenCode = (bool)rd.GetValue(rd.GetOrdinal("AutoGenCode"));
                _AutoBackUp = (bool)rd.GetValue(rd.GetOrdinal("AutoBackUp"));
                _DefaultFocus = (string)rd.GetValue(rd.GetOrdinal("DefaultFocus"));
                _Rate1 = (bool)rd.GetValue(rd.GetOrdinal("Rate1"));
                _Rate2 = (bool)rd.GetValue(rd.GetOrdinal("Rate2"));
                _Rate3 = (bool)rd.GetValue(rd.GetOrdinal("Rate3"));
                _Rate4 = (bool)rd.GetValue(rd.GetOrdinal("Rate4"));
                _None = (bool)rd.GetValue(rd.GetOrdinal("None"));
                _AutoMasterCode = (bool)rd.GetValue(rd.GetOrdinal("AutoMasterCode"));
                _SingleRate = (bool)rd.GetValue(rd.GetOrdinal("SingleRate"));
                _DefaultTaxId = (int)rd.GetValue(rd.GetOrdinal("DefaultTaxId"));
                _DefaultCatId = (int)rd.GetValue(rd.GetOrdinal("DefaultCatId"));
                _AllowExpiryDt = (bool)rd.GetValue(rd.GetOrdinal("AllowExpiryDt"));
                _RateEnter = (bool)rd.GetValue(rd.GetOrdinal("RateEnter"));
                _CSTTaxId = (int)rd.GetValue(rd.GetOrdinal("CSTTaxId"));
                _DefaultBookId = (int)rd.GetValue(rd.GetOrdinal("DefaultBookId"));
                _PackDet = (bool)rd.GetValue(rd.GetOrdinal("PackDet"));
                _TaxPattern = (bool)rd.GetValue(rd.GetOrdinal("TaxPattern"));
                _AllowMRP = (bool)rd.GetValue(rd.GetOrdinal("AllowMRP"));
                _AllowSize = (bool)rd.GetValue(rd.GetOrdinal("AllowSize"));
                _FromQuot = (bool)rd.GetValue(rd.GetOrdinal("FromQuot"));
                _RndOffPs = (bool)rd.GetValue(rd.GetOrdinal("RndOffPs"));
                _AllowUpcCode = (bool)rd.GetValue(rd.GetOrdinal("AllowUpcCode"));
                _RateLock = (bool)rd.GetValue(rd.GetOrdinal("RateLock"));
                _AllowUnit = (bool)rd.GetValue(rd.GetOrdinal("AllowUnit"));
                _AllowDesc = (bool)rd.GetValue(rd.GetOrdinal("AllowDesc"));
                _Stockpoint = (string)rd.GetValue(rd.GetOrdinal("stockpoint"));
                _MultiSalRate = (bool)rd.GetValue(rd.GetOrdinal("MultiSalRate"));
                _AllowPrint = (bool)rd.GetValue(rd.GetOrdinal("AllowPrint"));
                _IsAutoSaleStk = (bool)rd.GetValue(rd.GetOrdinal("IsAutoSaleStk"));
                _IsAutoItemSelect = (bool)rd.GetValue(rd.GetOrdinal("IsAutoItemSelect"));
                _DiscSharing = (bool)rd.GetValue(rd.GetOrdinal("DiscSharing"));
                _CustRateType = (bool)rd.GetValue(rd.GetOrdinal("CustRateType"));

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

        public DataTable LedgerSource(string DocType)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Acc_Qry_LedgerSelection", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@DocType", SqlDbType.VarChar, 5);
            param.Value = DocType;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
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
            tmp.Add(CommonView.GetGridViewColumn("Balance", "Balance", 100, 4, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
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
            tmp.Add(CommonView.GetGridViewBoolColumn("DefaultRate", "DefaultRate", 120, 4));
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 5));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 6));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

        public DataTable CategorySource()
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
        public DataTable TaxSource()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_Tax", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "Tax";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }
        public DataTable Config_DefaultFocus(string FormType)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_Config_DefaultFocus", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@DocTYpe", SqlDbType.Char, 3);
            MyParam.Value = FormType;
            MyCmd.Parameters.Add(MyParam);

            //MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            //MyParam.Value = Common.CId;
            //MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "DefaultFocus";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
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
        public DataTable GetExpiryItem_Source()
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("GetExpityItem", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "ExpiryItem";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }
        public DataTable Book_Source()
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_DefaultBookDet", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;          

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Book";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }
        public int Book_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();

            tmp.Add(CommonView.GetGridViewColumn("BookId", "BookId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Book", "Book", 100, 2, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("StartBillNo", "StartBillNo", 0, 3));
            tmp.Add(CommonView.GetGridViewBoolColumn("Closed", "Closed", 50, 4, true));


            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        public void UpdateConfigSettings()
        {
            try
            {
                SqlConnection Con = new SqlConnection(Common.ConStr);
                SqlDataAdapter Da = new SqlDataAdapter();
                Con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("Qry_GenConfigUpdate", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@CompId", SqlDbType.TinyInt);
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
