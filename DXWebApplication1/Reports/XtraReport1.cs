using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Web;
using System.Web.Mvc;
using DXWebApplication1.Models;
namespace DXWebApplication1.Reports
{
    public partial class XtraReport1 : DevExpress.XtraReports.UI.XtraReport
    {

        public XtraReport1(DetailReport detail)
        {
            
            InitializeComponent();
            User.NullValueText = detail.username;
            location.NullValueText = detail.location;
            zone.NullValueText = detail.zone;
            datereport.NullValueText = detail.datereport.ToString("yyyy/MM/dd");
            numerosonde.NullValueText = detail.numerosonde;
            max.NullValueText = detail.max.ToString();
            min.NullValueText = detail.min.ToString();
            datedebut.NullValueText = detail.datedebut.ToString("yyyy/MM/dd");
            datefin.NullValueText = detail.datefin.ToString("yyyy/MM/dd");
            valuesTableAdapter.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ModuleEquipementContext"].ConnectionString);


        }
       
        

        public void SetReportParameter(int EquipementID)
        {
           temperatureDetailReport1.Clear();
            valuesTableAdapter.Fill(temperatureDetailReport1.Values, EquipementID);
        }

    }
}
