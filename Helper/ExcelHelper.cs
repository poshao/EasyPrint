/*
 * Copyright (C) 2016-2018
 * 由SharpDevelop创建。
 * 作者: Byron Gong
 * 日期: 03/16/2018 时间: 11:06
 * 邮箱: 1032066879@QQ.com
 * 描述: Excel操作辅助类
 *
 */ 
using System;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;

namespace Spoon.Tools.TemplatePrint.Helper
{
	/// <summary>
	/// Excel操作辅助类
	/// </summary>
	public class ExcelHelper
	{
		private static IWorkbook m_book=null;
		
		public ExcelHelper()
		{
		}
		
		public static System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>> ExcelToTemplateData(string filename,string sheetname){
			var fs=new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite);
			
			switch (Path.GetExtension(filename)) {
				case ".xlsx":
				case ".xlsm":
				case ".xlam":
					m_book=new XSSFWorkbook(fs);//2007+版本
					break;
				case ".xls":
				case ".xla":
					m_book=new HSSFWorkbook(fs);//2003版本
					break;
			}
			
			var list=new System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>();
			
			var sheet=m_book.GetSheet(sheetname);
			var firstRow=sheet.GetRow(0);
			
			for (int i = 1; i <= sheet.LastRowNum; i++) {
				var row=sheet.GetRow(i);
				if(row==null) continue;
				
				var item=new System.Collections.Generic.Dictionary<string,string>();
				for (int j = 0; j < firstRow.LastCellNum; j++) {
					if(firstRow.Cells[j]==null) continue;
					var cell=row.Cells[j];
					
					item.Add(sheet.GetRow(0).Cells[j].StringCellValue,cell==null?string.Empty:cell.StringCellValue);
				}
				list.Add(item);
			}
			fs.Close();
			fs.Dispose();
			
			return list;
		}
		
		public static void Open(string filename){
			var fs=new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite);
			
			switch (Path.GetExtension(filename)) {
				case ".xlsx":
				case ".xlsm":
				case ".xlam":
					m_book=new XSSFWorkbook(fs);//2007+版本
					break;
				case ".xls":
				case ".xla":
					m_book=new HSSFWorkbook(fs);//2003版本
					break;
			}

			System.Diagnostics.Debug.WriteLine(m_book.GetSheetName(m_book.ActiveSheetIndex));
			System.Diagnostics.Debug.WriteLine(m_book.GetSheetAt(m_book.ActiveSheetIndex).LastRowNum.ToString());
			
			fs.Close();
			fs.Dispose();
		}
	}
}
