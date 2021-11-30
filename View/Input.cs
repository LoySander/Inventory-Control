using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presentation.Presenters;
using Presentation.Views;


namespace WarehouseAccountingSystem
{
    public partial class Input : Form, ILoginView
    {

        private LoginPresenter presenter;

        //string name = "";
        
        //public void SetName(string name)
        //{
        //    this.name = name;
        //}
        //public string GetName()
        //{
        //    return this.name;
        //}
        public Input()
        {
            InitializeComponent();
            presenter = new LoginPresenter(this);
            presenter.Start();
        }
        //пока работаем с одним пользователем
        public string ClientName { get { return Customer.SelectedItem.ToString(); } }

        public string Username { get { return textLoginBox.Text; } }
        public string Password { get { return textPasswordBox.Text; } }

        public bool PurchasingManager { get; set; }
        public bool AccountManager { get; set; }

        private void Customer_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SetName(Customer.SelectedItem.ToString());
            string selectedState = Customer.SelectedItem.ToString();
            button2.Enabled = true;
        }

        private void add_customer_Click(object sender, EventArgs e)
        {
            Customer.Items.Add(name_customer.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // обязательно изменить
            presenter.ClientLogin();
            Form1 z = new Form1(this);
            MessageBox.Show("Вы вошли в систему как " + ClientName);
            z.Show();
        }


        private void inputEmployee_Click(object sender, EventArgs e)
        {
            presenter.Login();
        }

        public void Error()
        {
            MessageBox.Show("Ошибка, проверьте логин или пароль");
        }

         public new void Show()
        {
            Form1 z = new Form1(this);
            z.Show();
        }

       
    }
}
