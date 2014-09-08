using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;
using MetroFramework.Drawing;
using MetroFramework.Components;
using MetroFramework.Interfaces;
using MetroFramework.Controls;
using MetroFramework;

namespace DataGridMetro.Class
{
    public partial class MetroGrid : C1FlexGrid, IMetroControl
    {
        #region Interface
        [Category("Metro Appearance")]
        public event EventHandler<MetroPaintEventArgs> CustomPaintBackground;
        protected virtual void OnCustomPaintBackground(MetroPaintEventArgs e)
        {
            if (GetStyle(ControlStyles.UserPaint) && CustomPaintBackground != null)
            {
                CustomPaintBackground(this, e);
            }
        }

        [Category("Metro Appearance")]
        public event EventHandler<MetroPaintEventArgs> CustomPaint;
        protected virtual void OnCustomPaint(MetroPaintEventArgs e)
        {
            if (GetStyle(ControlStyles.UserPaint) && CustomPaint != null)
            {
                CustomPaint(this, e);
            }
        }

        [Category("Metro Appearance")]
        public event EventHandler<MetroPaintEventArgs> CustomPaintForeground;
        protected virtual void OnCustomPaintForeground(MetroPaintEventArgs e)
        {
            if (GetStyle(ControlStyles.UserPaint) && CustomPaintForeground != null)
            {
                CustomPaintForeground(this, e);
            }
        }

        private MetroColorStyle metroStyle = MetroColorStyle.Default;
        [Category("Metro Appearance")]
        [DefaultValue(MetroColorStyle.Default)]
        public MetroColorStyle Style
        {
            get
            {
                if (DesignMode || metroStyle != MetroColorStyle.Default)
                {
                    return metroStyle;
                }

                if (StyleManager != null && metroStyle == MetroColorStyle.Default)
                {
                    return StyleManager.Style;
                }
                if (StyleManager == null && metroStyle == MetroColorStyle.Default)
                {
                    return MetroColorStyle.Blue;
                }

                return metroStyle;
            }
            set { metroStyle = value; StyleGrid(); }
        }

        private MetroThemeStyle metroTheme = MetroThemeStyle.Default;
        [Category("Metro Appearance")]
        [DefaultValue(MetroThemeStyle.Default)]
        public MetroThemeStyle Theme
        {
            get
            {
                if (DesignMode || metroTheme != MetroThemeStyle.Default)
                {
                    return metroTheme;
                }

                if (StyleManager != null && metroTheme == MetroThemeStyle.Default)
                {
                    return StyleManager.Theme;
                }
                if (StyleManager == null && metroTheme == MetroThemeStyle.Default)
                {
                    return MetroThemeStyle.Light;
                }

                return metroTheme;
            }
            set { metroTheme = value; StyleGrid(); }
        }

        private MetroStyleManager metroStyleManager = null;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MetroStyleManager StyleManager
        {
            get { return metroStyleManager; }
            set { metroStyleManager = value; StyleGrid(); }
        }

        private bool useCustomBackColor = false;
        [DefaultValue(false)]
        [Category("Metro Appearance")]
        public bool UseCustomBackColor
        {
            get { return useCustomBackColor; }
            set { useCustomBackColor = value; }
        }

        private bool useCustomForeColor = false;
        [DefaultValue(false)]
        [Category("Metro Appearance")]
        public bool UseCustomForeColor
        {
            get { return useCustomForeColor; }
            set { useCustomForeColor = value; }
        }

        private bool useStyleColors = false;
        [DefaultValue(false)]
        [Category("Metro Appearance")]
        public bool UseStyleColors
        {
            get { return useStyleColors; }
            set { useStyleColors = value; }
        }

        [Browsable(false)]
        [Category("Metro Behaviour")]
        [DefaultValue(true)]
        public bool UseSelectable
        {
            get { return GetStyle(ControlStyles.Selectable); }
            set { SetStyle(ControlStyles.Selectable, value); }
        }
        #endregion

        #region Fields

        private bool displayFocusRectangle = false;
        [DefaultValue(false)]
        [Category("Metro Appearance")]
        public bool DisplayFocus
        {
            get { return displayFocusRectangle; }
            set { displayFocusRectangle = value; }
        }


