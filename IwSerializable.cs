/*
 * Copyright (C) 2016-2018
 * 由SharpDevelop创建。
 * 作者: Byron Gong
 * 日期: 03/07/2018 时间: 11:29
 * 邮箱: 1032066879@QQ.com
 * 描述: 
 *
 */ 
using System;

namespace Spoon.Tools.TemplatePrint
{
	/// <summary>
	/// Description of IwSerializable.
	/// </summary>
	public interface IwSerializable
	{
		/// <summary>
		/// 序列化存储
		/// </summary>
		/// <param name="doc"></param>
		/// <returns></returns>
		System.Xml.XmlNode ToXml(System.Xml.XmlNode node);
		
//		/// <summary>
//		/// 反序列化
//		/// </summary>
//		/// <param name="node"></param>
//		/// <returns></returns>
//		object FromXml(System.Xml.XmlNode node);
			
	}
}
