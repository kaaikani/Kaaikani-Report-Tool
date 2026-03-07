using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using GridStructures;
using DBAccess;
using RLPOSDB ;

namespace RLPOSDB 
{
	/// <summary>
	/// Summary description for PartyDB.
	/// </summary>
	public class TallyImportDB
	{
        public TallyImportDB()
		{
			//
			// TODO: Add constructor logic here
			//
		}
        # region "Properties"


        short _MapId;
        public short MapId
        {
            get
            {
                return _MapId;
            }
            set
            {
                _MapId = value;
            }
        }

        int _DoctorId;
        public int DoctorId
        {
            get
            {
                return _DoctorId;
            }
            set
            {
                _DoctorId = value;
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

        string _DoctorName;
        public string DoctorName
        {
            get
            {
                return _DoctorName;
            }
            set
            {
                _DoctorName = value;
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

        DataTable _UserMapDet;
        public DataTable UserMapDet
        {
            get
            {
                return _UserMapDet;
            }
            set
            {
                _UserMapDet = value;
            }
        }

        # endregion


        # region "Detail Section"

        public DataTable Doctorselect_Source()
        {

            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_DoctorComboSelect", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "qry_doctor";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public int Doctorselect_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
           // tmp.Add(CommonView.GetGridViewColumn("LedgerHeader", "LedgerHeader", 100, 3, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("DoctorId", "DoctorId", 0,1));//3
            tmp.Add(CommonView.GetGridViewColumn("DoctorName", "DoctorName",150,2,true));//0
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0,3));//3
            tmp.Add(CommonView.GetGridViewColumn("UserName", "UserName", 0,4));//0
            tmp.Add(CommonView.GetGridViewColumn("CompId", "compid", 0, 5));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;       
          
        }

        public DataTable OPReceiptFill_Source(int DoctorId,DateTime FDt, DateTime ToDt)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_OPReceiptTallyImport", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;


            MyParam = new SqlParameter("@DoctorId", SqlDbType.Int);
            MyParam.Value = DoctorId;
            MyCmd.Parameters.Add(MyParam);


            MyParam = new SqlParameter("@FrmDt", SqlDbType.DateTime );
            MyParam.Value = FDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);


            MyParam = new SqlParameter("@ToDt", SqlDbType.DateTime);
            MyParam.Value = ToDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);


            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "OPReceipt";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public int OPReceiptFill_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("ReceiptDt", "ReceiptDt", 100, 1, true));//3
            tmp.Add(CommonView.GetGridViewColumn("MinNo", "Min.RecNo", 50, 2, true));//0
            tmp.Add(CommonView.GetGridViewColumn("MaxNo", "Max.RecNo", 50, 3, true));//0
            tmp.Add(CommonView.GetGridViewColumn("ReceivedAmt", "ReceivedAmt", 100, 4,true , DataGridViewContentAlignment.MiddleRight ,"###0.00"));//0
            tmp.Add(CommonView.GetGridViewColumn("DoctorId", "DoctorId", 0, 5));//3
            tmp.Add(CommonView.GetGridViewColumn("DoctorName", "DoctorName", 150, 6, true));//0
            tmp.Add(CommonView.GetGridViewColumn("GId", "GId", 0, 7));//3

           // tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;       
        }


        public DataTable userMapDetSource(int DoctorId)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("qry_userMapdet", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@DoctorId", SqlDbType.Int);
            param.Value = DoctorId;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "UserMapDet";
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
                }
                //Tbl.Columns["PtyId"].Unique = true;
            }
            return Tbl;

        }

        public int UserDet_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("MapId", "MapId", 0,1));//1
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0,2));//2
            tmp.Add(CommonView.GetGridViewColumn("UserName", "UserName", 230,3,false,DataGridViewContentAlignment.MiddleLeft ,"", DataGridViewAutoSizeColumnMode.Fill ));//2
            tmp.Add(CommonView.GetGridViewBoolColumn ("Accessable", "Accessable", 70,4,false));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;       
        }


        public DataTable VaccineFill_Source(DateTime FDt, DateTime ToDt)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("qry_VaccineTallyImport", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;


            //MyParam = new SqlParameter("@DoctorId", SqlDbType.Int);
            //MyParam.Value = DoctorId;
            //MyCmd.Parameters.Add(MyParam);


            MyParam = new SqlParameter("@FrmDt", SqlDbType.DateTime);
            MyParam.Value = FDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);


            MyParam = new SqlParameter("@ToDt", SqlDbType.DateTime);
            MyParam.Value = ToDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);


            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "VaccineHdr";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public int VaccineFill_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("ReceiptDate", "DocDate", 100, 1, true));//3
            tmp.Add(CommonView.GetGridViewColumn("MinNo", "Min.RecNo", 100, 2, true));//0
            tmp.Add(CommonView.GetGridViewColumn("MaxNo", "Max.RecNo", 100, 3, true));//0
            tmp.Add(CommonView.GetGridViewColumn("ReceivedAmt", "ReceivedAmt", 120, 4, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));//0
            //tmp.Add(CommonView.GetGridViewColumn("DoctorId", "DoctorId", 0, 5));//3
            //tmp.Add(CommonView.GetGridViewColumn("DoctorName", "DoctorName", 150, 6));//0
            tmp.Add(CommonView.GetGridViewColumn("GId", "GId", 0, 5));//3
            tmp.Add(CommonView.GetGridViewColumn("TallyHead", "TallyHead", 0, 6));//3
            tmp.Add(CommonView.GetGridViewColumn("TallyCompName", "TallyCompName", 0, 7));//3

            // tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }


        public DataTable ChargeFill_Source(char ChType,DateTime FDt, DateTime ToDt)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("qry_ChargeTallyImport", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;


            MyParam = new SqlParameter("@ChType", SqlDbType.Char,1);
            MyParam.Value = ChType;
            MyCmd.Parameters.Add(MyParam);


            MyParam = new SqlParameter("@FrmDt", SqlDbType.DateTime);
            MyParam.Value = FDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);


            MyParam = new SqlParameter("@ToDt", SqlDbType.DateTime);
            MyParam.Value = ToDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);


            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "ScanReceipt";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public int ChargeFill_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("ReceiptDate", "ReceiptDate", 100, 1, true));//3
            tmp.Add(CommonView.GetGridViewColumn("MinNo", "Min.RecNo", 100, 2, true));//0
            tmp.Add(CommonView.GetGridViewColumn("MaxNo", "Max.RecNo", 100, 3, true));//0
            tmp.Add(CommonView.GetGridViewColumn("ReceivedAmt", "ReceivedAmt", 120, 4, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));//0
            //tmp.Add(CommonView.GetGridViewColumn("DoctorId", "DoctorId", 0, 5));//3
            tmp.Add(CommonView.GetGridViewColumn("Labtype", "Labtype", 0, 5));//0
            tmp.Add(CommonView.GetGridViewColumn("LabTypeDet", "LabTypeDet", 150, 6, true));//0
            tmp.Add(CommonView.GetGridViewColumn("GId", "GId", 0, 7));//3
            tmp.Add(CommonView.GetGridViewColumn("TallyHead", "TallyHead", 0, 8));//3
            tmp.Add(CommonView.GetGridViewColumn("TallyCompName", "TallyCompName", 0, 9));//3

            // tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }


        public DataTable EEGFill_Source(DateTime FDt, DateTime ToDt)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("qry_EEGTallyImport", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;


            //MyParam = new SqlParameter("@DoctorId", SqlDbType.Int);
            //MyParam.Value = DoctorId;
            //MyCmd.Parameters.Add(MyParam);


            MyParam = new SqlParameter("@FrmDt", SqlDbType.DateTime);
            MyParam.Value = FDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);


            MyParam = new SqlParameter("@ToDt", SqlDbType.DateTime);
            MyParam.Value = ToDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);


            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "EEGReceipt";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public int EEGFill_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("ReceiptDate", "ReceiptDate", 100, 1, true));//3
            tmp.Add(CommonView.GetGridViewColumn("MinNo", "Min.RecNo", 100, 2, true));//0
            tmp.Add(CommonView.GetGridViewColumn("MaxNo", "Max.RecNo", 100, 3, true));//0
            tmp.Add(CommonView.GetGridViewColumn("ReceivedAmt", "ReceivedAmt", 120, 4, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));//0
            //tmp.Add(CommonView.GetGridViewColumn("DoctorId", "DoctorId", 0, 5));//3
            //tmp.Add(CommonView.GetGridViewColumn("DoctorName", "DoctorName", 150, 6));//0
            tmp.Add(CommonView.GetGridViewColumn("GId", "GId", 0, 5));//3
            tmp.Add(CommonView.GetGridViewColumn("TallyHead", "TallyHead", 0, 6));//3
            tmp.Add(CommonView.GetGridViewColumn("TallyCompName", "TallyCompName", 0, 7));//3

            // tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }


        public DataTable PurFill_Source(DateTime FDt, DateTime ToDt)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_PurTallyImport", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;



            MyParam = new SqlParameter("@FrmDt", SqlDbType.DateTime);
            MyParam.Value = FDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);


            MyParam = new SqlParameter("@ToDt", SqlDbType.DateTime);
            MyParam.Value = ToDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            
            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Purchase";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public int PurFill_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("PurId", "PurId", 0, 1, true));//3
            tmp.Add(CommonView.GetGridViewColumn("PurNo", "PurNo", 75, 2, true));//0
            tmp.Add(CommonView.GetGridViewColumn("PurDt", "PurDt", 100, 3, true, DataGridViewContentAlignment.MiddleLeft,"dd/MM/yyyy"));//0
            tmp.Add(CommonView.GetGridViewColumn("InvNo", "InvNo", 75, 4, true));//0
            tmp.Add(CommonView.GetGridViewColumn("InvDt", "InvDt", 100, 5, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));//0
            tmp.Add(CommonView.GetGridViewColumn("PtyId", "PtyId", 0, 6));//3
            tmp.Add(CommonView.GetGridViewColumn("Supplier", "Supplier", 100, 7));//3
            tmp.Add(CommonView.GetGridViewColumn("TallyHead", "TallyHead", 105, 8));//3
            tmp.Add(CommonView.GetGridViewColumn("Add1", "Add1", 75, 9));//3
            tmp.Add(CommonView.GetGridViewColumn("City", "City", 75, 10));//3
            tmp.Add(CommonView.GetGridViewColumn("Tin", "Tin", 75, 11));//3
            tmp.Add(CommonView.GetGridViewColumn("Cell", "Cell", 75, 12));//3
            tmp.Add(CommonView.GetGridViewColumn("Total", "Total", 75, 13, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));//0
            tmp.Add(CommonView.GetGridViewColumn("NetAmt", "NetAmunt", 80, 14, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));//0
            tmp.Add(CommonView.GetGridViewBoolColumn ("Cash", "Cash", 50, 15));//3
            tmp.Add(CommonView.GetGridViewColumn("GId", "GId", 0, 16));//3
            tmp.Add(CommonView.GetGridViewColumn("TallyCompName", "TallyCompName", 0, 17));//3
            tmp.Add(CommonView.GetGridViewColumn("TallySubGrpNAme", "TallySubGrpNAme", 0, 18));//3

             tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

        public DataTable PurPostDetFill_Source(int PurId)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_PurPostDetTallyImport", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;



            MyParam = new SqlParameter("@PurId", SqlDbType.Int);
            MyParam.Value = PurId ;
            MyCmd.Parameters.Add(MyParam);


            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);


            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "PurDet";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }


        public DataTable SalFill_Source(DateTime FDt, DateTime ToDt)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_SalTallyImport", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;



            MyParam = new SqlParameter("@FrmDt", SqlDbType.DateTime);
            MyParam.Value = FDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);


            MyParam = new SqlParameter("@ToDt", SqlDbType.DateTime);
            MyParam.Value = ToDt.ToString("dd/MMM/yyyy");
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);


            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Sales";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public int SalFill_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("MinNo", "MinNo", 75, 0, true));//0
            tmp.Add(CommonView.GetGridViewColumn("MaxNo", "MaxNo", 75, 1, true));//0
            tmp.Add(CommonView.GetGridViewColumn("BillDt", "BillDt", 100, 2, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yyyy"));//0
            tmp.Add(CommonView.GetGridViewColumn("Narration", "Narration", 100, 3));//3
            tmp.Add(CommonView.GetGridViewColumn("TallyHead", "TallyHead", 105, 4));//3
            tmp.Add(CommonView.GetGridViewColumn("NetAmt", "NetAmunt", 80, 5, true, DataGridViewContentAlignment.MiddleRight, "###0.00"));//0
            tmp.Add(CommonView.GetGridViewColumn("GId", "GId", 0, 6));//3
            tmp.Add(CommonView.GetGridViewColumn("TallyCompName", "TallyCompName", 0, 7));//3

            //tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

        public DataTable SalPostDetFill_Source(DateTime BillDt)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_SalPostDetTallyImport", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;



            MyParam = new SqlParameter("@BillDt", SqlDbType.DateTime);
            MyParam.Value = BillDt;
            MyCmd.Parameters.Add(MyParam);


            MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);


            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "SalDet";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }
        # endregion

        public void SaveFunction(Saving.SaveType Mode)
        {

            DataSet Ds = new DataSet();
            string DetStr;
            Ds.Tables.Add(UserMapDet);
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
                Cmd = new SqlCommand("usermapsp", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@Mode", SqlDbType.TinyInt);
                param.Value = Modeval;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@MapId", SqlDbType.SmallInt);
                param.Value = _MapId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DoctorId", SqlDbType.Int);
                param.Value = _DoctorId;
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


        public bool FetchRecord(int Id)
        {
            SqlConnection Con = new SqlConnection(Common.ConStr);
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("qry_userMaphdr", Con);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("@Mapid ", SqlDbType.Int);
            param.Value = Id;
            Cmd.Parameters.Add(param);
            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);
            SqlDataReader rd = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (rd.Read())
            {

                _MapId = (short)rd.GetValue(rd.GetOrdinal("MapId"));
                _DoctorId = (int)rd.GetValue(rd.GetOrdinal("DoctorId"));
                //_DoctorName = (string)rd.GetValue(rd.GetOrdinal("DoctorName"));
                //_UserId = (int)rd.GetValue(rd.GetOrdinal("UserId"));
                //_UserName = (string)rd.GetValue(rd.GetOrdinal("UserName"));
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

        #region "For View Record"


        public System.Collections.Hashtable _FilteringValues = new System.Collections.Hashtable();
        _ViewValues _View;
        public struct _ViewValues
        {
            public System.Collections.Hashtable FilteringValues;
            public string TableNames;
            public string Fields;
            public string Conditions;
            public string OrderBy;
        }
        public void SetViewControl()
        {
            _FilteringValues.Clear();

            _View.FilteringValues = _FilteringValues;
            _View.TableNames = "UserMaphdrFn("+ Common.CId+")";
            _View.Fields = "*";
            _View.Conditions = "MapId>0" ;
            _View.OrderBy = "MapId";
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
            tmp.Add(CommonView.GetGridViewColumn("MapId", "MapId", 0,1));
            tmp.Add(CommonView.GetGridViewColumn("DoctorId", "DoctorId", 0,2));
            tmp.Add(CommonView.GetGridViewColumn("DoctorName", "DoctorName", 240, 3,true,DataGridViewContentAlignment.MiddleLeft ,"", DataGridViewAutoSizeColumnMode.Fill ));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "compid", 0,4));//, false, HorizontalAlignment.Right));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }
        #endregion
        #region "Navigation"
        public DataTable navigate()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("select top 100 * from UserMaphdrFn(" + Common.CId + ") where MapId > 0 order by MapId desc", Con);
            Cmd.CommandType = CommandType.Text;
            SqlParameter param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);
            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "navigate";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }
        #endregion
    }

}

