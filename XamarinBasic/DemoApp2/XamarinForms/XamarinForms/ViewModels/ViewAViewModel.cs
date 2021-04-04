using Prism.Commands;
using Prism.Navigation;
using System.Threading.Tasks;

namespace XamarinForms.ViewModels
{
    public class ViewAViewModel : ViewModelBase, IConfirmNavigation
    {
        public ViewAViewModel(INavigationService navigationService): base(navigationService)
        {
            Title = "View A Page";

            //it will allow to execute the button click by click to checkbox checked
            clickCommand = new DelegateCommand(ExecuteClick);
        }

        public DelegateCommand clickCommand { get; set; }

        private async void ExecuteClick() 
        {
          await  NavigationService.NavigateAsync("MainPage");
        }

        public override void Initialize(INavigationParameters parameters)
        {
            var id = parameters.GetValue<int>("id");
            Title = $"The id is : {id}";
        }

        public bool CanNavigate(INavigationParameters parameters)
        {
            var id = parameters.GetValue<int>("id");
            if (id == 3)
                return false;
            return true;
        }
    }
}
