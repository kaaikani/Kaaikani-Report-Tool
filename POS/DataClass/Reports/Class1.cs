using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;
using System.Security.Authentication;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using RestSharp;


namespace DataClass
{
    public class OrderwiseRpt
    {
        string file = "F:\\BackUp\\kaaikani_vendurenew.sql";
        public DataTable RptLoadDetailReport(DateTime fDt, DateTime tDt, string timeType, DateTime time, int locationId)
        {

            string constring1 = "";
            //constring1 = "Server=" + CommonView.DBServer + "; Database = " + CommonView.DataBase + ";UID=root;Pwd=" + CommonView.Pwd + ";Port=" + CommonView.Port + " ;SslMode=none;Connect Timeout=30;Convert Zero Datetime=True;Charset=utf8;";
            constring1 = "Server=" + CommonView.DBServer + "; Database = " + CommonView.DataBase + ";UID=" + CommonView.UId + ";Pwd=" + CommonView.Pwd + ";Port=" + CommonView.Port + " ;SslMode=none;Connect Timeout=30;Convert Zero Datetime=True;Charset=utf8;";
            //con//constring1 = "Server=" + CommonView.DBServer + ";Uid=root;Database=" + CommonView.DataBase + ";Port=" + CommonView.Port + " ;Connect Timeout=30;Convert Zero Datetime=True;Charset=utf8;";
            //constring1 = "Server=localhost;Uid=root;Database=kaaikani;Port=4306;Connect Timeout=30;Convert Zero Datetime=True;Charset=utf8;";
            //string file = "C:\\backup.sql";
            string path = "";
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072 | SecurityProtocolType.Tls;
            path = file;//txb_Path.Text + year + "-" + month + "-" + day + "--" + hour + "-" + minute + "-" + second + ".sql";
            file = path;
            DataTable Tbl = new DataTable();
            MySqlDataAdapter Da = new MySqlDataAdapter();
            using (MySqlConnection conn = new MySqlConnection(constring1))
            {
                MySqlCommand cmd = new MySqlCommand();
                //{
                // using (MySqlBackup mb = new MySqlBackup(cmd))
                //{
                cmd.Connection = conn;
                conn.Open();
                //string qry = " SELECT O.iD,DENSE_RANK() OVER (ORDER BY Code) as SNo,CODE,CAST(O.updatedAt AS DATE)Date,CAST(O.updatedAt AS TIME)TIME,FULLNAME as Customer,concat(STREETLINE1 ,' ', STREETLINE2 ) as Address,POSTALCODE as Pincode,PHONENUMBER as CellNo,p.NAME as ItemName,QUANTITY as Qty,subTotalWithTax/100 as Total,(subTotalWithTax+shippingWithTax)/100 as NetTotal,st.Name as DeliveryTime,customFieldsOtherinstructions as CuttingInstructions ";
                //qry += " FROM `order` O,order_line OL,product_variant_translation P,stock_movement S,address A,shipping_line sl,shipping_method_translation st WHERE O.ID=OL.ORDERID AND OL.PRODUCTVARIANTID=P.ID AND S.ORDERLINEID=OL.ID AND A.CUSTOMERID=O.CUSTOMERID and sl.OrderId=o.Id and sl.shippingmethodid=st.Id AND CAST(O.updatedAt AS DATE) between '" + fDt.ToString("yyyy/MM/dd") + "' AND '" + tDt.ToString("yyyy/MM/dd") + "' and customFieldsClientrequesttocanceL=0 and o.State not in ('DELIVERED','CANCELLED') and st.Name='Tomorrow Morning Delivery (Charges + Tax)' ";
                //qry += " Union All";
                //qry += " SELECT O.iD,DENSE_RANK() OVER (ORDER BY Code) as SNo,CODE,CAST(O.updatedAt AS DATE)Date,CAST(O.updatedAt AS TIME)TIME,FULLNAME as Customer,concat(STREETLINE1 ,' ', STREETLINE2 ) as Address,POSTALCODE as Pincode,PHONENUMBER as CellNo,p.NAME as ItemName,QUANTITY as Qty,subTotalWithTax/100 as Total,(subTotalWithTax+shippingWithTax)/100 as NetTotal,st.Name as DeliveryTime,customFieldsOtherinstructions as CuttingInstructions ";
                //qry += " FROM `order` O,order_line OL,product_variant_translation P,stock_movement S,address A,shipping_line sl,shipping_method_translation st WHERE O.ID=OL.ORDERID AND OL.PRODUCTVARIANTID=P.ID AND S.ORDERLINEID=OL.ID AND A.CUSTOMERID=O.CUSTOMERID and sl.OrderId=o.Id and sl.shippingmethodid=st.Id AND CAST(O.updatedAt AS DATE) between '" + fDt.ToString("yyyy/MM/dd") + "' AND '" + tDt.ToString("yyyy/MM/dd") + "' and customFieldsClientrequesttocanceL=0 and o.State not in ('DELIVERED','CANCELLED') and st.Name='Tomorrow Evening Delivery (Charges + Tax)' ";
                //cmd = new MySqlCommand("Select * from Test", conn);
                string qry = "";
                if (timeType == "ALL")
                {
                    //qry = " Select * from (";
                    //qry += " SELECT O.iD,SKU AS PCODE,'' as SNo,CODE,CAST(O.updatedAt AS DATE)Date,CAST(O.updatedAt AS TIME)TIME,ShippingAddress as BillingAddress,'' as Customer,'' as Address,'' as CellNo,trim(p.name) as ItemName,'' as TamilName,QUANTITY as Qty,(price/100) as Rate,(QUANTITY*(price/100)) as Total,subTotalWithTax/100 as SubTotal,shippingWithTax/100 as Shipping,(subTotalWithTax+shippingWithTax)/100 as NetTotal,st.name as DeliveryTime,customFieldsOtherinstructions as CuttingInstructions,1 as OrdNo,CustomerId,'' as Pincode,py.metadata,'' as PaymentStatus ";
                    //qry += " FROM `order` O,payment py,order_line OL,product_variant_translation P,stock_movement S,shipping_line sl,shipping_method_translation st,product_variant PV, ";
                    //qry += " product_variant_price op WHERE O.ID=OL.ORDERID and py.OrderId=o.Id AND OL.PRODUCTVARIANTID=P.ID AND S.ORDERLINEID=OL.ID and sl.OrderId=o.Id and op.variantid=ol.productvariantid and op.variantid=p.id and sl.shippingmethodid=st.Id AND PV.iD=P.ID AND CAST(O.updatedAt AS DATE) between '" + fDt.ToString("yyyy/MM/dd") + "' AND '" + tDt.ToString("yyyy/MM/dd") + "' and customFieldsClientrequesttocanceL=0 and o.State not in ('DELIVERED','CANCELLED') and st.name='Tomorrow Morning Delivery (Rs.50 incl.Tax)' ";
                    //qry += " Union All";
                    //qry += " SELECT O.iD,SKU AS PCODE,'' as SNo,CODE,CAST(O.updatedAt AS DATE)Date,CAST(O.updatedAt AS TIME)TIME,ShippingAddress as BillingAddress,'' as Customer,'' as Address,'' as CellNo,trim(p.name) as ItemName,'' as TamilName,QUANTITY as Qty,(price/100) as Rate,(QUANTITY*(price/100)) Total,subTotalWithTax/100 as SubTotal,shippingWithTax/100 as Shipping,(subTotalWithTax+shippingWithTax)/100 as NetTotal,st.name as DeliveryTime,customFieldsOtherinstructions as CuttingInstructions,2 as OrdNo,CustomerId,'' as Pincode,py.metadata,'' as PaymentStatus ";
                    //qry += " FROM `order` O,payment py,order_line OL,product_variant_translation P,stock_movement S,shipping_line sl,shipping_method_translation st, ";
                    //qry += " product_variant_price op,product_variant PV WHERE O.ID=OL.ORDERID and py.OrderId=o.Id AND OL.PRODUCTVARIANTID=P.ID AND S.ORDERLINEID=OL.ID and sl.OrderId=o.Id and sl.shippingmethodid=st.Id and sl.OrderId=o.Id and op.variantid=ol.productvariantid and op.variantid=p.id AND PV.iD=P.ID AND CAST(O.updatedAt AS DATE) between '" + fDt.ToString("yyyy/MM/dd") + "' AND '" + tDt.ToString("yyyy/MM/dd") + "' and customFieldsClientrequesttocanceL=0 and o.State not in ('DELIVERED','CANCELLED') and st.name='Tomorrow Evening Delivery (Rs.25 incl.Tax)'  ";
                    //qry += ") a order by OrdNo,CAST(Time AS Time)";


                    //qry = " Select * from ";
                    //qry += " ( SELECT O.iD,SKU AS PCODE,'' as SNo,CODE,CAST(O.updatedAt AS DATE)Date, ";
                    //qry += " CAST(O.updatedAt AS TIME)TIME,ShippingAddress as BillingAddress,'' as Customer,'' as Address,'' as CellNo, ";
                    //qry += " trim(P.name) as ItemName,'' as TamilName, ";
                    //qry += " count(LineId) as Qty,S.ListPrice/100 as Rate, (Count(LineId)*(S.Listprice/100)) as Total, ";
                    //qry += " subTotalWithTax/100 as SubTotal,shippingWithTax/100 as Shipping,(subTotalWithTax+shippingWithTax)/100 as NetTotal, ";
                    //qry += " st.name as DeliveryTime,customFieldsOtherinstructions as CuttingInstructions,1 as OrdNo,CustomerId,'' as Pincode, ";
                    //qry += " py.metadata,";
                    //qry += " '' as PaymentStatus  ";
                    //qry += " FROM ";
                    //qry += " " + CommonView.DataBase + ".order_line OL," + CommonView.DataBase + ".product_variant_translation P,";
                    //qry += CommonView.DataBase + ".order_item  S,";
                    //qry += " " + CommonView.DataBase + ".shipping_line sl, ";
                    //qry += " " + CommonView.DataBase + ".shipping_method_translation st," + CommonView.DataBase + ".product_variant PV,   ";
                    //qry += " " + CommonView.DataBase + ".product_variant_price op, ";
                    //qry += CommonView.DataBase + ".order O ";
                    //qry += " left join " + CommonView.DataBase + ".payment py on py.OrderId=O.Id ";
                    //qry += " WHERE O.ID=OL.ORDERID ";//and py.OrderId=O.Id ";
                    //qry += " AND OL.PRODUCTVARIANTID=P.ID AND S.lineId=OL.ID and ";
                    //qry += " sl.OrderId=O.Id and op.variantid=OL.productvariantid and op.variantid=P.id and sl.shippingmethodid=st.Id AND ";
                    //qry += " PV.iD=P.ID AND CAST(O.updatedAt AS DATE) between '" + fDt.ToString("yyyy/MM/dd") + "' AND '" + tDt.ToString("yyyy/MM/dd") + "' and ";
                    //qry += " customFieldsClientrequesttocanceL=0 and O.State not in ('DELIVERED','CANCELLED','AddingItems') and ";
                    //qry += " st.name='Tomorrow Morning Delivery (Rs.50 incl.Tax)'  and S.Cancelled=0 ";
                    //qry += " group by O.iD,SKU ,CODE,O.updatedAt,ShippingAddress,subTotalWithTax,shippingWithTax,st.Name,customFieldsOtherinstructions, ";
                    //qry += " CustomerId,S.ListPrice,P.name,py.metadata ";
                    //qry += " Union All ";
                    //qry += " SELECT O.iD,SKU AS PCODE,'' as SNo,CODE, ";
                    //qry += " CAST(O.updatedAt AS DATE)Date,CAST(O.updatedAt AS TIME)TIME,ShippingAddress as BillingAddress,'' as Customer, ";
                    //qry += " '' as Address,'' as CellNo,trim(P.name) as ItemName,'' as TamilName,";
                    //qry += " count(LineId) as Qty,S.ListPrice/100 as Rate, (Count(LineId)*(S.Listprice/100)) as Total, ";
                    //qry += " subTotalWithTax/100 as SubTotal,shippingWithTax/100 as Shipping, ";
                    //qry += " (subTotalWithTax+shippingWithTax)/100 as NetTotal,st.name as DeliveryTime, ";
                    //qry += " customFieldsOtherinstructions as CuttingInstructions,2 as OrdNo,CustomerId,'' as Pincode,py.metadata, ";
                    //qry += " '' as PaymentStatus ";
                    //qry += " FROM ";
                    //qry += CommonView.DataBase + ".order_line OL, ";
                    //qry += " " + CommonView.DataBase + ".product_variant_translation P," + CommonView.DataBase + ".order_item  S, ";
                    //qry += " " + CommonView.DataBase + ".shipping_line sl, ";
                    //qry += " " + CommonView.DataBase + ".shipping_method_translation st,  " + CommonView.DataBase + ".product_variant_price op, ";
                    //qry += " " + CommonView.DataBase + ".product_variant PV, ";
                    //qry += CommonView.DataBase + ".order O ";
                    //qry += " left join " + CommonView.DataBase + ".payment py on py.OrderId=O.Id";
                    //qry += " WHERE O.ID=OL.ORDERID and ";//py.OrderId=O.Id 
                    //qry += " OL.PRODUCTVARIANTID=P.ID AND S.LINEID=OL.ID and ";
                    //qry += " sl.OrderId=O.Id and sl.shippingmethodid=st.Id and sl.OrderId=O.Id and op.variantid=OL.productvariantid and ";
                    //qry += " op.variantid=P.id AND PV.iD=P.ID AND CAST(O.updatedAt AS DATE) between '" + fDt.ToString("yyyy/MM/dd") + "' AND '" + tDt.ToString("yyyy/MM/dd") + "' and ";
                    //qry += " customFieldsClientrequesttocanceL=0 and O.State not in ('DELIVERED','CANCELLED','AddingItems') and ";
                    //qry += " st.name='Tomorrow Evening Delivery (Rs.25 incl.Tax)'  and S.Cancelled=0";
                    //qry += " group by O.iD,SKU ,CODE,O.updatedAt,ShippingAddress,subTotalWithTax,shippingWithTax,st.Name,customFieldsOtherinstructions, ";
                    //qry += " CustomerId,py.metadata,";
                    //qry += " S.ListPrice,P.name ) a  ";
                    //qry += " order by OrdNo,CAST(Time AS Time) ";

                    // qry = " Select * from ";
                    // qry += " ( SELECT Distinct O.iD,SKU AS PCODE,'' as SNo,CODE,CAST(O.updatedAt AS DATE)Date, ";
                    // qry += " CAST(O.updatedAt AS TIME)TIME,ShippingAddress as BillingAddress,'' as Customer,'' as Address,'' as CellNo, ";
                    // qry += " trim(P.name) as ItemName,'' as TamilName, ";
                    // qry += " (Quantity) as Qty,OL.ListPrice/100 as Rate, ((Quantity)*(OL.Listprice/100)) as Total, ";
                    // qry += " subTotalWithTax/100 as SubTotal,shippingWithTax/100 as Shipping,(subTotalWithTax+shippingWithTax)/100 as NetTotal, ";
                    // qry += " st.name as DeliveryTime,customFieldsOtherinstructions as CuttingInstructions,1 as OrdNo,CustomerId,'' as Pincode, ";
                    // qry += " py.metadata,";
                    // qry += " '' as PaymentStatus  ";
                    // qry += " FROM ";
                    // qry += " " + CommonView.DataBase + ".order_line OL," + CommonView.DataBase + ".product_variant_translation P,";
                    // //qry += CommonView.DataBase + ".order_item  S,";
                    // qry += " " + CommonView.DataBase + ".shipping_line sl, ";
                    // qry += " " + CommonView.DataBase + ".shipping_method_translation st," + CommonView.DataBase + ".product_variant PV,   ";
                    // qry += " " + CommonView.DataBase + ".product_variant_price op, ";
                    // qry += CommonView.DataBase + ".order O ";
                    // qry += " left join " + CommonView.DataBase + ".payment py on py.OrderId=O.Id ";
                    // qry += " left join " + CommonView.DataBase + ".order_channels_channel ch on O.Id=ch.OrderId ";
                    // qry += " WHERE O.ID=OL.ORDERID ";//and py.OrderId=O.Id ";
                    // qry += " AND OL.PRODUCTVARIANTID=P.ID AND "; // S.lineId=OL.ID and ";
                    // qry += " sl.OrderId=O.Id and op.variantid=OL.productvariantid and op.variantid=P.id and sl.shippingmethodid=st.Id AND ";
                    //// qry += " PV.iD=P.ID AND CAST(O.OrderPlacedAt AS DATE) between '" + fDt.ToString("yyyy/MM/dd") + "' AND '" + tDt.ToString("yyyy/MM/dd") + "' and ";
                    //// qry += " PV.iD=P.ID AND O.OrderPlacedAt between '" + fDt.ToString("yyyy/MM/dd") + " 19:30:00' AND '" + tDt.ToString("yyyy/MM/dd") + " 23:59:59' and ";
                    // qry += " customFieldsPlacedatistformatted between '" + fDt.ToString("yyyy/MM/dd") + " 00:00:00' AND '" + tDt.ToString("yyyy/MM/dd") + " 23:59:59' and ";
                    // qry += " customFieldsClientrequesttocanceL=0 and O.State not in ('DELIVERED','CANCELLED','AddingItems') and ";
                    qry = " SELECT * ";
                    qry += "FROM ( ";
                    qry += " SELECT DISTINCT ";
                    qry += "     O.id, ";
                    qry += " SKU AS PCode, ";
                    qry += " '' AS SNo, ";
                    qry += " Code, ";
                    qry += " CAST(O.OrderPlacedAt AS DATE) AS Date, ";
                    qry += " CAST(O.updatedAt AS TIME) AS Time, ";
                    qry += " ShippingAddress AS BillingAddress, ";
                    qry += " '' AS Customer, ";
                    qry += " '' AS Address, ";
                    qry += " '' AS CellNo, ";
                    qry += " TRIM(P.name) AS ItemName, ";
                    qry += " '' AS TamilName, ";
                    qry += " Quantity AS Qty, ";
                    qry += "pv.customFieldsShadowprice/100 AS ShadowPrice, ";
                    qry += " OL.ListPrice/100 AS Rate, ";
                    qry += " (Quantity * (OL.ListPrice/100)) AS Total, ";
                    qry += " subTotalWithTax/100 AS SubTotal, ";
                    qry += " shippingWithTax/100 AS Shipping, ";
                    qry += " (subTotalWithTax + shippingWithTax)/100 AS NetTotal, ";
                    qry += " st.name AS DeliveryTime, ";
                    qry += " customFieldsOtherinstructions AS CuttingInstructions, ";
                    qry += " COALESCE(JSON_UNQUOTE(JSON_EXTRACT(CAST(he.data AS JSON), '$.note')), '' ) AS PaymentMode,";
                    qry += " 1 AS OrdNo, ";
                    qry += " CustomerId, ";
                    qry += " '' AS Pincode, ";
                    qry += " py.metadata, ";
                    qry += " '' AS PaymentStatus,";
                   qry += "O.customFieldsLoyaltypointsused AS RewardPointUsed,";
                    qry += "O.couponCodes AS CouponCode,";
                    qry += "om.note AS Note";
                    qry += " FROM " + CommonView.DataBase + ".`order` O ";
                    qry += " INNER JOIN " + CommonView.DataBase + ".order_line OL ON O.ID = OL.ORDERID ";
                    qry += " INNER JOIN " + CommonView.DataBase + ".product_variant_translation P ON OL.PRODUCTVARIANTID = P.ID ";
                    qry += " INNER JOIN " + CommonView.DataBase + ".shipping_line sl ON sl.OrderId = O.Id ";
                    qry += " INNER JOIN " + CommonView.DataBase + ".shipping_method_translation st ON sl.shippingmethodid = st.Id ";
                    qry += " INNER JOIN " + CommonView.DataBase + ".product_variant_price op ON op.variantid = OL.productvariantid AND op.variantid = P.id ";
                    qry += " INNER JOIN " + CommonView.DataBase + ".product_variant AS pv ON pv.id = OL.productVariantId ";
                    qry += " LEFT JOIN " + CommonView.DataBase + ".payment py ON py.OrderId = O.Id ";
                    qry += " LEFT JOIN " + CommonView.DataBase + ".order_channels_channel ch ON O.Id = ch.OrderId ";
                    qry += " LEFT JOIN (SELECT he1.orderId, he1.data FROM " + CommonView.DataBase + ".history_entry he1 INNER JOIN (SELECT orderId, MAX(id) as maxId FROM " + CommonView.DataBase + ".history_entry WHERE type='ORDER_NOTE' GROUP BY orderId) he2 ON he1.orderId = he2.orderId AND he1.id = he2.maxId WHERE he1.type='ORDER_NOTE') he ON O.Id = he.orderId ";
                    qry += " LEFT JOIN " + CommonView.DataBase + ".order_modification om ON O.Id = om.OrderId ";
                    //qry += " WHERE customFieldsPlacedatistformatted BETWEEN '" + fDt.ToString("yyyy/MM/dd") + " 00:00:00' AND '" + tDt.ToString("yyyy/MM/dd") + " 23:59:59' ";
                    qry += " Where O.OrderPlacedAt between '" + fDt.ToString("yyyy/MM/dd") + " 18:30:00' AND '" + tDt.ToString("yyyy/MM/dd") + " 23:59:59' ";
                    qry += " AND customFieldsClientrequesttocanceL = 0 ";
                    qry += " AND py.state IN('Settled','Authorized')";
                    qry += " AND O.State NOT IN ('DELIVERED','CANCELLED','AddingItems') and  ";

                    if (locationId == 4) //|| locationId==1) 
                    { qry += " st.name='Tomorrow Morning Delivery (Rs.40 incl.Tax)' and "; }
                    qry += " ch.ChannelId= " + locationId;
                    //qry+= " and S.Cancelled=0 ";
                    //  qry += " group by O.iD,SKU ,CODE,O.updatedAt,ShippingAddress,subTotalWithTax,shippingWithTax,st.Name,customFieldsOtherinstructions, ";
                    //qry += " CustomerId,OL.ListPrice,P.name,py.metadata ";
                    if (locationId == 4) //|| locationId == 1)
                    {
                        qry += " Union All ";
                        //qry += " SELECT Distinct O.iD,SKU AS PCODE,'' as SNo,CODE, ";
                        //qry += " CAST(O.updatedAt AS DATE)Date,CAST(O.updatedAt AS TIME)TIME,ShippingAddress as BillingAddress,'' as Customer, ";
                        //qry += " '' as Address,'' as CellNo,trim(P.name) as ItemName,'' as TamilName,";
                        //qry += " (Quantity) as Qty,OL.ListPrice/100 as Rate, ((Quantity)*(OL.Listprice/100)) as Total, ";
                        //qry += " subTotalWithTax/100 as SubTotal,shippingWithTax/100 as Shipping, ";
                        //qry += " (subTotalWithTax+shippingWithTax)/100 as NetTotal,st.name as DeliveryTime, ";
                        //qry += " customFieldsOtherinstructions as CuttingInstructions,2 as OrdNo,CustomerId,'' as Pincode,py.metadata, ";
                        //qry += " '' as PaymentStatus ";
                        //qry += " FROM ";
                        //qry += CommonView.DataBase + ".order_line OL, ";
                        //qry += " " + CommonView.DataBase + ".product_variant_translation P,";//+ CommonView.DataBase + ".order_item  S, ";
                        //qry += " " + CommonView.DataBase + ".shipping_line sl, ";
                        //qry += " " + CommonView.DataBase + ".shipping_method_translation st,  " + CommonView.DataBase + ".product_variant_price op, ";
                        //qry += " " + CommonView.DataBase + ".product_variant PV, ";
                        //qry += CommonView.DataBase + ".order O ";
                        //qry += " left join " + CommonView.DataBase + ".payment py on py.OrderId=O.Id";
                        //qry += " left join " + CommonView.DataBase + ".order_channels_channel ch on O.Id=ch.OrderId ";
                        //qry += " WHERE O.ID=OL.ORDERID and ";//py.OrderId=O.Id 
                        //qry += " OL.PRODUCTVARIANTID=P.ID AND "; //S.LINEID=OL.ID and ";
                        //qry += " sl.OrderId=O.Id and sl.shippingmethodid=st.Id and sl.OrderId=O.Id and op.variantid=OL.productvariantid and ";
                        ////  qry += " op.variantid=P.id AND PV.iD=P.ID AND CAST(O.OrderPlacedAt AS DATE) between '" + fDt.ToString("yyyy/MM/dd") + "' AND '" + tDt.ToString("yyyy/MM/dd") + "' and ";
                        //qry += " op.variantid=P.id AND PV.iD=P.ID and ";
                        ////AND O.OrderPlacedAt between '" + fDt.ToString("yyyy/MM/dd") + " 19:30:00' AND '" + tDt.ToString("yyyy/MM/dd") + " 23:59:59' and ";
                        qry += " SELECT DISTINCT ";
                        qry += " O.id, ";
                        qry += " SKU AS PCode, ";
                        qry += " '' AS SNo, ";
                        qry += " Code, ";
                        qry += " CAST(O.OrderPlacedAt AS DATE) AS Date, ";
                        qry += " CAST(O.updatedAt AS TIME) AS Time, ";
                        qry += " ShippingAddress AS BillingAddress, ";
                        qry += " '' AS Customer, ";
                        qry += " '' AS Address, ";
                        qry += " '' AS CellNo, ";
                        qry += " TRIM(P.name) AS ItemName, ";
                        qry += " '' AS TamilName, ";
                        qry += " Quantity AS Qty, ";
                        qry += "pv.customFieldsShadowprice/100 AS ShadowPrice, ";
                        qry += " OL.ListPrice/100 AS Rate, ";
                        qry += " (Quantity * (OL.ListPrice/100)) AS Total, ";
                        qry += " subTotalWithTax/100 AS SubTotal, ";
                        qry += " shippingWithTax/100 AS Shipping, ";
                        qry += " (subTotalWithTax + shippingWithTax)/100 AS NetTotal, ";
                        qry += " st.name AS DeliveryTime, ";
                        qry += " customFieldsOtherinstructions AS CuttingInstructions, ";
                        qry += " COALESCE(JSON_UNQUOTE(JSON_EXTRACT(CAST(he.data AS JSON), '$.note')), '' ) AS PaymentMode,";
                        qry += " 2 AS OrdNo, ";
                        qry += " CustomerId, ";
                        qry += " '' AS Pincode, ";
                        qry += " py.metadata, ";
                        qry += " '' AS PaymentStatus, ";
                        qry += "O.customFieldsLoyaltypointsused AS RewardPointUsed,";
                        qry += "O.couponCodes AS CouponCode,";
                        qry += "om.note AS Note";
                        qry += " FROM " + CommonView.DataBase + ".`order` O ";
                        qry += " INNER JOIN " + CommonView.DataBase + ".order_line OL ON O.ID = OL.ORDERID ";
                        qry += " INNER JOIN " + CommonView.DataBase + ".product_variant_translation P ON OL.PRODUCTVARIANTID = P.ID ";
                        qry += " INNER JOIN " + CommonView.DataBase + ".shipping_line sl ON sl.OrderId = O.Id ";
                        qry += " INNER JOIN " + CommonView.DataBase + ".shipping_method_translation st ON sl.shippingmethodid = st.Id ";
                        qry += " INNER JOIN " + CommonView.DataBase + ".product_variant_price op ON op.variantid = OL.productvariantid AND op.variantid = P.id ";
                        qry += " INNER JOIN " + CommonView.DataBase + ".product_variant AS pv ON pv.id = OL.productVariantId ";
                        qry += " LEFT JOIN " + CommonView.DataBase + ".payment py ON py.OrderId = O.Id ";
                        qry += " LEFT JOIN " + CommonView.DataBase + ".order_channels_channel ch ON O.Id = ch.OrderId ";
                        qry += " LEFT JOIN (SELECT he1.orderId, he1.data FROM " + CommonView.DataBase + ".history_entry he1 INNER JOIN (SELECT orderId, MAX(id) as maxId FROM " + CommonView.DataBase + ".history_entry WHERE type='ORDER_NOTE' GROUP BY orderId) he2 ON he1.orderId = he2.orderId AND he1.id = he2.maxId WHERE he1.type='ORDER_NOTE') he ON O.Id = he.orderId ";
                        qry += " LEFT JOIN " + CommonView.DataBase + ".order_modification om ON O.Id = om.OrderId ";
                        // qry += " Where customFieldsPlacedatistformatted between '" + fDt.ToString("yyyy/MM/dd") + " 00:00:00' AND '" + tDt.ToString("yyyy/MM/dd") + " 23:59:59' and ";
                        qry += " Where O.OrderPlacedAt between '" + fDt.ToString("yyyy/MM/dd") + " 18:30:00' AND '" + tDt.ToString("yyyy/MM/dd") + " 23:59:59' and ";
                        qry += " customFieldsClientrequesttocanceL=0 and py.state IN('Settled','Authorized') AND O.State not in ('DELIVERED','CANCELLED','AddingItems') and ";
                        if (locationId == 4) { qry += " st.name='Tomorrow Evening Delivery (Rs.20 incl.Tax)'  and "; }
                        qry += " ch.ChannelId=" + locationId; //and S.Cancelled=0";
                        //  qry += " group by O.iD,SKU ,CODE,O.updatedAt,ShippingAddress,subTotalWithTax,shippingWithTax,st.Name,customFieldsOtherinstructions, ";
                        // qry += " CustomerId,py.metadata,";
                        //qry += " OL.ListPrice,P.name ";
                    }
                    qry += " ) a  ";
                    qry += " ORDER BY OrdNo, Time,Code; ";


                }
                else if (timeType == "LESS")
                {
                    qry = " Select * from (";
                    qry += " SELECT O.iD,SKU AS PCODE,DENSE_RANK() OVER (ORDER BY Code) as SNo,CODE,CAST(O.updatedAt AS DATE)Date,CAST(O.updatedAt AS TIME)TIME,ShippingAddress as BillingAddress,'' as Customer,'' as Address,'' as CellNo,trim(p.NAME) as ItemName,'' as TamilName,count(LineId) as Qty,PV.customFieldsShadowprice/100 AS ShadowPrice,s.ListPrice/100 as Rate, (Count(LineId)*(s.Listprice/100)) as as Total,subTotalWithTax/100 as SubTotal,shippingWithTax/100 as Shipping,(subTotalWithTax+shippingWithTax)/100 as NetTotal,st.Name as DeliveryTime,COALESCE((SELECT CAST(JSON_UNQUOTE(JSON_EXTRACT(CAST(he.data AS JSON), '$.note')) AS CHAR(1000) CHARACTER SET utf8mb4) COLLATE utf8mb4_unicode_ci FROM " + CommonView.DataBase + ".history_entry he WHERE he.orderId=O.Id AND he.type='ORDER_NOTE' ORDER BY he.updatedAt DESC LIMIT 1), CAST(O.customFieldsOtherinstructions AS CHAR(1000) CHARACTER SET utf8mb4) COLLATE utf8mb4_unicode_ci, CAST('' AS CHAR(1000) CHARACTER SET utf8mb4) COLLATE utf8mb4_unicode_ci) COLLATE utf8mb4_unicode_ci as PaymentMode,customFieldsOtherinstructions as CuttingInstructions,1 as OrdNo,CustomerId,'' as Pincode,py.metadata,'' as PaymentStatus ,";
                    qry += "O.customFieldsLoyaltypointsused AS RewardPointUsed,";
                    qry += "O.couponCodes AS CouponCode";
                    qry += " FROM " + CommonView.DataBase + ".order O," + CommonView.DataBase + ".payment py," + CommonView.DataBase + ".order_line OL," + CommonView.DataBase + ".product_variant_translation P," + CommonView.DataBase + ".order_item S," + CommonView.DataBase + ".shipping_line sl," + CommonView.DataBase + ".shipping_method_translation st, ";
                    qry += " " + CommonView.DataBase + ".product_variant PV," + CommonView.DataBase + ".product_variant_price op ";
                    qry += " WHERE O.ID=OL.ORDERID and py.OrderId=o.Id AND OL.PRODUCTVARIANTID=P.ID AND S.LINEID=OL.ID and sl.OrderId=o.Id and op.variantid=ol.productvariantid and op.variantid=p.id and sl.shippingmethodid=st.Id AND PV.iD=P.ID AND CAST(O.updatedAt AS DATE) between '" + fDt.ToString("yyyy/MM/dd") + "' AND '" + tDt.ToString("yyyy/MM/dd") + "' and customFieldsClientrequesttocanceL=0 and o.State not in ('DELIVERED','CANCELLED') and st.Name='Tomorrow Morning Delivery (Rs.40 incl.Tax)' and Cast(o.UpdatedAt as Time)<= '" + time.ToString("HH:mm:ss") + "'";
                    qry += " and S.Cancelled=0";
                    qry += " group by O.iD,SKU ,CODE,O.updatedAt,ShippingAddress,subTotalWithTax,shippingWithTax,st.Name,customFieldsOtherinstructions, ";
                    qry += " CustomerId,py.metadata,s.ListPrice,p.name ";
                    qry += " Union All";
                    qry += " SELECT O.iD,SKU AS PCODE,DENSE_RANK() OVER (ORDER BY Code) as SNo,CODE,CAST(O.updatedAt AS DATE)Date,CAST(O.updatedAt AS TIME)TIME,ShippingAddress as BillingAddress,'' as Customer,'' as Address,'' as CellNo,trim(p.NAME) as ItemName,'' as TamilName,count(LineId) as Qty,PV.customFieldsShadowprice/100 AS ShadowPrice,s.ListPrice/100 as Rate, (Count(LineId)*(s.Listprice/100)) as Total,subTotalWithTax/100 as SubTotal,shippingWithTax/100 as Shipping,(subTotalWithTax+shippingWithTax)/100 as NetTotal,st.Name as DeliveryTime,COALESCE((SELECT CAST(JSON_UNQUOTE(JSON_EXTRACT(CAST(he.data AS JSON), '$.note')) AS CHAR(1000) CHARACTER SET utf8mb4) COLLATE utf8mb4_unicode_ci FROM " + CommonView.DataBase + ".history_entry he WHERE he.orderId=O.Id AND he.type='ORDER_NOTE' ORDER BY he.updatedAt DESC LIMIT 1), CAST(O.customFieldsOtherinstructions AS CHAR(1000) CHARACTER SET utf8mb4) COLLATE utf8mb4_unicode_ci, CAST('' AS CHAR(1000) CHARACTER SET utf8mb4) COLLATE utf8mb4_unicode_ci) COLLATE utf8mb4_unicode_ci as PaymentMode,customFieldsOtherinstructions as CuttingInstructions,2 as OrdNo,CustomerId,'' as Pincode,py.metadata,'' as PaymentStatus,";
                    qry += "O.customFieldsLoyaltypointsused AS RewardPointUsed,";
                    qry += "O.couponCodes AS CouponCode";
                    qry += " FROM " + CommonView.DataBase + ".order O," + CommonView.DataBase + ".payment py," + CommonView.DataBase + ".order_line OL," + CommonView.DataBase + ".product_variant_translation P," + CommonView.DataBase + ".stock_movement S," + CommonView.DataBase + ".shipping_line sl," + CommonView.DataBase + ".shipping_method_translation st, ";
                    qry += CommonView.DataBase + ".product_variant_price op," + CommonView.DataBase + ".product_variant PV WHERE O.ID=OL.ORDERID and py.OrderId=o.Id AND OL.PRODUCTVARIANTID=P.ID AND S.ORDERLINEID=OL.ID and sl.OrderId=o.Id and sl.shippingmethodid=st.Id and sl.OrderId=o.Id and op.variantid=ol.productvariantid and op.variantid=p.id AND PV.iD=P.ID AND CAST(O.updatedAt AS DATE) between '" + fDt.ToString("yyyy/MM/dd") + "' AND '" + tDt.ToString("yyyy/MM/dd") + "' and customFieldsClientrequesttocanceL=0 and o.State not in ('DELIVERED','CANCELLED') and st.Name='Tomorrow Evening Delivery (Rs.20 incl.Tax)' and Cast(o.UpdatedAt as Time)<= '" + time.ToString("HH:mm:ss") + "'";
                    qry += " and S.Cancelled=0";
                    qry += " group by O.iD,SKU ,CODE,O.updatedAt,ShippingAddress,subTotalWithTax,shippingWithTax,st.Name,customFieldsOtherinstructions, ";
                    qry += " CustomerId,py.metadata,s.ListPrice,p.name ";
                    qry += ") a order by OrdNo,CAST(Time AS Time)";
                }
                else if (timeType == "GREATER")
                {
                    qry = " Select * from (";
                    qry += " SELECT O.iD,SKU AS PCODE,DENSE_RANK() OVER (ORDER BY Code) as SNo,CODE,CAST(O.updatedAt AS DATE)Date,CAST(O.updatedAt AS TIME)TIME,ShippingAddress as BillingAddress,'' as Customer,'' as Address,'' as CellNo,trim(p.NAME) as ItemName,'' as TamilName,count(LineId) as Qty,s.ListPrice/100 as Rate, (Count(LineId)*(s.Listprice/100)) as as Total,subTotalWithTax/100 as SubTotal,shippingWithTax/100 as Shipping,(subTotalWithTax+shippingWithTax)/100 as NetTotal,st.Name as DeliveryTime,COALESCE((SELECT CAST(JSON_UNQUOTE(JSON_EXTRACT(CAST(he.data AS JSON), '$.note')) AS CHAR(1000) CHARACTER SET utf8mb4) COLLATE utf8mb4_unicode_ci FROM " + CommonView.DataBase + ".history_entry he WHERE he.orderId=O.Id AND he.type='ORDER_NOTE' ORDER BY he.updatedAt DESC LIMIT 1), CAST(O.customFieldsOtherinstructions AS CHAR(1000) CHARACTER SET utf8mb4) COLLATE utf8mb4_unicode_ci, CAST('' AS CHAR(1000) CHARACTER SET utf8mb4) COLLATE utf8mb4_unicode_ci) COLLATE utf8mb4_unicode_ci as PaymentMode,customFieldsOtherinstructions as CuttingInstructions,1 as OrdNo,CustomerId,'' as Pincode,py.metadata,'' as PaymentStatus ,";
                    qry += "O.customFieldsLoyaltypointsused AS RewardPointUsed,";
                    qry += "O.couponCodes AS CouponCode";
                    qry += " FROM " + CommonView.DataBase + ".order O," + CommonView.DataBase + ".payment py," + CommonView.DataBase + ".order_line OL," + CommonView.DataBase + ".product_variant_translation P," + CommonView.DataBase + ".stock_movement S," + CommonView.DataBase + ".shipping_line sl," + CommonView.DataBase + ".shipping_method_translation st, ";
                    qry += " " + CommonView.DataBase + ".product_variant PV," + CommonView.DataBase + ".product_variant_price op WHERE O.ID=OL.ORDERID and py.OrderId=o.Id AND OL.PRODUCTVARIANTID=P.ID AND S.ORDERLINEID=OL.ID and sl.OrderId=o.Id and op.variantid=ol.productvariantid and op.variantid=p.id and sl.shippingmethodid=st.Id AND PV.iD=P.ID AND CAST(O.updatedAt AS DATE) between '" + fDt.ToString("yyyy/MM/dd") + "' AND '" + tDt.ToString("yyyy/MM/dd") + "' and customFieldsClientrequesttocanceL=0 and o.State not in ('DELIVERED','CANCELLED') and st.Name='Tomorrow Morning Delivery (Rs.40 incl.Tax)' and Cast(o.UpdatedAt as Time)>='" + time.ToString("HH:mm:ss") + "'";
                    qry += " and S.Cancelled=0";
                    qry += " group by O.iD,SKU ,CODE,O.updatedAt,ShippingAddress,subTotalWithTax,shippingWithTax,st.Name,customFieldsOtherinstructions, ";
                    qry += " CustomerId,py.metadata,s.ListPrice,p.name ";
                    qry += " Union All";
                    qry += " SELECT O.iD,SKU AS PCODE,DENSE_RANK() OVER (ORDER BY Code) as SNo,CODE,CAST(O.updatedAt AS DATE)Date,CAST(O.updatedAt AS TIME)TIME,ShippingAddress as BillingAddress,'' as Customer,'' as Address,'' as CellNo,trim(p.NAME) as ItemName,'' as TamilName,count(LineId) as Qty,s.ListPrice/100 as Rate, (Count(LineId)*(s.Listprice/100)) as as Total,subTotalWithTax/100 as SubTotal,shippingWithTax/100 as Shipping,(subTotalWithTax+shippingWithTax)/100 as NetTotal,st.Name as DeliveryTime,COALESCE((SELECT CAST(JSON_UNQUOTE(JSON_EXTRACT(CAST(he.data AS JSON), '$.note')) AS CHAR(1000) CHARACTER SET utf8mb4) COLLATE utf8mb4_unicode_ci FROM " + CommonView.DataBase + ".history_entry he WHERE he.orderId=O.Id AND he.type='ORDER_NOTE' ORDER BY he.updatedAt DESC LIMIT 1), CAST(O.customFieldsOtherinstructions AS CHAR(1000) CHARACTER SET utf8mb4) COLLATE utf8mb4_unicode_ci, CAST('' AS CHAR(1000) CHARACTER SET utf8mb4) COLLATE utf8mb4_unicode_ci) COLLATE utf8mb4_unicode_ci as PaymentMode,customFieldsOtherinstructions as CuttingInstructions,2 as OrdNo,CustomerId,'' as Pincode,py.metadata,'' as PaymentStatus,";
                    qry += "O.customFieldsLoyaltypointsused AS RewardPointUsed,";
                    qry += "O.couponCodes AS CouponCode";
                    qry += " FROM " + CommonView.DataBase + ".order O," + CommonView.DataBase + ".payment py," + CommonView.DataBase + ".order_line OL," + CommonView.DataBase + ".product_variant_translation P," + CommonView.DataBase + ".stock_movement S," + CommonView.DataBase + ".shipping_line sl," + CommonView.DataBase + ".shipping_method_translation st, ";
                    qry += CommonView.DataBase + ".product_variant_price op," + CommonView.DataBase + ".product_variant PV WHERE O.ID=OL.ORDERID and py.OrderId=o.Id AND OL.PRODUCTVARIANTID=P.ID AND S.ORDERLINEID=OL.ID and sl.OrderId=o.Id and sl.shippingmethodid=st.Id and sl.OrderId=o.Id and op.variantid=ol.productvariantid and op.variantid=p.id AND PV.iD=P.ID AND CAST(O.updatedAt AS DATE) between '" + fDt.ToString("yyyy/MM/dd") + "' AND '" + tDt.ToString("yyyy/MM/dd") + "' and customFieldsClientrequesttocanceL=0 and o.State not in ('DELIVERED','CANCELLED') and st.Name='Tomorrow Evening Delivery (Rs.20 incl.Tax)'  and Cast(o.UpdatedAt as Time)>='" + time.ToString("HH:mm:ss") + "'";
                    qry += " and S.Cancelled=0";
                    qry += " group by O.iD,SKU ,CODE,O.updatedAt,ShippingAddress,subTotalWithTax,shippingWithTax,st.Name,customFieldsOtherinstructions, ";
                    qry += " CustomerId,py.metadata,s.ListPrice,p.name ";
                    qry += ") a order by OrdNo,CAST(Time AS Time)";
                }
                cmd = new MySqlCommand(qry, conn);
                Da.SelectCommand = cmd;
                cmd.CommandTimeout = 1000000000;
                Da.Fill(Tbl);
                Tbl.TableName = "navigate";
                Da.Dispose();
                cmd.Dispose();
                conn.Close();
                // mb.ImportFromFile(file);
                conn.Close();
                return Tbl;
                //}
                // }
            }
        }

