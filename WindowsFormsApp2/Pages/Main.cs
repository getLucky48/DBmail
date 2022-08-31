using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.KernelObject;
using WindowsFormsApp2.Pages.Edit;

namespace WindowsFormsApp2.Pages
{
    public partial class Main : Form
    {

        public static string userid = "postgres";

        private int idx = 0;
        private DataGridView gridView = null;

        public Main()
        {

            InitializeComponent();

            if (userid.Equals("admin"))
            {

                ((Control)tabControl1.TabPages["tabPage1"]).Parent = null;
                ((Control)tabControl1.TabPages["tabPage2"]).Parent = null;
                ((Control)tabControl1.TabPages["tabPage4"]).Parent = null;

                idx = 2;

            }
            else if (userid.Equals("employee"))
            {

                ((Control)tabControl1.TabPages["tabPage3"]).Parent = null;
                ((Control)tabControl1.TabPages["tabPage4"]).Parent = null;

                idx = 0;

            }
            else
            {

                idx = 3;

            }

            tabControl1.SelectedIndex = idx;

            SelectGridView();
            LoadData();

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            idx = ((TabControl)sender).SelectedTab.TabIndex;

            SelectGridView();
            LoadData();

        }

        private void SelectGridView()
        {

            if (idx == 0) gridView = gridTypePackage;
            else if (idx == 1) gridView = gridPackage;
            else if (idx == 2) gridView = gridEmployee;
            else if (idx == 3) gridView = new DataGridView();
            else throw new Exception("Не указан грид для выборки данных");

        }

        private void LoadData()
        {

            if (idx == 0)
                gridView.DataSource = KernelObject.KernelObject.GetList<TypePackage>();
            else if (idx == 1)
                gridView.DataSource = KernelObject.KernelObject.GetList<Package>();
            else if (idx == 2)
                gridView.DataSource = KernelObject.KernelObject.GetList<Employee>();
            else if (idx == 3)
                gridView.DataSource = new List<string>(); 
            else
                throw new Exception("Не указан объект для выборки данных");

            foreach(DataGridViewColumn col in gridView.Columns)
            {

                if (col.Name.Equals("id"))
                    col.Visible = false; 

                if (col.Name.Equals("tableName"))
                    col.Visible = false;

                if (col.Name.EndsWith("_id"))
                    col.Visible = false;

            }

            if (idx == 3)
            {

                btnCreate.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;

            }
            else
            {

                btnCreate.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;

            }

        }

        private void OpenEditWindow(string id = "")
        {

            if (idx == 0)
            {

                _edit_TypePackage edit = new _edit_TypePackage();

                if (!string.IsNullOrEmpty(id))
                    edit = new _edit_TypePackage(Guid.Parse(id));

                edit.ShowDialog();
                LoadData();

            }
            else if (idx == 1)
            {

                _edit_Package edit = new _edit_Package();

                if (!string.IsNullOrEmpty(id))
                    edit = new _edit_Package(Guid.Parse(id));

                edit.ShowDialog();
                LoadData();

            }
            else if (idx == 2)
            {

                _edit_Employee edit = new _edit_Employee();

                if (!string.IsNullOrEmpty(id))
                    edit = new _edit_Employee(Guid.Parse(id));

                edit.ShowDialog();
                LoadData();

            }
            else if (idx == 3) { }
            else throw new Exception("Не указан грид для выборки данных");

        }

        private KernelObject.KernelObject GetKernelObjectByIdx(Guid guid)
        {

            if (idx == 0)
                return KernelObject.KernelObject.GetByID<TypePackage>(guid);
            else if (idx == 1)
                return KernelObject.KernelObject.GetByID<Package>(guid);
            else if (idx == 2)
                return KernelObject.KernelObject.GetByID<Employee>(guid);
            else if (idx == 3) { }

            return null;

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

            OpenEditWindow();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if(gridView.CurrentRow == null)
            {

                MessageBox.Show("Не выбран объект редактирования");

                return;

            }

            string id = gridView.CurrentRow.Cells["id"].Value.ToString();

            OpenEditWindow(id);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (gridView.CurrentRow == null)
            {

                MessageBox.Show("Не выбран объект редактирования");

                return;

            }


            string id = gridView.CurrentRow.Cells["id"].Value.ToString();

            KernelObject.KernelObject obj = GetKernelObjectByIdx(Guid.Parse(id));

            if (obj != null)
                obj.Delete();

            LoadData();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string query = $@"

                select
	                type_package.name,
	                package.sender,
	                package.start_point,
	                package.recipient,
	                package.finish_point,
	                employee.surname,
	                case
		                when weight > 0 and weight < 0.5
		                then 'до 500 г.'
		                when weight >= 0.5 and weight < 1
		                then 'от 500 г. до 1 кг.'
		                when weight >= 1 and weight < 1.5
		                then 'от 1 до 1.5 кг.'
		                else 'более 1.5 кг.'
	                end as weight
                from package
                join type_package
                on package.type_package_id = type_package.id
                join inventory
                on inventory.package_id = package.id
                join package_inventory
                on package_inventory.inventory_id = inventory.id
                join employee
                on employee_id = employee.id

            ";

            NpgsqlConnection connection = DBUtils.getConnection();

            connection.Open();

            NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

            NpgsqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);

            gridSql.DataSource = dt;

            connection.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            string query = $@"

                select * from all_package

            ";

            NpgsqlConnection connection = DBUtils.getConnection();

            connection.Open();

            NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

            NpgsqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);

            gridSql.DataSource = dt;

            connection.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            string query = $@"

                select
                    inventory.sender,
	                    (select sum(pay)
	                    from inventory_container
	                    where inventory.id = inventory_container.inventory_id) as subquery
                    from inventory

            ";

            NpgsqlConnection connection = DBUtils.getConnection();

            connection.Open();

            NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

            NpgsqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);

            gridSql.DataSource = dt;

            connection.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {

            string query = $@"

                select
                    start_point,
                    finish_point
                from
                    package
                where
                    start_point = any(select
					                  start_point
					                  from
					                  package
					                  where
					                  substring(start_point, 1, 10) = 'г. Саратов');

            ";

            NpgsqlConnection connection = DBUtils.getConnection();

            connection.Open();

            NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

            NpgsqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);

            gridSql.DataSource = dt;

            connection.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {

            string query = $@"

                select
                type_package.name,
                count(*) as count_package
                from package
                join type_package
                on package.type_package_id = type_package.id
                group by type_package.name
                having count(*) > 320

            ";

            NpgsqlConnection connection = DBUtils.getConnection();

            connection.Open();

            NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

            NpgsqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);

            gridSql.DataSource = dt;

            connection.Close();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string query = "select average_pay_cursor()";

            NpgsqlConnection connection = DBUtils.getConnection();

            connection.Open();

            NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

            NpgsqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);

            gridSql.DataSource = dt;

            connection.Close();

        }

        private void button7_Click(object sender, EventArgs e)
        {

            string query = "select count_object_in_inventory_scalar_func((select id from inventory limit 1))";

            NpgsqlConnection connection = DBUtils.getConnection();

            connection.Open();

            NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

            NpgsqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);

            gridSql.DataSource = dt;

            connection.Close();

        }

        private void button8_Click(object sender, EventArgs e)
        {

            string query = "select search_by_finish_point_vector_func((select finish_point from package limit 1));";

            NpgsqlConnection connection = DBUtils.getConnection();

            connection.Open();

            NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

            NpgsqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);

            gridSql.DataSource = dt;

            connection.Close();
        
        }
    
    }

}
