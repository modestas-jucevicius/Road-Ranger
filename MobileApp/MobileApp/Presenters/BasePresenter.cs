namespace MobileApp.Presenters
{
    public class BasePresenter
    {
        protected readonly object loadLock = new object();
    }
}