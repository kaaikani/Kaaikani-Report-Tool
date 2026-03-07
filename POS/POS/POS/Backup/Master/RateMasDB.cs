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
    public class RateMasDB
    {
        public RateMasDB()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        # region "Properties"

        int _RateTypeId;
        public int RateTypeId
        {
            get
            {
                return _RateTypeId;
            }
            set
            {
                _RateTypeId = value;
            }

        }

        string _RateType;
        public string RateType
        {
            get
            {
                return _RateType;
            }
            set
            {
                _RateType = value;
            }

        }

        decimal _Percentage;
        public decimal Percentage
        {
            get
            {
                return _Percentage;
            }
            set
            {
                _Percentage = value;
            }

        }

        bool _DefaultRate;
        public bool DefaultRate
        {
            get
            {
                return _DefaultRate;
            }
            set
            {
                _DefaultRate = value;
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



        public DataTable RateDet_Source(int RateTypeId)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.ConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_RateType", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@RateTypeId", SqlDbType.Int);
            param.Value = RateTypeId;
            Cmd.Parameters.Add(param);

            param = new SqlParameter("@compid", SqlDbType.TinyInt);
            param.Value = Common.CId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "RateType";
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
        public int Rate_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();

            tmp.Add(CommonView.GetGridViewColumn("RateTypeId", "RateTypeId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("RateType", "RateType", 300, 2, false, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("Percentage", "%", 90, 3, false, DataGridViewContentAlignment.MiddleRight, "0.000"));
            tmp.Add(CommonView.GetGridViewBoolColumn("DefaultRate", "DefaultRate", 120, 4));
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 5));
            tmp.Add(CommonView.GetGridViewColumn("CompId", "CompId", 0, 6));

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;

            return 0;
        }

       
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
                Cmd = new SqlCommand("RateTypesp", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@mode", SqlDbType.TinyInt);
                param.Value = Modeval;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@RateTypeId", SqlDbType.Int);
                param.Value = _RateTypeId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@RateType", SqlDbType.VarChar,25);
                param.Value = _RateType;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Percentage", SqlDbType.Decimal);
                param.Value = _Percentage;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@DefaultRate", SqlDbType.Bit);
                param.Value = _DefaultRate;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@UserId", SqlDbType.TinyInt);
                param.Value = Common.UserId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Compid", SqlDbType.TinyInt);
                param.Value = Common.CId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@ID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                Cmd.Parameters.Add(param);

                Cmd.ExecuteNonQuery();
                code = (int)Cmd.Parameters["@ID"].Value;

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

 
    }
}
