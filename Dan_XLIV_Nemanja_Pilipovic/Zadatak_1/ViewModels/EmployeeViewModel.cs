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
    class EmployeeViewModel : BaseViewModel
    {
        #region Objects

        EmployeeView main;

        #endregion

        #region Constructors

        public EmployeeViewModel(EmployeeView mainOpen)
        {
            main = mainOpen;
            AllOrders = GetAllOrders();            
        }

        #endregion

        #region Properties

        private tblOrder order;

        public tblOrder Order
        {
            get { return order; }
            set 
            {
                order = value;
                OnPropertyChanged("Order");
            }
        }


        private List<tblOrder> allOrders;

        public List<tblOrder> AllOrders
        {
            get { return allOrders; }
            set 
            {
                allOrders = value;
                OnPropertyChanged("AllOrders");
            }
        }

        #endregion

        #region Commands

        private ICommand allowOrder;
        public ICommand AllowOrder
        {
            get
            {
                if (allowOrder == null)
                {
                    allowOrder = new RelayCommand(param => AllowNewOrder(), param => CanAllowOrder());
                }
                return allowOrder;
            }
        }

        private ICommand declineOrder;
        public ICommand DeclineOrder
        {
            get
            {
                if (declineOrder == null)
                {
                    declineOrder = new RelayCommand(param => DeclineNewOrder(), param => CanDeclineOrder());
                }
                return declineOrder;
            }
        }

        private ICommand saveOrder;
        public ICommand SaveOrder
        {
            get
            {
                if (saveOrder == null)
                {
                    saveOrder = new RelayCommand(param => SaveNewOrder(), param => CanSaveOrder());
                }
                return saveOrder;
            }
        }

        private ICommand deleteOrder;
        public ICommand DeleteOrder
        {
            get
            {
                if (deleteOrder == null)
                {
                    deleteOrder = new RelayCommand(param => DeleteNewOrder(), param => CanDeleteOrder());
                }
                return deleteOrder;
            }
        }

        private ICommand close;
        public ICommand Close
        {
            get
            {
                if (close == null)
                {
                    close = new RelayCommand(param => CloseWindow(), param => CanCloseWindow());
                }
                return close;
            }
        }

        private ICommand orderOwner;
        public ICommand OrderOwner
        {
            get
            {
                if (orderOwner == null)
                {
                    orderOwner = new RelayCommand(param => GetOrderOwner(), param => CanGetOrderOwner());
                }
                return orderOwner;
            }
        }

        #endregion

        #region Functions
        
        /// <summary>
        /// Gets All orders from the database
        /// </summary>
        /// <returns>All Orders</returns>
        private List<tblOrder> GetAllOrders()
        {
            List<tblOrder> allOrders = new List<tblOrder>();
            try
            {
                using(PizzaRestourantEntities db = new PizzaRestourantEntities())
                {
                    allOrders = db.tblOrders.Where(x => x.Id > 0).ToList();
                    return allOrders;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Checks if Order can be Accepted
        /// </summary>
        private void AllowNewOrder()
        {
            tblOrder selectedOrder = new tblOrder();
            try
            {
                using (PizzaRestourantEntities db = new PizzaRestourantEntities())
                {
                    selectedOrder = db.tblOrders.Where(x => x.Id == Order.Id).FirstOrDefault();
                    if (selectedOrder.State != "Waiting")
                    {
                        MessageBox.Show("You Cant Accept Orders That Dont have State: 'Waiting'");
                    }
                    else
                    {                        
                        selectedOrder.State = "Accepted";
                        db.SaveChanges();
                        MessageBox.Show("Order Accepted!");
                    }
                }
                AllOrders = GetAllOrders();
                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message.ToString());                
            };
        }

        /// <summary>
        /// Allows switching state of order
        /// </summary>
        /// <returns></returns>
        private bool CanAllowOrder()
        {
            return true;
        }

        /// <summary>
        /// Declines the Order
        /// </summary>
        private void DeclineNewOrder()
        {
            tblOrder selectedOrder = new tblOrder();
            try
            {
                using (PizzaRestourantEntities db = new PizzaRestourantEntities())
                {
                    selectedOrder = db.tblOrders.Where(x => x.Id == Order.Id).FirstOrDefault();
                    if (selectedOrder.State != "Waiting")
                    {
                        MessageBox.Show("You Cant Decline Orders That Dont have State: 'Waiting'");
                    }
                    else
                    {
                        selectedOrder.State = "Declined";
                        db.SaveChanges();
                        MessageBox.Show("Order Declined!");
                    }
                }
                AllOrders = GetAllOrders();

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message.ToString());
            };
        }

        /// <summary>
        /// Checks if Order can be Declined
        /// </summary>
        /// <returns></returns>
        private bool CanDeclineOrder()
        {
            return true;
        }
        
        /// <summary>
        /// Switch Order status to Saved
        /// </summary>
        private void SaveNewOrder()
        {
            tblOrder selectedOrder = new tblOrder();
            try
            {
                using (PizzaRestourantEntities db = new PizzaRestourantEntities())
                {
                    selectedOrder = db.tblOrders.Where(x => x.Id == Order.Id).FirstOrDefault();
                    if (selectedOrder.State == "Waiting")
                    {
                        MessageBox.Show("You Cant Save Order That have State: 'Waiting'");
                    }
                    else
                    {
                        selectedOrder.State = "Saved";
                        db.SaveChanges();
                        MessageBox.Show("Order Saved!");
                    }
                }
                AllOrders = GetAllOrders();

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message.ToString());
            };
        }

        /// <summary>
        /// Checks if Order can be Saved
        /// </summary>
        /// <returns></returns>
        private bool CanSaveOrder()
        {
            return true;
        }

        /// <summary>
        /// Deletes selected Order
        /// </summary>
        private void DeleteNewOrder()
        {
            tblOrder selectedOrder = new tblOrder();
            try
            {
                using (PizzaRestourantEntities db = new PizzaRestourantEntities())
                {
                    selectedOrder = db.tblOrders.Where(x => x.Id == Order.Id).FirstOrDefault();
                    if (selectedOrder.State == "Waiting")
                    {
                        MessageBox.Show("You Cant Delete Order That have State: 'Waiting'");
                    }
                    else
                    {
                        MessageBoxResult result = MessageBox.Show("Do you want to Delete this Order?", "Confirm Deleting", MessageBoxButton.YesNoCancel);
                        switch (result)
                        {
                            case MessageBoxResult.Cancel:
                                break;
                            case MessageBoxResult.Yes:
                                db.tblOrders.Remove(selectedOrder);
                                db.SaveChanges();
                                MessageBox.Show("Order Deleted Successfully!");
                                break;
                            case MessageBoxResult.No:
                                break;
                            default:
                                break;
                        }

                    }
                }
                AllOrders = GetAllOrders();

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message.ToString());
            };
        }

        /// <summary>
        /// Checks if Order can be Deleted
        /// </summary>
        /// <returns></returns>
        private bool CanDeleteOrder()
        {
            return true;
        }

        /// <summary>
        /// Closes the Main window
        /// </summary>
        private void CloseWindow()
        {
            main.Close();
        }

        /// <summary>
        /// Chcks if window can be closed
        /// </summary>
        /// <returns></returns>
        private bool CanCloseWindow()
        {
            return true;
        }

        /// <summary>
        /// Gets the Guest that ordered selecred order
        /// </summary>
        private void GetOrderOwner()
        {
            tblOrder selectedOrder = new tblOrder();
            tblGuest guest = new tblGuest();
            try
            {
                using (PizzaRestourantEntities db = new PizzaRestourantEntities())
                {
                    selectedOrder = db.tblOrders.Where(x => x.Id == Order.Id).FirstOrDefault();
                    guest = db.tblGuests.Where(x => x.Id == selectedOrder.FKGuest).FirstOrDefault();
                }
                MessageBox.Show($"Username: {guest.Username}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message.ToString());
            };
        }

        /// <summary>
        /// Checks if Employee can get the Guest of the Owner
        /// </summary>
        /// <returns></returns>
        private bool CanGetOrderOwner()
        {
            return true;
        }

        #endregion
    }
}
