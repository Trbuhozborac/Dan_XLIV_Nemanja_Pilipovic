using System.Windows;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for GuestView.xaml
    /// </summary>
    public partial class GuestView : Window
    {
        public GuestView()
        {
            InitializeComponent();
            this.DataContext = new GuestViewModel(this);
        }
    }
}
