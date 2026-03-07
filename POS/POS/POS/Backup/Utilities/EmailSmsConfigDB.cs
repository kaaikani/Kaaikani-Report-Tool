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
    public class EmailSmsConfigDB
    {
        public EmailSmsConfigDB()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        # region "Properties"

        string _EmailID;
        public string EmailID
        {
            get
            {
                return _EmailID;
            }
            set
            {
                _EmailID = value;
            }
        }
        string _EmailPassword;
        public string EmailPassword
        {
            get
            {
                return _EmailPassword;
            }
            set
            {
                _EmailPassword = value;
            }
        }

        private string _SmsUserId;

        public string SmsUserId
        {
            get { return _SmsUserId; }
            set { _SmsUserId = value; }
        }


        private string _SmsPassword;

        public string SmsPassword
        {
            get { return _SmsPassword; }
            set { _SmsPassword = value; }
        }

        private string _SmsDomain;

        public string SmsDomain
        {
            get { return _SmsDomain; }
            set { _SmsDomain = value; }
        }



        private string _SmsSenderId;

        public string SmsSenderId
        {
            get { return _SmsSenderId; }
            set { _SmsSenderId = value; }
        }


        # endregion

        # region "Save"
        public void SaveFunction()
        {



            try
            {
                SqlConnection Con = new SqlConnection(Common.ConStr);
                SqlDataAdapter Da = new SqlDataAdapter();
                Con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("EmailSmsConfigSp", Con);
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@EmailID", SqlDbType.VarChar, 100);
                param.Value = _EmailID;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@EmailPassword", SqlDbType.VarChar, 100);
                param.Value = _EmailPassword;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@SmsUserId", SqlDbType.VarChar, 100);
                param.Value = _SmsUserId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@SmsPassword", SqlDbType.VarChar, 100);
                param.Value = _SmsPassword  ;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@SmsDomain", SqlDbType.VarChar, 300);
                param.Value = _SmsDomain;
                Cmd.Parameters.Add(param);


                param = new SqlParameter("@SmsSenderId", SqlDbType.VarChar, 100);
                param.Value = _SmsSenderId ;
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
        public DataTable RptEmail_Source(int id)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_EmailConfiguration", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@ConfigId", SqlDbType.Int);
            MyParam.Value = id;
            MyCmd.Parameters.Add(MyParam);


            MyParam = new SqlParameter("@compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Qry_EmailConfiguration";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }
        # endregion


        # region "Fetch Section"

        public bool FetchRecord(int Id)
        {
            SqlConnection Con = new SqlConnection(Common.ConStr);
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_EmailSmsConfig", Con);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("@ConfigId", SqlDbType.Int);
            param.Value = Id;
            Cmd.Parameters.Add(param);
            param = new SqlParameter("@compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);
            SqlDataReader rd = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (rd.Read())
            {

                // _ConfigId = (int)rd.GetValue(rd.GetOrdinal("ConfigId"));
                _EmailID = (string)rd.GetValue(rd.GetOrdinal("EmailID"));
                _EmailPassword = (string)rd.GetValue(rd.GetOrdinal("EmailPassword"));
                _SmsPassword = (string)rd.GetValue(rd.GetOrdinal("SmsPassword"));
                _SmsUserId = (string)rd.GetValue(rd.GetOrdinal("SmsUserId"));
                _SmsSenderId = (string)rd.GetValue(rd.GetOrdinal("SmsSenderId"));
                _SmsDomain = (string)rd.GetValue(rd.GetOrdinal("SmsDomain"));
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


        public DataTable SMSSelect_Source(int TemplateId)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_SMSTempSelect", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@TemplateId", SqlDbType.Int);
            MyParam.Value = TemplateId;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@compid", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "SMSTemplate";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

    }
}
