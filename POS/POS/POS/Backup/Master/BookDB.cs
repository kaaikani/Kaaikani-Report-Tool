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
    public class BookDB
    {
        public BookDB()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        
    # region "Properties"
        short _BookId;
        public short BookId
        {
            get
            {
                return _BookId;
            }
            set
            {
                _BookId = value;
            }
        }
        string _Book;
        public string Book
        {
            get
            {
                return _Book;
            }
            set
            {
                _Book = value;
            }
        }
        int _StartBillNo;
        public int StartBillNo
        {
            get
            {
                return _StartBillNo;
            }
            set
            {
                _StartBillNo = value;
            }
        }

        int _BillNoSize;
        public int BillNoSize
        {
            get
            {
                return _BillNoSize;
            }
            set
            {
                _BillNoSize = value;
            }
        }
        bool _Closed;
        public bool Closed
        {
            get
            {
                return _Closed;
            }
            set
            {
                _Closed = value;
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
        bool _NonTax;
        public bool NonTax
        {
            get
            {
                return _NonTax;
            }
            set
            {
                _NonTax = value;
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
                Cmd = new SqlCommand("BookDetSp", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@Mode", SqlDbType.TinyInt);
                param.Value = Modeval;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@BookId", SqlDbType.SmallInt);
                param.Value = _BookId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Book", SqlDbType.VarChar, 50);
                param.Value = _Book.Replace("'", "''");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@StartBillNo", SqlDbType.Int);
                param.Value = _StartBillNo;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Closed", SqlDbType.Bit);
                param.Value = _Closed;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@BillNoSize", SqlDbType.Int);
                param.Value = _BillNoSize;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Est", SqlDbType.Int);
                param.Value = _Est;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@NonTax", SqlDbType.Bit);
                param.Value = _NonTax;
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
   
        # region "Fetch Section"
  
        public bool FetchRecord(int Id)
        {
            SqlConnection Con = new SqlConnection(Common.ConStr);
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_BookDet", Con);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("@BookId", SqlDbType.SmallInt);
            param.Value = Id;
            Cmd.Parameters.Add(param);
            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);
            SqlDataReader rd = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (rd.Read())
            {

                _BookId = (short)rd.GetValue(rd.GetOrdinal("BookId"));
                _Book = (string)rd.GetValue(rd.GetOrdinal("Book"));
                _StartBillNo = (int)rd.GetValue(rd.GetOrdinal("StartBillNo"));
                _Closed = (bool)rd.GetValue(rd.GetOrdinal("Closed"));
                _BillNoSize = (int)rd.GetValue(rd.GetOrdinal("BillNoSize"));
                _Est = (bool)rd.GetValue(rd.GetOrdinal("Est"));
                _NonTax = (bool)rd.GetValue(rd.GetOrdinal("NonTax"));
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
            Cmd = new SqlCommand("Select Top 100 * From BookDetVwFn(" + Common.CId + ") where BookId > 0 order by BookId desc", Con);
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
            _View.TableNames = "BookDetVwFn(" + Common.CId + ")";
            _View.Fields = "*";
            _View.Conditions = "BookId > 0";
        }

     
        public int View_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("BookId", "BookId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Book", "Book", 150, 2, true,DataGridViewContentAlignment.MiddleLeft,"",DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("StartBillNo", "Start No.", 100, 3, true));
            tmp.Add(CommonView.GetGridViewBoolColumn("Closed", "Closed", 50, 4, true));
            tmp.Add(CommonView.GetGridViewColumn("BillNoSize", "BillNoSize", 100, 5, true));
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 6, true));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 7, true));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

        public int Search_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("BookId", "BookId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Book", "Book", 150, 2, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("StartBillNo", "Start No.", 100, 3, true));
            tmp.Add(CommonView.GetGridViewBoolColumn("Closed", "Closed", 50, 4, true));
            tmp.Add(CommonView.GetGridViewColumn("BillNoSize", "BillNoSize", 100, 5, true));
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 6, true));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 7, true));

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
