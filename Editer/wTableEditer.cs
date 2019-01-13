using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Spoon.Tools.TemplatePrint.Editer
{
    public partial class wTableEditer : wControlEditer
    {
        public int TitleHeight
        {
            get { return Control.TitleHeight; }
            set {
                Control.TitleHeight = value;
                txtTitleHeightPixel.Text = value.ToString();
                txtTitleHeightMm.Text = Helper.PrintHelper.DisplayToMm(value).ToString();
            }
        }

        public int RowHeight
        {
            get { return Control.RowHeight; }
            set
            {
                Control.RowHeight = value;
                txtRowHeightPixel.Text = value.ToString();
                txtRowHeightMm.Text = Helper.PrintHelper.DisplayToMm(value).ToString();
            }
        }

        public int ColWidth
        {
            get { return Control.Columns[cbColList.SelectedIndex].ColumnWidth; }
            set
            {
                Control.Columns[cbColList.SelectedIndex].ColumnWidth = value;
                txtColWidthPixel.Text = value.ToString();
                txtColWidthMm.Text = Helper.PrintHelper.DisplayToMm(value).ToString();
            }
        }

        public new Controls.wTable Control
        {
            get { return m_control as Controls.wTable; }
            set
            {
                if (m_control != null)
                {
                    m_control.PropertyChangedEvent -= m_propertyEvent;
                }
                m_control = value;
                if (value != null)
                {
                    value.PropertyChangedEvent += m_propertyEvent;
                    OnPropertyChanged(value, EventArgs.Empty);
                }
            }
        }
        new void OnPropertyChanged(object sender, EventArgs args)
        {
            if (Control == null)
            {
                return;
            }
            base.OnPropertyChanged(sender, args);
            TitleHeight = Control.TitleHeight;
            RowHeight = Control.RowHeight;
            txtRowFont.Text = Control.RowFont.ToString();
            txtRowCount.Text = Control.RowCount.ToString();
            ckShowTableTitle.Checked = Control.ShowTableTitle;
            cbShowTableBorder.Checked = Control.ShowTableBorder;

            //加载列设置
            cbColList.Items.Clear();
            foreach (TemplatePrint.Controls.wColumn col in Control.Columns)
            {
                cbColList.Items.Add(col.Name);
            }
            cbColList.SelectedIndex = 0;
        }

        public wTableEditer()
        {
            InitializeComponent();
        }

        public wTableEditer(Controls.wTable control) : base(control)
        {
            InitializeComponent();
            Control = control;
        }

        //删除当前列
        private void btnDel_Click(object sender, EventArgs e)
        {
            int pos = cbColList.SelectedIndex;
            if (pos == -1 || cbColList.Items.Count==1) return;
            Control.Columns.RemoveAt(pos);
            cbColList.Items.RemoveAt(pos);
            if (cbColList.Items.Count > pos)
            {
                cbColList.SelectedIndex = pos;
            }
            else if (cbColList.Items.Count > 0) 
            {
                cbColList.SelectedIndex = pos-1;
            }
            Control.ReCalcSize();
            //Control.Refresh();
        }

        /// <summary>
        /// 增加列
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int pos = cbColList.SelectedIndex;

            Control.Columns.Insert(pos, new TemplatePrint.Controls.wColumn("column","column",50));
            cbColList.Items.Insert(pos, "column");
            cbColList.SelectedIndex = pos;
            Control.ReCalcSize();
            //Control.Refresh();
        }

        private void cbColList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbColList.SelectedIndex != -1)
            {
                lblIndex.Text = "Index: " + cbColList.SelectedIndex.ToString();
                var col = Control.Columns[cbColList.SelectedIndex];
                txtColName.Text = col.Name;
                txtColTitle.Text = col.Title;
                ColWidth = col.ColumnWidth;
                txtColFont.Text = col.Font.ToString();
            }
        }

        private void btnRowFont_Click(object sender, EventArgs e)
        {
            using (var fd = new FontDialog())
            {
                fd.Font = Control.RowFont;
                if (fd.ShowDialog(this) == DialogResult.OK)
                {
                    Control.RowFont = fd.Font;
                    Control.Refresh();
                }
            }
        }

        private void btnColFont_Click(object sender, EventArgs e)
        {
            using (var fd = new FontDialog())
            {
                fd.Font = Control.Columns[cbColList.SelectedIndex].Font;
                if (fd.ShowDialog(this) == DialogResult.OK)
                {
                    Control.Columns[cbColList.SelectedIndex].Font = fd.Font;
                    Control.Refresh();
                }
            }
        }

        void OnTextBoxLeave(object sender, EventArgs e)
        {
            var txt = sender as TextBox;
            switch (txt.Name)
            {
                case "txtColName":
                    Control.Columns[cbColList.SelectedIndex].Name = txt.Text;
                    cbColList.Items[cbColList.SelectedIndex] = txt.Text;
                    break;
                case "txtColTitle":
                    Control.Columns[cbColList.SelectedIndex].Title = txt.Text;
                    break;
                case "txtColWidthPixel":
                    ColWidth = int.Parse(txt.Text);
                    break;
                case "txtColWidthMm":
                    ColWidth = Helper.PrintHelper.MmToDisplay(float.Parse(txt.Text));
                    break;
                case "txtTitleHeightPixel":
                    TitleHeight = int.Parse(txt.Text);
                    break;
                case "txtTitleHeightMm":
                    TitleHeight = Helper.PrintHelper.MmToDisplay(float.Parse(txt.Text));
                    break;
                case "txtRowHeightPixel":
                    RowHeight = int.Parse(txt.Text);
                    break;
                case "txtRowHeightMm":
                    RowHeight = Helper.PrintHelper.MmToDisplay(float.Parse(txt.Text));
                    break;
                case "txtRowCount":
                    Control.RowCount = int.Parse(txt.Text);
                    break;
            }
            Control.ReCalcSize();
            //Control.Refresh();
        }

        void OnTextBoxLeaveKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OnTextBoxLeave(sender, EventArgs.Empty);
            }
        }

        private void OnTextBoxLeaveKeyDown(object sender, EventArgs e)
        {

        }

        private void btnMoveColumn_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            switch (btn.Name)
            {
                case "btnUp":

                    break;
                case "btnDown":

                    break;
            }
        }

        private void ckShowTableTitle_CheckedChanged(object sender, EventArgs e)
        {
            Control.ShowTableTitle = ckShowTableTitle.Checked;
        }

        private void cbShowTableBorder_CheckedChanged(object sender, EventArgs e)
        {
            Control.ShowTableBorder = cbShowTableBorder.Checked;
        }
    }
}
