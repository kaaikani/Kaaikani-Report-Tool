Imports System.Reflection
Imports System.Data.OleDb
Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports System.Windows
Imports System.Windows.Forms

Public Class FrmCancelRpt
    Dim RptObj As New DataClass.OrderwiseRpt
    Dim blnProcess As Boolean = False
    Dim ReportTable As DataTable
    Dim TotalFilterstr As String = ""
    Dim TotalSumColStr As String = ""
    Dim dtb1 As DataTable
    Dim Printds As New DataSet()
    Dim CpRpt As CrystalDecisions.CrystalReports.Engine.ReportClass
    Dim ScrName As String = "Cancel Report"
    Dim commObj As New DataClass.CommonView
    Dim dtImport As DataTable
    Dim rptLoad As DataTable

    Public Sub InitServer(Optional ByVal Local As Boolean = False)
        Dim DS As New DataSet()
        Try
            DS.ReadXml(AppDomain.CurrentDomain.BaseDirectory & "ConnInfo.XML")
            commObj.DBServer = DS.Tables(0).Rows(0)("DBServer")
            commObj.Port = DS.Tables(0).Rows(0)("Port")
            commObj.DataBase = DS.Tables(0).Rows(0)("DataBase")
            commObj.Pwd = DS.Tables(0).Rows(0)("Pwd")
            DS.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
            DS.Dispose()
            End
        End Try
    End Sub

    Private Sub DtpFrmDt_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpFrmDt.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpToDt.Focus()
        End If
    End Sub

    Private Sub dtpToDt_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpToDt.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnProcess.Focus()
        End If
    End Sub

    Private Sub btnProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcess.Click
        FillGrids()
        For i As Integer = 0 To ReportTable.Columns.Count - 1
            If (ReportTable.Columns(i).ColumnName.ToLower().Contains("id")) Then
            Else
                cmbFilter1.Items.Add(ReportTable.Columns(i).ColumnName)
                cmbFilter2.Items.Add(ReportTable.Columns(i).ColumnName)
            End If
        Next

        blnProcess = True
    End Sub

    Private Sub FrmOrderRpt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub FrmOrderRpt_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InitServer()

        Me.Cursor = Cursors.WaitCursor
        Me.DtpFrmDt.Value = Now.Date
        Me.dtpToDt.Value = Now.Date

        DtpFrmDt.Focus()
        ''FillGrids()
        Me.Cursor = Cursors.Default
        Me.Text = ScrName
        ' Load the PDF document

    End Sub
    Public Sub FillGrids()
        Try


            InitServer()
            ' rdbAll.Checked = True

            TotalSumColStr = "NetTotal,QUANTITY"

            ReportTable = RptObj.RptCancelReport(DtpFrmDt.Value.Date.ToString("dd/MMM/yyyy"), dtpToDt.Value.Date.ToString("dd/MMM/yyyy"))
            RlItemDet.DataSource = ReportTable.Clone
            Dim table As New DataTable
            rptLoad = ReportTable.Clone

            'rptLoad.Columns.Add("Selection", GetType(Boolean))
            Dim code As String = ""
            If ReportTable.Rows.Count > 0 Then
                code = ReportTable.Rows(0)("Code")
            End If
            Dim sNo As Integer = 1

            For i As Integer = 0 To ReportTable.Rows.Count - 1
                rptLoad.Rows.Add()
                rptLoad.Rows(i)("Code") = ReportTable.Rows(i)("Code")
                rptLoad.Rows(i)("Date") = ReportTable.Rows(i)("Date")
                Dim address As String = ReportTable.Rows(i)("BillingAddress")
                Dim add1 As String = RptObj.readJSON(address)
                rptLoad.Rows(i)("Customer") = DataClass.CommonView.Customer
                rptLoad.Rows(i)("Address") = DataClass.CommonView.Address
                rptLoad.Rows(i)("CellNo") = DataClass.CommonView.CellNo
                rptLoad.Rows(i)("NetTotal") = ReportTable.Rows(i)("NetTotal")
            Next

            RlItemDet.DataSource = rptLoad
            RptObj.RptCancelReport_GridStyle(RlItemDet.Columns)
            If ReportTable Is Nothing Then Exit Sub
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub txtFilter1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFilter1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim dv As DataView
            dv = ReportTable.DefaultView
            If (txtFilter1.Text <> "") Then
                Select Case ReportTable.Columns(cmbFilter1.Text).DataType.Name.ToString()
                    Case "DateTime"
                        dv = New DataView(ReportTable, String.Format(cmbFilter1.Text + " = '{0}'", txtFilter1.Text), "", DataViewRowState.CurrentRows)
                    Case "String"
                        dv = New DataView(ReportTable, String.Format(cmbFilter1.Text + " = '{0}'", txtFilter1.Text), "", DataViewRowState.CurrentRows)
                End Select
            End If
            RlItemDet.DataSource = dv
            blnProcess = False

        End If
    End Sub

    Private Sub txtFilter1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilter1.TextChanged
        Dim dv As DataView
        dv = ReportTable.DefaultView

        If (txtFilter1.Text <> "") Then
            Select Case ReportTable.Columns(cmbFilter1.Text).DataType.Name.ToString()
                Case "Int32"
                    dv = New DataView(ReportTable, String.Format(cmbFilter1.Text + " = {0}", txtFilter1.Text), "", DataViewRowState.CurrentRows)
                    'dv.RowFilter = String.Format(cmbFilter1.Text + " = {0}", txtFilter1.Text)
                Case "String"
                    dv = New DataView(ReportTable, String.Format(cmbFilter1.Text + " LIKE '{0}%'", txtFilter1.Text), "", DataViewRowState.CurrentRows)
                    ' dv.RowFilter = String.Format(cmbFilter1.Text + " Like '{0}%'", txtFilter1.Text)

            End Select
        End If
        RlItemDet.DataSource = dv
        blnProcess = False
    End Sub

    Private Sub txtFilter2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFilter2.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim dv As DataView
            dv = ReportTable.DefaultView
            If (txtFilter2.Text <> "") Then
                Select Case ReportTable.Columns(cmbFilter2.Text).DataType.Name.ToString()
                    Case "DateTime"
                        dv = New DataView(ReportTable, String.Format(cmbFilter2.Text + " = '{0}'", txtFilter2.Text), "", DataViewRowState.CurrentRows)
                    Case "String"
                        dv = New DataView(ReportTable, String.Format(cmbFilter2.Text + " = '{0}'", txtFilter2.Text), "", DataViewRowState.CurrentRows)
                End Select
            End If
            RlItemDet.DataSource = dv
            blnProcess = False
            'calc(dv.ToTable)
        End If
    End Sub

    Private Sub txtFilter2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFilter2.TextChanged
        Dim dv As DataView
        dv = ReportTable.DefaultView
        If (txtFilter2.Text <> "") Then
            Select Case ReportTable.Columns(cmbFilter2.Text).DataType.Name.ToString()
                Case "Int32"
                    dv = New DataView(ReportTable, String.Format(cmbFilter2.Text + " = {0}", txtFilter2.Text), "", DataViewRowState.CurrentRows)
                    'dv.RowFilter = String.Format(cmbFilter1.Text + " = {0}", txtFilter1.Text)
                Case "String"
                    dv = New DataView(ReportTable, String.Format(cmbFilter2.Text + " LIKE '{0}%'", txtFilter2.Text), "", DataViewRowState.CurrentRows)
                    ' dv.RowFilter = String.Format(cmbFilter1.Text + " Like '{0}%'", txtFilter1.Text)
            End Select
        End If
        RlItemDet.DataSource = dv
        blnProcess = False
    End Sub

    Private Sub cmbFilter1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFilter1.SelectedIndexChanged
        txtFilter1.Text = ""
    End Sub

    Private Sub cmbFilter2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFilter2.SelectedIndexChanged
        txtFilter2.Text = ""
    End Sub
  
End Class
