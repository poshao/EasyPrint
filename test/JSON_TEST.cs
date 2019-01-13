/*
 * Copyright (C) 2016-2018
 * 由SharpDevelop创建。
 * 作者: Byron Gong
 * 日期: 05/14/2018 时间: 16:33
 * 邮箱: 1032066879@QQ.com
 * 描述: 
 *
 */ 
using System;
using NUnit.Framework;
using Newtonsoft.Json;
using Newtonsoft;

namespace Spoon.Tools.TemplatePrint.test
{
	[TestFixture]
	public class JSON_TEST
	{
		[Test]
		public void Json_decode()
		{
			string strjson=System.IO.File.ReadAllText(@"C:\Users\0115289\Desktop\workflow\current\物料管理系统\data.json");
//			var jo=Newtonsoft.Json.Linq.JObject.Parse(strjson);
			
			var jo=Newtonsoft.Json.JsonConvert.DeserializeObject(strjson);
//			Newtonsoft.Json.Linq.JObject aa;
//			Newtonsoft.Json.Linq.JArray ss;
			System.Diagnostics.Debug.WriteLine(jo.ToString());
			
//			foreach (var item in jo) {
//				System.Diagnostics.Debug.WriteLine("key:"+item.Key);
//				System.Diagnostics.Debug.WriteLine(item.Value.ToString());
//			}
			
//			 TODO: Add your test.
//			string strJson=@"[{no:1,itemcode:""QWnee"",qty:124},{no:2,itemcode:""QWnee"",qty:124},{no:3,itemcode:""QWnee"",qty:124}]";
////			var jo= Newtonsoft.Json.JsonConvert.DeserializeObject(strJson) as Newtonsoft.Json.Linq.JArray;
////			var jo=Newtonsoft.Json.Linq.JObject.Parse(strJson);
//			var jo=Newtonsoft.Json.Linq.JArray.Parse(strJson);
//			System.Diagnostics.Debug.WriteLine(jo[0].ToString());
		}
	}
}
