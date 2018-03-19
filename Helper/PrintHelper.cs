/*
 * Copyright (C) 2016-2018
 * 由SharpDevelop创建。
 * 作者: Byron Gong
 * 日期: 03/07/2018 时间: 14:55
 * 邮箱: 1032066879@QQ.com
 * 描述: 打印辅助类
 *
 */ 
using System;
using System.Drawing;
using System.Drawing.Printing;

namespace Spoon.Tools.TemplatePrint.Helper
{
	/// <summary>
	/// Description of PrintHelper.
	/// </summary>
	public class PrintHelper:PrintDocument
	{
		public class wPrintEventArgs:EventArgs{
			public Graphics Graphics{
				get;set;
			}
			public Point Offset{
				get;set;
			}
			public wPrintEventArgs(Graphics g,Point offset){
				Graphics=g;
				Offset=offset;
			}
		}
		private wCanvas m_canvas=null;
		private System.Collections.Generic.List<System.Collections.Generic.Dictionary<string,string>> m_datalist=null;
		private int m_printPageIndex=0;
		
		//打印相关
		private string m_printerName="";
		private SizeF m_paper=SizeF.Empty;
		private PaperSize m_papersize=null;
		private Point m_offset=Point.Empty;
		
		/// <summary>
		/// 打印机名称
		/// </summary>
		public string PrinterName{
			get{return m_printerName;}
			set{
				if(!ExistsPrinter(value)){
					throw new Exception("无效打印机[" + value + "]");
				}
				m_printerName=value;
			}
		}
		
		/// <summary>
		/// 纸张大小(毫米)
		/// </summary>
		public SizeF PaperSize{
			get{return m_paper;}
			set{
				m_paper=value;
				if (m_papersize==null) {
					m_papersize=new System.Drawing.Printing.PaperSize("byron_custom",100,100);
				}
				m_papersize.Width = (int)(value.Width / 25.4 * 100);
				m_papersize.Height = (int)(value.Height / 25.4 * 100);
			}
		}
		
		/// <summary>
		/// 打印偏移量
		/// </summary>
		public Point Offset{
			get{return m_offset;}
			set{m_offset=value;}
		}
		
		/// <summary>
		/// 打印偏移量(毫米)
		/// </summary>
		public PointF OffsetMm{
			get{return new PointF(Helper.PrintHelper.DisplayToMm(m_offset.X),Helper.PrintHelper.DisplayToMm(m_offset.Y));}
			set{m_offset=new Point(Helper.PrintHelper.MmToDisplay(value.X),Helper.PrintHelper.MmToDisplay(value.Y));}
		}
		
		/// <summary>
		/// 打印画布
		/// </summary>
		public wCanvas Canvas{
			get{return m_canvas;}
			set{m_canvas=value;}
		}
		
		public System.Collections.Generic.List<System.Collections.Generic.Dictionary<string,string>> Data{
			get{return m_datalist;}
			set{m_datalist=value;}
		}
		
		public PrintHelper()
		{
			DocumentName=Environment.GetEnvironmentVariable("computername")+"_"+Environment.GetEnvironmentVariable("username");
		}
		
		public PrintHelper(string printerName,float width,float height){
			PrinterName=printerName;
			PaperSize=new SizeF(width,height);
			DocumentName=Environment.GetEnvironmentVariable("computername")+"_"+Environment.GetEnvironmentVariable("username");
		}
		
		protected override void OnBeginPrint(PrintEventArgs e)
		{
			base.OnBeginPrint(e);
			//检查
			if(m_canvas==null){
				throw new Exception("无法打印,未设置打印内容");
			}
			if(!ExistsPrinter(m_printerName)){
				throw new Exception("无法打印,找不到指定打印机[" + m_printerName + "]");
			}
			if(m_papersize.Equals(Size.Empty)){
				throw new Exception("无法打印,未设定纸张大小");
			}
			m_printPageIndex=0;
			
			PrinterSettings.PrinterName=m_printerName;
			DefaultPageSettings.PaperSize=m_papersize;
		}
		
