
namespace WarehouseAccountingSystem
{
    partial class Input
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.login = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.InputEmployee = new System.Windows.Forms.Button();
            this.textPasswordBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textLoginBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.InputClientButton = new System.Windows.Forms.Button();
            this.name_customer = new System.Windows.Forms.TextBox();
            this.AddClient = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Customer = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.login.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // login
            // 
            this.login.AutoSize = true;
            this.login.BackColor = System.Drawing.SystemColors.HighlightText;
            this.login.Controls.Add(this.panel2);
            this.login.Controls.Add(this.panel1);
            this.login.Controls.Add(this.label1);
            this.login.Dock = System.Windows.Forms.DockStyle.Fill;
            this.login.Location = new System.Drawing.Point(0, 0);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(800, 450);
            this.login.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Info;
            this.panel2.Controls.Add(this.InputEmployee);
            this.panel2.Controls.Add(this.textPasswordBox);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.textLoginBox);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(385, 117);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(415, 333);
            this.panel2.TabIndex = 3;
            // 
            // InputEmployee
            // 
            this.InputEmployee.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InputEmployee.Location = new System.Drawing.Point(126, 187);
            this.InputEmployee.Name = "InputEmployee";
            this.InputEmployee.Size = new System.Drawing.Size(172, 38);
            this.InputEmployee.TabIndex = 11;
            this.InputEmployee.Text = "Войти";
            this.InputEmployee.UseVisualStyleBackColor = true;
            this.InputEmployee.Click += new System.EventHandler(this.InputEmployee_Click);
            // 
            // textPasswordBox
            // 
            this.textPasswordBox.Location = new System.Drawing.Point(126, 144);
            this.textPasswordBox.Name = "textPasswordBox";
            this.textPasswordBox.Size = new System.Drawing.Size(172, 20);
            this.textPasswordBox.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(123, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Пароль";
            // 
            // textLoginBox
            // 
            this.textLoginBox.Location = new System.Drawing.Point(126, 95);
            this.textLoginBox.Name = "textLoginBox";
            this.textLoginBox.Size = new System.Drawing.Size(172, 20);
            this.textLoginBox.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(123, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Логин";
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Wide Latin", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(415, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "Сотрудник";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Controls.Add(this.InputClientButton);
            this.panel1.Controls.Add(this.name_customer);
            this.panel1.Controls.Add(this.AddClient);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.Customer);
            this.panel1.Location = new System.Drawing.Point(4, 117);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(386, 333);
            this.panel1.TabIndex = 2;
            // 
            // InputClientButton
            // 
            this.InputClientButton.Enabled = false;
            this.InputClientButton.Location = new System.Drawing.Point(102, 281);
            this.InputClientButton.Name = "InputClientButton";
            this.InputClientButton.Size = new System.Drawing.Size(109, 40);
            this.InputClientButton.TabIndex = 6;
            this.InputClientButton.Text = "Войти";
            this.InputClientButton.UseVisualStyleBackColor = true;
            this.InputClientButton.Click += new System.EventHandler(this.InputClientButton_Click);
            // 
            // name_customer
            // 
            this.name_customer.Location = new System.Drawing.Point(32, 240);
            this.name_customer.Name = "name_customer";
            this.name_customer.Size = new System.Drawing.Size(115, 20);
            this.name_customer.TabIndex = 5;
            // 
            // AddClient
            // 
            this.AddClient.Font = new System.Drawing.Font("Wide Latin", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddClient.Location = new System.Drawing.Point(178, 240);
            this.AddClient.Name = "AddClient";
            this.AddClient.Size = new System.Drawing.Size(81, 20);
            this.AddClient.TabIndex = 4;
            this.AddClient.Text = "Добавить";
            this.AddClient.UseVisualStyleBackColor = true;
            this.AddClient.Click += new System.EventHandler(this.AddClient_Click);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Wide Latin", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(386, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Клиент";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Customer
            // 
            this.Customer.FormattingEnabled = true;
            this.Customer.Location = new System.Drawing.Point(8, 52);
            this.Customer.Name = "Customer";
            this.Customer.Size = new System.Drawing.Size(297, 21);
            this.Customer.Sorted = true;
            this.Customer.TabIndex = 0;
            this.Customer.SelectedIndexChanged += new System.EventHandler(this.Customer_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Wide Latin", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(800, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Добро пожаловать! Выберите роль.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Input
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.login);
            this.Name = "Input";
            this.Text = "Input";
            this.login.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel login;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox Customer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button InputClientButton;
        private System.Windows.Forms.TextBox name_customer;
        private System.Windows.Forms.Button AddClient;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button InputEmployee;
        private System.Windows.Forms.TextBox textPasswordBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textLoginBox;
        private System.Windows.Forms.Label label5;
    }
}