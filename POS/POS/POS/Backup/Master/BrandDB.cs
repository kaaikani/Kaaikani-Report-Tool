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
    public class BrandDB
    {
        public BrandDB()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        
    # region "Properties"
        int _BrandId;
        public int BrandId
        {
            get
            {
                return _BrandId;
            }
            set
            {
                _BrandId = value;
            }
        }
        string _BrandName;
        public string BrandName
        {
            get
            {
                return _BrandName;
            }
            set
            {
                _BrandName = value;
            }
        }
        decimal _ARatePer;
        public decimal ARatePer
        {
            get
            {
                return _ARatePer;
            }
            set
            {
                _ARatePer = value;
            }
        }

        decimal _BRatePer;
        public decimal BRatePer
        {
            get
            {
                return _BRatePer;
            }
            set
            {
                _BRatePer = value;
            }
        }
        decimal _CRatePer;
        public decimal CRatePer
        {
            get
            {
                return _CRatePer;
            }
            set
            {
                _CRatePer = value;
            }
        }
        decimal _DRatePer;
        public decimal DRatePer
        {
            get
            {
                return _DRatePer;
            }
            set
            {
                _DRatePer = value;
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
        # region "Save"
        public int SaveFunction(Saving.SaveType Mode)
        {
            int code;
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
                Cmd = new SqlCommand("BrandSp", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@Mode", SqlDbType.TinyInt);
                param.Value = Modeval;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@BrandId", SqlDbType.SmallInt);
                param.Value = _BrandId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@BrandName", SqlDbType.VarChar, 50);
                param.Value = _BrandName.Replace("'", "''");
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@ARatePer", SqlDbType.Decimal);
                param.Value = _ARatePer;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@BRatePer", SqlDbType.Decimal);
                param.Value = _BRatePer;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CRatePer", SqlDbType.Decimal);
                param.Value = _CRatePer;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DRatePer", SqlDbType.Decimal);
                param.Value = _DRatePer;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.TinyInt);
                param.Value = Common.UserId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CompId", SqlDbType.TinyInt);
                param.Value = Common.CId;
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
        # endregion

        public DataTable Brand_Source()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("select * from BrandMasterfn(" + Common.CId + ") where BrandId > 0 ", Con);
            Cmd.CommandType = CommandType.Text;

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "BrandName";
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
                    case "DateTime":
                        Col.DefaultValue = DateTime.Today;
                        Col.AllowDBNull = true;
                        break;
                }
            }

            return Tbl;
        }

        public int Brand_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("BrandId", "BrandId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("BrandName", "BrandName", 120, 2, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("ARatePer", "ARate%", 80, 3, false, DataGridViewContentAlignment.MiddleRight, "0.00"));
            tmp.Add(CommonView.GetGridViewColumn("BRatePer", "BRate%", 80,4, false, DataGridViewContentAlignment.MiddleRight, "0.00"));
            tmp.Add(CommonView.GetGridViewColumn("CRatePer", "CRate%", 80, 5, false, DataGridViewContentAlignment.MiddleRight, "0.00"));
            tmp.Add(CommonView.GetGridViewColumn("DRatePer", "DRate%", 80, 6, false, DataGridViewContentAlignment.MiddleRight, "0.00"));
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 7, false, DataGridViewContentAlignment.MiddleRight, "0.00"));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 8, false, DataGridViewContentAlignment.MiddleRight, "0.00"));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
            return 0;
        }

        # region "Fetch Section"
  
        public bool FetchRecord(int Id)
        {
            SqlConnection Con = new SqlConnection(Common.ConStr);
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_Brand", Con);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("@BrandId", SqlDbType.Int);
            param.Value = Id;
            Cmd.Parameters.Add(param);
            param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);
            SqlDataReader rd = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (rd.Read())
            {

                _BrandId = (int)rd.GetValue(rd.GetOrdinal("BrandId"));
                _BrandName = (string)rd.GetValue(rd.GetOrdinal("BrandName"));
                _ARatePer = (decimal)rd.GetValue(rd.GetOrdinal("ARatePer"));
                _BRatePer = (decimal)rd.GetValue(rd.GetOrdinal("BRatePer"));
                _CRatePer = (decimal)rd.GetValue(rd.GetOrdinal("CRatePer"));
                _DRatePer = (decimal)rd.GetValue(rd.GetOrdinal("DRatePer"));                
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

        public void UpdateBrandwiseRate(int BrandId,decimal CostRate,decimal SalRate)
        {
            try
            {
                SqlConnection Con = new SqlConnection(Common.ConStr);
                SqlDataAdapter Da = new SqlDataAdapter();
                Con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("UpdateBrandRateSp", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@BrandId", SqlDbType.Int);
                param.Value = BrandId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CostRate", SqlDbType.Decimal);
                param.Value = CostRate;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@SalRate", SqlDbType.Decimal);
                param.Value = SalRate;
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
    }
}
