﻿using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
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

        private void LogInExecute()
        {
            if (Username == "2201996800109" && Password == "Gost")
            {
                GuestView view = new GuestView();
                view.ShowDialog();
            }
            else if(Username == "Zaposleni" && Password == "Zaposleni")
            {
                //TODO otvori zaposleni prozor
                MessageBox.Show("Zaposleni");
            }
            else
            {
                MessageBox.Show("Incorrect Username or Passwrod");
            }
        }

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

        private void CloseExecute()
        {
            main.Close();
        }

        private bool CanCloseExecute()
        {
            return true;
        }

        #endregion
    }
}
