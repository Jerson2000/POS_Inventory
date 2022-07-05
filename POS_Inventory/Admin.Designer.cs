namespace POS_Inventory
{
    partial class Admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
            this.panel1 = new System.Windows.Forms.Panel();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.iconButton3 = new FontAwesome.Sharp.IconButton();
            this.menuBtn = new FontAwesome.Sharp.IconButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnStockIn = new FontAwesome.Sharp.IconButton();
            this.btnLogout = new FontAwesome.Sharp.IconButton();
            this.btnUSettings = new FontAwesome.Sharp.IconButton();
            this.btnSysSettings = new FontAwesome.Sharp.IconButton();
            this.btnRecords = new FontAwesome.Sharp.IconButton();
            this.btnBrand = new FontAwesome.Sharp.IconButton();
            this.btnCategory = new FontAwesome.Sharp.IconButton();
            this.btnProduct = new FontAwesome.Sharp.IconButton();
            this.btnPOS = new FontAwesome.Sharp.IconButton();
            this.btnDashboard = new FontAwesome.Sharp.IconButton();
            this.lbRole = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.btnSalesHistory = new FontAwesome.Sharp.IconButton();
            this.dashboard1 = new POS_Inventory.ControlsAdmin.Dashboard();
            this.product1 = new POS_Inventory.ControlsAdmin.Product();
            this.stockIn1 = new POS_Inventory.ControlsAdmin.StockIn();
            this.category1 = new POS_Inventory.ControlsAdmin.Category();
            this.brand1 = new POS_Inventory.ControlsAdmin.Brand();
            this.userSettings1 = new POS_Inventory.ControlsAdmin.UserSettings();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.panel1.Controls.Add(this.iconButton1);
            this.panel1.Controls.Add(this.iconButton2);
            this.panel1.Controls.Add(this.iconButton3);
            this.panel1.Controls.Add(this.menuBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1253, 46);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // iconButton1
            // 
            this.iconButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.iconButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.TimesCircle;
            this.iconButton1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Regular;
            this.iconButton1.IconSize = 35;
            this.iconButton1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.iconButton1.Location = new System.Drawing.Point(1202, 10);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(39, 32);
            this.iconButton1.TabIndex = 0;
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = true;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // iconButton2
            // 
            this.iconButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton2.FlatAppearance.BorderSize = 0;
            this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            this.iconButton2.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Regular;
            this.iconButton2.IconSize = 35;
            this.iconButton2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.iconButton2.Location = new System.Drawing.Point(1157, 10);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Size = new System.Drawing.Size(39, 32);
            this.iconButton2.TabIndex = 0;
            this.iconButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton2.UseVisualStyleBackColor = true;
            this.iconButton2.Click += new System.EventHandler(this.iconButton2_Click);
            // 
            // iconButton3
            // 
            this.iconButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton3.FlatAppearance.BorderSize = 0;
            this.iconButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton3.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.iconButton3.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.iconButton3.IconFont = FontAwesome.Sharp.IconFont.Regular;
            this.iconButton3.IconSize = 35;
            this.iconButton3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.iconButton3.Location = new System.Drawing.Point(1112, 10);
            this.iconButton3.Name = "iconButton3";
            this.iconButton3.Size = new System.Drawing.Size(39, 32);
            this.iconButton3.TabIndex = 0;
            this.iconButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton3.UseVisualStyleBackColor = true;
            this.iconButton3.Click += new System.EventHandler(this.iconButton3_Click);
            // 
            // menuBtn
            // 
            this.menuBtn.FlatAppearance.BorderSize = 0;
            this.menuBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuBtn.IconChar = FontAwesome.Sharp.IconChar.Bars;
            this.menuBtn.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.menuBtn.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.menuBtn.IconSize = 35;
            this.menuBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.menuBtn.Location = new System.Drawing.Point(12, 10);
            this.menuBtn.Name = "menuBtn";
            this.menuBtn.Size = new System.Drawing.Size(39, 32);
            this.menuBtn.TabIndex = 0;
            this.menuBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.menuBtn.UseVisualStyleBackColor = true;
            this.menuBtn.Click += new System.EventHandler(this.menuBtn_Click);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panel2.Controls.Add(this.btnSalesHistory);
            this.panel2.Controls.Add(this.btnStockIn);
            this.panel2.Controls.Add(this.btnLogout);
            this.panel2.Controls.Add(this.btnUSettings);
            this.panel2.Controls.Add(this.btnSysSettings);
            this.panel2.Controls.Add(this.btnRecords);
            this.panel2.Controls.Add(this.btnBrand);
            this.panel2.Controls.Add(this.btnCategory);
            this.panel2.Controls.Add(this.btnProduct);
            this.panel2.Controls.Add(this.btnPOS);
            this.panel2.Controls.Add(this.btnDashboard);
            this.panel2.Controls.Add(this.lbRole);
            this.panel2.Controls.Add(this.lbName);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 46);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(259, 641);
            this.panel2.TabIndex = 1;
            // 
            // btnStockIn
            // 
            this.btnStockIn.FlatAppearance.BorderSize = 0;
            this.btnStockIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStockIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStockIn.ForeColor = System.Drawing.Color.White;
            this.btnStockIn.IconChar = FontAwesome.Sharp.IconChar.Warehouse;
            this.btnStockIn.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnStockIn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnStockIn.IconSize = 30;
            this.btnStockIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStockIn.Location = new System.Drawing.Point(13, 318);
            this.btnStockIn.Name = "btnStockIn";
            this.btnStockIn.Size = new System.Drawing.Size(231, 29);
            this.btnStockIn.TabIndex = 3;
            this.btnStockIn.Text = "Stock In";
            this.btnStockIn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStockIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStockIn.UseVisualStyleBackColor = true;
            this.btnStockIn.Click += new System.EventHandler(this.btnStockIn_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            this.btnLogout.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnLogout.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLogout.IconSize = 35;
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(12, 604);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(223, 29);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Logout";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnUSettings
            // 
            this.btnUSettings.FlatAppearance.BorderSize = 0;
            this.btnUSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUSettings.ForeColor = System.Drawing.Color.White;
            this.btnUSettings.IconChar = FontAwesome.Sharp.IconChar.UserCog;
            this.btnUSettings.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnUSettings.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnUSettings.IconSize = 30;
            this.btnUSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUSettings.Location = new System.Drawing.Point(12, 528);
            this.btnUSettings.Name = "btnUSettings";
            this.btnUSettings.Size = new System.Drawing.Size(232, 29);
            this.btnUSettings.TabIndex = 3;
            this.btnUSettings.Text = "User Settings";
            this.btnUSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUSettings.UseVisualStyleBackColor = true;
            this.btnUSettings.Click += new System.EventHandler(this.btnUSettings_Click);
            // 
            // btnSysSettings
            // 
            this.btnSysSettings.FlatAppearance.BorderSize = 0;
            this.btnSysSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSysSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSysSettings.ForeColor = System.Drawing.Color.White;
            this.btnSysSettings.IconChar = FontAwesome.Sharp.IconChar.Cog;
            this.btnSysSettings.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSysSettings.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSysSettings.IconSize = 30;
            this.btnSysSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSysSettings.Location = new System.Drawing.Point(12, 493);
            this.btnSysSettings.Name = "btnSysSettings";
            this.btnSysSettings.Size = new System.Drawing.Size(232, 29);
            this.btnSysSettings.TabIndex = 3;
            this.btnSysSettings.Text = "System Settings";
            this.btnSysSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSysSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSysSettings.UseVisualStyleBackColor = true;
            // 
            // btnRecords
            // 
            this.btnRecords.FlatAppearance.BorderSize = 0;
            this.btnRecords.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecords.ForeColor = System.Drawing.Color.White;
            this.btnRecords.IconChar = FontAwesome.Sharp.IconChar.Database;
            this.btnRecords.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnRecords.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRecords.IconSize = 30;
            this.btnRecords.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecords.Location = new System.Drawing.Point(13, 423);
            this.btnRecords.Name = "btnRecords";
            this.btnRecords.Size = new System.Drawing.Size(232, 29);
            this.btnRecords.TabIndex = 3;
            this.btnRecords.Text = "Records";
            this.btnRecords.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecords.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRecords.UseVisualStyleBackColor = true;
            // 
            // btnBrand
            // 
            this.btnBrand.FlatAppearance.BorderSize = 0;
            this.btnBrand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrand.ForeColor = System.Drawing.Color.White;
            this.btnBrand.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            this.btnBrand.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnBrand.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnBrand.IconSize = 30;
            this.btnBrand.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBrand.Location = new System.Drawing.Point(12, 388);
            this.btnBrand.Name = "btnBrand";
            this.btnBrand.Size = new System.Drawing.Size(232, 29);
            this.btnBrand.TabIndex = 3;
            this.btnBrand.Text = "Brand";
            this.btnBrand.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBrand.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBrand.UseVisualStyleBackColor = true;
            this.btnBrand.Click += new System.EventHandler(this.btnBrand_Click);
            // 
            // btnCategory
            // 
            this.btnCategory.FlatAppearance.BorderSize = 0;
            this.btnCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategory.ForeColor = System.Drawing.Color.White;
            this.btnCategory.IconChar = FontAwesome.Sharp.IconChar.Folder;
            this.btnCategory.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnCategory.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnCategory.IconSize = 30;
            this.btnCategory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategory.Location = new System.Drawing.Point(12, 353);
            this.btnCategory.Name = "btnCategory";
            this.btnCategory.Size = new System.Drawing.Size(232, 29);
            this.btnCategory.TabIndex = 3;
            this.btnCategory.Text = "Category";
            this.btnCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCategory.UseVisualStyleBackColor = true;
            this.btnCategory.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.FlatAppearance.BorderSize = 0;
            this.btnProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProduct.ForeColor = System.Drawing.Color.White;
            this.btnProduct.IconChar = FontAwesome.Sharp.IconChar.ClipboardList;
            this.btnProduct.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnProduct.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnProduct.IconSize = 30;
            this.btnProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProduct.Location = new System.Drawing.Point(12, 283);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(232, 29);
            this.btnProduct.TabIndex = 3;
            this.btnProduct.Text = "Manage Product";
            this.btnProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProduct.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProduct.UseVisualStyleBackColor = true;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // btnPOS
            // 
            this.btnPOS.FlatAppearance.BorderSize = 0;
            this.btnPOS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPOS.ForeColor = System.Drawing.Color.White;
            this.btnPOS.IconChar = FontAwesome.Sharp.IconChar.ShoppingCart;
            this.btnPOS.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnPOS.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPOS.IconSize = 30;
            this.btnPOS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPOS.Location = new System.Drawing.Point(13, 248);
            this.btnPOS.Name = "btnPOS";
            this.btnPOS.Size = new System.Drawing.Size(232, 29);
            this.btnPOS.TabIndex = 3;
            this.btnPOS.Text = "POS";
            this.btnPOS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPOS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPOS.UseVisualStyleBackColor = true;
            // 
            // btnDashboard
            // 
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.IconChar = FontAwesome.Sharp.IconChar.TachometerAlt;
            this.btnDashboard.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnDashboard.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDashboard.IconSize = 30;
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Location = new System.Drawing.Point(12, 213);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(232, 29);
            this.btnDashboard.TabIndex = 2;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // lbRole
            // 
            this.lbRole.Font = new System.Drawing.Font("Lucida Console", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRole.ForeColor = System.Drawing.Color.White;
            this.lbRole.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbRole.Location = new System.Drawing.Point(13, 179);
            this.lbRole.Name = "lbRole";
            this.lbRole.Size = new System.Drawing.Size(232, 14);
            this.lbRole.TabIndex = 1;
            this.lbRole.Text = "Administrator";
            this.lbRole.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbName
            // 
            this.lbName.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(184)))), ((int)(((byte)(160)))));
            this.lbName.Location = new System.Drawing.Point(16, 157);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(228, 16);
            this.lbName.TabIndex = 1;
            this.lbName.Text = "Username";
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(65, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(117, 107);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelContainer
            // 
            this.panelContainer.BackColor = System.Drawing.Color.White;
            this.panelContainer.Controls.Add(this.dashboard1);
            this.panelContainer.Controls.Add(this.product1);
            this.panelContainer.Controls.Add(this.stockIn1);
            this.panelContainer.Controls.Add(this.category1);
            this.panelContainer.Controls.Add(this.brand1);
            this.panelContainer.Controls.Add(this.userSettings1);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(259, 46);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(994, 641);
            this.panelContainer.TabIndex = 2;
            // 
            // btnSalesHistory
            // 
            this.btnSalesHistory.FlatAppearance.BorderSize = 0;
            this.btnSalesHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalesHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalesHistory.ForeColor = System.Drawing.Color.White;
            this.btnSalesHistory.IconChar = FontAwesome.Sharp.IconChar.Database;
            this.btnSalesHistory.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSalesHistory.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSalesHistory.IconSize = 30;
            this.btnSalesHistory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalesHistory.Location = new System.Drawing.Point(13, 458);
            this.btnSalesHistory.Name = "btnSalesHistory";
            this.btnSalesHistory.Size = new System.Drawing.Size(232, 29);
            this.btnSalesHistory.TabIndex = 4;
            this.btnSalesHistory.Text = "Sales History";
            this.btnSalesHistory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalesHistory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalesHistory.UseVisualStyleBackColor = true;
            this.btnSalesHistory.Click += new System.EventHandler(this.btnSalesHistory_Click);
            // 
            // dashboard1
            // 
            this.dashboard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dashboard1.Location = new System.Drawing.Point(0, 0);
            this.dashboard1.Name = "dashboard1";
            this.dashboard1.Size = new System.Drawing.Size(994, 641);
            this.dashboard1.TabIndex = 1;
            // 
            // product1
            // 
            this.product1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.product1.Location = new System.Drawing.Point(0, 0);
            this.product1.Name = "product1";
            this.product1.Size = new System.Drawing.Size(994, 641);
            this.product1.TabIndex = 3;
            // 
            // stockIn1
            // 
            this.stockIn1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stockIn1.Location = new System.Drawing.Point(0, 0);
            this.stockIn1.Name = "stockIn1";
            this.stockIn1.Size = new System.Drawing.Size(994, 641);
            this.stockIn1.TabIndex = 4;
            // 
            // category1
            // 
            this.category1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.category1.Location = new System.Drawing.Point(0, 0);
            this.category1.Name = "category1";
            this.category1.Size = new System.Drawing.Size(994, 641);
            this.category1.TabIndex = 2;
            // 
            // brand1
            // 
            this.brand1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.brand1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.brand1.Location = new System.Drawing.Point(0, 0);
            this.brand1.Name = "brand1";
            this.brand1.Size = new System.Drawing.Size(994, 641);
            this.brand1.TabIndex = 0;
            // 
            // userSettings1
            // 
            this.userSettings1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userSettings1.Location = new System.Drawing.Point(0, 0);
            this.userSettings1.Name = "userSettings1";
            this.userSettings1.Size = new System.Drawing.Size(994, 641);
            this.userSettings1.TabIndex = 5;
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1253, 687);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Admin_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton menuBtn;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton iconButton2;
        private FontAwesome.Sharp.IconButton iconButton3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton btnDashboard;
        private FontAwesome.Sharp.IconButton btnUSettings;
        private FontAwesome.Sharp.IconButton btnSysSettings;
        private FontAwesome.Sharp.IconButton btnRecords;
        private FontAwesome.Sharp.IconButton btnBrand;
        private FontAwesome.Sharp.IconButton btnCategory;
        private FontAwesome.Sharp.IconButton btnProduct;
        private FontAwesome.Sharp.IconButton btnPOS;
        private FontAwesome.Sharp.IconButton btnLogout;
        private System.Windows.Forms.Panel panelContainer;
        private ControlsAdmin.Brand brand1;
        private ControlsAdmin.Dashboard dashboard1;
        private ControlsAdmin.Category category1;
        private ControlsAdmin.Product product1;
        private FontAwesome.Sharp.IconButton btnStockIn;
        private ControlsAdmin.StockIn stockIn1;
        private ControlsAdmin.UserSettings userSettings1;
        public System.Windows.Forms.Label lbName;
        public System.Windows.Forms.Label lbRole;
        private FontAwesome.Sharp.IconButton btnSalesHistory;
    }
}

