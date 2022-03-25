using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osu_backup
{
    public class FileUtils
    {
        public static Dictionary<string, string> RetrieveBeatmaps(string source)
        {
            var result = new Dictionary<string, string>();
            foreach (var beatmap in Directory.GetDirectories(source))
            {
                var fullName = new DirectoryInfo(beatmap).Name.Split(' ');
                string id = fullName[0];
                if (!result.ContainsKey(id))
                {
                    string name = string.Join(" ", fullName[1..]);
                    result.Add(id, name);
                }
            }
            return result;
        }

        public static CopyDirectoryResult? CopyDirectory(string sourceDir, string destinationDir, bool recursive = false, bool overwrite = false)
        {
            int files = 0;
            int dirs = 0;
            var dir = new DirectoryInfo(sourceDir);
            if (!dir.Exists)
            {
                return null;
            }

            if (!Directory.Exists(destinationDir))
            {
                Directory.CreateDirectory(destinationDir);
            }
            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                if (!File.Exists(targetFilePath) || overwrite)
                {
                    file.CopyTo(targetFilePath);
                    files++;
                }
            }

            DirectoryInfo[] children = dir.GetDirectories();
            if (recursive)
            {
                foreach (DirectoryInfo subDir in children)
                {
                    string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                    if (!Directory.Exists(newDestinationDir) || overwrite)
                    {
                        dirs++;
                        var result = CopyDirectory(subDir.FullName, newDestinationDir, true, overwrite);
                        if (result != null)
                        {
                            files += result.Files();
                            dirs += result.Dirs();
                        }
                    }
                }
            }
            return new CopyDirectoryResult(files, dirs);
        }

        public static string FileSize(FileInfo file)
        {
            long size = file.Length;
            string[] suffixes = { "bytes", "KB", "MB", "GB", "TB" };
            int unit = 0;
            for (int i = 0; i < suffixes.Length; i++)
            {
                if (size > Math.Pow(1024, i))
                {
                    unit = i;
                }
            }
            double newSize = Math.Floor(size / Math.Pow(1024, unit));
            return newSize + " " + suffixes[unit];
        }
    }
}
