using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncodingDetector
{
    public class EncodingDetector
    {
        public static Encoding DetectFileEncoding(string filePath)
        {
            using (var reader = new StreamReader(filePath, true))
            {
                reader.Peek(); 
                return reader.CurrentEncoding;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Specify the directory you want to process
            string directoryPath = @"C:\Work\p_new\p\db\script";

            // Get all files in the directory
            var fileEntries = Directory.EnumerateFiles(directoryPath);
            foreach (var filePath in fileEntries)
            {
                try
                {
                    var encoding = EncodingDetector.DetectFileEncoding(filePath);
                    Console.WriteLine($"File: {Path.GetFileName(filePath)}");
                    Console.WriteLine($" Encoding Name: {encoding.EncodingName}");
                    Console.WriteLine($" CodePage: {encoding.CodePage}");
                    Console.WriteLine($" WebName: {encoding.WebName}");
                    Console.WriteLine($" IsSingleByte: {encoding.IsSingleByte}");
                    Console.WriteLine($" ByteOrderMark: {encoding.GetPreamble().Length > 0}");
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    // Handle any errors that might occur during file processing
                    Console.WriteLine($"Error processing file {filePath}: {ex.Message}");
                }
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
