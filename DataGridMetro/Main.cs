using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;

namespace DataGridMetro
{
    public partial class Main : MetroForm 
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            DataTable _table = new DataTable();
            _table.ReadXml(Application.StartupPath + @"\Data\Books.xml");
            metroGrid1.DataSource = _table;
            metroGrid1.AutoSizeCols();   
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            stlMgr.Theme = stlMgr.Theme == MetroThemeStyle.Light ? MetroThemeStyle.Dark : MetroThemeStyle.Light;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            var m = new Random();
            int next = m.Next(0, 13);
            stlMgr.Style = (MetroColorStyle)next;
        }
    }
}
