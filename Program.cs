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
            if (true)
            {
                Helper.CommandHelper.Parse(args);
                var CFG = Helper.CommandHelper.Configs;

                if (CFG.ContainsKey("quiet"))
                {
                    //后台打印
                    if (CFG.ContainsKey("layout") && CFG.ContainsKey("datafile") && CFG.ContainsKey("printer"))
                    {
                        //Helper.PrintHelper.QuitePrint(CFG["file"],CFG["set-printername"],CFG["set-data-excel"]);
                        Helper.PrintHelper.QuitePrintJson(CFG["layout"], CFG["printer"], CFG["datafile"]);
                        return;
                    }
                    else
                    {
                        Helper.CommandHelper.InvalidCommand();
                    }
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            else
            {
                var ddd = new test.GeneratePDF();
                
            }
		}
		
	}
}
