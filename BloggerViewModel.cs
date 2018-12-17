namespace ObservableMvvm
{
    public class BloggerViewModel : BindableBase
    {
        public int Id { get; }

        private string name;
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        private string blog;
        public string Blog
        {
            get => blog;
            set => SetProperty(ref blog, value);
        }

        private NaughtyOrNice naughtyNiceRating;
        public NaughtyOrNice NaughtyNiceRating
        {
            get => naughtyNiceRating;
            set => SetProperty(ref naughtyNiceRating, value);
        }

        private bool justAdded = true;
        public bool JustAdded
        {
            get => justAdded;
            set => SetProperty(ref justAdded, value);
        }

        public BloggerViewModel(int id)
        {
            Id = id;
        }
    }

}