        private MetroDateTimeSize metroDateTimeSize = MetroDateTimeSize.Medium;
        [DefaultValue(MetroDateTimeSize.Medium)]
        [Category("Metro Appearance")]
        public MetroDateTimeSize FontSize
        {
            get { return metroDateTimeSize; }
            set { metroDateTimeSize = value; }
        }

        private MetroDateTimeWeight metroDateTimeWeight = MetroDateTimeWeight.Regular;
        [DefaultValue(MetroDateTimeWeight.Regular)]
        [Category("Metro Appearance")]
        public MetroDateTimeWeight FontWeight
        {
            get { return metroDateTimeWeight; }
            set { metroDateTimeWeight = value; }
        }
        #endregion

        private bool _displayaction = true;

        MetroGridHelper scrollhelper = null;
        MetroGridHelper scrollhelperH = null;

        public MetroGrid()
        {
            InitializeComponent();
            StyleGrid();

            this.Controls.Add(_vertical);
            this.Controls.Add(_horizontal);
            scrollhelper = new MetroGridHelper(_vertical, this);
            scrollhelperH = new MetroGridHelper(_horizontal, this, false);

            this.RowColChange += MetroGrid_RowColChange;
            this.BeforeScroll += MetroGrid_BeforeScroll;
            this.AfterScroll += MetroGrid_AfterScroll;
            this.AfterFilter += MetroGrid_AfterFilter;
            this.AfterDataRefresh += MetroGrid_AfterDataRefresh;
            this.DoubleClick += MetroGrid_DoubleClick;
            this.KeyDown += MetroGrid_KeyDown;

            if (this.Rows.Count > 1)
            {
                Rectangle _rec = this.GetCellRect(this.Row, 0);
                int _left = _rec.Left;
                int _top = _rec.Top;
            }

            _horizontal.MouseLeave += Metro_MouseLeave;
            _vertical.MouseLeave += Metro_MouseLeave;
        }

