/*
 * Copyright (C) 2016-2018
 * 由SharpDevelop创建。
 * 作者: Byron Gong
 * 日期: 03/05/2018 时间: 10:51
 * 邮箱: 1032066879@QQ.com
 * 描述: 模版打印
 *
 */ 
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Spoon.Tools.TemplatePrint.Controls;

namespace Spoon.Tools.TemplatePrint
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
//		private Point m_scrollPos=Point.Empty;
		/// <summary>
		/// 编辑面板
		/// </summary>
		private Control m_property=null;
		
		/// <summary>
		/// 工作区文件夹路径
		/// </summary>
		private string m_workplacePath=string.Empty;
		
		/// <summary>
		/// 文件路径
		/// </summary>
		private string m_layoutPath=string.Empty;
		
		/// <summary>
		/// 标识是否已保存
		/// </summary>
		private bool m_isSaved=false;
		
		/// <summary>
		/// 绑定数据(Excel文件)
		/// </summary>
		private string m_dataPath=string.Empty;
		
		/// <summary>
		/// 默认打印机
		/// </summary>
		private string m_defaultPrinter=string.Empty;
		
		#region 属性
		/// <summary>
		/// 打开的文件路径
		/// </summary>
		public string LayoutPath{
			get{return m_layoutPath;}
			set{
				m_layoutPath=value;
				if(value!=string.Empty){
					Text=string.Format("模版编辑器V2.0 - [{0}]",m_layoutPath);
				}else{
					Text="模版编辑器V2.0";
				}
			}
		}
		
		/// <summary>
		/// 标识是否保存
		/// </summary>
		public bool IsSaved{
			get{return m_isSaved;}
			set{
				m_isSaved=value;
				Text=(value?string.Empty:"*")+Text.TrimStart('*');
			}
		}
		
		#endregion
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			wExplorer1.Canvas=canvas21;
			
			var m_lbl=new wLabel();
			m_lbl.Name="hello";
			m_lbl.Text="test";
			m_lbl.VeticalAlignment=StringAlignment.Center;
			m_lbl.HorizontalAlignment=StringAlignment.Center;
			m_lbl.Location=new Point(10,50);
			
			canvas21.Controls.Add(m_lbl);
			
			canvas21.SelectControlChangedEvent += new EventHandler(
				delegate(object sender, EventArgs args) {
					IsSaved=false;
					var ctl = canvas21.SelectControl;
					if (m_property != null) {
						m_property.Parent.Controls.Remove(m_property);
						m_property.Dispose();
						m_property = null;
					}
					if (ctl != null) {
						if (ctl is wLabel) {
							m_property = new Editer.wLabelEditer(ctl as wLabel);
						} else if (ctl is wImage) {
							m_property = new Spoon.Tools.TemplatePrint.Editer.wImageEditer(ctl as wImage);
						} else if (ctl is wBarcode) {
							m_property = new Spoon.Tools.TemplatePrint.Editer.wBarcodeEditer(ctl as wBarcode);
						} else if (ctl is wQRCoder) {
							m_property=new Spoon.Tools.TemplatePrint.Editer.wQRCoderEditer(ctl as wQRCoder);
						}else{
							m_property = new Spoon.Tools.TemplatePrint.Editer.wControlEditer(canvas21.SelectControl);
						}
					} else {
						m_property=new Spoon.Tools.TemplatePrint.Editer.wCanvasEditer(canvas21);
					}
					tabPage1.Controls.Add(m_property);
					m_property.Dock = DockStyle.Fill;
				}
			);
			
