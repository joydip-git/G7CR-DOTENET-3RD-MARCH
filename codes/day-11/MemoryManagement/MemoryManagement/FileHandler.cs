using System.IO;
using System.Text;

namespace MemoryManagement
{
    public class FileHandler : IDisposable
    {
        FileStream? fileStream = null;
        StreamReader? streamReader = null;

        //finalizer
        ~FileHandler()
        {
            Console.WriteLine("in finalizer");
            if (fileStream != null && streamReader != null)
            {
                fileStream.Close();
                streamReader.Close();
                fileStream = null;
                streamReader = null;
            }
        }

        public void Dispose()
        {
            //the following line will make sure that CLR does not call the finalizer
            GC.SuppressFinalize(this);

            Console.WriteLine("in dispose");
            if (fileStream != null && streamReader != null)
            {
                //fileStream.Close();
                //streamReader.Close();
                fileStream.Dispose();
                streamReader.Dispose();
                fileStream = null;
                streamReader = null;
            }
        }

        public string GetData(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    fileStream = new(path, FileMode.OpenOrCreate);
                    streamReader = new(fileStream);
                    StringBuilder builder = new();
                    while (!streamReader.EndOfStream)
                    {
                        string? data = null;
                        if ((data = streamReader.ReadLine()) != null)
                        {
                            builder.AppendLine(data);
                        }
                    }
                    return builder.ToString();
                }
                else
                    throw new FileNotFoundException($"{path} does mot exist");
            }
            catch
            {
                throw;
            }
            //finally
            //{
            //    Console.WriteLine("in finally...");
            //    if (fileStream != null && streamReader != null)
            //    {
            //        fileStream.Close();
            //        streamReader.Close();
            //        fileStream = null;
            //        streamReader = null;
            //    }
            //}
        }
    }
}
