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

namespace WindowsFormsApp2.Pages.Edit
{
    public partial class _edit_Inventory : Form
    {

        private Inventory obj = null;
        private List<InventoryContainer> listInventory = new List<InventoryContainer>();

        public _edit_Inventory()
        {

            throw new Exception("Не указаны ИД");
            InitializeComponent();

        }

        public _edit_Inventory(Guid packageId, int mode = 0)
        {

            InitializeComponent();

            int sheetNum = KernelObject.KernelObject.GetList<Inventory>().Where(t => t.package_id == packageId).Count() + 1;

            this.obj = new Inventory();
            this.obj.package_id = packageId;
            this.obj.sheet = sheetNum;

            tBoxSheet.Text = (sheetNum).ToString();

            RefreshGrid();

        }

        public _edit_Inventory(Guid guid)
        {

            InitializeComponent();

            this.obj = KernelObject.KernelObject.GetByID<Inventory>(guid);

            tBoxSender.Text = this.obj.sender;

            if (this.obj.sheet != 0)
                tBoxSheet.Text = this.obj.sheet.ToString();

            RefreshGrid();

        }

        private void RefreshGrid()
        {

            listInventory = KernelObject.KernelObject.GetList<InventoryContainer>().Where(t => t.inventory_id == this.obj.id).ToList();

            gridContainer.DataSource = listInventory;

            foreach (DataGridViewColumn col in gridContainer.Columns)
            {

                if (col.Name.Equals("id"))
                    col.Visible = false;

                if (col.Name.Equals("tableName"))
                    col.Visible = false;

                if (col.Name.EndsWith("_id"))
                    col.Visible = false;

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.obj.sender = tBoxSender.Text;
            this.obj.sheet = int.Parse(tBoxSheet.Text);

            this.obj.Save();

            this.Close();

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

            this.obj.Save();

            _edit_InventoryContainer _edit = new _edit_InventoryContainer(this.obj.id);
            _edit.ShowDialog();

            RefreshGrid();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            Guid id = listInventory[gridContainer.CurrentRow.Index].id;

            this.obj.Save();

            _edit_InventoryContainer _edit = new _edit_InventoryContainer(id, 0);
            _edit.ShowDialog();

            RefreshGrid();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            listInventory[gridContainer.CurrentRow.Index].Delete();
            RefreshGrid();

        }

    }

}
