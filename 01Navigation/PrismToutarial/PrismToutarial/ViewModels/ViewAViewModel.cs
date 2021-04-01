using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace PrismToutarial.ViewModels
{
    public class ViewAViewModel : ViewModelBase
    {
        public ViewAViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        : base(navigationService, pageDialogService) 
        {
            Title = "View A Page";
        }

        private DelegateCommand _navigateCommand;
        public DelegateCommand NavigateCommand => _navigateCommand ?? (_navigateCommand = new DelegateCommand(ExecuteNavigateCommand));

        public async void ExecuteNavigateCommand()
        {
            var p = new NavigationParameters("firstParam=First Params From ViewA&secondParam=Second Params From ViewA");
            await NavigationService.NavigateAsync("ViewB",p);
        }
    }
}
