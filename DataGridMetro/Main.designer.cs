namespace DataGridMetro
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.stlMgr = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroGrid1 = new DataGridMetro.Class.MetroGrid();
            ((System.ComponentModel.ISupportInitialize)(this.stlMgr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // stlMgr
            // 
            this.stlMgr.Owner = this;
            // 
            // metroButton1
            // 
            this.metroButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton1.Location = new System.Drawing.Point(584, 30);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(106, 25);
            this.metroButton1.TabIndex = 1;
            this.metroButton1.Text = "Toggle Theme";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton2.Location = new System.Drawing.Point(695, 30);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(106, 25);
            this.metroButton2.TabIndex = 2;
            this.metroButton2.Text = "Switch Style";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // metroGrid1
            // 
            this.metroGrid1.AllowFiltering = true;
            this.metroGrid1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.metroGrid1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.None;
            this.metroGrid1.ColumnInfo = "10,1,0,0,0,105,Columns:";
            this.metroGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroGrid1.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid;
            this.metroGrid1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroGrid1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroGrid1.Location = new System.Drawing.Point(20, 60);
            this.metroGrid1.Name = "metroGrid1";
            this.metroGrid1.Padding = new System.Windows.Forms.Padding(0, 0, 15, 15);
            this.metroGrid1.Rows.DefaultSize = 21;
            this.metroGrid1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroGrid1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.metroGrid1.Size = new System.Drawing.Size(781, 393);
            this.metroGrid1.StyleInfo = resources.GetString("metroGrid1.StyleInfo");
            this.metroGrid1.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 473);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metroGrid1);
            this.Name = "Main";
            this.StyleManager = this.stlMgr;
            this.Text = "C1Flexgrid MetroFramework Style";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stlMgr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridMetro.Class.MetroGrid metroGrid1;
        private MetroFramework.Components.MetroStyleManager stlMgr;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton2;
    }
}