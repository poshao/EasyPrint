/*
 * Copyright (C) 2016-2018
 * 由SharpDevelop创建。
 * 作者: Byron Gong
 * 日期: 03/05/2018 时间: 10:51
 * 邮箱: 1032066879@QQ.com
 * 描述: 
 *
 */ 
namespace Spoon.Tools.TemplatePrint
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private Spoon.Tools.TemplatePrint.wCanvas canvas21;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private Spoon.Tools.TemplatePrint.wExplorer wExplorer1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 打开OToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 保存SToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 关于AToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 新建NToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 打印PToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 打印预览ToolStripMenuItem;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton sbLabel;
		private System.Windows.Forms.ToolStripButton sbImage;
		private System.Windows.Forms.ToolStripButton sbBarcode;
		private System.Windows.Forms.ToolStripButton sbQRCoder;
		private System.Windows.Forms.ToolStripMenuItem 另存为ASToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 绑定数据ToolStripMenuItem;
		private System.Windows.Forms.ToolStripButton sbTable;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建NToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.另存为ASToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打印PToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打印预览ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绑定数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.sbLabel = new System.Windows.Forms.ToolStripButton();
            this.sbImage = new System.Windows.Forms.ToolStripButton();
            this.sbBarcode = new System.Windows.Forms.ToolStripButton();
            this.sbQRCoder = new System.Windows.Forms.ToolStripButton();
            this.sbTable = new System.Windows.Forms.ToolStripButton();
            this.wExplorer1 = new Spoon.Tools.TemplatePrint.wExplorer();
            this.canvas21 = new Spoon.Tools.TemplatePrint.wCanvas();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.AutoScrollMinSize = new System.Drawing.Size(1, 1);
            this.splitContainer1.Panel1.Controls.Add(this.canvas21);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(583, 325);
            this.splitContainer1.SplitterDistance = 309;
            this.splitContainer1.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(270, 325);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(262, 299);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "属性";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 81);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.wExplorer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(778, 325);
            this.splitContainer2.SplitterDistance = 191;
            this.splitContainer2.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem,
            this.打印PToolStripMenuItem,
            this.帮助HToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(778, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件FToolStripMenuItem
            // 
            this.文件FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建NToolStripMenuItem,
            this.打开OToolStripMenuItem,
            this.保存SToolStripMenuItem,
            this.另存为ASToolStripMenuItem});
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.文件FToolStripMenuItem.Text = "文件(&F)";
            // 
            // 新建NToolStripMenuItem
            // 
            this.新建NToolStripMenuItem.Name = "新建NToolStripMenuItem";
            this.新建NToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.新建NToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.新建NToolStripMenuItem.Text = "新建(&N)";
            this.新建NToolStripMenuItem.Click += new System.EventHandler(this.新建NToolStripMenuItemClick);
            // 
            // 打开OToolStripMenuItem
            // 
            this.打开OToolStripMenuItem.Name = "打开OToolStripMenuItem";
            this.打开OToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.打开OToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.打开OToolStripMenuItem.Text = "打开(&O)";
            this.打开OToolStripMenuItem.Click += new System.EventHandler(this.打开OToolStripMenuItemClick);
            // 
            // 保存SToolStripMenuItem
            // 
            this.保存SToolStripMenuItem.Name = "保存SToolStripMenuItem";
            this.保存SToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.保存SToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.保存SToolStripMenuItem.Text = "保存(&S)";
            this.保存SToolStripMenuItem.Click += new System.EventHandler(this.保存SToolStripMenuItemClick);
            // 
            // 另存为ASToolStripMenuItem
            // 
            this.另存为ASToolStripMenuItem.Name = "另存为ASToolStripMenuItem";
            this.另存为ASToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.另存为ASToolStripMenuItem.Text = "另存为...";
            this.另存为ASToolStripMenuItem.Click += new System.EventHandler(this.另存为ASToolStripMenuItemClick);
            // 
            // 打印PToolStripMenuItem
            // 
            this.打印PToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打印预览ToolStripMenuItem,
            this.绑定数据ToolStripMenuItem});
            this.打印PToolStripMenuItem.Name = "打印PToolStripMenuItem";
            this.打印PToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.打印PToolStripMenuItem.Text = "打印(&P)";
            // 
            // 打印预览ToolStripMenuItem
            // 
            this.打印预览ToolStripMenuItem.Name = "打印预览ToolStripMenuItem";
            this.打印预览ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.打印预览ToolStripMenuItem.Text = "打印预览";
            this.打印预览ToolStripMenuItem.Click += new System.EventHandler(this.打印预览ToolStripMenuItemClick);
            // 
            // 绑定数据ToolStripMenuItem
            // 
            this.绑定数据ToolStripMenuItem.Name = "绑定数据ToolStripMenuItem";
            this.绑定数据ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.绑定数据ToolStripMenuItem.Text = "绑定数据";
            this.绑定数据ToolStripMenuItem.Click += new System.EventHandler(this.绑定数据ToolStripMenuItemClick);
            // 
            // 帮助HToolStripMenuItem
            // 
            this.帮助HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于AToolStripMenuItem});
            this.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            this.帮助HToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.帮助HToolStripMenuItem.Text = "帮助(&H)";
            // 
            // 关于AToolStripMenuItem
            // 
            this.关于AToolStripMenuItem.Name = "关于AToolStripMenuItem";
            this.关于AToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.关于AToolStripMenuItem.Text = "关于(&A)";
            this.关于AToolStripMenuItem.Click += new System.EventHandler(this.关于AToolStripMenuItemClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbLabel,
            this.sbImage,
            this.sbBarcode,
            this.sbQRCoder,
            this.sbTable});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(778, 54);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // sbLabel
            // 
            this.sbLabel.Image = ((System.Drawing.Image)(resources.GetObject("sbLabel.Image")));
            this.sbLabel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbLabel.Margin = new System.Windows.Forms.Padding(4, 1, 4, 2);
            this.sbLabel.Name = "sbLabel";
            this.sbLabel.Size = new System.Drawing.Size(39, 51);
            this.sbLabel.Text = "Label";
            this.sbLabel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.sbLabel.Click += new System.EventHandler(this.OnAddButonClick);
            // 
            // sbImage
            // 
            this.sbImage.Image = ((System.Drawing.Image)(resources.GetObject("sbImage.Image")));
            this.sbImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbImage.Name = "sbImage";
            this.sbImage.Size = new System.Drawing.Size(44, 51);
            this.sbImage.Text = "Image";
            this.sbImage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.sbImage.Click += new System.EventHandler(this.OnAddButonClick);
            // 
            // sbBarcode
            // 
            this.sbBarcode.Image = ((System.Drawing.Image)(resources.GetObject("sbBarcode.Image")));
            this.sbBarcode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbBarcode.Name = "sbBarcode";
            this.sbBarcode.Size = new System.Drawing.Size(54, 51);
            this.sbBarcode.Text = "Barcode";
            this.sbBarcode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.sbBarcode.Click += new System.EventHandler(this.OnAddButonClick);
            // 
            // sbQRCoder
            // 
            this.sbQRCoder.Image = ((System.Drawing.Image)(resources.GetObject("sbQRCoder.Image")));
            this.sbQRCoder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbQRCoder.Name = "sbQRCoder";
            this.sbQRCoder.Size = new System.Drawing.Size(59, 51);
            this.sbQRCoder.Text = "QRCoder";
            this.sbQRCoder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.sbQRCoder.Click += new System.EventHandler(this.OnAddButonClick);
            // 
            // sbTable
            // 
            this.sbTable.Image = ((System.Drawing.Image)(resources.GetObject("sbTable.Image")));
            this.sbTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbTable.Name = "sbTable";
            this.sbTable.Size = new System.Drawing.Size(40, 51);
            this.sbTable.Text = "Table";
            this.sbTable.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.sbTable.Click += new System.EventHandler(this.OnAddButonClick);
            // 
            // wExplorer1
            // 
            this.wExplorer1.AllowDrop = true;
            this.wExplorer1.Canvas = null;
            this.wExplorer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wExplorer1.Location = new System.Drawing.Point(0, 0);
            this.wExplorer1.Name = "wExplorer1";
            this.wExplorer1.Size = new System.Drawing.Size(191, 325);
            this.wExplorer1.TabIndex = 0;
            this.wExplorer1.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnOpenDragDrop);
            this.wExplorer1.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnOpenDragEnter);
            // 
            // canvas21
            // 
            this.canvas21.AllowDrop = true;
            this.canvas21.Author = "0115289";
            this.canvas21.BackColor = System.Drawing.Color.White;
            this.canvas21.BackgroundPath = "";
            this.canvas21.BackgroundRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.canvas21.BackgroundScale = 0F;
            this.canvas21.CreateTime = new System.DateTime(2018, 3, 7, 15, 52, 26, 689);
            this.canvas21.Location = new System.Drawing.Point(0, 0);
            this.canvas21.Name = "canvas21";
            this.canvas21.SelectControl = null;
            this.canvas21.ShowBackground = true;
            this.canvas21.Size = new System.Drawing.Size(800, 600);
            this.canvas21.TabIndex = 0;
            this.canvas21.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnOpenDragDrop);
            this.canvas21.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnOpenDragEnter);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 410);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainForm";
            this.Text = "模板编辑器V2.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
	}
}
