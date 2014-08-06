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
    public partial class XtraReport3 : DevExpress.XtraReports.UI.XtraReport
    {


        public XtraReport3(DetailReport detail)
        {
            InitializeComponent();
            User.NullValueText = detail.username;
            datereport.NullValueText = detail.datereport.ToString("yyyy/MM/dd");
            nbalarme.NullValueText = detail.max.ToString();
            nonacquite.NullValueText = detail.min.ToString();

            alarmesTableAdapter.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ModuleEquipementContext"].ConnectionString);


        }

    }
}
