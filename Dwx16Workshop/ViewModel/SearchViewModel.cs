using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using QuizApiClient;
using QuizApiClient.Model;

namespace Dwx16Workshop.ViewModel
{
    public class SearchViewModel : ViewModelBase
    {
        private readonly IQuizClient quizClient;
        private readonly INavigationService navigationService;
        private string searchTerm;
        private ObservableCollection<Set> sets;

        public string SearchTerm {
            get { return searchTerm; }
            set
            {
                Set(ref searchTerm, value);
            }
        }

        public RelayCommand SearchCommand
        {
            get
            {
                return new RelayCommand(HandleSearchCommand);
            }
        }

        public RelayCommand<object> ItemClickCommand
        {
            get
            {
                return new RelayCommand<object>(HandleItemClickCommand);
            }
        }

        private async void HandleItemClickCommand(object args)
        {
            var itemClickArgs = args as ItemClickEventArgs;
            if (itemClickArgs == null)
            {
                return;
            }

            var set = itemClickArgs.ClickedItem as Set;
            if (set == null)
            {
                return;
            }

            var detailedSet = await this.quizClient.GetSetAsync(set.id);

            var setVm = ServiceLocator.Current.GetInstance<SetViewModel>();
            setVm.Set = detailedSet;

            navigationService.NavigateTo("SetPageKey",detailedSet.id);
        }

        public SearchViewModel(IQuizClient quizClient, INavigationService navigationService)
        {
            this.quizClient = quizClient;
            this.navigationService = navigationService;
        }

        private async void HandleSearchCommand()
        {
            var result = await this.quizClient.SearchForSetsAsync(this.SearchTerm);
            this.Sets = new ObservableCollection<Set>(result.sets);
        }

        public ObservableCollection<Set> Sets
        {
            get { return sets; }
            set { Set(ref sets, value); }
        }
    }
}
