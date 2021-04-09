using System;
using System.IO;

namespace Folder_Size
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles("../../../TestFolder");

            double fileSizes = 0;

            foreach (var filePath in files)
            {
                FileInfo file = new FileInfo(filePath);

                fileSizes += file.Length / 1024.0;
            }

            byte[] buffer = new byte[(int)fileSizes];

            using (FileStream streamWriter = new FileStream("../../../output.txt", FileMode.Create, FileAccess.Write))
            {
                streamWriter.Write(buffer, 0, buffer.Length);
            }

        }
    }
}
