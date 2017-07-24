using GalaSoft.MvvmLight;

using PropertyChanged;

namespace OCineManagerApps.OcineManager.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    [ImplementPropertyChanged]
    public class MainViewModel : ViewModelBase
    {
        
        public MainViewModel()
        {
        }
        public FilmsViewModel FilmVm { get; }
        public CinemaViewModel CinemaVm { get; }
        public SeancesViewModel SeancesVm { get; }
    }
}