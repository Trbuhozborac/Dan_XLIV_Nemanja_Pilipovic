using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
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
            AllFood = GetAllFood();
        }

        #endregion

        #region Properties

        private Food food;

        public Food Food
        {
            get { return food; }
            set 
            {
                food = value;
                OnPropertyChanged("Food");
            }
        }


        private List<Food> foods;

        public List<Food> AllFood
        {
            get { return foods; }
            set 
            {
                foods = value;
                OnPropertyChanged("AllFood");
            }
        }

        private int price;

        public int Price
        {
            get { return price; }
            set 
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }       

        #endregion

        #region Commands

        private ICommand addItem;
        public ICommand AddItem
        {
            get
            {
                if (addItem == null)
                {
                    addItem = new RelayCommand(param => AddNewItem(), param => CanAddNewItem());
                }
                return addItem;
            }
        }      

        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }
                return save;
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

        private List<Food> GetAllFood()
        {
            List<Food> food = new List<Food>();
            Food fish = new Food("Fish", 100);
            Food chips = new Food("Chips", 200);
            Food cevap = new Food("Cevap", 250);
            Food pljeskavica = new Food("Pljeskavica", 250);
            food.Add(fish);
            food.Add(chips);
            food.Add(cevap);
            food.Add(pljeskavica);
            return food;
        }

        private void AddNewItem()
        {
            Price += Food.Price;           
        }

        private bool CanAddNewItem()
        {
            return true;
        }

        private void SaveExecute()
        {
            try
            {
                tblOrder order = new tblOrder();
                order.Price = Price;
                order.State = "Waiting";
                using(PizzaRestourantEntities db = new PizzaRestourantEntities())
                {
                    tblGuest guest = db.tblGuests.Where(x => x.Username == "2201996800109").FirstOrDefault();
                    order.FKGuest = guest.Id;
                    DateTime dateTime = DateTime.Now;
                    order.CreatedDate = dateTime.Date;
                    order.CreatedTime = dateTime.TimeOfDay;
                    db.tblOrders.Add(order);
                    db.SaveChanges();
                }
                MessageBox.Show($"Ordered Successfully! Order Status: {order.State}");
                main.Close();                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message.ToString());               
            }
        }

        private bool CanSaveExecute()
        {
            if(Price <= 0)
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
