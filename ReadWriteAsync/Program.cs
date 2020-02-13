using System;
using System.IO;
using System.Threading.Tasks;

namespace ReadWriteAsync
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            string path = @"d:\";
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }
            Console.WriteLine("Enter string:");
            string text = Console.ReadLine();

            using (FileStream fWStream = new FileStream($"{path}note.txt", FileMode.OpenOrCreate))
            {
                byte[] arra = System.Text.Encoding.Default.GetBytes(text);
                await fWStream.WriteAsync(arra, 0, arra.Length);
                Console.WriteLine("Write end!");
            }
            using (FileStream fRStream = File.OpenRead($"{path}note.txt"))
            {
                byte[] array = new byte[fRStream.Length];
                await fRStream.ReadAsync(array, 0, array.Length);
                string textF = System.Text.Encoding.Default.GetString(array);
                Console.WriteLine(textF);
            }
        }
    }
}