		protected override void OnPrintPage(PrintPageEventArgs e)
		{
			base.OnPrintPage(e);
			wPrintEventArgs arg=new wPrintEventArgs(e.Graphics,m_offset);
			if(m_datalist!=null){
				Canvas.DoPrint(m_datalist[m_printPageIndex],arg);
				e.HasMorePages=++m_printPageIndex<m_datalist.Count;
			}else{
				Canvas.DoPrint(null,arg);
			}
		}
		
		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			if(m_canvas!=null){
				m_canvas.Dispose();
			}
		}
		
		/// <summary>
		/// 将像素单位转为毫米
		/// </summary>
		/// <param name="pixel"></param>
		/// <returns></returns>
		public static float DisplayToMm(int pixel){
			//百分之一毫米
			var m=System.Drawing.Printing.PrinterUnitConvert.Convert(pixel,System.Drawing.Printing.PrinterUnit.Display,System.Drawing.Printing.PrinterUnit.HundredthsOfAMillimeter);
			return m/100.0F;
		}
		
		/// <summary>
		/// 将毫米转为像素
		/// </summary>
		/// <param name="mm"></param>
		/// <returns></returns>
		public static int MmToDisplay(float mm){
			int m=(int)(mm*100);
			return System.Drawing.Printing.PrinterUnitConvert.Convert(m,System.Drawing.Printing.PrinterUnit.HundredthsOfAMillimeter,System.Drawing.Printing.PrinterUnit.Display);
		}
		
		/// <summary>
		/// 检查打印机是否安装
		/// </summary>
		/// <param name="printerName"></param>
		/// <returns></returns>
		public static bool ExistsPrinter(string printerName){
			foreach (string name in PrinterSettings.InstalledPrinters) {
//				System.Diagnostics.Debug.WriteLine(name);
				if(name==printerName) return true;
			}
			return false;
		}
		
		/// <summary>
		/// 检查纸张
		/// </summary>
		/// <param name="printer"></param>
		/// <param name="paperName"></param>
		/// <returns></returns>
		public static PaperSize GetPaper(PrinterSettings printer,string paperName){
			foreach (PaperSize paper in printer.PaperSizes) {
//				System.Diagnostics.Debug.WriteLine(paper.PaperName);
				if(paper.PaperName==paperName) return paper;
			}
			return null;
		}
		
		public static void QuitePrint(string layoutPath,string printername,string dataPath)
		{
			string tempdir=Helper.UnitHelper.GetTemplateFolderName();
			Helper.UnitHelper.UnArchiveFiles(layoutPath,tempdir);
			var doc=new System.Xml.XmlDocument();
			doc.Load(System.IO.Path.Combine(tempdir,"layout.xml"));
			var canvas=new wCanvas(doc);
			var pt=new Helper.PrintHelper(printername,Helper.PrintHelper.DisplayToMm(canvas.Width),Helper.PrintHelper.DisplayToMm(canvas.Height));
			pt.Canvas=canvas;
			pt.Data=Helper.ExcelHelper.ExcelToTemplateData(dataPath,"Sheet1");
			var CFG=Helper.CommandHelper.Configs;
			if(CFG.ContainsKey("print-offset")){
				var printoffset=CFG["print-offset"].Split("x".ToCharArray());
				pt.OffsetMm=new PointF(float.Parse(printoffset[0]),float.Parse(printoffset[1]));
			}
//			pt.OffsetMm=new PointF(-27,-3);
//			pt.PrinterSettings.PrintToFile=true;
//			pt.PrinterSettings.PrintFileName=@"C:\Users\0115289\Desktop\N7RNAN1LOG00003_0115289.pdf";
			pt.Print();
			pt.Dispose();
			doc=null;
			System.IO.Directory.Delete(tempdir,true);
		}
	}
}
