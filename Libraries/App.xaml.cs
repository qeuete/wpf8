using System.IO;
using System.Windows;

namespace Libraries
{
    public partial class App : Application
    {
        private static string theme;
        public static string Theme
        {
            get { return theme; }
            set
            {
                theme = value;
                var dict = new ResourceDictionary { Source = new Uri("/LibraryThemes;component/Themes/" + value + ".xaml", UriKind.Relative) };

                Current.Resources.MergedDictionaries.RemoveAt(0);
                Current.Resources.MergedDictionaries.Insert(0, dict);

                var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                File.WriteAllText($"{desktop}\\theme.txt", value);
            }
        }
        public App()
        {
            InitializeComponent();

            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (File.Exists($"{desktop}\\theme.txt"))
            {
                Theme = File.ReadAllText($"{desktop}\\theme.txt");
            }
        }
    }
}