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
    public class ReceiptNewDB
    {
        public ReceiptNewDB()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        # region "Properties"

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
        int _SlNo;
        public int SlNo
        {
            get
            {
                return _SlNo;
            }
            set
            {
                _SlNo = value;
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

        int _BankId;
        public int BankId
        {
            get
            {
                return _BankId;
            }
            set
            {
                _BankId = value;
            }
        }

        int _PAcYrId;
        public int PAcYrId
        {
            get
            {
                return _PAcYrId;
            }
            set
            {
                _PAcYrId = value;
            }
        }



        int _SalId;
        public int SalId
        {
            get
            {
                return _SalId;
            }
            set
            {
                _SalId = value;
            }
        }



        int _SalRetId;
        public int SalRetId
        {
            get
            {
                return _SalRetId;
            }
            set
            {
                _SalRetId = value;
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
        string _PayType;
        public string PayType
        {
            get
            {
                return _PayType;
            }
            set
            {
                _PayType = value;
            }
        }
        decimal _DDComsn;
        public decimal DDComsn
        {
            get
            {
                return _DDComsn;
            }
            set
            {
                _DDComsn = value;
            }
        }

        decimal _Amount;
        public decimal Amount
        {
            get
            {
                return _Amount;
            }
            set
            {
                _Amount = value;
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

        decimal _SalRetAmt;
        public decimal SalRetAmt
        {
            get
            {
                return _SalRetAmt;
            }
            set
            {
                _SalRetAmt = value;
            }
        }
        decimal _SalDiscPer;
        public decimal SalDiscPer
        {
            get
            {
                return _SalDiscPer;
            }
            set
            {
                _SalDiscPer = value;
            }
        }

        decimal _SalTotal;
        public decimal SalTotal
        {
            get
            {
                return _SalTotal;
            }
            set
            {
                _SalTotal = value;
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


        decimal _Others;
        public decimal Others
        {
            get
            {
                return _Others;
            }
            set
            {
                _Others = value;
            }
        }

        decimal _AgentComsn;
        public decimal AgentComsn
        {
            get
            {
                return _AgentComsn;
            }
            set
            {
                _AgentComsn = value;
            }
        }

        decimal _AgentComsnPer;
        public decimal AgentComsnPer
        {
            get
            {
                return _AgentComsnPer;
            }
            set
            {
                _AgentComsnPer = value;
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

        DateTime _SalRetDt;
        public DateTime SalRetDt
        {
            get
            {
                return _SalRetDt;
            }
            set
            {
                _SalRetDt = value;
            }
        }

        string _DocType;
        public string DocType
        {
            get
            {
                return _DocType;
            }
            set
            {
                _DocType = value;
            }
        }


        string _GridId;
        public string GridId
        {
            get
            {
                return _GridId;
            }
            set
            {
                _GridId = value;
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

        int _SalRetNo;
        public int SalRetNo
        {
            get
            {
                return _SalRetNo;
            }
            set
            {
                _SalRetNo = value;
            }
        }

        DataTable _ReceiptDet;
        public DataTable ReceiptDet
        {
            get
            {
                return _ReceiptDet;
            }
            set
            {
                _ReceiptDet = value;
            }
        }



        string _PurInvNo;
        public string PurInvNo
        {
            get
            {
                return _PurInvNo;
            }
            set
            {
                _PurInvNo = value;
            }
        }


        DateTime _PurInvDt;
        public DateTime PurInvDt
        {
            get
            {
                return _PurInvDt;
            }
            set
            {
                _PurInvDt = value;
            }
        }
              
        DataTable _RecDet;
        public DataTable RecDet
        {
            get
            {
                return _RecDet;
            }
            set
            {
                _RecDet = value;
            }
        }

        DataTable _RecRetDet;
        public DataTable RecRetDet
        {
            get
            {
                return _RecRetDet;
            }
            set
            {
                _RecRetDet = value;
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

        decimal _InterestAmt;
        public decimal InterestAmt
        {
            get
            {
                return _InterestAmt;
            }
            set
            {
                _InterestAmt = value;
            }
        }

        # endregion

        # region "Save"
        public int SaveFunction(Saving.SaveType Mode)
        {
            int code;
            DataSet Ds = new DataSet();
            string DetStr;
            Ds.Tables.Add(RecDet);
            Ds.Tables.Add(RecRetDet);
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
                Cmd = new SqlCommand("ReceiptSP", Con);
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

                param = new SqlParameter("@SNo", SqlDbType.Int);
                param.Value = _SlNo;
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

                param = new SqlParameter("@PtyId", SqlDbType.Int);
                param.Value = _PtyId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@AgainstType", SqlDbType.Char, 1);
                param.Value = _AgainstType;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@LedgerAccId", SqlDbType.Int);
                param.Value = _LedgerAccId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Commission", SqlDbType.Decimal);
                param.Value = _Commission;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CashDisc", SqlDbType.Decimal);
                param.Value = _CashDisc;
                Cmd.Parameters.Add(param);               

                param = new SqlParameter("@PayType", SqlDbType.Char, 1);
                param.Value = _PayType;
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

                param = new SqlParameter("@Est", SqlDbType.Bit);
                param.Value = _Est;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@EstId", SqlDbType.Int);
                param.Value = _EstId;
                Cmd.Parameters.Add(param);  

                param = new SqlParameter("@BankId", SqlDbType.Int);
                param.Value = _BankId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@SalTotal", SqlDbType.Decimal);
                param.Value = _SalTotal;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@AddAmt", SqlDbType.Decimal);
                param.Value = 0;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@NetAmt", SqlDbType.Decimal);
                param.Value = _NetAmt;
                Cmd.Parameters.Add(param);

                //param = new SqlParameter("@PurAmt", SqlDbType.Decimal);
                //param.Value = _PurAmt;
                //Cmd.Parameters.Add(param);

                param = new SqlParameter("@SalRetAmt", SqlDbType.Decimal);
                param.Value = _SalRetAmt;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Cash", SqlDbType.Char, 2);
                param.Value = _Cash;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Narration1", SqlDbType.VarChar, 50);
                param.Value = _Narration1;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Narration2", SqlDbType.VarChar, 50);
                param.Value = _Narration2;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CashRecNo", SqlDbType.VarChar, 75);
                param.Value = _CashRecNo;
                Cmd.Parameters.Add(param);

                //param = new SqlParameter("@PurInvNo", SqlDbType.VarChar, 50);
                //param.Value = _PurInvNo.Replace("'", "''");
                //Cmd.Parameters.Add(param);

                //param = new SqlParameter("@SalRetDt", SqlDbType.DateTime);
                //param.Value = _SalRetDt.ToString("dd/MMM/yyyy");
                //Cmd.Parameters.Add(param);

                //param = new SqlParameter("@PurRetInvNo", SqlDbType.VarChar, 50);
                //param.Value = _PurRetInvNo.Replace("'", "''");
                //Cmd.Parameters.Add(param);

                //param = new SqlParameter("@PurRetInvDt", SqlDbType.DateTime);
                //param.Value = _PurRetInvDt.ToString("dd/MMM/yyyy");
                //Cmd.Parameters.Add(param);

                param = new SqlParameter("@SalDiscPer", SqlDbType.Decimal);
                param.Value = _DiscPer;
                Cmd.Parameters.Add(param);           

                param = new SqlParameter("@AgComsn", SqlDbType.Decimal);
                param.Value = _AgentComsn;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@AgComsnPer", SqlDbType.Decimal);
                param.Value = _AgentComsnPer;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Others", SqlDbType.Decimal);
                param.Value = _Others;
                Cmd.Parameters.Add(param);                

                param = new SqlParameter("@SalRetId", SqlDbType.Int);
                param.Value = _SalRetId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@InterestAmt", SqlDbType.Decimal);
                param.Value = _InterestAmt;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DDComm", SqlDbType.Decimal);
                param.Value = _DDComsn;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TextileRec", SqlDbType.Bit);
                param.Value = 1;
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

                param = new SqlParameter("@Id", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                Cmd.Parameters.Add(param);

                Cmd.ExecuteNonQuery();
                code = (int)Cmd.Parameters["@Id"].Value;
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


            MyCmd = new SqlCommand("qry_ReceiptDet", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@RecId", SqlDbType.Int);
            MyParam.Value = Id;
            MyCmd.Parameters.Add(MyParam);


            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
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
            tmp.Add(CommonView.GetGridViewColumn("PaidAmt", "PaidAmt", 100, 10, false, DataGridViewContentAlignment.MiddleRight, "#####0.000"));
            tmp.Add(CommonView.GetGridViewColumn("DocRef", "DocRef", 0, 11));
            tmp.Add(CommonView.GetGridViewColumn("RefTypeId", "RefTypeId", 0, 12));
            tmp.Add(CommonView.GetGridViewColumn("DrCr", "DrCr", 0, 13));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 14));
            tmp.Add(CommonView.GetGridViewColumn("AcYrId", "AcYrId", 0, 15));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

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
        //public DataTable BillNo_Source(int payID,int AccID)
        //{
        //    SqlConnection MyCon = new SqlConnection();
        //    SqlCommand MyCmd = new SqlCommand();
        //    SqlParameter MyParam = new SqlParameter();
        //    SqlDataAdapter MyAdapt = new SqlDataAdapter();
        //    DataTable DTbl = new DataTable();

        //    MyCon = new SqlConnection(Common.ConStr);
        //    MyCon.Open();


        //    MyCmd = new SqlCommand("Qry_PurPending", MyCon);
        //    MyCmd.CommandType = CommandType.StoredProcedure;

        //    MyParam = new SqlParameter("@payID", SqlDbType.Int);
        //    MyParam.Value = payID;
        //    MyCmd.Parameters.Add(MyParam);

        //    MyParam = new SqlParameter("@AccID", SqlDbType.Int);
        //    MyParam.Value = AccID;
        //    MyCmd.Parameters.Add(MyParam);
            
        //    MyParam = new SqlParameter("@compID", SqlDbType.TinyInt);
        //    MyParam.Value = Common.CId;
        //    MyCmd.Parameters.Add(MyParam);

        //    MyAdapt.SelectCommand = MyCmd;
        //    MyAdapt.Fill(DTbl);

        //    DTbl.TableName = "Acc_AdjustDet";
        //    MyAdapt.Dispose();
        //    MyCmd.Dispose();
        //    MyCon.Close();
        //    //return DTbl;
        //    foreach (DataColumn Col in DTbl.Columns)
        //    {
        //        switch (Col.DataType.UnderlyingSystemType.Name)
        //        {
        //            case "String":
        //                Col.AllowDBNull = false;
        //                Col.DefaultValue = "";
        //                break;
        //            case "Byte":
        //                Col.DefaultValue = 0;
        //                Col.AllowDBNull = false;
        //                break;
        //            case "int":
        //                Col.AllowDBNull = false;
        //                Col.DefaultValue = 0;
        //                break;
        //            case "Int32":
        //                Col.AllowDBNull = false;
        //                Col.DefaultValue = 0;
        //                break;
        //            case "Int16":
        //                Col.AllowDBNull = false;
        //                Col.DefaultValue = 0;
        //                break;
        //            case "Single":
        //                Col.AllowDBNull = false;
        //                Col.DefaultValue = 0.0;
        //                break;
        //            case "Double":
        //                Col.AllowDBNull = false;
        //                Col.DefaultValue = 0.0;
        //                break;
        //            case "Decimal":
        //                Col.DefaultValue = 0.0;
        //                Col.AllowDBNull = false;
        //                break;
        //        }
        //    }
        //    return DTbl;
        //}
        //public int BillNo_GridStyle(DataGridViewColumnCollection tmp)
        //{
        //    tmp.Clear();
        //    tmp.Add(CommonView.GetGridViewColumn("PayId", "PayId", 0, 1));
        //    tmp.Add(CommonView.GetGridViewColumn("Part", "Part", 0, 2));//, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
        //    tmp.Add(CommonView.GetGridViewColumn("InvNo", "InvNo", 80, 3, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
        //    tmp.Add(CommonView.GetGridViewColumn("InvDt", "InvDt", 80, 4, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));
        //    tmp.Add(CommonView.GetGridViewColumn("RefId", "RefId", 0, 5));
        //    tmp.Add(CommonView.GetGridViewColumn("RefNo", "RefNo", 70, 6, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
        //    tmp.Add(CommonView.GetGridViewColumn("RefDate", "RefDate", 80, 7, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));
        //    tmp.Add(CommonView.GetGridViewColumn("BillAmt", "BillAmt", 100, 8, true, DataGridViewContentAlignment.MiddleRight, "#####0.000"));
        //    tmp.Add(CommonView.GetGridViewColumn("Balance", "Balance", 100, 9, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
        //    tmp.Add(CommonView.GetGridViewColumn("PaidAmt", "PaidAmt", 100, 10, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
        //    tmp.Add(CommonView.GetGridViewColumn("DocRef", "DocRef", 0, 11));
        //    tmp.Add(CommonView.GetGridViewColumn("RefTypeId", "RefTypeId", 0, 12));
        //    tmp.Add(CommonView.GetGridViewColumn("DrCr", "DrCr", 0, 13));
        //    tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 14));
        //    tmp.Add(CommonView.GetGridViewColumn("AcYrId", "AcYrId", 0, 15));

        //    tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

        //    return 0;
        //}
        #endregion

        # region "Fetch Section"
       
        public bool FetchRecord(int Id,bool All)
        {
            SqlConnection Con = new SqlConnection(Common.ConStr);
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_ReceiptNewHdr", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@RecId", SqlDbType.Int);
            param.Value = Id;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@All", SqlDbType.Bit);
            param.Value = All;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@TextileRec", SqlDbType.Bit);
            param.Value = 1;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@compId", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            SqlDataReader rd = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
             if (rd.Read())
            {
                //_GridId = (string)rd.GetValue(rd.GetOrdinal("GridId"));
                _RecId = (int)rd.GetValue(rd.GetOrdinal("RecId"));
                _SlNo = (int)rd.GetValue(rd.GetOrdinal("SNo"));
                _RecNo = (int)rd.GetValue(rd.GetOrdinal("RecNo"));
                _RecDt = (DateTime)rd.GetValue(rd.GetOrdinal("RecDt"));
                _PtyId = (int)rd.GetValue(rd.GetOrdinal("PtyId"));                
                _Commission = (decimal)rd.GetValue(rd.GetOrdinal("Commission"));
                _PayType = (string)rd.GetValue(rd.GetOrdinal("PayType"));
                _Chqno = (string)rd.GetValue(rd.GetOrdinal("ChqNo"));
                _ChqDt = (DateTime)rd.GetValue(rd.GetOrdinal("ChqDt"));
                _BankId = (int)rd.GetValue(rd.GetOrdinal("BankId"));

                _DiscPer = (decimal)rd.GetValue(rd.GetOrdinal("SalDiscPer"));
                //_DiscAmt = (decimal)rd.GetValue(rd.GetOrdinal("PurDiscAmt"));
                //_Amount = (decimal)rd.GetValue(rd.GetOrdinal("Amount"));
                _NetAmt = (decimal)rd.GetValue(rd.GetOrdinal("NetAmt"));
                //_PurAmt = (decimal)rd.GetValue(rd.GetOrdinal("PurAmt"));
                _SalRetAmt = (decimal)rd.GetValue(rd.GetOrdinal("SalRetAmt"));
                _Cash = (string)rd.GetValue(rd.GetOrdinal("Cash"));
                _Narration1 = (string)rd.GetValue(rd.GetOrdinal("Narration1"));
                _Narration2 = (string)rd.GetValue(rd.GetOrdinal("Narration2"));
                //_PurInvNo = (string)rd.GetValue(rd.GetOrdinal("PurInvNo"));
                //_PurInvDt = (DateTime)rd.GetValue(rd.GetOrdinal("PurInvDt"));
                //_PurRetInvNo = (string)rd.GetValue(rd.GetOrdinal("PurRetInvNo"));
               // _SalRetDt = (DateTime)rd.GetValue(rd.GetOrdinal("SalRetDt"));
                _SalTotal = (decimal)rd.GetValue(rd.GetOrdinal("SalTotal"));

                _AgentComsn = (decimal)rd.GetValue(rd.GetOrdinal("AgComsn"));
                _AgentComsnPer = (decimal)rd.GetValue(rd.GetOrdinal("AgComsnPer"));
                _Others = (decimal)rd.GetValue(rd.GetOrdinal("Others"));
                _SalRetId = (int)rd.GetValue(rd.GetOrdinal("SalRetId"));
                _RefTypeId = (short)rd.GetValue(rd.GetOrdinal("RefTypeId"));
                _AgainstType = (string)rd.GetValue(rd.GetOrdinal("AgainstType"));
                _LedgerAccId = (int)rd.GetValue(rd.GetOrdinal("LedgerAccId"));
                _chqType = (string)rd.GetValue(rd.GetOrdinal("chqType"));
                _CashDisc = (decimal)rd.GetValue(rd.GetOrdinal("CashDisc"));
                _Est = (bool)rd.GetValue(rd.GetOrdinal("Est"));
                _EstId = (int)rd.GetValue(rd.GetOrdinal("EstId"));
                _InterestAmt = (decimal)rd.GetValue(rd.GetOrdinal("InterestAmt"));
                _DDComsn = (decimal)rd.GetValue(rd.GetOrdinal("DDComm"));
                _CashRecNo = (string)rd.GetValue(rd.GetOrdinal("CashRecNo"));
              
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

        public DataTable Type_Source()
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
            
        # region "Return Goods"

        public DataTable SalRetFill(int AccID)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            SqlParameter MyParam = new SqlParameter();
            Con.Open();
            SqlCommand MyCmd;
            MyCmd = new SqlCommand("Qry_SalRetPending", Con);
            MyCmd.CommandType = CommandType.StoredProcedure;          

            MyParam = new SqlParameter("@AccID", SqlDbType.Int);
            MyParam.Value = AccID;
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



        # region "Supplier"

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

        #endregion

        #region "For View Record"
        public DataTable navigate(bool All)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Select Top 100 * From ReceiptHdrNewvwFn('" + All + "',1," + Common.CId + ") where RecId > 0 order by RecId desc", Con);
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
        public void SetViewControl(bool All)
        {
            _FilteringValues.Clear();

            _View.FilteringValues = _FilteringValues;
            _View.TableNames = "ReceiptHdrNewvwFn('" + All + "',1," + Common.CId + ")";
            _View.Fields = "*";
            _View.Conditions = "RecId > 0";
        }

     
        public int View_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();

            tmp.Add(CommonView.GetGridViewColumn("RecId", "RecId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("RecNo", "RecNo", 50, 2, true));
            tmp.Add(CommonView.GetGridViewColumn("RecDt", "RecDt", 70, 3, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));
            tmp.Add(CommonView.GetGridViewColumn("RefNo", "RefNo", 80, 4, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("PartyName", "PartyName", 240, 5, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("BankName", "BankName", 240, 6, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("LedgerAccId", "LedgerAccId", 60, 7, true, DataGridViewContentAlignment.MiddleLeft));
            tmp.Add(CommonView.GetGridViewColumn("NetAmt", "NetAmt", 70, 8, true, DataGridViewContentAlignment.MiddleRight, "#####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("PMode", "PMode", 0, 9, true));
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



        # region "Bill No Pend"

          public DataTable BillNo_Source(int RecID,int AccID)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();


            MyCmd = new SqlCommand("Qry_SalPending", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@RecID", SqlDbType.Int);
            MyParam.Value = RecID;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@AccID", SqlDbType.Int);
            MyParam.Value = AccID;
            MyCmd.Parameters.Add(MyParam);
            
            MyParam = new SqlParameter("@compID", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_SalPending";
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

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        #endregion


        public DataTable RecPrint_Source(int Id,bool All)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();


            MyCmd = new SqlCommand("Qry_ReceiptNewHdr", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@RecId", SqlDbType.Int);
            MyParam.Value = Id;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@All", SqlDbType.Int);
            MyParam.Value = All;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@TextileRec", SqlDbType.Bit);
            MyParam.Value = 1;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@CompId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Receipt";
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



    }
}
