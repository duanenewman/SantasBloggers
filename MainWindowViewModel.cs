using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace ObservableMvvm
{
    public class MainWindowViewModel : BindableBase
    {
        private ObservableCollection<BloggerViewModel> santasBloggers = new ObservableCollection<BloggerViewModel>();
        public ObservableCollection<BloggerViewModel> SantasBloggers { get => santasBloggers; set => SetProperty(ref santasBloggers, value); }

        private bool useUpdateItemsExtension;
        public bool UseUpdateItemsExtension { get => useUpdateItemsExtension; set => SetProperty(ref useUpdateItemsExtension, value); }

        public SantasBloggerService BloggerService { get; } = new SantasBloggerService();
        public WpfDispatcher Dispatcher { get; }= new WpfDispatcher();
        
        public MainWindowViewModel()
        {
            Task.Run(() => UpdateBloggers());
        }

        private void UpdateBloggers()
        {
            while (true)
            {
                var updatedBloggers = BloggerService.GetSantasBloggers();

                if (UseUpdateItemsExtension)
                {
                    var modelToViewModelMatcher = new Func<BloggerViewModel, Blogger, bool>((vm, model) => vm.Id == model.Id);

                    var viewModelUpdater = new Action<BloggerViewModel, Blogger>((vm, model) => { vm.NaughtyNiceRating = model.NaughtyNiceRating; vm.JustAdded = false; });
                    
                    //we have to dispatch because a .Remove or .Add to the observable has to be on the UI thread.
                    Dispatcher.BeginInvoke(() =>
                    {
                        SantasBloggers.UpdateItems(updatedBloggers, modelToViewModelMatcher, MapBloggerToBloggerViewModel, viewModelUpdater);
                    });
                }
                else
                {
                    SantasBloggers = new ObservableCollection<BloggerViewModel>(updatedBloggers.Select(MapBloggerToBloggerViewModel));
                }

                Task.Delay(1000).Wait();
            }
        }

        private BloggerViewModel MapBloggerToBloggerViewModel(Blogger model)
        {
            return new BloggerViewModel(model.Id)
            {
                Name = model.Name,
                Blog = model.Blog,
                NaughtyNiceRating = model.NaughtyNiceRating
            };
        }
    }
}
