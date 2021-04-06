using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace PrismToutarial.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService,IPageDialogService pageDialogService)
        : base(navigationService, pageDialogService)
        {
            Title = "Main Page";
            //it will allow to execute the button click by click to checkbox checked
            _navigateCommand = new DelegateCommand(ExecuteNavigateCommand)
                          .ObservesCanExecute(() => IsChecked);
        }


        private DelegateCommand _navigateCommand;
        public DelegateCommand NavigateCommand => _navigateCommand ?? (_navigateCommand = new DelegateCommand(ExecuteNavigateCommand));


        private bool _isChecked;
        public bool IsChecked
        {
            get
            {
                return _isChecked;
            }
            set
            {
                SetProperty(ref _isChecked, value);
            }
        }


        public async void ExecuteNavigateCommand()
        {
            //we can pass parameter through NavigationService as below
            var p = new NavigationParameters("firstParam=First Params From MainPage&secondParam=Second Params From MainPage");
            await NavigationService.NavigateAsync("ViewA", p);
        }
    }
}
