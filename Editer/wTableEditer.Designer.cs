namespace Spoon.Tools.TemplatePrint.Editer
{
    partial class wTableEditer
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtTitleHeightPixel = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTitleHeightMm = new System.Windows.Forms.TextBox();
            this.txtRowHeightMm = new System.Windows.Forms.TextBox();
            this.txtRowHeightPixel = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbColList = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnColFont = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblIndex = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtColFont = new System.Windows.Forms.TextBox();
            this.txtColWidthMm = new System.Windows.Forms.TextBox();
            this.txtColWidthPixel = new System.Windows.Forms.TextBox();
            this.txtColTitle = new System.Windows.Forms.TextBox();
            this.txtColName = new System.Windows.Forms.TextBox();
            this.btnRowFont = new System.Windows.Forms.Button();
            this.txtRowFont = new System.Windows.Forms.TextBox();
            this.btnFont = new System.Windows.Forms.Button();
            this.txtFont = new System.Windows.Forms.TextBox();
            this.txtRowCount = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.ckShowTableTitle = new System.Windows.Forms.CheckBox();
            this.cbShowTableBorder = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTitleHeightPixel
            // 
            this.txtTitleHeightPixel.Location = new System.Drawing.Point(59, 163);
            this.txtTitleHeightPixel.Name = "txtTitleHeightPixel";
            this.txtTitleHeightPixel.Size = new System.Drawing.Size(72, 20);
            this.txtTitleHeightPixel.TabIndex = 10;
            this.txtTitleHeightPixel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnTextBoxLeaveKeyDown);
            this.txtTitleHeightPixel.Leave += new System.EventHandler(this.OnTextBoxLeave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 166);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "THeight";
            // 
            // txtTitleHeightMm
            // 
            this.txtTitleHeightMm.Location = new System.Drawing.Point(148, 163);
            this.txtTitleHeightMm.Name = "txtTitleHeightMm";
            this.txtTitleHeightMm.Size = new System.Drawing.Size(72, 20);
            this.txtTitleHeightMm.TabIndex = 12;
            this.txtTitleHeightMm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnTextBoxLeaveKeyDown);
            this.txtTitleHeightMm.Leave += new System.EventHandler(this.OnTextBoxLeave);
            // 
            // txtRowHeightMm
            // 
            this.txtRowHeightMm.Location = new System.Drawing.Point(148, 189);
            this.txtRowHeightMm.Name = "txtRowHeightMm";
            this.txtRowHeightMm.Size = new System.Drawing.Size(72, 20);
            this.txtRowHeightMm.TabIndex = 13;
            this.txtRowHeightMm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnTextBoxLeaveKeyDown);
            this.txtRowHeightMm.Leave += new System.EventHandler(this.OnTextBoxLeave);
            // 
            // txtRowHeightPixel
            // 
            this.txtRowHeightPixel.Location = new System.Drawing.Point(59, 189);
            this.txtRowHeightPixel.Name = "txtRowHeightPixel";
            this.txtRowHeightPixel.Size = new System.Drawing.Size(72, 20);
            this.txtRowHeightPixel.TabIndex = 11;
            this.txtRowHeightPixel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnTextBoxLeaveKeyDown);
            this.txtRowHeightPixel.Leave += new System.EventHandler(this.OnTextBoxLeave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 192);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "RHeight";
            // 
            // cbColList
            // 
            this.cbColList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColList.FormattingEnabled = true;
            this.cbColList.Location = new System.Drawing.Point(56, 47);
            this.cbColList.Name = "cbColList";
            this.cbColList.Size = new System.Drawing.Size(161, 21);
            this.cbColList.TabIndex = 1;
            this.cbColList.SelectedIndexChanged += new System.EventHandler(this.cbColList_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnColFont);
            this.groupBox1.Controls.Add(this.btnDown);
            this.groupBox1.Controls.Add(this.btnUp);
            this.groupBox1.Controls.Add(this.btnDel);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.lblIndex);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtColFont);
            this.groupBox1.Controls.Add(this.txtColWidthMm);
            this.groupBox1.Controls.Add(this.txtColWidthPixel);
            this.groupBox1.Controls.Add(this.txtColTitle);
            this.groupBox1.Controls.Add(this.txtColName);
            this.groupBox1.Controls.Add(this.cbColList);
            this.groupBox1.Location = new System.Drawing.Point(3, 292);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(231, 176);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "列设置";
            // 
            // btnColFont
            // 
            this.btnColFont.Location = new System.Drawing.Point(8, 151);
            this.btnColFont.Name = "btnColFont";
            this.btnColFont.Size = new System.Drawing.Size(38, 21);
            this.btnColFont.TabIndex = 6;
            this.btnColFont.Text = "Font";
            this.btnColFont.UseVisualStyleBackColor = true;
            this.btnColFont.Click += new System.EventHandler(this.btnColFont_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(172, 19);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(45, 21);
            this.btnDown.TabIndex = 10;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnMoveColumn_Click);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(128, 19);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(45, 21);
            this.btnUp.TabIndex = 9;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = true;
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(8, 46);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(38, 21);
            this.btnDel.TabIndex = 8;
            this.btnDel.Text = "Del";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(8, 19);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(38, 21);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 128);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "Width";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 102);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 13);
            this.label12.TabIndex = 16;
            this.label12.Text = "Title";
            // 
            // lblIndex
            // 
            this.lblIndex.AutoSize = true;
            this.lblIndex.Location = new System.Drawing.Point(56, 23);
            this.lblIndex.Name = "lblIndex";
            this.lblIndex.Size = new System.Drawing.Size(45, 13);
            this.lblIndex.TabIndex = 16;
            this.lblIndex.Text = "Index: 0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 76);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Name";
            // 
            // txtColFont
            // 
            this.txtColFont.BackColor = System.Drawing.SystemColors.Menu;
            this.txtColFont.Location = new System.Drawing.Point(56, 151);
            this.txtColFont.Name = "txtColFont";
            this.txtColFont.Size = new System.Drawing.Size(161, 20);
            this.txtColFont.TabIndex = 13;
            // 
            // txtColWidthMm
            // 
            this.txtColWidthMm.Location = new System.Drawing.Point(145, 125);
            this.txtColWidthMm.Name = "txtColWidthMm";
            this.txtColWidthMm.Size = new System.Drawing.Size(72, 20);
            this.txtColWidthMm.TabIndex = 5;
            this.txtColWidthMm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnTextBoxLeaveKeyDown);
            this.txtColWidthMm.Leave += new System.EventHandler(this.OnTextBoxLeave);
            // 
            // txtColWidthPixel
            // 
            this.txtColWidthPixel.Location = new System.Drawing.Point(56, 125);
            this.txtColWidthPixel.Name = "txtColWidthPixel";
            this.txtColWidthPixel.Size = new System.Drawing.Size(72, 20);
            this.txtColWidthPixel.TabIndex = 4;
            this.txtColWidthPixel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnTextBoxLeaveKeyDown);
            this.txtColWidthPixel.Leave += new System.EventHandler(this.OnTextBoxLeave);
            // 
            // txtColTitle
            // 
            this.txtColTitle.Location = new System.Drawing.Point(56, 99);
            this.txtColTitle.Name = "txtColTitle";
            this.txtColTitle.Size = new System.Drawing.Size(161, 20);
            this.txtColTitle.TabIndex = 3;
            this.txtColTitle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnTextBoxLeaveKeyDown);
            this.txtColTitle.Leave += new System.EventHandler(this.OnTextBoxLeave);
            // 
            // txtColName
            // 
            this.txtColName.Location = new System.Drawing.Point(56, 73);
            this.txtColName.Name = "txtColName";
            this.txtColName.Size = new System.Drawing.Size(161, 20);
            this.txtColName.TabIndex = 2;
            this.txtColName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnTextBoxLeaveKeyDown);
            this.txtColName.Leave += new System.EventHandler(this.OnTextBoxLeave);
            // 
            // btnRowFont
            // 
            this.btnRowFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRowFont.Location = new System.Drawing.Point(11, 241);
            this.btnRowFont.Name = "btnRowFont";
            this.btnRowFont.Size = new System.Drawing.Size(38, 21);
            this.btnRowFont.TabIndex = 14;
            this.btnRowFont.Text = "Row";
            this.btnRowFont.UseVisualStyleBackColor = true;
            this.btnRowFont.Click += new System.EventHandler(this.btnRowFont_Click);
            // 
            // txtRowFont
            // 
            this.txtRowFont.BackColor = System.Drawing.SystemColors.Menu;
            this.txtRowFont.Location = new System.Drawing.Point(59, 241);
            this.txtRowFont.Name = "txtRowFont";
            this.txtRowFont.Size = new System.Drawing.Size(161, 20);
            this.txtRowFont.TabIndex = 18;
            // 
            // btnFont
            // 
            this.btnFont.Location = new System.Drawing.Point(12, 151);
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size(38, 21);
            this.btnFont.TabIndex = 17;
            this.btnFont.Text = "Font";
            this.btnFont.UseVisualStyleBackColor = true;
            // 
            // txtFont
            // 
            this.txtFont.BackColor = System.Drawing.SystemColors.Menu;
            this.txtFont.Location = new System.Drawing.Point(56, 151);
            this.txtFont.Name = "txtFont";
            this.txtFont.Size = new System.Drawing.Size(161, 20);
            this.txtFont.TabIndex = 13;
            // 
            // txtRowCount
            // 
            this.txtRowCount.Location = new System.Drawing.Point(59, 215);
            this.txtRowCount.Name = "txtRowCount";
            this.txtRowCount.Size = new System.Drawing.Size(161, 20);
            this.txtRowCount.TabIndex = 11;
            this.txtRowCount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnTextBoxLeaveKeyDown);
            this.txtRowCount.Leave += new System.EventHandler(this.OnTextBoxLeave);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 218);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 13);
            this.label13.TabIndex = 14;
            this.label13.Text = "RCount";
            // 
            // ckShowTableTitle
            // 
            this.ckShowTableTitle.AutoSize = true;
            this.ckShowTableTitle.Location = new System.Drawing.Point(10, 269);
            this.ckShowTableTitle.Name = "ckShowTableTitle";
            this.ckShowTableTitle.Size = new System.Drawing.Size(74, 17);
            this.ckShowTableTitle.TabIndex = 19;
            this.ckShowTableTitle.Text = "显示标题";
            this.ckShowTableTitle.UseVisualStyleBackColor = true;
            this.ckShowTableTitle.CheckedChanged += new System.EventHandler(this.ckShowTableTitle_CheckedChanged);
            // 
            // cbShowTableBorder
            // 
            this.cbShowTableBorder.AutoSize = true;
            this.cbShowTableBorder.Location = new System.Drawing.Point(120, 269);
            this.cbShowTableBorder.Name = "cbShowTableBorder";
            this.cbShowTableBorder.Size = new System.Drawing.Size(74, 17);
            this.cbShowTableBorder.TabIndex = 19;
            this.cbShowTableBorder.Text = "显示边框";
            this.cbShowTableBorder.UseVisualStyleBackColor = true;
            this.cbShowTableBorder.CheckedChanged += new System.EventHandler(this.cbShowTableBorder_CheckedChanged);
            // 
            // wTableEditer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbShowTableBorder);
            this.Controls.Add(this.ckShowTableTitle);
            this.Controls.Add(this.btnRowFont);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtRowFont);
            this.Controls.Add(this.txtRowHeightMm);
            this.Controls.Add(this.txtRowCount);
            this.Controls.Add(this.txtRowHeightPixel);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtTitleHeightMm);
            this.Controls.Add(this.txtTitleHeightPixel);
            this.Controls.Add(this.label8);
            this.MinimumSize = new System.Drawing.Size(241, 384);
            this.Name = "wTableEditer";
            this.Size = new System.Drawing.Size(241, 480);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.txtTitleHeightPixel, 0);
            this.Controls.SetChildIndex(this.txtTitleHeightMm, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.txtRowHeightPixel, 0);
            this.Controls.SetChildIndex(this.txtRowCount, 0);
            this.Controls.SetChildIndex(this.txtRowHeightMm, 0);
            this.Controls.SetChildIndex(this.txtRowFont, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnRowFont, 0);
            this.Controls.SetChildIndex(this.ckShowTableTitle, 0);
            this.Controls.SetChildIndex(this.cbShowTableBorder, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTitleHeightPixel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTitleHeightMm;
        private System.Windows.Forms.TextBox txtRowHeightMm;
        private System.Windows.Forms.TextBox txtRowHeightPixel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbColList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnColFont;
        private System.Windows.Forms.TextBox txtColName;
        private System.Windows.Forms.TextBox txtColFont;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtColWidthMm;
        private System.Windows.Forms.TextBox txtColWidthPixel;
        private System.Windows.Forms.TextBox txtColTitle;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Label lblIndex;
        private System.Windows.Forms.Button btnRowFont;
        private System.Windows.Forms.TextBox txtRowFont;
        private System.Windows.Forms.Button btnFont;
        private System.Windows.Forms.TextBox txtFont;
        private System.Windows.Forms.TextBox txtRowCount;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox ckShowTableTitle;
        private System.Windows.Forms.CheckBox cbShowTableBorder;
    }
}
