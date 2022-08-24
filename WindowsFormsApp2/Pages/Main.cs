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

        private int idx = 0;
        private DataGridView gridView = null;

        public Main()
        {

            InitializeComponent();

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
            else if (idx == 1) {

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

            return null;

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

            OpenEditWindow();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            try
            {

                string id = gridView.CurrentRow.Cells["id"].Value.ToString();

                OpenEditWindow(id);

            }
            catch(NullReferenceException)
            {
                MessageBox.Show("Не выбран объект редактирования");
                return;
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            try
            {

                string id = gridView.CurrentRow.Cells["id"].Value.ToString();

                KernelObject.KernelObject obj = GetKernelObjectByIdx(Guid.Parse(id));

                if (obj != null)
                    obj.Delete();

                LoadData();

            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Не выбран объект для удаления");
                return;
            }

        }
    }

}
