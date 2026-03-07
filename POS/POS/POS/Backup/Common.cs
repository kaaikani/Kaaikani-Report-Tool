using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;



namespace RLPOSDB
{
	/// <summary>
	/// Summary description for Common.
	/// </summary>
	public class Common
	{
		public Common()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static string DataBase;
		public static string MasDataBase;   
		public static string DBServer;
        public static string LnkDBServer;
		public static string UserName;
		public static string Password;
        public static string CustDataBase;
		public static int UserId;
		public static int LocId;
		public static bool SearchAll;
		public static string _SpString;
		public static int CId;
        public static int configqty;
        //public static int configcopy;
        public static string BckPath1;


		public static GridStructures._Def.ColorScheme YrnColorStyle  ;											
		public static GridStructures._Def.ColorScheme ProdColorStyle ;
		public static GridStructures._Def.ColorScheme AcsColorStyle ;
		public static GridStructures._Def.ColorScheme ExpColorStyle ;
        public static GridStructures._Def.ColorScheme BrownColorStyle ;

		public static bool Pooling;
        public static RLPOSDB.ConfigurationDB comobj = new ConfigurationDB();
        public static DataTable GenConfig = new DataTable();
        public static DataTable PurConfig = new DataTable();
        public static DataTable SalConfig = new DataTable();
        public static DataTable QuotConfig = new DataTable();
        public static DataTable EstConfig = new DataTable();
        public static bool WtItem = false;
        public static bool AllowDisc = false;
        public static bool AllowTax = false;
        public static bool AllowFree = false;
        public static bool AllowExpiryDt = false;
        public static bool AllowSize = false;
        public static bool AllowMRP = false;
        public static bool MultiSRate = false;
        public static bool ShowSalMan = false;
        public static bool SingleRate = false;
        public static bool ShowCalcPer = false;
        public static bool AutoGenCode = false;
        public static bool AutoMasterCode = false;
        public static bool RateEnter = false;
        public static bool RateLock = false;
        public static bool AllowDesc = false;
        public static bool AllowUnit = false;
        public static bool IsAutoSaleStk = true;
        public static string HeaderName1="";
        public static string HeaderName2 = "";
        public static string DetailHeaderSelection = "";
        public static string QtyFormat;
        public static bool AllowPurDisc = false;
        public static bool AllowSalDisc = false;
        public static bool AllowSalRetDisc = false;
        public static bool AllowPurFree = false;
        public static bool AllowSalFree = false;
        public static bool AllowPurRetFree = false;
        public static bool AllowSalRetFree = false;
        public static bool AllowSalDesc = false;
        public static bool AllowPurDesc = false;     
        public static bool StkChecking = false;
        public static bool RateOption = false;
        public static int DefaultBookId;
        public static int DefaultCatId;
        public static int CSTTaxId;
        public static bool AllowUpcCode = false;
        public static bool IncDec = false;
        public static bool CalcRatePer = false;
        public static bool AllowBrand = false;
        public static bool AllowCategory = false;
        public static bool ShowCategoryinSales = false;
        public static bool ShowBrandinSales = false;
        public static string StockReportOn = "";
        public static bool PrinterMode = false;
        public static string PrnModelId = "";
        public static bool AllowCess = false;
        public static bool ESales = false;
		internal static string ConStr
		{
			get
			{
				string pool;
				pool=(Pooling==true)? "":";pooling=false";
				return "user id=" + UserName + ";password=" + Password + ";initial catalog=" + DataBase + ";data source=" + DBServer+ pool;
			}
		}
																																														 
		internal static string MasConStr
		{
			get
			{
				return "user id=" + UserName + ";password=" + Password + ";initial catalog=" + MasDataBase + ";data source=" + DBServer;
			}
		}
        internal static string LnkConStr
        {
            get
            {
                string pool;
                pool = (Pooling == true) ? "" : ";pooling=false";
                return "user id=" + UserName + ";password=" + Password + ";initial catalog=" + DataBase+"A" + ";data source=" + LnkDBServer + pool;
            }
        }

        internal static string CustConStr
        {
            get
            {
                string pool;
                pool = (Pooling == true) ? "" : ";pooling=false";
                return "user id=" + UserName + ";password=" + Password + ";initial catalog=" + CustDataBase + ";data source=" + DBServer + pool;
            }
        }
		

        public static DataGridTextBoxColumn GetSIMColumn(string MappingName, string HeaderText, int Width, string RefName, GridStructures._Def.ColorScheme ClrScheme)
        {
            bool ColumnReadOnly = false;
            
            SIM.DataGridSIMTextBoxColumn Col = new SIM.DataGridSIMTextBoxColumn(ClrScheme);
            Col.MappingName = MappingName;
            Col.HeaderText = HeaderText;
            Col.ColumnFSIM.RefName = RefName;
            Col.ColumnFSIM.BackColor = System.Drawing.Color.Cornsilk;
            Col.Width = Width;
            if (Width == 0) Col.ReadOnly = ColumnReadOnly;
            //		   Col.ReadOnly = true;
            return Col;
        }


