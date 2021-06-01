using System;
using System.IO.Compression;

namespace _06_Zip_and_Extract
{
    class Program
    {
        static void Main(string[] args)
        {
            ZipFile.CreateFromDirectory(@"C:\test", @"C:\test\TestArchive.zip");

            ZipFile.ExtractToDirectory(@"C:\test\TestArchive.zip", @"C:\test");
        }
    }
}
