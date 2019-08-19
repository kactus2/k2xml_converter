# k2xml_converter

A conversion tool for different IEEE-1685 IP-XACT XML versions.

By default, the tool converts SPIRIT 1.5 IP-XACT XML files to IEEE 1685-2014 compilant including Kactus2 vendor extensions. 
The tool traverses through the directory hierarchy, opens all 1.5 XML files and saves the converted 1685-2014 files in the original 
directory with a modified name. Any existing files with similar file name will be overwritten.

## Prerequisites

### Linux users
Use following commands at command line to install dependencies and launch the application:

```
sudo apt-get install mono-runtime
sudo apt-get install libmono-system-windows-forms4.0-cil
sudo apt-get install libmono2.0-cil
mono K2XML_Converter.exe
```

Tested on Ubuntu 14.04.3 64-bit and 15.04 64-bit

Having a .NET implementation is mandatory for the application to work.
For instance, Debian 8.1.0 did not have mono by default.

## Installing

The conversion tool is provided as a prebuild standalone application.

## Usage

1. Make a backup of the root directory of the conversion i.e the folder where the files needing conversion are located. 
Please include also any other files and subdirectoies in the backup as well.
2. Launch the application.
3. Select a directory as the root directory for the conversion by either:
	a) Type or copy the path in the text box, or
	b) Click the "Select Folder" button. A directory browser dialog should appear.
4. Press the "Convert" button.
5. The XML files in the directory and all subdirectories are now scanned. After the scan, no new files are included in the conversion.
6. Now the tool will convert every XML file found in the scan.
By default, it will first convert from SPIRIT standard version 1.5 to IP-XACT 1685-2009 and then to IP-XACT 1685-2014. Finally, it
applies the conversion rules for the vendor extensions used by Kactus2.
7. The progress bar illustrates how large percentage of all the XML files are processed.
You may also stop the conversion by clicking "Halt", but not reverse it!
8. When conversion is done, the time started and finished are displayed.
9. If need be, you will find log data at conversion.log.

## Configuration

The conversion tool is configured by [K2XML_Converter.conf](K2XML_Converter.conf). The file should contain exactly four lines:
1. file prefix
2. path to first XSLT file
3. path to second XSLT file
4. path to third XSLT file

The first line defines the file prefix for all the created XML files. The remaining three lines define the path to XSLT files
defining the rules for the conversion. The transformations will be applied in the given order.

Example configuration:
```
k2u_
Conversion_Rules/from1.5_to_1685_2009.xsl
Conversion_Rules/from1685_2009_to_1685_2014.xsl
Conversion_Rules/kactus_extensions_2014.xsl
```

An XML file comp.xml would be transformed from SPIRIT 1.5 to IP-XACT 2009, then to IP-XACT 2014 and last Kactus2 vendor extensions
would be converted. The updated XML would be stored in file k2u_comp.xml.

Files with the given prefix are skipped in the converstion, as these are considered as already converted files.

## Deployment

TODO.

## Built With

* Visual Studio 2017

Compilation settings:
* Target Framework: .NET Framework 4.0
* Target CPU: Any
* File Alignment: 4096
* DLL Base address: 0x400000

Tested on Windows 7 64-bit and Windows 10 64-bit.

## Authors

* Janne Virtanen - *Initial work*

See also the list of [contributors](https://github.com/kactus2/k2xml_converter/graphs/contributors) who participated in this project.

## License

This project is licensed under the GPL2 License - see the [LICENSE](LICENSE) file for details

## Acknowledgments

* The XSLT conversion rules for different IP-XACT standard versions are provided by Accellera Systems Initiative, not the authors of this tool.
