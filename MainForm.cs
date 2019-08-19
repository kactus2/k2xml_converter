/*
 * Created by SharpDevelop.
 * User: virtan39
 * Date: 13.8.2015
 * Time: 11:16
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Xsl;
using System.Xml;
using System.IO;
using System.Text;

namespace K2XML_Converter
{
	public partial class MainForm : Form
	{
		// The name of the configuration file.
		const string CONF_NAME = "K2XML_Converter.conf";
		
		const string NAMESPACES = 
			"xmlns:kactus2=\"http://funbase.cs.tut.fi/\" " +
			"xmlns:spirit=\"http://www.spiritconsortium.org/XMLSchema/SPIRIT/1.5\" " +
			"xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" " +
			"xsi:schemaLocation=\"http://www.spiritconsortium.org/XMLSchema/SPIRIT/1.5 " +
			"http://www.spiritconsortium.org/XMLSchema/SPIRIT/1.5/index.xsd\" ";
		const string APIDEF_NO_NS = "<kactus2:apiDefinition>";
		const string APIDEF_YES_NS = "<kactus2:apiDefinition " + NAMESPACES + ">";
		const string COMDEF_NO_NS = "<kactus2:comDefinition>";
		const string COMDEF_YES_NS = "<kactus2:comDefinition " + NAMESPACES + ">";
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			// Must reserve a link for link label before use!
            this.linkLabel.Links.Add(0, 0, "joku");
		}
		
        // How many files processed so far?
        int processed = 0;
		
		void ConversionWorkerDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			// Use intendation.
			XmlWriterSettings settings = new XmlWriterSettings();
			settings.Indent = true;
			settings.IndentChars = "   ";
			
	        // Reset the counter
	        processed = 0;
	        
	        // Log the when started
	        logStream.WriteLine( "Conversion started: " + started_ );
	        // How many files
	        logStream.WriteLine( "Scanned " + totalFiles + " files for processing." );
	        // The used XSLT files.
	        logStream.WriteLine( "The first used XSLT file: " + firstConPath );
	        logStream.WriteLine( "The second used XSLT file: " + secondConPath );
	        logStream.WriteLine( "The third used XSLT file: " + thirdConPath );
	        logStream.WriteLine();
	        logStream.WriteLine( "******************************" );
	        logStream.WriteLine();

            // Convert each scanned file now, with certain exceptions of course.
			// NOTICE: file specific non-error messages are ommitted from console for performance!
            foreach (string file in files)
            {
                try
                {
	                if (conversionWorker.CancellationPending == true)
	                {
	                	// The conversion has been manually halted before its end!
	                    e.Cancel = true;
	                    
	                    // Log and file it.
            			logStream.WriteLine();
	                    string errs = "***CONVERSION HALTED BY USER***";
						Console.WriteLine( errs );
	        			logStream.WriteLine( errs );
	        			
	                    break;
	                }
                
                    // File info is needed for file details, like extension, directory, ect.
                    System.IO.FileInfo fi = new System.IO.FileInfo(file);
                    
                    // One less file to check.
                    ++processed;
                    
                    // As long as there wont be division by zero, report the progress.
                    if ( totalFiles > 0 )
                    {
                    	conversionWorker.ReportProgress( 100 * processed / totalFiles );
                    }
                    
                    // Only XML files are to be converted.
                    if ( fi.Extension != ".xml" )
                    	continue;
                    
                    // Begins with prefix -> already converted -> do not convert!
                    if ( fi.Name.StartsWith( prefix, StringComparison.Ordinal ) )
                    {
                    	// Log it.
	        			logStream.WriteLine( fi.Name + " was skipped since it was already converted!" );
                    	continue;
                    }
                    
                    // Form the path of the new file.
                    string newPath = fi.Directory + System.IO.Path.DirectorySeparatorChar.ToString() + prefix + fi.Name;
					
				   	// Log which original file was opened.
	        		logStream.WriteLine( fi.Name + ":" );
	        		// When:
	        		logStream.WriteLine( "\tOpened: " + DateTime.Now );
	        		// What was the output file?
	        		logStream.WriteLine( "\tOutput: " + newPath );    

					// Read the original from file system.
	        		string xml = "";
	        		
					try
					{
	        			xml = File.ReadAllText(file);
					}
					catch ( Exception exp )
					{
						string errs = "Error while reading XML file: " + exp.Message;
						Console.WriteLine( errs );
	        			logStream.WriteLine( "\t" + errs );
					}
					
					// Replace API and com definition root elements with ones containing namespaces.
					xml = xml.Replace( APIDEF_NO_NS, APIDEF_YES_NS );
					xml = xml.Replace( COMDEF_NO_NS, COMDEF_YES_NS );
	        		
					// Wrap the document to a reader.
					XmlReader firstReader = new XmlTextReader(new StringReader(xml));
					
					// Dump the intermediate conversion result to memory rather than filesystem.
					MemoryStream firstStream = new MemoryStream();
					// Needs a writer to write to that stream.
					XmlWriter firstWriter = XmlWriter.Create( firstStream, xslt1.OutputSettings );
		
					// Execute the transform and output the results to the intermediate stream.
					try
					{
						xslt1.Transform( firstReader, firstWriter );
					}
					catch ( XsltException exp )
					{
						string errs = "Error in 1st conversion: " + exp.Message + " Location: " + exp.LineNumber + ", " + exp.LinePosition;
						Console.WriteLine( errs );
	        			logStream.WriteLine( "\t" + errs );
					}
						
					// Roll back the first stream after writing.
					firstStream.Seek( 0, SeekOrigin.Begin );
					// Needs a reader to read from that stream.
					XmlReader secondReader = XmlReader.Create( firstStream );
					// Dump the intermediate conversion result to memory rather than filesystem.
					MemoryStream secondStream = new MemoryStream();
					// Needs a writer to write to that stream.
					XmlWriter secondWriter = XmlWriter.Create( secondStream, xslt2.OutputSettings );
		
					// Execute the second transformation, which is again outputted to memory.
					try
					{
						xslt2.Transform( secondReader, secondWriter );
					}
					catch ( XmlException exp )
					{
						string errs = "Error while reading the second XML: " + exp.Message + " Location: "
						+ exp.LineNumber + ", " + exp.LinePosition;
						Console.WriteLine( errs );
	        			logStream.WriteLine( "\t" + errs );
					}
					catch ( XsltException exp )
					{
						string errs = "Error in 2nd conversion: " + exp.Message + " Location: " + exp.LineNumber + ", " + exp.LinePosition;
						Console.WriteLine( errs );
	        			logStream.WriteLine( "\t" + errs );
					}
						
					// Roll back the first stream after writing.
					secondStream.Seek( 0, SeekOrigin.Begin );
					// Needs a reader to read from that stream.
					XmlReader thirdReader = XmlReader.Create( secondStream );
					// The final output is dumped to the filesystem.
					FileStream thirdStream = new FileStream( newPath, FileMode.Create );
					// Needs a writer to write to that stream.
					XmlWriter thirdWriter = XmlWriter.Create( thirdStream, xslt3.OutputSettings );
		
					// Execute the third transformation, which is outputted to file system.
					try
					{
						xslt3.Transform( thirdReader, thirdWriter );
					}
					catch ( XmlException exp )
					{
						string errs = "Error while reading the third XML: " + exp.Message + " Location: "
						+ exp.LineNumber + ", " + exp.LinePosition;
						Console.WriteLine( errs );
	        			logStream.WriteLine( "\t" + errs );
					}
					catch ( XsltException exp )
					{
						string errs = "Error in 3rd conversion: " + exp.Message + " Location: " + exp.LineNumber + ", " + exp.LinePosition;
						Console.WriteLine( errs );
	        			logStream.WriteLine( "\t" + errs );
					}
					
					// Try to flush the output writer, and close every one of them.
					try
					{
						thirdWriter.Flush();
						
						firstReader.Close();
						firstWriter.Close();
						firstStream.Close();
						secondReader.Close();
						secondWriter.Close();
						secondStream.Close();
						thirdReader.Close();
						thirdWriter.Close();
						thirdStream.Close();
					}
					catch ( Exception exp )
					{
						string errs = "Error while closing streams: " + exp.Message;
						Console.WriteLine( errs );
	        			logStream.WriteLine( "\t" + errs );
					}
                }
                catch ( Exception exp )
                {
                    // Catch and report any uncatched execeptions.
					string errs = "Error while processing: " + exp.Message;
                    Console.WriteLine(errs);
	        		logStream.WriteLine( "\t" + errs );
                }
					
				try
				{
				   	// Log when files were closed
	        		logStream.WriteLine( "\tClosed: " + DateTime.Now );
				}
                catch ( Exception exp )
                {
                    // Any anomaly caused by this entry should be reported as well.
					string errs = "Error while logging closing time of XML files: " + exp.Message;
                    Console.WriteLine(errs);
                }
	        }
		}
		
		// Date when conversion work was requested.
		DateTime started_;
		// Configurations
		String prefix; // Prefix used for converted files.
		
		// Stream to write the log file.
		StreamWriter logStream;
		
		// The used stylesheets containing the conversion rules.
		XslCompiledTransform xslt1;
		XslCompiledTransform xslt2;
		XslCompiledTransform xslt3;
		
		// Locations of the stylesheets.
		String firstConPath; 
		String secondConPath;
		String thirdConPath;
		
		// The files in current processing run.
		string[] files;
	    int totalFiles;
	    
	    // The root folder of the converted files. 
	    string inputPath;
		
		void ButtonConvertClick(object sender, EventArgs eargs)
		{
			// No action if already converting or even scanning.
			if ( conversionWorker.IsBusy || fileScanner.IsBusy )
				return;
			
			// Load the configurations.
			try
			{
				StreamReader cfgStream = new StreamReader(CONF_NAME);
				prefix = cfgStream.ReadLine();
				firstConPath = cfgStream.ReadLine();
				secondConPath = cfgStream.ReadLine();
				thirdConPath = cfgStream.ReadLine();
				
				// Close the configuration file: No further need for it.
				cfgStream.Close();
			}
			catch ( Exception exp )
			{
				// If configurations failed, no action!
				string errs = "Error while loading configurations: " + exp.Message;
				labelStatus.Text = errs;
				Console.WriteLine(errs);
				return;
			}
			
			// Must have a prefix.
			if ( prefix == null || prefix.Length < 1 )
			{
				string errs = "The file name prefix must be at least 1 character long." +
					" The prefix is defined at file " + CONF_NAME;
				labelStatus.Text = errs;
				Console.WriteLine(errs);
				return;
			}
			
			try
			{
				// Load the style sheets.
				xslt1 = new XslCompiledTransform();
				xslt1.Load(firstConPath);
				
				xslt2 = new XslCompiledTransform();
				xslt2.Load(secondConPath);
				
				xslt3 = new XslCompiledTransform();
				xslt3.Load(thirdConPath);
			}
			catch ( Exception exp )
			{
				// If loading style sheets failed, no action!
				string errs = "Error while loading style sheets: " + exp.Message +
					" Style sheet paths are defined in file " + CONF_NAME;
				labelStatus.Text = errs;
				Console.WriteLine(errs);
				return;
			}
				
			inputPath = textBoxFolder.Text;
				
			// Check that there actually is something to process.
	        if (!System.IO.Directory.Exists( inputPath ) )
	        {
	        	string errs = "Error: Invalid target directory specified!";
	        	labelStatus.Text = errs;
				Console.WriteLine(errs);
				return;
	        }
		
			try
			{
				// Open the log file for writing.
				logStream = new StreamWriter("conversion.log", false, Encoding.UTF8);
				linkLabel.Links[0].LinkData = Path.GetFullPath("conversion.log");
				linkLabel.Text = "Log file written in " + Path.GetFullPath("conversion.log");
			}
			catch ( Exception exp )
			{
				// Must be able to open the log file.
				string errs = "Error while opening the log file: " + exp.Message;
				labelStatus.Text = errs;
				Console.WriteLine(errs);
				return;
			}
	        
	        labelStatus.Text = "Scanning the folder for input files...";
	        
			fileScanner.RunWorkerAsync();
			
			buttonConvert.Enabled = false;
		}
		
		void ButtonSelectFolderClick(object sender, EventArgs e)
		{
			// Show the FolderBrowserDialog.
	        DialogResult result = folderBrowserDialog.ShowDialog();
	        
	        if( result == DialogResult.OK )
	        {
	            textBoxFolder.Text = folderBrowserDialog.SelectedPath;
	        }
		}
		
		void ConversionWorkerRunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			// It is complete! Time to tell how long it lasted.
			DateTime concluded = DateTime.Now;
			
			labelStatus.Text = "Conversion started: " + started_.ToString() + "\n\rConversion concluded: " + concluded.ToString()
				+ "\n\rProcessed " + processed + " files";
            
            try
            {
            	logStream.WriteLine();
	        	logStream.WriteLine( "******************************" );
            	logStream.WriteLine();
            	string conclusion = "Conversion concluded: " + concluded;
            	logStream.WriteLine( conclusion );
				Console.WriteLine( conclusion );
            	
	            // Time to close the configuration stream.
				logStream.Flush();
				logStream.Close();
            }
            catch ( Exception exp )
            {
                // Error will be informed.
				string errs = "Error while closing the log file: " + exp.Message;
				labelStatus.Text = errs;
				Console.WriteLine(errs);
            }
            
            // Re-enable conversion, cannot press halt any more.
			buttonConvert.Enabled = true;
			buttonHalt.Enabled = false;
			
			// When complete, the bar is always at full!
			if ( !e.Cancelled )
				progressBar.Value = 100;
		}
		
		void ConversionWorkerProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
		{
			if ( progressBar.Value < e.ProgressPercentage )
			{
				// Progress has been made -> Tell to user.
				progressBar.PerformStep();
			}
		}
		
		void FileScannerDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			// Scan all files in advance.
	       	files = System.IO.Directory.GetFiles( inputPath, "*.xml", SearchOption.AllDirectories );
	        // Mark up how many there are in total.
	       	totalFiles = files.Length;
		}
		
		void FileScannerRunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			if ( conversionWorker.IsBusy )
			{
	       		labelStatus.Text = "Error: A conversion was already on progress after scanning the files.";
				return;
			}
			
			// Reset the bar.
			progressBar.Value = 0;
	       	
	       	// Update status, check the time, start the work.
	       	string startS = "Processing " + totalFiles + " files...";
	       	labelStatus.Text = startS;
	       	Console.WriteLine( startS );
			
			started_ = DateTime.Now;
			
			conversionWorker.RunWorkerAsync();
			
			// Conversion started -> may halt it
			buttonHalt.Enabled = true;
		}
		
		void LinkLabelLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				System.Diagnostics.Process.Start(linkLabel.Links[0].LinkData.ToString());
			}
            catch ( Exception exp )
            {
                // Error will be informed.
				string errs = "Error while viewing the log file: " + exp.Message;
				labelStatus.Text = errs;
				Console.WriteLine(errs);
            }
		}
		
		void ButtonHaltlClick(object sender, EventArgs e)
		{
			conversionWorker.CancelAsync();
		}
		
		void ButtonAboutClick(object sender, EventArgs e)
		{
			// Create and display when needed!
			About af = new About();
			af.Show();
		}
    }
}