        public DataTable RptLoadCummReport(DateTime fDt, DateTime tDt, string timeType, DateTime time)
        {
            string constring1 = "";
            constring1 = "Server=" + CommonView.DBServer + "; Database = " + CommonView.DataBase + ";UID=" + CommonView.UId + ";Pwd=" + CommonView.Pwd + ";Port=" + CommonView.Port + " ;SslMode=none;Connect Timeout=30;Convert Zero Datetime=True;Charset=utf8;";
            //constring1 = "Server=localhost;Uid=root;Database=kaaikani;Port=3306;Connect Timeout=30;Convert Zero Datetime=True;Charset=utf8;";
            //constring1 = "Server=localhost;Uid=root;Database=kaaikani;Port=4306;Connect Timeout=30;Convert Zero Datetime=True;Charset=utf8;";
            //string file = "C:\\backup.sql";
            string path = "";
            path = file;//txb_Path.Text + year + "-" + month + "-" + day + "--" + hour + "-" + minute + "-" + second + ".sql";
            file = path;
            DataTable Tbl = new DataTable();
            MySqlDataAdapter Da = new MySqlDataAdapter();
            using (MySqlConnection conn = new MySqlConnection(constring1))
            {
                MySqlCommand cmd = new MySqlCommand();
                //{
                // using (MySqlBackup mb = new MySqlBackup(cmd))
                //{
                cmd.Connection = conn;
                conn.Open();
                string qry = "";
                if (timeType == "ALL")
                {
                    //qry = " SELECT SKU as PCOde,Trim(P.NAME) as ItemName,'' as TamilName,'' as Category,Count(S.LineId) as Qty,'' as OrdNo";
                    ////qry += " FROM `order` O,order_line OL,product_variant_translation P,stock_movement S,shipping_line sl,shipping_method_translation st WHERE O.ID=OL.ORDERID AND OL.PRODUCTVARIANTID=P.ID AND S.ORDERLINEID=OL.ID and sl.OrderId=o.Id and sl.shippingmethodid=st.Id AND CAST(O.updatedAt AS DATE) between '" + fDt.ToString("yyyy/MM/dd") + "' AND '" + tDt.ToString("yyyy/MM/dd") + "' and customFieldsClientrequesttocanceL=0 and o.State not in ('DELIVERED','CANCELLED')";
                    //qry += " FROM " + CommonView.DataBase + ".order O," + CommonView.DataBase + ".order_line OL," + CommonView.DataBase + ".product_variant_translation P,";
                    //qry += CommonView.DataBase + ".order_item S," + CommonView.DataBase + ".shipping_line sl," + CommonView.DataBase + ".shipping_method_translation st,";
                    //qry += CommonView.DataBase + ".product_variant PV WHERE O.ID=OL.ORDERID AND OL.PRODUCTVARIANTID=P.ID AND S.LINEID=OL.ID and sl.OrderId=O.Id and P.Id=PV.Id ";
                    //qry += " and sl.shippingmethodid=st.Id AND CAST(O.updatedAt AS DATE) between '" + fDt.ToString("yyyy/MM/dd") + "' AND '" + tDt.ToString("yyyy/MM/dd") + "'";
                    //qry += " and customFieldsClientrequesttocanceL=0 and O.State not in ('DELIVERED','CANCELLED') and S.Cancelled=0";
                    //qry += " Group by SKU,P.name oRDER BY trim(P.name) ASC ";

                    qry = " SELECT SKU as PCOde,Trim(P.NAME) as ItemName,'' as TamilName,'' as Category,(Quantity) as Qty,'' as OrdNo";
                    //qry += " FROM `order` O,order_line OL,product_variant_translation P,stock_movement S,shipping_line sl,shipping_method_translation st WHERE O.ID=OL.ORDERID AND OL.PRODUCTVARIANTID=P.ID AND S.ORDERLINEID=OL.ID and sl.OrderId=o.Id and sl.shippingmethodid=st.Id AND CAST(O.updatedAt AS DATE) between '" + fDt.ToString("yyyy/MM/dd") + "' AND '" + tDt.ToString("yyyy/MM/dd") + "' and customFieldsClientrequesttocanceL=0 and o.State not in ('DELIVERED','CANCELLED')";
                    //qry += " FROM " + CommonView.DataBase + ".order O," + CommonView.DataBase + ".order_line OL," + CommonView.DataBase + ".product_variant_translation P,";
                    ////qry += CommonView.DataBase + ".order_item S," + 
                    //qry += CommonView.DataBase + ".shipping_line sl," + CommonView.DataBase + ".shipping_method_translation st,";
                    //qry += CommonView.DataBase + ".product_variant PV WHERE O.ID=OL.ORDERID AND OL.PRODUCTVARIANTID=P.ID "; //AND S.LINEID=OL.ID 
                    //qry += " and sl.OrderId=O.Id and P.Id=PV.Id and ";
                    //// qry += " and sl.shippingmethodid=st.Id AND CAST(O.OrderPlacedAt AS DATE) between '" + fDt.ToString("yyyy/MM/dd") + "' AND '" + tDt.ToString("yyyy/MM/dd") + "'";
                    //// qry += " and sl.shippingmethodid=st.Id AND O.OrderPlacedAt between '" + fDt.ToString("yyyy/MM/dd") + " 19:30:00' AND '" + tDt.ToString("yyyy/MM/dd") + " 23:59:59'";
                    qry += " FROM wow_vendure.`order` O ";
                    qry += " INNER JOIN wow_vendure.order_line OL ON O.ID = OL.ORDERID ";
                    qry += " INNER JOIN wow_vendure.product_variant_translation P ON OL.PRODUCTVARIANTID = P.ID ";
                    qry += " INNER JOIN wow_vendure.shipping_line sl ON sl.OrderId = O.Id ";
                    qry += " INNER JOIN wow_vendure.shipping_method_translation st ON sl.shippingmethodid = st.Id ";
                    qry += " INNER JOIN wow_vendure.product_variant_price op ON op.variantid = OL.productvariantid AND op.variantid = P.id ";
                    qry += " INNER JOIN product_variant AS pv ON pv.id = OL.productVariantId ";
                    qry += " LEFT JOIN wow_vendure.payment py ON py.OrderId = O.Id ";
                    qry += " LEFT JOIN wow_vendure.order_channels_channel ch ON O.Id = ch.OrderId ";
                    qry += " Where O.OrderPlacedAt between '" + fDt.ToString("yyyy/MM/dd") + " 18:30:00' AND '" + tDt.ToString("yyyy/MM/dd") + " 23:59:59' ";
                    //  qry += " WHERE customFieldsPlacedatistformatted between '" + fDt.ToString("yyyy/MM/dd") + " 00:00:00' AND '" + tDt.ToString("yyyy/MM/dd") + " 23:59:59' and ";
                    qry += " and customFieldsClientrequesttocanceL=0 and O.State not in ('DELIVERED','CANCELLED','AddingItems') "; //and S.Cancelled=0";
                    //qry += " Group by SKU,P.name 
                    qry += " oRDER BY trim(P.name) ASC ";
                }
                else if (timeType == "LESS")
                {
                    qry = " SELECT SKU as PCOde,Trim(P.NAME) as ItemName,'' as TamilName,'' as Category,Count(S.LineId) as Qty,'' as OrdNo";
                    //qry += " FROM `order` O,order_line OL,product_variant_translation P,stock_movement S,shipping_line sl,shipping_method_translation st WHERE O.ID=OL.ORDERID AND OL.PRODUCTVARIANTID=P.ID AND S.ORDERLINEID=OL.ID and sl.OrderId=o.Id and sl.shippingmethodid=st.Id AND CAST(O.updatedAt AS DATE) between '" + fDt.ToString("yyyy/MM/dd") + "' AND '" + tDt.ToString("yyyy/MM/dd") + "' and customFieldsClientrequesttocanceL=0 and o.State not in ('DELIVERED','CANCELLED')";
                    qry += " FROM " + CommonView.DataBase + ".order O," + CommonView.DataBase + ".order_line OL," + CommonView.DataBase + ".product_variant_translation P,";
                    qry += CommonView.DataBase + ".order_item S," + CommonView.DataBase + ".shipping_line sl," + CommonView.DataBase + ".shipping_method_translation st,";
                    qry += CommonView.DataBase + ".product_variant PV WHERE O.ID=OL.ORDERID AND OL.PRODUCTVARIANTID=P.ID AND S.LINEID=OL.ID and sl.OrderId=O.Id and P.Id=PV.Id ";
                    qry += " and sl.shippingmethodid=st.Id AND CAST(O.updatedAt AS DATE) between '" + fDt.ToString("yyyy/MM/dd") + "' AND '" + tDt.ToString("yyyy/MM/dd") + "'";
                    qry += " and customFieldsClientrequesttocanceL=0 and O.State not in ('DELIVERED','CANCELLED') and Cast(O.UpdatedAt as Time)<= '" + time.ToString("HH:mm:ss") + "'";
                    qry += " and S.Cancelled=0";
                    qry += " Group by SKU,P.name oRDER BY trim(P.name) ASC ";
                }
                else if (timeType == "GREATER")
                {
                    qry = " SELECT SKU as PCOde,Trim(P.NAME) as ItemName,'' as TamilName,'' as Category,Count(S.LineId) as Qty,'' as OrdNo";
                    //qry += " FROM `order` O,order_line OL,product_variant_translation P,stock_movement S,shipping_line sl,shipping_method_translation st WHERE O.ID=OL.ORDERID AND OL.PRODUCTVARIANTID=P.ID AND S.ORDERLINEID=OL.ID and sl.OrderId=o.Id and sl.shippingmethodid=st.Id AND CAST(O.updatedAt AS DATE) between '" + fDt.ToString("yyyy/MM/dd") + "' AND '" + tDt.ToString("yyyy/MM/dd") + "' and customFieldsClientrequesttocanceL=0 and o.State not in ('DELIVERED','CANCELLED')";
                    qry += " FROM " + CommonView.DataBase + ".order O," + CommonView.DataBase + ".order_line OL," + CommonView.DataBase + ".product_variant_translation P,";
                    qry += CommonView.DataBase + ".order_item S," + CommonView.DataBase + ".shipping_line sl," + CommonView.DataBase + ".shipping_method_translation st,";
                    qry += CommonView.DataBase + ".product_variant PV WHERE O.ID=OL.ORDERID AND OL.PRODUCTVARIANTID=P.ID AND S.LINEID=OL.ID and sl.OrderId=O.Id and P.Id=PV.Id ";
                    qry += " and sl.shippingmethodid=st.Id AND CAST(O.updatedAt AS DATE) between '" + fDt.ToString("yyyy/MM/dd") + "' AND '" + tDt.ToString("yyyy/MM/dd") + "'";
                    qry += " and customFieldsClientrequesttocanceL=0 and O.State not in ('DELIVERED','CANCELLED') and Cast(o.UpdatedAt as Time)>= '" + time.ToString("HH:mm:ss") + "'";
                    qry += " and S.Cancelled=0";
                    qry += " Group by SKU,P.name oRDER BY trim(P.name) ASC ";
                }
                //cmd = new MySqlCommand("Select * from Test", conn);
                cmd = new MySqlCommand(qry, conn);
                Da.SelectCommand = cmd;
                Da.Fill(Tbl);
                Tbl.TableName = "navigate";
                Da.Dispose();
                cmd.Dispose();
                conn.Close();
                // mb.ImportFromFile(file);
                conn.Close();
                return Tbl;
                //}
                // }
            }
        }

