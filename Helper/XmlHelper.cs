/*
 * Copyright (C) 2016-2018
 * 由SharpDevelop创建。
 * 作者: Byron Gong
 * 日期: 03/07/2018 时间: 11:39
 * 邮箱: 1032066879@QQ.com
 * 描述: XML辅助操作类
 *
 */ 
using System;

namespace Spoon.Tools.TemplatePrint.Helper
{
	/// <summary>
	/// Description of XmlHelper.
	/// </summary>
	public class XmlHelper
	{
		public XmlHelper()
		{
		}
		
		/// <summary>
		/// 添加属性
		/// </summary>
		/// <param name="node"></param>
		/// <param name="key"></param>
		/// <param name="value"></param>
		public static void AddAttribute(string key,string value,System.Xml.XmlNode node){
			if(node==null){
				throw new Exception("节点不能为null");
			}
			var attr=node.Attributes.GetNamedItem(key) as System.Xml.XmlAttribute;
			if(attr==null){
				attr=node.OwnerDocument.CreateAttribute(key);
				node.Attributes.Append(attr);
			}
			attr.Value=value;
		}
		
		/// <summary>
		/// 添加定位属性
		/// </summary>
		/// <param name="rect"></param>
		/// <param name="prefix"></param>
		/// <param name="node"></param>
		public static void AddRectangleAttribute(System.Drawing.Rectangle rect,string prefix,System.Xml.XmlNode node){
			prefix=prefix.Equals(string.Empty)?prefix:prefix+"-";
			AddAttribute(prefix+"top",rect.Top.ToString(),node);
			AddAttribute(prefix+"left",rect.Left.ToString(),node);
			AddAttribute(prefix+"width",rect.Width.ToString(),node);
			AddAttribute(prefix+"height",rect.Height.ToString(),node);
		}
		
		/// <summary>
		/// 添加定位属性
		/// </summary>
		/// <param name="rect"></param>
		/// <param name="node"></param>
		public static void AddRectangleAttribute(System.Drawing.Rectangle rect,System.Xml.XmlNode node){
			AddRectangleAttribute(rect,string.Empty,node);
		}
		
		/// <summary>
		/// 添加尺寸属性
		/// </summary>
		/// <param name="size"></param>
		/// <param name="node"></param>
		public static void AddSizeAttribute(System.Drawing.SizeF size,System.Xml.XmlNode node){
			AddAttribute("width",size.Width.ToString(),node);
			AddAttribute("height",size.Height.ToString(),node);
		}
		
		/// <summary>
		/// 创建一个新文档
		/// </summary>
		/// <returns></returns>
		public static System.Xml.XmlDocument NewDocment(){
			var doc=new System.Xml.XmlDocument();
			doc.AppendChild(doc.CreateProcessingInstruction("xml", "version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\""));
			return doc;
		}
	}
}
