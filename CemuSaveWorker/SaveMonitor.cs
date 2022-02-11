namespace CemuSaveWorker
{
    public class SaveMonitor
    {
        public static void OnFileChanged(object sender, FileSystemEventArgs e)
        {
            var source = e.FullPath;

            var folderName = "save";

            var index = source.IndexOf(folderName);

            var path = source.Remove(0, index + folderName.Length + 1);

            var destination = @$"G:\Meu Drive\emuladores\cemu\save\{path}";

            File.Copy(source, destination, true);
        }
    }
}
