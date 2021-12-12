using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presentation.Common;
using Presentation.Presenters;
using Presentation.Views;
using Model.Services;
using Model.Repositories.DAO;


namespace WarehouseAccountingSystem
{
    public partial class MainForm : Form, IMainView
    {
       
       private MainPresenter presenter;
       public List<Foodstuffs> Items2 { get; set; }
       public List<Product> Items3 { get; set; }
       public List<Order> Orders { get; set; }
       public string ClientName { get; set; }
       public bool PurchasingManager { get; set; }
       public bool AccountManager { get; set; }
       
       public string Heading { get; set; }
       private Form inputWindow;

 
        public MainForm(Input inputWindow)
        {
            InitializeComponent();
            Items2 = GetItems2();
            Orders = GetOrders();

            this.inputWindow = inputWindow;
            presenter = new MainPresenter(this, new AuthorizationService());
            presenter.GetRoles();

        }
        public void SetHeading(string heading)
        {
            CatalogLabel.Text = heading; 
        }
        // здесь происходит установка ролей
        public void SetWindowFromRole()
        {

            if (PurchasingManager == true)
            {
                // нужно с маленькой буквы прописать
                DeleviryToolStripMenuItem.Enabled = false;
                BidToolStripMenuItem.Enabled = false;
                ProfitToolStripMenuItem.Enabled = false;
                EditingToolStripMenuItem.Enabled = false;
                сatalogToolStripMenuItem.Enabled = false;
                groupBox1.Hide();
                CatalogLabel.Text = " ";
            }
            else if (AccountManager == true)
            {
                ProfitToolStripMenuItem.Enabled = false;
                BidToolStripMenuItem.Enabled = false;
                DeleviryToolStripMenuItem.Enabled = false;
                OrderProviderToolStripMenuItem.Enabled = false;
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
            presenter.Help();
        }

        public void OpenCatalog()
        {
            if (DeliverPanel.Visible || MyOrderPanel.Visible || BidPanel.Visible || ProfitPanel.Visible || SortButton.Visible || TransferButton.Visible)
            {
                DeliverPanel.Hide();
                MyOrderPanel.Hide();
                BidPanel.Hide();
                ProfitPanel.Hide();
                SortButton.Hide();
                TransferButton.Hide();
            }
            CatalogLabel.Text = "Каталог товаров";
            if (!MainPanel.Visible && !groupBox1.Visible)
            {
                MainPanel.Show();
                groupBox1.Show();
                ProductGridView1.Show();
            }

        }
        public void CheckStorage()
        {
            if (DeliverPanel.Visible || MyOrderPanel.Visible || BidPanel.Visible || ProfitPanel.Visible)
            {
                DeliverPanel.Hide();
                MyOrderPanel.Hide();
                BidPanel.Hide();
                ProfitPanel.Hide();
            }
            groupBox1.Show();
            MainPanel.Show();
            ProductGridView1.Show();
            SortButton.Show();
            TransferButton.Show();
            Order.Show();
            OrderButton.Show();
            CatalogLabel.Text = "Товары на складе";
            CartGridView.Show();
        }

        public void ExitCatalog()
        {
            MainPanel.Hide();
            CatalogLabel.Text = "";
        }
        
        private List<Order> GetOrders()
        {
            var list = new List<Order>();
            return list;
        }
        private List<Foodstuffs> GetItems2()
        {
            var list = new List<Foodstuffs>();
            list.Add(new Foodstuffs()
            {
                NameProduct = "Bread",
                WeightProduct = 1,
                CostProduct = 1,
                CountryProduct = "Belarus",
                IdProduct = 345678
            });
            return list;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //dataGridView4.DataSource = Orders;
           MyOrderGridView1.DataSource = Orders;
        }
        private void CheckCatalog_Click(object sender, EventArgs e)
        {
            presenter.GetCataloge();
        }

        private void ExitFromCatalog_Click(object sender, EventArgs e)
        {
            presenter.CloseCatalog();
        }

        private void СheckStorage_Click(object sender, EventArgs e)
        {

            //dataGridView1.Show();
            //ExitFromCatalog.Show();
            //IdProductBox.Show();
            //IdProductLabel.Show();
            //ReOrderButton.Show();
            //SortButton.Show();
            //TransferButton.Show();
            ProductGridView1.DataSource = presenter.GetStorage(getProductType());
           
        }
     
        public void CheckCourierOrder()
        {
            CatalogLabel.Text = "Заказы";
            if (MainPanel.Visible || groupBox1.Visible || MyOrderPanel.Visible || BidPanel.Visible || ProfitPanel.Visible)
            {
                MainPanel.Hide();
                groupBox1.Hide();
                MyOrderPanel.Hide();
                BidPanel.Hide();
                ProfitPanel.Hide();
            }
            DeliverPanel.Show();
        }

        public void CheckProviderOrder()
        {
           // здесь под вопросом кое-что
            GiveStorageButton.Show();
            MyOrderGridView.Show();
            GiveStorageLabel.Show();
            CostProductBox.Show();
            CostProduct.Show();
            BidText.Hide();
            BidLabel.Hide();
            LeaveBidButton.Hide();

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
            if (FindButton.Visible && DeleteOrderButton.Visible)
            {
                CostProductBox.Show();
                PayButton.Show();
                CostProductBox.Show();
                FindButton.Hide();
                DeleteOrderButton.Hide();
            }


        }
        //public void CheckMyOrders()
        //{
        //    GiveStorageButton.Hide();
        //    MyOrderGridView.Hide();
        //    GiveStorageLabel.Hide();
        //    BidText.Show();
        //    BidLabel.Show();
        //    LeaveBidButton.Show();
        //    CostProduct.Show();


        //    if (!MyOrderPanel.Visible)
        //    {
        //        MyOrderPanel.Show();
        //    }

        //    CatalogLabel.Text = "Мои Заказы";
        //    if (MainPanel.Visible || groupBox1.Visible || ProfitPanel.Visible || BidPanel.Visible || DeliverPanel.Visible)
        //    {
        //        MainPanel.Hide();
        //        groupBox1.Hide();
        //        ProfitPanel.Hide();
        //        BidPanel.Hide();
        //        DeliverPanel.Hide();
        //    }

        //    //if (!BidLabel.Visible || !BidText.Visible || !LeaveBidButton.Visible)
        //    // {
        //    //    BidText.Show();
        //    //   BidLabel.Show();
        //    //     LeaveBidButton.Show();
        //    //    GiveStorageButton.Hide();
        //    //    dataGridView6.Hide();
        //    //    GiveStorageLabel.Hide();
        //    // }

        //    if (FindButton.Visible && DeleteOrderButton.Visible)
        //    {
        //        CostProductBox.Show();
        //        PayButton.Show();
        //        CostProduct.Show();
        //        FindButton.Hide();
        //        DeleteOrderButton.Hide();
        //    }

        //}
        public void CheckEditing()
        {
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
            CatalogLabel.Text = "Редактирование заказов";
            if (BidLabel.Visible && BidText.Visible && LeaveBidButton.Visible)
            {
                BidText.Hide();
                BidLabel.Hide();
                LeaveBidButton.Hide();
                GiveStorageButton.Show();
                MyOrderGridView.Show();
                GiveStorageLabel.Show();
            }

            if (CostProductBox.Visible && PayButton.Visible && CostProductBox.Visible)
            {
                CostProductBox.Hide();
                PayButton.Hide();
                CostProduct.Hide();
                BidText.Hide();
                BidLabel.Hide();
                LeaveBidButton.Hide();
                GiveStorageButton.Hide();
                MyOrderGridView.Hide();
                GiveStorageLabel.Hide();
                FindButton.Show();
                DeleteOrderButton.Show();
            }
        }

        public void CheckProfit()
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
        }

