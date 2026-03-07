using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using GridStructures;
using DBAccess;
using AccountsDB;

namespace AccountsDB
{
    /// <summary>
    /// Summary description for PartyDB.
    /// </summary>
    public class ReceiptPendingDB
    {
        public ReceiptPendingDB()
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
        int _RecId;
        public int RecId
        {
            get
            {
                return _RecId;
            }
            set
            {
                _RecId = value;
            }
        }
        short _AcYrId;
        public short AcYrId
        {
            get
            {
                return _AcYrId;
            }
            set
            {
                _AcYrId = value;
            }
        }
        int _DocNo;
        public int DocNo
        {
            get
            {
                return _DocNo;
            }
            set
            {
                _DocNo = value;
            }
        }

        int _RecNo;
        public int RecNo
        {
            get
            {
                return _RecNo;
            }
            set
            {
                _RecNo = value;
            }
        }
        DateTime _DocDt;
        public DateTime DocDt
        {
            get
            {
                return _DocDt;
            }
            set
            {
                _DocDt = value;
            }
        }

        DateTime _RecDt;
        public DateTime RecDt
        {
            get
            {
                return _RecDt;
            }
            set
            {
                _RecDt = value;
            }
        }

        string _Cash;
        public string Cash
        {
            get
            {
                return _Cash;
            }
            set
            {
                _Cash = value;
            }
        }

        short _RefTypeId;
        public short RefTypeId
        {
            get
            {
                return _RefTypeId;
            }
            set
            {
                _RefTypeId = value;
            }
        }

        string _AgainstType;
        public string AgainstType
        {
            get
            {
                return _AgainstType;
            }
            set
            {
                _AgainstType = value;
            }
        }
        int _PtyId;
        public int PtyId
        {
            get
            {
                return _PtyId;
            }
            set
            {
                _PtyId = value;
            }
        }
        int _LedgerAccId;
        public int LedgerAccId
        {
            get
            {
                return _LedgerAccId;
            }
            set
            {
                _LedgerAccId = value;
            }
        }
        
        string _Chqno;
        public string Chqno
        {
            get
            {
                return _Chqno;
            }
            set
            {
                _Chqno = value;
            }
        }

        DateTime _ChqDt;
        public DateTime ChqDt
        {
            get
            {
                return _ChqDt;
            }
            set
            {
                _ChqDt = value;
            }
        }
        string _chqType;
        public string chqType
        {
            get
            {
                return _chqType;
            }
            set
            {
                _chqType = value;
            }
        }
        decimal _CashDisc;
        public decimal CashDisc
        {
            get
            {
                return _CashDisc;
            }
            set
            {
                _CashDisc = value;
            }
        }
        decimal _Commission;
        public decimal Commission
        {
            get
            {
                return _Commission;
            }
            set
            {
                _Commission = value;
            }
        }
        decimal _NetAmt;
        public decimal NetAmt
        {
            get
            {
                return _NetAmt;
            }
            set
            {
                _NetAmt = value;
            }
        }
        string _Narration1;
        public string Narration1
        {
            get
            {
                return _Narration1;
            }
            set
            {
                _Narration1 = value;
            }
        }
        string _Narration2;
        public string Narration2
        {
            get
            {
                return _Narration2;
            }
            set
            {
                _Narration2 = value;
            }
        }
        string _CashRecNo;
        public string CashRecNo
        {
            get
            {
                return _CashRecNo;
            }
            set
            {
                _CashRecNo = value;
            }
        }
        bool _Est;
        public bool Est
        {
            get
            {
                return _Est;
            }
            set
            {
                _Est = value;
            }
        }

