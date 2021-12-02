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
using Model.Services;


namespace WarehouseAccountingSystem
{
    public partial class Input : Form, ILoginView
    {

        private LoginPresenter loginPresenter;

        public Input()
        {
            InitializeComponent();
            loginPresenter = new LoginPresenter(this,new AuthorizationService(),new AddClientService());
            //presenter.Start();
        }
        //пока работаем с одним пользователем
        public string ClientName { get { return name_customer.Text; } set {  } }

        public string Username { get { return textLoginBox.Text; } }
        public string Password { get { return textPasswordBox.Text; } }

        public bool PurchasingManager { get; set; }
        public bool AccountManager { get; set; }

        private void Customer_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SetName(Customer.SelectedItem.ToString());
            string selectedState = Customer.SelectedItem.ToString();
            InputClientButton.Enabled = true;
        }

        public void AddCustomer(string clientName)
        {
            Customer.Items.Add(clientName);
        }
        private void add_customer_Click(object sender, EventArgs e)
        {
            Customer.Items.Add(name_customer.Text);
            loginPresenter.AddClient();
        }

        private void InputClientButton_Click(object sender, EventArgs e)
        {
            loginPresenter.ClientLogin();
        }


        private void inputEmployee_Click(object sender, EventArgs e)
        {
            loginPresenter.Login();
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

         public new void Show()
        {
            Form1 z = new Form1(this);
            z.Show();
        }

        
    }
}
