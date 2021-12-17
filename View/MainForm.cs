using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using Presentation.Common;
using Presentation.Presenters;
using Presentation.Views;
using Services;


namespace WarehouseAccountingSystem
{
    public partial class MainForm : Form, IMainView
    {
       
       private MainPresenter presenter;
       public List<StorageProduct> Items3 { get; set; }
       public List<Order> Orders { get; set; }
       public string ClientName { get; set; }

       public UserType type;
       public string Heading { get; set; }
       private Form inputWindow;

        public MainForm(Input inputWindow)
        {
            InitializeComponent();
            this.inputWindow = inputWindow;
            presenter = new MainPresenter(this, new AuthorizationService());
            type = presenter.GetRoles();
            openFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            SetWindowFromRole();
        }
    
        // здесь происходит установка ролей
        public void SetWindowFromRole()
        {
            if (type == UserType.PurchasingManager)
            {
                // нужно с маленькой буквы прописать
                DeleviryToolStripMenuItem.Enabled = false;
                BidToolStripMenuItem.Enabled = false;
                ProfitToolStripMenuItem.Enabled = false;
                EditingToolStripMenuItem.Enabled = false;
                сatalogToolStripMenuItem.Enabled = false;
                MyOrdersToolStripMenuItem.Enabled = false;
                PayButton.Enabled = false;
                groupBox1.Hide();
                CatalogLabel.Text = " ";
            }
            else if (type == UserType.AccountManager)
            {
                ProfitToolStripMenuItem.Enabled = false;
                BidToolStripMenuItem.Enabled = true;
                DeleviryToolStripMenuItem.Enabled = false;
                OrderProviderToolStripMenuItem.Enabled = false;
                groupBox1.Hide();
                CatalogLabel.Text = " ";
            }

            else if (type == UserType.Client)
            {
                ProfitToolStripMenuItem.Enabled = false;
                DeleviryToolStripMenuItem.Enabled = false;
                OrderProviderToolStripMenuItem.Enabled = false;
                storageToolStripMenuItem.Enabled = false;
                BidToolStripMenuItem.Enabled = false;
            }

            else if (type == UserType.Storekeeper)
            {
                ProfitToolStripMenuItem.Enabled = false;
                //DeleviryToolStripMenuItem.Enabled = false;
                OrderProviderToolStripMenuItem.Enabled = false;
                BidToolStripMenuItem.Enabled = false;
                сatalogToolStripMenuItem.Enabled = false;
                EditingToolStripMenuItem.Enabled = false;
                DeleviryToolStripMenuItem.Enabled = false;
                groupBox1.Hide();
                CatalogLabel.Text = " ";
            }
            else if (type == UserType.Booker)
            {
                DeleviryToolStripMenuItem.Enabled = false;
                OrderProviderToolStripMenuItem.Enabled = false;
                EditingToolStripMenuItem.Enabled = false;
                BidToolStripMenuItem.Enabled = false;
                ProfitToolStripMenuItem.Enabled = true;
                storageToolStripMenuItem.Enabled = false;
                сatalogToolStripMenuItem.Enabled = false;
                groupBox1.Hide();
                CatalogLabel.Text = " ";
            }
            else
            {
                DeleviryToolStripMenuItem.Enabled = true;
                RequestToolStripMenuItem.Enabled = false;
                storageToolStripMenuItem.Enabled = false;
                сatalogToolStripMenuItem.Enabled = false;
                groupBox1.Hide();
                CatalogLabel.Text = " ";
            }

        }
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowMessage("Номер телефона для связи: +375 228 1337");
        }
    
        public void ExitCatalog()
        {
            MainPanel.Hide();
            CatalogLabel.Text = "";
        }
        
      
        private void Form1_Load(object sender, EventArgs e)
        {
            //dataGridView4.DataSource = Orders;
           myOrderClientView.DataSource = Orders;
        }
        private void CheckCatalog_Click(object sender, EventArgs e)
        {
            if (DeliverPanel.Visible || MyOrderPanel.Visible || BidPanel.Visible || ProfitPanel.Visible || SortButton.Visible || transferToCourierButton.Visible || consignmentPanel.Visible)
            {
                DeliverPanel.Hide();
                MyOrderPanel.Hide();
                BidPanel.Hide();
                ProfitPanel.Hide();
                SortButton.Hide();
                transferToCourierButton.Hide();
                consignmentPanel.Hide();
            }
            CatalogLabel.Text = "Каталог товаров";
            if (!MainPanel.Visible && !groupBox1.Visible)
            {
                MainPanel.Show();
                groupBox1.Show();
                productGridView1.Show();
            }
        }

