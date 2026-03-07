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
    public class GrpMasDB
    {
        public GrpMasDB()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        # region "Properties"

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

        string _GroupName;
        public string GroupName
        {
            get
            {
                return _GroupName;
            }
            set
            {
                _GroupName = value;
            }
        }

        string _BsGrp;
        public string BsGrp
        {
            get
            {
                return _BsGrp;
            }
            set
            {
                _BsGrp = value;
            }
        }

        byte _BsOrder;
        public byte BsOrder
        {
            get
            {
                return _BsOrder;
            }
            set
            {
                _BsOrder = value;
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
                Cmd = new SqlCommand("Acc_GroupSP", Con);
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@Mode", SqlDbType.TinyInt);
                param.Value = Modeval;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@GrpId", SqlDbType.Int);
                param.Value = _GrpId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@GroupName", SqlDbType.VarChar, 50);
                param.Value = _GroupName.Replace("'", "''");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@BsGrp", SqlDbType.Char, 1);
                param.Value = _BsGrp;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@BsOrder", SqlDbType.TinyInt);
                param.Value = _BsOrder;
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
            Cmd = new SqlCommand("Select Top 100 * From Acc_GroupVwFn(" + Common.CId + ") where GrpId > 0 order by GrpId desc", Con);
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
            Cmd = new SqlCommand("Acc_Qry_Group", Con);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("@GrpId", SqlDbType.Int);
            param.Value = Id;
            Cmd.Parameters.Add(param);
            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);
            SqlDataReader rd = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (rd.Read())
            {

                _GrpId = (int)rd.GetValue(rd.GetOrdinal("GrpId"));
                _GroupName = (string)rd.GetValue(rd.GetOrdinal("GroupName"));
                _BsGrp = (string)rd.GetValue(rd.GetOrdinal("BsGrp"));
                _BsOrder = (byte)rd.GetValue(rd.GetOrdinal("BsOrder"));
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
            _View.TableNames = "Acc_GroupVwFn(" + Common.CId + ")";
            _View.Fields = "*";
            _View.Conditions = "GrpId > 0";
        }

     
        public int SetGrpMasView_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("Grpid", "Grpid", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("GroupName", "GroupName", 80, 2, true));
            tmp.Add(CommonView.GetGridViewColumn("BsGrp", "BsGrp", 80, 3, true));
            tmp.Add(CommonView.GetGridViewColumn("BsOrder", "BsOrder", 80, 4, true));
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
