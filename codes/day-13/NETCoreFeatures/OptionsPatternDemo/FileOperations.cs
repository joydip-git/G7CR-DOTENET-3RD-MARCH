using Microsoft.Extensions.Options;
using System.Text;

namespace OptionsPatternDemo
{
    public class FileOperations : IFileOperations
    {
        //private readonly string path;
        //public FileOperations(string path) => this.path = path;

        /*
         *  private readonly IOptionsMonitor<FileSettingOptions> options;
        private readonly string? path;
        public FileOperations(IOptionsMonitor<FileSettingOptions> options)
        {
            this.options = options;
            this.path = this.options.CurrentValue.FilePath;
        }
         */

        private readonly IOptions<FileSettingOptions> options;
        private readonly string? path;
        public FileOperations(IOptions<FileSettingOptions> options)
        {
            this.options = options;
            this.path = this.options.Value.FilePath;
        }

        public string GetData()
        {
            if (path != null && File.Exists(path))
            {
                StringBuilder builder = new();

                using (var reader = new StreamReader(path))
                {
                    string? text = null;
                    while (!reader.EndOfStream)
                    {
                        while ((text = reader.ReadLine()) != null)
                        {
                            builder.AppendLine(text);
                        }
                    }
                }
                return builder.ToString();
            }
            else
                throw new FileNotFoundException($"{path} is not found");
        }
    }
}
