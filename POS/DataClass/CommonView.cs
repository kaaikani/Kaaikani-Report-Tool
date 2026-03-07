using System.Windows.Forms;



namespace DataClass
{
    public class CommonView
    {
        public static string Customer;
        public static string Address;
        public static string Pincode;
        public static string CellNo;
        public static string DBServer;
        public static string DataBase;
        public static string UId;
        public static string Pwd;
        public static string Port;
        public static string PaymentId;
        public static string OrderId;
        public static string Signature;
        public static string Amount;
        public static string PaymentType;
        public CommonView()
        {
            //
            // TODO: Add constructor logic here
            

        }
        private static string _FontName="Bamini";
        public static string FontName
        {
            get { return CommonView._FontName; }
            set { CommonView._FontName = value; }
        }
        private static int _FontSize = 18;
        public static int FontSize
        {
            get { return CommonView._FontSize; }
            set { CommonView._FontSize = value; }
        }

        public static DataGridViewTextBoxColumn GetGridViewColumn(string MappingName, string HeaderText, int Width, int DisplayPosition)
        {
            DataGridViewTextBoxColumn Col = new DataGridViewTextBoxColumn();
            Col.Name = MappingName;
            Col.HeaderText = HeaderText;
            Col.Width = Width;
            //Col.ReadOnly = ColumnReadOnly;
            //Col.AutoSizeMode = Sizemode;
            Col.DisplayIndex = DisplayPosition;
            //Col.DefaultCellStyle.Alignment = Align;
            //if (Formatting)
            //{
            //    Col.DefaultCellStyle.Format = "######0.00";
            //    Col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //}
            //if (DtFormat)
            //{
            //    Col.DefaultCellStyle.Format = "dd/MMM/yyyy";
            //}
            Col.DefaultCellStyle.NullValue = " ";

            Col.DataPropertyName = MappingName;
            //if (Visible)
            //{
            //    Col.MinimumWidth = 2;
            //}
            //Col.ReadOnly = true;
            if (Width == 0)
            {
                Col.Visible = false;
            }
            else
            {
                Col.Visible = true;
            }
            return (Col);
        }
      
        //
        //public static DataGridViewDateColumn GetGridViewDateColumn(string MappingName, string HeaderText, int Width, int DisplayPosition,string Format)
        //{
        //    DataGridViewDateColumn Col = new DataGridViewDateColumn();
        //    Col.Name = MappingName;
        //    Col.HeaderText = HeaderText;
        //    Col.Width = Width;
            
        //    Col.DisplayIndex = DisplayPosition;       
        //    Col.DefaultCellStyle.NullValue = " ";
        //    Col.DataPropertyName = MappingName;
        //    Col.DefaultCellStyle.Format = Format; 
        //    if (Width == 0)
        //    {
        //        Col.Visible = false;
        //    }
        //    else
        //    {
        //        Col.Visible = true;
        //    }
        //    return (Col);
        //}

        //public static DataGridViewDateColumn GetGridViewDateColumn(string MappingName, string HeaderText, int Width, int DisplayPosition, string Format,bool ColumnReadOnly)
        //{
        //    DataGridViewDateColumn Col = new DataGridViewDateColumn();
        //    Col.Name = MappingName;
        //    Col.HeaderText = HeaderText;
        //    Col.Width = Width;

        //    Col.DisplayIndex = DisplayPosition;
        //    Col.ReadOnly = ColumnReadOnly;
        //    Col.DefaultCellStyle.NullValue = " ";

        //    Col.DataPropertyName = MappingName;

