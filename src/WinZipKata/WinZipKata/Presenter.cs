namespace WinZipKata
{
    public class Presenter
    {
        private readonly IWinZipUI _view;
        private ParentPath _parentPath;

        public Presenter(IWinZipUI view, ParentPath parentPath)
        {
            _view = view;
            _parentPath = parentPath;
        }

        public void ParentPathChanged(string newParentPath)
        {

        }
    }
}
