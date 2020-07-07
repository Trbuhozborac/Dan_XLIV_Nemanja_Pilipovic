using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class GuestViewModel : BaseViewModel
    {
        #region Objects

        GuestView main;

        #endregion

        #region Constructors

        public GuestViewModel(GuestView mainOpen)
        {
            main = mainOpen;
        }

        #endregion
    }
}
