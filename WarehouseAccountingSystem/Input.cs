using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarehouseAccountingSystem
{
    public partial class Input : Form
    {
        string name = "";
        public void SetName(string name)
        {
            this.name = name;
        }
        public string GetName()
        {
            return this.name;
        }
        public Input()
        {
            InitializeComponent();

           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        

        private void Customer_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetName(Customer.SelectedItem.ToString());
            string selectedState = Customer.SelectedItem.ToString();
            button2.Enabled = true;
        }

        private void add_customer_Click(object sender, EventArgs e)
        {
            Customer.Items.Add(name_customer.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string selectedState = Customer.SelectedItem.ToString();
            Form1 z = new Form1(this);
            MessageBox.Show("Вы вошли в систему как " + selectedState);
            z.Show();
        }
    }
}
