namespace osu_backup
{
    public class CopyDirectoryResult
    {
        private readonly int files;
        private readonly int dirs;

        public CopyDirectoryResult(int files, int dirs)
        {
            this.files = files;
            this.dirs = dirs;
        }

        public int Files()
        {
            return files;
        }

        public int Dirs()
        {
            return dirs;
        }
    }
}
