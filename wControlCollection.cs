/*
 * Copyright (C) 2016-2018
 * 由SharpDevelop创建。
 * 作者: Byron Gong
 * 日期: 03/06/2018 时间: 10:23
 * 邮箱: 1032066879@QQ.com
 * 描述: 控件集合类
 *
 */ 
using System;
using Spoon.Tools.TemplatePrint.Controls;

namespace Spoon.Tools.TemplatePrint
{
	/// <summary>
	/// 控件参数
	/// </summary>
	public class wControlCollectEventArgs:EventArgs{
		public wControl Control{
			get;set;
		}
		public wControlCollectEventArgs(wControl control){
			Control=control;
		}
	}
	
	/// <summary>
	/// Description of wControlCollection.
	/// </summary>
	public class wControlCollection:System.Collections.Generic.List<Controls.wControl>
	{

		private System.Windows.Forms.Control m_parent=null;
		
		public delegate void ControlEventHanlder(object sender,wControlCollectEventArgs e);
		
		public event ControlEventHanlder ControlAddedEvent=null;
		public event ControlEventHanlder ControlRemovedEvent=null;
		
		public wControlCollection(System.Windows.Forms.Control parent)
		{
			m_parent=parent;
		}
		
		/// <summary>
		/// 置前
		/// </summary>
		/// <param name="control"></param>
		/// <returns></returns>
		public bool SetFront(wControl control){
			if(base.Contains(control)){
				base.Remove(control);
				base.Add(control);
				return true;
			}
			return false;
		}
		
		/// <summary>
		/// 添加一个元素
		/// </summary>
		/// <param name="control"></param>
		public new virtual void Add(wControl control){
			control.Parent=m_parent;
			base.Add(control);
			OnControlAdded(this,new wControlCollectEventArgs(control));
		}
		
		/// <summary>
		/// 移除一个元素
		/// </summary>
		/// <param name="control"></param>
		public new virtual void Remove(wControl control){
			control.Parent=null;
			base.Remove(control);
			OnControlRemoved(this,new wControlCollectEventArgs(control));
		}
		
		public new virtual void Clear(){
			var cnt=this.Count;
			for (int i = 0; i < cnt; i++) {
				Remove(this[0]);
			}
		}
		
		protected void OnControlAdded(object sender,wControlCollectEventArgs args){
			var handler=ControlAddedEvent;
			if(handler!=null){
				handler(this,args);
			}
		}
		protected void OnControlRemoved(object sender,wControlCollectEventArgs args){
			var handler=ControlRemovedEvent;
			if(handler!=null){
				handler(this,args);
			}
		}
	}
}
