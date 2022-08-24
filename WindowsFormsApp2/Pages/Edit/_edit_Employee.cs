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
    public partial class _edit_Employee : Form
    {

        private Employee obj;

        public _edit_Employee()
        {

            InitializeComponent();

            obj = new Employee();

        }

        public _edit_Employee(Guid id)
        {

            InitializeComponent();

            obj = KernelObject.KernelObject.GetByID<Employee>(id);

            tBoxFio.Text = obj.surname;
            tBoxPhone.Text = obj.phone_number;

        }


        private void button1_Click(object sender, EventArgs e)
        {

            this.obj.surname = tBoxFio.Text;
            this.obj.phone_number = tBoxPhone.Text;

            this.obj.Save();
            this.Close();

        }
    }

}
