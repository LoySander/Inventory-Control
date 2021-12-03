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
        
            loginPresenter = new LoginPresenter(this,new AuthorizationService(),new ClientService());
            //presenter.Start();
        }
        //пока работаем с одним пользователем
        public string ClientName { get { return Customer.SelectedItem.ToString(); } set {  } }

        public string Username { get { return textLoginBox.Text; } }
        public string Password { get { return textPasswordBox.Text; } }

        private void Customer_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SetName(Customer.SelectedItem.ToString());
            //string selectedState = Customer.SelectedItem.ToString();
            InputClientButton.Enabled = true;
        }

        public void AddCustomer(string clientName)
        {
            Customer.Items.Add(clientName);
        }
      

        private void InputClientButton_Click(object sender, EventArgs e)
        {
            loginPresenter.ClientLogin();
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

         public new void Show()
        {
            MainForm z = new MainForm(this);
            z.Show();
            this.Hide();
        }

        private void AddClient_Click(object sender, EventArgs e)
        {
            //Customer.Items.Add(name_customer.Text);
            loginPresenter.AddClient(name_customer.Text);
        }

        private void InputEmployee_Click(object sender, EventArgs e)
        {
            loginPresenter.Login();
        }
    }
}
