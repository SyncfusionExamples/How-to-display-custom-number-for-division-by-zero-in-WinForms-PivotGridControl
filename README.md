# How to display custom number for division by zero in WinForms PivotGridControl?

In [WinForms PivotGrid](https://www.syncfusion.com/winforms-ui-controls/pivot-grid), when a calculation results in division by zero, the infinity symbol (∞) is displayed by default. To display 0 instead of infinity, you can use the following formula.

**C#**
```csharp
 pivotGrid.PivotCalculations.Add(new PivotComputationInfo()
 {
     FieldName = "AchQtyPer",
     FieldHeader = "Ach Qty % (NEW)",
     CalculationType = CalculationType.Formula,
     Formula = "IF([TargetQty] = 0, 0, [AchQty] / [TargetQty])",
     Format = "P1"
 });
```

**Note:** In the above formula, an **IF condition** is used. If TargetQty (**FieldName**) is 0, you can assign a value based on your requirement (for example, 0 or any custom number). The internal calculation will then use this assigned value. If the condition is not met (i.e., when TargetQty is not 0), the normal division will be performed using the values from the data source.

![Display Custom Number For Division By Zero](Display%20custom%20number%20for%20division%20by%20zero.gif)

Take a moment to peruse the [WinForms PivotGrid - Pivot Calculations](https://help.syncfusion.com/windowsforms/pivot-grid/pivot-calculations) documentation, to learn more about calculations with example.