        public DataTable RptLoadCummDelTimeReport(DateTime fDt, DateTime tDt, string timeType, DateTime time, int locationId)
        {
            string constring1 = "";
            //constring1 = "Server=" + CommonView.DBServer + "; Database = " + CommonView.DataBase + ";UID=root;Pwd=" + CommonView.Pwd + ";Port=" + CommonView.Port + " ;SslMode=none;Connect Timeout=30;Convert Zero Datetime=True;Charset=utf8;";
            constring1 = "Server=" + CommonView.DBServer + "; Database = " + CommonView.DataBase + ";UID=" + CommonView.UId + ";Pwd=" + CommonView.Pwd + ";Port=" + CommonView.Port + " ;SslMode=none;Connect Timeout=30;Convert Zero Datetime=True;Charset=utf8;";
            //constring1 = "Server=localhost;Uid=root;Database=kaaikani;Port=3306;Connect Timeout=30;Convert Zero Datetime=True;Charset=utf8;";
            //constring1 = "Server=localhost;Uid=root;Database=kaaikani;Port=4306;Connect Timeout=30;Convert Zero Datetime=True;Charset=utf8;";
            //string file = "C:\\backup.sql";
            string path = "";
            path = file;//txb_Path.Text + year + "-" + month + "-" + day + "--" + hour + "-" + minute + "-" + second + ".sql";
            file = path;
            DataTable Tbl = new DataTable();
            MySqlDataAdapter Da = new MySqlDataAdapter();
            using (MySqlConnection conn = new MySqlConnection(constring1))
            {
                MySqlCommand cmd = new MySqlCommand();
                //{
                // using (MySqlBackup mb = new MySqlBackup(cmd))
                //{
                cmd.Connection = conn;
                conn.Open();
                string qry = "";
                if (timeType == "ALL")
                {
                    qry = " Select * from (";
                    // qry += " SELECT distinct SKU as PCOde,Trim(P.name) as ItemName,'' as TamilName,'' as Category,sum(Quantity) as Qty,st.Name as DeliveryTime,1 as OrdNo,'' as SlNo";
                    qry += " SELECT pv.SKU AS PCode, ";
                    qry += " TRIM(P.name) AS ItemName, '' AS TamilName,'' AS Category,SUM(OL.Quantity) AS Qty, st.Name AS DeliveryTime, 1 AS OrdNo,'' AS SlNo ";
                    ////qry += " FROM `order` O,order_line OL,product_variant_translation P,stock_movement S,shipping_line sl,shipping_method_translation st WHERE O.ID=OL.ORDERID AND OL.PRODUCTVARIANTID=P.ID AND S.ORDERLINEID=OL.ID and sl.OrderId=o.Id and sl.shippingmethodid=st.Id AND CAST(O.updatedAt AS DATE) between '" + fDt.ToString("yyyy/MM/dd") + "' AND '" + tDt.ToString("yyyy/MM/dd") + "' and customFieldsClientrequesttocanceL=0 and o.State not in ('DELIVERED','CANCELLED')";
                    // qry += " FROM " + CommonView.DataBase + ".order_line OL," + CommonView.DataBase + ".product_variant_translation P,";
                    // //qry += CommonView.DataBase + ".order_item S," + 
                    // qry += CommonView.DataBase + ".shipping_line sl," + CommonView.DataBase + ".shipping_method_translation st,";
                    // // qry += CommonView.DataBase + ".product_variant_price op," 

                    // qry += CommonView.DataBase + ".product_variant PV, ";
                    // qry += CommonView.DataBase + ".order O ";
                    // qry += " left join " + CommonView.DataBase + ".order_channels_channel ch on O.Id=ch.OrderId ";
                    // qry += " WHERE O.ID=OL.ORDERID AND OL.PRODUCTVARIANTID=P.ID and ";//AND S.LINEID=OL.ID and ";
                    // qry += " sl.OrderId=O.Id and P.Id=PV.Id and ";
                    // qry += " sl.OrderId=O.Id and ";
                    // //and op.variantid=OL.productvariantid and op.variantid=P.id  ";
                    // //qry += " and sl.shippingmethodid=st.Id AND CAST(O.OrderPlacedAt AS DATE) between '" + fDt.ToString("yyyy/MM/dd") + "' AND '" + tDt.ToString("yyyy/MM/dd") + "'";
                    // // qry += " and sl.shippingmethodid=st.Id AND O.OrderPlacedAt between '" + fDt.ToString("yyyy/MM/dd") + " 19:30:00' AND '" + tDt.ToString("yyyy/MM/dd") + " 23:59:59'";
                    //// qry += " customFieldsPlacedatistformatted between '" + fDt.ToString("yyyy/MM/dd") + " 00:00:00' AND '" + tDt.ToString("yyyy/MM/dd") + " 23:59:59' and ";
                    // qry += "  cast(O.OrderPlacedAt as Date) between '" + fDt.ToString("yyyy/MM/dd") + "' AND '" + tDt.ToString("yyyy/MM/dd") + "' and ";
                    // qry += " customFieldsClientrequesttocanceL=0 and O.State not in ('DELIVERED','CANCELLED','AddingItems') and";
                    // if (locationId == 4)
                    // { qry += "  st.Name='Tomorrow Morning Delivery (Rs.40 incl.Tax)' and "; }
                    // //  qry += " and S.Cancelled=0";
                    // qry += " ch.ChannelId= " + locationId;
                    // qry += " Group by SKU,P.name,st.Name ";
                    // if (locationId == 4)
                    // {
                    //     qry += " Union All";
                    //qry += " FROM " + CommonView.DataBase + ".`order` O ";
                    //qry += " INNER JOIN " + CommonView.DataBase + ".order_line OL ON O.ID = OL.ORDERID ";
                    //qry += " INNER JOIN " + CommonView.DataBase + ".product_variant_translation P ON OL.PRODUCTVARIANTID = P.ID ";
                    //qry += " INNER JOIN " + CommonView.DataBase + ".shipping_line sl ON sl.OrderId = O.Id ";
                    //qry += " INNER JOIN " + CommonView.DataBase + ".shipping_method_translation st ON sl.shippingmethodid = st.Id ";
                    //qry += " INNER JOIN " + CommonView.DataBase + ".product_variant_price op ON op.variantid = OL.productvariantid AND op.variantid = P.id ";
                    //qry += " INNER JOIN " + CommonView.DataBase + ".product_variant AS pv ON pv.id = OL.productVariantId ";
                    //qry += " LEFT JOIN " + CommonView.DataBase + ".payment py ON py.OrderId = O.Id ";
                    //qry += " LEFT JOIN " + CommonView.DataBase + ".order_channels_channel ch ON O.Id = ch.OrderId ";
                    ////qry += " WHERE customFieldsPlacedatistformatted BETWEEN '" + fDt.ToString("yyyy/MM/dd") + " 00:00:00' AND '" + tDt.ToString("yyyy/MM/dd") + " 23:59:59' ";
                    //qry += " Where O.OrderPlacedAt between '" + fDt.ToString("yyyy/MM/dd") + " 18:30:00' AND '" + tDt.ToString("yyyy/MM/dd") + " 23:59:59' ";
                    //qry += " AND customFieldsClientrequesttocanceL = 0 ";
                    //qry += " AND O.State NOT IN ('DELIVERED','CANCELLED','AddingItems') and ";

                    //if (locationId == 4) //|| locationId==1) 
                    //{ qry += " st.name='Tomorrow Morning Delivery (Rs.40 incl.Tax)' and "; }
                    //qry += " ch.ChannelId= " + locationId;
                    //qry += " Group by ItemName";
                    ////qry+= " and S.Cancelled=0 ";
                    ////  qry += " group by O.iD,SKU ,CODE,O.updatedAt,ShippingAddress,subTotalWithTax,shippingWithTax,st.Name,customFieldsOtherinstructions, ";
                    ////qry += " CustomerId,OL.ListPrice,P.name,py.metadata ";
                    qry += " FROM wow_vendure.`order` O ";
                    qry += " INNER JOIN wow_vendure.order_line OL ";
                    qry += " ON O.Id = OL.OrderId ";
                    qry += " INNER JOIN wow_vendure.product_variant pv ";
                    qry += " ON pv.id = OL.productVariantId ";
                    qry += " INNER JOIN wow_vendure.product_variant_translation P ";
                    qry += " ON P.id = pv.id ";
                    qry += " AND P.languageCode = 'en' ";//  -- ✅ ensures single row per variant
                    qry += " INNER JOIN wow_vendure.shipping_line sl ";
                    qry += " ON sl.OrderId = O.Id ";
                    qry += " INNER JOIN wow_vendure.shipping_method_translation st ";
                    qry += " ON st.Id = sl.shippingmethodid ";
                    qry += " AND st.languageCode = 'en' ";//  -- ✅ ensures single translation row
                    qry += " INNER JOIN wow_vendure.product_variant_price op ";
                    qry += " ON op.variantid = pv.id ";
                    qry += " AND op.channelid = " + locationId; //        -- ✅ ensures one price per variant for this channel
                    qry += " INNER JOIN wow_vendure.order_channels_channel ch ";
                    qry += " ON ch.OrderId = O.Id ";
                    qry += " AND ch.ChannelId = " + locationId;//       -- ✅ ensures only one matching row per order
                    qry += " WHERE ";
                    qry += "  O.OrderPlacedAt between '" + fDt.ToString("yyyy/MM/dd") + " 18:30:00' AND '" + tDt.ToString("yyyy/MM/dd") + " 23:59:59' ";
                    qry += " AND O.customFieldsClientrequesttocanceL = 0 ";
                    qry += " AND O.State NOT IN ('DELIVERED', 'CANCELLED', 'AddingItems') ";
                    if (locationId == 4) //|| locationId==1) 
                    { qry += " AND st.name = 'Tomorrow Morning Delivery (Rs.40 incl.Tax)' "; }
                    qry += " GROUP BY  ";
                    qry += " pv.SKU, ";
                    qry += " P.name, ";
                    qry += " st.Name ";
                    if (locationId == 4) //|| locationId == 1)
                    {
                        qry += " Union All ";

                        //qry += " SELECT distinct SKU as PCOde,Trim(P.name) as ItemName,'' as TamilName,'' as Category,sum(Quantity) as Qty,st.Name as DeliveryTime,2 as OrdNo,'' as SlNo ";
                        qry += " SELECT pv.SKU AS PCode, ";
                        qry += " TRIM(P.name) AS ItemName, '' AS TamilName,'' AS Category,SUM(OL.Quantity) AS Qty, st.Name AS DeliveryTime, 2 AS OrdNo,'' AS SlNo ";
                        //qry += " FROM " + CommonView.DataBase + ".order_line OL," + CommonView.DataBase + ".product_variant_translation P,";
                        ////qry += CommonView.DataBase + ".order_item S," 
                        //qry += CommonView.DataBase + ".shipping_line sl," + CommonView.DataBase + ".shipping_method_translation st,";
                        ////qry += CommonView.DataBase + ".product_variant_price op,"                         
                        //qry += CommonView.DataBase + ".product_variant PV, ";
                        //qry += CommonView.DataBase + ".order O ";
                        //qry += " left join " + CommonView.DataBase + ".order_channels_channel ch on O.Id=ch.OrderId ";
                        //qry += " WHERE O.ID=OL.ORDERID AND OL.PRODUCTVARIANTID=P.ID AND ";// S.LINEID=OL.ID and ";
                        //qry += " sl.OrderId=O.Id and sl.shippingmethodid=st.Id and sl.OrderId=O.Id ";
                        ////and op.variantid=OL.productvariantid and op.variantid=P.id 
                        //qry += " AND PV.iD=P.ID AND  ";
                        // qry += " CAST(O.OrderPlacedAt AS DATE) between '" + fDt.ToString("yyyy/MM/dd") + "' AND '" + tDt.ToString("yyyy/MM/dd") + "' and ";// and customFieldsClientrequesttocanceL=0 and O.State not in ('DELIVERED','CANCELLED','AddingItems') and st.Name='Tomorrow Evening Delivery (Rs.20 incl.Tax)'  ";
                        ////qry += "  O.OrderPlacedAt between '" + fDt.ToString("yyyy/MM/dd") + " 19:30:00' AND '" + tDt.ToString("yyyy/MM/dd") + " 23:59:59'";
                        ////qry += " customFieldsPlacedatistformatted between '" + fDt.ToString("yyyy/MM/dd") + " 00:00:00' AND '" + tDt.ToString("yyyy/MM/dd") + " 23:59:59' and ";
                        //qry += " customFieldsClientrequesttocanceL=0 and O.State not in ('DELIVERED','CANCELLED','AddingItems') and st.Name='Tomorrow Evening Delivery (Rs.20 incl.Tax)'  ";
                        ////qry += " and S.Cancelled=0";
                        //qry += " and ch.ChannelId= " + locationId;
                        //qry += " Group by SKU,P.name,st.Name";
                        //qry += " FROM " + CommonView.DataBase + ".`order` O ";
                        //qry += " INNER JOIN " + CommonView.DataBase + ".order_line OL ON O.ID = OL.ORDERID ";
                        //qry += " INNER JOIN " + CommonView.DataBase + ".product_variant_translation P ON OL.PRODUCTVARIANTID = P.ID ";
                        //qry += " INNER JOIN " + CommonView.DataBase + ".shipping_line sl ON sl.OrderId = O.Id ";
                        //qry += " INNER JOIN " + CommonView.DataBase + ".shipping_method_translation st ON sl.shippingmethodid = st.Id ";
                        //qry += " INNER JOIN " + CommonView.DataBase + ".product_variant_price op ON op.variantid = OL.productvariantid AND op.variantid = P.id ";
                        //qry += " INNER JOIN " + CommonView.DataBase + ".product_variant AS pv ON pv.id = OL.productVariantId ";
                        //qry += " LEFT JOIN " + CommonView.DataBase + ".payment py ON py.OrderId = O.Id ";
                        //qry += " LEFT JOIN " + CommonView.DataBase + ".order_channels_channel ch ON O.Id = ch.OrderId ";
                        //// qry += " Where customFieldsPlacedatistformatted between '" + fDt.ToString("yyyy/MM/dd") + " 00:00:00' AND '" + tDt.ToString("yyyy/MM/dd") + " 23:59:59' and ";
                        //qry += " Where O.OrderPlacedAt between '" + fDt.ToString("yyyy/MM/dd") + " 18:30:00' AND '" + tDt.ToString("yyyy/MM/dd") + " 23:59:59' and ";
                        //qry += " customFieldsClientrequesttocanceL=0 and O.State not in ('DELIVERED','CANCELLED','AddingItems') and ";
                        qry += " FROM wow_vendure.`order` O ";
                        qry += " INNER JOIN wow_vendure.order_line OL ";
                        qry += " ON O.Id = OL.OrderId ";
                        qry += " INNER JOIN wow_vendure.product_variant pv ";
                        qry += " ON pv.id = OL.productVariantId ";
                        qry += " INNER JOIN wow_vendure.product_variant_translation P ";
                        qry += " ON P.id = pv.id ";
                        qry += " AND P.languageCode = 'en' ";//  -- ✅ ensures single row per variant
                        qry += " INNER JOIN wow_vendure.shipping_line sl ";
                        qry += " ON sl.OrderId = O.Id ";
                        qry += " INNER JOIN wow_vendure.shipping_method_translation st ";
                        qry += " ON st.Id = sl.shippingmethodid ";
                        qry += " AND st.languageCode = 'en' ";//  -- ✅ ensures single translation row
                        qry += " INNER JOIN wow_vendure.product_variant_price op ";
                        qry += " ON op.variantid = pv.id ";
                        qry += " AND op.channelid = " + locationId; //        -- ✅ ensures one price per variant for this channel
                        qry += " INNER JOIN wow_vendure.order_channels_channel ch ";
                        qry += " ON ch.OrderId = O.Id ";
                        qry += " AND ch.ChannelId = " + locationId;//       -- ✅ ensures only one matching row per order
                        qry += " WHERE ";
                        qry += "  O.OrderPlacedAt between '" + fDt.ToString("yyyy/MM/dd") + " 18:30:00' AND '" + tDt.ToString("yyyy/MM/dd") + " 23:59:59' ";
                        qry += " AND O.customFieldsClientrequesttocanceL = 0 ";
                        qry += " AND O.State NOT IN ('DELIVERED', 'CANCELLED', 'AddingItems') ";
                        if (locationId == 4) { qry += " and st.name='Tomorrow Evening Delivery (Rs.20 incl.Tax)'"; }
                       // qry += " ch.ChannelId=" + locationId;
                        //qry += " Group by ItemName ";
                        qry += " GROUP BY  ";
                        qry += " pv.SKU, ";
                        qry += " P.name, ";
                        qry += " st.Name ";
                    }
                    //qry += ") a order by OrdNo,ItemName";
                    qry += " ) a  ";
                    qry += " ORDER BY OrdNo, ItemName ";
                }
                //else if (timeType == "LESS")
                //{
                //    qry = " SELECT SKU as PCOde,Trim(P.NAME) as ItemName,'' as TamilName,'' as Category,Sum(QUANTITY) as Qty,'' as OrdNo";
                //    //qry += " FROM `order` O,order_line OL,product_variant_translation P,stock_movement S,shipping_line sl,shipping_method_translation st WHERE O.ID=OL.ORDERID AND OL.PRODUCTVARIANTID=P.ID AND S.ORDERLINEID=OL.ID and sl.OrderId=o.Id and sl.shippingmethodid=st.Id AND CAST(O.updatedAt AS DATE) between '" + fDt.ToString("yyyy/MM/dd") + "' AND '" + tDt.ToString("yyyy/MM/dd") + "' and customFieldsClientrequesttocanceL=0 and o.State not in ('DELIVERED','CANCELLED')";
                //    qry += " FROM `order` O,order_line OL,product_variant_translation P,stock_movement S,shipping_line sl,shipping_method_translation st,PRODUCT_VARIANT PV WHERE O.ID=OL.ORDERID AND OL.PRODUCTVARIANTID=P.ID AND S.ORDERLINEID=OL.ID and sl.OrderId=o.Id and p.Id=pv.Id and sl.shippingmethodid=st.Id AND CAST(O.updatedAt AS DATE) between '" + fDt.ToString("yyyy/MM/dd") + "' AND '" + tDt.ToString("yyyy/MM/dd") + "' and customFieldsClientrequesttocanceL=0 and o.State not in ('DELIVERED','CANCELLED') and st.Name='Tomorrow Morning Delivery (Charges + Tax)' and Cast(o.UpdatedAt as Time)<= '" + time.ToString("HH:mm:ss") + "' ";
                //    qry += " Group by p.Name oRDER BY trim(p.Name) ASC ";
                //    qry += " Union All";
                //    qry += " SELECT SKU as PCOde,Trim(P.NAME) as ItemName,'' as TamilName,'' as Category,Sum(QUANTITY) as Qty,'' as OrdNo";
                //    //qry += " FROM `order` O,order_line OL,product_variant_translation P,stock_movement S,shipping_line sl,shipping_method_translation st WHERE O.ID=OL.ORDERID AND OL.PRODUCTVARIANTID=P.ID AND S.ORDERLINEID=OL.ID and sl.OrderId=o.Id and sl.shippingmethodid=st.Id AND CAST(O.updatedAt AS DATE) between '" + fDt.ToString("yyyy/MM/dd") + "' AND '" + tDt.ToString("yyyy/MM/dd") + "' and customFieldsClientrequesttocanceL=0 and o.State not in ('DELIVERED','CANCELLED')";
                //    qry += " FROM `order` O,order_line OL,product_variant_translation P,stock_movement S,shipping_line sl,shipping_method_translation st,PRODUCT_VARIANT PV WHERE O.ID=OL.ORDERID AND OL.PRODUCTVARIANTID=P.ID AND S.ORDERLINEID=OL.ID and sl.OrderId=o.Id and p.Id=pv.Id and sl.shippingmethodid=st.Id AND CAST(O.updatedAt AS DATE) between '" + fDt.ToString("yyyy/MM/dd") + "' AND '" + tDt.ToString("yyyy/MM/dd") + "' and customFieldsClientrequesttocanceL=0 and o.State not in ('DELIVERED','CANCELLED') and st.Name='Tomorrow Evening Delivery (Charges + Tax)' and Cast(o.UpdatedAt as Time)<= '" + time.ToString("HH:mm:ss") + "' ";
                //    qry += " Group by p.Name oRDER BY trim(p.Name) ASC ";
                //}
                //else if (timeType == "GREATER")
                //{
                //    qry = " SELECT SKU as PCOde,Trim(P.NAME) as ItemName,'' as TamilName,'' as Category,Sum(QUANTITY) as Qty,'' as OrdNo";
                //    //qry += " FROM `order` O,order_line OL,product_variant_translation P,stock_movement S,shipping_line sl,shipping_method_translation st WHERE O.ID=OL.ORDERID AND OL.PRODUCTVARIANTID=P.ID AND S.ORDERLINEID=OL.ID and sl.OrderId=o.Id and sl.shippingmethodid=st.Id AND CAST(O.updatedAt AS DATE) between '" + fDt.ToString("yyyy/MM/dd") + "' AND '" + tDt.ToString("yyyy/MM/dd") + "' and customFieldsClientrequesttocanceL=0 and o.State not in ('DELIVERED','CANCELLED')";
                //    qry += " FROM `order` O,order_line OL,product_variant_translation P,stock_movement S,shipping_line sl,shipping_method_translation st,PRODUCT_VARIANT PV WHERE O.ID=OL.ORDERID AND OL.PRODUCTVARIANTID=P.ID AND S.ORDERLINEID=OL.ID and sl.OrderId=o.Id and p.Id=pv.Id and sl.shippingmethodid=st.Id AND CAST(O.updatedAt AS DATE) between '" + fDt.ToString("yyyy/MM/dd") + "' AND '" + tDt.ToString("yyyy/MM/dd") + "' and customFieldsClientrequesttocanceL=0 and o.State not in ('DELIVERED','CANCELLED') and st.Name='Tomorrow Morning Delivery (Charges + Tax)' and Cast(o.UpdatedAt as Time)>= '" + time.ToString("HH:mm:ss") + "'";
                //    qry += " Group by p.Name oRDER BY trim(p.Name) ASC ";
                //    qry += " Union All";
                //    qry += " SELECT SKU as PCOde,Trim(P.NAME) as ItemName,'' as TamilName,'' as Category,Sum(QUANTITY) as Qty,'' as OrdNo";
                //    //qry += " FROM `order` O,order_line OL,product_variant_translation P,stock_movement S,shipping_line sl,shipping_method_translation st WHERE O.ID=OL.ORDERID AND OL.PRODUCTVARIANTID=P.ID AND S.ORDERLINEID=OL.ID and sl.OrderId=o.Id and sl.shippingmethodid=st.Id AND CAST(O.updatedAt AS DATE) between '" + fDt.ToString("yyyy/MM/dd") + "' AND '" + tDt.ToString("yyyy/MM/dd") + "' and customFieldsClientrequesttocanceL=0 and o.State not in ('DELIVERED','CANCELLED')";
                //    qry += " FROM `order` O,order_line OL,product_variant_translation P,stock_movement S,shipping_line sl,shipping_method_translation st,PRODUCT_VARIANT PV WHERE O.ID=OL.ORDERID AND OL.PRODUCTVARIANTID=P.ID AND S.ORDERLINEID=OL.ID and sl.OrderId=o.Id and p.Id=pv.Id and sl.shippingmethodid=st.Id AND CAST(O.updatedAt AS DATE) between '" + fDt.ToString("yyyy/MM/dd") + "' AND '" + tDt.ToString("yyyy/MM/dd") + "' and customFieldsClientrequesttocanceL=0 and o.State not in ('DELIVERED','CANCELLED') and st.Name='Tomorrow Evening Delivery (Charges + Tax)' and Cast(o.UpdatedAt as Time)>= '" + time.ToString("HH:mm:ss") + "'";
                //    qry += " Group by p.Name oRDER BY trim(p.Name) ASC ";
                //}
                //cmd = new MySqlCommand("Select * from Test", conn);
                cmd = new MySqlCommand(qry, conn);
                Da.SelectCommand = cmd;
                Da.Fill(Tbl);
                Tbl.TableName = "navigate";
                Da.Dispose();
                cmd.Dispose();
                conn.Close();
                // mb.ImportFromFile(file);
                conn.Close();
                return Tbl;
                //}
                // }
            }
        }
        public DataTable RptLoadBillDelPartnerReport(DateTime fDt, DateTime tDt, int locationId)
        {
            string constring1 = "";
            // constring1 = "Server=" + CommonView.DBServer + "; Database = " + CommonView.DataBase + ";UID=root;Pwd=" + CommonView.Pwd + ";Port=" + CommonView.Port + " ;SslMode=none;Connect Timeout=30;Convert Zero Datetime=True;Charset=utf8;";
            constring1 = "Server=" + CommonView.DBServer + "; Database = " + CommonView.DataBase + ";UID=" + CommonView.UId + ";Pwd=" + CommonView.Pwd + ";Port=" + CommonView.Port + " ;SslMode=none;Connect Timeout=30;Convert Zero Datetime=True;Charset=utf8;";
            //constring1 = "Server=localhost;Uid=root;Database=kaaikani;Port=3306;Connect Timeout=30;Convert Zero Datetime=True;Charset=utf8;";
            //constring1 = "Server=localhost;Uid=root;Database=kaaikani;Port=4306;Connect Timeout=30;Convert Zero Datetime=True;Charset=utf8;";
            //string file = "C:\\backup.sql";
            string path = "";
            path = file;//txb_Path.Text + year + "-" + month + "-" + day + "--" + hour + "-" + minute + "-" + second + ".sql";
            file = path;
            DataTable Tbl = new DataTable();
            MySqlDataAdapter Da = new MySqlDataAdapter();
            using (MySqlConnection conn = new MySqlConnection(constring1))
            {
                MySqlCommand cmd = new MySqlCommand();
                //{
                // using (MySqlBackup mb = new MySqlBackup(cmd))
                //{
                cmd.Connection = conn;
                conn.Open();
                string qry = "";

                qry = " Select * from (";
                qry += " SELECT Distinct DENSE_RANK() OVER (ORDER BY Code) as SNo,CODE,Metadata,customFieldsOtherinstructions as CuttingInstructions,(subTotalWithTax+shippingWithTax)/100 as NetTotal,CAST(O.updatedAt AS TIME) AS Time,ShippingAddress as BillingAddress,1 as OrdNo, CustomerId,'' as Pincode,'' as PaymentStatus";
                // qry += " FROM " + CommonView.DataBase + ".payment py," + CommonView.DataBase + ".order_line OL,";
                // qry += CommonView.DataBase + ".product_variant_translation P," + CommonView.DataBase + ".stock_movement S," + CommonView.DataBase + ".shipping_line sl," + CommonView.DataBase + ".shipping_method_translation st," + CommonView.DataBase + ".product_variant PV, ";
                // qry += " " + CommonView.DataBase + ".product_variant_price op,";
                // qry += CommonView.DataBase + ".order O ";
                // qry += " left join " + CommonView.DataBase + ".order_channels_channel ch on O.Id=ch.OrderId ";
                // qry += " WHERE O.ID=OL.ORDERID and py.OrderId=O.Id AND OL.PRODUCTVARIANTID=P.ID AND S.ORDERLINEID=OL.ID and sl.OrderId=O.Id and op.variantid=OL.productvariantid and op.variantid=P.Id and sl.shippingmethodid=st.Id AND PV.iD=P.ID ";
                //  qry += " AND CAST(O.OrderPlacedAt AS DATE) between '" + fDt.ToString("yyyy/MM/dd") + "' AND '" + tDt.ToString("yyyy/MM/dd") + "' ";
                // //qry += " AND O.OrderPlacedAt between '" + fDt.ToString("yyyy/MM/dd") + " 19:30:00' AND '" + tDt.ToString("yyyy/MM/dd") + " 23:59:59'";
                //// qry += " and customFieldsPlacedatistformatted between '" + fDt.ToString("yyyy/MM/dd") + " 00:00:00' AND '" + tDt.ToString("yyyy/MM/dd") + " 23:59:59' ";
                qry += " FROM " + CommonView.DataBase + ".`order` O ";
                qry += " INNER JOIN " + CommonView.DataBase + ".order_line OL ON O.ID = OL.ORDERID ";
                qry += " INNER JOIN " + CommonView.DataBase + ".product_variant_translation P ON OL.PRODUCTVARIANTID = P.ID ";
                qry += " INNER JOIN " + CommonView.DataBase + ".shipping_line sl ON sl.OrderId = O.Id ";
                qry += " INNER JOIN " + CommonView.DataBase + ".shipping_method_translation st ON sl.shippingmethodid = st.Id ";
                qry += " INNER JOIN " + CommonView.DataBase + ".product_variant_price op ON op.variantid = OL.productvariantid AND op.variantid = P.id ";
                qry += " INNER JOIN " + CommonView.DataBase + ".product_variant AS pv ON pv.id = OL.productVariantId ";
                qry += " LEFT JOIN " + CommonView.DataBase + ".payment py ON py.OrderId = O.Id ";
                qry += " LEFT JOIN " + CommonView.DataBase + ".order_channels_channel ch ON O.Id = ch.OrderId ";
               
                //qry += " WHERE customFieldsPlacedatistformatted BETWEEN '" + fDt.ToString("yyyy/MM/dd") + " 00:00:00' AND '" + tDt.ToString("yyyy/MM/dd") + " 23:59:59' ";
                qry += " Where O.OrderPlacedAt between '" + fDt.ToString("yyyy/MM/dd") + " 18:30:00' AND '" + tDt.ToString("yyyy/MM/dd") + " 23:59:59' ";
                qry += " and customFieldsClientrequesttocanceL=0 and O.State not in ('DELIVERED','CANCELLED','AddingItems') and ";
                if (locationId == 4)
                { qry += "  st.Name='Tomorrow Morning Delivery (Rs.40 incl.Tax)' and "; }
                qry += " ch.ChannelId= " + locationId;
                //  and st.Name='Tomorrow Morning Delivery (Rs.50 incl.Tax)' ";
                // qry += "  and py.orderid=12874";
                if (locationId == 4)
                {
                    qry += " Union All";
                    qry += " SELECT Distinct DENSE_RANK() OVER (ORDER BY Code) as SNo,CODE,Metadata,customFieldsOtherinstructions as CuttingInstructions,(subTotalWithTax+shippingWithTax)/100 as NetTotal,CAST(O.updatedAt AS TIME) AS Time,ShippingAddress as BillingAddress,2 as OrdNo,CustomerId,'' as Pincode,'' as PaymentStatus";
                    // qry += " FROM " + CommonView.DataBase + ".payment py," + CommonView.DataBase + ".order_line OL," + CommonView.DataBase + ".product_variant_translation P," + CommonView.DataBase + ".stock_movement S," + CommonView.DataBase + ".shipping_line sl," + CommonView.DataBase + ".shipping_method_translation st, ";
                    // qry += " " + CommonView.DataBase + ".product_variant_price op," + CommonView.DataBase + ".product_variant PV, ";
                    // qry += CommonView.DataBase + ".order O ";
                    // qry += " left join " + CommonView.DataBase + ".order_channels_channel ch on O.Id=ch.OrderId ";
                    // qry += " WHERE O.ID=OL.ORDERID and py.OrderId=O.Id AND OL.PRODUCTVARIANTID=P.ID AND S.ORDERLINEID=OL.ID and sl.OrderId=O.Id and sl.shippingmethodid=st.Id and sl.OrderId=O.Id and op.variantid=OL.productvariantid and op.variantid=P.Id AND PV.iD=P.ID ";
                    //   qry += "  AND cast(O.OrderPlacedAt as date) between '" + fDt.ToString("yyyy/MM/dd") + "' AND '" + tDt.ToString("yyyy/MM/dd") + "' ";
                    //// qry += " and customFieldsPlacedatistformatted between '" + fDt.ToString("yyyy/MM/dd") + " 00:00:00' AND '" + tDt.ToString("yyyy/MM/dd") + " 23:59:59'";
                    qry += " FROM " + CommonView.DataBase + ".`order` O ";
                    qry += " INNER JOIN " + CommonView.DataBase + ".order_line OL ON O.ID = OL.ORDERID ";
                    qry += " INNER JOIN " + CommonView.DataBase + ".product_variant_translation P ON OL.PRODUCTVARIANTID = P.ID ";
                    qry += " INNER JOIN " + CommonView.DataBase + ".shipping_line sl ON sl.OrderId = O.Id ";
                    qry += " INNER JOIN " + CommonView.DataBase + ".shipping_method_translation st ON sl.shippingmethodid = st.Id ";
                    qry += " INNER JOIN " + CommonView.DataBase + ".product_variant_price op ON op.variantid = OL.productvariantid AND op.variantid = P.id ";
                    qry += " INNER JOIN " + CommonView.DataBase + ".product_variant AS pv ON pv.id = OL.productVariantId ";
                    qry += " LEFT JOIN " + CommonView.DataBase + ".payment py ON py.OrderId = O.Id ";
                    qry += " LEFT JOIN " + CommonView.DataBase + ".order_channels_channel ch ON O.Id = ch.OrderId ";
                   //qry += " WHERE customFieldsPlacedatistformatted BETWEEN '" + fDt.ToString("yyyy/MM/dd") + " 00:00:00' AND '" + tDt.ToString("yyyy/MM/dd") + " 23:59:59' ";
                    qry += " Where O.OrderPlacedAt between '" + fDt.ToString("yyyy/MM/dd") + " 18:30:00' AND '" + tDt.ToString("yyyy/MM/dd") + " 23:59:59' ";
                    qry += " and customFieldsClientrequesttocanceL=0 and O.State not in ('DELIVERED','CANCELLED') and st.Name='Tomorrow Evening Delivery (Rs.20 incl.Tax)'  ";
                    qry += " and ch.ChannelId= " + locationId;
                    // qry += "  and py.orderid=12874";
                }
                qry += ") a order by OrdNo,Time,Code";

                //qry = " Select * from (";
                //qry += " SELECT Distinct DENSE_RANK() OVER (ORDER BY Code) as SNo,CODE,(subTotalWithTax+shippingWithTax)/100 as NetTotal,CAST(O.updatedAt AS TIME)TIME,ShippingAddress as BillingAddress,1 as OrdNo, CustomerId,'' as Pincode";
                //qry += " FROM `order` O,shipping_method_translation st WHERE  CAST(O.updatedAt AS DATE) between '" + fDt.ToString("yyyy/MM/dd") + "' AND '" + tDt.ToString("yyyy/MM/dd") + "' and customFieldsClientrequesttocanceL=0 and o.State not in ('DELIVERED','CANCELLED') and st.Name='Tomorrow Morning Delivery (Rs.50 incl.Tax)' ";
                //qry += " Union All";
                //qry += " SELECT Distinct DENSE_RANK() OVER (ORDER BY Code) as SNo,CODE,(subTotalWithTax+shippingWithTax)/100 as NetTotal,CAST(O.updatedAt AS TIME)TIME,ShippingAddress as BillingAddress,2 as OrdNo,CustomerId,'' as Pincode ";
                //qry += " FROM `order` O,shipping_method_translation st WHERE CAST(O.updatedAt AS DATE) between '" + fDt.ToString("yyyy/MM/dd") + "' AND '" + tDt.ToString("yyyy/MM/dd") + "' and customFieldsClientrequesttocanceL=0 and o.State not in ('DELIVERED','CANCELLED') and st.Name='Tomorrow Evening Delivery (Rs.25 incl.Tax)'  ";
                //qry += ") a order by OrdNo,CAST(Time AS Time)";

                cmd = new MySqlCommand(qry, conn);
                Da.SelectCommand = cmd;
                Da.Fill(Tbl);
                Tbl.TableName = "navigate";
                Da.Dispose();
                cmd.Dispose();
                conn.Close();
                // mb.ImportFromFile(file);
                conn.Close();
                return Tbl;
                //}
                // }
            }
        }
        public DataTable RptLoadCummGroupReport(DateTime fDt, DateTime tDt, string timeType, DateTime time)
        {
            string constring1 = "";
            // constring1 = "Server=" + CommonView.DBServer + "; Database = " + CommonView.DataBase + ";UID=root;Pwd=" + CommonView.Pwd + ";Port=" + CommonView.Port + " ;SslMode=none;Connect Timeout=30;Convert Zero Datetime=True;Charset=utf8;";
            constring1 = "Server=" + CommonView.DBServer + "; Database = " + CommonView.DataBase + ";UID=" + CommonView.UId + ";Pwd=" + CommonView.Pwd + ";Port=" + CommonView.Port + " ;SslMode=none;Connect Timeout=30;Convert Zero Datetime=True;Charset=utf8;";
            //constring1 = "Server=localhost;Uid=root;Database=kaaikani;Port=3306;Connect Timeout=30;Convert Zero Datetime=True;Charset=utf8;";
            //constring1 = "Server=localhost;Uid=root;Database=kaaikani;Port=4306;Connect Timeout=30;Convert Zero Datetime=True;Charset=utf8;";
            //string file = "C:\\backup.sql";
            string path = "";
            path = file;//txb_Path.Text + year + "-" + month + "-" + day + "--" + hour + "-" + minute + "-" + second + ".sql";
            file = path;
            DataTable Tbl = new DataTable();
            MySqlDataAdapter Da = new MySqlDataAdapter();
            using (MySqlConnection conn = new MySqlConnection(constring1))
            {
                MySqlCommand cmd = new MySqlCommand();
                //{
                // using (MySqlBackup mb = new MySqlBackup(cmd))
                //{
                cmd.Connection = conn;
                conn.Open();
                string qry = "";
                if (timeType == "ALL")
                {
                    //qry = " SELECT SKU as PCOde,Trim(P.NAME) as ItemName,'' as TamilName,'' as Category,cast(Count(S.LineId) as Decimal(18,2)) as Qty,'' as OrdNo,'' as GroupName";
                    ////qry += " FROM `order` O,order_line OL,product_variant_translation P,stock_movement S,shipping_line sl,shipping_method_translation st WHERE O.ID=OL.ORDERID AND OL.PRODUCTVARIANTID=P.ID AND S.ORDERLINEID=OL.ID and sl.OrderId=o.Id and sl.shippingmethodid=st.Id AND CAST(O.updatedAt AS DATE) between '" + fDt.ToString("yyyy/MM/dd") + "' AND '" + tDt.ToString("yyyy/MM/dd") + "' and customFieldsClientrequesttocanceL=0 and o.State not in ('DELIVERED','CANCELLED')";
                    //qry += " FROM " + CommonView.DataBase + ".order O," + CommonView.DataBase + ".order_line OL," + CommonView.DataBase + ".product_variant_translation P,";
                    //qry += CommonView.DataBase + ".order_item S," + CommonView.DataBase + ".shipping_line sl," + CommonView.DataBase + ".shipping_method_translation st,";
                    //qry += CommonView.DataBase + ".product_variant PV WHERE O.ID=OL.ORDERID AND OL.PRODUCTVARIANTID=P.ID AND S.LINEID=OL.ID and sl.OrderId=O.Id and P.Id=PV.Id ";
                    //qry += " and sl.shippingmethodid=st.Id AND CAST(O.updatedAt AS DATE) between '" + fDt.ToString("yyyy/MM/dd") + "' AND '" + tDt.ToString("yyyy/MM/dd") + "' and ";
                    //qry += " customFieldsClientrequesttocanceL=0 and O.State not in ('DELIVERED','CANCELLED') ";
                    //qry += " and S.Cancelled=0";
                    //qry += " Group by SKU,P.name oRDER BY trim(P.name) ASC ";

                    qry = " SELECT  SKU as PCOde,Trim(P.NAME) as ItemName,'' as TamilName,'' as Category,cast(sum(Quantity) as decimal(18,3)) as Qty,'' as OrdNo,'' as GroupName";
                    //qry += " FROM `order` O,order_line OL,product_variant_translation P,stock_movement S,shipping_line sl,shipping_method_translation st WHERE O.ID=OL.ORDERID AND OL.PRODUCTVARIANTID=P.ID AND S.ORDERLINEID=OL.ID and sl.OrderId=o.Id and sl.shippingmethodid=st.Id AND CAST(O.updatedAt AS DATE) between '" + fDt.ToString("yyyy/MM/dd") + "' AND '" + tDt.ToString("yyyy/MM/dd") + "' and customFieldsClientrequesttocanceL=0 and o.State not in ('DELIVERED','CANCELLED')";
                    qry += " FROM " + CommonView.DataBase + ".order_line OL," + CommonView.DataBase + ".product_variant_translation P,";
                    //qry += CommonView.DataBase + ".order_item S," + 
                    qry += CommonView.DataBase + ".shipping_line sl," + CommonView.DataBase + ".shipping_method_translation st,";
                    qry += CommonView.DataBase + ".product_variant PV, ";
                    qry += CommonView.DataBase + ".order O ";
                    qry += " left join " + CommonView.DataBase + ".order_channels_channel ch on O.Id=ch.OrderId ";
                    qry += " WHERE O.ID=OL.ORDERID AND OL.PRODUCTVARIANTID=P.ID ";// AND S.LINEID=OL.ID 
                    qry += " and sl.OrderId=O.Id and P.Id=PV.Id ";
                    //qry += " and sl.shippingmethodid=st.Id AND CAST(O.OrderPlacedAt AS DATE) between '" + fDt.ToString("yyyy/MM/dd") + "' AND '" + tDt.ToString("yyyy/MM/dd") + "' and ";
                    qry += " and sl.shippingmethodid=st.Id AND ";
                    qry += " O.OrderPlacedAt between '" + fDt.ToString("yyyy/MM/dd") + " 18:30:00' AND '" + tDt.ToString("yyyy/MM/dd") + " 23:59:59' and ";
                    //   qry += " customFieldsPlacedatistformatted between '" + fDt.ToString("yyyy/MM/dd") + " 00:00:00' AND '" + tDt.ToString("yyyy/MM/dd") + " 23:59:59' and ";
                    qry += " customFieldsClientrequesttocanceL=0 and O.State not in ('DELIVERED','CANCELLED','AddingItems') and ch.ChannelId in (4,6,5,7) ";
                    //qry += " and S.Cancelled=0";
                    qry += " Group by SKU,P.name,Code ";
                    qry += " oRDER BY trim(P.name) ASC ";
                }
                else if (timeType == "LESS")
                {
                    qry = " SELECT SKU as PCOde,Trim(P.NAME) as ItemName,'' as TamilName,'' as Category,Count(S.LineId) as Qty,'' as OrdNo,'' as GroupName";
                    //qry += " FROM `order` O,order_line OL,product_variant_translation P,stock_movement S,shipping_line sl,shipping_method_translation st WHERE O.ID=OL.ORDERID AND OL.PRODUCTVARIANTID=P.ID AND S.ORDERLINEID=OL.ID and sl.OrderId=o.Id and sl.shippingmethodid=st.Id AND CAST(O.updatedAt AS DATE) between '" + fDt.ToString("yyyy/MM/dd") + "' AND '" + tDt.ToString("yyyy/MM/dd") + "' and customFieldsClientrequesttocanceL=0 and o.State not in ('DELIVERED','CANCELLED')";
                    qry += " FROM " + CommonView.DataBase + ".order O," + CommonView.DataBase + ".order_line OL," + CommonView.DataBase + ".product_variant_translation P,";
                    qry += CommonView.DataBase + ".order_item S," + CommonView.DataBase + ".shipping_line sl," + CommonView.DataBase + ".shipping_method_translation st,";
                    qry += CommonView.DataBase + ".PRODUCT_VARIANT PV WHERE O.ID=OL.ORDERID AND OL.PRODUCTVARIANTID=P.ID AND S.LINEID=OL.ID and sl.OrderId=O.Id and P.Id=PV.Id and ";
                    qry += " sl.shippingmethodid=st.Id AND CAST(O.updatedAt AS DATE) between '" + fDt.ToString("yyyy/MM/dd") + "' AND '" + tDt.ToString("yyyy/MM/dd") + "' and customFieldsClientrequesttocanceL=0 and ";
                    qry += " O.State not in ('DELIVERED','CANCELLED') and Cast(O.UpdatedAt as Time)<= '" + time.ToString("HH:mm:ss") + "'";
                    qry += " and S.Cancelled=0";
                    qry += " Group by SKU,p.Name oRDER BY trim(p.Name) ASC ";
                }
                else if (timeType == "GREATER")
                {
                    qry = " SELECT SKU as PCOde,Trim(P.NAME) as ItemName,'' as TamilName,'' as Category,Count(S.LineId) as Qty,'' as OrdNo,'' as GroupName";
                    //qry += " FROM `order` O,order_line OL,product_variant_translation P,stock_movement S,shipping_line sl,shipping_method_translation st WHERE O.ID=OL.ORDERID AND OL.PRODUCTVARIANTID=P.ID AND S.ORDERLINEID=OL.ID and sl.OrderId=o.Id and sl.shippingmethodid=st.Id AND CAST(O.updatedAt AS DATE) between '" + fDt.ToString("yyyy/MM/dd") + "' AND '" + tDt.ToString("yyyy/MM/dd") + "' and customFieldsClientrequesttocanceL=0 and o.State not in ('DELIVERED','CANCELLED')";
                    qry += " FROM " + CommonView.DataBase + ".order O," + CommonView.DataBase + ".order_line OL," + CommonView.DataBase + ".product_variant_translation P,";
                    qry += CommonView.DataBase + ".order_item S," + CommonView.DataBase + ".shipping_line sl," + CommonView.DataBase + ".shipping_method_translation st,";
                    qry += CommonView.DataBase + ".product_variant PV WHERE O.ID=OL.ORDERID AND OL.PRODUCTVARIANTID=P.ID AND S.LINEID=OL.ID and sl.OrderId=O.Id and P.Id=PV.Id ";
                    qry += " and sl.shippingmethodid=st.Id AND CAST(O.updatedAt AS DATE) between '" + fDt.ToString("yyyy/MM/dd") + "' AND '" + tDt.ToString("yyyy/MM/dd") + "'";
                    qry += " and customFieldsClientrequesttocanceL=0 and O.State not in ('DELIVERED','CANCELLED') and Cast(o.UpdatedAt as Time)>= '" + time.ToString("HH:mm:ss") + "'";
                    qry += " and S.Cancelled=0";
                    qry += " Group by SKU,P.name oRDER BY trim(P.name) ASC ";
                }
                //cmd = new MySqlCommand("Select * from Test", conn);
                cmd = new MySqlCommand(qry, conn);
                Da.SelectCommand = cmd;
                Da.Fill(Tbl);
                Tbl.TableName = "navigate";
                Da.Dispose();
                cmd.Dispose();
                conn.Close();
                // mb.ImportFromFile(file);
                conn.Close();
                return Tbl;
                //}
                // }
            }
        }
        public DataTable RptCancelReport(DateTime fDt, DateTime tDt)
        {

            string constring1 = "";
            //constring1 = "Server=" + CommonView.DBServer + "; Database = " + CommonView.DataBase + ";UID=root;Pwd=" + CommonView.Pwd + ";Port=" + CommonView.Port + " ;SslMode=none;Connect Timeout=30;Convert Zero Datetime=True;Charset=utf8;";
            constring1 = "Server=" + CommonView.DBServer + "; Database = " + CommonView.DataBase + ";UID=" + CommonView.UId + ";Pwd=" + CommonView.Pwd + ";Port=" + CommonView.Port + " ;SslMode=none;Connect Timeout=30;Convert Zero Datetime=True;Charset=utf8;";

            //con//constring1 = "Server=" + CommonView.DBServer + ";Uid=root;Database=" + CommonView.DataBase + ";Port=" + CommonView.Port + " ;Connect Timeout=30;Convert Zero Datetime=True;Charset=utf8;";
            //constring1 = "Server=localhost;Uid=root;Database=kaaikani;Port=4306;Connect Timeout=30;Convert Zero Datetime=True;Charset=utf8;";
            //string file = "C:\\backup.sql";
            string path = "";
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072 | SecurityProtocolType.Tls;
            path = file;//txb_Path.Text + year + "-" + month + "-" + day + "--" + hour + "-" + minute + "-" + second + ".sql";
            file = path;
            DataTable Tbl = new DataTable();
            MySqlDataAdapter Da = new MySqlDataAdapter();
            using (MySqlConnection conn = new MySqlConnection(constring1))
            {
                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = conn;
                conn.Open();

                string qry = "";

                qry = " SELECT Cast(updatedat as date) as Date,Code,CustomerId,ShippingAddress as BillingAddress,'' as Customer,'' as Address,'' as CellNo,(subTotalWithTax+shippingWithTax)/100 as NetTotal ";
                qry += " FROM " + CommonView.DataBase + ".order O ";
                //qry += " where O.OrderPlacedAt between '" + fDt.ToString("yyyy/MM/dd") + " 19:30:00' AND '" + tDt.ToString("yyyy/MM/dd") + " 23:59:59'";
                qry += " Where customFieldsPlacedatistformatted between '" + fDt.ToString("yyyy/MM/dd") + " 00:00:00' AND '" + tDt.ToString("yyyy/MM/dd") + " 23:59:59' and ";
                qry += " customFieldsClientrequesttocanceL=1 and orderPlacedAt is not null ";

                cmd = new MySqlCommand(qry, conn);
                Da.SelectCommand = cmd;
                Da.Fill(Tbl);
                Tbl.TableName = "navigate";
                Da.Dispose();
                cmd.Dispose();
                conn.Close();
                // mb.ImportFromFile(file);
                conn.Close();
                return Tbl;
                //}
                // }
            }
        }
        public void RptLoadReport_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();
            tmp.Add(CommonView.GetGridViewColumn("Id", "Id", 0, 1));
            tmp.Add(CommonView.GetGridViewColumn("PCODE", "PCODE", 0, 2));

