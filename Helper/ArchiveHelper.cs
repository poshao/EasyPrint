/*
 * Copyright (C) 2016-2018
 * 由SharpDevelop创建。
 * 作者: Byron Gong
 * 日期: 03/16/2018 时间: 9:27
 * 邮箱: 1032066879@QQ.com
 * 描述: 压缩辅助类
 *
 */ 
using System;
using ICSharpCode.SharpZipLib.Zip;

namespace Spoon.Tools.TemplatePrint.Helper
{
	/// <summary>
	/// 压缩辅助类
	/// </summary>
	public static class ArchiveHelper
	{
		/// <summary>
		/// 压缩
		/// </summary>
		/// <param name="directoryName"></param>
		/// <param name="archiveFilename"></param>
		public static void Archive(string directoryName,string archiveFilename){
			var fz=new FastZip();
			fz.CreateZip(archiveFilename,directoryName,true,string.Empty,string.Empty);
		}
		
		/// <summary>
		/// 解压缩
		/// </summary>
		/// <param name="archiveFilename"></param>
		/// <param name="directoryName"></param>
		public static void Extract(string archiveFilename,string directoryName){
			var fz=new FastZip();
			fz.ExtractZip(archiveFilename,directoryName,FastZip.Overwrite.Always,null,string.Empty,string.Empty,false);
		}
	}
}
