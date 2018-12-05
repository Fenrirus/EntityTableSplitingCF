using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EntityTableSplitingCF
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
                GridView1.DataSource = Wszystkie();
            else
                GridView1.DataSource = Podstawowe();
            GridView1.DataBind();
        }
        private DataTable Wszystkie()
        {
            EmployeeDbContext db = new EmployeeDbContext();
            DataTable dt = new DataTable();
            List<Employee> emp = db.Employees.Include("EmployeeContacs").ToList();
            DataColumn[] dc ={ new DataColumn("EmployeeID"),
                                 new DataColumn("FirstName"),
                                 new DataColumn("LastName"),
                                 new DataColumn("Gender"),
                                 new DataColumn("Email"),
                                 new DataColumn("Mobile"),
                                 new DataColumn("LandLine") };
            dt.Columns.AddRange(dc);
            foreach (Employee employees in emp)
            {
                DataRow dr = dt.NewRow();
                dr["EmployeeID"] = employees.EmployeeID;
                dr["FirstName"] = employees.FirstName;
                dr["LastName"] = employees.LastName;
                dr["Gender"] = employees.Gender;
                dr["Email"] = employees.employeeContacs.Email;
                dr["Mobile"] = employees.employeeContacs.Mobile;
                dr["LandLine"] = employees.employeeContacs.LandLine;
                dt.Rows.Add(dr);
            }
            return dt;
        }
        private DataTable Podstawowe()
        {
            EmployeeDbContext db = new EmployeeDbContext();
            DataTable dt = new DataTable();
            List<Employee> emp = db.Employees.ToList();
            DataColumn[] dc ={ new DataColumn("EmployeeID"),
                                 new DataColumn("FirstName"),
                                 new DataColumn("LastName"),
                                 new DataColumn("Gender") };
            dt.Columns.AddRange(dc);
            foreach (Employee employees in emp)
            {
                DataRow dr = dt.NewRow();
                dr["EmployeeID"] = employees.EmployeeID;
                dr["FirstName"] = employees.FirstName;
                dr["LastName"] = employees.LastName;
                dr["Gender"] = employees.Gender;
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}