            //tmp.Add(CommonView.GetGridViewBoolColumn("Selection", "Select", 80, 4 ,false));
            tmp.Add(CommonView.GetGridViewColumn("Code", "Code", 180, 5, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Date", "Date", 80, 6, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yy"));
            tmp.Add(CommonView.GetGridViewColumn("Time", "Time", 80, 7, true, DataGridViewContentAlignment.MiddleRight, ""));
            tmp.Add(CommonView.GetGridViewColumn("BillingAddress", "BillingAddress", 0, 8, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Customer", "Customer", 100, 9, true));
            tmp.Add(CommonView.GetGridViewColumn("Address", "Address", 250, 10, true));
            tmp.Add(CommonView.GetGridViewColumn("CellNo", "CellNo", 80, 11, true));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 200, 12, true));
            tmp.Add(CommonView.GetGridViewColumn("TamilName", "TamilName", 150, 13, true));
            tmp.Add(CommonView.GetGridViewColumn("Qty", "Qty", 40, 14, true));
            tmp.Add(CommonView.GetGridViewColumn("ShadowPrice", "ShadowPrice", 70, 15, true, DataGridViewContentAlignment.MiddleLeft, "####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Rate", "Rate", 60, 16, true, DataGridViewContentAlignment.MiddleLeft, "####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Total", "Total", 70, 17, true, DataGridViewContentAlignment.MiddleLeft, "####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("SubTotal", "SubTotal", 70, 18, true, DataGridViewContentAlignment.MiddleLeft, "####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("Shipping", "Shipping", 70, 19, true, DataGridViewContentAlignment.MiddleLeft, "####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("NetTotal", "NetTotal", 70, 20, true, DataGridViewContentAlignment.MiddleRight, "####0.00"));
            tmp.Add(CommonView.GetGridViewColumn("DeliveryTime", "DeliveryTime", 200, 21, true));
            tmp.Add(CommonView.GetGridViewColumn("CuttingInstructions", "CuttingInstructions", 180, 22, true));
            tmp.Add(CommonView.GetGridViewColumn("PaymentMode", "PaymentMode", 100, 23, true));
            tmp.Add(CommonView.GetGridViewColumn("SNo", "SNo", 90, 24, true));
            tmp.Add(CommonView.GetGridViewColumn("CustomerId", "CustomerId", 0, 25, true));
            tmp.Add(CommonView.GetGridViewColumn("Pincode", "Pincode", 90, 26, true));
            tmp.Add(CommonView.GetGridViewColumn("OrdNo", "OrdNo", 0, 27, true));
            tmp.Add(CommonView.GetGridViewColumn("MetaData", "MetaData", 0, 28, true));
            tmp.Add(CommonView.GetGridViewColumn("PaymentStatus", "PaymentStatus", 100, 29, true));
            tmp.Add(CommonView.GetGridViewColumn("RewardPointUsed", "RewardPointUsed",100, 30, true));
            tmp.Add(CommonView.GetGridViewColumn("CouponCode", "CouponCode", 100, 31, true));
            tmp.Add(CommonView.GetGridViewColumn("Note", "Note", 100, 32, true));
            tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }

        public void RptLoadCummReport_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();

            //tmp.Add(CommonView.GetGridViewColumn("Date", "Date", 80, 3, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yy"));
            tmp.Add(CommonView.GetGridViewColumn("PCode", "PCode", 0, 1, true));
            //tmp.Add(CommonView.GetGridViewBoolColumn("Selection", "Select", 80, 2, false));
            // tmp.Add(CommonView.GetGridViewColumn("Time", "Time", 80, 3, true, DataGridViewContentAlignment.MiddleRight, ""));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 400, 4, true));
            tmp.Add(CommonView.GetGridViewColumn("TamilName", "TamilName", 400, 5, true));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 100, 6, true));
            tmp.Add(CommonView.GetGridViewColumn("Qty", "Qty", 40, 7, true));
            tmp.Add(CommonView.GetGridViewColumn("OrdNo", "OrdNo", 0, 8, true));

            // tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }
        public void RptLoadCummDelTimeReport_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();

            //tmp.Add(CommonView.GetGridViewColumn("Date", "Date", 80, 3, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yy"));
            tmp.Add(CommonView.GetGridViewColumn("PCode", "PCode", 0, 1, true));
            //tmp.Add(CommonView.GetGridViewBoolColumn("Selection", "Select", 80, 2, false));
            // tmp.Add(CommonView.GetGridViewColumn("Time", "Time", 80, 3, true, DataGridViewContentAlignment.MiddleRight, ""));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 400, 4, true));
            tmp.Add(CommonView.GetGridViewColumn("TamilName", "TamilName", 400, 5, true));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 100, 6, true));
            tmp.Add(CommonView.GetGridViewColumn("Qty", "Qty", 40, 7, true));
            tmp.Add(CommonView.GetGridViewColumn("DeliveryTime", "DeliveryTime", 150, 8, true));
            tmp.Add(CommonView.GetGridViewColumn("OrdNo", "OrdNo", 0, 9, true));
            tmp.Add(CommonView.GetGridViewColumn("SlNo", "SNo", 150, 10, true));

            // tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }
        public void RptLoadGroupCummReport_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();

            //tmp.Add(CommonView.GetGridViewColumn("Date", "Date", 80, 3, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yy"));
            tmp.Add(CommonView.GetGridViewColumn("PCode", "PCode", 0, 1, true));
            //tmp.Add(CommonView.GetGridViewBoolColumn("Selection", "Select", 80, 2, false));
            // tmp.Add(CommonView.GetGridViewColumn("Time", "Time", 80, 3, true, DataGridViewContentAlignment.MiddleRight, ""));
            tmp.Add(CommonView.GetGridViewColumn("ItemName", "ItemName", 400, 4, true));
            tmp.Add(CommonView.GetGridViewColumn("TamilName", "TamilName", 400, 5, true));
            tmp.Add(CommonView.GetGridViewColumn("Category", "Category", 100, 6, true));
            tmp.Add(CommonView.GetGridViewColumn("Qty", "Qty", 40, 7, true));
            tmp.Add(CommonView.GetGridViewColumn("OrdNo", "OrdNo", 0, 8, true));
            tmp.Add(CommonView.GetGridViewColumn("GroupName", "GroupName", 0, 9, true));

            // tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }
        public void RptCancelReport_GridStyle(DataGridViewColumnCollection tmp)
        {
            tmp.Clear();

            tmp.Add(CommonView.GetGridViewColumn("Date", "Date", 80, 1, true, DataGridViewContentAlignment.MiddleLeft, "dd/MM/yy"));
            tmp.Add(CommonView.GetGridViewColumn("Code", "Code", 200, 2, true));
            tmp.Add(CommonView.GetGridViewColumn("CustomerId", "CustomerId", 0, 3, true));
            tmp.Add(CommonView.GetGridViewColumn("BillingAddress", "BillingAddress", 0, 4, true, DataGridViewContentAlignment.MiddleLeft, ""));
            tmp.Add(CommonView.GetGridViewColumn("Customer", "Customer", 130, 5, true));
            tmp.Add(CommonView.GetGridViewColumn("Address", "Address", 600, 6, true));
            tmp.Add(CommonView.GetGridViewColumn("CellNo", "CellNo", 120, 7, true));
            tmp.Add(CommonView.GetGridViewColumn("NetTotal", "NetTotal", 120, 8, true, DataGridViewContentAlignment.MiddleRight, "####0.00"));

            // tmp.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }

        public DataTable RpCustomerDetail(int CustomerId)
        {
            string constring1 = "";
            //constring1 = "Server=" + CommonView.DBServer + "; Database = " + CommonView.DataBase + ";UID=root;Pwd=" + CommonView.Pwd + ";Port=" + CommonView.Port + " ;SslMode=none;Connect Timeout=30;Convert Zero Datetime=True;Charset=utf8;";
            constring1 = "Server=" + CommonView.DBServer + "; Database = " + CommonView.DataBase + ";UID=" + CommonView.UId + ";Pwd=" + CommonView.Pwd + ";Port=" + CommonView.Port + " ;SslMode=none;Connect Timeout=30;Convert Zero Datetime=True;Charset=utf8;";
            string path = "";
            path = file;//txb_Path.Text + year + "-" + month + "-" + day + "--" + hour + "-" + minute + "-" + second + ".sql";
            file = path;
            DataTable Tbl = new DataTable();
            MySqlDataAdapter Da = new MySqlDataAdapter();
            using (MySqlConnection conn = new MySqlConnection(constring1))
            {
                MySqlCommand cmd = new MySqlCommand();
                //{
                // using (MySqlBackup mb = new MySqlBackup(cmd))
                //{
                cmd.Connection = conn;
                conn.Open();
                string qry = "";

                qry = " SELECT CustomerId,FullName as Customer,streetLine1,streetLine2,City , PostalCode as PinCode, ";
                qry += " phoneNumber as CellNo ";
                qry += " FROM " + CommonView.DataBase + ".address where customerid= " + CustomerId;

                cmd = new MySqlCommand(qry, conn);
                Da.SelectCommand = cmd;
                Da.Fill(Tbl);
                Tbl.TableName = "navigate";
                Da.Dispose();
                cmd.Dispose();
                conn.Close();
                conn.Close();
                return Tbl;
            }
        }

        public DataTable loadLocation()
        {
            string constring1 = "";
            //constring1 = "Server=" + CommonView.DBServer + "; Database = " + CommonView.DataBase + ";UID=root;Pwd=" + CommonView.Pwd + ";Port=" + CommonView.Port + " ;SslMode=none;Connect Timeout=30;Convert Zero Datetime=True;Charset=utf8;";
            constring1 = "Server=" + CommonView.DBServer + "; Database = " + CommonView.DataBase + ";UID=" + CommonView.UId + ";Pwd=" + CommonView.Pwd + ";Port=" + CommonView.Port + " ;SslMode=none;Connect Timeout=30;Convert Zero Datetime=True;Charset=utf8;";
            string path = "";
            path = file;//txb_Path.Text + year + "-" + month + "-" + day + "--" + hour + "-" + minute + "-" + second + ".sql";
            file = path;
            DataTable Tbl = new DataTable();
            MySqlDataAdapter Da = new MySqlDataAdapter();
            using (MySqlConnection conn = new MySqlConnection(constring1))
            {
                MySqlCommand cmd = new MySqlCommand();
                //{
                // using (MySqlBackup mb = new MySqlBackup(cmd))
                //{
                cmd.Connection = conn;
                conn.Open();
                string qry = "";

                qry = " SELECT Id,Code as Location";
                qry += " FROM " + CommonView.DataBase + ".channel where Id not in (1) order by Id";

                cmd = new MySqlCommand(qry, conn);
                Da.SelectCommand = cmd;
                Da.Fill(Tbl);
                Tbl.TableName = "navigate";
                Da.Dispose();
                cmd.Dispose();
                conn.Close();
                conn.Close();
                return Tbl;
            }
        }
        public void updatePriceList(string code, int price, int shadowPrice, int stockOnHand, string hsnCode, int channelId)
                    {

            try
            {
                string constring1 = "";
                //constring1 = "Server=" + CommonView.DBServer + "; Database = " + CommonView.DataBase + ";UID=root;Pwd=" + CommonView.Pwd + ";Port=" + CommonView.Port + " ;SslMode=none;Connect Timeout=30;Convert Zero Datetime=True;Charset=utf8;";
                constring1 = "Server=" + CommonView.DBServer + "; Database = " + CommonView.DataBase + ";UID=" + CommonView.UId + ";Pwd=" + CommonView.Pwd + ";Port=" + CommonView.Port + " ;SslMode=none;Connect Timeout=30;Convert Zero Datetime=True;Charset=utf8;";
                MySqlConnection Con = new MySqlConnection(constring1);
                MySqlDataAdapter Da = new MySqlDataAdapter();
                Con.Open();

                string qry = "UPDATE " + CommonView.DataBase + ".product_variant_price ";
                qry += " JOIN " + CommonView.DataBase + ".product_variant_channels_channel ";
                qry += " ON " + CommonView.DataBase + ".product_variant_channels_channel.productVariantId = " + CommonView.DataBase + ".product_variant_price .variantId ";
                qry += " JOIN " + CommonView.DataBase + ".product_variant ";
                qry += " ON " + CommonView.DataBase + ".product_variant.id = " + CommonView.DataBase + ".product_variant_price .variantId ";
                qry += " SET " + CommonView.DataBase + ".product_variant_price.price = " + price;
                qry += " WHERE " + CommonView.DataBase + ".product_variant_channels_channel.channelId = " + CommonView.DataBase + ".product_variant_price.channelId ";
                qry += " AND " + CommonView.DataBase + ".product_variant.sku = '" + code + "'";
                qry += " AND " + CommonView.DataBase + ".product_variant_price.channelId = " + channelId;
                qry += " AND " + CommonView.DataBase + ".product_variant.enabled = 1;";
                MySqlCommand Cmd;
                Cmd = new MySqlCommand(qry, Con);
                Cmd.CommandTimeout = 15000;
                Cmd.ExecuteNonQuery();

                Cmd.Dispose();

                string qry2 = "UPDATE " + CommonView.DataBase + ".product_variant pv " +
                      "JOIN " + CommonView.DataBase + ".product_variant_channels_channel pvc " +
                      "  ON pv.id = pvc.productVariantId " +
                      "SET pv.customFieldsShadowprice = " + shadowPrice + " " +
                      "WHERE pv.sku = '" + code + "' " +
                      "AND pvc.channelId = " + channelId + " " +
                      "AND pv.enabled = 1;";

                MySqlCommand Cmd2 = new MySqlCommand(qry2, Con);
                Cmd2.CommandTimeout = 15000;
                Cmd2.ExecuteNonQuery();
                Cmd2.Dispose();

              
                string qry3 = "UPDATE " + CommonView.DataBase + ".stock_level sl " +
                              "JOIN " + CommonView.DataBase + ".product_variant pv " +
                              "  ON pv.id = sl.productVariantId " +
                              "JOIN " + CommonView.DataBase + ".product_variant_channels_channel pvc " +
                              "  ON pv.id = pvc.productVariantId " +
                              "SET sl.stockOnHand = " + stockOnHand + " " +
                              "WHERE pv.sku = '" + code + "' " +
                              "AND pvc.channelId = " + channelId + ";";

                MySqlCommand Cmd3 = new MySqlCommand(qry3, Con);
                Cmd3.CommandTimeout = 15000;
                Cmd3.ExecuteNonQuery();
                Cmd3.Dispose();

            
                string qry4 = "UPDATE " + CommonView.DataBase + ".product p " +
                              "JOIN " + CommonView.DataBase + ".product_variant pv " +
                              "  ON pv.productId = p.id " +
                              "JOIN " + CommonView.DataBase + ".product_variant_channels_channel pvc " +
                              "  ON pv.id = pvc.productVariantId " +
                              "SET p.customFieldsHsncode = '" + hsnCode +"' " + 
                              "WHERE pv.sku = '" + code + "' " +
                              "AND pvc.channelId = " + channelId + " " +
                              "AND p.enabled = 1;";

                MySqlCommand Cmd4 = new MySqlCommand(qry4, Con);
                Cmd4.CommandTimeout = 15000;
                Cmd4.ExecuteNonQuery();
                Cmd4.Dispose();


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

        public string readJSON(string jsonText)
        {
            string address = "";
            WeatherForecast add = JsonConvert.DeserializeObject<WeatherForecast>(jsonText);
            address = "Customer :" + add.FullName + "\nAddress: " + add.StreetLine1 + "," + add.StreetLine2 + ",City :" + add.City + ",PinCode :" + add.PostalCode + ",CellNo :" + add.PhoneNumber;
            CommonView.Customer = add.FullName;
            CommonView.Address = add.StreetLine1 + "," + add.StreetLine2 + ",City :" + add.City + "-" + add.PostalCode;
            CommonView.Pincode = add.PostalCode;
            CommonView.CellNo = add.PhoneNumber;
            return address;
        }
        public string readPaymentMetadataJSON(string jsonT)
        {
            string payment = "";

            //Console.WriteLine("Enter JSON string for the first row:");
            //string firstRowJson = jsonText;

            //Console.WriteLine("Enter JSON string for the second row:");
            //string secondRowJson = Console.ReadLine();

            try
            {

                string jsonText1 = Convert.ToString(jsonT.Substring(1, jsonT.Length - 2));

                string result = jsonText1.Replace("\\", "");

                //// Parse first row JSON string into JObject

                if (result != "")
                {
                    //Payment payment1 = JsonConvert.DeserializeObject<Payment>(result);

                    MetaData myDeserializedClass = JsonConvert.DeserializeObject<MetaData>(Convert.ToString(jsonT));

                    payment = myDeserializedClass.method;
                    CommonView.PaymentId = myDeserializedClass.razorpay_payment_id;
                    CommonView.OrderId = myDeserializedClass.razorpay_order_id;
                    CommonView.Signature = myDeserializedClass.razorpay_signature;
                    //CommonView.Amount = myDeserializedClass.Amount;
                    CommonView.PaymentType = myDeserializedClass.status;

                }
                else
                {
                    CommonView.PaymentId = "";
                    CommonView.OrderId = "";
                    CommonView.Signature = "";
                    CommonView.Amount = "";
                    CommonView.PaymentType = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);// Console.WriteLine($"Error: {ex.Message}");
            }
            return payment;
        }
        public string CheckSmsBalance()
        {
            string balanceApiUrl = "https://control.msg91.com/api/balance.php";
            string apiKey = "409513AhuZ0auiuCo66549fcd8P1";

            try
            {
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072 | SecurityProtocolType.Tls;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(balanceApiUrl + "?authkey=" + apiKey + "&type=0");
                request.Method = "GET";

                // Optional: Set other request properties if needed
                request.Timeout = 10000; // Set the timeout to 10 seconds (adjust as needed)
                // request.Headers.Add("Your-Additional-Header", "header-value");
                request.Headers.Add("authkey", "409513AhuZ0auiuCo66549fcd8P1");
                // Disable TLS (since C# in VS2005 doesn't support later versions)
                // ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream dataStream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(dataStream))
                        {
                            string responseFromServer = reader.ReadToEnd();

                            // Parse the response or handle as needed
                            // string balance = ParseBalanceResponse(responseFromServer);
                            return responseFromServer;
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle specific web exceptions
                return "WebException: {ex.Message}";
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                return "Exception: {ex.Message}";
            }
        }
        public string SendWhatsAppMessages(string cellNo)
        {
            string status1 = "";
            string jsonResponse = "";
            try
            {

                //string url = "https://control.msg91.com/api/v5/whatsapp/whatsapp-outbound-message/bulk/";
                //string authkey = "395929AcYuel89696451b515P1"; // Replace with your actual Msg91 authkey

                // string url = "https://control.msg91.com/api/v5/whatsapp/whatsapp-outbound-message/bulk/";
                string url = "https://api.msg91.com/api/v5/whatsapp/whatsapp-outbound-message/bulk/";
                //string authkey = "395929AcYuel89696451b515P1"; // Replace with your actual Msg91 authkey
                string authkey = "395929A2YW1qXt4afm682c115cP1";
                string mobno = "[918108250626,919840032880]";
                // Example list of phone numbers
                List<string> phoneNumbers = new List<string> { "918525876381", "919840032880" };

                // Convert the list of phone numbers to a comma-separated string
                string phoneNumbersString = string.Join("\", \"", phoneNumbers);

                string templateName = "coupon";
                string templateImage = @"https://media.graphassets.com/QWsUMiHxS6SXvpQ1IzxO";
                //Prepare the JSON payload
                string jsonBody = @"
                                            {
                                                ""integrated_number"": ""919840089302"",
                                                ""content_type"": ""template"",
                                                ""payload"": {
                                                    ""messaging_product"": ""whatsapp"",
                                                    ""type"": ""template"",
                                                    ""template"": {
                                                        ""name"": ""coupon"",
                                                        ""language"": {
                                                            ""code"": ""en_GB"",
                                                            ""policy"": ""deterministic""
                                                        },
                                                        ""namespace"": null,
                                                        ""to_and_components"": [
                                                            {
                                                                 ""to"":  [""918525876381"", ""919840032880"",""919487487088"",""919894089302"",""919894966437""],
                                                                ""components"": {
                                                                    ""header_1"": {
                                                                        ""type"": ""image"",
                                                                        ""value"": ""https://media.graphassets.com/zBdHBRTQ7OOp8J8tFDMQ""
                                                                    },
                                                                    ""button_1"": {
                                                                        ""subtype"": ""url"",
                                                                        ""type"": ""text"",
                                                                        ""value"": ""https://play.google.com/store/apps/details?id=com.kaaikani.kaaikani&pcampaignid=web_share""
                                                                    }
                                                                }
                                                            }
                                                        ]
                                                    }
                                                }
                                            }";

                //                string jsonBody = @"
                //                            {
                //                                ""integrated_number"": ""919840089302"",
                //                                ""content_type"": ""template"",
                //                                ""payload"": {
                //                                    ""messaging_product"": ""whatsapp"",
                //                                    ""type"": ""template"",
                //                                    ""template"": {
                //                                        ""name"": ""limited_offer"",
                //                                        ""language"": {
                //                                            ""code"": ""en_GB"",
                //                                            ""policy"": ""deterministic""
                //                                        },
                //                                        ""namespace"": null,
                //                                        ""to_and_components"": [
                //                                            {
                //                                                 ""to"":  [""phoneNumbersString""],
                //                                                ""components"": {
                //                                                    ""header_1"": {
                //                                                        ""type"": ""image"",
                //                                                        ""value"": ""https://ap-south-1.graphassets.com/cm5c7pec50mx507pg2q1nbbqs/cm6aekcfi1w7f07o4lofm37zn""
                //                                                    },
                //                                                    ""button_1"": {
                //                                                        ""subtype"": ""url"",
                //                                                        ""type"": ""text"",
                //                                                        ""value"": ""https://play.google.com/store/apps/details?id=com.kaaikani.kaaikani&pcampaignid=web_share""
                //                                                    }
                //                                                }
                //                                            }
                //                                        ]
                //                                    }
                //                                }
                //                            }";

                //  string jBody = jsonBody.Replace("phoneNumbersString", phoneNumbersString);

                //    string jsonBody = "{"
                //+ "\"integrated_number\": \"919840089302\","
                //+ "\"content_type\": \"template\","
                //+ "\"payload\": {"
                //+ "\"messaging_product\": \"whatsapp\","
                //+ "\"type\": \"template\","
                //+ "\"template\": {"
                //    + "\"name\": \""+ templateName + "\","
                //+ "\"language\": {"
                //+ "\"code\": \"en_GB\","
                //+ "\"policy\": \"deterministic\""
                //+ "},"
                //+ "\"namespace\": null,"
                //+ "\"to_and_components\": ["
                //+ "{"
                //+ "\"to\": [\"" + phoneNumbersString + "\"],"
                //+ "\"components\": {"
                //+ "\"header_1\": {"
                //+ "\"type\": \"image\","
                //    + "\"value\": \""+ templateImage +"\""
                //+ "},"
                //+ "\"button_1\": {"
                //+ "\"subtype\": \"url\","
                //+ "\"type\": \"text\","
                //+ "\"value\": \"https://play.google.com/store/apps/details?id=com.kaaikani.kaaikani&pcampaignid=web_share\""
                //+ "}"
                //+ "}"
                //+ "}"
                //+ "]"
                //+ "}"
                //+ "}"
                //+ "}";


                // Convert JSON string to byte array
                byte[] byteData = Encoding.UTF8.GetBytes(jsonBody);

                // Create WebRequest
                WebRequest request = WebRequest.Create(url);
                request.Method = "POST";
                request.Headers.Add("authkey", authkey);
                request.ContentType = "application/json";
                request.ContentLength = byteData.Length;

                // Write data to request stream
                using (Stream dataStream = request.GetRequestStream())
                {
                    dataStream.Write(byteData, 0, byteData.Length);
                }

                // Get the response
                using (WebResponse response = request.GetResponse())
                {
                    // Read the response data
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            jsonResponse = reader.ReadToEnd();
                            //Console.WriteLine($"Response: {jsonResponse}");
                        }
                    }
                }
                string status = jsonResponse;

                // Parse the JSON response
                JObject json = JObject.Parse(jsonResponse);

                // Extract the "status" field
                status1 = json["status"].ToString();

            }

            catch (Exception ex)
            {
                //Console.WriteLine($"Exception: {ex.Message}");
            }
            return status1;
        }

        public string SendWhatsAppMessages1(string cellNo)
        {
            string status1 = "";
            string jsonResponse = "";
            try
            {

                //string url = "https://control.msg91.com/api/v5/whatsapp/whatsapp-outbound-message/bulk/";
                //string authkey = "395929AcYuel89696451b515P1"; // Replace with your actual Msg91 authkey

                string url = "https://control.msg91.com/api/v5/whatsapp/whatsapp-outbound-message/bulk/";
                string authkey = "395929AcYuel89696451b515P1"; // Replace with your actual Msg91 authkey

                // Prepare the JSON payload
                string jsonBody = @"
            {
                ""integrated_number"": ""919840089302"",
                ""content_type"": ""template"",
                ""payload"": {
                    ""messaging_product"": ""whatsapp"",
                    ""type"": ""template"",
                    ""template"": {
                        ""name"": ""coupon"",
                        ""language"": {
                            ""code"": ""en_GB"",
                            ""policy"": ""deterministic""
                        },
                        ""namespace"": null,
                        ""to_and_components"": [
                            {
                                 ""to"": [""9994017535"",""8525876381""],
                                ""components"": {
                                    ""header_1"": {
                                        ""type"": ""image"",
                                        ""value"": ""https://media.graphassets.com/3IDHVYDBSqGwCMPqdmWm""
                                    },
                                    ""button_1"": {
                                        ""subtype"": ""url"",
                                        ""type"": ""text"",
                                        ""value"": ""https://ap-south-1.graphassets.com/cm1rin51b0am206pj8yhrh9ce/cm4jjdjhy0isj07pml4vz49x2""
                                    }
                                }
                            }
                        ]
                    }
                }
            }";



                // Convert JSON string to byte array
                byte[] byteData = Encoding.UTF8.GetBytes(jsonBody);

                // Create WebRequest
                WebRequest request = WebRequest.Create(url);
                request.Method = "POST";
                request.Headers.Add("authkey", authkey);
                request.ContentType = "application/json";
                request.ContentLength = byteData.Length;

                // Write data to request stream
                using (Stream dataStream = request.GetRequestStream())
                {
                    dataStream.Write(byteData, 0, byteData.Length);
                }

                // Get the response
                using (WebResponse response = request.GetResponse())
                {
                    // Read the response data
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            jsonResponse = reader.ReadToEnd();
                            //Console.WriteLine($"Response: {jsonResponse}");
                        }
                    }
                }
                string status = jsonResponse;

                // Parse the JSON response
                JObject json = JObject.Parse(jsonResponse);

                // Extract the "status" field
                status1 = json["status"].ToString();

            }

            catch (Exception ex)
            {
                //Console.WriteLine($"Exception: {ex.Message}");
            }
            return status1;
        }
        public void whatAppMultiNumbers()
        {
            try
            {
                //string url = "https://control.msg91.com/api/v5/whatsapp/whatsapp-outbound-message/bulk/";
                //string authkey = "395929AcYuel89696451b515P1"; // Replace with your actual Msg91 authkey

                //var phoneNumbers = new List<string> { "9840032880"};//, "[+919840032880]" };

                //var jsonBodyTemplate = new WhatsAppMessage
                //{
                //    integrated_number = "919840089302",
                //    content_type = "template",
                //    payload = new Payload
                //    {
                //        messaging_product = "whatsapp",
                //        type = "template",
                //        template = new Template
                //        {
                //            name = "wednesday_offer",
                //            language = new Language
                //            {
                //                code = "en_GB",
                //                policy = "deterministic"
                //            },

                //            namespace1 = "null",
                //            to_and_components = new List<ToAndComponents>()
                //        }
                //    }
                //};



                //foreach (var phoneNumber in phoneNumbers)
                //{
                //    jsonBodyTemplate.payload.template.to_and_components.Add(new ToAndComponents
                //    {
                //        to =    "[" + phoneNumber+"]", 
                //        components = new Components
                //        {
                //            header_1 = new Header
                //            {
                //                type = "image",
                //                value = "https://media.graphassets.com/wn9U0DQqTAiU9zGHGkjL"
                //            },
                //            button_1 = new Button
                //            {
                //                subtype = "url",
                //                type = "text",
                //                value = "https://play.google.com/store/apps/details?id=com.kaaikani.kaaikani&pcampaignid=web_share"
                //            }
                //        }
                //    });
                //}

                string url = "https://control.msg91.com/api/v5/whatsapp/whatsapp-outbound-message/bulk/";
                string authkey = "395929AcYuel89696451b515P1"; // Replace with your actual Msg91 authkey

                var phoneNumbers = new List<string> { "+919840032880" };

                // Construct the JSON payload directly as a string
                var toComponentsJson = new StringBuilder();
                foreach (var phoneNumber in phoneNumbers)
                {
                    if (toComponentsJson.Length > 0)
                        toComponentsJson.Append(", ");

                    toComponentsJson.AppendFormat(@"
            {{
                ""to"": ""{0}"",
                ""components"": {{
                    ""header_1"": {{
                        ""type"": ""image"",
                        ""value"": ""https://media.graphassets.com/wn9U0DQqTAiU9zGHGkjL""
                    }},
                    ""button_1"": {{
                        ""subtype"": ""url"",
                        ""type"": ""text"",
                        ""value"": ""https://play.google.com/store/apps/details?id=com.kaaikani.kaaikani&pcampaignid=web_share""
                    }}
                }}
            }}", phoneNumber);
                }

                var jsonBody = @"
        {{
            ""integrated_number"": ""919840089302"",
            ""content_type"": ""template"",
            ""payload"": {{
                ""messaging_product"": ""whatsapp"",
                ""type"": ""template"",
                ""template"": {{
                    ""name"": ""wednesday_offer"",
                    ""language"": {{
                        ""code"": ""en_GB"",
                        ""policy"": ""deterministic""
                    }},
                    ""namespace"": ""null"",
                    ""to_and_components"": [
                        {toComponentsJson}
                    ]
                }}
            }}
        }}";

                var json = JsonConvert.SerializeObject(jsonBody);
                byte[] byteData = Encoding.UTF8.GetBytes(json);

                // Create WebRequest
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.Headers.Add("authkey", authkey);
                request.ContentType = "application/json";
                request.ContentLength = byteData.Length;

                // Write data to request stream
                using (Stream dataStream = request.GetRequestStream())
                {
                    dataStream.Write(byteData, 0, byteData.Length);
                }

                // Get the response
                string jsonResponse;
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            jsonResponse = reader.ReadToEnd();
                        }
                    }
                }

                // Parse and handle the JSON response
                JObject json1 = JObject.Parse(jsonResponse);
                string status = json1["status"].ToString();

                // Optionally print status or handle it accordingly
                // Console.WriteLine($"Response Status: {status}");
            }
            catch (WebException webEx)
            {
                using (var errorResponse = (HttpWebResponse)webEx.Response)
                {
                    if (errorResponse != null)
                    {
                        using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                        {
                            string errorText = reader.ReadToEnd();
                            // Console.WriteLine($"Error: {errorText}");
                        }
                    }
                }
                // Log the exception
                //Console.WriteLine($"Exception: {ex.Message}");
            }
        }
        public void whatsApp()
        {
            //string apiStr; 
            //var client = new RestClient("https://control.msg91.com/api/v5/whatsapp/whatsapp-outbound-message/bulk/"); 
            //var request = new RestRequest(Method.POST); 
            //request.AddHeader("authkey", ""); request.AddHeader("content-type", "application/json"); 
            //request.AddHeader("accept", "application/json"); 
            //request.AddParameter("application/json", "curl --location 'https://api.msg91.com/api/v5/whatsapp/whatsapp-outbound-message/bulk/' \\\n--header 'Content-Type: application/json' \\\n--header 'authkey: 395929AcYuel89696451b515P1' \\\n--header 'Cookie: PHPSESSID=ini008aqs182s45s9lmgvg4nn3' \\\n--data '{\n \"integrated_number\": \"919840089302\",\n \"content_type\": \"template\",\n \"payload\": {\n \"messaging_product\": \"whatsapp\",\n \"type\": \"template\",\n \"template\": {\n \"name\": \"kaaikani\",\n \"language\": {\n \"code\": \"en_GB\",\n \"policy\": \"deterministic\"\n },\n \"namespace\": null,\n \"to_and_components\": [\n {\n \"to\": [\n \"919840032880\"\n ],\n \"components\": {\n \"header_1\": {\n \"type\": \"image\",\n \"value\": \"https://media.graphassets.com/2QiUz28pQnWogZGm16nu\"\n },\n \"button_1\": {\n \"subtype\": \"url\",\n \"type\": \"text\",\n \"value\": \"https://play.google.com/store/apps/details?id=com.kaaikani.kaaikani&pcampaignid=web_share\"\n }\n }\n }\n ]\n }\n }\n}'", ParameterType.RequestBody); 
            //IRestResponse response = client.Execute(request);


            var client = new RestClient("https://control.msg91.com/api/v5/whatsapp/whatsapp-outbound-message/bulk/");
            var request = new RestRequest(Method.POST);

            // Add necessary headers
            request.AddHeader("authkey", "395929AcYuel89696451b515P1"); // Replace with your actual auth key
            request.AddHeader("content-type", "application/json");
            request.AddHeader("accept", "application/json");

            // Create the JSON payload
            string jsonBody = @"
            {
                ""integrated_number"": ""919840089302"",
                ""content_type"": ""template"",
                ""payload"": {
                    ""messaging_product"": ""whatsapp"",
                    ""type"": ""template"",
                    ""template"": {
                        ""name"": ""coupon"",
                        ""language"": {
                            ""code"": ""en_GB"",
                            ""policy"": ""deterministic""
                        },
                        ""namespace"": null,
                        ""to_and_components"": [
                            {
                                ""to"": [""<919840032880>""],
                                ""components"": {
                                    ""header_1"": {
                                        ""type"": ""image"",
                                        ""value"": ""https://media.graphassets.com/2QiUz28pQnWogZGm16nu""
                                    },
                                    ""button_1"": {
                                        ""subtype"": ""url"",
                                        ""type"": ""text"",
                                        ""value"": ""https://play.google.com/store/apps/details?id=com.kaaikani.kaaikani&pcampaignid=web_share""
                                    }
                                }
                            }
                        ]
                    }
                }
            }";// Add JSON body to request
            request.AddJsonBody(jsonBody);

            // Execute the request
            IRestResponse response = client.Execute(request);

            //Check response status and content
            //if (response1.IsSuccessful)
            //{
            //    Console.WriteLine("Request successful!");
            //    Console.WriteLine(response.Content);
            //}
            //else
            //{
            //    Console.WriteLine("Request failed!");
            //    Console.WriteLine(response.ErrorMessage);
            //}


            //return apiStr;
        }
    }

}
public class Root
{
    public string PaymentId { get; set; }
    public string OrderId { get; set; }
    public string Signature { get; set; }
    public string Amount { get; set; }
    public string PaymentType { get; set; }
}

