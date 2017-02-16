using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

class Program
{
	static void Main(string[] args)
	{
		/*
		BinaryReader	从二进制流读取原始数据。
		BinaryWriter	以二进制格式写入原始数据。
		BufferedStream	字节流的临时存储。
		Directory		有助于操作目录结构。
		DirectoryInfo	用于对目录执行操作。
		DriveInfo		提供驱动器的信息。
		File			有助于处理文件。
		FileInfo		用于对文件执行操作。
		FileStream		用于文件中任何位置的读写。
		MemoryStream	用于随机访问存储在内存中的数据流。
		Path			对路径信息执行操作。
		StreamReader	用于从字节流中读取字符。
		StreamWriter	用于向一个流中写入字符。
		StringReader	用于读取字符串缓冲区。
		StringWriter	用于写入字符串缓冲区。
		*/

		FileStream f = new FileStream("test.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);

		f.Position = 0;
		for (int i = 0; i < 10; i++)
			f.WriteByte((byte)i);

		f.Position = 0;
		for (int i = 0; i < 10; i++)
			Console.Write(f.ReadByte() + " ");

		f.Close();


		// 程序配置设置
		IsolatedStorageFile storFile = IsolatedStorageFile.GetUserStoreForDomain();

		IsolatedStorageFileStream storStream = new IsolatedStorageFileStream("stor.xml", FileMode.Create, FileAccess.ReadWrite);
		XmlTextWriter writer = new XmlTextWriter(storStream, Encoding.UTF8) { Formatting = Formatting.Indented };

		writer.WriteStartDocument();

		writer.WriteStartElement("Settings");
		writer.WriteValue(123);
		writer.WriteEndElement();

		writer.Close();

		foreach (var item in storFile.GetFileNames())
		{
			Console.WriteLine(item);
		}
	}
}
