/*
 * Copyright (C) 2016-2018
 * 由SharpDevelop创建。
 * 作者: Byron Gong
 * 日期: 03/16/2018 时间: 10:54
 * 邮箱: 1032066879@QQ.com
 * 描述: 
 *
 */ 
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Spoon.Tools.TemplatePrint
{
	/// <summary>
	/// Description of TestForm.
	/// </summary>
	public partial class TestForm : Form
	{
		public TestForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void BtnReadExcelClick(object sender, EventArgs e)
		{
			using (var ofd =new OpenFileDialog()) {
				if(ofd.ShowDialog()==DialogResult.OK){
					Helper.ExcelHelper.Open(ofd.FileName);
				}
			}
		}
	}
}
