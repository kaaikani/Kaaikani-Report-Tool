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
    public class AchdDB 
    {
        public AchdDB()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        # region "Properties"
       
        struct _ViewValues
        {
         //Dim FilteringValues As Hashtable
        string TableNames ;
        string Fields; 
        string Conditions;
        string OrderBy ; 
        }
        //_ViewValues _View;
        //public _ViewValues ViewValues
        //{
        //    get
        //    {
        //        Return _View;
        //    }
        //     set
        //     {
        //         _View = Value;
        //     }

        //}

        string _Accode;
        public string Accode
        {
            get
            {
                return _Accode;
            }
            set
             {
                  _Accode = value;
             }

        }
        string _Acdesc;
        public string Acdesc
        {
            get
            {
                return _Acdesc;
            }
            set
             {
                 _Acdesc = value;
             }

        }

        string _Senr1;
        public string Senr1
        {
            get
            {
                return _Senr1;
            }

             set
             {
                 _Senr1 = value;
             }

        }
          Boolean _Led;
        public Boolean Led
        {
            get
            {
                return _Led;
            }

             set
             {
                 _Led = value;
             }

        }
          Boolean _Predefined;
        public Boolean Predefined
        {
            get
            {
                return _Predefined;
            }

             set
             {
                 _Predefined = value;
             }

        }

           double _OpBal;
        public double OpBal
        {
            get
            {
                return _OpBal;
            }

             set
             {
                 _OpBal = value;
             }

        }

           string _DrCr;
        public string DrCr
        {
            get
            {
                return _DrCr;
            }

             set
             {
                 _DrCr = value;
             }

        }

               int _BlockId;
        public int BlockId
        {
            get
            {
                return _BlockId;
            }

             set
             {
                 _BlockId = value;
             }

        }

               double _DepVal;
        public double DepVal
        {
            get
            {
                return _DepVal;
            }

             set
             {
                 _DepVal = value;
             }

        }

               int _BudgetId;
        public int BudgetId
        {
            get
            {
                return _BudgetId;
            }

             set
             {
                 _BudgetId = value;
             }

        }

              Boolean _Costing;
        public Boolean Costing
        {
            get
            {
                return _Costing;
            }

             set
             {
                 _Costing = value;
             }

        }

              Boolean _SubLed;
        public Boolean SubLed
        {
            get
            {
                return _SubLed;
            }

             set
             {
                 _SubLed = value;
             }

        }

                  string _Senr3;
        public string Senr3
        {
            get
            {
                return _Senr3;
            }

             set
             {
                 _Senr3 = value;
             }

        }

                  string _Senr2;
        public string Senr2
        {
            get
            {
                return _Senr2;
            }

             set
             {
                 _Senr2 = value;
             }

        }

                  string _FirstLvl;
        public string FirstLvl
        {
            get
            {
                return _FirstLvl;
            }

             set
             {
                 _FirstLvl = value;
             }

        }

                      string _Add1;
        public string Add1
        {
            get
            {
                return _Add1;
            }

             set
             {
                 _Add1 = value;
             }

        }

                      string _Add2;
        public string Add2
        {
            get
            {
                return _Add2;
            }

             set
             {
                 _Add2 = value;
             }

        }

                      string _City;
        public string City
        {
            get
            {
                return _City;
            }

             set
             {
                 _City = value;
             }

        }

                string _Pin;
        public string Pin
        {
            get
            {
                return _Pin;
            }

             set
             {
                 _Pin = value;
             }

        }

                string _ResPh;
        public string ResPh
        {
            get
            {
                return _ResPh;
            }

             set
             {
                 _ResPh = value;
             }

        }

                string _OffPh;
        public string OffPh
        {
            get
            {
                return _OffPh;
            }

             set
             {
                 _OffPh = value;
             }

        }

        
                string _Email;
        public string Email
        {
            get
            {
                return _Email;
            }

             set
             {
                 _Email = value;
             }

        }

        
                string _Fax;
        public string Fax
        {
            get
            {
                return _Fax;
            }

             set
             {
                 _Fax = value;
             }

        }

        
                string _TNGST;
        public string TNGST
        {
            get
            {
                return _TNGST;
            }

             set
             {
                 _TNGST = value;
             }

        }

        
                string _CST;
        public string CST
        {
            get
            {
                return _CST;
            }

             set
             {
                 _CST = value;
             }

        }

        
                string _Bsgrp;
        public string Bsgrp
        {
            get
            {
                return _Bsgrp;
            }

             set
             {
                 _Bsgrp = value;
             }

        }

        DataTable _SubLedDetTbl;
        public DataTable SubLedDetTbl
        {
            get
            {
                return _SubLedDetTbl;
            }

            set
            {
                _SubLedDetTbl = value;
            }

        }

        DataTable _OpRefDetTbl;
        public DataTable OpRefDetTbl
        {
            get
            {
                return _OpRefDetTbl;
            }

            set
            {
                _OpRefDetTbl = value;
            }

        }
#endregion

        public DataTable GroupDt()
        {

            SqlConnection Con = new SqlConnection(Common.ConStr);
            DataTable Tbl = new DataTable();

            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Acc_Qry_GroupVw", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

    

            SqlParameter Param = new SqlParameter("@Compid", SqlDbType.TinyInt);
            Param.Value = Common.CId;
            Cmd.Parameters.Add(Param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "Groupvw";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }
        public int Group_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();

            tmp.Add(CommonView.GetGridViewColumn("Accode", "Accode", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Groups", "Groups", 300, 2, true));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = true;
            return 0;

        }


        public DataTable SCRAreaDt()
        {

            SqlConnection Con = new SqlConnection(Common.ConStr);
            DataTable Tbl = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Acc_Qry_SCRAreaVw", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

           SqlParameter Param = new SqlParameter("@compid", SqlDbType.TinyInt);
            Param.Value = Common.CId;
            Cmd.Parameters.Add(Param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "SCRVw";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }

        public int SCRArea_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();

            tmp.Add(CommonView.GetGridViewColumn("Accode", "Accode", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Area", "Area", 300, 2, true));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = true;
            return 0;

        }


        public DataTable SDRAreaDt()
        {

            SqlConnection Con = new SqlConnection(Common.ConStr);
            DataTable Tbl = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Acc_Qry_SDRAreavw", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter Param = new SqlParameter("@compid", SqlDbType.TinyInt);
            Param.Value = Common.CId;
            Cmd.Parameters.Add(Param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            Tbl.TableName = "SDRVw";
            Da.Dispose();
            Cmd.Dispose();
            Con.Close();
            return Tbl;
        }
        public int SDRArea_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();

            tmp.Add(CommonView.GetGridViewColumn("Accode", "Accode", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("Area", "Area", 300, 2, true));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = true;
            return 0;

        }

        public void LedSaveFunctions(Saving.SaveType Mode)
        {
        try
            {
            DataSet SubLedDs =new DataSet();
            DataSet OpRefDs =new DataSet();
            string XmlSubLedStr, XmlOpRefStr ;
            if (Mode == Saving.SaveType.Add || Mode == Saving.SaveType.Edit) 
            {
                SubLedDs.Clear();
                SubLedDs.Tables.Clear();
                SubLedDs.Tables.Add(SubLedDetTbl);
                //XmlSubLedStr = SubLedDs.GetXml;
                SubLedDs.Dispose();

                OpRefDs.Tables.Clear();
                OpRefDs.Tables.Add(OpRefDetTbl);
                //XmlOpRefStr = OpRefDs.GetXml;
                OpRefDs.Dispose();
            }
                else
            {
                XmlSubLedStr = "";
                XmlOpRefStr = "";
            }

            SubLedDs.Tables.Clear();
            OpRefDs.Tables.Clear();

            //SQL2K.ExecSp("Acc_AchdSp " & IIf(Mode = Saving.SaveType.Add, 1, IIf(Mode = Saving.SaveType.Edit, 2, IIf(Mode = Saving.SaveType.Delete, 3, 6))) & ",'" & _Accode & "','" & _Acdesc & "','" & _Senr1 & "' ," & _OpBal & ",'" & _DrCr & "'," & _BlockId & "," & _DepVal & "," & _BudgetId & "," & IIf(_Costing = True, 1, 0) & "," & IIf(_SubLed = True, 1, 0) & "," & IIf(_Led = True, 1, 0) & "," & UserId & "," & LocId & ",'" & XmlSubLedStr & "','" & XmlOpRefStr & "','" & _Add1 & "','" & _Add2 & "','" & _City & "','" & _Pin & "','" & _ResPh & "','" & _OffPh & "','" & _Email & "','" & _Fax & "','" & _TNGST & "','" & _CST & "'," & CId & ", '" & Common.MasDataBase & "'")
        }
        catch (Exception ex)
        {
            throw ex;
        }   
       
        }

        public Boolean FetchRecord(int Value)
        {

            SqlConnection Con = new SqlConnection(Common.ConStr);
            DataTable Tbl = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Acc_Qry_achd", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter Param = new SqlParameter("@AccId", SqlDbType.Int);
            Param.Value = Value;
            Cmd.Parameters.Add(Param);

             Param = new SqlParameter("@compid", SqlDbType.TinyInt);
            Param.Value = Common.CId;
            Cmd.Parameters.Add(Param);


            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            SqlDataReader Dr;// = new SqlDataReader();
            Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (Dr.Read())
            {

                //_AccId = (int)Dr.GetValue(Dr.GetOrdinal("AccId"));
                //_Accode = (string)Dr.GetValue(Dr.GetOrdinal("Accode"));
                _Acdesc = (string)Dr.GetValue(Dr.GetOrdinal("Ledger"));
                //_Senr1 = (bool)If(Dr.GetValue(10) == null || Dr.GetValue(10) = "" ? Dr.GetValue(3) : Dr.GetValue(4));
                //_OtherState = (bool)Dr.GetValue(Dr.GetOrdinal("OtherState"));
                //_AllComp = (bool)(Dr.GetValue(Dr.GetOrdinal("AllComp")));
                //_GrpId = (int)(Dr.GetValue(Dr.GetOrdinal("GrpId")));
                //_SubGrpId1 = (int)(Dr.GetValue(Dr.GetOrdinal("SubGrpId1")));
                //_SubGrpId2 = (int)Dr.GetValue(Dr.GetOrdinal("SubGrpId2"));
               // _OpBal = (decimal)(Dr.GetValue(Dr.GetOrdinal("OpBal")));
                _DrCr = (string)Dr.GetValue(Dr.GetOrdinal("DrCr"));
                //_CrLimitDays = (short)(Dr.GetValue(Dr.GetOrdinal("CrLimitDays")));
               // _CrLimitAmt = (decimal)(Dr.GetValue(Dr.GetOrdinal("CrLimitAmt")));
                //_FirstLvl =(string)(Dr.GetValue(2)==null? "": Dr.GetValue(2));
                _Add1 = (string)(Dr.GetValue(Dr.GetOrdinal("Add1"))==null? "": Dr.GetValue(Dr.GetOrdinal("Add1")));
                _Add2 = (string)(Dr.GetValue(Dr.GetOrdinal("Add2"))==null? "": Dr.GetValue(Dr.GetOrdinal("Add2")));
               // _Add3 = (string)(Dr.GetValue(Dr.GetOrdinal("Add3")) == null ? "" : Dr.GetValue(Dr.GetOrdinal("Add3")));
                _City = (string)(Dr.GetValue(Dr.GetOrdinal("City")) == null ? "" : Dr.GetValue(Dr.GetOrdinal("City")));
                //_Pincode = (string)(Dr.GetValue(Dr.GetOrdinal("Pincode")) == null ? "" : Dr.GetValue(Dr.GetOrdinal("Pincode")));
                //_AreaId = (int)(Dr.GetValue(Dr.GetOrdinal("AreaId")));
               // _Ph1 = (string)(Dr.GetValue(Dr.GetOrdinal("Ph1")) == null ? "" : Dr.GetValue(Dr.GetOrdinal("Ph1")));
                //_Ph2 = (string)(Dr.GetValue(Dr.GetOrdinal("Ph2")) == null ? "" : Dr.GetValue(Dr.GetOrdinal("Ph2")));
               // _Cell = (string)(Dr.GetValue(Dr.GetOrdinal("Cell")) == null ? "" : Dr.GetValue(Dr.GetOrdinal("Cell")));
               // _TIN = (string)(Dr.GetValue(Dr.GetOrdinal("TIN")) == null ? "" : Dr.GetValue(Dr.GetOrdinal("TIN")));
                _CST = (string)(Dr.GetValue(Dr.GetOrdinal("CST")) == null ? "" : Dr.GetValue(Dr.GetOrdinal("CST")));
                //_Contactperson = (string)(Dr.GetValue(Dr.GetOrdinal("Contactperson")) == null ? "" : Dr.GetValue(Dr.GetOrdinal("Contactperson")));
               /// _ContactCell = (string)(Dr.GetValue(Dr.GetOrdinal("ContactCell")) == null ? "" : Dr.GetValue(Dr.GetOrdinal("ContactCell")));
               // _EMail = (string)(Dr.GetValue(Dr.GetOrdinal("EMail")) == null ? "" : Dr.GetValue(Dr.GetOrdinal("EMail")));
                _Fax = (string)(Dr.GetValue(Dr.GetOrdinal("Fax")) == null ? "" : Dr.GetValue(Dr.GetOrdinal("Fax")));
               // _URL = (string)(Dr.GetValue(Dr.GetOrdinal("URL")) == null ? "" : Dr.GetValue(Dr.GetOrdinal("URL")));
                //_Hide = (bool)(Dr.GetValue(Dr.GetOrdinal("Hide"))); 
               // _BlockId = (short)(Dr.GetValue(Dr.GetOrdinal("BlockId")));
                //_DepnVal = (decimal)(Dr.GetValue(Dr.GetOrdinal("DepnVal")));
                //_BudgetId = (short)(Dr.GetValue(Dr.GetOrdinal("BudgetId")));
               // _Compid = (short)(Dr.GetValue(Dr.GetOrdinal("Compid")));
               // _UserId = (short)(Dr.GetValue(Dr.GetOrdinal("UserId")));
                Dr.Dispose();
            Cmd.Dispose();
            Con.Close();
            return true;
            }
            else
            {
                Dr.Dispose();
            Cmd.Dispose();
            Con.Close();
            return false;
            }
           // Tbl.TableName = "SCRVw";
           
        }

        public Boolean FetchAccode(int userid)
        {

            SqlConnection Con = new SqlConnection(Common.ConStr);
            DataTable Tbl = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter();
            Con.Open();
            SqlCommand Cmd;
            Cmd = new SqlCommand("Acc_Qry_Achdaccodefn", Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter Param = new SqlParameter("@userid", SqlDbType.TinyInt);
            Param.Value = userid;
            Cmd.Parameters.Add(Param);

            Da.SelectCommand = Cmd;
            Da.Fill(Tbl);
            SqlDataReader Dr ;//= new SqlDataReader(CommandBehavior.CloseConnection); 
        Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection);

        if (Dr.Read()) 
        {
            Accode =(string) Dr.GetValue(0);
            //Rs = dbobj.RetRs("*", "Achdaccodefn(" & userid & ")")
            Acdesc = (string)Dr.GetValue(1);
            Dr.Dispose();
            Cmd.Dispose();
            Con.Close();

            return true;
        }
        else
        {
            Dr.Dispose();
            Cmd.Dispose();
            Con.Close();
            return false;
        }
        }

            }
}
