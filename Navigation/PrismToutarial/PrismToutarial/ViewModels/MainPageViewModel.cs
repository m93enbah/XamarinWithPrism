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
        }


        private DelegateCommand _navigateCommand;
        public DelegateCommand NavigateCommand => _navigateCommand ?? (_navigateCommand = new DelegateCommand(ExecuteNavigateCommand));

        public async void ExecuteNavigateCommand()
        {
            //we can pass parameter through NavigationService as below
            var p = new NavigationParameters("firstParam=First Params From MainPage&secondParam=Second Params From MainPage");
            await NavigationService.NavigateAsync("ViewA", p);
        }
    }
}