        //    Col.DefaultCellStyle.Format = Format;
        //    if (Width == 0)
        //    {
        //        Col.Visible = false;
        //    }
        //    else
        //    {
        //        Col.Visible = true;
        //    }
        //    return (Col);
        //}

 
        public static DataGridViewTextBoxColumn GetGridViewColumn(string MappingName, string HeaderText, int Width, int DisplayPosition, bool ColumnReadOnly)
        {
            DataGridViewTextBoxColumn Col = new DataGridViewTextBoxColumn();
            Col.Name = MappingName;
            Col.DataPropertyName = MappingName; 
            Col.HeaderText = HeaderText;
            Col.Width = Width;
            Col.ReadOnly = ColumnReadOnly;
            Col.DisplayIndex = DisplayPosition;
            Col.DefaultCellStyle.NullValue = " ";
            Col.DataPropertyName = MappingName;
            Col.ReadOnly = ColumnReadOnly;
            if (Width == 0)
            {
                Col.Visible = false;
            }
            else
            {
                Col.Visible = true;
            }
            return (Col);
        }
      //
        public static DataGridViewTextBoxColumn GetGridViewColumn(string MappingName, string HeaderText, int Width, int DisplayPosition, bool ColumnReadOnly,DataGridViewColumnSortMode ColumnSort)
        {
            DataGridViewTextBoxColumn Col = new DataGridViewTextBoxColumn();
            Col.Name = MappingName;
            Col.DataPropertyName = MappingName; 
            Col.HeaderText = HeaderText;
            Col.Width = Width;
            Col.ReadOnly = ColumnReadOnly;
            Col.DisplayIndex = DisplayPosition;
            Col.DefaultCellStyle.NullValue = " ";
            Col.DataPropertyName = MappingName;
            Col.ReadOnly = ColumnReadOnly;
            Col.SortMode = ColumnSort;
            if (Width == 0)
            {
                Col.Visible = false;
            }
            else
            {
                Col.Visible = true;
            }
            return (Col);
        }
        public static DataGridViewTextBoxColumn GetGridViewColumn(string MappingName, string HeaderText, int Width, int DisplayPosition, bool ColumnReadOnly, DataGridViewContentAlignment Align)
        {
            DataGridViewTextBoxColumn Col = new DataGridViewTextBoxColumn();
            Col.Name = MappingName;
            Col.HeaderText = HeaderText;
            Col.Width = Width;
            Col.ReadOnly = ColumnReadOnly;
            Col.DisplayIndex = DisplayPosition;
            Col.DefaultCellStyle.Alignment = Align;
            Col.DefaultCellStyle.NullValue = " ";
            Col.DataPropertyName = MappingName;
            Col.ReadOnly = ColumnReadOnly;
            if (Width == 0)
            {
                Col.Visible = false;
            }
            else
            {
                Col.Visible = true;
            }
            return (Col);
        }

