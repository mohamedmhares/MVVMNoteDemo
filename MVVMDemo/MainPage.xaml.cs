namespace MVVMDemo
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            Container.Content = new View.NoteView();
        }

        
    }

}
