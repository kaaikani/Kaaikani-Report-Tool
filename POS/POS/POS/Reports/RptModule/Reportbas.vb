Public Module Reportbas
    Public Enum Reports
        Purchase = 0
        PurchaseItemWiseDetail
        PurchaseCategoryWiseDetail
    End Enum
      Public Enum SalesReports
        Sales = 0
        SalesItemWiseDetail
        SalesCategoryWiseDetail
        RSales
        RSalesItemWiseDetail
        RSalesCategoryWiseDetail
    End Enum
    Public Enum StkReports
        StockReport = 0
        StockLedger
        RptAgewise
        RptMRPRate
        DailyExpIncDet
        CostRate
        GodownWiseStock
        CustomerMonAnalysis
        EmpExpDet
        RptPtyCummulative
        RptPointLed
        RptItemLock
    End Enum
    Public Enum PointRpt
        PointAnalReport = 0
        EmpwisePointAnalRpt
        None
    End Enum
    Public Enum IntReports
        IntReport = 0
        VolumePoint
    End Enum
    Public Enum RptConv
        Convmonthly = 0
        ConvDaily = 1
        ConvDetail = 2
    End Enum
    Public Enum CatwiseStkReports
        StkCatwiseRpt
    End Enum
    Public Enum Rptbill
        RptBillwise = 0
        RptHourly
        RptBillCancel
        EmpCLDet
        None
    End Enum
    Public Enum ReturnReports
        PurRetReg = 0
        PurRetItemwise
        SalesRetReg
        SalesRetItem
        RetailRetReg
        RetailRetItem
    End Enum
    Public Enum GeneralReports
        DcReg = 0
        DamageReg
        DamageItemReg
        CustomerPointReg
        StockAdjustReg
    End Enum
    Public Enum RecReports
        Pay = 0
        Rec
    End Enum
    Public Enum RptDetailSales
        SalesCons = 0
        SalesTaxCons
    End Enum
End Module