        public static DataGridTextBoxColumn GetSIMColumn(string MappingName, string HeaderText, int Width, string RefName, GridStructures._Def.ColorScheme ClrScheme, bool ColumnReadOnly)
        {
            //bool ColumnReadOnly=false;
            SIM.DataGridSIMTextBoxColumn Col = new SIM.DataGridSIMTextBoxColumn(ClrScheme);
            Col.MappingName = MappingName;
            Col.HeaderText = HeaderText;
            Col.ColumnFSIM.RefName = RefName;
            Col.Width = Width;
            Col.ColumnFSIM.ReadOnly = true;
            //if (Width == 0) Col.ReadOnly = ColumnReadOnly;
            //		   Col.ReadOnly = true;
            return Col;
        }

       
        public static DataGridTextBoxColumn GetSIMColumn(string MappingName, string HeaderText, int Width, string RefName, string FilterIds, GridStructures._Def.ColorScheme ClrScheme)
        {
            bool ColumnReadOnly = false;
            SIM.DataGridSIMTextBoxColumn Col = new SIM.DataGridSIMTextBoxColumn(ClrScheme);
            Col.MappingName = MappingName;
            Col.HeaderText = HeaderText;
            Col.ColumnFSIM.RefName = RefName;
            Col.ColumnFSIM.FilterIds = FilterIds;

            Col.Width = Width;
            if (Width == 0) Col.ReadOnly = ColumnReadOnly;
            return Col;
        }


		public static DataGridTextBoxColumn GetColumn(string	MappingName,string HeaderText,int Width) 
		{
			bool ColumnReadOnly=false;
            bool ColumnEnabled = false;
			DataGridTextBoxColumn Col = new DataGridTextBoxColumn();
			Col.MappingName = MappingName;
			Col.HeaderText = HeaderText;
			Col.Width = Width;
            
			if (Width == 0) Col.ReadOnly = ColumnReadOnly;
            if (Width == 0) Col.TextBox.Enabled = ColumnEnabled;
			
            return Col;
		}
		public static DataGridTextBoxColumn GetColumn(string	MappingName,string HeaderText,int Width,bool ColumnReadOnly) 
		{
			//ColumnReadOnly=false;
			DataGridTextBoxColumn Col = new DataGridTextBoxColumn();
			Col.MappingName = MappingName;
			Col.HeaderText = HeaderText;
			Col.Width = Width;
			Col.ReadOnly = ColumnReadOnly;
			if (Width == 0)  Col.ReadOnly = ColumnReadOnly;
            if (Width == 0) Col.TextBox.Enabled = false ;
			return Col;
		}
        public static DataGridTextBoxColumn GetColumn(string MappingName, string HeaderText, int Width, bool ColumnReadOnly,bool ColumnEnabled)
        {
            //ColumnReadOnly=false;
            DataGridTextBoxColumn Col = new DataGridTextBoxColumn();
            Col.MappingName = MappingName;
            Col.HeaderText = HeaderText;
            Col.Width = Width;
            Col.ReadOnly = ColumnReadOnly;
            Col.TextBox.Enabled = ColumnEnabled;
            if (Width == 0) Col.ReadOnly = ColumnReadOnly;
            if (Width == 0) Col.TextBox.Enabled = ColumnEnabled;
            return Col;
        }
		public static DataGridTextBoxColumn GetColumn(string	MappingName,string HeaderText,int Width,bool ColumnReadOnly,HorizontalAlignment Align) 
		{
			//Align=HorizontalAlignment.Left;
			//ColumnReadOnly=false;
			DataGridTextBoxColumn Col = new DataGridTextBoxColumn();
			Col.MappingName = MappingName;
			Col.HeaderText = HeaderText;
			Col.Width = Width;
			Col.ReadOnly = ColumnReadOnly;
			Col.Alignment = Align;
			if (Width == 0)  Col.ReadOnly = ColumnReadOnly;
            if (Width == 0) Col.TextBox.Enabled = false;
			return Col;
		}


		public static DataGridBoolColumn GetBoolColumn(string MappingName, string HeaderText,int Width)  
		{
			DataGridBoolColumn BCol = new DataGridBoolColumn();
            BCol.MappingName = MappingName;
            BCol.HeaderText = HeaderText;
            BCol.Width = Width;
			BCol.AllowNull=false;
            return BCol;
         }

