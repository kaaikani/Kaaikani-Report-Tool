Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmDsRPT
    Inherits System.Windows.Forms.Form


#Region " Windows Form Designer generated code "
    Dim RptObj As Object
    Dim RptStr, RptHdr As String
    Dim Z As Integer
    Public Sub New(ByVal RptName As Object, ByVal ReportHdr As String, Optional ByVal Reportstr As String = "", Optional ByVal Zm As Integer = 1)
        MyBase.New()
        Z = Zm
        RptObj = RptName
        RptStr = Reportstr
        RptHdr = ReportHdr
        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Label1 As System.Windows.Forms.Label
    'Friend WithEvents c As CrystalDecisions.Windows.Forms.CrystalReportViewer
    'Friend WithEvents CRVAPC As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CRVAPC As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmbZoom As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDsRPT))
        Me.Label1 = New System.Windows.Forms.Label
        Me.CRVAPC = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.Label2 = New System.Windows.Forms.Label
        Me.CmbZoom = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(752, 448)
        Me.Label1.TabIndex = 1
        '
        'CRVAPC
        '
        Me.CRVAPC.ActiveViewIndex = -1
        Me.CRVAPC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRVAPC.DisplayGroupTree = False
        Me.CRVAPC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRVAPC.Location = New System.Drawing.Point(0, 0)
        Me.CRVAPC.Name = "CRVAPC"
        Me.CRVAPC.SelectionFormula = ""
        Me.CRVAPC.Size = New System.Drawing.Size(762, 458)
        Me.CRVAPC.TabIndex = 2
        Me.CRVAPC.ViewTimeSelectionFormula = ""
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(353, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Zoom Level"
        '
        'CmbZoom
        '
        Me.CmbZoom.Items.AddRange(New Object() {"100", "90", "80", "75", "60", "50", "25"})
        Me.CmbZoom.Location = New System.Drawing.Point(425, 4)
        Me.CmbZoom.Name = "CmbZoom"
        Me.CmbZoom.Size = New System.Drawing.Size(48, 21)
        Me.CmbZoom.TabIndex = 5
        '
        'FrmDsRPT
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(762, 458)
        Me.Controls.Add(Me.CmbZoom)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CRVAPC)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmDsRPT"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public BindReport As Boolean = True
    Public FromDate As String
    Public ToDate As String
    Private Sub FrmRPT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim ds As New DataSet()
            RptObj.Refresh()
            RptObj.RecordSelectionFormula = RptStr
           
            If BindReport Then
                CRVAPC.ReportSource = RptObj
                CRVAPC.Zoom(100)
                CmbZoom.Text = 100
                Me.Text = RptHdr
            End If
        Catch ee As Exception
            MsgBox(ee.ToString)
        End Try
    End Sub

    Public Sub BindReportManually()
        CRVAPC.ReportSource = RptObj
        CRVAPC.Zoom(100)
        CmbZoom.Text = 100
        Me.Text = RptHdr
    End Sub


    Public Sub SetCurrentValuesForParameterField(ByVal myReportDocument As ReportDocument, ByVal myArrayList As ArrayList, ByVal FieldName As String)
        Dim currentParameterValues As ParameterValues = New ParameterValues()
        Dim submittedValue As Object
        For Each submittedValue In myArrayList
            Dim myParameterDiscreteValue As ParameterDiscreteValue = New ParameterDiscreteValue()
            myParameterDiscreteValue.Value = submittedValue.ToString()
            currentParameterValues.Add(myParameterDiscreteValue)
        Next

        Dim myParameterFieldDefinitions As ParameterFieldDefinitions = myReportDocument.DataDefinition.ParameterFields
        Dim myParameterFieldDefinition As ParameterFieldDefinition = myParameterFieldDefinitions(FieldName)
        myParameterFieldDefinition.ApplyCurrentValues(currentParameterValues)
    End Sub

    'Private Sub CRVAPC_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CRVAPC.Leave
    '    CRVAPC.Zoom(Val(CmbZoom.Text))
    'End Sub

    Private Sub CmbZoom_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbZoom.SelectedValueChanged
        CRVAPC.Zoom(Val(CmbZoom.Text))
    End Sub

    Private Sub CmbZoom_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbZoom.KeyPress
        'If  Then
        '    CRVAPC.Zoom(Val(CmbZoom.Text))
        'End If
    End Sub

    Private Sub CmbZoom_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbZoom.KeyDown
        If e.KeyCode = 13 Then
            CRVAPC.Zoom(Val(CmbZoom.Text))
        End If
    End Sub
End Class
