﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OCine.ViewModel;
using Xamarin.Forms;

namespace OCine
{
    public partial class App : Application
    {

        public App()
        {
            MainPage = new NavigationPage(GetMainPage());
        }
        private static ViewModelLocator _locator;
        public static ViewModelLocator Locator => _locator?? (_locator = new ViewModelLocator());

        public static Page GetMainPage()
        {
            return new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
