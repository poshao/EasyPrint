/*
 * Copyright (C) 2016-2018
 * 由SharpDevelop创建。
 * 作者: Byron Gong
 * 日期: 03/13/2018 时间: 16:51
 * 邮箱: 1032066879@QQ.com
 * 描述: 
 *
 */ 
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Spoon.Tools.TemplatePrint
{
	/// <summary>
	/// Description of wExplorer.
	/// </summary>
	public partial class wExplorer : UserControl
	{
		private wCanvas m_canvas=null;
		private wControlCollection.ControlEventHanlder m_controlAddedEvent=null;
		private wControlCollection.ControlEventHanlder m_controlRemovedEvent=null;
		private EventHandler m_selectControlChangedEvent=null;
		private Spoon.Tools.TemplatePrint.Controls.wControl.PropertyChangedEventHandler m_propertyChangedEvent=null;
		
		public wCanvas Canvas{
			get{return m_canvas;}
			set{
				if(m_canvas!=null){
					m_canvas.Controls.ControlAddedEvent-=m_controlAddedEvent;
					m_canvas.Controls.ControlRemovedEvent-=m_controlRemovedEvent;
					m_canvas.SelectControlChangedEvent-=m_selectControlChangedEvent;
				}
				m_canvas=value;
				if(m_canvas!=null){
					m_canvas.Controls.ControlAddedEvent+=m_controlAddedEvent;
					m_canvas.Controls.ControlRemovedEvent+=m_controlRemovedEvent;
					m_canvas.SelectControlChangedEvent+=m_selectControlChangedEvent;
				}
			}
		}
		
		public wExplorer(){
			InitializeComponent();
			m_controlAddedEvent=new wControlCollection.ControlEventHanlder(OnControlAdded);
			m_controlRemovedEvent=new wControlCollection.ControlEventHanlder(OnControlRemoved);
			m_selectControlChangedEvent=new EventHandler(OnSelectControlChanged);
			m_propertyChangedEvent=new Spoon.Tools.TemplatePrint.Controls.wControl.PropertyChangedEventHandler(OnPropertyChanged);
			
			tvList.ExpandAll();
		}
		public wExplorer(wCanvas canvas)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			m_controlAddedEvent=new wControlCollection.ControlEventHanlder(OnControlAdded);
			m_controlRemovedEvent=new wControlCollection.ControlEventHanlder(OnControlRemoved);
			m_selectControlChangedEvent=new EventHandler(OnSelectControlChanged);
			m_propertyChangedEvent=new Spoon.Tools.TemplatePrint.Controls.wControl.PropertyChangedEventHandler(OnPropertyChanged);
			
			Canvas=canvas;
			tvList.ExpandAll();
		}
		
		protected void OnPropertyChanged(object sender,EventArgs args){
			if(Canvas.SelectControl!=null){
				tvList.SelectedNode.Text=Canvas.SelectControl.Name;
			}
		}
		
		protected void OnControlAdded(object sender,wControlCollectEventArgs e){
			var node=tvList.Nodes[0].Nodes.Add(e.Control.Name);
			e.Control.PropertyChangedEvent+=m_propertyChangedEvent;
			node.Tag=e.Control;
		}
		protected void OnControlRemoved(object sender,wControlCollectEventArgs e){
			e.Control.PropertyChangedEvent-=m_propertyChangedEvent;
			foreach (TreeNode node in tvList.Nodes[0].Nodes) {
				if(node.Tag.Equals(e.Control)){
					node.Remove();
					return;
				}
			}
		}
		protected void OnSelectControlChanged(object sender,EventArgs e){
			foreach (TreeNode node in tvList.Nodes[0].Nodes) {
				if(node.Tag.Equals(Canvas.SelectControl)){
					tvList.SelectedNode=node;
					return;
				}
			}
			tvList.SelectedNode=tvList.Nodes[0];
		}
		
		void TvListNodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if(e.Node.Tag != null){
				Canvas.SelectControl=e.Node.Tag as Controls.wControl;
			}
		}
	}
}
