using Prism.Commands;
using Prism.Navigation;
using System.Threading;

namespace XamarinForms.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private string _Desc;
        public string Description
        {
            get { return _Desc; }
            set { SetProperty(ref _Desc, value); }
        }

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

        public DelegateCommand clickCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            IsChecked = false;
            Title = "Main Page";
            Description = "Description Page";
            //it will allow to execute the button click by click to checkbox checked
            clickCommand = new DelegateCommand(ExecuteClick)
                          .ObservesCanExecute(() => IsChecked);
        }

        private void ExecuteClick()
        {
            Description = "Description was changed";
            Thread.Sleep(1000);
            var p1 = new NavigationParameters($"id=1&name=${Description}");
            NavigationService.NavigateAsync("ViewA", p1);
        }
    }
}
