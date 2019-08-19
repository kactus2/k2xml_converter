/*
 * Created by SharpDevelop.
 * User: virtan39
 * Date: 15.8.2015
 * Time: 11:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace K2XML_Converter
{
	/// <summary>
	/// Description of AboutForm.
	/// </summary>
	public partial class About : Form
	{
		public About()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			// Must create the links before use!
            linkFunbase.Links.Add(0, 0, "http://funbase.cs.tut.fi");
            linkEmail.Links.Add(0, 0, "mailto:kactus2@cs.tut.fi");
            
            // Check the current build automaticly.
            labelVersion.Text = "Version " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
		}
		
		void LinkFunbaseLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
			}
			catch( Exception )
			{
			}
		}
		
		void LinkEmailLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
			}
			catch( Exception )
			{
			}
		}
		
		protected override void OnPaintBackground(PaintEventArgs e)
		{
		    LinearGradientBrush brush = new LinearGradientBrush(
  			this.ClientRectangle, Color.Gray, Color.LightGray, 90f, false );
  			ColorBlend cb = new ColorBlend();
			cb.Positions = new[] {0, 1/2f, 1};
			cb.Colors = new[] {Color.FromArgb(120,180,250), Color.FromArgb(0xC3,0xDD,0xFD), Color.FromArgb(158,201,252)};
			brush.InterpolationColors= cb;
			e.Graphics.FillRectangle(brush, this.ClientRectangle);
		}
	}
}
