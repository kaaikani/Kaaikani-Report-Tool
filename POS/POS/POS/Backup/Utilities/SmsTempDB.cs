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
    public class SmsTempDB
    {
        public SmsTempDB()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        
    # region "Properties"
        int _TemplateId;
        public int TemplateId
        {
            get
            {
                return _TemplateId;
            }
            set
            {
                _TemplateId = value;
            }
        }
        string _TemplateName;
        public string TemplateName
        {
            get
            {
                return _TemplateName;
            }
            set
            {
                _TemplateName = value;
            }
        }

        string _Types;
        public string Types
        {
            get
            {
                return _Types;
            }
            set
            {
                _Types = value;
            }
        }
        int _TemplateNo;
        public int TemplateNo
        {
            get
            {
                return _TemplateNo;
            }
            set
            {
                _TemplateNo = value;
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

        string _TemplateMessage;
        public string TemplateMessage
        {
            get
            {
                return _TemplateMessage;
            }
            set
            {
                _TemplateMessage = value;
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
        # endregion

        # region "Save"
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
                Cmd = new SqlCommand("SMSTemplateSp", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@Mode", SqlDbType.TinyInt);
                param.Value = Modeval;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TemplateId", SqlDbType.Int );
                param.Value = _TemplateId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TemplateNo", SqlDbType.Int );
                param.Value = _TemplateNo;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TemplateName", SqlDbType.VarChar,50 );
                 param.Value = _TemplateName.Replace("'", "''");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TemplateMessage", SqlDbType.NVarChar,100);
                param.Value = _TemplateMessage;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Types", SqlDbType.Char);
                param.Value = "S";
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Hide", SqlDbType.Bit);
                param.Value = (_Hide==true ? 1 : 0);
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.TinyInt);
                param.Value = Common.UserId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CompId", SqlDbType.TinyInt);
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
        # endregion

        public DataTable SmsTemplate(String TemplateName)
        {
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            DataTable DTbl = new DataTable();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_SMSTemplateMsg", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@TemplateName", SqlDbType.VarChar, 20);
            param.Value = TemplateName;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(DTbl);
            DTbl.TableName = "SmsTemplate";
            
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            
            return DTbl;

        }

        # region "Fetch Section"
  
        public bool FetchRecord(int Id)
        {
            SqlConnection Con = new SqlConnection(Common.ConStr);
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_SMSTemplate", Con);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("@TemplateId", SqlDbType.Int );
            param.Value = Id;
            Cmd.Parameters.Add(param);
            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);
            SqlDataReader rd = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (rd.Read())
            {

                _TemplateId = (int)rd.GetValue(rd.GetOrdinal("TemplateId"));
                _TemplateName = (string)rd.GetValue(rd.GetOrdinal("TemplateName"));
                _TemplateNo = (int)rd.GetValue(rd.GetOrdinal("TemplateNo"));
                _TemplateMessage = (string)rd.GetValue(rd.GetOrdinal("TemplateMessage"));
                _Types = (string)rd.GetValue(rd.GetOrdinal("Types"));
                _Hide = (bool)rd.GetValue(rd.GetOrdinal("Hide"));
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
        public DataTable navigate()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Select Top 100 * From SMSTemplateVwFn(" + Common.CId + ") where TemplateId > 0 order by TemplateId desc", Con);
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
            _View.TableNames = "SMSTemplateVwFn(" + Common.CId + ")";
            _View.Fields = "*";
            _View.Conditions = "TemplateId > 0";
        }

     
        public int View_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("TemplateId", "TemplateId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("TemplateNo", "TemplateNo", 50, 2, true));
            tmp.Add(CommonView.GetGridViewColumn("TemplateName", "TemplateName", 100, 3, true));
            tmp.Add(CommonView.GetGridViewColumn("TemplateMessage", "TemplateMessage", 150, 4, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));

            tmp.Add(CommonView.GetGridViewColumn("Types", "Types", 50, 5, true));
            tmp.Add(CommonView.GetGridViewColumn("Hide", "Hide", 40, 6, true));
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 7, true));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 8, true));

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
