namespace DataGridMetro.Class
{
    partial class MetroGrid
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
            this._vertical = new MetroFramework.Controls.MetroScrollBar();
            this._horizontal = new MetroFramework.Controls.MetroScrollBar();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // _vertical
            // 
            this._vertical.LargeChange = 10;
            this._vertical.Location = new System.Drawing.Point(0, 0);
            this._vertical.Maximum = 100;
            this._vertical.Minimum = 0;
            this._vertical.MouseWheelBarPartitions = 10;
            this._vertical.Name = "_vertical";
            this._vertical.Orientation = MetroFramework.Controls.MetroScrollOrientation.Vertical;
            this._vertical.ScrollbarSize = 10;
            this._vertical.Size = new System.Drawing.Size(10, 200);
            this._vertical.TabIndex = 0;
            this._vertical.UseSelectable = true;
            // 
            // _horizontal
            // 
            this._horizontal.LargeChange = 10;
            this._horizontal.Location = new System.Drawing.Point(0, 0);
            this._horizontal.Maximum = 100;
            this._horizontal.Minimum = 0;
            this._horizontal.MouseWheelBarPartitions = 10;
            this._horizontal.Name = "_horizontal";
            this._horizontal.Orientation = MetroFramework.Controls.MetroScrollOrientation.Horizontal;
            this._horizontal.ScrollbarSize = 10;
            this._horizontal.Size = new System.Drawing.Size(200, 10);
            this._horizontal.TabIndex = 0;
            this._horizontal.UseSelectable = true;
            // 
            // MetroGrid
            // 
            this.Padding = new System.Windows.Forms.Padding(0, 0, 15, 15);
            this.Rows.DefaultSize = 19;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroScrollBar _vertical;
        private MetroFramework.Controls.MetroScrollBar _horizontal;
    }
}
