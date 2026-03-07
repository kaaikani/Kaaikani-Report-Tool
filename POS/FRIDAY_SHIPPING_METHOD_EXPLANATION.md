# Friday Shipping Method - Dynamic vs Static Analysis

## 📋 **User Requirement:**

**Current Situation:**
- Friday orders are **excluded** (only balance days - Monday to Thursday)
- Orders are processed for Monday, Tuesday, Wednesday, Thursday only

**Future Requirement:**
- All days including Friday should have orders
- If Friday orders exist, they need a **new shipping method**

**Question:**
- Can this be done **dynamically**?
- Or must it be done **statically**?

---

## 🔍 **Current Code Analysis:**

### **1. Shipping Method Filtering (Current Implementation):**

**File:** `DataClass\Reports\Class1.cs`

**Line 350, 354, 417, 421, 438, 447, 690, 861-864, 902-904:**

```csharp
// Location-based hardcoded filtering
if (locationId == 4)
{ 
    qry += " AND st.name = 'Tomorrow Morning Delivery (Rs.40 incl.Tax)' "; 
}
else if (locationId == 6)
{ 
    qry += " AND st.name = 'Tomorrow Morning Delivery (Rs.50 incl.Tax)' "; 
}

// Evening delivery
if (locationId == 4)
{ 
    qry += " AND st.name = 'Tomorrow Evening Delivery (Rs.20 incl.Tax)' "; 
}
else if (locationId == 6)
{ 
    qry += " AND st.name = 'Tomorrow Evening Delivery (Rs.30 incl.Tax)' "; 
}
```

**Key Observations:**
- ❌ **All shipping method names are hardcoded**
- ❌ **No day-of-week filtering exists**
- ❌ **No Friday-specific logic**
- ❌ **Exact string match required**

---

### **2. Date/Time Filtering (Current Implementation):**

**File:** `DataClass\Reports\Class1.cs`

**Line 686:**
```csharp
qry += " O.OrderPlacedAt between '" + fDt.ToString("yyyy/MM/dd") + " 18:30:00' AND '" + tDt.ToString("yyyy/MM/dd") + " 23:59:59' ";
```

**Line 858:**
```csharp
qry += " Where O.OrderPlacedAt between '" + fDt.ToString("yyyy/MM/dd") + " 18:30:00' AND '" + tDt.ToString("yyyy/MM/dd") + " 23:59:59' ";
```

**Key Observations:**
- ✅ Uses date range filtering
- ❌ **No day-of-week check (WEEKDAY, DAYOFWEEK)**
- ❌ **No Friday exclusion logic visible**
- ⚠️ Friday exclusion might be handled at **date selection level** (user selects dates excluding Friday)

---

## 🎯 **Answer: STATIC Only (Not Dynamic)**

### **Why It Must Be Static:**

#### **1. Hardcoded Shipping Method Names:**

**Current Code Pattern:**
```csharp
qry += " AND st.name = 'Tomorrow Morning Delivery (Rs.40 incl.Tax)' ";
```

**Problem:**
- Code uses **exact string match** with hardcoded names
- Even if you add new shipping method to database, code won't automatically use it
- **Must update code** to include new shipping method name

**For Friday:**
- You must add new hardcoded condition:
  ```csharp
  if (isFriday) {
      qry += " AND st.name = 'Friday Delivery (Rs.XX incl.Tax)' ";
  }
  ```
- This is **STATIC** - hardcoded in code

---

#### **2. No Dynamic Shipping Method Discovery:**

**Current Code:**
- Does NOT query available shipping methods from database
- Does NOT dynamically build WHERE clause based on available methods
- Uses **fixed hardcoded names** only

**Missing Dynamic Logic:**
```csharp
// This does NOT exist in current code:
// SELECT name FROM shipping_method_translation WHERE ...
// Then dynamically build WHERE clause
```

**For Friday:**
- Cannot dynamically discover "Friday shipping method"
- Must hardcode the name

---

#### **3. Day-of-Week Logic Must Be Added:**

**Current Code:**
- No `WEEKDAY()` or `DAYOFWEEK()` SQL functions
- No C# `DayOfWeek` checks
- No Friday-specific filtering

**Required for Friday:**
```csharp
// Must add STATIC logic:
DayOfWeek dayOfWeek = orderDate.DayOfWeek;
if (dayOfWeek == DayOfWeek.Friday) {
    // Use Friday shipping method
    qry += " AND st.name = 'Friday Delivery (Rs.XX incl.Tax)' ";
} else {
    // Use existing shipping methods
    qry += " AND st.name = 'Tomorrow Morning Delivery (Rs.40 incl.Tax)' ";
}
```

