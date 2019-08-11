namespace WinZipKata.Core
{
    public class SubFolder
    {
        public string Name { get; }
        public bool IsProcessed { get; set; }

        public SubFolder(string name)
        {
            Name = name;
        }
    }
}
