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
    public partial class _edit_InventoryContainer : Form
    {

        private InventoryContainer obj = null;

        public _edit_InventoryContainer()
        {
            InitializeComponent();
        }

        public _edit_InventoryContainer(Guid inventoryId)
        {

            InitializeComponent();

            this.obj = new InventoryContainer();
            this.obj.inventory_id = inventoryId;

        }

        public _edit_InventoryContainer(Guid id, int mode)
        {

            InitializeComponent();

            this.obj = KernelObject.KernelObject.GetByID<InventoryContainer>(id);

            tBoxName.Text = this.obj.name;
            tBoxCount.Text = this.obj.count.ToString();
            tBoxPay.Text = this.obj.pay.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.obj.name = tBoxName.Text;
            this.obj.count = int.Parse(tBoxCount.Text);
            this.obj.pay = float.Parse(tBoxPay.Text);

            this.obj.Save();

            this.Close();

        }
 
    }

}
