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
    public partial class Form1 : Form
    {
        //public List<Product> Items { get; set; }
        public List<Manufacture> Items1 { get; set; }
        public List<Foodstuffs> Items2 { get; set; }

        public List<Product> Items3 { get; set; }

        public List<Order> Orders { get; set;}
        public bool check = false;

        ToolStripLabel dateLabel;
        ToolStripLabel timeLabel;
        ToolStripLabel infoLabel;
        Timer timer;
        public Form1(Input x)
        {  
            InitializeComponent();
            Items1 = GetItems1();
            Items2 = GetItems2();
            Orders = GetOrders();
            
            if(x.PurchasingManager == true)
            {
                // нужно с маленькой буквы прописать
                DeleviryToolStripMenuItem.Enabled = false;
                BidToolStripMenuItem.Enabled = false;
                ProfitToolStripMenuItem.Enabled = false;
                EditingToolStripMenuItem.Enabled = false;
                сatalogToolStripMenuItem.Enabled = false;
            }

            // часики
            infoLabel = new ToolStripLabel();
            infoLabel.Text = "Текущие дата и время:";
            dateLabel = new ToolStripLabel();
            timeLabel = new ToolStripLabel();
            statusStrip1.Items.Add(infoLabel);
            statusStrip1.Items.Add(dateLabel);
            statusStrip1.Items.Add(timeLabel);
            infoLabel = new ToolStripLabel();
            infoLabel.Text = "Текущие дата и время:";
            dateLabel = new ToolStripLabel();
            timeLabel = new ToolStripLabel();
            timer = new Timer() { Interval = 1000 };
            timer.Tick += timer_Tick; 
            timer.Start();
            //Input x = new Input();
            //label1.Text = x.GetName();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            dateLabel.Text = DateTime.Now.ToLongDateString();
            timeLabel.Text = DateTime.Now.ToLongTimeString();
        }

        private List<Manufacture> GetItems1()
        {
            var list = new List<Manufacture>();
            list.Add(new Manufacture()
            {
                NameProduct = "TV",
                WeightProduct = 10,
                CostProduct = 100,
                CountryProduct = "Poland",
                IdProduct = 123456
            });
            return list;
        }
        private List<Order> GetOrders()
        {
            var list = new List<Order>();
            list.Add(new Order()
            {
                NameProduct = "TV",
                CostProduct = 100,
                IdProduct = 123456,
                PaymentProduct = "Оплачен"
            });
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
            dataGridView1.DataSource = Items1;
            dataGridView2.DataSource = Items2;
            dataGridView4.DataSource = Orders;
            dataGridView5.DataSource = Orders;
        }

        private void CheckCatalog_Click(object sender, EventArgs e)
        {
            if (DeliverPanel.Visible)
            {
                DeliverPanel.Hide();
            }
            if (MyOrderPanel.Visible)
            {
                MyOrderPanel.Hide();
            }
            if (BidPanel.Visible)
            {
                BidPanel.Hide();
            }
            if (ProfitPanel.Visible)
            {
                ProfitPanel.Hide();
            }
            CatalogLabel.Text = "Каталог товаров";
            if (SortButton.Visible)
            {
                SortButton.Hide();
            }
            if (TransferButton.Visible)
            {
                TransferButton.Hide();
            }
            if(!MainPanel.Visible && !groupBox1.Visible)
            {
                MainPanel.Show();
                groupBox1.Show();
                dataGridView1.Show();
            }
        }

        private void ExitFromCatalog_Click(object sender, EventArgs e)
        {  
            MainPanel.Hide();
            CatalogLabel.Text = "";
        }

        private void СheckStorage_Click(object sender, EventArgs e)
        {
            if (DeliverPanel.Visible)
            {
                DeliverPanel.Hide();
            }
            if (MyOrderPanel.Visible)
            {
                MyOrderPanel.Hide();
            }
            if (BidPanel.Visible)
            {
                BidPanel.Hide();
            }
            if (ProfitPanel.Visible)
            {
                ProfitPanel.Hide();
            }
            groupBox1.Show();
            MainPanel.Show();
            dataGridView1.Show();
            SortButton.Show();
            TransferButton.Show();
            Order.Show();
            OrderButton.Show();
            CatalogLabel.Text = "Товары на складе";
            dataGridView3.Show();

           
            //dataGridView1.Show();
            //ExitFromCatalog.Show();
            //IdProductBox.Show();
            //IdProductLabel.Show();
            //ReOrderButton.Show();
            //SortButton.Show();
            //TransferButton.Show();
           
        }

      

        private void AddProduct_Click(object sender, EventArgs e)
        {
            
            dataGridView3.DataSource = Items1; 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedProduct = dataGridView1.SelectedRows[0].DataBoundItem as Product;
            IdProductBox.Text = selectedProduct.IdProduct.ToString();
            AddProductButton.Enabled = true;
            OrderButton.Enabled = true;
        }

      
        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedOrder = dataGridView5.SelectedRows[0].DataBoundItem as Order;
            IdProductBox1.Text = selectedOrder.IdProduct.ToString();
            CostProductBox.Text = selectedOrder.CostProduct.ToString();
            PayButton.Enabled = true;
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedProduct = dataGridView2.SelectedRows[0].DataBoundItem as Product;
            IdProductBox.Text = selectedProduct.IdProduct.ToString();
            AddProductButton.Enabled = true;
            OrderButton.Enabled = true;
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedProduct = dataGridView4.SelectedRows[0].DataBoundItem as Order;
            textBox3.Text = selectedProduct.IdProduct.ToString();
            DeliverButton.Enabled = true;
        }

        private void ОкGroupBox1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (dataGridView2.Visible)
                {
                    dataGridView2.Hide();
                }
                MainPanel.Show();
                dataGridView1.Show();
            }
            else if (radioButton2.Checked)
            {
                if (dataGridView1.Visible)
                {
                    dataGridView1.Hide();
                }
                MainPanel.Show();
                dataGridView2.Show();
            }
            else
            {
                MessageBox.Show("Ошибка");
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void IdProductBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Номер телефона для связи: +375 228 1337");
        }

        private void CourierToolStripMenuItem_Click(object sender, EventArgs e)
        {

            CatalogLabel.Text = "Заказы";
            if (MainPanel.Visible || groupBox1.Visible || MyOrderPanel.Visible || BidPanel.Visible || ProfitPanel.Visible )
            {
                MainPanel.Hide();
                groupBox1.Hide();
                MyOrderPanel.Hide();
                BidPanel.Hide();
                ProfitPanel.Hide();
            }
            DeliverPanel.Show();
      
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
            GiveStorageButton.Hide();
            dataGridView6.Hide();
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
            GiveStorageButton.Show();
            dataGridView6.Show();
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BidToolStripMenuItem_Click(object sender, EventArgs e)
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
                dataGridView6.Show();
                GiveStorageLabel.Show();
            }
             
            if(CostProductBox.Visible && PayButton.Visible && CostProductBox.Visible)
            {
                CostProductBox.Hide();
                PayButton.Hide();
                CostProduct.Hide();
                BidText.Hide();
                BidLabel.Hide();
                LeaveBidButton.Hide();
                GiveStorageButton.Hide();
                dataGridView6.Hide();
                GiveStorageLabel.Hide();
                FindButton.Show();
                DeleteOrderButton.Show();
            }



        }

        private void ProfitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ProfitPanel.Visible)
            {
                ProfitPanel.Show();
            }
            if (MainPanel.Visible || groupBox1.Visible || MyOrderPanel.Visible || BidPanel.Visible || DeliverPanel.Visible )
            {
                MainPanel.Hide();
                groupBox1.Hide();
                MyOrderPanel.Hide();
                BidPanel.Hide();
                DeliverPanel.Hide();
               
            }

            CatalogLabel.Text = "Ведение отчётности";
        }

        private void CloseProfit_Click(object sender, EventArgs e)
        {
            ProfitPanel.Hide();
            CatalogLabel.Text = "";
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}
