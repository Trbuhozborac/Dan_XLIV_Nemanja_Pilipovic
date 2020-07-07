using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class MainWindowViewModel : BaseViewModel
    {
        #region Objects

        MainWindow main;

        #endregion

        #region Constructors

        public MainWindowViewModel(MainWindow mainOpen)
        {
            main = mainOpen;
        }

        #endregion

        #region Properties

        private string username;

        public string Username
        {
            get { return username; }
            set 
            {
                username = value;
                OnPropertyChanged("Username");
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set 
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        #endregion

        #region Commands

        private ICommand logIn;
        public ICommand LogIn
        {
            get
            {
                if (logIn == null)
                {
                    logIn = new RelayCommand(param => LogInExecute(), param => CanLogInExecute());
                }
                return logIn;
            }
        }

        private ICommand close;
        public ICommand Close
        {
            get
            {
                if (close == null)
                {
                    close = new RelayCommand(param => CloseExecute(), param => CanCloseExecute());
                }
                return close;
            }
        }

        #endregion

        #region Functions

        /// <summary>
        /// Logs the Employee or Guest
        /// </summary>
        private void LogInExecute()
        {
            if (Username == "2201996800109" && Password == "Gost")
            {
                try
                {
                    using(PizzaRestourantEntities db = new PizzaRestourantEntities())
                    {
                        tblGuest guest = db.tblGuests.Where(x => x.Username == "2201996800109").FirstOrDefault();
                        tblOrder order = db.tblOrders.Where(x => x.FKGuest == guest.Id).FirstOrDefault();
                        if(order != null && order.State == "Waiting")
                        {
                            MessageBox.Show($"You Already Ordered. Order Status: {order.State}");
                        }                       
                        else
                        {
                            GuestView view = new GuestView();
                            view.ShowDialog();
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message.ToString());                   
                }             
            }
            else if(Username == "Zaposleni" && Password == "Zaposleni")
            {
                EmployeeView view = new EmployeeView();
                view.ShowDialog();
            }
            else
            {
                MessageBox.Show("Incorrect Username or Passwrod");
            }
        }

        /// <summary>
        /// Checks if Login can be Executed
        /// </summary>
        /// <returns></returns>
        private bool CanLogInExecute()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password) ||
                string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Close the Main window
        /// </summary>
        private void CloseExecute()
        {
            main.Close();
        }

        /// <summary>
        /// Checks if Main window can be closed
        /// </summary>
        /// <returns></returns>
        private bool CanCloseExecute()
        {
            return true;
        }

        #endregion
    }
}