public class MetaData
{
    public string razorpay_payment_id { get; set; }
    public string razorpay_order_id { get; set; }
    public string status { get; set; }
    public string razorpay_signature { get; set; }
    public string method { get; set; }
}
public class WeatherForecast
{
    string _FullName;
    public string FullName
    {
        get
        {
            return _FullName;
        }
        set
        {
            _FullName = value;
        }
    }
    string _StreetLine1;
    public string StreetLine1
    {
        get
        {
            return _StreetLine1;
        }
        set
        {
            _StreetLine1 = value;
        }
    }
    string _StreetLine2;
    public string StreetLine2
    {
        get
        {
            return _StreetLine2;
        }
        set
        {
            _StreetLine2 = value;
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
    string _PostalCode;
    public string PostalCode
    {
        get
        {
            return _PostalCode;
        }
        set
        {
            _PostalCode = value;
        }
    }
    string _PhoneNumber;
    public string PhoneNumber
    {
        get
        {
            return _PhoneNumber;
        }
        set
        {
            _PhoneNumber = value;
        }
    }
}
public class paymentMetadata
{
    //string _PaymentId;
    //public string PaymentId
    //{
    //    get
    //    {
    //        return _PaymentId;
    //    }
    //    set
    //    {
    //        _PaymentId = value;
    //    }
    //}
    //string _OrderId;
    //public string OrderId
    //{
    //    get
    //    {
    //        return _OrderId;
    //    }
    //    set
    //    {
    //        _OrderId = value;
    //    }
    //}
    //string _Signature;
    //public string Signature
    //{
    //    get
    //    {
    //        return _Signature;
    //    }
    //    set
    //    {
    //        _Signature = value;
    //    }
    //}
    public decimal Amount { get; set; }
    public string PaymentType { get; set; }

}
public class WhatsAppMessage
{
    public string integrated_number { get; set; }
    public string content_type { get; set; }
    public Payload payload { get; set; }
}

public class Payload
{
    public string messaging_product { get; set; }
    public string type { get; set; }
    public Template template { get; set; }

}


public class Template
{
    public string name { get; set; }

    public Language language { get; set; }

    public String namespace1 = "namespace";



    public List<ToAndComponents> to_and_components { get; set; }
}

public class Language
{
    public string code { get; set; }
    public string policy { get; set; }


}
public class ToAndComponents
{
    public string to { get; set; }
    public Components components { get; set; }
}

public class Components
{
    public Header header_1 { get; set; }
    public Button button_1 { get; set; }
}

public class Header
{
    public string type { get; set; }
    public string value { get; set; }
}

public class Button
{
    public string subtype { get; set; }
    public string type { get; set; }
    public string value { get; set; }
}
public class Payment
{
    [JsonProperty("amount")]
    public string Amount { get; set; }

    [JsonProperty("paymentType")]
    public string PaymentType { get; set; }
}



