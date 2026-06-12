using Syncfusion.PivotAnalysis.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PivotGridDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            

            // Bind data
            pivotGrid.ItemSource = GetData();

            // Row field
            pivotGrid.PivotRows.Add(new PivotItem() { FieldMappingName = "Product" });

            // Column field
            pivotGrid.PivotColumns.Add(new PivotItem() { FieldMappingName = "Year" });

            // Values
            pivotGrid.PivotCalculations.Add(new PivotComputationInfo()
            {
                FieldName = "AchQty",
                SummaryType = SummaryType.DoubleTotalSum
            });

            pivotGrid.PivotCalculations.Add(new PivotComputationInfo()
            {
                FieldName = "TargetQty",
                SummaryType = SummaryType.DoubleTotalSum
            });

            pivotGrid.PivotCalculations.Add(new PivotComputationInfo()
            {
                FieldName = "AchQtyPer",
                FieldHeader = "Ach Qty % (OLD)",
                CalculationType = CalculationType.Formula,
                Formula = "[AchQty] / [TargetQty]",
                Format = "P1"
            });

            pivotGrid.PivotCalculations.Add(new PivotComputationInfo()
            {
                FieldName = "AchQtyPer",
                FieldHeader = "Ach Qty % (NEW)",
                CalculationType = CalculationType.Formula,
                Formula = "IF([TargetQty] = 0, 0, [AchQty] / [TargetQty])",
                Format = "P1"
            });

        }

        private DataTable GetData()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Product", typeof(string));
            dt.Columns.Add("Year", typeof(int));
            dt.Columns.Add("AchQty", typeof(double));
            dt.Columns.Add("TargetQty", typeof(double));

            //dt.Rows.Add(50, 0);
            dt.Rows.Add("A", 2024, 50, 0);
            dt.Rows.Add("A", 2025, 75, 230);
            dt.Rows.Add("B", 2024, 40, 110);
            dt.Rows.Add("B", 2025, 60, 0);

            return dt;
        }
    }
}
