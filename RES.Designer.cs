﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Spoon.Tools.TemplatePrint {
	using System;
	
	
	/// <summary>
	///   A strongly-typed resource class, for looking up localized strings, etc.
	/// </summary>
	// This class was auto-generated by the StronglyTypedResourceBuilder
	// class via a tool like ResGen or Visual Studio.
	// To add or remove a member, edit your .ResX file then rerun ResGen
	// with the /str option, or rebuild your VS project.
	[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
	[global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
	public class RES {
		
		private static global::System.Resources.ResourceManager resourceMan;
		
		private static global::System.Globalization.CultureInfo resourceCulture;
		
		[global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		internal RES() {
		}
		
		/// <summary>
		///   Returns the cached ResourceManager instance used by this class.
		/// </summary>
		[global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
		public static global::System.Resources.ResourceManager ResourceManager {
			get {
				if (object.ReferenceEquals(resourceMan, null)) {
					global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Spoon.Tools.TemplatePrint.RES", typeof(RES).Assembly);
					resourceMan = temp;
				}
				return resourceMan;
			}
		}
		
		/// <summary>
		///   Overrides the current thread's CurrentUICulture property for all
		///   resource lookups using this strongly typed resource class.
		/// </summary>
		[global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
		public static global::System.Globalization.CultureInfo Culture {
			get {
				return resourceCulture;
			}
			set {
				resourceCulture = value;
			}
		}
		
		/// <summary>
		///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;UTF-8&quot; standalone=&quot;yes&quot;?&gt; &lt;layout version=&quot;1.0.1.0&quot;&gt; &lt;property&gt; &lt;author name=&quot;0115289&quot; /&gt; &lt;canvas width=&quot;800&quot; height=&quot;600&quot; /&gt; &lt;datetime createtime=&quot;03/07/2018 15:52:26&quot; updatetime=&quot;03/14/2018 14:44:30&quot; /&gt; &lt;/property&gt; &lt;items&gt; &lt;label text=&quot;test&quot; horizontal-alignment=&quot;Center&quot; vetical-alignment=&quot;Center&quot; font=&quot;Microsoft Sans Serif, 8.25pt&quot; name=&quot;hello&quot; border-visible=&quot;True&quot; top=&quot;73&quot; left=&quot;71&quot; width=&quot;80&quot; height=&quot;50&quot; /&gt; &lt;/items&gt; &lt;/layout&gt;.
		/// </summary>
		public static string Template_New {
			get {
				return ResourceManager.GetString("Template_New", resourceCulture);
			}
		}
	}
}