//			canvas21.LostFocus+=new EventHandler(
//				delegate(object sender,EventArgs e){
//					m_scrollPos.X=(canvas21.Parent as Panel).HorizontalScroll.Value;// splitContainer1.Panel1.HorizontalScroll.Value;
//					m_scrollPos.Y=(canvas21.Parent as Panel).VerticalScroll.Value;//splitContainer1.Panel1.VerticalScroll.Value;
//					System.Diagnostics.Debug.WriteLine(string.Format("Lost {0},{1}",m_scrollPos.X,m_scrollPos.Y));
//				}
//			);
//			canvas21.GotFocus+=new EventHandler(
//				delegate(object sender,EventArgs e){
//					splitContainer1.Panel1.HorizontalScroll.Value=m_scrollPos.X;
//					splitContainer1.Panel1.VerticalScroll.Value=m_scrollPos.Y;
//					System.Diagnostics.Debug.WriteLine(string.Format("Got {0},{1}",m_scrollPos.X,m_scrollPos.Y));
//				}
//			);
			
			if(Helper.CommandHelper.Configs.ContainsKey("file")){
				OpenFile(Helper.CommandHelper.Configs["file"]);
			}
			if(Helper.CommandHelper.Configs.ContainsKey("set-printername")){
				m_defaultPrinter=Helper.CommandHelper.Configs["set-printername"];
			}
			if(Helper.CommandHelper.Configs.ContainsKey("set-data-excel")){
				m_dataPath=Helper.CommandHelper.Configs["set-data-excel"];
			}
		}
		
		public void OnAddButonClick(object sender,EventArgs arg){
			IsSaved=false;
			var btn=sender as ToolStripButton;
			switch (btn.Name) {
				case "sbLabel":
					var lbl=new wLabel();
					lbl.Name="label";
					lbl.Text="test";
					lbl.Location=new Point(10,50);
					canvas21.Controls.Add(lbl);
					break;
				case "sbBarcode":
					var barcode=new wBarcode();
					barcode.Name="Barcode";
					barcode.EncodeType=BarcodeLib.TYPE.CODE128;
					barcode.Location=new Point(10,50);
					barcode.Text="E123456";
					canvas21.Controls.Add(barcode);
					break;
				case "sbImage":
					var img=new wImage();
					img.Name="image";
					img.Location=new Point(10,50);
					canvas21.Controls.Add(img);
					break;
				case "sbQRCoder":
					var qrcode=new wQRCoder();
					qrcode.Name="qrcode";
					qrcode.Text="hello";
					qrcode.Location=new Point(10,50);
					canvas21.Controls.Add(qrcode);
					break;
			}
			canvas21.SelectControl=canvas21.Controls[canvas21.Controls.Count-1];
			canvas21.Refresh();
		}
		void 打开OToolStripMenuItemClick(object sender, EventArgs e)
		{
			using (var ofd=new OpenFileDialog()) {
				ofd.Filter="布局文件(*.bg)|*.bg|所有文件(*.*)|*.*";
				if(ofd.ShowDialog()==DialogResult.OK){
					OpenFile(ofd.FileName);
				}
			}
		}
		
		/// <summary>
		/// 打开布局文件
		/// </summary>
		/// <param name="filename"></param>
		private void OpenFile(string filename)
		{
			if (m_workplacePath != string.Empty) {
				System.IO.Directory.Delete(m_workplacePath, true);
			}
			m_workplacePath = Helper.UnitHelper.GetTemplateFolderName();
					
			Helper.UnitHelper.UnArchiveFiles(filename, m_workplacePath);
			
			var doc = new System.Xml.XmlDocument();
			LayoutPath = filename;
			doc.Load(System.IO.Path.Combine(m_workplacePath,"layout.xml"));
			canvas21.Init(doc);
			doc=null;
			IsSaved = true;
		}
		
		void 保存SToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(LayoutPath==string.Empty){
				using (var sfd=new SaveFileDialog()) {
					sfd.Filter="布局文件(*.bg)|*.bg|所有文件(*.*)|*.*";
					if(sfd.ShowDialog()==DialogResult.OK){
						LayoutPath=sfd.FileName;
					}
				}
			}
			if(LayoutPath!=string.Empty){
				var doc=Helper.XmlHelper.NewDocment();
				doc.AppendChild(canvas21.ToXml(doc));
				Helper.UnitHelper.ArchiveFiles(doc,LayoutPath);
				IsSaved=true;
			}
		}
		void 新建NToolStripMenuItemClick(object sender, EventArgs e)
		{
			LayoutPath=string.Empty;
			System.Xml.XmlDocument doc=new System.Xml.XmlDocument();
			doc.LoadXml(RES.Template_New);
			canvas21.Init(doc);
			canvas21.Author=string.Empty;
			IsSaved=false;
		}
		void 打印预览ToolStripMenuItemClick(object sender, EventArgs e)
		{
			var printername=m_defaultPrinter;
			if (printername == string.Empty) {
				var printer = new InputPrinter();
				if (printer.ShowDialog(this) == DialogResult.OK) {
					printername=printer.PrinterName;
				}else{
					return;
				}
			}
			
			var doc = new Helper.PrintHelper(printername, Helper.PrintHelper.DisplayToMm(canvas21.Width), Helper.PrintHelper.DisplayToMm(canvas21.Height));
			doc.Canvas = canvas21;
			if (m_dataPath != string.Empty) {
				doc.Data = Helper.ExcelHelper.ExcelToTemplateData(m_dataPath, "sheet1");
			}
		
			PrintPreviewDialog pp = new PrintPreviewDialog();
			pp.Document = doc;
			pp.ShowDialog();
		}
		void 关于AToolStripMenuItemClick(object sender, EventArgs e)
		{
			var about=new About();
			about.ShowDialog(this);
		}
		
		void OnOpenDragDrop(object sender, DragEventArgs e)
		{
			if(e.Data.GetDataPresent(DataFormats.FileDrop)){
				var files=e.Data.GetData(DataFormats.FileDrop) as string[];
				OpenFile(files[0]);
			}
		}
		void OnOpenDragEnter(object sender, DragEventArgs e)
		{
			if(e.Data.GetDataPresent(DataFormats.FileDrop)){
				e.Effect=DragDropEffects.Copy;
			}
		}
		protected override void OnFormClosed(FormClosedEventArgs e)
		{
			base.OnFormClosed(e);
			if(m_workplacePath!=string.Empty){
				System.IO.Directory.Delete(m_workplacePath,true);
			}
		}
		void 另存为ASToolStripMenuItemClick(object sender, EventArgs e)
		{
			LayoutPath=string.Empty;
			保存SToolStripMenuItemClick(保存SToolStripMenuItem,EventArgs.Empty);
		}
		void 绑定数据ToolStripMenuItemClick(object sender, EventArgs e)
		{
			using (var ofd=new OpenFileDialog()) {
				ofd.Filter="数据文件(*.xls;*.xlsx)|*.xls;*.xlsx|所有文件(*.*)|*.*";
				if(ofd.ShowDialog()==DialogResult.OK){
					m_dataPath=ofd.FileName;
				}
			}
		}
	}
}
