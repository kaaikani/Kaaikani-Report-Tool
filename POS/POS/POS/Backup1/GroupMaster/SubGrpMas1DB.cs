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
    public class SubGrpMas1DB
    {
        public SubGrpMas1DB()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        # region "Properties"

        
        int _SubGrpId1;
        public int subGrpId1
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

        string _SubGroupName;
        public string SubGroupName
        {
            get
            {
                return _SubGroupName;
            }
            set
            {
                _SubGroupName = value;
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

        string   _UnderGroup;
        public string  UnderGroup
        {
            get
            {
                return _UnderGroup;
            }
            set
            {
                _UnderGroup = value;
            }
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
                Cmd = new SqlCommand("Acc_SubGroup1Sp", Con);
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@Mode", SqlDbType.TinyInt);
                param.Value = Modeval;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@SubGrpId1", SqlDbType.Int);
                param.Value = _SubGrpId1;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@GrpId", SqlDbType.Int);
                param.Value = _GrpId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@SubGroupName", SqlDbType.VarChar, 50);
                param.Value = _SubGroupName.Replace("'", "''");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.TinyInt);
                param.Value = Common.UserId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CompId", SqlDbType.TinyInt);
                param.Value = 0;
                Cmd.Parameters.Add(param);


                param = new SqlParameter("@UnderGroup", SqlDbType.Char);
                param.Value = _UnderGroup ;
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
            tmp.Add(CommonView.GetGridViewColumn("GroupName", "GroupName",150, 2, true));
            tmp.Add(CommonView.GetGridViewColumn("BsGrp", "BsGrp", 50, 3, true));
           
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

        public DataTable UnderGroupSource(string UnBsGrp)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            
            MyCmd = new SqlCommand("Acc_Qry_UnderGroup", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@UnBsGrp", SqlDbType.Char );
            MyParam.Value = UnBsGrp;
            MyCmd.Parameters.Add(MyParam);


            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "UnderGroup";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }
        # region "Fetch Section"
        public DataTable navigate()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Select Top 100 * From Acc_SubGroup1VWFn(" + Common.CId + ") where SubGrpId1 > 0 order by SubGrpId1 desc", Con);
            Cmd.CommandType = CommandType.Text;

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "navigate";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }

        public bool FetchRecord(int Id)
        {
            SqlConnection Con = new SqlConnection(Common.ConStr);
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Acc_Qry_SubGroup1", Con);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("@SubGrpId1", SqlDbType.Int);
            param.Value = Id;
            Cmd.Parameters.Add(param);
            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);
            SqlDataReader rd = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (rd.Read())
            {

                _SubGrpId1 = (int)rd.GetValue(rd.GetOrdinal("SubGrpId1"));
                _SubGroupName = (string)rd.GetValue(rd.GetOrdinal("SubGroupName"));
                _GrpId = (int)rd.GetValue(rd.GetOrdinal("GrpId"));
                _UserId = (byte)rd.GetValue(rd.GetOrdinal("UserId"));
                _UnderGroup = (string)rd.GetValue(rd.GetOrdinal("UnderGroup"));
                
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
            _View.TableNames = "Acc_SubGroup1VwFn(" + Common.CId + ")";
            _View.Fields = "*";
            _View.Conditions = "SubGrpId1 > 0";
        }

     
        public int SetGrpMasView_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("SubGrpid1", "SubGrpid1", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("SubGroupName", "SubGroupName", 150, 2, true));
            tmp.Add(CommonView.GetGridViewColumn("GrpId", "GrpId", 0, 3, true));
            tmp.Add(CommonView.GetGridViewColumn("Predefined", "Predefined", 0, 4, true));
            tmp.Add(CommonView.GetGridViewColumn("GroupName", "GroupName", 150, 5, true));
            
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