        int _EstId;
        public int EstId
        {
            get
            {
                return _EstId;
            }
            set
            {
                _EstId = value;
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
        string  _UserName;
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
        DataTable _OutStandingAdjustDet;
        public DataTable OutStandingAdjustDet
        {
            get
            {
                return _OutStandingAdjustDet;
            }
            set
            {
                _OutStandingAdjustDet = value;
            }
        }

              
        # endregion

        # region "Save"
        public void SaveFunction(Saving.SaveType Mode)
        {
            //int code;
            DataSet Ds = new DataSet();
            string DetStr;
            Ds.Tables.Add(OutStandingAdjustDet);
           
            DetStr = Ds.GetXml();
            DetStr = DetStr.Replace("'", "''");
            DetStr = DetStr.Replace("true", "1");
            DetStr = DetStr.Replace("false", "0");
            if (DetStr.IndexOf("T00:00:00") != -1)
                DetStr = DetStr.Replace(DetStr.Substring(DetStr.IndexOf("T00:00:00"), 15), "");
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
                Cmd = new SqlCommand("OutStandingAdjustmentSp", Con);
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@Mode", SqlDbType.TinyInt);
                param.Value = Modeval;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DocId", SqlDbType.Int);
                param.Value = _DocId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@AcYrId", SqlDbType.SmallInt);
                param.Value = _AcYrId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DocNo", SqlDbType.Int);
                param.Value = _DocNo;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DocDt", SqlDbType.DateTime);
                param.Value = _DocDt.ToString("dd/MMM/yyyy");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@AgainstType", SqlDbType.Char, 1);
                param.Value = _AgainstType;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@PtyId", SqlDbType.Int);
                param.Value = _PtyId;
                Cmd.Parameters.Add(param);
                                
                param = new SqlParameter("@LedgerAccId", SqlDbType.Int);
                param.Value = _LedgerAccId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Cash", SqlDbType.Char,2);
                param.Value = _Cash;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@ChqNo", SqlDbType.VarChar, 20);
                param.Value = _Chqno;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@ChqDt", SqlDbType.DateTime);
                param.Value = _ChqDt.ToString("dd/MMM/yyyy");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@chqType", SqlDbType.Char, 1);
                param.Value = _chqType;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CashDisc", SqlDbType.Decimal);
                param.Value = _CashDisc;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Commission", SqlDbType.Decimal);
                param.Value = _Commission;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@NetAmt", SqlDbType.Decimal);
                param.Value = _NetAmt;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Narration1", SqlDbType.VarChar, 50);
                param.Value = _Narration1;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Narration2", SqlDbType.VarChar, 50);
                param.Value = _Narration2;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@RecId", SqlDbType.Int);
                param.Value = _RecId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.TinyInt);
                param.Value = Common.UserId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CompId", SqlDbType.TinyInt);
                param.Value = Common.CId;
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

        public void ReceiptSaveFunction(Saving.SaveType Mode)
        {
            //int code;
            DataSet Ds = new DataSet();
            string DetStr;
            Ds.Tables.Add(OutStandingAdjustDet);

            DetStr = Ds.GetXml();
            DetStr = DetStr.Replace("'", "''");
            DetStr = DetStr.Replace("true", "1");
            DetStr = DetStr.Replace("false", "0");
            if (DetStr.IndexOf("T00:00:00") != -1)
                DetStr = DetStr.Replace(DetStr.Substring(DetStr.IndexOf("T00:00:00"), 15), "");
            Ds.Tables.Clear();
            Ds.Dispose();
            int Modeval = 0;
         
            if (Mode == Saving.SaveType.Edit)
                Modeval = 2;
           

            try
            {
                SqlConnection Con = new SqlConnection(Common.ConStr);
                SqlDataAdapter Da = new SqlDataAdapter();
                Con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("ReceiptSp", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@Mode", SqlDbType.TinyInt);
                param.Value = Modeval;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@RecId", SqlDbType.Int);
                param.Value = _RecId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@AcYrId", SqlDbType.SmallInt);
                param.Value = _AcYrId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@RecNo", SqlDbType.Int);
                param.Value = _RecNo;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@RecDt", SqlDbType.DateTime);
                param.Value = _RecDt.ToString("dd/MMM/yyyy");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@RefTypeId", SqlDbType.SmallInt);
                param.Value = _RefTypeId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@AgainstType", SqlDbType.Char, 1);
                param.Value = _AgainstType;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@PtyId", SqlDbType.Int);
                param.Value = _PtyId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@LedgerAccId", SqlDbType.Int);
                param.Value = _LedgerAccId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Cash", SqlDbType.Char, 2);
                param.Value = _Cash;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@ChqNo", SqlDbType.VarChar, 20);
                param.Value = _Chqno;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@ChqDt", SqlDbType.DateTime);
                param.Value = _ChqDt.ToString("dd/MMM/yyyy");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@chqType", SqlDbType.Char, 1);
                param.Value = _chqType;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CashDisc", SqlDbType.Decimal);
                param.Value = _CashDisc;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Commission", SqlDbType.Decimal);
                param.Value = _Commission;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@NetAmt", SqlDbType.Decimal);
                param.Value = _NetAmt;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Narration1", SqlDbType.VarChar, 50);
                param.Value = "Adjustment Entry";
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Narration2", SqlDbType.VarChar, 50);
                param.Value = _Narration2;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CashRecNo", SqlDbType.VarChar, 75);
                param.Value = _CashRecNo;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Est", SqlDbType.Bit);
                param.Value = _Est;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@EstId", SqlDbType.Int);
                param.Value = _EstId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.TinyInt);
                param.Value = Common.UserId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CompId", SqlDbType.TinyInt);
                param.Value = Common.CId;
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
        #endregion

        # region "Detail Section"

        public DataTable RecDet_Source(int Id)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();


            MyCmd = new SqlCommand("qry_OutStandingPendingDet", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@DocId", SqlDbType.Int);
            MyParam.Value = Id;
            MyCmd.Parameters.Add(MyParam);


            MyParam = new SqlParameter("@compID", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Acc_AdjustDet";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            //return DTbl;
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

        public int RecDet_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("RecId", "RecId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Part", "Part", 0, 2));//, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("BillRefNo", "BillRefNo", 80, 3, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            //tmp.Add(CommonView.GetGridViewColumn("InvDt", "InvDt", 80, 4,true,DataGridViewContentAlignment.MiddleLeft,"dd/MM/yyyy"));
            tmp.Add(CommonView.GetGridViewColumn("RefId", "RefId", 0, 5));
            tmp.Add(CommonView.GetGridViewColumn("RefNo", "RefNo", 70, 6, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("RefDate", "RefDate", 80, 7, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));
            tmp.Add(CommonView.GetGridViewColumn("BillAmt", "BillAmt", 100, 8, true, DataGridViewContentAlignment.MiddleRight, "#####0.000"));
            tmp.Add(CommonView.GetGridViewColumn("Balance", "Balance", 100, 9, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("PaidAmt", "PaidAmt", 100, 10, true, DataGridViewContentAlignment.MiddleRight, "#####0.000"));
            tmp.Add(CommonView.GetGridViewColumn("DocRef", "DocRef", 0, 11));
            tmp.Add(CommonView.GetGridViewColumn("RefTypeId", "RefTypeId", 0, 12));
            tmp.Add(CommonView.GetGridViewColumn("DrCr", "DrCr", 0, 13));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 14));
            tmp.Add(CommonView.GetGridViewColumn("AcYrId", "AcYrId", 0, 15));
            tmp.Add(CommonView.GetGridViewColumn("Discount", "Discount", 100, 16, false, DataGridViewContentAlignment.MiddleRight, "#####0.000"));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        public DataTable BillNo_Source(int RecId,int AccID,bool Mode,decimal PaidAmt)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();


            MyCmd = new SqlCommand("Qry_RecAdjPending", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@RecID", SqlDbType.Int);
            MyParam.Value = RecId;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@AccID", SqlDbType.Int);
            MyParam.Value = AccID;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Mode", SqlDbType.Bit);
            MyParam.Value = Mode;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@PaidAmt", SqlDbType.Decimal);
            MyParam.Value = PaidAmt;
            MyCmd.Parameters.Add(MyParam);
            
            MyParam = new SqlParameter("@compID", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Acc_AdjustDet";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            //return DTbl;
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
        public int BillNo_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("RecId", "RecId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Part", "Part", 0, 2));//, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("BillRefNo", "BillRefNo", 80, 3, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            //tmp.Add(CommonView.GetGridViewColumn("InvDt", "InvDt", 80, 4, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));
            tmp.Add(CommonView.GetGridViewColumn("RefId", "RefId", 0, 5));
            tmp.Add(CommonView.GetGridViewColumn("RefNo", "RefNo", 70, 6, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("RefDate", "RefDate", 80, 7, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));
            tmp.Add(CommonView.GetGridViewColumn("BillAmt", "BillAmt", 100, 8, true, DataGridViewContentAlignment.MiddleRight, "#####0.000"));
            tmp.Add(CommonView.GetGridViewColumn("Balance", "Balance", 100, 9, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("PaidAmt", "PaidAmt", 100, 10, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("DocRef", "DocRef", 0, 11));
            tmp.Add(CommonView.GetGridViewColumn("RefTypeId", "RefTypeId", 0, 12));
            tmp.Add(CommonView.GetGridViewColumn("DrCr", "DrCr", 0, 13));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 14));
            tmp.Add(CommonView.GetGridViewColumn("AcYrId", "AcYrId", 0, 15));
            tmp.Add(CommonView.GetGridViewColumn("Discount", "CashDisc", 100, 10, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        #endregion

        public DataTable LastRecNo_Source()
        {

            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_LastRecNoSource", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_LastRecNoSource";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();

            return DTbl;

        }

        public DataTable ReceipthdrSource(int Id)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_Receipthdr", Con);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("@RecId", SqlDbType.Int);
            param.Value = Id;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@compId", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "ReceiptHdr";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }
        public DataTable ReceiptDetSource(int Id)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("qry_ReceiptDet", Con);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("@RecId", SqlDbType.Int);
            param.Value = Id;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@compId", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "ReceiptDet";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }
        public DataTable SalFill(int RecID, int AccID, bool Mode)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand MyCmd;
            SqlParameter MyParam = new SqlParameter();
            MyCmd = new SqlCommand("Qry_SalPending", Con);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@RecID", SqlDbType.Int);
            MyParam.Value = RecID;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@AccID", SqlDbType.Int);
            MyParam.Value = AccID;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Mode", SqlDbType.Bit);
            MyParam.Value = Mode;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            Da.SelectCommand = MyCmd;
            Da.Fill(Tbl);
            Tbl.TableName = "Acc_AdjustDet";
            Da.Dispose();
            MyCmd.Dispose();
            Con.Close();
            return Tbl;
        }

        public int SalFill_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("RecId", "RecId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Part", "Part", 0, 2));//, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("BillRefNo", "BillRefNo", 80, 3, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            //tmp.Add(CommonView.GetGridViewColumn("InvDt", "InvDt", 80, 4, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));
            tmp.Add(CommonView.GetGridViewColumn("RefId", "RefId", 0, 5));
            tmp.Add(CommonView.GetGridViewColumn("RefNo", "RefNo", 70, 6, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("RefDate", "RefDate", 80, 7, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));
            tmp.Add(CommonView.GetGridViewColumn("BillAmt", "BillAmt", 100, 8, true, DataGridViewContentAlignment.MiddleRight, "#####0.000"));
            tmp.Add(CommonView.GetGridViewColumn("Balance", "Balance", 100, 9, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("PaidAmt", "PaidAmt", 100, 10, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("DocRef", "DocRef", 0, 11));
            tmp.Add(CommonView.GetGridViewColumn("RefTypeId", "RefTypeId", 0, 12));
            tmp.Add(CommonView.GetGridViewColumn("DrCr", "DrCr", 0, 13));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 14));
            tmp.Add(CommonView.GetGridViewColumn("AcYrId", "AcYrId", 0, 15));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        # region "Return Goods"

        public DataTable SalRetFill(int RecId,int AccID,Boolean Mode)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            SqlParameter MyParam = new SqlParameter();
            Con.Open();
            SqlCommand MyCmd;
            MyCmd = new SqlCommand("Qry_SalRetPending", Con);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@RecId", SqlDbType.Int);
            MyParam.Value = RecId;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@AccID", SqlDbType.Int);
            MyParam.Value = AccID;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Mode", SqlDbType.Bit);
            MyParam.Value = Mode;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@compID", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            Da.SelectCommand = MyCmd;
            Da.Fill(Tbl);
            Tbl.TableName = "SalRetPend";
            Da.Dispose();
            MyCmd.Dispose();
            Con.Close();
            return Tbl;
        }

        public int SalRetFill_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("Id", "Id", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("SalRetId", "SalRetId", 0, 2));
            tmp.Add(CommonView.GetGridViewColumn("PtyId", "PtyId", 0, 3));//, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("SalRetNo", "SalRetNo", 80, 4, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("SalRetDt", "SalRetDt", 80, 5, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));
            tmp.Add(CommonView.GetGridViewColumn("NetAmt", "NetAmt", 100, 6, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            //tmp.Add(CommonView.GetGridViewColumn("PurRetNo", "PurRetNo", 80, 7));
            tmp.Add(CommonView.GetGridViewColumn("AcYrId", "AcYrId", 0, 7));
            tmp.Add(CommonView.GetGridViewColumn("DocRef", "DocRef", 0, 8));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }



        # endregion

        public DataTable RecRetDet_Source(int Id)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();


            MyCmd = new SqlCommand("qry_ReceiptRetDet", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@RecId", SqlDbType.Int);
            MyParam.Value = Id;
            MyCmd.Parameters.Add(MyParam);


            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "RecRetDet";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            //return DTbl;
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

        public int RecRetDet_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("RecId", "RecId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("SalRetId", "SalRetId", 0, 2));
            tmp.Add(CommonView.GetGridViewColumn("SalRetNo", "SalRetNo", 80, 3));
            tmp.Add(CommonView.GetGridViewColumn("PtyId", "PtyId", 0, 4));
            tmp.Add(CommonView.GetGridViewColumn("NetAmt", "NetAmt", 100, 5, true, DataGridViewContentAlignment.MiddleRight, "#####0.000"));
            tmp.Add(CommonView.GetGridViewColumn("SalRetDt", "SalRetDt", 80, 6, true, DataGridViewContentAlignment.MiddleRight, "dd/MM/yyyy"));
            tmp.Add(CommonView.GetGridViewColumn("AcYrId", "AcYrId", 0, 7));
            tmp.Add(CommonView.GetGridViewColumn("SRDocRef", "SRDocRef", 0, 8));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

        public DataTable PendingBillFill(int DocId,int AccID)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand MyCmd;
            SqlParameter MyParam = new SqlParameter();
            MyCmd = new SqlCommand("Qry_OnAccRecPending", Con);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@DocId", SqlDbType.Int);
            MyParam.Value = DocId;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@AccID", SqlDbType.Int);
            MyParam.Value = AccID;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            Da.SelectCommand = MyCmd;
            Da.Fill(Tbl);
            Tbl.TableName = "Acc_AdjustDet";
            Da.Dispose();
            MyCmd.Dispose();
            Con.Close();
            return Tbl;
        }

        public int PendingBillFill_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("RecId", "RecId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("AcYrId", "AcYrId", 0, 2));   
            tmp.Add(CommonView.GetGridViewColumn("RecNo", "RecNo", 70,3, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("RecDt", "RecDate", 80, 4, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));
            tmp.Add(CommonView.GetGridViewColumn("RefTypeId", "RefTypeId", 0, 5));
            tmp.Add(CommonView.GetGridViewColumn("PtyId", "PtyId", 0, 6));
            tmp.Add(CommonView.GetGridViewColumn("LedgerAccId", "LedgerAccId", 0, 7));
            tmp.Add(CommonView.GetGridViewColumn("Cash", "Cash", 0, 8));
            tmp.Add(CommonView.GetGridViewColumn("ChqNo", "ChqNo", 0, 9));
            tmp.Add(CommonView.GetGridViewColumn("ChqDt", "ChqDt", 0, 10));
            tmp.Add(CommonView.GetGridViewColumn("chqType", "chqType", 0, 11));
            tmp.Add(CommonView.GetGridViewColumn("CashDisc", "CashDisc", 0, 12));
            tmp.Add(CommonView.GetGridViewColumn("Commission", "Commission", 0, 13));
            tmp.Add(CommonView.GetGridViewColumn("Narration1", "Narration1", 0, 14));
            tmp.Add(CommonView.GetGridViewColumn("Narration2", "Narration2", 0, 15));
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 16));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 17));
            tmp.Add(CommonView.GetGridViewColumn("CashRecNo", "CashRecNo", 0, 18));
            tmp.Add(CommonView.GetGridViewColumn("AgainstType", "AgainstType", 0, 19));
            tmp.Add(CommonView.GetGridViewColumn("Est", "Est", 0, 20));
            tmp.Add(CommonView.GetGridViewColumn("EstId", "EstId", 0, 21));
            tmp.Add(CommonView.GetGridViewColumn("GId", "GId", 0, 22));
            tmp.Add(CommonView.GetGridViewColumn("NetAmt", "NetAmt", 100, 23, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));            

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

        # region "Fetch Section"
       
        public bool FetchRecord(int Id,bool All)
        {
            SqlConnection Con = new SqlConnection(Common.ConStr);
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_OutStandingPendingHdr", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@DocId", SqlDbType.Int);
            param.Value = Id;
            Cmd.Parameters.Add(param);         

            param = new SqlParameter("@compId", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            SqlDataReader rd = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (rd.Read())
            {

                _DocId = (int)rd.GetValue(rd.GetOrdinal("DocId"));
                _AcYrId = (short)rd.GetValue(rd.GetOrdinal("AcYrId"));
                _DocNo = (int)rd.GetValue(rd.GetOrdinal("DocNo"));
                _DocDt = (DateTime)rd.GetValue(rd.GetOrdinal("DocDt"));                
                _AgainstType = (string)rd.GetValue(rd.GetOrdinal("AgainstType"));
                _PtyId = (int)rd.GetValue(rd.GetOrdinal("PtyId"));
                _LedgerAccId = (int)rd.GetValue(rd.GetOrdinal("LedgerAccId"));
                _Cash = (string)rd.GetValue(rd.GetOrdinal("Cash"));
                _Chqno = (string)rd.GetValue(rd.GetOrdinal("ChqNo"));
                _ChqDt = (DateTime)rd.GetValue(rd.GetOrdinal("ChqDt"));
                _chqType = (string)rd.GetValue(rd.GetOrdinal("chqType"));
                _CashDisc = (decimal)rd.GetValue(rd.GetOrdinal("CashDisc"));
                _Commission = (decimal)rd.GetValue(rd.GetOrdinal("Commission"));
                _NetAmt = (decimal)rd.GetValue(rd.GetOrdinal("NetAmt"));
                _Narration1 = (string)rd.GetValue(rd.GetOrdinal("Narration1"));
                _Narration2 = (string)rd.GetValue(rd.GetOrdinal("Narration2"));
                _CashRecNo = (string)rd.GetValue(rd.GetOrdinal("CashRecNo"));
                _RecId = (int)rd.GetValue(rd.GetOrdinal("RecId"));
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

        # region "Fill Supplier"
        public DataTable LedgerSource(string DocType,bool Mode)
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

            param = new SqlParameter("@Mode", SqlDbType.Bit);
            param.Value = Mode;
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

        public DataTable Bank_Source()
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_BankSelect", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@compId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "BankSelect";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }
      
        public int Bank_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("BankId", "BankId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("BankName", "BankName", 200, 3, true));
            
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        public DataTable EstimateBook()
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_EstimateBook", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_EstimateBook";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }
        public DataTable Type_Source(string Ref)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Acc_Qry_Fsim", Con);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("@RefId", SqlDbType.TinyInt);
            param.Value = 1;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Ref", SqlDbType.Char,5);
            param.Value = Ref;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "Type";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }
        public int Type_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("FsimId", "FsimId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Fsimname", "Fsimname", 200, 3, true));
            tmp.Add(CommonView.GetGridViewColumn("Updownno", "Updownno", 0, 2));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
# endregion
            
        # region "Fill Opening"

        # endregion

        #region "For View Record"
        public DataTable navigate()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Select Top 100 * From OutStandingPendingHdrvwFn(" + Common.CId + ") where DocId > 0 order by DocId desc", Con);
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
            _View.TableNames = "OutStandingPendingHdrvwFn(" + Common.CId + ")";
            _View.Fields = "*";
            _View.Conditions = "DocId > 0";
        }

     
        public int View_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
                        
            tmp.Add(CommonView.GetGridViewColumn("DocId", "DocId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("DocNo", "DocNo", 50, 2, true));
            tmp.Add(CommonView.GetGridViewColumn("DocDt", "DocDt", 70, 3, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));
            tmp.Add(CommonView.GetGridViewColumn("RefNo", "RefNo", 80, 4, true, DataGridViewContentAlignment.MiddleLeft,""));
            tmp.Add(CommonView.GetGridViewColumn("PartyName", "PartyName", 240,5, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("BankName", "BankName", 240, 6, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("LedgerAccId", "LedgerAccId", 0, 7, true));
            //tmp.Add(CommonView.GetGridViewColumn("chqno", "chqno", 60, 6, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("NetAmt", "NetAmt", 70, 8, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            //tmp.Add(CommonView.GetGridViewColumn("PMode", "PMode", 0, 8,true));
            //tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 10, true));
            //tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 12, true));
            
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
    }
}
