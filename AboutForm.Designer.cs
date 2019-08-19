/*
 * Created by SharpDevelop.
 * User: virtan39
 * Date: 15.8.2015
 * Time: 11:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace K2XML_Converter
{
	partial class About
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label labelCopyright;
		private System.Windows.Forms.LinkLabel linkFunbase;
		private System.Windows.Forms.Label labelVersion;
		private System.Windows.Forms.Label labelDisclaimer;
		private System.Windows.Forms.LinkLabel linkEmail;
		private System.Windows.Forms.PictureBox pictureBox;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
			this.labelCopyright = new System.Windows.Forms.Label();
			this.linkFunbase = new System.Windows.Forms.LinkLabel();
			this.labelVersion = new System.Windows.Forms.Label();
			this.labelDisclaimer = new System.Windows.Forms.Label();
			this.linkEmail = new System.Windows.Forms.LinkLabel();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// labelCopyright
			// 
			this.labelCopyright.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelCopyright.BackColor = System.Drawing.Color.Transparent;
			this.labelCopyright.Location = new System.Drawing.Point(12, 415);
			this.labelCopyright.Name = "labelCopyright";
			this.labelCopyright.Size = new System.Drawing.Size(675, 26);
			this.labelCopyright.TabIndex = 9;
			this.labelCopyright.Text = "Copyright 2015-2016 Tampere University of Technology,\r\nKorkeakoulunkatu 10, FI-33" +
	"720 Tampere, Finland\r\n";
			this.labelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// linkFunbase
			// 
			this.linkFunbase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.linkFunbase.BackColor = System.Drawing.Color.Transparent;
			this.linkFunbase.Location = new System.Drawing.Point(12, 441);
			this.linkFunbase.Name = "linkFunbase";
			this.linkFunbase.Size = new System.Drawing.Size(675, 13);
			this.linkFunbase.TabIndex = 10;
			this.linkFunbase.TabStop = true;
			this.linkFunbase.Text = "http://funbase.cs.tut.fi";
			this.linkFunbase.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.linkFunbase.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkFunbaseLinkClicked);
			// 
			// labelVersion
			// 
			this.labelVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelVersion.BackColor = System.Drawing.Color.Transparent;
			this.labelVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelVersion.Location = new System.Drawing.Point(12, 403);
			this.labelVersion.Name = "labelVersion";
			this.labelVersion.Size = new System.Drawing.Size(675, 12);
			this.labelVersion.TabIndex = 11;
			this.labelVersion.Text = "VERSION\r\n";
			this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelDisclaimer
			// 
			this.labelDisclaimer.BackColor = System.Drawing.Color.Transparent;
			this.labelDisclaimer.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.labelDisclaimer.Location = new System.Drawing.Point(0, 476);
			this.labelDisclaimer.Name = "labelDisclaimer";
			this.labelDisclaimer.Size = new System.Drawing.Size(699, 124);
			this.labelDisclaimer.TabIndex = 12;
			this.labelDisclaimer.Text = resources.GetString("labelDisclaimer.Text");
			this.labelDisclaimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// linkEmail
			// 
			this.linkEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.linkEmail.BackColor = System.Drawing.Color.Transparent;
			this.linkEmail.Location = new System.Drawing.Point(12, 454);
			this.linkEmail.Name = "linkEmail";
			this.linkEmail.Size = new System.Drawing.Size(675, 13);
			this.linkEmail.TabIndex = 13;
			this.linkEmail.TabStop = true;
			this.linkEmail.Text = "kactus2@cs.tut.fi";
			this.linkEmail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.linkEmail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkEmailLinkClicked);
			// 
			// pictureBox
			// 
			this.pictureBox.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
			this.pictureBox.Location = new System.Drawing.Point(0, 0);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(699, 400);
			this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pictureBox.TabIndex = 14;
			this.pictureBox.TabStop = false;
			// 
			// About
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.ClientSize = new System.Drawing.Size(699, 600);
			this.Controls.Add(this.pictureBox);
			this.Controls.Add(this.linkEmail);
			this.Controls.Add(this.labelDisclaimer);
			this.Controls.Add(this.labelVersion);
			this.Controls.Add(this.linkFunbase);
			this.Controls.Add(this.labelCopyright);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "About";
			this.ShowIcon = false;
			this.Text = "About";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