        private void ExitFromCatalog_Click(object sender, EventArgs e)
        {
            presenter.CloseCatalog();
        }

        private void СheckStorage_Click(object sender, EventArgs e)
        {

            if (DeliverPanel.Visible || MyOrderPanel.Visible || BidPanel.Visible || ProfitPanel.Visible)
            {
                DeliverPanel.Hide();
                MyOrderPanel.Hide();
                BidPanel.Hide();
                ProfitPanel.Hide();
            }

            if (type == UserType.Storekeeper)
            {
                consignmentPanel.Show();
            }
            groupBox1.Show();
            MainPanel.Show();
            productGridView1.Show();
            SortButton.Show();
            transferToCourierButton.Show();
            Order.Show();
            OrderButton.Show();
            CatalogLabel.Text = "Товары на складе";
            cartGridView.Show();
            productGridView1.DataSource = presenter.GetStorage(getProductType());
        }
     
        private void AddProduct_Click(object sender, EventArgs e)
        {

            long id = long.Parse(IdProductBox.Text);
            if (type == UserType.Storekeeper)
            {

                // consignmentDataView.DataSource = new List<StorageProduct>(presenter.AddToCart(id));
                consignmentDataView.DataSource = new List<Product>(presenter.AddToCart(id));
            }
            else
            {
                //CartGridView.DataSource = new List<StorageProduct>(presenter.AddToCart(id));
                cartGridView.DataSource = new List<Product>(presenter.AddToCart(id));
            }
           
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedProduct = productGridView1.SelectedRows[0].DataBoundItem as Product;
            IdProductBox.Text = selectedProduct.IdProduct.ToString();
            AddProductButton.Enabled = true;
            OrderButton.Enabled = true;
        }
        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedOrder = myOrderClientView.SelectedRows[0].DataBoundItem as OrderProvider;
            idProductBox1.Text = selectedOrder.Id.ToString();
            costProductBox.Text = selectedOrder.TotalCost.ToString();
            PayButton.Enabled = true;
        }
        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedProduct = courierDataGridView.SelectedRows[0].DataBoundItem as Order;
            idOrderText.Text = selectedProduct.IdProduct.ToString();
            deliverButton.Enabled = true;
        }
        private void ОкGroupBox1_Click(object sender, EventArgs e)
        {
            if (type == UserType.Client)
            {
                productGridView1.DataSource = presenter.GetClientsProduct(getProductType());
            }
            else
            {
                productGridView1.DataSource = presenter.GetStorage(getProductType());
            }
            productGridView1.Show();
            MainPanel.Show();
        }

        private void CourierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CatalogLabel.Text = "Заказы";
            if (MainPanel.Visible || groupBox1.Visible || MyOrderPanel.Visible || BidPanel.Visible || ProfitPanel.Visible || consignmentPanel.Visible)
            {
                MainPanel.Hide();
                groupBox1.Hide();
                MyOrderPanel.Hide();
                BidPanel.Hide();
                ProfitPanel.Hide();
                consignmentPanel.Hide();
            }
            DeliverPanel.Show();
            courierDataGridView.DataSource = presenter.GetСonsignments();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            DeliverPanel.Hide();
            CatalogLabel.Text = "";
        }

        private void MyOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //presenter.CheckClientOrder()

            GiveStorageButton.Hide();
            myOrderCartGridView.Hide();
            GiveStorageLabel.Hide();
            bidText.Show();
            BidLabel.Show();
            LeaveBidButton.Show();
            CostProduct.Show();
            myOrderClientView.Show();
        
            //
            myOrderProviderView.Hide();
            if (!MyOrderPanel.Visible)
            {
                MyOrderPanel.Show();
            }
            CatalogLabel.Text = "Мои Заказы";
            if (MainPanel.Visible || groupBox1.Visible || ProfitPanel.Visible || BidPanel.Visible || DeliverPanel.Visible)
            {
                MainPanel.Hide();
                groupBox1.Hide();
                ProfitPanel.Hide();
                BidPanel.Hide();
                DeliverPanel.Hide();
            }

            //if (!BidLabel.Visible || !BidText.Visible || !LeaveBidButton.Visible)
            // {
            //    BidText.Show();
            //   BidLabel.Show();
            //     LeaveBidButton.Show();
            //    GiveStorageButton.Hide();
            //    dataGridView6.Hide();
            //    GiveStorageLabel.Hide();
            // }

            if (deleteOrderButton.Visible)
            {
                costProductBox.Show();
                PayButton.Show();
                CostProduct.Show();
               
                deleteOrderButton.Hide();
            }

            myOrderClientView.DataSource = presenter.getClientsOrders();
          
        }

        private void CloseButton2_Click(object sender, EventArgs e)
        {
            MyOrderPanel.Hide();
            CatalogLabel.Text = "";
        }
        private void OrderProviderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GiveStorageButton.Show();
            myOrderCartGridView.Show();
            GiveStorageLabel.Show();
            costProductBox.Show();
            CostProduct.Show();
            bidText.Hide();
            BidLabel.Hide();
            LeaveBidButton.Hide();
            myOrderProviderView.Show();
            deleteOrderButton.Show();
            //
            myOrderClientView.Hide();

            if (!MyOrderPanel.Visible)
            {
                MyOrderPanel.Show();
            }
            if (DeliverPanel.Visible || MainPanel.Visible || groupBox1.Visible || BidPanel.Visible || ProfitPanel.Visible)
            {
                DeliverPanel.Hide();
                MainPanel.Hide();
                groupBox1.Hide();
                BidPanel.Hide();
                ProfitPanel.Hide();
            }
            CatalogLabel.Text = "Заказы у поставщиков";
            //if(BidLabel.Visible && BidText.Visible && LeaveBidButton.Visible)
            //{
            //    BidText.Hide();
            //    BidLabel.Hide();
            //    LeaveBidButton.Hide();

            //}
            if (deleteOrderButton.Visible)
            {
                costProductBox.Show();
                PayButton.Show();
                costProductBox.Show();
                moveButton.Show();
                deleteOrderButton.Hide();
            }

            myOrderProviderView.DataSource = presenter.GetOrderProvider(); 
        }
        private void BidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bidsComboBox.Items.Clear();
            bidsComboBox.Items.AddRange(presenter.GetBidsId());
            if (MyOrderPanel.Visible || DeliverPanel.Visible || MainPanel.Visible || groupBox1.Visible || ProfitPanel.Visible)
            {
                MyOrderPanel.Hide();
                DeliverPanel.Hide();
                MainPanel.Hide();
                groupBox1.Hide();
                ProfitPanel.Hide();
            }

            if (!BidPanel.Visible)
            {
                BidPanel.Show();
            }
            CatalogLabel.Text = "Заявки";
        }
        private void CloseButton3_Click(object sender, EventArgs e)
        {
            BidPanel.Hide();
            CatalogLabel.Text = "";
        }

        private void EditingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!MyOrderPanel.Visible)
            {
                MyOrderPanel.Show();

            }
            if (DeliverPanel.Visible || MainPanel.Visible || groupBox1.Visible || BidPanel.Visible || ProfitPanel.Visible || consignmentPanel.Visible)
            {
                DeliverPanel.Hide();
                MainPanel.Hide();
                groupBox1.Hide();
                BidPanel.Hide();
                ProfitPanel.Hide();
                consignmentPanel.Hide();
            }
            CatalogLabel.Text = "Редактирование заказов";
            if (BidLabel.Visible && bidText.Visible && LeaveBidButton.Visible)
            {
                bidText.Hide();
                BidLabel.Hide();
                LeaveBidButton.Hide();
                GiveStorageButton.Show();
                myOrderCartGridView.Show();
                GiveStorageLabel.Show();
            }

            if (costProductBox.Visible && PayButton.Visible && costProductBox.Visible)
            {
                costProductBox.Hide();
                PayButton.Hide();
                CostProduct.Hide();
                bidText.Hide();
                BidLabel.Hide();
                LeaveBidButton.Hide();
                GiveStorageButton.Hide();
                myOrderCartGridView.Hide();
                GiveStorageLabel.Hide();
                deleteOrderButton.Show();
            }
        }

        private void ProfitToolStripMenuItem_Click(object sender, EventArgs e)
        {  
            if (!ProfitPanel.Visible)
            {
                ProfitPanel.Show();
            }
            if (MainPanel.Visible || groupBox1.Visible || MyOrderPanel.Visible || BidPanel.Visible || DeliverPanel.Visible)
            {
                MainPanel.Hide();
                groupBox1.Hide();
                MyOrderPanel.Hide();
                BidPanel.Hide();
                DeliverPanel.Hide();

            }
            CatalogLabel.Text = "Ведение отчётности";

            costsTextBox.Text = presenter.GetCosts().ToString();
            incomeTextBox.Text = presenter.GetIncome().ToString();
        }

        private void CloseProfit_Click(object sender, EventArgs e)
        {
            ProfitPanel.Hide();
            CatalogLabel.Text = "";
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            inputWindow.Show();
        }

        void IViewOpenClose.Show()
        {
            throw new NotImplementedException();
        }

        void IViewOpenClose.Close()
        {
            throw new NotImplementedException();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            inputWindow.Show();
        }

      
        private void SortButton_Click(object sender, EventArgs e)
        {
            productGridView1.DataSource = presenter.GetSortedStorage(getProductType());
        }

        private void OrderButton_Click(object sender, EventArgs e)
        {
         
            cartGridView.DataSource = presenter.makeOrder();
        }

        private ProductType getProductType()
        {
            ProductType type = ProductType.Manufacture;
            if (radioButton2.Checked)
            {
                type = ProductType.Food;
            }
            return type;
        }

        private void PayButton_Click(object sender, EventArgs e)
        {

           
            if (type == UserType.Booker)
            {
                long id = long.Parse(idProductBox1.Text);
                myOrderProviderView.DataSource = presenter.ChangeOrderProviderStatus(long.Parse(idProductBox1.Text), "Оплачено");
            }
            else if(type == UserType.Client)
            {
                myOrderClientView.DataSource = presenter.ChangeOrderStatus(long.Parse(idProductBox1.Text), "Оплачено");
            }
        }
        private void moveButton_Click(object sender, EventArgs e)
        {
            if (idProductBox1.Text != "" && myOrderProviderView.Rows.Count != 0)
            {
                long id = long.Parse(idProductBox1.Text);
                myOrderCartGridView.DataSource = new List<OrderProvider>(presenter.AddToCartProvider(id));
                myOrderProviderView.DataSource = presenter.RemoveOrderProvider(id);
                idProductBox1.Text = "";
                costProductBox.Text = "";
            }
          
        }
        private void GiveStorageButton_Click(object sender, EventArgs e)
        {
          if(myOrderCartGridView.Rows.Count != 0 )
            {
                myOrderCartGridView.DataSource = presenter.AddProductToStorage((List<OrderProvider>)myOrderCartGridView.DataSource);
            }
        
        }

        private void transferToCourierButton_Click(object sender, EventArgs e)
        {
            if(idOrderBox.Text !="" && consignmentDataView.Rows.Count != 0)
            {
                consignmentDataView.DataSource = presenter.AddToCourier(long.Parse(idOrderBox.Text));
                productGridView1.DataSource = presenter.GetStorage(getProductType());
            }
            else
            {
                this.ShowMessage("Ошибка");
            }
           
        }

        private void courierDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedId = courierDataGridView.SelectedRows[0].DataBoundItem as Сonsignment;
            idOrderText.Text = selectedId.OrderId.ToString();
            deliverButton.Enabled = true;
        }

        private void deliverButton_Click(object sender, EventArgs e)
        {
            if (idOrderText.Text != "")
            {
                presenter.RemoveConsignment(long.Parse(idOrderText.Text));
                courierDataGridView.DataSource = presenter.GetСonsignments();
             
                ShowMessage("Заказ успешно доставлен");
                myOrderClientView.DataSource = presenter.ChangeOrderStatus(long.Parse(idOrderText.Text), "Доставлен");
            }
            else
            {
                ShowMessage("Ошибка");
            }
        }

        private void deleteOrderButton_Click(object sender, EventArgs e)
        {
            if (idProductBox1.Text != "")
            {
                if (type == UserType.AccountManager)
                {
                    myOrderClientView.DataSource = presenter.RemoveOrder(long.Parse(idProductBox1.Text));
                }
            }
        }

        private void myOrderProviderView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedId = myOrderProviderView.SelectedRows[0].DataBoundItem as OrderProvider;
            idProductBox1.Text = selectedId.Id.ToString();
            costProductBox.Text = selectedId.TotalCost.ToString();
            PayButton.Enabled = true;
        }

        private void LeaveBidButton_Click(object sender, EventArgs e)
        {
            if (bidText.Text != "")
            {
                presenter.LeaveBid(bidText.Text);
                // додумать
            }
            else
            {
                ShowMessage("Ошибочка вышла, вы Саша Соболь");
            }
            bidText.Text = "";
        }
        

        private void clientsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedState = bidsComboBox.SelectedItem.ToString();
            bidTextBox.Text = presenter.GetBid(int.Parse(selectedState));
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
           // OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog.FileName;
            // читаем файл в строку
            string fileText = System.IO.File.ReadAllText(filename);
            richTextBox1.Text = fileText;
            MessageBox.Show("Файл открыт");
        }

        private void saveFileButton_Click(object sender, EventArgs e)
        {
      
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog.FileName;
            // сохраняем текст в файл
            System.IO.File.WriteAllText(filename, richTextBox1.Text);
            MessageBox.Show("Файл сохранен");
            richTextBox1.Text = "";
        }

        private void calculateProfitButton_Click(object sender, EventArgs e)
        {
            profitTextBox.Text = presenter.CalculateProfit().ToString();
        }
    }
}