This is **STATIC** - hardcoded day check and shipping method name

---

#### **4. Location-Based Logic is Static:**

**Current Code:**
```csharp
if (locationId == 4) {
    qry += " AND st.name = 'Tomorrow Morning Delivery (Rs.40 incl.Tax)' ";
} else if (locationId == 6) {
    qry += " AND st.name = 'Tomorrow Morning Delivery (Rs.50 incl.Tax)' ";
}
```

**For Friday:**
- Must add similar static logic:
  ```csharp
  if (dayOfWeek == DayOfWeek.Friday) {
      if (locationId == 4) {
          qry += " AND st.name = 'Friday Delivery (Rs.XX incl.Tax)' ";
      } else if (locationId == 6) {
          qry += " AND st.name = 'Friday Delivery (Rs.YY incl.Tax)' ";
      }
  }
  ```
- This is **STATIC** - hardcoded conditions

---

## 📊 **Complete Implementation Flow (Static Approach):**

### **Step 1: Add Friday Shipping Method to Database**

```sql
INSERT INTO shipping_method_translation (id, name, languageCode, ...)
VALUES (..., 'Friday Delivery (Rs.60 incl.Tax)', 'en', ...);
```

✅ **This is Dynamic** - Database can store it

---

### **Step 2: Update Code to Include Friday Logic**

**File:** `DataClass\Reports\Class1.cs`

**Required Changes:**

```csharp
// Add day-of-week check
DayOfWeek dayOfWeek = fDt.DayOfWeek; // or order date

// Add Friday-specific shipping method filter
if (dayOfWeek == DayOfWeek.Friday) {
    // Friday shipping method
    if (locationId == 4) {
        qry += " AND st.name = 'Friday Delivery (Rs.60 incl.Tax)' ";
    } else if (locationId == 6) {
        qry += " AND st.name = 'Friday Delivery (Rs.70 incl.Tax)' ";
    }
} else {
    // Existing logic for other days
    if (locationId == 4) {
        qry += " AND st.name = 'Tomorrow Morning Delivery (Rs.40 incl.Tax)' ";
    } else if (locationId == 6) {
        qry += " AND st.name = 'Tomorrow Morning Delivery (Rs.50 incl.Tax)' ";
    }
}
```

❌ **This is STATIC** - Hardcoded:
- Day check (`DayOfWeek.Friday`)
- Shipping method names
- Location IDs
- Prices

---

### **Step 3: Multiple Locations Need Updates**

**Files to Update:**
1. `RptLoadDetailReport()` - Line 348-356, 415-423
2. `RptLoadCummDelTimeReport()` - Line 689-690
3. `RptLoadBillDelPartnerReport()` - Line 861-864, 902-904
4. Other report methods with shipping method filters

**Each location needs:**
- Friday day check
- Friday shipping method name
- Location-specific logic

❌ **All STATIC** - Must hardcode in each method

---

## ❌ **Why Dynamic Approach Won't Work:**

### **1. No Dynamic Shipping Method Discovery:**

**Current Code Pattern:**
```csharp
// Static hardcoded name
qry += " AND st.name = 'Tomorrow Morning Delivery (Rs.40 incl.Tax)' ";
```

**Dynamic Approach Would Require:**
```csharp
// Query database for available shipping methods
string shippingMethodQuery = "SELECT name FROM shipping_method_translation WHERE ...";
// Build WHERE clause dynamically
qry += " AND st.name IN (" + dynamicShippingMethods + ")";
```

**Problem:**
- This logic **does NOT exist** in current code
- Would require **major refactoring**
- Current architecture is **static-based**

---

### **2. No Day-of-Week Configuration:**

**Current Code:**
- No database table for day-of-week rules
- No configuration for "which shipping method for which day"
- All logic is **hardcoded in C# code**

**Dynamic Approach Would Require:**
```sql
-- New table needed:
CREATE TABLE shipping_method_day_config (
    dayOfWeek INT,
    locationId INT,
    shippingMethodId INT,
    ...
);
```

**Problem:**
- This table **does NOT exist**
- Would require **database schema changes**
- Would require **code refactoring**

---

### **3. Current Architecture is Static:**

**Evidence:**
- All shipping method names are hardcoded strings
- All location IDs are hardcoded (4, 6)
- All prices are hardcoded in names (Rs.40, Rs.50, Rs.20, Rs.30)
- No configuration tables
- No dynamic query building

**Conclusion:**
- Architecture is designed for **static approach**
- Dynamic approach would require **complete redesign**

---

## ✅ **Final Answer:**

### **Friday Shipping Method Must Be STATIC:**

**Reasons:**

