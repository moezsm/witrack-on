namespace DXWebApplication1.Reports
{
    partial class XtraReport2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel1 = new DevExpress.XtraCharts.PointSeriesLabel();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrChart1 = new DevExpress.XtraReports.UI.XRChart();
            this.temperatureDetailReport1 = new DXWebApplication1.Data.TemperatureDetailReport();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrControlStyle1 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.xrControlStyle2 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.datereport = new DevExpress.XtraReports.UI.XRLabel();
            this.zone = new DevExpress.XtraReports.UI.XRLabel();
            this.location = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPanel1 = new DevExpress.XtraReports.UI.XRPanel();
            this.datedebut = new DevExpress.XtraReports.UI.XRLabel();
            this.haute = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.min = new DevExpress.XtraReports.UI.XRLabel();
            this.max = new DevExpress.XtraReports.UI.XRLabel();
            this.numerosonde = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.titre = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.User = new DevExpress.XtraReports.UI.XRLabel();
            this.xrControlStyle3 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.valuesTableAdapter = new DXWebApplication1.Data.TemperatureDetailReportTableAdapters.ValuesTableAdapter();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.basse = new DevExpress.XtraReports.UI.XRLabel();
            this.datefin = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this.xrChart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.temperatureDetailReport1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Expanded = false;
            this.Detail.HeightF = 307.2917F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrChart1
            // 
            this.xrChart1.AutoBindingSettingsEnabled = false;
            this.xrChart1.AutoLayoutSettingsEnabled = false;
            this.xrChart1.BorderColor = System.Drawing.Color.Black;
            this.xrChart1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrChart1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 145.1249F);
            this.xrChart1.Name = "xrChart1";
            this.xrChart1.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.xrChart1.SeriesTemplate.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.DateTime;
            pointSeriesLabel1.LineVisible = true;
            this.xrChart1.SeriesTemplate.Label = pointSeriesLabel1;
            this.xrChart1.SeriesTemplate.ShowInLegend = false;
            this.xrChart1.SizeF = new System.Drawing.SizeF(981F, 445.125F);
            // 
            // temperatureDetailReport1
            // 
            this.temperatureDetailReport1.DataSetName = "TemperatureDetailReport";
            this.temperatureDetailReport1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 23.45834F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 34.375F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrControlStyle1
            // 
            this.xrControlStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xrControlStyle1.Name = "xrControlStyle1";
            this.xrControlStyle1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrControlStyle1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrControlStyle2
            // 
            this.xrControlStyle2.Name = "xrControlStyle2";
            this.xrControlStyle2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrControlStyle2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.datereport,
            this.zone,
            this.location,
            this.xrLabel15,
            this.xrLabel14,
            this.xrLabel9,
            this.xrPanel1,
            this.titre,
            this.xrLabel8,
            this.User,
            this.xrChart1});
            this.ReportHeader.HeightF = 590.2499F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // datereport
            // 
            this.datereport.BackColor = System.Drawing.Color.Empty;
            this.datereport.BorderColor = System.Drawing.Color.Empty;
            this.datereport.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.datereport.LocationFloat = new DevExpress.Utils.PointFloat(107.875F, 104.4166F);
            this.datereport.Name = "datereport";
            this.datereport.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.datereport.SizeF = new System.Drawing.SizeF(99.08337F, 21.95834F);
            this.datereport.StylePriority.UseBackColor = false;
            this.datereport.StylePriority.UseBorderColor = false;
            this.datereport.StylePriority.UseBorders = false;
            // 
            // zone
            // 
            this.zone.BackColor = System.Drawing.Color.Empty;
            this.zone.BorderColor = System.Drawing.Color.Empty;
            this.zone.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.zone.LocationFloat = new DevExpress.Utils.PointFloat(107.875F, 82.45834F);
            this.zone.Name = "zone";
            this.zone.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.zone.SizeF = new System.Drawing.SizeF(99.08337F, 21.95834F);
            this.zone.StylePriority.UseBackColor = false;
            this.zone.StylePriority.UseBorderColor = false;
            this.zone.StylePriority.UseBorders = false;
            // 
            // location
            // 
            this.location.BackColor = System.Drawing.Color.Empty;
            this.location.BorderColor = System.Drawing.Color.Empty;
            this.location.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.location.LocationFloat = new DevExpress.Utils.PointFloat(107.875F, 60.49998F);
            this.location.Name = "location";
            this.location.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.location.SizeF = new System.Drawing.SizeF(99.08337F, 21.95834F);
            this.location.StylePriority.UseBackColor = false;
            this.location.StylePriority.UseBorderColor = false;
            this.location.StylePriority.UseBorders = false;
            // 
            // xrLabel15
            // 
            this.xrLabel15.BackColor = System.Drawing.Color.Empty;
            this.xrLabel15.BorderColor = System.Drawing.Color.Empty;
            this.xrLabel15.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 82.45834F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(97.87503F, 21.95834F);
            this.xrLabel15.StylePriority.UseBackColor = false;
            this.xrLabel15.StylePriority.UseBorderColor = false;
            this.xrLabel15.StylePriority.UseBorders = false;
            this.xrLabel15.Text = "Zone :";
            // 
            // xrLabel14
            // 
            this.xrLabel14.BackColor = System.Drawing.Color.Empty;
            this.xrLabel14.BorderColor = System.Drawing.Color.Empty;
            this.xrLabel14.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 60.49998F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(97.87503F, 21.95834F);
            this.xrLabel14.StylePriority.UseBackColor = false;
            this.xrLabel14.StylePriority.UseBorderColor = false;
            this.xrLabel14.StylePriority.UseBorders = false;
            this.xrLabel14.Text = "Location :";
            // 
            // xrLabel9
            // 
            this.xrLabel9.BackColor = System.Drawing.Color.Empty;
            this.xrLabel9.BorderColor = System.Drawing.Color.Empty;
            this.xrLabel9.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 104.4166F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(97.87503F, 21.95834F);
            this.xrLabel9.StylePriority.UseBackColor = false;
            this.xrLabel9.StylePriority.UseBorderColor = false;
            this.xrLabel9.StylePriority.UseBorders = false;
            this.xrLabel9.Text = "Date de rapport :";
            // 
            // xrPanel1
            // 
            this.xrPanel1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.datefin,
            this.basse,
            this.xrLabel6,
            this.xrLabel5,
            this.xrLine2,
            this.datedebut,
            this.haute,
            this.xrLabel11,
            this.xrLabel10,
            this.xrLine1,
            this.min,
            this.max,
            this.numerosonde,
            this.xrLabel4,
            this.xrLabel3,
            this.xrLabel2});
            this.xrPanel1.LocationFloat = new DevExpress.Utils.PointFloat(367.7083F, 38.54167F);
            this.xrPanel1.Name = "xrPanel1";
            this.xrPanel1.SizeF = new System.Drawing.SizeF(613.2917F, 94.79163F);
            this.xrPanel1.StyleName = "xrControlStyle3";
            // 
            // datedebut
            // 
            this.datedebut.BackColor = System.Drawing.Color.Empty;
            this.datedebut.BorderColor = System.Drawing.Color.Empty;
            this.datedebut.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.datedebut.LocationFloat = new DevExpress.Utils.PointFloat(324.5417F, 31.70827F);
            this.datedebut.Name = "datedebut";
            this.datedebut.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.datedebut.SizeF = new System.Drawing.SizeF(99.08337F, 21.95834F);
            this.datedebut.StylePriority.UseBackColor = false;
            this.datedebut.StylePriority.UseBorderColor = false;
            this.datedebut.StylePriority.UseBorders = false;
            // 
            // haute
            // 
            this.haute.BackColor = System.Drawing.Color.Empty;
            this.haute.BorderColor = System.Drawing.Color.Empty;
            this.haute.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.haute.LocationFloat = new DevExpress.Utils.PointFloat(560.2919F, 53.91668F);
            this.haute.Name = "haute";
            this.haute.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.haute.SizeF = new System.Drawing.SizeF(42.99988F, 21.95834F);
            this.haute.StylePriority.UseBackColor = false;
            this.haute.StylePriority.UseBorderColor = false;
            this.haute.StylePriority.UseBorders = false;
            // 
            // xrLabel11
            // 
            this.xrLabel11.BackColor = System.Drawing.Color.Empty;
            this.xrLabel11.BorderColor = System.Drawing.Color.Empty;
            this.xrLabel11.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(250.6249F, 53.66661F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(73.91681F, 21.95834F);
            this.xrLabel11.StylePriority.UseBackColor = false;
            this.xrLabel11.StylePriority.UseBorderColor = false;
            this.xrLabel11.StylePriority.UseBorders = false;
            this.xrLabel11.Text = "Date fin :";
            // 
            // xrLabel10
            // 
            this.xrLabel10.BackColor = System.Drawing.Color.Empty;
            this.xrLabel10.BorderColor = System.Drawing.Color.Empty;
            this.xrLabel10.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(250.6249F, 31.70827F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(73.91681F, 21.95834F);
            this.xrLabel10.StylePriority.UseBackColor = false;
            this.xrLabel10.StylePriority.UseBorderColor = false;
            this.xrLabel10.StylePriority.UseBorders = false;
            this.xrLabel10.Text = "Date début :";
            // 
            // xrLine1
            // 
            this.xrLine1.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash;
            this.xrLine1.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.xrLine1.BorderWidth = 1;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(245F, 10F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(2F, 65.62497F);
            this.xrLine1.StylePriority.UseBorderDashStyle = false;
            this.xrLine1.StylePriority.UseBorders = false;
            this.xrLine1.StylePriority.UseBorderWidth = false;
            // 
            // min
            // 
            this.min.BackColor = System.Drawing.Color.Empty;
            this.min.BorderColor = System.Drawing.Color.Empty;
            this.min.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.min.LocationFloat = new DevExpress.Utils.PointFloat(90.16666F, 53.91669F);
            this.min.Name = "min";
            this.min.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.min.SizeF = new System.Drawing.SizeF(143.1667F, 21.95834F);
            this.min.StylePriority.UseBackColor = false;
            this.min.StylePriority.UseBorderColor = false;
            this.min.StylePriority.UseBorders = false;
            // 
            // max
            // 
            this.max.BackColor = System.Drawing.Color.Empty;
            this.max.BorderColor = System.Drawing.Color.Empty;
            this.max.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.max.LocationFloat = new DevExpress.Utils.PointFloat(90.16666F, 31.95834F);
            this.max.Name = "max";
            this.max.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.max.SizeF = new System.Drawing.SizeF(143.1667F, 21.95834F);
            this.max.StylePriority.UseBackColor = false;
            this.max.StylePriority.UseBorderColor = false;
            this.max.StylePriority.UseBorders = false;
            // 
            // numerosonde
            // 
            this.numerosonde.BackColor = System.Drawing.Color.Empty;
            this.numerosonde.BorderColor = System.Drawing.Color.Empty;
            this.numerosonde.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.numerosonde.LocationFloat = new DevExpress.Utils.PointFloat(90.16666F, 9.999992F);
            this.numerosonde.Name = "numerosonde";
            this.numerosonde.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.numerosonde.SizeF = new System.Drawing.SizeF(143.1667F, 21.95834F);
            this.numerosonde.StylePriority.UseBackColor = false;
            this.numerosonde.StylePriority.UseBorderColor = false;
            this.numerosonde.StylePriority.UseBorders = false;
            // 
            // xrLabel4
            // 
            this.xrLabel4.BackColor = System.Drawing.Color.Empty;
            this.xrLabel4.BorderColor = System.Drawing.Color.Empty;
            this.xrLabel4.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(9.999974F, 53.91668F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(80.16669F, 21.95834F);
            this.xrLabel4.StylePriority.UseBackColor = false;
            this.xrLabel4.StylePriority.UseBorderColor = false;
            this.xrLabel4.StylePriority.UseBorders = false;
            this.xrLabel4.Text = "Valeur Min :";
            // 
            // xrLabel3
            // 
            this.xrLabel3.BackColor = System.Drawing.Color.Empty;
            this.xrLabel3.BorderColor = System.Drawing.Color.Empty;
            this.xrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(9.999974F, 31.95836F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(80.16669F, 21.95834F);
            this.xrLabel3.StylePriority.UseBackColor = false;
            this.xrLabel3.StylePriority.UseBorderColor = false;
            this.xrLabel3.StylePriority.UseBorders = false;
            this.xrLabel3.Text = "Valeur Max :";
            // 
            // xrLabel2
            // 
            this.xrLabel2.BackColor = System.Drawing.Color.Empty;
            this.xrLabel2.BorderColor = System.Drawing.Color.Empty;
            this.xrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(9.999974F, 10.00001F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(69.75003F, 21.95834F);
            this.xrLabel2.StylePriority.UseBackColor = false;
            this.xrLabel2.StylePriority.UseBorderColor = false;
            this.xrLabel2.StylePriority.UseBorders = false;
            this.xrLabel2.Text = "Sonde :";
            // 
            // titre
            // 
            this.titre.Font = new System.Drawing.Font("Times New Roman", 16F);
            this.titre.LocationFloat = new DevExpress.Utils.PointFloat(367.7083F, 0F);
            this.titre.Name = "titre";
            this.titre.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.titre.SizeF = new System.Drawing.SizeF(294.7917F, 27.16667F);
            this.titre.StylePriority.UseFont = false;
            this.titre.StylePriority.UseTextAlignment = false;
            this.titre.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel8
            // 
            this.xrLabel8.BackColor = System.Drawing.Color.Empty;
            this.xrLabel8.BorderColor = System.Drawing.Color.Empty;
            this.xrLabel8.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 38.54167F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(97.87503F, 21.95834F);
            this.xrLabel8.StylePriority.UseBackColor = false;
            this.xrLabel8.StylePriority.UseBorderColor = false;
            this.xrLabel8.StylePriority.UseBorders = false;
            this.xrLabel8.Text = "Nom utilisateur :";
            // 
            // User
            // 
            this.User.BackColor = System.Drawing.Color.Empty;
            this.User.BorderColor = System.Drawing.Color.Empty;
            this.User.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.User.LocationFloat = new DevExpress.Utils.PointFloat(107.875F, 38.54163F);
            this.User.Name = "User";
            this.User.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.User.SizeF = new System.Drawing.SizeF(259.8333F, 21.95834F);
            this.User.StylePriority.UseBackColor = false;
            this.User.StylePriority.UseBorderColor = false;
            this.User.StylePriority.UseBorders = false;
            // 
            // xrControlStyle3
            // 
            this.xrControlStyle3.BackColor = System.Drawing.Color.White;
            this.xrControlStyle3.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash;
            this.xrControlStyle3.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrControlStyle3.BorderWidth = 1;
            this.xrControlStyle3.Name = "xrControlStyle3";
            // 
            // valuesTableAdapter
            // 
            this.valuesTableAdapter.ClearBeforeFill = true;
            // 
            // xrLine2
            // 
            this.xrLine2.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash;
            this.xrLine2.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.xrLine2.BorderWidth = 1;
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(446.875F, 10.25008F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(2F, 65.62497F);
            this.xrLine2.StylePriority.UseBorderDashStyle = false;
            this.xrLine2.StylePriority.UseBorders = false;
            this.xrLine2.StylePriority.UseBorderWidth = false;
            // 
            // xrLabel5
            // 
            this.xrLabel5.BackColor = System.Drawing.Color.Empty;
            this.xrLabel5.BorderColor = System.Drawing.Color.Empty;
            this.xrLabel5.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(469.7084F, 53.66662F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(90.5835F, 21.95834F);
            this.xrLabel5.StylePriority.UseBackColor = false;
            this.xrLabel5.StylePriority.UseBorderColor = false;
            this.xrLabel5.StylePriority.UseBorders = false;
            this.xrLabel5.Text = "Alarme haute :";
            // 
            // xrLabel6
            // 
            this.xrLabel6.BackColor = System.Drawing.Color.Empty;
            this.xrLabel6.BorderColor = System.Drawing.Color.Empty;
            this.xrLabel6.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(469.7084F, 31.70827F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(90.58337F, 21.95834F);
            this.xrLabel6.StylePriority.UseBackColor = false;
            this.xrLabel6.StylePriority.UseBorderColor = false;
            this.xrLabel6.StylePriority.UseBorders = false;
            this.xrLabel6.Text = "Alarme basse :";
            // 
            // basse
            // 
            this.basse.BackColor = System.Drawing.Color.Empty;
            this.basse.BorderColor = System.Drawing.Color.Empty;
            this.basse.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.basse.LocationFloat = new DevExpress.Utils.PointFloat(563.4169F, 31.70827F);
            this.basse.Name = "basse";
            this.basse.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.basse.SizeF = new System.Drawing.SizeF(39.87488F, 21.95834F);
            this.basse.StylePriority.UseBackColor = false;
            this.basse.StylePriority.UseBorderColor = false;
            this.basse.StylePriority.UseBorders = false;
            // 
            // datefin
            // 
            this.datefin.BackColor = System.Drawing.Color.Empty;
            this.datefin.BorderColor = System.Drawing.Color.Empty;
            this.datefin.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.datefin.LocationFloat = new DevExpress.Utils.PointFloat(324.5417F, 53.66661F);
            this.datefin.Name = "datefin";
            this.datefin.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.datefin.SizeF = new System.Drawing.SizeF(99.08331F, 21.95834F);
            this.datefin.StylePriority.UseBackColor = false;
            this.datefin.StylePriority.UseBorderColor = false;
            this.datefin.StylePriority.UseBorders = false;
            // 
            // XtraReport2
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader});
            this.DataAdapter = this.valuesTableAdapter;
            this.DataMember = "Values";
            this.DataSource = this.temperatureDetailReport1;
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(56, 53, 23, 34);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.xrControlStyle1,
            this.xrControlStyle2,
            this.xrControlStyle3});
            this.Version = "13.1";
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrChart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.temperatureDetailReport1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRControlStyle xrControlStyle1;
        private DevExpress.XtraReports.UI.XRControlStyle xrControlStyle2;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel titre;
        private DevExpress.XtraReports.UI.XRPanel xrPanel1;
        private DevExpress.XtraReports.UI.XRLabel min;
        private DevExpress.XtraReports.UI.XRLabel max;
        private DevExpress.XtraReports.UI.XRLabel numerosonde;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRControlStyle xrControlStyle3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.XRLabel datedebut;
        private DevExpress.XtraReports.UI.XRLabel haute;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel xrLabel15;
        private DevExpress.XtraReports.UI.XRLabel xrLabel14;
        private DevExpress.XtraReports.UI.XRLabel datereport;
        private DevExpress.XtraReports.UI.XRLabel zone;
        private DevExpress.XtraReports.UI.XRLabel location;
        private DevExpress.XtraReports.UI.XRLabel User;
        private Data.TemperatureDetailReport temperatureDetailReport1;
        private Data.TemperatureDetailReportTableAdapters.ValuesTableAdapter valuesTableAdapter;
        private DevExpress.XtraReports.UI.XRLabel xrLabel10;
        public DevExpress.XtraReports.UI.XRChart xrChart1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLine xrLine2;
        private DevExpress.XtraReports.UI.XRLabel datefin;
        private DevExpress.XtraReports.UI.XRLabel basse;
    }
}
