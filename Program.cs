/*
 * Copyright (C) 2016-2018
 * 由SharpDevelop创建。
 * 作者: Byron Gong
 * 日期: 03/05/2018 时间: 10:51
 * 邮箱: 1032066879@QQ.com
 * 描述: 
 *
 */ 
using System;
using System.Windows.Forms;

namespace Spoon.Tools.TemplatePrint
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Helper.CommandHelper.Parse(args);
			var CFG=Helper.CommandHelper.Configs;
			if(CFG.ContainsKey("mode-server")){
				if(CFG.ContainsKey("file") && CFG.ContainsKey("set-data-excel") && CFG.ContainsKey("set-printername")){
					Helper.PrintHelper.QuitePrint(CFG["file"],CFG["set-printername"],CFG["set-data-excel"]);
					return;
				}else{
					Helper.CommandHelper.InvalidCommand();
				}
			}
			
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
		
	}
}
