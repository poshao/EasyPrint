/*
 * Copyright (C) 2016-2018
 * 由SharpDevelop创建。
 * 作者: Byron Gong
 * 日期: 02/08/2018 时间: 9:12
 * 邮箱: 1032066879@QQ.com
 * 描述: 选择打印机名称
 *
 */ 
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Spoon.Tools.TemplatePrint
{
	/// <summary>
	/// Description of InputPrinter.
	/// </summary>
	public partial class InputPrinter : Form
	{
		private string m_printerName="";
		
		public string PrinterName{
			get{
				return m_printerName;
			}
		}
		
		public InputPrinter()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			lstPrinters.Items.Clear();
			var doc=new System.Drawing.Printing.PrintDocument();
			string printName=doc.PrinterSettings.PrinterName;
			var printers=System.Drawing.Printing.PrinterSettings.InstalledPrinters;
			for (int i = 0; i < printers.Count; i++) {
				lstPrinters.Items.Add(printers[i]);
				if(printers[i]==printName){
					lstPrinters.SelectedIndex=i;
				}
			}
		}
		void BtnCancelClick(object sender, EventArgs e)
		{
			DialogResult=DialogResult.Cancel;
		}
		void BtnOKClick(object sender, EventArgs e)
		{
			if(lstPrinters.Text==""){
				MessageBox.Show("请选择打印机");
				return;
			}
			m_printerName=lstPrinters.Text;
			DialogResult=DialogResult.OK;
		}
		void LstPrintersDoubleClick(object sender, EventArgs e)
		{
			btnOK.PerformClick();
		}
	}
}
