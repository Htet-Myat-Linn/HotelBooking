﻿namespace HRS1.Booking
{
    partial class ctl_Booking
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvBooking1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooking1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBooking1
            // 
            this.dgvBooking1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBooking1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBooking1.Location = new System.Drawing.Point(0, 0);
            this.dgvBooking1.Name = "dgvBooking1";
            this.dgvBooking1.Size = new System.Drawing.Size(846, 77);
            this.dgvBooking1.TabIndex = 0;
            // 
            // ctl_Booking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvBooking1);
            this.Name = "ctl_Booking";
            this.Size = new System.Drawing.Size(846, 77);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooking1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvBooking1;
    }
}
