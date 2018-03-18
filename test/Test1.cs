/*
 * Copyright (C) 2016-2018
 * 由SharpDevelop创建。
 * 作者: Byron Gong
 * 日期: 03/07/2018 时间: 10:31
 * 邮箱: 1032066879@QQ.com
 * 描述: 
 *
 */ 
using System;
using NUnit.Framework;

namespace Spoon.Tools.TemplatePrint.test
{
	[TestFixture]
	public class Test1
	{
		[Test]
		public void dsdf(){
			var dds = System.IO.Directory.GetDirectories(@"C:\Users\0115289\Documents\SharpDevelop Projects\SpoonSystem\TemplatePrint\bin\Debug\templates");
			foreach (var ds in dds) {
				foreach (var f in System.IO.Directory.GetFiles(ds,"*.xmlbg")) {
					System.IO.File.Move(f,f.Replace(".xmlbg",".bg"));
				}
			}
		}
		
		[Test]
		public void PackageFiles(){
			string strPath =@"C:\Users\0115289\Desktop\sf.xmlx";
			
			string strTempFolder=Helper.UnitHelper.GetTemplateFolderName();
			
			//生成临时目录
			if(System.IO.Directory.Exists(strTempFolder)){
				System.IO.Directory.Delete(strTempFolder,true);
			}
			System.IO.Directory.CreateDirectory(strTempFolder);
			System.IO.Directory.CreateDirectory(strTempFolder+"\\res");
			
			var doc=new System.Xml.XmlDocument();
			doc.Load(strPath);
			
			//替换背景图
			var background=doc.SelectSingleNode("/layout/property/background");
			if(background!=null){
				string backgroundPathOld=background.Attributes["src"].Value;
				if(backgroundPathOld!=string.Empty){
					if(backgroundPathOld.IndexOf(":",StringComparison.CurrentCulture)==-1){
						backgroundPathOld=System.IO.Path.Combine(System.IO.Path.GetDirectoryName(strPath),backgroundPathOld);
					}
					string backgroundPathShort=System.IO.Path.Combine("res","background"+System.IO.Path.GetExtension(backgroundPathOld));
					string backgroundPathNew=System.IO.Path.Combine(strTempFolder,backgroundPathShort);
					System.IO.File.Copy(backgroundPathOld,backgroundPathNew);
					background.Attributes["src"].Value=backgroundPathShort;
				}
			}
			
			int imageIndex=1;
			foreach (System.Xml.XmlNode item in doc.SelectNodes("/layout/items/image")) {
				string imagePathOld=item.Attributes["src"].Value;
				if(imagePathOld!=string.Empty){
					if(imagePathOld.IndexOf(":",StringComparison.CurrentCulture)==-1){
						imagePathOld=System.IO.Path.Combine(System.IO.Path.GetDirectoryName(strPath),imagePathOld);
					}
					string imagePathShort=System.IO.Path.Combine("res","image"+imageIndex.ToString()+System.IO.Path.GetExtension(imagePathOld));
					string imagePathNew=System.IO.Path.Combine(strTempFolder,imagePathShort);
					System.IO.File.Copy(imagePathOld,imagePathNew);
					item.Attributes["src"].Value=imagePathShort;
					imageIndex++;
				}
			}
			
			doc.Save(System.IO.Path.Combine(strTempFolder,"layout.xml"));
			
			Helper.ArchiveHelper.Archive(strTempFolder,@"C:\Users\0115289\Desktop\sf.zip");
			System.IO.Directory.Delete(strTempFolder,true);
		}
		
		
		public System.Xml.XmlDocument UnPackageFiles(string filename,string tempfolder){
			filename=@"C:\Users\0115289\Desktop\sf.zip";
			
			string strTempFolder=Helper.UnitHelper.GetTemplateFolderName();
			Helper.ArchiveHelper.Extract(filename,strTempFolder);
			var doc=new System.Xml.XmlDocument();
			doc.Load(System.IO.Path.Combine(strTempFolder,"layout.xml"));
			//替换背景路径
			var background=doc.SelectSingleNode("/layout/property/background");
			if(background!=null){
				string backgroundPathOld=background.Attributes["src"].Value;
				if(backgroundPathOld!=string.Empty){
					if(backgroundPathOld.IndexOf(":",StringComparison.CurrentCulture)==-1){
						background.Attributes["src"].Value=System.IO.Path.Combine(strTempFolder,backgroundPathOld);
					}
				}
			}
			//替换图片路径
			foreach (System.Xml.XmlNode item in doc.SelectNodes("/layout/items/image")) {
				string imagePathOld=item.Attributes["src"].Value;
				if(imagePathOld!=string.Empty){
					if(imagePathOld.IndexOf(":",StringComparison.CurrentCulture)==-1){
						item.Attributes["src"].Value=System.IO.Path.Combine(strTempFolder,imagePathOld);
					}
				}
			}
			return doc;
		}
		
