<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCancelRpt
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.DtpFrmDt = New System.Windows.Forms.DateTimePicker()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dtpToDt = New System.Windows.Forms.DateTimePicker()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnProcess = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.chkAll = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtFilter2 = New System.Windows.Forms.TextBox()
        Me.txtFilter1 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbFilter2 = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmbFilter1 = New System.Windows.Forms.ComboBox()
        Me.RlItemDet = New RLComponents.ExRlGridView()
        Me.Panel13.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.RlItemDet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblHeader
        '
        Me.lblHeader.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.lblHeader.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold)
        Me.lblHeader.ForeColor = System.Drawing.Color.MintCream
        Me.lblHeader.Location = New System.Drawing.Point(1, 2)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(999, 29)
        Me.lblHeader.TabIndex = 3
        Me.lblHeader.Text = "Cancel Report"
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel13
        '
        Me.Panel13.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel13.Controls.Add(Me.Label8)
        Me.Panel13.Location = New System.Drawing.Point(85, 33)
        Me.Panel13.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(53, 28)
        Me.Panel13.TabIndex = 12474
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(1, 2)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 21)
        Me.Label8.TabIndex = 12344
        Me.Label8.Text = "From"
        '
        'Panel14
        '
        Me.Panel14.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel14.Controls.Add(Me.DtpFrmDt)
        Me.Panel14.Location = New System.Drawing.Point(137, 33)
        Me.Panel14.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(118, 28)
        Me.Panel14.TabIndex = 12475
        '
        'DtpFrmDt
        '
        Me.DtpFrmDt.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpFrmDt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFrmDt.Location = New System.Drawing.Point(-1, -1)
        Me.DtpFrmDt.Name = "DtpFrmDt"
        Me.DtpFrmDt.Size = New System.Drawing.Size(118, 29)
        Me.DtpFrmDt.TabIndex = 12349
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.dtpToDt)
        Me.Panel1.Location = New System.Drawing.Point(306, 33)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(118, 28)
        Me.Panel1.TabIndex = 12477
        '
        'dtpToDt
        '
        Me.dtpToDt.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpToDt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToDt.Location = New System.Drawing.Point(-1, -1)
        Me.dtpToDt.Name = "dtpToDt"
        Me.dtpToDt.Size = New System.Drawing.Size(118, 29)
        Me.dtpToDt.TabIndex = 12349
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(254, 33)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(53, 28)
        Me.Panel2.TabIndex = 12476
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 21)
        Me.Label1.TabIndex = 12344
        Me.Label1.Text = "To"
        '
        'btnProcess
        '
        Me.btnProcess.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btnProcess.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnProcess.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnProcess.ForeColor = System.Drawing.Color.MintCream
        Me.btnProcess.Location = New System.Drawing.Point(429, 32)
        Me.btnProcess.Name = "btnProcess"
        Me.btnProcess.Size = New System.Drawing.Size(126, 31)
        Me.btnProcess.TabIndex = 12478
        Me.btnProcess.Text = "Process"
        Me.btnProcess.UseVisualStyleBackColor = False
        '
        'Panel5
        '
        Me.Panel5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel5.BackColor = System.Drawing.Color.Transparent
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel5.Controls.Add(Me.chkAll)
        Me.Panel5.Controls.Add(Me.Label9)
        Me.Panel5.Controls.Add(Me.txtFilter2)
        Me.Panel5.Controls.Add(Me.txtFilter1)
        Me.Panel5.Controls.Add(Me.Label10)
        Me.Panel5.Controls.Add(Me.Label11)
        Me.Panel5.Controls.Add(Me.cmbFilter2)
        Me.Panel5.Controls.Add(Me.Label12)
        Me.Panel5.Controls.Add(Me.cmbFilter1)
        Me.Panel5.Location = New System.Drawing.Point(1, 65)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(999, 69)
        Me.Panel5.TabIndex = 12480
        '
        'chkAll
        '
        Me.chkAll.AutoSize = True
        Me.chkAll.BackColor = System.Drawing.Color.Transparent
        Me.chkAll.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAll.Location = New System.Drawing.Point(3, 1)
        Me.chkAll.Name = "chkAll"
        Me.chkAll.Size = New System.Drawing.Size(78, 19)
        Me.chkAll.TabIndex = 12486
        Me.chkAll.Text = "Select All"
        Me.chkAll.UseVisualStyleBackColor = False
        Me.chkAll.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(248, 40)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 17)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Condition"
        Me.Label9.Visible = False
        '
        'txtFilter2
        '
        Me.txtFilter2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFilter2.Location = New System.Drawing.Point(324, 37)
        Me.txtFilter2.Name = "txtFilter2"
        Me.txtFilter2.Size = New System.Drawing.Size(18, 25)
        Me.txtFilter2.TabIndex = 11
        Me.txtFilter2.Visible = False
        '
        'txtFilter1
        '
        Me.txtFilter1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFilter1.Location = New System.Drawing.Point(86, 37)
        Me.txtFilter1.Name = "txtFilter1"
        Me.txtFilter1.Size = New System.Drawing.Size(204, 25)
        Me.txtFilter1.TabIndex = 10
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(12, 40)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(69, 17)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Condition"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(250, 11)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(67, 17)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "Search By"
        Me.Label11.Visible = False
        '
        'cmbFilter2
        '
        Me.cmbFilter2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFilter2.FormattingEnabled = True
        Me.cmbFilter2.Location = New System.Drawing.Point(324, 5)
        Me.cmbFilter2.Name = "cmbFilter2"
        Me.cmbFilter2.Size = New System.Drawing.Size(18, 25)
        Me.cmbFilter2.TabIndex = 7
        Me.cmbFilter2.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(12, 11)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(67, 17)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "Search By"
        '
        'cmbFilter1
        '
        Me.cmbFilter1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFilter1.FormattingEnabled = True
        Me.cmbFilter1.Location = New System.Drawing.Point(86, 5)
        Me.cmbFilter1.Name = "cmbFilter1"
        Me.cmbFilter1.Size = New System.Drawing.Size(204, 25)
        Me.cmbFilter1.TabIndex = 1
        '
        'RlItemDet
        '
        Me.RlItemDet.AddNew = True
        Me.RlItemDet.AllowMouseHoverEffect = False
        Me.RlItemDet.AllowNew = True
        Me.RlItemDet.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.RlItemDet.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.RlItemDet.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RlItemDet.Cancelled = False
        Me.RlItemDet.ColumnHeadersHeight = 30
        Me.RlItemDet.DelRights = False
        Me.RlItemDet.DowncolumnIndex = 0
        Me.RlItemDet.DowncolumnindexName = "Empty"
        Me.RlItemDet.ExitColumnName = ""
        Me.RlItemDet.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Mixed
        Me.RlItemDet.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridDataCellList
        Me.RlItemDet.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.List
        Me.RlItemDet.GridStyles.StyleDataCells = ComponentFactory.Krypton.Toolkit.GridStyle.List
        Me.RlItemDet.GridStyles.StyleRow = ComponentFactory.Krypton.Toolkit.GridStyle.List
        Me.RlItemDet.HoveringColor1 = System.Drawing.Color.Empty
        Me.RlItemDet.HoveringColor2 = System.Drawing.Color.Empty
        Me.RlItemDet.HoveringMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal
        Me.RlItemDet.Location = New System.Drawing.Point(1, 140)
        Me.RlItemDet.Name = "RlItemDet"
        Me.RlItemDet.NextFocusControl = Nothing
        Me.RlItemDet.NextRowCellFocus = 0
        Me.RlItemDet.NextRowFocusCellName = "Empty"
        Me.RlItemDet.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.[Global]
        Me.RlItemDet.RefName = Nothing
        Me.RlItemDet.RowHeadersWidth = 30
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        Me.RlItemDet.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.RlItemDet.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.LemonChiffon
        Me.RlItemDet.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.RlItemDet.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Silver
        Me.RlItemDet.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.RlItemDet.RowTemplate.Height = 30
        Me.RlItemDet.Size = New System.Drawing.Size(999, 289)
        Me.RlItemDet.StateCommon.Background.Color1 = System.Drawing.Color.LemonChiffon
        Me.RlItemDet.StateCommon.Background.Color2 = System.Drawing.Color.LemonChiffon
        Me.RlItemDet.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridDataCellList
        Me.RlItemDet.StateCommon.DataCell.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.RlItemDet.StateCommon.DataCell.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.RlItemDet.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RlItemDet.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.Gray
        Me.RlItemDet.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.SolidInside
        Me.RlItemDet.StateCommon.HeaderColumn.Border.Color1 = System.Drawing.Color.Gray
        Me.RlItemDet.StateCommon.HeaderColumn.Border.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.SolidInside
        Me.RlItemDet.StateCommon.HeaderColumn.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.RlItemDet.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.White
        Me.RlItemDet.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RlItemDet.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.White
        Me.RlItemDet.StateCommon.HeaderRow.Content.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RlItemDet.StateDisabled.Background.Color1 = System.Drawing.Color.LemonChiffon
        Me.RlItemDet.StateNormal.Background.Color1 = System.Drawing.Color.Honeydew
        Me.RlItemDet.TabIndex = 12486
        '
        'FrmCancelRpt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1003, 493)
        Me.Controls.Add(Me.RlItemDet)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.btnProcess)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel14)
        Me.Controls.Add(Me.Panel13)
        Me.Controls.Add(Me.lblHeader)
        Me.MaximizeBox = False
        Me.Name = "FrmCancelRpt"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel13.ResumeLayout(False)
        Me.Panel13.PerformLayout()
        Me.Panel14.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.RlItemDet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents Panel13 As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel14 As System.Windows.Forms.Panel
    Friend WithEvents DtpFrmDt As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dtpToDt As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnProcess As System.Windows.Forms.Button
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtFilter2 As System.Windows.Forms.TextBox
    Friend WithEvents txtFilter1 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbFilter2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbFilter1 As System.Windows.Forms.ComboBox
    Friend WithEvents chkAll As System.Windows.Forms.CheckBox
    Friend WithEvents RlItemDet As RLComponents.ExRlGridView

End Class
