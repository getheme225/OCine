using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace OCineApps.Models
{
   public class BaseViewModel: BindableBase, INavigationAware
   {
       protected readonly INavigationService _navigationService;
       public DelegateCommand<string> NavigateCommand { get; set; }

       public BaseViewModel(INavigationService navigationServices)
       {
           _navigationService = navigationServices;
           NavigateCommand = new DelegateCommand<string>(Navigate);
       }

       private async void Navigate(string name)
       {
           await _navigationService.NavigateAsync(name);
       }

       public virtual void OnNavigatedFrom(NavigationParameters parameters)
       {
       }

       public virtual void OnNavigatedTo(NavigationParameters parameters)
       {
       }

       public virtual void OnNavigatingTo(NavigationParameters parameters)
       {
       }
   }
}
