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
    public class SubGrpMas2DB
    {
        public SubGrpMas2DB()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        # region "Properties"

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

        public DataTable SubGrp1_Source()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Acc_Qry_SubGrp1Select", Con);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "SubGrp1Select";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }
        public int SubGrp1_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("SubGrpId1", "SubGrpId1", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("SubGroupName", "SubGroupName", 150, 2, true));
            tmp.Add(CommonView.GetGridViewColumn("GrpId", "GrpId", 0, 5, true));
            tmp.Add(CommonView.GetGridViewColumn("GroupName", "GroupName", 150, 2, true));
            
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

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
                Cmd = new SqlCommand("Acc_SubGroup2SP", Con);
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@Mode", SqlDbType.TinyInt);
                param.Value = Modeval;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@SubGrpId2", SqlDbType.Int);
                param.Value = _SubGrpId2;
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

 
        # region "Fetch Section"
        public DataTable navigate()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Select Top 100 * From Acc_SubGroup2vwfn(" + Common.CId + ") where SubGrpId2 > 0 order by SubGrpId2 desc", Con);
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
            Cmd = new SqlCommand("Acc_Qry_SubGroup2", Con);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("@SubGrpId2", SqlDbType.Int);
            param.Value = Id;
            Cmd.Parameters.Add(param);
            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);
            SqlDataReader rd = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (rd.Read())
            {

                _SubGrpId2 = (int)rd.GetValue(rd.GetOrdinal("SubGrpId2"));
                _SubGroupName = (string)rd.GetValue(rd.GetOrdinal("SubGroupName"));
                _SubGrpId1 = (int)rd.GetValue(rd.GetOrdinal("SubGrpId1"));
                _GrpId = (int)rd.GetValue(rd.GetOrdinal("GrpId"));
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
            _View.TableNames = "Acc_SubGroup2vwfn(" + Common.CId + ")";
            _View.Fields = "*";
            _View.Conditions = "SubGrpId2 > 0";
        }

     
        public int SetGrpMasView_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("SubGrpid2", "SubGrpid2", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("SubGroupName", "SubGroupName", 150, 2, true));
            tmp.Add(CommonView.GetGridViewColumn("SubGrpId1", "SubGrpId1", 0, 3, true));
            tmp.Add(CommonView.GetGridViewColumn("GrpId", "GrpId", 0, 4, true));
            tmp.Add(CommonView.GetGridViewColumn("Predefined", "Predefined", 0, 5, true));
            
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
