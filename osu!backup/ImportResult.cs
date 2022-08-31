using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osu_backup
{
    public class ImportResult
    {
        public Dictionary<BackupPart, List<string>> Parts { get; private set; }

        public ImportResult(Dictionary<BackupPart, List<string>> parts)
        {
            Parts = parts;
        }

    }
}