        public void CheckBid()
        {
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
      

        private void AddProduct_Click(object sender, EventArgs e)
        {

            long id = long.Parse(IdProductBox.Text);

            CartGridView.DataSource = new List<Product> (presenter.AddToCart(id));
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedProduct = ProductGridView1.SelectedRows[0].DataBoundItem as Product;
            IdProductBox.Text = selectedProduct.IdProduct.ToString();
            AddProductButton.Enabled = true;
            OrderButton.Enabled = true;
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedOrder = MyOrderGridView1.SelectedRows[0].DataBoundItem as Order;
            IdProductBox1.Text = selectedOrder.Id.ToString();
            CostProductBox.Text = selectedOrder.TotalCost.ToString();
            PayButton.Enabled = true;
        }
        //private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    var selectedProduct = ProductGridView2.SelectedRows[0].DataBoundItem as Product;
        //    IdProductBox.Text = selectedProduct.IdProduct.ToString();
        //    AddProductButton.Enabled = true;
        //    OrderButton.Enabled = true;
        //}

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedProduct = dataGridView4.SelectedRows[0].DataBoundItem as Order;
            textBox3.Text = selectedProduct.IdProduct.ToString();
            DeliverButton.Enabled = true;
        }
        private void ОкGroupBox1_Click(object sender, EventArgs e)
        {
            ProductGridView1.DataSource = presenter.GetClientsProduct(getProductType());
            ProductGridView1.Show();
            MainPanel.Show();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void IdProductBox_TextChanged(object sender, EventArgs e)
        {

        }


        private void CourierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            presenter.GetCourierOrder();
        }

        private void DeliverButton_Click(object sender, EventArgs e)
        {

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
            MyOrderGridView.Hide();
            GiveStorageLabel.Hide();
            BidText.Show();
            BidLabel.Show();
            LeaveBidButton.Show();
            CostProduct.Show();


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

            if (FindButton.Visible && DeleteOrderButton.Visible)
            {
                CostProductBox.Show();
                PayButton.Show();
                CostProduct.Show();
                FindButton.Hide();
                DeleteOrderButton.Hide();
            }

            MyOrderGridView1.DataSource = presenter.getClientsOrders();

        }


        private void CloseButton2_Click(object sender, EventArgs e)
        {
            MyOrderPanel.Hide();
            CatalogLabel.Text = "";
        }

        private void MyOrderPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void OrderProviderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            presenter.CheckOrderProvider();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            presenter.GetBid();
        }
        private void CloseButton3_Click(object sender, EventArgs e)
        {
            BidPanel.Hide();
            CatalogLabel.Text = "";
        }

        private void EditingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            presenter.GetEditing();
        }

        private void ProfitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            presenter.GetProfit();
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

        private void DeleviryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void сatalogToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void CatalogLabel_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

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

        private void RequestToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SortButton_Click(object sender, EventArgs e)
        {
            ProductGridView1.DataSource = presenter.GetSortedStorage(getProductType());
        }

        private void OrderButton_Click(object sender, EventArgs e)
        {
            CartGridView.DataSource = presenter.makeOrder();
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
    }
}