		public static DataGridTextBoxColumn GetColumn(string	MappingName,string HeaderText,int Width,bool ColumnReadOnly,HorizontalAlignment Align,string Format) 
		{
			//Align=HorizontalAlignment.Left;			
			//ColumnReadOnly=false;
			//Format="";
			DataGridTextBoxColumn Col = new DataGridTextBoxColumn();
			Col.MappingName = MappingName;
			Col.HeaderText = HeaderText;
			Col.Width = Width;
			Col.ReadOnly = ColumnReadOnly;
            
            
			Col.Alignment = Align;
			if (Format !=  "") Col.Format = Format;
			if (Width == 0)  Col.ReadOnly = ColumnReadOnly;
			return Col;
		}

        
        public static DataGridTextBoxColumn GetDecColumn(string MappingName, string HeaderText, int Width, bool ColumnReadOnly, HorizontalAlignment Align, string Format)
        {
            //Align=HorizontalAlignment.Left;			
            //ColumnReadOnly=false;
            //Format="";
            DataGridTextBoxColumn Col = new DataGridTextBoxColumn();
            Col.MappingName = MappingName;
            Col.HeaderText = HeaderText;
            Col.Width = Width;
            Col.ReadOnly = ColumnReadOnly;

            if (Format != "") Col.Format = Format;
            Col.Alignment = Align;

            DataTable dtbl = new DataTable();
            int Size;
            string Size1;
            CommonTransDb CDB = new CommonTransDb();

            dtbl = CDB.QtyDicimalPlace();
            if (dtbl.Rows.Count >= 0)
            {
                Size1 =(string)dtbl.Rows[0][0];
                if (Size1 == "")
                    Size = 0;
                else
                    Size = Convert.ToInt16(Size1);
            }
            else
                Size = 3;

            if (Size == 0) 
                Col.Format ="#####0";
            else if (Size ==1)
                Col.Format = "#####0.0";
            else if (Size == 2)
                Col.Format = "#####0.00";
            else
                Col.Format = "#####0.000";
            
            if (Width == 0) Col.ReadOnly = ColumnReadOnly;
            return Col;
        }

        public static DataGridTextBoxColumn GetColumn(string MappingName, string HeaderText, int Width, bool ColumnReadOnly, HorizontalAlignment Align, string Format,bool ColEnabled )
        {
            //Align=HorizontalAlignment.Left;			
            //ColumnReadOnly=false;
            //Format="";
            DataGridTextBoxColumn Col = new DataGridTextBoxColumn();
            Col.MappingName = MappingName;
            Col.HeaderText = HeaderText;
            Col.Width = Width;
            Col.ReadOnly = ColumnReadOnly;

            Col.TextBox.Enabled = ColEnabled;
            Col.Alignment = Align;
            if (Format != "") Col.Format = Format;
            if (Width == 0) Col.ReadOnly = ColumnReadOnly;
            return Col;
        }


		public  static DataGridTableStyle SetColor(DataGridTableStyle tmp,GridStructures._Def.ColorScheme ColorStyle ) 
		{
			//tmp=new DataGridTableStyle();
			tmp.HeaderFont = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
			tmp.BackColor=ColorStyle.GridBackColor;
			tmp.AlternatingBackColor=ColorStyle.GridAlternatingBackColor;
			tmp.ForeColor=ColorStyle.GridForeColor;
			tmp.GridLineColor=ColorStyle.GridGridLineColor;
			tmp.HeaderBackColor=ColorStyle.GridHeaderBackColor;
			tmp.HeaderForeColor=ColorStyle.GridHeaderForeColor;
			
//			tmp.HeaderFont = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
//			tmp.AlternatingBackColor = System.Drawing.Color.FromArgb((byte)225, (byte)204,(byte)179);
//			tmp.GridLineColor = System.Drawing.Color.FromArgb((byte)101, (byte)9,(byte)51);
//			tmp.ForeColor = System.Drawing.Color.FromArgb(( byte)101,  (byte)9, (byte)51);
//			//        ' tmp.HeaderBackColor = System.Drawing.Color.FromArgb(CType(132, Byte), CType(73, Byte), CType(41, Byte));
//			tmp.HeaderBackColor = System.Drawing.Color.FromArgb((byte)101,(byte)9,(byte)51);
//			tmp.HeaderForeColor = System.Drawing.Color.Snow;
//			tmp.RowHeaderWidth = 1;
//			//        'tmp.GridLineStyle = DataGridLineStyle.None;
//			//
//			//        ' tmp.BackColor = Color.MistyRose;
//			//        'tmp.HeaderForeColor = Color.SaddleBrown;
//			//        ' tmp.AllowSorting = False;
			return tmp;
		}
 
		public static DataGridTextBoxColumn SetLength(DataGridTextBoxColumn Clm,int Length)
		{
			Clm.TextBox.MaxLength=Length;
			return Clm;
		}

        public static DataGridTextBoxColumn GetDateColumn(string MappingName, string HeaderText, int Width)
        {
            bool ColumnReadOnly = false;
            DataGridTextBoxColumn Col = new DataGridTextBoxColumn();
            Col.MappingName = MappingName;
            Col.HeaderText = HeaderText;
            Col.Width = Width;
            if (Width == 0) Col.ReadOnly = ColumnReadOnly;
            return Col;
        }



        public static object GetFSIMColumn(string p, string p_2, int p_3, GridStructures._Def.ColorScheme colorScheme)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        public static object GetSIMColumn(string p, string p_2, int p_3, GridStructures._Def.ColorScheme colorScheme)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        public static void SetDefaults(DataTable Tbl)
        {
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
                }
            }
        }
    }
}
