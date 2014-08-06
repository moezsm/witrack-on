using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Web;
using System.Web.Mvc;
using DXWebApplication1.Models;
using DevExpress.XtraCharts;
namespace DXWebApplication1.Reports
{
    public partial class XtraReport2 : DevExpress.XtraReports.UI.XtraReport
    {
        public DevExpress.XtraCharts.Series seriesp;
        public DevExpress.XtraCharts.SeriesPoint seriesPoint1;
         public DevExpress.XtraCharts.LineSeriesView lineSeriesView1;
        /*
        public DevExpress.XtraCharts.PointOptions pointOptions1;
        public DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel1;
        public DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel1;
        */


         public XtraReport2(DetailReport detail)
        {
            InitializeComponent();
            titre.NullValueText = "Courbe pour " + detail.nomsonde;
            User.NullValueText = detail.username;
            location.NullValueText = detail.location;
            zone.NullValueText = detail.zone;
            datereport.NullValueText = detail.datereport.ToString("yyyy/MM/dd");
            numerosonde.NullValueText = detail.numerosonde;
            max.NullValueText = detail.max.ToString();
            min.NullValueText = detail.min.ToString();
            datedebut.NullValueText = detail.datedebut.ToString("yyyy/MM/dd");
            datefin.NullValueText = detail.datefin.ToString("yyyy/MM/dd");
            haute.NullValueText = detail.haute.ToString() + " C°" ;
            basse.NullValueText = detail.basse.ToString() + " C°";
            valuesTableAdapter.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ModuleEquipementContext"].ConnectionString);


        }

        

        public void SetReportParameter(int EquipementID, int max, int min)
        {
           temperatureDetailReport1.Clear();
           valuesTableAdapter.Fill(temperatureDetailReport1.Values, EquipementID);
            
            System.Data.DataSet Tabletemperature = temperatureDetailReport1.Values.DataSet;
            seriesp = new DevExpress.XtraCharts.Series();
            lineSeriesView1 = new DevExpress.XtraCharts.SplineSeriesView();
            lineSeriesView1.MarkerVisibility = DevExpress.Utils.DefaultBoolean.False;


            // Cast the chart's diagram to the XYDiagram type, to access its axes.
           


            seriesp.View = lineSeriesView1;
            
            foreach (System.Data.DataRow pRow in Tabletemperature.Tables[0].Rows)
            {
                seriesPoint1 = new DevExpress.XtraCharts.SeriesPoint(pRow["DateCreation"], new object[] { ((object)(Math.Round( Convert.ToDecimal(pRow["Val"]), 2))) });
                seriesp.Points.Add(seriesPoint1);
                seriesp.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
                
                seriesp.ShowInLegend = true; 

            }
           
        
            xrChart1.Series.Add(seriesp);
            xrChart1.Legend.AlignmentVertical = LegendAlignmentVertical.BottomOutside;
            xrChart1.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center;
            xrChart1.Legend.Direction = LegendDirection.LeftToRight;
            xrChart1.Legend.HorizontalIndent = 5;
            xrChart1.Legend.Margins.Top = 20;
            

            XYDiagram diagram = (XYDiagram)xrChart1.Diagram;

            // Create a constant line.
            ConstantLine constantLine1 = new ConstantLine("Constant Line 1");


            // Define its axis value.
            constantLine1.AxisValue = max;

            // Customize the behavior of the constant line.
            constantLine1.Visible = true;
            constantLine1.ShowInLegend = true;
            constantLine1.LegendText = "Alarme Haute";
            constantLine1.ShowBehind = false;

            // Customize the constant line's title.
            constantLine1.Title.Visible = false;
            constantLine1.Title.Text = "Alarme Haute";
            constantLine1.Title.TextColor = Color.Red;
            constantLine1.Title.Antialiasing = false;
            constantLine1.Title.Font = new Font(this.Font.FontFamily.Name, 14, FontStyle.Bold);
            constantLine1.Title.ShowBelowLine = true;
            constantLine1.Title.Alignment = ConstantLineTitleAlignment.Far;

            // Customize the appearance of the constant line.
            constantLine1.Color = Color.Red;
            constantLine1.LineStyle.DashStyle = DashStyle.Dash;
            constantLine1.LineStyle.Thickness = 1;


            // Create a constant line.
            ConstantLine constantLine2 = new ConstantLine("Constant Line 1");


            // Define its axis value.
            constantLine2.AxisValue = min;

            // Customize the behavior of the constant line.
            constantLine2.Visible = true;
            constantLine2.ShowInLegend = true;
            constantLine2.LegendText = "Alarme basse";
            constantLine2.ShowBehind = true;

            // Customize the constant line's title.
            constantLine2.Title.Visible = false;
            constantLine2.Title.Text = "Alarme basse";
            constantLine2.Title.TextColor = Color.Red;
            constantLine2.Title.Antialiasing = false;
            constantLine2.Title.Font = new Font(this.Font.FontFamily.Name, 14, FontStyle.Bold);
            constantLine2.Title.ShowBelowLine = true;
            constantLine2.Title.Alignment = ConstantLineTitleAlignment.Far;

            // Customize the appearance of the constant line.
            constantLine2.Color = Color.Blue;
            constantLine2.LineStyle.DashStyle = DashStyle.Dash;
            constantLine2.LineStyle.Thickness = 1;


            diagram.AxisY.ConstantLines.Add(constantLine1);
            diagram.AxisY.ConstantLines.Add(constantLine2);


            
        }

    }
}