        public static DataGridViewTextBoxColumn GetGridViewColumn(string MappingName, string HeaderText, int Width, int DisplayPosition, bool ColumnReadOnly, DataGridViewContentAlignment Align, string Formatting)
        {
            DataGridViewTextBoxColumn Col = new DataGridViewTextBoxColumn();
            Col.Name = MappingName;
            Col.HeaderText = HeaderText;
            Col.Width = Width;
            Col.ReadOnly = ColumnReadOnly;
            Col.DisplayIndex = DisplayPosition;
            Col.DefaultCellStyle.Alignment = Align;
            if (Formatting.Trim().Length>0)
            {
                Col.DefaultCellStyle.Format = Formatting;
                Col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            Col.DefaultCellStyle.NullValue = " ";
            Col.DataPropertyName = MappingName;
            Col.ReadOnly = ColumnReadOnly;
            if (Width == 0)
            {
                Col.Visible = false;
            }
            else
            {
                Col.Visible = true;
            }
            return (Col);
        }

        public static DataGridViewComboBoxColumn GetGridComboColumn(string MappingName, string HeaderText, int Width, int DisplayPosition, bool ColumnReadOnly, DataGridViewContentAlignment Align, string Formatting)
        {
            DataGridViewComboBoxColumn Col = new DataGridViewComboBoxColumn();
            Col.Name = MappingName;
            Col.HeaderText = HeaderText;
            Col.Width = Width;
            Col.ReadOnly = ColumnReadOnly;
            Col.DisplayIndex = DisplayPosition;
            Col.DefaultCellStyle.Alignment = Align;
            if (Formatting.Trim().Length > 0)
            {
                Col.DefaultCellStyle.Format = Formatting;
                Col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            Col.DefaultCellStyle.NullValue = " ";
            Col.DataPropertyName = MappingName;
            Col.ReadOnly = ColumnReadOnly;
            if (Width == 0)
            {
                Col.Visible = false;
            }
            else
            {
                Col.Visible = true;
            }
            return (Col);
        }

      //
        public static DataGridViewTextBoxColumn GetGridViewColumn(string MappingName, string HeaderText, int Width, int DisplayPosition, bool ColumnReadOnly, DataGridViewContentAlignment Align, string Formatting, DataGridViewColumnSortMode ColumnSort,string FontName)
        {
            DataGridViewTextBoxColumn Col = new DataGridViewTextBoxColumn();
            Col.Name = MappingName;
            Col.HeaderText = HeaderText;
            Col.Width = Width;
            Col.ReadOnly = ColumnReadOnly;
            //Col.AutoSizeMode = Sizemode;
            Col.DisplayIndex = DisplayPosition;
            Col.DefaultCellStyle.Alignment = Align;
            Col.SortMode = ColumnSort;
            

            //Col.DefaultCellStyle.Format = Formatting;
            if (Formatting.Trim().Length > 0)
            {
                Col.DefaultCellStyle.Format = Formatting;
                Col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            //if (DtFormat)
            //{
            //    Col.DefaultCellStyle.Format = "dd/MMM/yyyy";
            //}
            Col.DefaultCellStyle.NullValue = " ";

            Col.DataPropertyName = MappingName;
            //if (Visible)
            //{
            //    Col.MinimumWidth = 2;
            //}

            Col.ReadOnly = ColumnReadOnly;
            if (Width == 0)
            {
                Col.Visible = false;
            }
            else
            {
                Col.Visible = true;
            }
            return (Col);
        }
        public static DataGridViewTextBoxColumn GetGridViewColumn(string MappingName, string HeaderText, int Width, int DisplayPosition, bool ColumnReadOnly, DataGridViewContentAlignment Align, string Formatting, DataGridViewAutoSizeColumnMode Sizemode, string FontName)
        {
            DataGridViewTextBoxColumn Col = new DataGridViewTextBoxColumn();
            Col.Name = MappingName;
            Col.HeaderText = HeaderText;
            Col.Width = Width;
            Col.ReadOnly = ColumnReadOnly;
            Col.AutoSizeMode = Sizemode;
            Col.DisplayIndex = DisplayPosition;
            Col.DefaultCellStyle.Alignment = Align;
            Col.DataPropertyName = MappingName;
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            System.Drawing.FontFamily f = new System.Drawing.FontFamily(FontName);
            if (f.IsStyleAvailable(System.Drawing.FontStyle.Regular))
                columnHeaderStyle.Font = new System.Drawing.Font(FontName, _FontSize);
            else if (f.IsStyleAvailable(System.Drawing.FontStyle.Bold))
                columnHeaderStyle.Font = new System.Drawing.Font(FontName, _FontSize, System.Drawing.FontStyle.Bold);
            else if (f.IsStyleAvailable(System.Drawing.FontStyle.Italic))
                columnHeaderStyle.Font = new System.Drawing.Font(FontName, _FontSize, System.Drawing.FontStyle.Italic);


            Col.DefaultCellStyle = columnHeaderStyle;

            //Col.DefaultCellStyle.Format = Formatting;
            if (Formatting.Trim().Length > 0)
            {
                Col.DefaultCellStyle.Format = Formatting;
                Col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            Col.DefaultCellStyle.NullValue = " ";
            Col.DataPropertyName = MappingName;
            Col.ReadOnly = ColumnReadOnly;
            if (Width == 0)
            {
                Col.Visible = false;
            }
            else
            {
                Col.Visible = true;
            }
            return (Col);
        }
        public static DataGridViewTextBoxColumn GetGridViewColumn(string MappingName, string HeaderText, int Width, int DisplayPosition, bool ColumnReadOnly, DataGridViewContentAlignment Align, string Formatting, DataGridViewColumnSortMode ColumnSort,bool  IsSizeAdjust)
        {
            DataGridViewTextBoxColumn Col = new DataGridViewTextBoxColumn();
            Col.Name = MappingName;
            Col.HeaderText = HeaderText;
            Col.Width = Width;
            Col.ReadOnly = ColumnReadOnly;
            //Col.AutoSizeMode = Sizemode;
            Col.DisplayIndex = DisplayPosition;
            Col.DefaultCellStyle.Alignment = Align;
            Col.SortMode = ColumnSort;

            if (IsSizeAdjust == true)
            {
                Col.DefaultCellStyle.Font = new System.Drawing.Font("CourierNew", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                Col.HeaderCell.Style.Font = new System.Drawing.Font("CourierNew", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }

            //Col.DefaultCellStyle.Format = Formatting;
            if (Formatting.Trim().Length > 0)
            {
                Col.DefaultCellStyle.Format = Formatting;
                Col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            //if (DtFormat)
            //{
            //    Col.DefaultCellStyle.Format = "dd/MMM/yyyy";
            //}
            Col.DefaultCellStyle.NullValue = " ";

            Col.DataPropertyName = MappingName;
            //if (Visible)
            //{
            //    Col.MinimumWidth = 2;
            //}

            Col.ReadOnly = ColumnReadOnly;
            if (Width == 0)
            {
                Col.Visible = false;
            }
            else
            {
                Col.Visible = true;
            }
            return (Col);
        }

        public static DataGridViewTextBoxColumn GetGridViewColumn(string MappingName, string HeaderText, int Width, int DisplayPosition, bool ColumnReadOnly, DataGridViewContentAlignment Align,string Formatting,DataGridViewAutoSizeColumnMode Sizemode)
        {
            DataGridViewTextBoxColumn Col = new DataGridViewTextBoxColumn();
            Col.Name = MappingName;
            Col.HeaderText = HeaderText;
            Col.Width = Width;
            Col.ReadOnly = ColumnReadOnly;
            Col.AutoSizeMode = Sizemode;
            Col.DisplayIndex = DisplayPosition;
            Col.DefaultCellStyle.Alignment = Align;
            Col.DataPropertyName = MappingName;
            if (Formatting.Trim().Length>0)
            {
                Col.DefaultCellStyle.Format = Formatting;
                Col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            Col.DefaultCellStyle.NullValue = " ";
            Col.DataPropertyName = MappingName;
            Col.ReadOnly = ColumnReadOnly;
            if (Width == 0)
            {
                Col.Visible = false;
            }
            else
            {
                Col.Visible = true;
            }
            return (Col);
        }

      
        public static DataGridViewCheckBoxColumn GetGridViewBoolColumn(string MappingName, string HeaderText, int Width, int DisplayPosition)
        {
            DataGridViewCheckBoxColumn BCol = new DataGridViewCheckBoxColumn();
            BCol.DataPropertyName = MappingName;
            BCol.Name = MappingName;
            BCol.HeaderText = HeaderText;
            if (Width == 0)
            {
                BCol.Visible = false;
            }
            else
            {
                BCol.Visible = true;
            }
            //BCol.DefaultCellStyle.Alignment = ;
            BCol.ReadOnly = false;
            BCol.DisplayIndex = DisplayPosition;
            return BCol;
        }
        public static DataGridViewCheckBoxColumn GetGridViewBoolColumn(string MappingName, string HeaderText, int Width, int DisplayPosition,bool ReadOnly)
        {
            DataGridViewCheckBoxColumn BCol = new DataGridViewCheckBoxColumn();
            BCol.DataPropertyName = MappingName;
            BCol.Name = MappingName;
            BCol.HeaderText = HeaderText;
            BCol.Width = Width;
            if (Width == 0)
            {
                BCol.Visible = false;
            }
            else
            {
                BCol.Visible = true;
            }
            BCol.ReadOnly = ReadOnly;
            BCol.DisplayIndex = DisplayPosition;
            return BCol;
        }
        //public static DataGridViewSIMTextBoxColumn GetGridViewsimColumn(string MappingName, string HeaderText, string RefName, int Width, int DisplayPosition, GridStructures._Def.ColorScheme colorScheme)
        //{
        //    DataGridViewSIMTextBoxColumn SCol = new DataGridViewSIMTextBoxColumn();
        //    SCol.DataPropertyName = MappingName;
        //    SCol.Name = MappingName;
        //    SCol.HeaderText = HeaderText;
        //    SCol.RefName = RefName;
        //    SCol.ColorStyle = colorScheme;
        //    SCol.Width = Width;
        //    SCol.Visible = true;
        //    SCol.DisplayIndex = DisplayPosition;
        //    return SCol;
        //}
    }

}