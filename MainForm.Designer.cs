/*
 * Created by SharpDevelop.
 * User: virtan39
 * Date: 13.8.2015
 * Time: 11:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace K2XML_Converter
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button buttonConvert;
		private System.Windows.Forms.Label labelStatus;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.Button buttonSelectFolder;
		private System.ComponentModel.BackgroundWorker conversionWorker;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.TextBox textBoxFolder;
		private System.ComponentModel.BackgroundWorker fileScanner;
		private System.Windows.Forms.Button buttonHalt;
		private System.Windows.Forms.LinkLabel linkLabel;
		private System.Windows.Forms.Button buttonAbout;
		private System.Windows.Forms.Label labelDesc;
		private System.Windows.Forms.Label labelSelect;
		
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
		void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonConvert = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.textBoxFolder = new System.Windows.Forms.TextBox();
            this.buttonSelectFolder = new System.Windows.Forms.Button();
            this.conversionWorker = new System.ComponentModel.BackgroundWorker();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.fileScanner = new System.ComponentModel.BackgroundWorker();
            this.buttonHalt = new System.Windows.Forms.Button();
            this.linkLabel = new System.Windows.Forms.LinkLabel();
            this.buttonAbout = new System.Windows.Forms.Button();
            this.labelDesc = new System.Windows.Forms.Label();
            this.labelSelect = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonConvert
            // 
            this.buttonConvert.Location = new System.Drawing.Point(454, 153);
            this.buttonConvert.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(80, 23);
            this.buttonConvert.TabIndex = 0;
            this.buttonConvert.Text = "Convert";
            this.buttonConvert.UseVisualStyleBackColor = true;
            this.buttonConvert.Click += new System.EventHandler(this.ButtonConvertClick);
            // 
            // labelStatus
            // 
            this.labelStatus.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.labelStatus.Location = new System.Drawing.Point(10, 179);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(607, 57);
            this.labelStatus.TabIndex = 1;
            // 
            // textBoxFolder
            // 
            this.textBoxFolder.Location = new System.Drawing.Point(10, 126);
            this.textBoxFolder.Margin = new System.Windows.Forms.Padding(10);
            this.textBoxFolder.Name = "textBoxFolder";
            this.textBoxFolder.Size = new System.Drawing.Size(524, 20);
            this.textBoxFolder.TabIndex = 2;
            // 
            // buttonSelectFolder
            // 
            this.buttonSelectFolder.Location = new System.Drawing.Point(537, 126);
            this.buttonSelectFolder.Margin = new System.Windows.Forms.Padding(10);
            this.buttonSelectFolder.Name = "buttonSelectFolder";
            this.buttonSelectFolder.Size = new System.Drawing.Size(80, 23);
            this.buttonSelectFolder.TabIndex = 3;
            this.buttonSelectFolder.Text = "Browse...";
            this.buttonSelectFolder.UseVisualStyleBackColor = true;
            this.buttonSelectFolder.Click += new System.EventHandler(this.ButtonSelectFolderClick);
            // 
            // conversionWorker
            // 
            this.conversionWorker.WorkerReportsProgress = true;
            this.conversionWorker.WorkerSupportsCancellation = true;
            this.conversionWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ConversionWorkerDoWork);
            this.conversionWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.ConversionWorkerProgressChanged);
            this.conversionWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ConversionWorkerRunWorkerCompleted);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(10, 153);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(439, 23);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 4;
            // 
            // fileScanner
            // 
            this.fileScanner.DoWork += new System.ComponentModel.DoWorkEventHandler(this.FileScannerDoWork);
            this.fileScanner.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.FileScannerRunWorkerCompleted);
            // 
            // buttonHalt
            // 
            this.buttonHalt.Enabled = false;
            this.buttonHalt.Location = new System.Drawing.Point(537, 153);
            this.buttonHalt.Margin = new System.Windows.Forms.Padding(10);
            this.buttonHalt.Name = "buttonHalt";
            this.buttonHalt.Size = new System.Drawing.Size(80, 23);
            this.buttonHalt.TabIndex = 5;
            this.buttonHalt.Text = "Cancel";
            this.buttonHalt.UseVisualStyleBackColor = true;
            this.buttonHalt.Click += new System.EventHandler(this.ButtonHaltlClick);
            // 
            // linkLabel
            // 
            this.linkLabel.Location = new System.Drawing.Point(10, 240);
            this.linkLabel.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(607, 23);
            this.linkLabel.TabIndex = 6;
            this.linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelLinkClicked);
            // 
            // buttonAbout
            // 
            this.buttonAbout.Location = new System.Drawing.Point(537, 10);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(80, 23);
            this.buttonAbout.TabIndex = 7;
            this.buttonAbout.Text = "About";
            this.buttonAbout.UseVisualStyleBackColor = true;
            this.buttonAbout.Click += new System.EventHandler(this.ButtonAboutClick);
            // 
            // labelDesc
            // 
            this.labelDesc.Location = new System.Drawing.Point(7, 10);
            this.labelDesc.Margin = new System.Windows.Forms.Padding(10);
            this.labelDesc.Name = "labelDesc";
            this.labelDesc.Size = new System.Drawing.Size(512, 106);
            this.labelDesc.TabIndex = 8;
            this.labelDesc.Text = resources.GetString("labelDesc.Text");
            // 
            // labelSelect
            // 
            this.labelSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelect.Location = new System.Drawing.Point(7, 102);
            this.labelSelect.Name = "labelSelect";
            this.labelSelect.Size = new System.Drawing.Size(313, 24);
            this.labelSelect.TabIndex = 9;
            this.labelSelect.Text = "Please select the base directory for the conversion: ";
            this.labelSelect.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(624, 281);
            this.Controls.Add(this.labelSelect);
            this.Controls.Add(this.labelDesc);
            this.Controls.Add(this.buttonAbout);
            this.Controls.Add(this.linkLabel);
            this.Controls.Add(this.buttonHalt);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.buttonSelectFolder);
            this.Controls.Add(this.textBoxFolder);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.buttonConvert);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "K2XML Converter";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
	}
}
