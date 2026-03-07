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
    /// 
     
    public class BooksDB 
    {
        public BooksType RefType;
        string Ref;
        //public BooksDB()
        //{
        //}
        public BooksDB(BooksType Refference)
        {
            //
            // TODO: Add constructor logic here
            RefType = Refference;
            switch (RefType)
            {
                case BooksType.Journal:
                    Ref = "JR";
                    break;
                case BooksType.Contra:
                    Ref = "CT";
                    break;
                case BooksType.DebitNote:
                    Ref = "DN";
                    break;
                case BooksType.CreditNote:
                    Ref = "CN";
                    break;
                case BooksType.CashReceipt:
                    Ref = "CR";
                    break;
                case BooksType.BankReceipt:
                    Ref = "BR";
                    break;
                case BooksType.CashReceiptOnSales:
                    Ref = "CS";
                    break;
                case BooksType.BankReceiptOnSales:
                    Ref = "BS";
                    break;
                case BooksType.CashPayment:
                    Ref = "CP";
                    break;
                case BooksType.BankPayment:
                    Ref = "BP";
                    break;
                case BooksType.DayBook:
                    Ref = "DB";
                    break;

            }

            //
    }

    # region "Property"



       public enum BooksType
        {

            Journal,
            Contra,
            DebitNote,
            CreditNote,
            CashReceipt,
            BankReceipt,
            CashPayment,
            BankPayment,
            DayBook,
            CashReceiptOnSales,
            BankReceiptOnSales
        };

         enum LedgerType
         {
        //'Journal
        //'Contra
        //'Cash
        //'Bank
        //'Customer
        //'Party
        //'All
        //'Rec
        Journal,
        Contra,
        Cash,
        Bank,
        CashPayRec,
        BankPayRec,
        PayRec,
        Customer,
        Party,
        All,
        Rec
         }
         enum DrCr
         {
        Credit,
        Debit,
        Null
         }
        Guid _DocID;
        public Guid DocID
         {
             get
             {
                 return _DocID;
             }
             set
             {
                 _DocID = value;
             }
         }
        int _DocNo;
        public int DocNo
         {
             get
             {
                 return _DocNo;
             }
             set
             {
                 _DocNo = value;
             }
         }
        DateTime _DocDt;
        public DateTime DocDt
         {
             get
             {
                 return _DocDt;
             }
             set
             {
                 _DocDt = value;
             }
         }
        double _Amt;
        public double Amt
         {
             get
             {
                 return _Amt;
             }
             set
             {
                 _Amt = value;
             }
         }
        Guid _RefID;
        public Guid RefID
         {
             get
             {
                 return _RefID;
             }
             set
             {
                 _RefID = value;
             }
         }
        string _Nar;
        public string Nar
         {
             get
             {
                 return _Nar;
             }
             set
             {
                 _Nar = value;
             }
         }

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

        string _SAccode;
        public string SAccode
         {
             get
             {
                 return _SAccode;
             }
             set
             {
                 _SAccode = value;
             }
         }

        int _BudgetAppId;
        public int BudgetAppId
         {
             get
             {
                 return _BudgetAppId;
             }
             set
             {
                 _BudgetAppId = value;
             }
         }
        //  struct _ViewValues
        //  {
        //FilteringValues ;
        //string TableNames;
        //string Fields ;
        //string Conditions ;
        //      string OrderBy;
        //  }

        //_ViewValues _View;
        //public _ViewValues vi
        //  {
        //      get
        //      {
        //          return _View;
        //      }
        //      set
        //      {
        //          _View = value;
        //      }
        //  }

        Boolean _ReconFlag;
        public Boolean ReconFlag
          {
              get
              {
                  return _ReconFlag;
              }
              set
              {
                  _ReconFlag = value;
              }
          }
    
    
    #endregion


        //public DataTable LedgerSelectTbl(LedgerType LedType)
        //{
        //    DataTable Tbl = new DataTable();
        //    SqlConnection Con = new SqlConnection(Common.ConStr);
        //    SqlDataAdapter Da = new SqlDataAdapter();
        //    Con.Open();
        //    SqlCommand Cmd;
        //    string selledtype;
        //    selledtype = (LedType == LedgerType.Journal ? "Journal" : (LedType == LedgerType.Contra ? "Contra" : (LedType == LedgerType.Cash ? "Cash" : (LedType == LedgerType.Bank ? "Bank" : (LedType = LedgerType.Customer ? "Customer" : (LedType == LedgerType.Party ? "Party" : (LedType = LedgerType.Rec ? "Rec" : "All")))))));
        //    Cmd = new SqlCommand("Acc_Qry_LedgerSelectFn", Con);
        //    Cmd.CommandType = CommandType.StoredProcedure;

        //    SqlParameter Param = new SqlParameter("@Type", SqlDbType.VarChar,50);
        //    Param.Value = selledtype;
            
        //    Cmd.Parameters.Add(Param);

        //    Param = new SqlParameter("@compid", SqlDbType.TinyInt);
        //    Param.Value = Common.CId;
        //Cmd.Parameters.Add(Param);

      
        //    Da.SelectCommand = Cmd;
        //    Da.Fill(Tbl);
        //    Tbl.TableName = "OPBalDet";
        //    Da.Dispose();
        //    Cmd.Dispose();
        //    Con.Close();
          
        //    return Tbl;
        //}

        DataTable _DetTbl;
        public DataTable DetTbl
          {
              get
              {
                  return _DetTbl;
              }
              set
              {
                  _DetTbl = value;
              }
          }

       // public void save(Saving.SaveType Mode)
       // {
       //      DataSet DetDs;
       // DataSet RefDetDs ;
       // DataSet CostDetDs;
       //  If ( Mode == Saving.SaveType.Add || Mode == Saving.SaveType.Edit)
       //     {
       //     DetDs.Tables.Clear();

       //     DetDs.Tables.Add(DetTbl);
       //     XmlDetStr = DetDs.GetXml;
       //     DetDs.Dispose();

       //     RefDetDs.Tables.Clear();
       //     RefDetDs.Tables.Add(DayRefDetDb.RefDetTbl);
       //     XmlRefDetStr = RefDetDs.GetXml;

       //     If (DayRefDetDb.RefDetTbl.Rows.Count > 0)
       //     {
       //         If (_DocID != (DayRefDetDb.RefDetTbl.Rows(0)(11)== null? 0: DayRefDetDb.RefDetTbl.Rows(0)(11)))
       //     {   
       //         XmlRefDetStr = "";
       //     }
             
       //     }
            
       //     RefDetDs.Dispose();

       //     //'CostDetDs.Tables.Clear()
       //     //'CostDetDs.Tables.Add(DayCostDetDb.CostDetTbl)
       //     //'XmlCostDetStr = CostDetDs.GetXml
       //     //'CostDetDs.Dispose()
       //     XmlCostDetStr = "";
       // Else
       //     XmlDetStr = "";
       //     XmlRefDetStr = "";
       //     XmlCostDetStr = "";
       //     }
       // }

       //public   void SaveFunction(Saving.SaveType Mode)
       //{
       // Try
       //      {
       //     DetailSave(Mode);
       //     SQL2K.ExecSp("Acc_DaySp " & IIf(Mode = Saving.SaveType.Add, 1, IIf(Mode = Saving.SaveType.Edit, 2, 3)) & ",'" & _DocID.ToString & "'," & _DocNo & ",'" & Format(_DocDt, "dd MMM yyyy") & "' ,'" & Ref & "', '" & RefID.ToString & "' ," & _Amt & ",'" & _Nar & "'," & UserId & "," & LocId & ",'" & XmlDetStr & "','" & XmlRefDetStr & "','" & XmlCostDetStr & "'," & CId & " ")
       //      }

       // Catch (exception ex)
       //      {
       //     Throw ex;
       //      }
       
       // }
  

  
    
       
     





    
    }
}
