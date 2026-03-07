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
    public class ProcessOffLineDB
    {
        public ProcessOffLineDB()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        # region "Properties"

        int _PId;
        public int PId
        {
            get
            {
                return _PId;
            }
            set
            {
                _PId = value;
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

        # region "FillDocRef"

        public DataTable FillDocRefSource(string MasDBName,byte UserId)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.ConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("FillDocRef", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@MasDBName", SqlDbType.VarChar,20);
            MyParam.Value = MasDBName ;
            MyCmd.Parameters.Add(MyParam);

            MyParam = new SqlParameter("@UserId", SqlDbType.TinyInt);
            MyParam.Value = Common.UserId;
            MyCmd.Parameters.Add(MyParam);

            //MyParam = new SqlParameter("@Compid", SqlDbType.TinyInt);
            //MyParam.Value = Common.CId;
            //MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "FillDocRef";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }



        #endregion

        # region "Purchase"
        public void OffLinePur(DateTime FromDt, DateTime ToDt, string DocRef)
        {
            try
            {
                SqlConnection Con = new SqlConnection(Common.LnkConStr);
                SqlDataAdapter Da = new SqlDataAdapter();
                Con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("Acc_OffLineDayPostSpPur", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@FromDt", SqlDbType.DateTime);
                param.Value = FromDt.ToString("dd/MMM/yyyy");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@ToDt", SqlDbType.DateTime);
                param.Value = ToDt.ToString ("dd/MMM/yyyy");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DocRef", SqlDbType.Char, 5);
                param.Value = DocRef;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Est", SqlDbType.Bit);
                param.Value = 1;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.TinyInt);
                param.Value = Common.UserId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@compId", SqlDbType.TinyInt);
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
        #endregion

        # region "Purchase Return"
        public void OffLinePurRet(DateTime FromDt, DateTime ToDt, string DocRef)
        {

            try
            {
                SqlConnection Con = new SqlConnection(Common.LnkConStr);
                SqlDataAdapter Da = new SqlDataAdapter();
                Con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("Acc_OffLineDayPostSpPurRet", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@FromDt", SqlDbType.DateTime);
                param.Value = FromDt.ToString("dd/MMM/yyyy");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@ToDt", SqlDbType.DateTime);
                param.Value = ToDt.ToString("dd/MMM/yyyy");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DocRef", SqlDbType.Char, 5);
                param.Value = DocRef;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.TinyInt);
                param.Value = Common.UserId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@compId", SqlDbType.TinyInt);
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
        #endregion
       
        # region "Sales"
        public void OffLineSales(DateTime FromDt, DateTime ToDt, string DocRef)
        {

            try
            {
                SqlConnection Con = new SqlConnection(Common.LnkConStr);
                SqlDataAdapter Da = new SqlDataAdapter();
                Con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("Acc_OffLineDayPostSpSal", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@FromDt", SqlDbType.DateTime);
                param.Value = FromDt.ToString("dd/MMM/yyyy");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@ToDt", SqlDbType.DateTime);
                param.Value = ToDt.ToString("dd/MMM/yyyy");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DocRef", SqlDbType.Char, 5);
                param.Value = DocRef;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Est", SqlDbType.Bit);
                param.Value = 1;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@userid", SqlDbType.TinyInt);
                param.Value = Common.UserId;
                Cmd.Parameters.Add(param);


                param = new SqlParameter("@compId", SqlDbType.TinyInt);
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
                #endregion

        # region "Sales Return"
        public void OffLineSalRet(DateTime FromDt, DateTime ToDt, string DocRef)
        {

            try
            {
                SqlConnection Con = new SqlConnection(Common.LnkConStr);
                SqlDataAdapter Da = new SqlDataAdapter();
                Con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("Acc_OffLineDayPostSpSalRet", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@FromDt", SqlDbType.DateTime);
                param.Value = FromDt.ToString("dd/MMM/yyyy");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@ToDt", SqlDbType.DateTime);
                param.Value = ToDt.ToString("dd/MMM/yyyy");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DocRef", SqlDbType.Char, 5);
                param.Value = DocRef;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.TinyInt);
                param.Value = Common.UserId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@compId", SqlDbType.TinyInt);
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
        #endregion

        # region "Payment"
        public void OffLinePayment(DateTime FromDt, DateTime ToDt, string DocRef,bool TextilePay)
        {

            try
            {
                SqlConnection Con = new SqlConnection(Common.LnkConStr);
                SqlDataAdapter Da = new SqlDataAdapter();
                Con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("Acc_OffLineDayPostSpPay", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@FromDt", SqlDbType.DateTime);
                param.Value = FromDt.ToString("dd/MMM/yyyy");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@ToDt", SqlDbType.DateTime);
                param.Value = ToDt.ToString("dd/MMM/yyyy");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DocRef", SqlDbType.Char, 5);
                param.Value = DocRef;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@TextilePay", SqlDbType.Bit);
                param.Value = TextilePay;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Est", SqlDbType.Bit);
                param.Value = 1;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.TinyInt);
                param.Value = Common.UserId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@compId", SqlDbType.TinyInt);
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
        #endregion

        # region "Receipt"
        public void OffLineReceipt(DateTime FromDt, DateTime ToDt, string DocRef)
        {

            try
            {
                SqlConnection Con = new SqlConnection(Common.LnkConStr);
                SqlDataAdapter Da = new SqlDataAdapter();
                Con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("Acc_OffLineDayPostSpRec", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@FromDt", SqlDbType.DateTime);
                param.Value = FromDt.ToString("dd/MMM/yyyy");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@ToDt", SqlDbType.DateTime);
                param.Value = ToDt.ToString("dd/MMM/yyyy");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DocRef", SqlDbType.Char, 5);
                param.Value = DocRef;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Est", SqlDbType.Bit);
                param.Value = 1;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@userid", SqlDbType.TinyInt);
                param.Value = Common.UserId;
                Cmd.Parameters.Add(param);


                param = new SqlParameter("@compId", SqlDbType.TinyInt);
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
             #endregion

        # region "Journal"
        public void OffLineJournal(DateTime FromDt, DateTime ToDt, string DocRef)
        {

            try
            {
                SqlConnection Con = new SqlConnection(Common.LnkConStr);
                SqlDataAdapter Da = new SqlDataAdapter();
                Con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("Acc_OffLineDayPostSpJou", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@FromDt", SqlDbType.DateTime);
                param.Value = FromDt.ToString("dd/MMM/yyyy");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@ToDt", SqlDbType.DateTime);
                param.Value = ToDt.ToString("dd/MMM/yyyy");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DocRef", SqlDbType.Char, 5);
                param.Value = DocRef;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@userid", SqlDbType.TinyInt);
                param.Value = Common.UserId;
                Cmd.Parameters.Add(param);


                param = new SqlParameter("@compId", SqlDbType.TinyInt);
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
             #endregion

        # region "DayBook"
        public void OffLineDayBook(DateTime FromDt, DateTime ToDt, string DocRef)
        {

            try
            {
                SqlConnection Con = new SqlConnection(Common.LnkConStr);
                SqlDataAdapter Da = new SqlDataAdapter();
                Con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("Acc_OffLineDayPostSpDB", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@FromDt", SqlDbType.DateTime);
                param.Value = FromDt.ToString("dd/MMM/yyyy");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@ToDt", SqlDbType.DateTime);
                param.Value = ToDt.ToString("dd/MMM/yyyy");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DocRef", SqlDbType.Char, 5);
                param.Value = DocRef;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@userid", SqlDbType.TinyInt);
                param.Value = Common.UserId;
                Cmd.Parameters.Add(param);


                param = new SqlParameter("@compId", SqlDbType.TinyInt);
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
            #endregion
    }
}
