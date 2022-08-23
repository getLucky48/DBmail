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
    public partial class _edit_TypePackage : Form
    {

        private TypePackage obj = null;

        public _edit_TypePackage()
        {

            InitializeComponent();

            obj = new TypePackage();

        }

        public _edit_TypePackage(Guid guid)
        {

            InitializeComponent();

            this.obj = KernelObject.KernelObject.GetByID<TypePackage>(guid);

            tBoxName.Text = this.obj.name;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.obj.name = tBoxName.Text;
            this.obj.Save();
            this.Close();

        }

    }

}
