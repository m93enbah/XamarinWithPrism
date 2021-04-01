using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace PrismToutarial.ViewModels
{
    public class ViewBViewModel : ViewModelBase
    {

        public ViewBViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        : base(navigationService, pageDialogService)
        {
            Title = "View B Page";
        }

        private DelegateCommand _navigateCommand;
        public DelegateCommand NavigateCommand => _navigateCommand ?? (_navigateCommand = new DelegateCommand(ExecuteNavigateCommand));

        public async void ExecuteNavigateCommand() 
        {
            var p = new NavigationParameters("firstParam=First Params From ViewB&secondParam=Second Params From ViewB");
            await NavigationService.NavigateAsync("MainPage",p);
        }
    }
}