1. **✅ Database Part (Dynamic):**
   - Can add Friday shipping method to `shipping_method_translation` table
   - Database can store it dynamically
   - No code change needed for database insertion

2. **❌ Code Part (Static):**
   - Must add hardcoded Friday day check (`DayOfWeek.Friday`)
   - Must add hardcoded Friday shipping method name
   - Must add hardcoded location-based logic
   - Must update multiple methods in code
   - **Cannot be done dynamically** without major refactoring

---

## 📝 **Implementation Steps (Static Approach):**

### **Step 1: Database (Dynamic) ✅**

```sql
-- Add Friday shipping method to database
INSERT INTO shipping_method_translation 
(id, name, languageCode, ...)
VALUES 
(..., 'Friday Delivery (Rs.60 incl.Tax)', 'en', ...);
```

---

### **Step 2: Code Updates (Static) ❌**

**File:** `DataClass\Reports\Class1.cs`

**Method:** `RptLoadDetailReport()`

**Location:** Line 348-356

**Current Code:**
```csharp
if (locationId == 4)
{
    qry += " AND st.name = 'Tomorrow Morning Delivery (Rs.40 incl.Tax)' ";
}
else if (locationId == 6)
{
    qry += " AND st.name = 'Tomorrow Morning Delivery (Rs.50 incl.Tax)' ";
}
```

**Required Change:**
```csharp
// Add Friday check
DayOfWeek dayOfWeek = fDt.DayOfWeek;

if (dayOfWeek == DayOfWeek.Friday) {
    // Friday shipping method
    if (locationId == 4)
    {
        qry += " AND st.name = 'Friday Delivery (Rs.60 incl.Tax)' ";
    }
    else if (locationId == 6)
    {
        qry += " AND st.name = 'Friday Delivery (Rs.70 incl.Tax)' ";
    }
} else {
    // Existing logic for other days
    if (locationId == 4)
    {
        qry += " AND st.name = 'Tomorrow Morning Delivery (Rs.40 incl.Tax)' ";
    }
    else if (locationId == 6)
    {
        qry += " AND st.name = 'Tomorrow Morning Delivery (Rs.50 incl.Tax)' ";
    }
}
```

**Repeat for:**
- Line 415-423 (Evening delivery)
- Line 438 (Time-based filtering)
- Line 447 (Evening delivery)
- Line 689-690 (Cumulative report)
- Line 861-864 (Bill delivery report - Morning)
- Line 902-904 (Bill delivery report - Evening)
- All other methods with shipping method filters

---

## 🎯 **Summary:**

### **Can Friday Shipping Method Be Dynamic?**

**Answer: ❌ NO - Must Be STATIC**

**Reasons:**

1. **Current Architecture:**
   - All shipping method names are hardcoded
   - No dynamic discovery mechanism
   - No day-of-week configuration table
   - Static-based design

2. **Required Changes:**
   - Add `DayOfWeek.Friday` check (STATIC)
   - Add hardcoded Friday shipping method name (STATIC)
   - Add location-based logic (STATIC)
   - Update multiple methods (STATIC)

3. **Database Part:**
   - ✅ Can add Friday shipping method dynamically to database
   - ❌ But code must be updated statically to use it

---

## 📊 **Comparison:**

| Aspect | Dynamic | Static |
|--------|---------|--------|
| **Database Insert** | ✅ Yes | ✅ Yes |
| **Code Discovery** | ❌ No | ✅ Yes (Hardcoded) |
| **Day Check** | ❌ No | ✅ Yes (Hardcoded) |
| **Shipping Method Name** | ❌ No | ✅ Yes (Hardcoded) |
| **Location Logic** | ❌ No | ✅ Yes (Hardcoded) |
| **Overall** | ❌ **Not Possible** | ✅ **Must Use This** |

---

## ✅ **Final Answer:**

**Friday Shipping Method:**
- **Database:** ✅ Can be added dynamically
- **Code:** ❌ **Must be STATIC** (hardcoded)

**Conclusion:**
- You **cannot** make it fully dynamic with current architecture
- You **must** update code statically to include Friday logic
- Database part is dynamic, but code part is static

**To make it dynamic:** Would require complete refactoring of shipping method filtering logic, which is beyond the scope of adding Friday support.

---

## 🔧 **What Needs to Be Done:**

1. ✅ **Database:** Add Friday shipping method (Dynamic - No code change)
2. ❌ **Code:** Add Friday day check (Static - Code change required)
3. ❌ **Code:** Add Friday shipping method name (Static - Code change required)
4. ❌ **Code:** Add location-based logic (Static - Code change required)
5. ❌ **Code:** Update all report methods (Static - Code change required)

**Total:** 1 Dynamic + 4 Static = **Mostly Static Approach Required**
