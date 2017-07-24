/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:OCineManagerApps.OcineManager"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using OCine.BAL.DTO;
using OCineManagerApps.OcineManager.DATA;
using OCineManagerApps.OcineManager.DATA.Interfaces;
using OCineManagerApps.OcineManager.Helper;
using OCineManagerApps.OcineManager.Helper.UserControls;
using OCineManagerApps.OcineManager.RefreshInterface;
using System;

namespace OCineManagerApps.OcineManager.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
           

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<FilmsViewModel>();
            SimpleIoc.Default.Register<SeancesViewModel>();
            SimpleIoc.Default.Register<CreateFilmVIewModel>();
            SimpleIoc.Default.Register<CinemaViewModel>();
            SimpleIoc.Default.Register<IFilmsRequest, FilmsRequest>();
            SimpleIoc.Default.Register< ICinemaRequest, CinemaRequest >();
            SimpleIoc.Default.Register<IActorRequest, ActorRequest>();
            SimpleIoc.Default.Register<ICountryRequest, CountryRequest>();
            SimpleIoc.Default.Register<IGenreRequest, GenreRequest>();
            SimpleIoc.Default.Register<ISeancesRequest, SeancesRequest >();
            SimpleIoc.Default.Register<FilmShedulesListView>();
            SimpleIoc.Default.Register<CreateCinemaViewModel>();
            SimpleIoc.Default.Register<AddSeancesViewModel>();
        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        public FilmsViewModel FilmVm => ServiceLocator.Current.GetInstance<FilmsViewModel>();
        public CinemaViewModel CinemaVm => ServiceLocator.Current.GetInstance<CinemaViewModel>();
        public SeancesViewModel SeancesVm => ServiceLocator.Current.GetInstance<SeancesViewModel>();
        public CreateFilmVIewModel CreateVm => ServiceLocator.Current.GetInstance<CreateFilmVIewModel>();
        public CreateCinemaViewModel CreateCinemaVm => ServiceLocator.Current.GetInstance<CreateCinemaViewModel>();
        public AddSeancesViewModel AddSeancesVm => ServiceLocator.Current.GetInstance<AddSeancesViewModel>();
        public static void Cleanup<T>(T t) where T:class, new ()
        {
            
        }
    }
}