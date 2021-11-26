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
        public bool PurchasingManager { get; set; } 
        public bool AccountManager { get; set; }
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


        private void inputEmployee_Click(object sender, EventArgs e)
        {
            if(textPasswordBox.Text.ToString() == "123" && textLoginBox.Text.ToString() == "PM")
            {
                PurchasingManager = true;
                Form1 z = new Form1(this);
                z.Show();
            }

            else if(textPasswordBox.Text.ToString() == "321" && textLoginBox.Text.ToString() == "AM")
            {
                AccountManager = true;
                Form1 z = new Form1(this);
                z.Show();
            }
            else 
            { 
                MessageBox.Show("Ошибка, проверьте логин или пароль"); 
            }

        }
    }
}
