/*
 * Copyright (C) 2016-2018
 * 由SharpDevelop创建。
 * 作者: Byron Gong
 * 日期: 03/17/2018 时间: 12:09
 * 邮箱: 1032066879@QQ.com
 * 描述: 
 *
 */ 
using System;

namespace Spoon.Tools.TemplatePrint.Helper
{
	/// <summary>
	/// Description of UnitHelper.
	/// </summary>
	public static class UnitHelper
	{
		/// <summary>
		/// 获取临时文件夹
		/// </summary>
		/// <returns></returns>
		public static string GetTemplateFolderName(){
			return System.IO.Path.Combine(Environment.GetEnvironmentVariable("temp"),"spoon",Guid.NewGuid().ToString().Replace("-",""));
		}
		
		/// <summary>
		/// 压缩文档
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="filepath"></param>
		public static void ArchiveFiles(System.Xml.XmlDocument doc, string filepath){
			string strTempFolder=UnitHelper.GetTemplateFolderName();
			
			//生成临时目录
			if(System.IO.Directory.Exists(strTempFolder)){
				System.IO.Directory.Delete(strTempFolder,true);
			}
			System.IO.Directory.CreateDirectory(strTempFolder);
			System.IO.Directory.CreateDirectory(System.IO.Path.Combine(strTempFolder,"res"));
			
//			var doc=new System.Xml.XmlDocument();
//			doc.Load(filepath);
			
			//替换背景图
			var background=doc.SelectSingleNode("/layout/property/background");
			if(background!=null){
				string backgroundPathOld=background.Attributes["src"].Value;
				if(backgroundPathOld!=string.Empty){
					if(backgroundPathOld.IndexOf(":",StringComparison.CurrentCulture)==-1){
						backgroundPathOld=System.IO.Path.Combine(System.IO.Path.GetDirectoryName(filepath),backgroundPathOld);
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
						imagePathOld=System.IO.Path.Combine(System.IO.Path.GetDirectoryName(filepath),imagePathOld);
					}
					string imagePathShort=System.IO.Path.Combine("res","image"+imageIndex.ToString()+System.IO.Path.GetExtension(imagePathOld));
					string imagePathNew=System.IO.Path.Combine(strTempFolder,imagePathShort);
					System.IO.File.Copy(imagePathOld,imagePathNew);
					item.Attributes["src"].Value=imagePathShort;
					imageIndex++;
				}
			}
			
			doc.Save(System.IO.Path.Combine(strTempFolder,"layout.xml"));
			doc=null;
			GC.Collect();
			ArchiveHelper.Archive(strTempFolder,filepath);
			System.IO.Directory.Delete(strTempFolder,true);
		}
		
		/// <summary>
		/// 解压缩文档
		/// </summary>
		/// <param name="filename"></param>
		/// <param name="folderPath"></param>
		/// <returns></returns>
		public static System.Xml.XmlDocument UnArchiveFiles(string filename,string folderPath){
			ArchiveHelper.Extract(filename,folderPath);
			var doc=new System.Xml.XmlDocument();
			doc.Load(System.IO.Path.Combine(folderPath,"layout.xml"));
			//替换背景路径
			var background=doc.SelectSingleNode("/layout/property/background");
			if(background!=null){
				string backgroundPathOld=background.Attributes["src"].Value;
				if(backgroundPathOld!=string.Empty){
					if(backgroundPathOld.IndexOf(":",StringComparison.CurrentCulture)==-1){
						background.Attributes["src"].Value=System.IO.Path.Combine(folderPath,backgroundPathOld);
					}
				}
			}
			//替换图片路径
			foreach (System.Xml.XmlNode item in doc.SelectNodes("/layout/items/image")) {
				string imagePathOld=item.Attributes["src"].Value;
				if(imagePathOld!=string.Empty){
					if(imagePathOld.IndexOf(":",StringComparison.CurrentCulture)==-1){
						item.Attributes["src"].Value=System.IO.Path.Combine(folderPath,imagePathOld);
					}
				}
			}
			doc.Save(System.IO.Path.Combine(folderPath,"layout.xml"));
			return doc;
		}
	}
}
