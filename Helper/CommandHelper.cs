/*
 * Copyright (C) 2016-2018
 * 由SharpDevelop创建。
 * 作者: Byron Gong
 * 日期: 03/16/2018 时间: 16:24
 * 邮箱: 1032066879@QQ.com
 * 描述: 命令解析辅助
 *
 */ 
using System;

namespace Spoon.Tools.TemplatePrint.Helper
{
	/// <summary>
	/// Description of CommandHelper.
	/// </summary>
	public static class CommandHelper
	{
		private static System.Collections.Generic.Dictionary<string,string> m_configs=null;
		
		public static System.Collections.Generic.Dictionary<string,string> Configs{
			get{
				if(m_configs==null){
					m_configs=new System.Collections.Generic.Dictionary<string, string>();
				}
				return m_configs;
			}
		}
		
		/// <summary>
		/// 解析命令
		/// </summary>
		/// <param name="args"></param>
		public static void Parse(string[] args){
			
			if(args.Length==1){
				Configs.Add("file",args[0]);
			}else{
				for (int i = 0; i < args.Length; i+=2) {
					Configs.Add(args[i],args[i+1]);
				}
			}
		}
	}
}
