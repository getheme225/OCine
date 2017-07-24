using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;

namespace OCineManagerApps.OcineManager.Helper
{
    public class ChildWindowManager : ViewModelBase
    {
        public ChildWindowManager()
        {

        }

        //Singleton pattern implementation 
        private static ChildWindowManager instance;
        public static ChildWindowManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ChildWindowManager();
                }
                return instance;
            }
        }

        public void ShowChildWindow(Window window)
        {
           window.Show();
        }

        public void CloseChildWindow(Window window)
        {
          window.Close();
        }
    }
}
