namespace HRS1.LogIn
{
    partial class frm_ManagerBoard
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
            this.mnuDeatialHide = new System.Windows.Forms.MenuStrip();
            this.mnuRoomType = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRoom = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBooking = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuService = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChekOut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDetailHide = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvBooking = new System.Windows.Forms.DataGridView();
            this.mnuDeatialHide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooking)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuDeatialHide
            // 
            this.mnuDeatialHide.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRoomType,
            this.mnuRoom,
            this.mnuEmployee,
            this.mnuCustomer,
            this.mnuBooking,
            this.mnuService,
            this.mnuChekOut,
            this.mnuDetailHide,
            this.toolStripMenuItem1});
            this.mnuDeatialHide.Location = new System.Drawing.Point(0, 0);
            this.mnuDeatialHide.Name = "mnuDeatialHide";
            this.mnuDeatialHide.Size = new System.Drawing.Size(700, 24);
            this.mnuDeatialHide.TabIndex = 1;
            this.mnuDeatialHide.Text = "DetailHide";
            // 
            // mnuRoomType
            // 
            this.mnuRoomType.Name = "mnuRoomType";
            this.mnuRoomType.Size = new System.Drawing.Size(80, 20);
            this.mnuRoomType.Text = "RoomTypes";
            this.mnuRoomType.Click += new System.EventHandler(this.mnuRoomType_Click);
            // 
            // mnuRoom
            // 
            this.mnuRoom.Name = "mnuRoom";
            this.mnuRoom.Size = new System.Drawing.Size(56, 20);
            this.mnuRoom.Text = "Rooms";
            this.mnuRoom.Click += new System.EventHandler(this.mnuRoom_Click);
            // 
            // mnuEmployee
            // 
            this.mnuEmployee.Name = "mnuEmployee";
            this.mnuEmployee.Size = new System.Drawing.Size(76, 20);
            this.mnuEmployee.Text = "Employees";
            this.mnuEmployee.Click += new System.EventHandler(this.mnuEmployee_Click);
            // 
            // mnuCustomer
            // 
            this.mnuCustomer.Name = "mnuCustomer";
            this.mnuCustomer.Size = new System.Drawing.Size(76, 20);
            this.mnuCustomer.Text = "Customers";
            this.mnuCustomer.Click += new System.EventHandler(this.mnuCustomer_Click);
            // 
            // mnuBooking
            // 
            this.mnuBooking.Name = "mnuBooking";
            this.mnuBooking.Size = new System.Drawing.Size(63, 20);
            this.mnuBooking.Text = "Booking";
            this.mnuBooking.Click += new System.EventHandler(this.mnuBooking_Click);
            // 
            // mnuService
            // 
            this.mnuService.Name = "mnuService";
            this.mnuService.Size = new System.Drawing.Size(56, 20);
            this.mnuService.Text = "Service";
            this.mnuService.Click += new System.EventHandler(this.mnuService_Click);
            // 
            // mnuChekOut
            // 
            this.mnuChekOut.Name = "mnuChekOut";
            this.mnuChekOut.Size = new System.Drawing.Size(75, 20);
            this.mnuChekOut.Text = "Check Out";
            // 
            // mnuDetailHide
            // 
            this.mnuDetailHide.Name = "mnuDetailHide";
            this.mnuDetailHide.Size = new System.Drawing.Size(74, 20);
            this.mnuDetailHide.Text = "DetailHide";
            this.mnuDetailHide.Click += new System.EventHandler(this.mnuDetailHide_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(48, 20);
            this.toolStripMenuItem1.Text = "Close";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // dgvBooking
            // 
            this.dgvBooking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBooking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBooking.Location = new System.Drawing.Point(0, 24);
            this.dgvBooking.Name = "dgvBooking";
            this.dgvBooking.Size = new System.Drawing.Size(700, 214);
            this.dgvBooking.TabIndex = 3;
            this.dgvBooking.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBooking_CellDoubleClick_1);
            // 
            // frm_ManagerBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(700, 238);
            this.Controls.Add(this.dgvBooking);
            this.Controls.Add(this.mnuDeatialHide);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_ManagerBoard";
            this.Text = "ManagerBoard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_ManagerBoard_Load);
            this.mnuDeatialHide.ResumeLayout(false);
            this.mnuDeatialHide.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooking)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuDeatialHide;
        private System.Windows.Forms.ToolStripMenuItem mnuRoomType;
        private System.Windows.Forms.ToolStripMenuItem mnuRoom;
        private System.Windows.Forms.ToolStripMenuItem mnuEmployee;
        private System.Windows.Forms.ToolStripMenuItem mnuCustomer;
        private System.Windows.Forms.ToolStripMenuItem mnuBooking;
        private System.Windows.Forms.ToolStripMenuItem mnuService;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuChekOut;
        private System.Windows.Forms.ToolStripMenuItem mnuDetailHide;
        private System.Windows.Forms.DataGridView dgvBooking;
    }
}