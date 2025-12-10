Imports System.Reflection
Imports System.Data.OleDb
Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports System.Windows
Imports System.Windows.Forms

Public Class FrmOrderRpt
    Dim RptObj As New DataClass.OrderwiseRpt
    Dim blnProcess As Boolean = False
    Dim ReportTable As DataTable
    Dim TotalFilterstr As String = ""
    Dim TotalSumColStr As String = ""
    Dim dtb1 As DataTable
    Dim Printds As New DataSet()
    Dim CpRpt As CrystalDecisions.CrystalReports.Engine.ReportClass
    Dim ScrName As String = "Orderwise Report"
    Dim commObj As New DataClass.CommonView
    Dim dtImport As DataTable
    Dim rptLoad As DataTable
    Dim rptFinalLoad As DataTable
    Dim isSmsBalBtn As Short

    Public Sub InitServer(Optional ByVal Local As Boolean = False)
        Dim DS As New DataSet()
        Try
            DS.ReadXml(AppDomain.CurrentDomain.BaseDirectory & "ConnInfoWeb.XML")
            ' DS.ReadXml(AppDomain.CurrentDomain.BaseDirectory & "ConnInfo.XML")
            commObj.DBServer = DS.Tables(0).Rows(0)("DBServer")
            commObj.Port = DS.Tables(0).Rows(0)("Port")
            commObj.DataBase = DS.Tables(0).Rows(0)("DataBase")
            commObj.UId = DS.Tables(0).Rows(0)("UserId")
            commObj.Pwd = DS.Tables(0).Rows(0)("Pwd")
            isSmsBalBtn = DS.Tables(0).Rows(0)("SMS")
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
        rdbAll.Checked = True
        Me.Cursor = Cursors.WaitCursor
        Me.DtpFrmDt.Value = Now.Date
        Me.dtpToDt.Value = Now.Date
        dtpTime.Value = Now.ToString("dd/MM/yyyy hh:mm:ss tt")
        DtpFrmDt.Focus()
        cmbLocation.DataSource = RptObj.loadLocation()
        cmbLocation.ValueMember = "Id"
        cmbLocation.DisplayMember = "Location"
        ''FillGrids()
        Me.Cursor = Cursors.Default
        Me.Text = ScrName
        If isSmsBalBtn = 1 Then btnSmsBal.Visible = True Else btnSmsBal.Visible = False
        ' Load the PDF document

    End Sub
    Public Sub FillGrids()
        Try

            InitServer()
            ' rdbAll.Checked = True
            If rdbDetail.Checked Then

                TotalSumColStr = "NetTotal,QUANTITY"
                Dim timeType As String = ""
                If rdbAll.Checked Then
                    timeType = "ALL"
                ElseIf rdpLess.Checked Then
                    timeType = "LESS"
                ElseIf rdbGreater.Checked Then
                    timeType = "GREATER"
                Else
                    timeType = "ALL"
                End If
                ReportTable = RptObj.RptLoadDetailReport(DtpFrmDt.Value.Date.ToString("dd/MMM/yyyy"), dtpToDt.Value.Date.ToString("dd/MMM/yyyy"), timeType, dtpTime.Value.ToString("dd/MMM/yyyy HH:mm:ss"), cmbLocation.SelectedValue)
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
                    rptLoad.Rows(i)("Id") = ReportTable.Rows(i)("Id")
                    ' rptLoad.Rows(i)("SNo") = ReportTable.Rows(i)("SNo")
                    If ReportTable.Rows(i)("Code") <> code Then
                        rptLoad.Rows(i)("SNo") = sNo + 1
                        sNo = sNo + 1
                    Else
                        rptLoad.Rows(i)("SNo") = sNo
                    End If
                    rptLoad.Rows(i)("PCode") = ReportTable.Rows(i)("PCode")
                    rptLoad.Rows(i)("Code") = ReportTable.Rows(i)("Code")
                    rptLoad.Rows(i)("Date") = ReportTable.Rows(i)("Date")
                    rptLoad.Rows(i)("Time") = ReportTable.Rows(i)("Time")
                    rptLoad.Rows(i)("MetaData") = ReportTable.Rows(i)("MetaData")
                    rptLoad.Rows(i)("ShadowPrice") = ReportTable.Rows(i)("ShadowPrice")
                    rptLoad.Rows(i)("RewardPointUsed") = ReportTable.Rows(i)("RewardPointUsed")
                    rptLoad.Rows(i)("CouponCode") = ReportTable.Rows(i)("CouponCode")
                    rptLoad.Rows(i)("Note") = ReportTable.Rows(i)("Note")
                    'rptLoad.Rows(i)("Selection") = False
                    Dim address As String = ReportTable.Rows(i)("BillingAddress")
                    Dim add1 As String = RptObj.readJSON(address)
                    If DataClass.CommonView.Customer <> Nothing Then
                        rptLoad.Rows(i)("Customer") = DataClass.CommonView.Customer
                        rptLoad.Rows(i)("Address") = DataClass.CommonView.Address
                        rptLoad.Rows(i)("CellNo") = DataClass.CommonView.CellNo
                        rptLoad.Rows(i)("Pincode") = DataClass.CommonView.Pincode
                    Else
                        Dim dtCustAdd As DataTable = RptObj.RpCustomerDetail(ReportTable.Rows(i)("CustomerId"))
                        If dtCustAdd.Rows.Count > 0 Then
                            rptLoad.Rows(i)("Customer") = dtCustAdd.Rows(0)("Customer")
                            rptLoad.Rows(i)("Address") = dtCustAdd.Rows(0)("StreetLine1") + "," + dtCustAdd.Rows(0)("StreetLine2") + "," + dtCustAdd.Rows(0)("City") + "-" + dtCustAdd.Rows(0)("Pincode")
                            rptLoad.Rows(i)("CellNo") = dtCustAdd.Rows(0)("CellNo")
                            rptLoad.Rows(i)("Pincode") = dtCustAdd.Rows(0)("Pincode")
                        End If
                    End If
                    rptLoad.Rows(i)("ItemName") = ReportTable.Rows(i)("ItemName")


                    If dtImport Is Nothing Then
                    Else
                        If dtImport.Rows.Count > 0 Then
                            Dim dt As DataTable
                            Dim dataView As DataView = dtImport.DefaultView
                            If Not String.IsNullOrEmpty(rptLoad.Rows(i)("ItemName")) Then
                                dataView.RowFilter = "SKU = '" & rptLoad.Rows(i)("PCODE").ToString().Trim() & "'"
                                'dataView.RowFilter = "ItemName ='" + rptLoad.Rows(i)("ItemName").ToString().Trim() + "'"
                                dt = dataView.ToTable
                                If dt.Rows.Count > 0 Then
                                    rptLoad.Rows(i)("TamilName") = dt.Rows(0)("TamilName")
                                End If
                            End If
                        End If
                    End If
                    rptLoad.Rows(i)("Qty") = ReportTable.Rows(i)("Qty")
                    rptLoad.Rows(i)("Rate") = ReportTable.Rows(i)("Rate")
                    rptLoad.Rows(i)("Total") = ReportTable.Rows(i)("Total")
                    rptLoad.Rows(i)("SubTotal") = ReportTable.Rows(i)("SubTotal")
                    rptLoad.Rows(i)("Shipping") = ReportTable.Rows(i)("Shipping")
                    rptLoad.Rows(i)("NetTotal") = ReportTable.Rows(i)("NetTotal")
                    rptLoad.Rows(i)("DeliveryTime") = ReportTable.Rows(i)("DeliveryTime")
                    rptLoad.Rows(i)("CuttingInstructions") = ReportTable.Rows(i)("CuttingInstructions")
                    rptLoad.Rows(i)("PaymentMode") = ReportTable.Rows(i)("PaymentMode")
                    rptLoad.Rows(i)("OrdNo") = ReportTable.Rows(i)("OrdNo")
                    'replace
                    '  Dim pay As String = ReportTable.Rows(i)("MetaData").ToString()
                    ' Dim payment As String = ""
                    'If (pay <> "") Then
                    'Payment = RptObj.readPaymentMetadataJSON(pay)
                    'End If
                    'If Payment <> "" Then
                    '' If DataClass.CommonView.PaymentId <> Nothing Then
                    'rptLoad.Rows(i)("PaymentStatus") = "Bill Paid"
                    'Else
                    'Dim billPaid As String = ReportTable.Rows(i)("PaymentMode")
                    'If billPaid <> "" Then
                    'If (billPaid.Contains("Bill Paid")) Then
                    'rptLoad.Rows(i)("PaymentStatus") = "Bill Paid"
                    'End If
                    ' End If
                    ' End If
                    Dim meta As String = ReportTable.Rows(i)("MetaData").ToString().ToLower()
                    Dim payMode As String = ReportTable.Rows(i)("CuttingInstructions").ToString().ToLower()
                    Dim payMode1 As String = ReportTable.Rows(i)("PaymentMode").ToString().ToLower()
                    Dim paymentJson As String = ""

                    ' Parse metadata JSON (your existing function)
                    If meta <> "" Then
                        paymentJson = RptObj.readPaymentMetadataJSON(meta)
                    End If

                    Dim isBillPaid As Boolean = False

                    ' 1️⃣ Razorpay = Bill Paid
                    If meta.Contains("razorpayPaymentId") Then
                        isBillPaid = True
                    End If


                    If meta.Contains("""mode"":""online""") Then
                        isBillPaid = True
                    End If

                    Dim p As String = payMode.ToLower().Replace(" ", "").Replace(".", "")
                    If p.Contains("billpaid") Then
                        isBillPaid = True
                    End If
                    Dim p1 As String = payMode1.ToLower().Replace(" ", "").Replace(".", "")
                    If p1.Contains("billpaid") Then
                        isBillPaid = True
                    End If

                    If meta.Contains("""paymentmethod"":""offline""") Then
                        isBillPaid = False
                    End If

                    ' ---- FINAL OUTPUT ----
                    If isBillPaid Then
                        rptLoad.Rows(i)("PaymentStatus") = "Bill Paid"
                    Else
                        rptLoad.Rows(i)("PaymentStatus") = "COD"
                    End If

                    code = ReportTable.Rows(i)("Code")
                Next
                rptLoad.DefaultView.Sort = "OrdNo ASC,Pincode asc"
                rptLoad = rptLoad.DefaultView.ToTable

                'rptFinalLoad = rptLoad.Clone
                code = ""
                If rptLoad.Rows.Count > 0 Then
                    code = rptLoad.Rows(0)("Code")
                End If
                sNo = 1
                For i As Integer = 0 To rptLoad.Rows.Count - 1
                    ' rptFinalLoad.Rows.Add()
                    ' rptFinalLoad.Rows(i)("Id") = rptLoad.Rows(i)("Id")
                    ' rptLoad.Rows(i)("SNo") = ReportTable.Rows(i)("SNo")
                    If rptLoad.Rows(i)("Code") <> code Then
                        rptLoad.Rows(i)("SNo") = sNo + 1
                        sNo = sNo + 1
                    Else
                        rptLoad.Rows(i)("SNo") = sNo
                    End If
                    code = rptLoad.Rows(i)("Code")
                Next
                RlItemDet.DataSource = rptLoad
                RptObj.RptLoadReport_GridStyle(RlItemDet.Columns)
                ' RlItemDet.Columns("Selection").Visible = True
            ElseIf rdbCumm.Checked Then
                Dim rptLoad As DataTable
                TotalSumColStr = "QUANTITY"
                Dim timeType As String = ""
                If rdbAll.Checked Then
                    timeType = "ALL"
                ElseIf rdpLess.Checked Then
                    timeType = "LESS"
                ElseIf rdbGreater.Checked Then
                    timeType = "GREATER"
                Else
                    timeType = "ALL"
                End If
                ReportTable = RptObj.RptLoadCummReport(DtpFrmDt.Value.Date.ToString("dd/MMM/yyyy"), dtpToDt.Value.Date.ToString("dd/MMM/yyyy"), timeType, dtpTime.Value.ToString("HH:mm:ss"))
                'dgvReport.DataSource = ReportTable
                RlItemDet.DataSource = ReportTable.Clone
                Dim table As New DataTable
                rptLoad = ReportTable.Clone

                For i As Integer = 0 To ReportTable.Rows.Count - 1
                    rptLoad.Rows.Add()
                    rptLoad.Rows(i)("PCode") = ReportTable.Rows(i)("PCOde")
                    ' rptLoad.Rows(i)("Time") = ReportTable.Rows(i)("Time")
                    rptLoad.Rows(i)("ItemName") = ReportTable.Rows(i)("ItemName")
                    rptLoad.Rows(i)("Qty") = ReportTable.Rows(i)("Qty")
                    If dtImport Is Nothing Then
                    Else
                        If dtImport.Rows.Count > 0 Then
                            Dim dt As DataTable
                            Dim dataView As DataView = dtImport.DefaultView
                            If Not String.IsNullOrEmpty(rptLoad.Rows(i)("ItemName")) Then
                                'dataView = New DataView(dtImport, String.Format("ItemName LIKE '%{0}'", rptLoad.Rows(i)("ItemName").ToString().Trim()), "", DataViewRowState.CurrentRows)
                                'dataView.RowFilter = "ItemName like * '" & rptLoad.Rows(i)("ItemName").ToString().Trim() & "'"
                                'dataView.RowFilter = "ItemName LIKE '%" + rptLoad.Rows(i)("ItemName").ToString().Trim() + "%'"
                                'dataView.RowFilter = "ItemName ='" + rptLoad.Rows(i)("ItemName").ToString().Trim() + "'"
                                dataView.RowFilter = "SKU = '" & rptLoad.Rows(i)("PCODE").ToString().Trim() & "'"
                                dt = dataView.ToTable
                                If dt.Rows.Count > 0 Then
                                    rptLoad.Rows(i)("TamilName") = dt.Rows(0)("TamilName").ToString().Trim()
                                    rptLoad.Rows(i)("Category") = dt.Rows(0)("Category").ToString().Trim()
                                    rptLoad.Rows(i)("OrdNo") = dt.Rows(0)("OrdNo").ToString().Trim()
                                End If
                            End If
                        End If
                    End If
                Next
                RlItemDet.DataSource = rptLoad
                RptObj.RptLoadCummReport_GridStyle(RlItemDet.Columns)
            End If
            If ReportTable Is Nothing Then Exit Sub
            ' calc(ReportTable.Copy)
            'dgvReport.DataSource = ReportTable
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Function readFromUpdatePriceExcel(ByVal path As String) As Boolean
        Dim connstring As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=""Excel 8.0;HDR=YES;"""
        Dim status As Boolean = True
        Dim pram As OleDbParameter
        Dim dr As DataRow
        Dim olecon As OleDbConnection
        Dim olecomm As OleDbCommand
        Dim olecomm1 As OleDbCommand
        Dim oleadpt As OleDbDataAdapter
        Dim dtTable As DataTable
        Dim ds As DataSet
        Try
            olecon = New OleDbConnection
            olecon.ConnectionString = connstring
            olecomm = New OleDbCommand

            Dim query As String = "SELECT * FROM [MSysObjects] WHERE TYPE=1 AND NAME NOT LIKE 'P%';"

            ' Create an OLEDB connection

            Using connection As New OleDbConnection(olecon.ConnectionString)
                Try
                    ' Open the connection
                    connection.Open()

                    Dim dtExcelSchema As DataTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
                    Dim channelId As Integer = 0

                    For i As Integer = 0 To dtExcelSchema.Rows.Count - 1
                        Using connection1 As New OleDbConnection(olecon.ConnectionString)
                            Dim sheetName As String = dtExcelSchema.Rows(i)("TABLE_NAME").ToString()
                            olecomm.CommandText = _
                  "Select SKU,[Product Name] as ItemName,Price ,[Shadow Price],[Stock],[HSN code] from [" + sheetName + "] Where [Product Name] is not null "
                            olecomm.Connection = olecon
                            olecomm1 = New OleDbCommand

                            oleadpt = New OleDbDataAdapter(olecomm)
                            ds = New DataSet
                            dtTable = New DataTable

                            connection1.Open()
                            oleadpt.Fill(dtTable)
                            dtTable.TableName = "OrdDet"

                            If sheetName = "Madurai$" Then
                                channelId = 4
                            ElseIf sheetName = "Covai$" Then
                                channelId = 6
                            ElseIf sheetName = "Salem$" Then
                                channelId = 5
                            ElseIf sheetName = "Trichy$" Then
                                channelId = 7
                            End If
                            For cnt As Integer = 0 To dtTable.Rows.Count - 1
                                Try
                                    RptObj.updatePriceList(
                                        dtTable.Rows(cnt)("SKU").ToString(),
                                        Val(dtTable.Rows(cnt)("Price").ToString()) * 100,
                                        Val(dtTable.Rows(cnt)("Shadow Price").ToString()) * 100,
                                        Val(dtTable.Rows(cnt)("Stock").ToString()),
                                        dtTable.Rows(cnt)("HSN code").ToString(),
                                        channelId
                                    )
                                Catch exRow As Exception
                                    MsgBox("❌ Error updating SKU " & dtTable.Rows(cnt)("SKU").ToString() & ": " & exRow.Message)
                                End Try
                            Next
                        End Using
                    Next

                Catch ex As Exception
                    ' Handle errors, such as file not found or connection issues
                    MsgBox("Error: " & ex.Message)
                    status = False
                End Try

            End Using


            'ds.Tables(0).TableName = "OrdDet"
        Catch ex As Exception
            MsgBox(ex.Message)
            status = False
        Finally
            olecon.Close()
            olecon = Nothing
            olecomm = Nothing
            oleadpt = Nothing

            dr = Nothing
            pram = Nothing
        End Try
        Return status
    End Function
    Function readFromExcel(ByVal path As String) As DataTable
        Dim connstring As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=""Excel 8.0;HDR=YES;"""

        Dim pram As OleDbParameter
        Dim dr As DataRow
        Dim olecon As OleDbConnection
        Dim olecomm As OleDbCommand
        Dim olecomm1 As OleDbCommand
        Dim oleadpt As OleDbDataAdapter
        Dim dtTable As DataTable
        Dim ds As DataSet
        Try
            olecon = New OleDbConnection
            olecon.ConnectionString = connstring
            olecomm = New OleDbCommand

            
            olecomm.CommandText = _
               "Select SKU,[Product Name] as ItemName,[Tamil Name] as TamilName,Category,[Group Name] as GroupName,Weight,OrdNo from [Sheet1$] Where [Product Name] is not null "
            olecomm.Connection = olecon
            olecomm1 = New OleDbCommand

            oleadpt = New OleDbDataAdapter(olecomm)
            ds = New DataSet
            dtTable = New DataTable

            olecon.Open()
            oleadpt.Fill(dtTable)
            dtTable.TableName = "OrdDet"
            'ds.Tables(0).TableName = "OrdDet"
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            olecon.Close()
            olecon = Nothing
            olecomm = Nothing
            oleadpt = Nothing

            dr = Nothing
            pram = Nothing
        End Try
        Return dtTable
    End Function
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
    Sub Cr_OrderBill(ByVal code As String)
        Dim TxtCompName, TxtCompAdd1, TxtCity, TxtGstNo, TextTitle As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim dv As DataView
        Try
            Dim Rpt As Object
            'dtb1 = RptObj.RptPurHdr_Source(DtpFrmDt.Value.Date.ToString("dd/MMM/yyyy"), DtpToDt.Value.Date.ToString("dd/MMM/yyyy"), "")
            If RlItemDet.DataSource IsNot Nothing Then
                ' MessageBox.Show(blnProcess.ToString())
                If blnProcess = True Then
                    dtb1 = RlItemDet.DataSource
                Else
                    dtb1 = RlItemDet.DataSource.totable
                End If
                dv = dtb1.DefaultView
                ' dv.RowFilter = "Selection = 'true'"
                dtb1 = dv.ToTable
                dtb1.TableName = "Qry_OrderRpt"
            End If

            If dtb1.Rows.Count = 0 Then MsgBox("No Records Found...", MsgBoxStyle.Information, Me.Text) : Exit Sub

            Printds.Tables.Clear()

            Printds.Tables.Add(dtb1)


            Rpt = New OrderBill
            'Rpt = New SalesA5LSPrint
            'TxtCompName = CpRpt.ReportDefinition.ReportObjects.Item("TextCompFrm")
            'TxtCompName.Text = "From " + DtpFrmDt.Value.Date.ToString("dd/MM/yyyy") + " To " + dtpToDt.Value.Date.ToString("dd/MM/yyyy")


            TxtCompName = Rpt.ReportDefinition.ReportObjects.Item("TxtCompName")
            TxtCompName.Text = "KAAIKANI"

            TxtCompName = Rpt.ReportDefinition.ReportObjects.Item("TxtCompAdd")
            TxtCompName.Text = "Kovil Papakudi,Madurai-625018"

            TxtCompName = Rpt.ReportDefinition.ReportObjects.Item("TxtCompCity")
            TxtCompName.Text = "Toll Free No : 1800 309 4983"

            TxtCompAdd1 = Rpt.ReportDefinition.ReportObjects.Item("TextTitle")
            TxtCompAdd1.Text = "Order Itemwise Report on " + dtpToDt.Value.Date

            Rpt.SetDataSource(Printds)

            Dim frm As New FrmDsRPT(Rpt, "")
            'frm.Text = lblHeader.Text
            frm.Show()

            Rpt = Nothing
            'Rpt.PrintToPrinter(1, True, 1, 1)
            'Rpt.Dispose()
            'Printds.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
            Printds.Tables.Clear()
        End Try

    End Sub

    Sub Cr_OrderItemRegister()
        Dim TxtCompName, TxtCompAdd1, TxtCity, TxtGstNo, TextTitle As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim dv As DataView
        Try
            Dim Rpt As Object
            'dtb1 = RptObj.RptPurHdr_Source(DtpFrmDt.Value.Date.ToString("dd/MMM/yyyy"), DtpToDt.Value.Date.ToString("dd/MMM/yyyy"), "")
            ' If RlItemDet.DataSource IsNot Nothing Then
            ' MessageBox.Show(blnProcess.ToString())
            If blnProcess = True Then
                dtb1 = RlItemDet.DataSource
            Else
                dtb1 = RlItemDet.DataSource.totable
            End If
            dv = dtb1.DefaultView
            ' dv.RowFilter = "Selection='true'"
            dtb1 = dv.ToTable
            dtb1.TableName = "Qry_OrderRpt"
            'End If

            If dtb1.Rows.Count = 0 Then MsgBox("No Records Found...", MsgBoxStyle.Information, Me.Text) : Exit Sub

            Printds.Tables.Clear()

            Printds.Tables.Add(dtb1)


            Rpt = New RptOrderReg

            'TxtCompName = CpRpt.ReportDefinition.ReportObjects.Item("TextCompFrm")
            'TxtCompName.Text = "From " + DtpFrmDt.Value.Date.ToString("dd/MM/yyyy") + " To " + dtpToDt.Value.Date.ToString("dd/MM/yyyy")


            TxtCompName = Rpt.ReportDefinition.ReportObjects.Item("TxtCompName")
            TxtCompName.Text = "KAAIKANI"

            TxtCompAdd1 = Rpt.ReportDefinition.ReportObjects.Item("TextTitle")
            TxtCompAdd1.Text = "Order Itemwise Report on " + dtpToDt.Value.Date

            Rpt.SetDataSource(Printds)

            Dim frm As New FrmDsRPT(Rpt, "")
            'frm.Text = lblHeader.Text
            frm.Show()

            Rpt = Nothing
            'Rpt.PrintToPrinter(1, True, 1, 1)
            'Rpt.Dispose()
            'Printds.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
            Printds.Tables.Clear()
        End Try

    End Sub

    Sub Cr_OrderItemCummRegister()
        Dim TxtCompName, TxtCompAdd1, TxtCity, TxtGstNo, TextTitle As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim dv As DataView
        Try
            Dim Rpt As Object
            'dtb1 = RptObj.RptPurHdr_Source(DtpFrmDt.Value.Date.ToString("dd/MMM/yyyy"), DtpToDt.Value.Date.ToString("dd/MMM/yyyy"), "")
            If RlItemDet.DataSource IsNot Nothing Then
                If blnProcess = True Then
                    dtb1 = RlItemDet.DataSource
                Else
                    dtb1 = RlItemDet.DataSource.totable
                End If
                dv = dtb1.DefaultView
                'dv.RowFilter = "Selection =true"
                dtb1 = dv.ToTable
                dtb1.TableName = "Qry_OrderRpt"
            End If
            If dtb1.Rows.Count = 0 Then MsgBox("No Records Found...", MsgBoxStyle.Information, Me.Text) : Exit Sub

            Printds.Tables.Clear()

            Printds.Tables.Add(dtb1)


            Rpt = New RptOrderCummReg

            'TxtCompName = CpRpt.ReportDefinition.ReportObjects.Item("TextCompFrm")
            'TxtCompName.Text = "From " + DtpFrmDt.Value.Date.ToString("dd/MM/yyyy") + " To " + dtpToDt.Value.Date.ToString("dd/MM/yyyy")


            TxtCompName = Rpt.ReportDefinition.ReportObjects.Item("TxtCompName")
            TxtCompName.Text = "KAAIKANI"

            TxtCompAdd1 = Rpt.ReportDefinition.ReportObjects.Item("TextTitle")
            TxtCompAdd1.Text = "Order Itemwise Report on " + dtpToDt.Value.Date

            Rpt.SetDataSource(Printds)

            Dim frm As New FrmDsRPT(Rpt, "")
            frm.Text = lblHeader.Text
            frm.Show()

            'Rpt = Nothing
            'Rpt.PrintToPrinter(1, True, 1, 1)
            'Rpt.Dispose()
            Printds.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
            Printds.Tables.Clear()
        End Try
    End Sub
    Sub Cr_OrderItemCummDelTimeRegister()
        Dim TxtCompName, TxtCompAdd1, TxtCity, TxtGstNo, TextTitle As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim dv As DataView
        Try
            Dim Rpt As Object
            'dtb1 = RptObj.RptPurHdr_Source(DtpFrmDt.Value.Date.ToString("dd/MMM/yyyy"), DtpToDt.Value.Date.ToString("dd/MMM/yyyy"), "")
            If RlItemDet.DataSource IsNot Nothing Then
                If blnProcess = True Then
                    dtb1 = RlItemDet.DataSource
                Else
                    dtb1 = RlItemDet.DataSource.totable
                End If
                dv = dtb1.DefaultView
                dv.RowFilter = "Category in ('Vegetables','Exotic Vegetables','Keerai/Green leaves','Fruits','Diary Products','Instant Foods')"
                dtb1 = dv.ToTable
                dtb1.TableName = "Qry_OrderRpt"
            End If

            If dtb1.Rows.Count = 0 Then MsgBox("No Records Found...", MsgBoxStyle.Information, Me.Text) : Exit Sub

            Printds.Tables.Clear()

            Printds.Tables.Add(dtb1)


            Rpt = New RptOrderCummDelTimeReg

            'TxtCompName = CpRpt.ReportDefinition.ReportObjects.Item("TextCompFrm")
            'TxtCompName.Text = "From " + DtpFrmDt.Value.Date.ToString("dd/MM/yyyy") + " To " + dtpToDt.Value.Date.ToString("dd/MM/yyyy")


            TxtCompName = Rpt.ReportDefinition.ReportObjects.Item("TxtCompName")
            TxtCompName.Text = "KAAIKANI - " + cmbLocation.Text

            TxtCompAdd1 = Rpt.ReportDefinition.ReportObjects.Item("TextTitle")
            TxtCompAdd1.Text = "Packing Vegitables Product List Report on " + dtpToDt.Value.Date

            Rpt.SetDataSource(Printds)

            'Dim frm As New FrmDsRPT(Rpt, "")
            'frm.Text = lblHeader.Text
            'frm.Show()


            Rpt.PrintToPrinter(1, True, 0, 0)
            'Rpt.Dispose()
            'Printds.Dispose()
            Rpt = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
            Printds.Tables.Clear()
        End Try

    End Sub
    Sub Cr_OrderCutVegItemCummDelTimeRegister()
        Dim TxtCompName, TxtCompAdd1, TxtCity, TxtGstNo, TextTitle As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim dv As DataView
        Try
            Dim Rpt As Object
            'dtb1 = RptObj.RptPurHdr_Source(DtpFrmDt.Value.Date.ToString("dd/MMM/yyyy"), DtpToDt.Value.Date.ToString("dd/MMM/yyyy"), "")
            If RlItemDet.DataSource IsNot Nothing Then
                If blnProcess = True Then
                    dtb1 = RlItemDet.DataSource
                Else
                    dtb1 = RlItemDet.DataSource.totable
                End If
                dv = dtb1.DefaultView
                dv.RowFilter = "Category in ('Cut Vegetables','Cut Keerai/Green leaves','Fruit Salads','Juices')"
                dtb1 = dv.ToTable
                dtb1.TableName = "Qry_OrderRpt"
            End If

            If dtb1.Rows.Count = 0 Then MsgBox("No Records Found...", MsgBoxStyle.Information, Me.Text) : Exit Sub

            Printds.Tables.Clear()

            Printds.Tables.Add(dtb1)


            Rpt = New RptOrderCummDelTimeReg

            'TxtCompName = CpRpt.ReportDefinition.ReportObjects.Item("TextCompFrm")
            'TxtCompName.Text = "From " + DtpFrmDt.Value.Date.ToString("dd/MM/yyyy") + " To " + dtpToDt.Value.Date.ToString("dd/MM/yyyy")


            TxtCompName = Rpt.ReportDefinition.ReportObjects.Item("TxtCompName")
            TxtCompName.Text = "KAAIKANI - " + cmbLocation.Text

            TxtCompAdd1 = Rpt.ReportDefinition.ReportObjects.Item("TextTitle")
            TxtCompAdd1.Text = "Packing CutVegitables Product List Report on " + dtpToDt.Value.Date

            Rpt.SetDataSource(Printds)

            'Dim frm As New FrmDsRPT(Rpt, "")
            'frm.Text = lblHeader.Text
            'frm.Show()

            Rpt.PrintToPrinter(1, True, 0, 0)
            'Rpt.PrintToPrinter(1, True, 1, 1)
            ' Rpt.Dispose()
            'Printds.Dispose()
            Rpt = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
            Printds.Tables.Clear()
        End Try

    End Sub
    Sub Cr_OrderBillDelPartnerRegister()
        Dim TxtCompName, TxtCompAdd1, TxtCity, TxtGstNo, TextTitle As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim dv As DataView
        Try
            Dim Rpt As Object
            'dtb1 = RptObj.RptPurHdr_Source(DtpFrmDt.Value.Date.ToString("dd/MMM/yyyy"), DtpToDt.Value.Date.ToString("dd/MMM/yyyy"), "")
            dtb1 = RptObj.RptLoadBillDelPartnerReport(DtpFrmDt.Value.Date.ToString("dd/MMM/yyyy"), dtpToDt.Value.Date.ToString("dd/MMM/yyyy"), cmbLocation.SelectedValue)
            'If RlItemDet.DataSource IsNot Nothing Then
            '    If blnProcess = True Then
            '        dtb1 = RlItemDet.DataSource
            '    Else
            '        dtb1 = RlItemDet.DataSource.totable
            '    End If
            '    dv = dtb1.DefaultView
            '    'dv.RowFilter = "Selection =true"
            '    dtb1 = dv.ToTable

            Dim tblDtDel As DataTable = dtb1.Clone
            tblDtDel.Columns("SNo").DataType = GetType(Integer)

            'rptLoad.Columns.Add("Selection", GetType(Boolean))
            Dim code As String = ""
            If dtb1.Rows.Count > 0 Then
                code = dtb1.Rows(0)("Code")
            End If
            Dim sNo As Integer = 1

            For i As Integer = 0 To dtb1.Rows.Count - 1

                Dim payment As String = dtb1.Rows(i)("Metadata")
                Dim pay As String
                If (payment <> "") Then
                    pay = RptObj.readPaymentMetadataJSON(payment)
                End If
                tblDtDel.Rows.Add()

                ' rptLoad.Rows(i)("SNo") = ReportTable.Rows(i)("SNo")
                If dtb1.Rows(i)("Code") <> code Then
                    tblDtDel.Rows(i)("SNo") = sNo + 1
                    sNo = sNo + 1
                Else
                    tblDtDel.Rows(i)("SNo") = CInt(sNo)
                End If
                tblDtDel.Rows(i)("Code") = dtb1.Rows(i)("Code")
                tblDtDel.Rows(i)("Time") = dtb1.Rows(i)("Time")
                'rptLoad.Rows(i)("Selection") = False
                Dim address As String = dtb1.Rows(i)("BillingAddress")
                Dim add1 As String = RptObj.readJSON(address)
                If DataClass.CommonView.Customer <> Nothing Then
                    tblDtDel.Rows(i)("Pincode") = DataClass.CommonView.Pincode
                Else
                    Dim dtCustAdd As DataTable = RptObj.RpCustomerDetail(dtb1.Rows(i)("CustomerId"))
                    If dtCustAdd.Rows.Count > 0 Then
                        tblDtDel.Rows(i)("Pincode") = dtCustAdd.Rows(0)("Pincode")
                    End If
                End If
                tblDtDel.Rows(i)("NetTotal") = dtb1.Rows(i)("NetTotal")
                tblDtDel.Rows(i)("OrdNo") = dtb1.Rows(i)("OrdNo")
                tblDtDel.Rows(i)("Note") = dtb1.Rows(i)("Note")
                ' If DataClass.CommonView.PaymentId <> Nothing Then
                'change code
                ' --- Payment Status Logic ---
                Dim meta As String = dtb1.Rows(i)("Metadata").ToString()
                Dim cutInst As String = ""
                Dim paymode As String = " "
                Dim isBillPaid As Boolean = False


                If dtb1.Columns.Contains("CuttingInstructions") Then
                    cutInst = dtb1.Rows(i)("CuttingInstructions").ToString()
                End If
                If dtb1.Columns.Contains("PaymentMode") Then
                    paymode = dtb1.Rows(i)("PaymentMode").ToString()
                End If

                If meta <> "" Then


                    If meta.ToLower().Contains("razorpaypaymentid") Then
                        isBillPaid = True
                    End If


                    If meta.ToLower().Contains("""mode"":""online""") Then
                        isBillPaid = True
                    End If


                    If meta.ToLower().Contains("""paymentmethod"":""offline""") Then
                        isBillPaid = False   ' force COD
                    End If

                End If
                Dim p As String = cutInst.ToLower().Replace(" ", "").Replace(".", "")
                If p.Contains("billpaid") Then
                    isBillPaid = True
                End If
                Dim p1 As String = paymode.ToLower().Replace(" ", "").Replace(".", "")
                If p1.Contains("billpaid") Then
                    isBillPaid = True
                End If

                If isBillPaid Then
                    tblDtDel.Rows(i)("PaymentStatus") = "Bill Paid"
                Else
                    tblDtDel.Rows(i)("PaymentStatus") = "COD"
                End If

                ' If pay <> "" Then
                'tblDtDel.Rows(i)("PaymentStatus") = "Bill Paid"
                '' rptLoad.Rows(i)("PaymentStatus") = "Bill Paid"
                'End If
                code = dtb1.Rows(i)("Code")
            Next
            'change//
            ' tblDtDel.DefaultView.Sort = "OrdNo ASC,Pincode asc"
            ' tblDtDel = rptLoad.DefaultView.ToTable
            tblDtDel.DefaultView.Sort = "OrdNo ASC,Pincode ASC"
            tblDtDel = tblDtDel.DefaultView.ToTable()
            'change code
            ' 'rptFinalLoad = rptLoad.Clone
            ' code = ""
            ' If tblDtDel.Rows.Count > 0 Then
            ' code = rptLoad.Rows(0)("Code")
            ' End If
            code = ""
            If tblDtDel.Rows.Count > 0 Then
                code = tblDtDel.Rows(0)("Code")
            End If
            sNo = 1
            For i As Integer = 0 To tblDtDel.Rows.Count - 1
                ' rptFinalLoad.Rows.Add()
                ' rptFinalLoad.Rows(i)("Id") = rptLoad.Rows(i)("Id")
                ' rptLoad.Rows(i)("SNo") = ReportTable.Rows(i)("SNo")
                If tblDtDel.Rows(i)("Code") <> code Then
                    tblDtDel.Rows(i)("SNo") = sNo + 1
                    sNo = sNo + 1
                Else
                    tblDtDel.Rows(i)("SNo") = CInt(sNo)
                End If
                code = tblDtDel.Rows(i)("Code")
            Next

            tblDtDel.TableName = "Qry_OrderRpt"
            ' End If

            If dtb1.Rows.Count = 0 Then MsgBox("No Records Found...", MsgBoxStyle.Information, Me.Text) : Exit Sub

            Printds.Tables.Clear()

            Printds.Tables.Add(tblDtDel)


            Rpt = New RptOrderDelPartnerReg

            'TxtCompName = CpRpt.ReportDefinition.ReportObjects.Item("TextCompFrm")
            'TxtCompName.Text = "From " + DtpFrmDt.Value.Date.ToString("dd/MM/yyyy") + " To " + dtpToDt.Value.Date.ToString("dd/MM/yyyy")


            TxtCompName = Rpt.ReportDefinition.ReportObjects.Item("TxtCompName")
            TxtCompName.Text = "KAAIKANI - " + cmbLocation.Text 'IIf(cmbLocation.SelectedValue = 4, "MADURAI", IIf(cmbLocation.SelectedValue = 6, "COIMBATORE", "SALEM"))

            TxtCompAdd1 = Rpt.ReportDefinition.ReportObjects.Item("TextTitle")
            TxtCompAdd1.Text = "Delivery Partner Bill Report on " + dtpToDt.Value.Date

            Rpt.SetDataSource(Printds)

            Dim frm As New FrmDsRPT(Rpt, "")
            frm.Text = lblHeader.Text
            frm.Show()

            'Rpt = Nothing
            'Rpt.PrintToPrinter(1, True, 1, 1)
            'Rpt.Dispose()
            Printds.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
            Printds.Tables.Clear()
        End Try

    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        'If rdbDetail.Checked Then
        '    Cr_OrderItemRegister()
        If rdbCumm.Checked Then
            Cr_OrderItemCummRegister()
        End If

    End Sub


    Private Sub rdbDetail_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbDetail.CheckedChanged
        FillGrids()
        blnProcess = True
    End Sub

    Private Sub rdbCumm_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbCumm.CheckedChanged
        FillGrids()
        blnProcess = True
    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        Dim FD As New OpenFileDialog()
        Dim F As String()
        Dim Filepath As String
        FD.Filter = "Excel Files (*.Xls)|(*.Xls)|(*.Xlsx)|*.*sx|All Files (*.*)|*.*"
        FD.FilterIndex = 1

        If FD.ShowDialog = DialogResult.OK Then
            Dim LocPath As String = FD.FileName
            'Filepath = FD.SafeFileName
            dtImport = readFromExcel(LocPath)
        End If
    End Sub

    Private Sub btnBillPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBillPrint.Click
        'For i As Integer = 0 To dgvReport.Rows.Count - 1
        '    Cr_OrderBill(dgvReport.Item("Code", i).Value.ToString())
        'Next
        Cr_OrderBill("")

    End Sub

    Private Sub chkAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAll.CheckedChanged
        'If chkAll.Checked = True Then
        '    For Each dr As DataGridViewRow In RlItemDet.Rows
        '        Selection(dr)
        '    Next
        '    RlItemDet.DataSource.AcceptChanges()
        '    RlItemDet.CurrentCell = RlItemDet("ItemName", 0)
        'Else
        '    FillGrids()
        'End If


    End Sub
    Sub Selection(ByVal Dr As DataGridViewRow)
        If chkAll.Checked = True Then
            Dr.Cells("Selection").Value = True
        Else
            Dr.Cells("Selection").Value = False
        End If
    End Sub

    Private Sub rdbAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbAll.CheckedChanged
        FillGrids()
    End Sub

    Private Sub rdpLess_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdpLess.CheckedChanged
        FillGrids()
    End Sub

    Private Sub rdbGreater_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbGreater.CheckedChanged
        FillGrids()
    End Sub

    Private Sub btnSmsBal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSmsBal.Click
        'Dim balStr As String = RptObj.CheckSmsBalance()
        'Dim bal As Double
        'If balStr <> "" Then
        '    bal = Val(balStr)
        '    If bal > 0 Then
        '        lblBal.Visible = True
        '        lblBal.Text = bal / 0.25
        '    End If
        'End If

        Dim whatApi As String = RptObj.SendWhatsAppMessages("")
        'RptObj.whatAppMultiNumbers()

    End Sub

    Private Sub btnFinalProdRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinalProdRpt.Click
        Try
            Dim sNoStr As String = ""
            If rdbCumm.Checked Then
                Dim rptLoad As DataTable
                TotalSumColStr = "QUANTITY"
                Dim timeType As String = ""
                If rdbAll.Checked Then
                    timeType = "ALL"
                    Dim dtSNoTbl As DataTable = RptObj.RptLoadDetailReport(DtpFrmDt.Value.Date.ToString("dd/MMM/yyyy"), dtpToDt.Value.Date.ToString("dd/MMM/yyyy"), "ALL", dtpTime.Value.ToString("dd/MMM/yyyy HH:mm:ss"), cmbLocation.SelectedValue)
                    ReportTable = RptObj.RptLoadCummDelTimeReport(DtpFrmDt.Value.Date.ToString("dd/MMM/yyyy"), dtpToDt.Value.Date.ToString("dd/MMM/yyyy"), timeType, dtpTime.Value.ToString("HH:mm:ss"), cmbLocation.SelectedValue)
                    'dgvReport.DataSource = ReportTable
                    RlItemDet.DataSource = ReportTable.Clone
                    Dim table As New DataTable
                    rptLoad = ReportTable.Clone

                    Dim sNo As Integer = 1
                    Dim code As String = dtSNoTbl.Rows(0)("Code")
                    For n As Integer = 0 To dtSNoTbl.Rows.Count - 1

                        ' rptLoad.Rows(i)("SNo") = ReportTable.Rows(i)("SNo")
                        If dtSNoTbl.Rows(n)("Code") <> code Then
                            dtSNoTbl.Rows(n)("SNo") = sNo + 1
                            sNo = sNo + 1
                        Else
                            dtSNoTbl.Rows(n)("SNo") = sNo
                        End If
                        Dim address As String = dtSNoTbl.Rows(n)("BillingAddress")
                        Dim add1 As String = RptObj.readJSON(address)
                        If DataClass.CommonView.Customer <> Nothing Then
                            dtSNoTbl.Rows(n)("Customer") = DataClass.CommonView.Customer
                            dtSNoTbl.Rows(n)("Address") = DataClass.CommonView.Address
                            dtSNoTbl.Rows(n)("CellNo") = DataClass.CommonView.CellNo
                            dtSNoTbl.Rows(n)("Pincode") = DataClass.CommonView.Pincode
                        Else
                            Dim dtCustAdd As DataTable = RptObj.RpCustomerDetail(dtSNoTbl.Rows(n)("CustomerId"))
                            If dtCustAdd.Rows.Count > 0 Then
                                dtSNoTbl.Rows(n)("Customer") = dtCustAdd.Rows(0)("Customer")
                                dtSNoTbl.Rows(n)("Address") = dtCustAdd.Rows(0)("StreetLine1") + "," + dtCustAdd.Rows(0)("StreetLine2") + "," + dtCustAdd.Rows(0)("City") + "-" + dtCustAdd.Rows(0)("Pincode")
                                dtSNoTbl.Rows(n)("CellNo") = dtCustAdd.Rows(0)("CellNo")
                                dtSNoTbl.Rows(n)("Pincode") = dtCustAdd.Rows(0)("Pincode")
                            End If
                        End If
                        code = dtSNoTbl.Rows(n)("Code")
                    Next

                    dtSNoTbl.DefaultView.Sort = "OrdNo ASC,Pincode asc"
                    dtSNoTbl = dtSNoTbl.DefaultView.ToTable

                    code = ""
                    If dtSNoTbl.Rows.Count > 0 Then
                        code = dtSNoTbl.Rows(0)("Code")
                    End If
                    sNo = 1
                    For c As Integer = 0 To dtSNoTbl.Rows.Count - 1
                        ' rptFinalLoad.Rows.Add()
                        ' rptFinalLoad.Rows(i)("Id") = rptLoad.Rows(i)("Id")
                        ' rptLoad.Rows(i)("SNo") = ReportTable.Rows(i)("SNo")
                        If dtSNoTbl.Rows(c)("Code") <> code Then
                            dtSNoTbl.Rows(c)("SNo") = sNo + 1
                            sNo = sNo + 1
                        Else
                            dtSNoTbl.Rows(c)("SNo") = sNo
                        End If
                        code = dtSNoTbl.Rows(c)("Code")
                    Next

                    For i As Integer = 0 To ReportTable.Rows.Count - 1
                        sNoStr = ""
                        rptLoad.Rows.Add()
                        rptLoad.Rows(i)("PCode") = ReportTable.Rows(i)("PCOde")
                        ' rptLoad.Rows(i)("Time") = ReportTable.Rows(i)("Time")
                        rptLoad.Rows(i)("ItemName") = ReportTable.Rows(i)("ItemName")
                        rptLoad.Rows(i)("Qty") = ReportTable.Rows(i)("Qty")
                        rptLoad.Rows(i)("DeliveryTime") = ReportTable.Rows(i)("DeliveryTime")
                        If dtImport Is Nothing Then
                        Else
                            If dtImport.Rows.Count > 0 Then
                                Dim dt As DataTable
                                Dim dataView As DataView = dtImport.DefaultView
                                If Not String.IsNullOrEmpty(rptLoad.Rows(i)("ItemName")) Then
                                    'dataView = New DataView(dtImport, String.Format("ItemName LIKE '%{0}'", rptLoad.Rows(i)("ItemName").ToString().Trim()), "", DataViewRowState.CurrentRows)
                                    'dataView.RowFilter = "ItemName like * '" & rptLoad.Rows(i)("ItemName").ToString().Trim() & "'"
                                    'dataView.RowFilter = "ItemName LIKE '%" + rptLoad.Rows(i)("ItemName").ToString().Trim() + "%'"
                                    ' dataView.RowFilter = "ItemName ='" + rptLoad.Rows(i)("ItemName").ToString().Trim() + "'"
                                    dataView.RowFilter = "SKU = '" & rptLoad.Rows(i)("PCODE").ToString().Trim() & "'"
                                    dt = dataView.ToTable
                                    If dt.Rows.Count > 0 Then
                                        rptLoad.Rows(i)("TamilName") = dt.Rows(0)("TamilName").ToString().Trim()
                                        rptLoad.Rows(i)("Category") = dt.Rows(0)("Category").ToString().Trim()
                                        rptLoad.Rows(i)("OrdNo") = dt.Rows(0)("OrdNo").ToString().Trim()
                                    End If
                                End If
                            End If
                        End If



                        If dtSNoTbl.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            Dim dataView1 As DataView = dtSNoTbl.DefaultView
                            dataView1.RowFilter = "PCode ='" + rptLoad.Rows(i)("PCode").ToString().Trim() + "' and DeliveryTime='" + rptLoad.Rows(i)("DeliveryTime").ToString().Trim() + "'"
                            dt1 = dataView1.ToTable
                            For k As Integer = 0 To dt1.Rows.Count - 1
                                If Val(dt1.Rows(k)("Qty")) > 1 Then
                                    Dim qty As Double = Val(dt1.Rows(k)("Qty"))
                                    For j As Integer = 0 To qty - 1
                                        sNoStr += dt1.Rows(k)("SNo").ToString().Trim() + ","
                                    Next
                                Else
                                    sNoStr += dt1.Rows(k)("SNo").ToString().Trim() + ","
                                End If
                            Next
                            If sNoStr <> "" Then
                                sNoStr = sNoStr.Remove(sNoStr.Length - 1, 1)
                            End If
                        End If
                        rptLoad.Rows(i)("SlNo") = sNoStr
                    Next

                    RlItemDet.DataSource = rptLoad
                    RptObj.RptLoadCummDelTimeReport_GridStyle(RlItemDet.Columns)
                    Cr_OrderItemCummDelTimeRegister()
                    Cr_OrderCutVegItemCummDelTimeRegister()
                End If
            End If
            If ReportTable Is Nothing Then Exit Sub
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnDelPartnerRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelPartnerRpt.Click
        Cr_OrderBillDelPartnerRegister()
    End Sub

    Private Sub btnGrpPrn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrpPrn.Click
        If rdbCumm.Checked Then
            Dim rptLoad As DataTable
            TotalSumColStr = "QUANTITY"
            Dim timeType As String = ""
            If rdbAll.Checked Then
                timeType = "ALL"
            ElseIf rdpLess.Checked Then
                timeType = "LESS"
            ElseIf rdbGreater.Checked Then
                timeType = "GREATER"
            Else
                timeType = "ALL"
            End If
            ReportTable = RptObj.RptLoadCummGroupReport(DtpFrmDt.Value.Date.ToString("dd/MMM/yyyy"), dtpToDt.Value.Date.ToString("dd/MMM/yyyy"), timeType, dtpTime.Value.ToString("HH:mm:ss"))
            'dgvReport.DataSource = ReportTable
            RlItemDet.DataSource = ReportTable.Clone
            Dim table As New DataTable
            rptLoad = ReportTable.Clone

            For i As Integer = 0 To ReportTable.Rows.Count - 1
                rptLoad.Rows.Add()
                rptLoad.Rows(i)("PCode") = ReportTable.Rows(i)("PCOde")
                ' rptLoad.Rows(i)("Time") = ReportTable.Rows(i)("Time")
                rptLoad.Rows(i)("ItemName") = ReportTable.Rows(i)("ItemName")
                rptLoad.Rows(i)("Qty") = ReportTable.Rows(i)("Qty")
                If dtImport Is Nothing Then
                Else
                    If dtImport.Rows.Count > 0 Then
                        Dim dt As DataTable
                        Dim dataView As DataView = dtImport.DefaultView
                        If Not String.IsNullOrEmpty(rptLoad.Rows(i)("ItemName")) Then
                            'dataView = New DataView(dtImport, String.Format("ItemName LIKE '%{0}'", rptLoad.Rows(i)("ItemName").ToString().Trim()), "", DataViewRowState.CurrentRows)
                            'dataView.RowFilter = "ItemName like * '" & rptLoad.Rows(i)("ItemName").ToString().Trim() & "'"
                            'dataView.RowFilter = "ItemName LIKE '%" + rptLoad.Rows(i)("ItemName").ToString().Trim() + "%'"
                            'dataView.RowFilter = "ItemName ='" + rptLoad.Rows(i)("ItemName").ToString().Trim() + "'"
                            dataView.RowFilter = "SKU ='" + rptLoad.Rows(i)("PCode").ToString().Trim() + "'"
                            dt = dataView.ToTable

                            If dt.Rows.Count > 0 Then
                                rptLoad.Rows(i)("TamilName") = dt.Rows(0)("TamilName").ToString().Trim()
                                rptLoad.Rows(i)("GroupName") = dt.Rows(0)("GroupName").ToString().Trim()
                                rptLoad.Rows(i)("Category") = dt.Rows(0)("Category").ToString().Trim()
                                rptLoad.Rows(i)("OrdNo") = dt.Rows(0)("OrdNo").ToString().Trim()
                                rptLoad.Rows(i)("Qty") = Val(rptLoad.Rows(i)("Qty")) * Val(dt.Rows(0)("Weight").ToString())
                            End If
                        End If
                    End If
                End If
            Next
            Dim TxtCompName, TxtCompAdd1, TxtCity, TxtGstNo, TextTitle As CrystalDecisions.CrystalReports.Engine.TextObject
            Dim dv As DataView
            Try
                Dim Rpt As Object
                'dtb1 = RptObj.RptPurHdr_Source(DtpFrmDt.Value.Date.ToString("dd/MMM/yyyy"), DtpToDt.Value.Date.ToString("dd/MMM/yyyy"), "")

                dv = rptLoad.DefaultView
                'dv.RowFilter = "Selection =true"
                rptLoad = dv.ToTable
                rptLoad.TableName = "Qry_OrderRpt"


                If rptLoad.Rows.Count = 0 Then MsgBox("No Records Found...", MsgBoxStyle.Information, Me.Text) : Exit Sub

                Printds.Tables.Clear()

                Printds.Tables.Add(rptLoad)


                Rpt = New RptOrderGroupCummReg

                'TxtCompName = CpRpt.ReportDefinition.ReportObjects.Item("TextCompFrm")
                'TxtCompName.Text = "From " + DtpFrmDt.Value.Date.ToString("dd/MM/yyyy") + " To " + dtpToDt.Value.Date.ToString("dd/MM/yyyy")


                TxtCompName = Rpt.ReportDefinition.ReportObjects.Item("TxtCompName")
                TxtCompName.Text = "KAAIKANI"

                TxtCompAdd1 = Rpt.ReportDefinition.ReportObjects.Item("TextTitle")
                TxtCompAdd1.Text = "Purchase Product List on " + dtpToDt.Value.Date

                Rpt.SetDataSource(Printds)

                Dim frm As New FrmDsRPT(Rpt, "")
                frm.Text = lblHeader.Text
                frm.Show()

                'Rpt = Nothing
                'Rpt.PrintToPrinter(1, True, 1, 1)
                'Rpt.Dispose()
                Printds.Dispose()
            Catch ex As Exception
                MsgBox(ex.Message)
                Printds.Tables.Clear()
            End Try
            'RlItemDet.DataSource = rptLoad
            'RptObj.RptLoadCummReport_GridStyle(RlItemDet.Columns)
        End If
    End Sub

    Private Sub btnCancelRpt_Click(sender As Object, e As EventArgs) Handles btnCancelRpt.Click
        Dim f As New FrmCancelRpt
        f.Show()
    End Sub

    Private Sub btnPriceUpdate_Click(sender As Object, e As EventArgs) Handles btnPriceUpdate.Click
        Dim FD As New OpenFileDialog()
        Dim F As String()
        Dim Filepath As String
        Dim isStatus As Boolean
        FD.Filter = "Excel Files (*.Xls)|(*.Xls)|(*.Xlsx)|*.*sx|All Files (*.*)|*.*"
        FD.FilterIndex = 1

        If FD.ShowDialog = DialogResult.OK Then
            Dim LocPath As String = FD.FileName
            'Filepath = FD.SafeFileName
            isStatus = readFromUpdatePriceExcel(LocPath)
            If isStatus = True Then
                MsgBox("Successfully Updated...")
            End If
        End If
    End Sub
End Class