		[Test]
		public void ACTest(){
			Guid.NewGuid().ToString().Replace("-",string.Empty);
			
			ICSharpCode.SharpZipLib.Zip.FastZip fz=new ICSharpCode.SharpZipLib.Zip.FastZip();
			fz.CreateZip(@"C:\123.zip",@"C:\Users\0115289\Desktop\becky",true,string.Empty,string.Empty);
		}
		
		[Test]
		public void TestMethod()
		{
			Controls.wLabel lbl=new Spoon.Tools.TemplatePrint.Controls.wLabel();
			lbl.Name="hello";
			lbl.Text="test";
			lbl.Rectangle=new System.Drawing.Rectangle(0,0,100,300);
			lbl.ShowBorder=true;
			
			System.Xml.XmlDocument doc=new System.Xml.XmlDocument();
			var d=doc.CreateElement("qqq");
			doc.AppendChild(d);
			d.AppendChild(lbl.ToXml(d));
			doc.Save(@"C:\Users\0115289\Desktop\123.xml");
		}
		
		[Test]
		public void Convert(){
			var olddoc=new System.Xml.XmlDocument();
			
			olddoc.Load(@"C:\Users\0115289\Documents\SharpDevelop Projects\SpoonSystem\TemplatePrint\bin\Debug\templates\1. 顺丰\sf.xml");
			
			var doc=XmlHelper.NewDocment();
			wCanvas canvas=new wCanvas();
			canvas.Author="Elder Yao";
			
			var size=olddoc.SelectSingleNode("/layout/size");
			canvas.Size=new System.Drawing.Size(int.Parse(size.Attributes["width"].Value),int.Parse(size.Attributes["height"].Value));
			
			var background=olddoc.SelectSingleNode("/layout/background");
			canvas.BackgroundPath=background.Attributes["path"].Value;
			canvas.BackgroundScale=float.Parse(background.Attributes["scale"].Value);
			
			foreach (System.Xml.XmlNode item in olddoc.SelectSingleNode("/layout/items").ChildNodes) {
				var lbl=new Controls.wLabel();
				lbl.Name=item.Attributes["name"].Value;
				lbl.Text=item.Attributes["value"].Value;
				lbl.Rectangle=new System.Drawing.Rectangle(
					int.Parse(item.Attributes["left"].Value),
					int.Parse(item.Attributes["top"].Value),
					int.Parse(item.Attributes["width"].Value),
					int.Parse(item.Attributes["height"].Value)
				);
				var fc=new System.Drawing.FontConverter();
				lbl.Font=fc.ConvertFromString(item.Attributes["font"].Value) as System.Drawing.Font;
				
				lbl.ShowBorder=false;
				canvas.Controls.Add(lbl);
			}
			
			doc.AppendChild(canvas.ToXml(doc));
			doc.Save(@"C:\Users\0115289\Documents\SharpDevelop Projects\SpoonSystem\TemplatePrint\bin\Debug\templates\1. 顺丰\sf.xmlx");
		}
	}
}