        void MetroGrid_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Return:
                case Keys.Space:
                    break;
                case Keys.Delete:
                    break;
            }
        }

        void MetroGrid_DoubleClick(object sender, EventArgs e)
        {
      
        }

        void MetroGrid_AfterDataRefresh(object sender, ListChangedEventArgs e)
        {
            Rectangle _rec = this.GetCellRect(this.Row, 0);
            int _left = _rec.Left;
            int _top = _rec.Top;
        }

        void MetroGrid_AfterFilter(object sender, EventArgs e)
        {
            MetroGrid_RowColChange(sender, new EventArgs());
        }

        void MetroGrid_AfterScroll(object sender, RangeEventArgs e)
        {
            MetroGrid_RowColChange(sender, new EventArgs());
        }

        void MetroGrid_BeforeScroll(object sender, RangeEventArgs e)
        {
            
        }

        void Metro_MouseLeave(object sender, EventArgs e)
        {
            _horizontal.Visible = false;
            _vertical.Visible = false;
        }

        private void StyleGrid()
        {
            this.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.None;

            this.Styles.Alternate.BackColor = (Theme == MetroThemeStyle.Light) ? Color.FromArgb(244, 244, 244) : Color.FromArgb(40, 40, 40);
            this.Styles.Highlight.BackColor = Color.FromArgb(90, MetroPaint.GetStyleColor(Style).R, MetroPaint.GetStyleColor(Style).G, MetroPaint.GetStyleColor(Style).B);  // Color.FromArgb(90,25, 199, 244);
            this.Styles.Highlight.ForeColor = (Theme == MetroThemeStyle.Light) ? Color.FromArgb(17, 17, 17) : Color.FromArgb(255, 255, 255);

            this.Styles.Fixed.BackColor = MetroPaint.GetStyleColor(Style);
            this.Styles.Fixed.Border.Color = MetroPaint.GetStyleColor(Style);
            this.Styles.Fixed.ForeColor = MetroPaint.ForeColor.Button.Press(Theme);
            this.Styles.Fixed.Font = new Font("Tahoma", 9.0f);//MetroFonts.Label(MetroLabelSize.Small, MetroLabelWeight.Regular);
            this.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter;

            this.Styles.Normal.BackColor = MetroPaint.BackColor.Form(Theme);
            this.Styles.Normal.Border.Color = (Theme == MetroThemeStyle.Light) ? Color.FromArgb(229, 229, 229) : Color.FromArgb(93, 93, 93);
            this.Styles.Normal.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Vertical;
            this.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Flat;

            this.Styles.Frozen.BackColor = MetroPaint.BackColor.Form(Theme);
            this.Styles.Frozen.Border.Color = (Theme == MetroThemeStyle.Light) ? Color.FromArgb(229, 229, 229) : Color.FromArgb(93, 93, 93);
            this.Styles.Frozen.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Vertical;
            this.Styles.Frozen.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Flat;

            this.Styles.EmptyArea.BackColor = MetroPaint.BackColor.Form(Theme);
            this.Styles.EmptyArea.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Flat;
            this.Styles.EmptyArea.Border.Color = (Theme == MetroThemeStyle.Light) ? Color.FromArgb(229, 229, 229) : Color.FromArgb(93, 93, 93);

            this.BackColor = MetroPaint.BackColor.Form(Theme);
            this.ForeColor = MetroPaint.ForeColor.Button.Disabled(MetroThemeStyle.Dark);
            this.Font = new Font("Segoe UI", 11f, FontStyle.Regular, GraphicsUnit.Pixel); //MetroFonts.Label(MetroLabelSize.Small, MetroLabelWeight.Regular);
            this.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid;
            this.Rows[0].Height = 25;
        }

        void MetroGrid_RowColChange(object sender, EventArgs e)
        {
            if (this.Rows.Count > 1 && _displayaction)
            {
                if (this.Row <= 0) return;
                if (!(this.Row >= this.TopRow && this.Row <= this.Bottom)) return;
                if (this.TopRow < 0) return;

                Rectangle _rec = this.GetCellRect(this.Row, 0);
                int _left = _rec.Left;
                int _top = _rec.Top;
            } 
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (e.Y <= this.Height && e.Y >= this.Height - 10)
            {
                _horizontal.Visible = scrollhelperH.VisibleHorizontalScroll();
            }
            else
            {
                if (_horizontal.Visible) this.Focus();
                _horizontal.Visible = false;
            }

            if (e.X <= this.Width && e.X >= this.Width - 10)
            {
                _vertical.Visible = scrollhelperH.VisibleVerticalScroll();
            }
            else
            {
                if (_vertical.Visible) this.Focus();
                _vertical.Visible = false;
            }
        }
    }

    public class MetroGridHelper
    {
        /// <summary>
        /// The associated scrollbar or scrollbar collector
        /// </summary>
        private MetroScrollBar _scrollbar;

        /// <summary>
        /// Associated Grid
        /// </summary>
        private C1FlexGrid _grid;

        /// <summary>
        /// if greater zero, scrollbar changes are ignored
        /// </summary>
        private int _ignoreScrollbarChange = 0;

        /// <summary>
        /// 
        /// </summary>
        private bool _ishorizontal = false;

        public MetroGridHelper(MetroScrollBar scrollbar, C1FlexGrid grid, bool vertical = true)
        {
            _scrollbar = scrollbar;
            _scrollbar.UseBarColor = true;
            _grid = grid;
            _ishorizontal = !vertical;

            grid.ScrollBars = System.Windows.Forms.ScrollBars.None;

            _grid.AfterScroll += new RangeEventHandler(_grid_AfterScroll);
            _grid.AfterAddRow += new RowColEventHandler(_grid_AfterAddRow);
            _grid.AfterDeleteRow += new RowColEventHandler(_grid_AfterDeleteRow);
            _grid.AfterDataRefresh += new ListChangedEventHandler(_grid_AfterDataRefresh);
            _grid.Resize += new EventHandler(_grid_Resize);
            _scrollbar.Scroll += _scrollbar_Scroll;    // += new ScrollValueChangedDelegate(_scrollbar_ValueChanged);
            _scrollbar.Visible = false;
            UpdateScrollbar();
        }

        void _scrollbar_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
        {
            if (_ignoreScrollbarChange > 0) return;

            if (_ishorizontal)
            {
                if (_scrollbar.Value >= 0 && _scrollbar.Value < _grid.Cols.Count)
                    _grid.LeftCol = (_grid.Cols.Fixed == 0 && _scrollbar.Value == 1) ? 0 : _scrollbar.Value;
            }
            else
            {
                if (_scrollbar.Value >= 0 && _scrollbar.Value < _grid.Rows.Count)
                    _grid.TopRow = _scrollbar.Value;
            }
        }

        private void BeginIgnoreScrollbarChangeEvents()
        {
            _ignoreScrollbarChange++;
        }

        private void EndIgnoreScrollbarChangeEvents()
        {
            if (_ignoreScrollbarChange > 0)
                _ignoreScrollbarChange--;
        }

        /// <summary>
        /// Updates the scrollbar values
        /// </summary>
        public void UpdateScrollbar()
        {
            try
            {
                BeginIgnoreScrollbarChangeEvents();

                if (_ishorizontal)
                {
                    int visibleCols = VisibleFlexGridCols();
                    _scrollbar.Maximum = _grid.Cols.Count - visibleCols + 1;
                    _scrollbar.Minimum = 1;
                    _scrollbar.SmallChange = 1;
                    _scrollbar.LargeChange = Math.Max(1, visibleCols - 1);
                    _scrollbar.Value = _grid.LeftCol;
                    _scrollbar.Location = new Point(0, _grid.Height - 10);
                    _scrollbar.Width = _grid.Width;
                    _scrollbar.BringToFront();
                }
                else
                {
                    int visibleRows = VisibleFlexGridRows();
                    _scrollbar.Maximum = _grid.Rows.Count - visibleRows + 1;
                    _scrollbar.Minimum = 1;
                    _scrollbar.SmallChange = 1;
                    _scrollbar.LargeChange = Math.Max(1, visibleRows - 1);
                    _scrollbar.Value = _grid.TopRow;

                    _scrollbar.Location = new Point(_grid.Width - 10, 0);
                    _scrollbar.Height = _grid.Height;
                    _scrollbar.BringToFront();
                }
            }
            finally
            {
                EndIgnoreScrollbarChangeEvents();
            }
        }

        /// <summary>
        /// Determine the current count of visible rows
        /// </summary>
        /// <returns></returns>
        private int VisibleFlexGridRows()
        {
            return _grid.BottomRow - _grid.TopRow;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private int VisibleFlexGridCols()
        {
            return _grid.RightCol - _grid.LeftCol;
        }

        public bool VisibleVerticalScroll()
        {
            bool _return = false;
            int _rowheight = 0;

            foreach (Row _row in _grid.Rows)
            {
                if (_row.Index == 0) continue;
                if (!_row.Visible) continue;

                _rowheight += _row.HeightDisplay;

                if (_rowheight > (_grid.Height - _grid.Rows[0].HeightDisplay))
                {
                    _return = true;
                    break;
                }
            }

            return _return;
        }

        public bool VisibleHorizontalScroll()
        {
            bool _return = false;
            int _colwidth = 0;

            foreach (Column _col in _grid.Cols)
            {
                if (!_col.Visible) continue;
                _colwidth += _col.WidthDisplay;

                if (_colwidth > _grid.Width)
                {
                    _return = true;
                    break;
                }
            }

            return _return;
        }

        #region Events of interest

        void _grid_Resize(object sender, EventArgs e)
        {
            UpdateScrollbar();
        }


        void _grid_AfterDeleteRow(object sender, RowColEventArgs e)
        {
            UpdateScrollbar();
        }

        void _grid_AfterAddRow(object sender, RowColEventArgs e)
        {
            UpdateScrollbar();
        }

        private void _grid_AfterScroll(object sender, RangeEventArgs e)
        {
            UpdateScrollbar();
        }

        void _grid_AfterDataRefresh(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            UpdateScrollbar();
        }

        void _scrollbar_ValueChanged(MetroScrollBar sender, int newValue)
        {
            if (_ignoreScrollbarChange > 0) return;

            if (_ishorizontal)
            {
                if (newValue >= 0 && newValue < _grid.Cols.Count)
                    _grid.LeftCol = newValue;
            }
            else
            {
                if (newValue >= 0 && newValue < _grid.Rows.Count)
                    _grid.TopRow = newValue;
            }
        }
        #endregion
    }
}
