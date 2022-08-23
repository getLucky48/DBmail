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
    public partial class _edit_Package : Form
    {

        private Package obj = null;
        private List<TypePackage> typePackageList = new List<TypePackage>();
        private List<Inventory> InventoryList = new List<Inventory>();
        private List<InventoryContainer> inventoryContainerList = new List<InventoryContainer>();
        private Guid inventoryId = Guid.Empty;

        public _edit_Package()
        {

            InitializeComponent();

            this.obj = new Package();

            typePackageList = KernelObject.KernelObject.GetList<TypePackage>();

            comboTypePackage.DataSource = typePackageList.Select(t => t.name).ToList();
            comboTypePackage.SelectedIndex = 0;

            cBoxInventory.DataSource = InventoryList;
            
            RefreshComboBox();
            RefreshGrid();

        }

        public _edit_Package(Guid guid)
        {

            InitializeComponent();

            this.obj = KernelObject.KernelObject.GetByID<Package>(guid);

            tBoxSender.Text = this.obj.sender;
            tBoxStartPoint.Text = this.obj.start_point;
            tBoxRecipient.Text = this.obj.recipient;
            tBoxFinishPoint.Text = this.obj.finish_point;
            tBoxWeight.Text = this.obj.weight.ToString();
            tBoxPay.Text = this.obj.pay.ToString();
            tBoxStartPointIdx.Text = this.obj.start_point_index.ToString();
            tBoxFinishPointIdx.Text = this.obj.finish_point_index.ToString();

            typePackageList = KernelObject.KernelObject.GetList<TypePackage>();

            comboTypePackage.DataSource = typePackageList.Select(t => t.name).ToList();
            comboTypePackage.SelectedItem = typePackageList.Where(t => t.id == this.obj.type_package_id).Select(t => t.name).First();

            RefreshComboBox();
            RefreshGrid();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.obj.sender = tBoxSender.Text;
            this.obj.start_point = tBoxStartPoint.Text;
            this.obj.recipient = tBoxRecipient.Text;
            this.obj.finish_point = tBoxFinishPoint.Text;
            this.obj.weight = float.Parse(tBoxWeight.Text);
            this.obj.pay = float.Parse(tBoxPay.Text);
            this.obj.start_point_index = int.Parse(tBoxStartPointIdx.Text);
            this.obj.finish_point_index = int.Parse(tBoxFinishPointIdx.Text);

            this.obj.type_package_id = this.typePackageList[comboTypePackage.SelectedIndex].id;

            this.obj.Save();

            this.Close();

        }

        private void btnInventoryCreate_Click(object sender, EventArgs e)
        {

            this.obj.type_package_id = this.typePackageList[comboTypePackage.SelectedIndex].id;
            this.obj.Save();

            _edit_Inventory _edit = new _edit_Inventory(this.obj.id, 0);
            _edit.ShowDialog();

            RefreshComboBox();
            RefreshGrid();

        }

        private void RefreshComboBox()
        {

            InventoryList = KernelObject.KernelObject.GetList<Inventory>().Where(t => t.package_id == this.obj.id).ToList();
            cBoxInventory.DataSource = InventoryList.Select(t => t.sheet).ToList();

            if (cBoxInventory.Items.Count > 0)
                cBoxInventory.SelectedIndex = 0;

        }

        private void RefreshGrid()
        {

            inventoryContainerList = KernelObject.KernelObject.GetList<InventoryContainer>().Where(t => t.inventory_id == inventoryId).ToList();

            gridInventory.DataSource = inventoryContainerList;

            foreach (DataGridViewColumn col in gridInventory.Columns)
            {

                if (col.Name.Equals("id"))
                    col.Visible = false;

                if (col.Name.Equals("tableName"))
                    col.Visible = false;

                if (col.Name.EndsWith("_id"))
                    col.Visible = false;

            }

        }

        private void cBoxInventory_SelectedIndexChanged(object sender, EventArgs e)
        {

            int idx = cBoxInventory.SelectedIndex;

            inventoryId = InventoryList[idx].id;

            RefreshGrid();

        }

        private void btnInventoryEdit_Click(object sender, EventArgs e)
        {

            this.obj.type_package_id = this.typePackageList[comboTypePackage.SelectedIndex].id;
            this.obj.Save();

            _edit_Inventory _edit = new _edit_Inventory(inventoryId);
            _edit.ShowDialog();

            RefreshComboBox();
            RefreshGrid();

        }

        private void btnInventoryDelete_Click(object sender, EventArgs e)
        {

            KernelObject.KernelObject.GetByID<Inventory>(inventoryId).Delete();

            RefreshComboBox();
            RefreshGrid();

        }

    }

}
