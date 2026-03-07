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
	public class ShortCutConfigDB
	{
        public ShortCutConfigDB()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		# region "Properties"

      
        
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

        DataTable _ShortCut;
        public DataTable ShortCut
        {
            get
            {
                return _ShortCut;
            }
            set
            {
                _ShortCut = value;
            }
        }
       

# endregion

        
        public void SaveFunction()
        {

            int code;
            DataSet Ds = new DataSet();
            string DetStr;
          
            Ds.Tables.Add(this.ShortCut);
            DetStr = Ds.GetXml();
            DetStr = DetStr.Replace("'", "''");
            DetStr = DetStr.Replace("true", "1");
            DetStr = DetStr.Replace("false", "0");
            Ds.Tables.Clear();
            Ds.Dispose();

            //int Modeval = 0;
            //if (Mode == Saving.SaveType.Add)
            //    Modeval = 1;
            //else if (Mode == Saving.SaveType.Edit)
            //    Modeval = 2;
            //else if (Mode == Saving.SaveType.Delete)
            //    Modeval = 3;
            //else if (Mode == Saving.SaveType.DocCancel)
            //    Modeval = 8;

            try
            {
                SqlConnection Con = new SqlConnection(Common.MasConStr);
                SqlDataAdapter Da = new SqlDataAdapter();
                Con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("ShortCutSp", Con);
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@Detstr", SqlDbType.Text);
                param.Value = DetStr;
                Cmd.Parameters.Add(param);


                param = new SqlParameter("@UserID", SqlDbType.TinyInt);
                param.Value =_UserId;
                Cmd.Parameters.Add(param);

                param = new SqlParameter("@CompID", SqlDbType.TinyInt);
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


        # region "Detail Section"

        public DataTable ShortCutDetSource(byte UserId)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.MasConStr);
            MyCon.Open();


            MyCmd = new SqlCommand("Qry_shortCutDet", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@UserId", SqlDbType.TinyInt);
            MyParam.Value = UserId;
            MyCmd.Parameters.Add(MyParam);
          
            MyParam = new SqlParameter("@compId", SqlDbType.TinyInt);
            MyParam.Value = Common.CId;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "ShortCut";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            //return DTbl;

            Common.SetDefaults(DTbl);
            return DTbl;
            
        }

        public int ShortCutDet_GridStyle(DataGridViewColumnCollection tmp)
        {
            
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("ShortCutID", "ShortCutID", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("KeyValue", "KeyValue", 80, 2,false,DataGridViewContentAlignment.MiddleLeft,""));
            tmp.Add(CommonView.GetGridViewColumn("Caption", "Caption", 100, 3, false, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("BtnPos", "BtnPos", 0, 4, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("BtnSiz", "BtnSiz", 0, 5, true, DataGridViewContentAlignment.MiddleRight, ""));
            tmp.Add(CommonView.GetGridViewColumn("UserId", "UserId", 0, 6, false, DataGridViewContentAlignment.MiddleRight, ""));
            tmp.Add(CommonView.GetGridViewColumn("FrmID", "FrmID", 0, 7, false, DataGridViewContentAlignment.MiddleRight, ""));
            tmp.Add(CommonView.GetGridViewColumn("CompID", "CompID", 0, 8, false, DataGridViewContentAlignment.MiddleRight, ""));
            tmp.Add(CommonView.GetGridViewBoolColumn("MnuVisible", "MnuVisible", 0, 9,false));
            tmp.Add(CommonView.GetGridViewBoolColumn("SlNo", "SlNo", 0, 10, false));
          
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
            return 0;
        } 
        # endregion
        

        # region "SecDet"
        public DataTable SecDet_Source(byte userid)
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.MasConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_SecDetSelect", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

            MyParam = new SqlParameter("@userid", SqlDbType.TinyInt);
            MyParam.Value = userid;
            MyCmd.Parameters.Add(MyParam);

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Party";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public int SecDet_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("FrmId", "FrmId", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("FormSecName", "FormSecName", 200, 2, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("KeyValue", "KeyValue", 100, 3, true,DataGridViewContentAlignment.MiddleLeft,""));
            tmp.Add(CommonView.GetGridViewColumn("BtnPos", "BtnPos", 100, 4, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("BtnSiz", "BtnSiz", 100, 5, true, DataGridViewContentAlignment.MiddleLeft, ""));

           
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
            return 0;
        }

        public DataTable SecHdr_Source()
        {
            SqlConnection MyCon = new SqlConnection();
            SqlCommand MyCmd = new SqlCommand();
            SqlParameter MyParam = new SqlParameter();
            SqlDataAdapter MyAdapt = new SqlDataAdapter();
            DataTable DTbl = new DataTable();

            MyCon = new SqlConnection(Common.MasConStr);
            MyCon.Open();

            MyCmd = new SqlCommand("Qry_SecHdrSelect", MyCon);
            MyCmd.CommandType = CommandType.StoredProcedure;

          

            MyAdapt.SelectCommand = MyCmd;
            MyAdapt.Fill(DTbl);

            DTbl.TableName = "Party";
            MyAdapt.Dispose();
            MyCmd.Dispose();
            MyCon.Close();
            return DTbl;
        }

        public int SecHdr_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("Userid", "Userid", 0, 1));
            
            tmp.Add(CommonView.GetGridViewColumn("Username", "Username", 200, 2, true, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.Fill));
            tmp.Add(CommonView.GetGridViewColumn("UserTypeId", "UserTypeid", 0, 3));
            

            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
            return 0;
        }


     # endregion

    }
}
