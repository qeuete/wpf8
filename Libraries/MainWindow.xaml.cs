using System.Windows;
using System.Windows.Media;

namespace Libraries
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BlueTheme_Click(object sender, RoutedEventArgs e)
        {
            ChangeTheme("Themes/BlueTheme.xaml");
        }

        private void GreenTheme_Click(object sender, RoutedEventArgs e)
        {
            ChangeTheme("Themes/GreenTheme.xaml");
        }

        private void ChangeTheme(string themePath)
        {
            var dict = new ResourceDictionary { Source = new Uri(themePath, UriKind.Relative) };
            Application.Current.Resources.MergedDictionaries[0] = dict;
        }

        private void serializationBtn_Click(object sender, RoutedEventArgs e)
        {
            string textToSerialize = inputText.Text;
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string jsonFilePath = Path.Combine(desktopPath, "serialized_text.json");
            Json.SerializeToFile(textToSerialize, jsonFilePath);

            inputText.Text = "";
        }

        private void deserializationBtn_Click(object sender, RoutedEventArgs e)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string jsonFilePath = Path.Combine(desktopPath, "serialized_text.json");
            string deserializedText = Json.DeserializeFromFile<string>(jsonFilePath);
            if (!string.IsNullOrEmpty(deserializedText))
            {
                dataLbx.Items.Add(deserializedText);
            }
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
