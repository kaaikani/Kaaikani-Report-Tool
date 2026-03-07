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
    public class MasterDB
    {
        public MasterDB()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        # region "Properties"

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

        string _AcCode;
        public string AcCode
        {
            get
            {
                return _AcCode;
            }
            set
            {
                _AcCode = value;
            }
        }

        string _AccName;
        public string AccName
        {
            get
            {
                return _AccName;
            }
            set
            {
                _AccName = value;
            }
        }

        bool _OtherState;
        public bool OtherState
        {
            get
            {
                return _OtherState;
            }
            set
            {
                _OtherState = value;
            }

        }
        bool _AllComp;
        public bool AllComp
        {
            get
            {
                return _AllComp;
            }
            set
            {
                _AllComp = value;
            }

        }

        string _Add1;
        public string Add1
        {
            get
            {
                return _Add1;
            }
            set
            {
                _Add1 = value;
            }
        }

        string _Add2;
        public string Add2
        {
            get
            {
                return _Add2;
            }
            set
            {
                _Add2 = value;
            }
        }

        string _Add3;
        public string Add3
        {
            get
            {
                return _Add3;
            }
            set
            {
                _Add3 = value;
            }
        }

        string _City;
        public string City
        {
            get
            {
                return _City;
            }
            set
            {
                _City = value;
            }
        }

        string _Pincode;
        public string Pincode
        {
            get
            {
                return _Pincode;
            }
            set
            {
                _Pincode = value;
            }
        }

        int _AreaId;
        public int AreaId
        {
            get
            {
                return _AreaId;
            }
            set
            {
                _AreaId = value;
            }

        }

        string _Ph1;
        public string Ph1
        {
            get
            {
                return _Ph1;
            }
            set
            {
                _Ph1 = value;
            }
        }

        string _Ph2;
        public string Ph2
        {
            get
            {
                return _Ph2;
            }
            set
            {
                _Ph2 = value;
            }
        }

        string _MType;
        public string MType
        {
            get
            {
                return _MType;
            }
            set
            {
                _MType = value;
            }
        }

        string _Cell;
        public string Cell
        {
            get
            {
                return _Cell;
            }
            set
            {
                _Cell = value;
            }
        }
        string _TIN;
        public string TIN
        {
            get
            {
                return _TIN;
            }
            set
            {
                _TIN = value;
            }
        }

        string _CST;
        public string CST
        {
            get
            {
                return _CST;
            }
            set
            {
                _CST = value;
            }
        }

        string _Contactperson;
        public string Contactperson
        {
            get
            {
                return _Contactperson;
            }
            set
            {
                _Contactperson = value;
            }
        }

        string _Contactcell;
        public string Contactcell
        {
            get
            {
                return _Contactcell;
            }
            set
            {
                _Contactcell = value;
            }
        }

        string _EMail;
        public string EMail
        {
            get
            {
                return _EMail;
            }
            set
            {
                _EMail = value;
            }
        }

        string _Fax;
        public string Fax
        {
            get
            {
                return _Fax;
            }
            set
            {
                _Fax = value;
            }

        }

        string _URL;
        public string URL
        {
            get
            {
                return _URL;
            }
            set
            {
                _URL = value;
            }

        }
        decimal _OpBal;
        public decimal OpBal
        {
            get
            {
                return _OpBal;
            }
            set
            {
                _OpBal = value;
            }

        }

        string _Drcr;
        public string Drcr
        {
            get
            {
                return _Drcr;
            }
            set
            {
                _Drcr = value;
            }

        }

        short _CrLimitDays;
        public short CrLimitDays
        {
            get
            {
                return _CrLimitDays;
            }
            set
            {
                _CrLimitDays = value;
            }

        }
        decimal _CrLimitAmt;
        public decimal CrLimitAmt
        {
            get
            {
                return _CrLimitAmt;
            }
            set
            {
                _CrLimitAmt = value;
            }

        }

        int _GrpId;
        public int GrpId
        {
            get
            {
                return _GrpId;
            }
            set
            {
                _GrpId = value;
            }
        }
        int _SubGrpId1;
        public int SubGrpId1
        {
            get
            {
                return _SubGrpId1;
            }
            set
            {
                _SubGrpId1 = value;
            }
        }
        int _SubGrpId2;
        public int SubGrpId2
        {
            get
            {
                return _SubGrpId2;
            }
            set
            {
                _SubGrpId2 = value;
            }
        }
        byte _BlockId;
        public byte BlockId
        {
            get
            {
                return _BlockId;
            }
            set
            {
                _BlockId = value;
            }
        }

        decimal _DepnVal;
        public decimal DepnVal
        {
            get
            {
                return _DepnVal;
            }
            set
            {
                _DepnVal = value;
            }

        }

        byte _BudgetId;
        public byte BudgetId
        {
            get
            {
                return _BudgetId;
            }
            set
            {
                _BudgetId = value;
            }
        }
        int _TransPortId;
        public int TransPortId
        {
            get
            {
                return _TransPortId;
            }
            set
            {
                _TransPortId = value;
            }
        }

        int _RateTypeId;
        public int RateTypeId
        {
            get
            {
                return _RateTypeId;
            }
            set
            {
                _RateTypeId = value;
            }
        }

        bool _Hide;
        public bool Hide
        {
            get
            {
                return _Hide;
            }
            set
            {
                _Hide = value;
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

        byte _Compid;
        public byte Compid
        {
            get
            {
                return _Compid;
            }
            set
            {
                _Compid = value;
            }
        }

       
        # endregion

        # region "Detail"
        public DataTable Ledgercode_cheking()
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
            MyParam.Value = 1;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@compId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);


            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Ledgercode";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public DataTable GroupSource()
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Acc_Qry_GrpSelect", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@compId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "GroupSelect";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public int GroupSource_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("GrpId", "GrpId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("GroupName", "GroupName", 150, 1, true));
            tmp.Add(CommonView.GetGridViewColumn("BsGrp", "BsGrp", 50, 2, true));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

        public DataTable MobileCustomerSource(string cell)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_MobileAchd", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Cell", SqlDbType.VarChar);
            MyParam.Value = cell;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@compId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_MobileAchd";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public DataTable SubGrp1_Source()
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Acc_Qry_SubGrp1Fill", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            
            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "SubGrp1Fill";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public int SubGrp1_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("SubGrpId1", "SubGrpId1", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("SubGroupName", "SubGroupName", 250, 2, true));
            tmp.Add(CommonView.GetGridViewColumn("GrpId", "GrpId", 0, 3));
            
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

        public DataTable SubGrp2_Source(int SubGrpId1)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Acc_Qry_SubGrp2Fill", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@SubGrpId1", SqlDbType.Int);
            MyParam.Value = SubGrpId1;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "SubGrp1Fill";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public int SubGrp2_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("SubGrpId2", "SubGrpId2", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("SubGroupName", "SubGroupName", 250, 2, true));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        # endregion
  
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
                Cmd = new SqlCommand("Acc_AchdSp", Con);
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@Mode", SqlDbType.TinyInt);
                param.Value = Modeval;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@AccId", SqlDbType.Int);
                param.Value = _AccId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@AcCode", SqlDbType.VarChar, 6);
                param.Value = _AcCode.Replace("'", "''");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@AccName", SqlDbType.NVarChar, 100);
                param.Value = _AccName.Replace("'", "''");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@AllComp", SqlDbType.Bit);
                param.Value = (_AllComp == true ? 1 : 0);
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@OtherState", SqlDbType.Bit);
                param.Value = (_OtherState == true ? 1 : 0);
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Add1", SqlDbType.NVarChar, 100);
                param.Value = _Add1.Replace("'", "''");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Add2", SqlDbType.NVarChar, 100);
                param.Value = _Add2.Replace("'", "''");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Add3", SqlDbType.NVarChar, 100);
                param.Value = _Add3.Replace("'", "''");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@City", SqlDbType.NVarChar, 100);
                param.Value = _City.Replace("'", "''");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@AreaId", SqlDbType.Int);
                param.Value = _AreaId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Pincode", SqlDbType.VarChar, 15);
                param.Value = _Pincode.Replace("'", "''");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Ph1", SqlDbType.VarChar, 20);
                param.Value = _Ph1.Replace("'", "''");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Ph2", SqlDbType.VarChar, 20);
                param.Value = _Ph2.Replace("'", "''");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Cell", SqlDbType.VarChar, 14);
                param.Value = _Cell.Replace("'", "''");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TIN", SqlDbType.VarChar, 25);
                param.Value = _TIN.Replace("'", "''");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CST", SqlDbType.VarChar, 25);
                param.Value = _CST.Replace("'", "''");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Contactperson", SqlDbType.VarChar, 50);
                param.Value = _Contactperson.Replace("'", "''");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Contactcell", SqlDbType.VarChar, 50);
                param.Value = _Contactcell.Replace("'", "''");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@EMail", SqlDbType.VarChar, 60);
                param.Value = _EMail.Replace("'", "''");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Fax", SqlDbType.VarChar, 30);
                param.Value = _Fax.Replace("'", "''");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@URL", SqlDbType.VarChar, 40);
                param.Value = _URL.Replace("'", "''");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@OpBal", SqlDbType.Decimal);
                param.Value = _OpBal;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Drcr", SqlDbType.Char, 1);
                param.Value = _Drcr;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CrLimitDays", SqlDbType.SmallInt);
                param.Value = _CrLimitDays;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CrLimitAmt", SqlDbType.Decimal);
                param.Value = _CrLimitAmt;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@GrpId", SqlDbType.Int);
                param.Value = _GrpId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@SubGrpId1", SqlDbType.Int);
                param.Value = _SubGrpId1;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@SubGrpId2", SqlDbType.Int);
                param.Value = _SubGrpId2;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@BlockId", SqlDbType.TinyInt);
                param.Value = _BlockId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DepnVal", SqlDbType.Decimal);
                param.Value = _DepnVal;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@BudgetId", SqlDbType.TinyInt);
                param.Value = _BudgetId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Hide", SqlDbType.Bit);
                param.Value = (_Hide == true ? 1 : 0);
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TransPortId", SqlDbType.Int);
                param.Value = _TransPortId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@RateTypeId", SqlDbType.Int);
                param.Value = _RateTypeId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.TinyInt);
                param.Value = Common.UserId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Compid", SqlDbType.TinyInt);
                param.Value = Common.CId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@MasDbName", SqlDbType.VarChar,20);
                param.Value = Common.MasDataBase;
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




        public DataTable PtyAddress(int AccId)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_PtyAddress", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@AccId", SqlDbType.Int);
            MyParam.Value = AccId;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@compId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_PtyAddress";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public DataTable RateTypeSelect_Source(int RateTypeId)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_PartyRateType", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@RateTypeId", SqlDbType.Int);
            param.Value = RateTypeId;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@compid", SqlDbType.TinyInt);
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
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 3, false, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 4, false, DataGridViewContentAlignment.MiddleLeft));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
 
        # region "Fetch Section"
      
        public bool FetchRecord(int Id)
        {
            SqlConnection Con = new SqlConnection(Common.ConStr);
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Acc_Qry_Achd", Con);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("@AccId", SqlDbType.Int);
            param.Value = Id;
            Cmd.Parameters.Add(param);
            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);
            SqlDataReader rd = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (rd.Read())
            {

                _AccId = (int)rd.GetValue(rd.GetOrdinal("AccId"));
                _AcCode = (string)rd.GetValue(rd.GetOrdinal("AcCode"));
                _AccName = (string)rd.GetValue(rd.GetOrdinal("Ledger"));
                _OtherState = (bool)rd.GetValue(rd.GetOrdinal("OtherState"));
                _AllComp = (bool)rd.GetValue(rd.GetOrdinal("AllComp"));
                _GrpId = (int)rd.GetValue(rd.GetOrdinal("GrpID"));
                _SubGrpId1 = (int)rd.GetValue(rd.GetOrdinal("SubGrpId1"));
                _SubGrpId2 = (int)rd.GetValue(rd.GetOrdinal("SubGrpId2"));
                _Add1 = (string)rd.GetValue(rd.GetOrdinal("Add1"));
                _Add2 = (string)rd.GetValue(rd.GetOrdinal("Add2"));
                _Add3 = (string)rd.GetValue(rd.GetOrdinal("Add3"));
                _City = (string)rd.GetValue(rd.GetOrdinal("City"));
                _AreaId = (int)rd.GetValue(rd.GetOrdinal("AreaId"));
                _Pincode = (string)rd.GetValue(rd.GetOrdinal("Pincode"));
                _Ph1 = (string)rd.GetValue(rd.GetOrdinal("Ph1"));
                _Ph2 = (string)rd.GetValue(rd.GetOrdinal("Ph2"));
                _Cell = (string)rd.GetValue(rd.GetOrdinal("Cell"));
                _TIN = (string)rd.GetValue(rd.GetOrdinal("TIN"));
                _CST = (string)rd.GetValue(rd.GetOrdinal("CST"));
                _Contactperson = (string)rd.GetValue(rd.GetOrdinal("Contactperson"));
                _Contactcell = (string)rd.GetValue(rd.GetOrdinal("Contactcell"));
                _EMail = (string)rd.GetValue(rd.GetOrdinal("EMail"));
                _Fax = (string)rd.GetValue(rd.GetOrdinal("Fax"));
                _URL = (string)rd.GetValue(rd.GetOrdinal("URL"));
                _OpBal = (decimal)rd.GetValue(rd.GetOrdinal("OpBal"));
                _Drcr = (string)rd.GetValue(rd.GetOrdinal("Drcr"));
                _CrLimitDays = (short)rd.GetValue(rd.GetOrdinal("CrLimitDays"));
                _CrLimitAmt = (decimal)rd.GetValue(rd.GetOrdinal("CrLimitAmt"));
                _BlockId = (byte)rd.GetValue(rd.GetOrdinal("BlockId"));
                _DepnVal = (decimal)rd.GetValue(rd.GetOrdinal("DepnVal"));
                _BudgetId = (byte)rd.GetValue(rd.GetOrdinal("BudgetId"));
                _Hide = (bool)rd.GetValue(rd.GetOrdinal("Hide"));
                _TransPortId = (int)rd.GetValue(rd.GetOrdinal("TransPortId"));
                _RateTypeId = (int)rd.GetValue(rd.GetOrdinal("RateTypeId"));
                _UserId = (byte)rd.GetValue(rd.GetOrdinal("UserId"));
                
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

        # region "Quick "

        public DataTable QuickSubGrp_Source()
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_QuickSubGroup", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;


            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "QuickSubGrp";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }


        #region "For Quick View Record"

        public DataTable Quicknavigate()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Select Top 100 * From Quickvwfn(" + Common.CId + ") where AccId > 0 order by AccId desc", Con);
            Cmd.CommandType = CommandType.Text;

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "navigate";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }


        public void QuickSetViewControl()
        {
            _FilteringValues.Clear();

            _View.FilteringValues = _FilteringValues;
            _View.TableNames = "Quickvwfn(" + Common.CId + ")";
            _View.Fields = "*";
            _View.Conditions = "AccId > 0";
        }

        public int QuickView_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("AccId", "AccId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Ledger", "Name", 120, 2, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("SubGroupName1", "Type", 100, 3, true));
            tmp.Add(CommonView.GetGridViewColumn("Add1", "Address", 120, 4, true,DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Add2", "Address", 150, 5, true));
            tmp.Add(CommonView.GetGridViewColumn("Add3", "Address", 0, 6, true));
            tmp.Add(CommonView.GetGridViewColumn("City", "City", 100, 7, true));
            tmp.Add(CommonView.GetGridViewColumn("TIN", "TIN", 90,8, true));
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 9, true));
            tmp.Add(CommonView.GetGridViewColumn("UserName", "UserName", 0, 10, true));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        public int Search_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("AccId", "AccId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("AcCode", "AcCode", 50, 2, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Ledger", "Ledger", 100, 3, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewBoolColumn("OtherState", "OtherState", 40, 4, true));
            tmp.Add(CommonView.GetGridViewBoolColumn("AllComp", "AllComp", 0, 5, true));
            tmp.Add(CommonView.GetGridViewColumn("GrpId", "GrpId", 0, 6, true));
            tmp.Add(CommonView.GetGridViewColumn("SubGrpId1", "SubGrpId1", 0, 7, true));
            tmp.Add(CommonView.GetGridViewColumn("SubGrpId2", "SubGrpId2", 0, 8, true));
            tmp.Add(CommonView.GetGridViewColumn("OpBal", "OpBal", 80, 9, true));
            tmp.Add(CommonView.GetGridViewColumn("DrCr", "DrCr", 0, 10, true));
            tmp.Add(CommonView.GetGridViewColumn("CrLimitDays", "CrLimitDays", 50, 11, true));


            tmp.Add(CommonView.GetGridViewColumn("CrLimitAmt", "CrLimitAmt", 50, 12, true));
            tmp.Add(CommonView.GetGridViewColumn("Add1", "Address", 80, 13, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Add2", "Address", 80, 14, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Add3", "Address", 0, 15, true, DataGridViewContentAlignment.MiddleLeft, ""));


            tmp.Add(CommonView.GetGridViewColumn("City", "City", 70, 16, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Pincode", "Pincode", 50, 17, true));
            tmp.Add(CommonView.GetGridViewColumn("AreaId", "AreaId", 0, 18, true));
            tmp.Add(CommonView.GetGridViewColumn("Ph1", "Phone", 50, 19, true));


            tmp.Add(CommonView.GetGridViewColumn("Ph2", "Phone", 0, 20, true));
            tmp.Add(CommonView.GetGridViewColumn("Cell", "Cell", 50, 21, true));
            tmp.Add(CommonView.GetGridViewColumn("TIN", "TIN", 70, 22, true));
            tmp.Add(CommonView.GetGridViewColumn("CST", "CST", 70, 23, true));


            tmp.Add(CommonView.GetGridViewColumn("Contactperson", "Contactperson", 60, 24, true));
            tmp.Add(CommonView.GetGridViewColumn("ContactCell", "ContactCell", 50, 25, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("EMail", "EMail", 0, 26, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Fax", "Fax", 0, 27, true));


            tmp.Add(CommonView.GetGridViewColumn("URL", "URL", 0, 28, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewBoolColumn("Hide", "Hide", 0, 29, true));
            tmp.Add(CommonView.GetGridViewColumn("BlockId", "BlockId", 0, 30, true));
            tmp.Add(CommonView.GetGridViewColumn("DepnVal", "DepnVal", 0, 31, true));


            tmp.Add(CommonView.GetGridViewColumn("BudgetId", "BudgetId", 0, 32, true));
            tmp.Add(CommonView.GetGridViewColumn("TransportId", "TransportId", 0, 33, true));
            tmp.Add(CommonView.GetGridViewColumn("Compid", "Compid", 0, 34, true));
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 35, true));




            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

        #endregion
        #endregion

        #region "For View Record"

        public DataTable navigate()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Select Top 100 * From Acc_Achdvwfn(" + Common.CId + ") where AccId > 0 order by AccId desc", Con);
            Cmd.CommandType = CommandType.Text;

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "navigate";
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
        }
        public void SetViewControl()
        {
            _FilteringValues.Clear();

            _View.FilteringValues = _FilteringValues;
            _View.TableNames = "Acc_Achdvwfn(" + Common.CId + ")";
            _View.Fields = "*";
            _View.Conditions = "AccId > 0";
        }

        public int View_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("AccId", "AccId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("AcCode", "AcCode", 80, 2, true, DataGridViewContentAlignment.MiddleLeft,"",DataGridViewAutoSizeColumnMode.None ));
            tmp.Add(CommonView.GetGridViewColumn("Ledger", "Ledger", 80, 3, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("OpBal", "OpBal", 80, 4, true, DataGridViewContentAlignment.MiddleRight, "#####0.00", DataGridViewAutoSizeColumnMode.None));
            tmp.Add(CommonView.GetGridViewColumn("DrCr", "DrCr", 70, 5, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.None));
            tmp.Add(CommonView.GetGridViewBoolColumn("AllComp", "AllCompany", 70, 6, true));
            tmp.Add(CommonView.GetGridViewBoolColumn("Hide", "Hide", 60, 7, true));
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 8, true));
            tmp.Add(CommonView.GetGridViewColumn("UserName", "UserName", 0,9, true));
            
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
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
          #endregion

        # region "Detail"
        public DataTable QuickPartyDet_Source(int SubGrpId1)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_QuickParty", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@SubGrpId1", SqlDbType.Int);
            param.Value = SubGrpId1;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "Party";
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
        public int QuickParty_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            Common.GenConfig = Common.comobj.Config_Source("G");

            tmp.Add(CommonView.GetGridViewColumn("AccId", "AccId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Accode", "Accode", 80, 2, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Ledger", "Ledger", 150, 3, false, DataGridViewContentAlignment.MiddleLeft, ""));           
            tmp.Add(CommonView.GetGridViewColumn("Credit", "Credit", 90, 4, false, DataGridViewContentAlignment.MiddleRight, "###0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Debit", "Debit", 90, 5, false, DataGridViewContentAlignment.MiddleRight, "###0.00"));           
            tmp.Add(CommonView.GetGridViewColumn("Add1", "Add1", 150, 6, false, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Add2", "Add2", 150, 7, false, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Add3", "Add3", 100, 8, false, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("City", "City", 90, 9, false, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("PinCode", "PinCode", 90, 10, false, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Tin", "Tin", 90, 11, false, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("CST", "CST", 90, 12, false, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Ph1", "Phone", 90, 13, false, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Email", "Email", 90, 14, false, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Cell", "Cell", 90, 15, false, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Area", "Area", 90, 16, false, DataGridViewContentAlignment.MiddleLeft, ""));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        #endregion
        public DataTable QuickParty_Source()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_Acc_Party", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "Party";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();

            return Tbl;
        }
    }
}
