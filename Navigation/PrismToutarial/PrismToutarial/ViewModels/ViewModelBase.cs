using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System.Threading.Tasks;

namespace PrismToutarial.ViewModels
{
    public class ViewModelBase : BindableBase, IInitialize, INavigationAware, IDestructible ,IConfirmNavigationAsync
    {
        protected INavigationService NavigationService { get; private set; }

        protected IPageDialogService PageDialogService { get; private set; }


        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _firstParam;

        public string FirstParam 
        {
            get { return _firstParam; }
            set { SetProperty(ref _firstParam, value); }
        }


        private string _secondParam;

        public string SecondParam
        {
            get { return _firstParam; }
            set { SetProperty(ref _secondParam, value); }
        }
        //we inject IPageDialogService on the constructor level as below
        public ViewModelBase(INavigationService navigationService,IPageDialogService pageDialogService)
        {
            NavigationService = navigationService;
            PageDialogService = pageDialogService;
        }

        public virtual void Initialize(INavigationParameters parameters)
        {

        }

        //when thre request send from the current page
        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
            FirstParam = parameters["firstParam"] != null ? parameters["firstParam"].ToString() : string.Empty;
            SecondParam = parameters["secondParam"] != null ? parameters["secondParam"].ToString() : string.Empty;
        }

        //when the request recieved from the target page
        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
            FirstParam = parameters["firstParam"] != null ? parameters["firstParam"].ToString() : string.Empty;
            SecondParam = parameters["secondParam"] != null ? parameters["secondParam"].ToString() : string.Empty;
        }

        public virtual void Destroy()
        {

        }

        public Task<bool> CanNavigateAsync(INavigationParameters parameters)
        {
            return PageDialogService.DisplayAlertAsync("My Title", "Save ?", "Accept", "Cancel");
        }
    }
}
