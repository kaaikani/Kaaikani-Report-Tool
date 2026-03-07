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
    /// Summary description for ItemDB.
    /// </summary>
    public class SecurityEngineDB
    {
        public SecurityEngineDB()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        # region "Properties"


        int _DocId;
        public int DocId
        {
            get
            {
                return _DocId;
            }
            set
            {
                _DocId = value;
            }
        }

        int _UsrIde;
        public int UsrIde
        {
            get
            {
                return _UsrIde;
            }
            set
            {
                _UsrIde = value;
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

        DataTable _UserDet;
        public DataTable UserDet
        {
            get
            {
                return _UserDet;
            }
            set
            {
                _UserDet = value;
            }
        }

        # endregion
        
        # region "Detail Section"

        # region "UserInfo"
        public DataTable UserNameSource(int usrId)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.MasConStr);
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Qry_UserName", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@UserId", SqlDbType.TinyInt);
            param.Value = usrId;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "Qry_UserName";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }
        //UserId,UserName,UnitId,UserTypeId
        public DataGridTableStyle UserSource_GridStyle()
        {
            DataGridTableStyle tmp = new DataGridTableStyle();
            tmp.MappingName = "Qry_UserName";
            tmp.GridColumnStyles.Add(Common.GetColumn("UserId", "UserId", 70));//0
            tmp.GridColumnStyles.Add(Common.GetColumn("UserName", "UserName", 200, true, false));//0
            tmp.GridColumnStyles.Add(Common.GetColumn("UnitId", "UnitId", 0));//0
            tmp.GridColumnStyles.Add(Common.GetColumn("UserTypeId", "UserTypeId", 70, true, false));//0

            tmp.AllowSorting = false;
            return Common.SetColor(tmp, Common.BrownColorStyle);
        }

        # endregion

        public DataTable TreeUserSource()
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.MasConStr );
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("qry_user", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            //SqlParameter param = new SqlParameter("@compid", SqlDbType.TinyInt);
            //param.Value = Common.CId;
            //Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "qry_user";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }
        public DataGridTableStyle TreeUser_GridStyle()
        {
            DataGridTableStyle tmp = new DataGridTableStyle();
            tmp.MappingName = "qry_user";
            tmp.GridColumnStyles.Add(Common.GetColumn("userid", "UserId",100));//0
            tmp.GridColumnStyles.Add(Common.GetColumn("username", "UserName", 300, true, false));//0
            tmp.AllowSorting = false;
            return Common.SetColor(tmp, Common.BrownColorStyle);
        }
      


        public DataTable GridUserSource(int usrId)
        {
            DataTable Tbl = new DataTable();
            SqlConnection Con = new SqlConnection(Common.MasConStr );
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("qry_users", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@userId", SqlDbType.TinyInt);
            param.Value = usrId ;
            Cmd.Parameters.Add(param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "UserDet";
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
                        Col.DefaultValue =1;
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
                        //Col.DefaultValue = DateTime.Today;
                        Col.DefaultValue = System.DateTime.Now.ToString("dd/MMM/yyyy");

                        Col.AllowDBNull = true;
                        break;
                }
                Tbl.Columns["MenuVisible"].DefaultValue = true;

            }
           
            return Tbl;
        }
        public DataGridTableStyle GridUser_GridStyle()
        {

            //UserId,MenuVisible,Id,FormSecName,Senior,FrmId,
            //Addition,Edition,Deletion,DocCancel,DocPrint,Opening,ShowAud
            DataGridTableStyle tmp = new DataGridTableStyle();
            tmp.MappingName = "UserDet";
            tmp.GridColumnStyles.Add(Common.GetColumn("userid", "UserId", 0,false ,true));//0
            tmp.GridColumnStyles.Add(Common.GetBoolColumn("MenuVisible", "MenuVisible", 100));//0
            tmp.GridColumnStyles.Add(Common.GetColumn("Id", "Id", 0, false, true));//0
            tmp.GridColumnStyles.Add(Common.GetColumn("FormSecName", "Form Name", 200, false, true));//0
            tmp.GridColumnStyles.Add(Common.GetColumn("Senior", "Senior", 0, false, true));//0
            tmp.GridColumnStyles.Add(Common.GetColumn("FrmId", "FrmId", 0, false, true));//0
            tmp.GridColumnStyles.Add(Common.GetBoolColumn("Addition", "Addition", 55));
            tmp.GridColumnStyles.Add(Common.GetBoolColumn("Edition", "Edition", 50));
            tmp.GridColumnStyles.Add(Common.GetBoolColumn("Deletion", "Deletion", 50));
            tmp.GridColumnStyles.Add(Common.GetBoolColumn("DocCancel", "DocCancel", 0));
            tmp.GridColumnStyles.Add(Common.GetBoolColumn("DocPrint", "DocPrint", 80));
            tmp.GridColumnStyles.Add(Common.GetBoolColumn("Opening", "Opening", 0));
            tmp.GridColumnStyles.Add(Common.GetBoolColumn("ShowAud", "ShowAud", 0));
            
            tmp.AllowSorting = false;
            return Common.SetColor(tmp, Common.BrownColorStyle);
        }


        # endregion


        public void SaveFunction(Saving.SaveType Mode)
        {
            DataSet Ds = new DataSet();
            string DetStr;
            Ds.Tables.Add(UserDet);
            DetStr = Ds.GetXml();
            DetStr = DetStr.Replace("'", "''");
            DetStr = DetStr.Replace("true", "1");
            DetStr = DetStr.Replace("false", "0");
            if (DetStr.IndexOf("T00:00:00") != -1)
                DetStr = DetStr.Replace(DetStr.Substring(DetStr.IndexOf("T00:00:00"), 15), "");
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
                SqlConnection Con = new SqlConnection(Common.MasConStr);
                SqlDataAdapter Da = new SqlDataAdapter();
                Con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("UserSP", Con);
                Cmd.CommandType = CommandType.StoredProcedure;

               // @userId int,@Detstr as text

                SqlParameter param = new SqlParameter("@userId", SqlDbType.Int);
                param.Value = UsrIde;
                Cmd.Parameters.Add(param);

                
                param = new SqlParameter("@DetStr", SqlDbType.Text);
                param.Value = DetStr;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@Mode", SqlDbType.TinyInt);
                param.Value = Modeval;
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
                else if (Ex.Message.IndexOf("Cann't Delete It") > -1)
                    throw new Exception("Can Not Delete Admin Types");
                else

                    throw Ex;
            }
        }


      

       
    }

}

