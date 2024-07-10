using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Printing3D;
using WinUIEx;
using CommunityToolkit.WinUI.Controls;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using val_stat.Models;
using Microsoft.UI;
using Windows.UI;
using Windows.UI.Popups;
using Microsoft.UI.Xaml.Media.Imaging;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using Microsoft.UI.Xaml.Media.Animation;
using Windows.UI.ApplicationSettings;
using Microsoft.UI.Xaml.Shapes;
using Windows.Networking.NetworkOperators;
using static System.Net.WebRequestMethods;
using System.Data;
using CommunityToolkit.WinUI.UI.Controls;
using Windows.System;
// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace val_stat
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public static event Action UserInfoUpdated;
        private MainViewModel ViewModel { get; set; }
        public MainWindow()
        {

            this.InitializeComponent();
            this.CenterOnScreen();
            this.SetWindowSize(1024, 258);
            this.Title = "Val.stat beta 0.01";
            var manager = WinUIEx.WindowManager.Get(this);
            manager.MinHeight = 700;
            manager.MinWidth = 900;
            ViewModel = new MainViewModel();
            this.NavView.DataContext = ViewModel;
            Init_Apikey();
            var itemToSelect = NavView.MenuItems.OfType<NavigationViewItem>().FirstOrDefault(item => item.Tag.ToString() == "home");
            if (itemToSelect != null)
            {
                NavView.SelectedItem = itemToSelect;
                NavigateToPage(itemToSelect as NavigationViewItem);
            }
        }

        public void Init_Apikey()
        {
            apiKeyVariable.apiKey = "your-api-key";
            valorantUser.login_auth = false;
        }

        public async void GetUserInfo()
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("https://api.henrikdev.xyz/valorant/v1/account/" + valorantUser.usr_Name + "/" + valorantUser.usr_Tag + "?api_key=" + apiKeyVariable.apiKey);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                v1AccountModel.Root root = JsonConvert.DeserializeObject<v1AccountModel.Root>(responseBody);
                valorantUser.usr_Name = root.data.name;
                valorantUser.usr_Tag = root.data.tag;
                valorantUser.usr_level = root.data.account_level;
                valorantUser.usr_region = root.data.region;
                valorantUser.login_auth = true;
                apiLinks.accountLink = "https://api.henrikdev.xyz/valorant/v1/account/" + valorantUser.usr_Name + "/" + valorantUser.usr_Tag + "?api_key=" + apiKeyVariable.apiKey;
                UserHistory();
                if (root.data.card != null)
                {
                    valorantUser.is_usrHasProfilePicture = true;
                    valorantUser.usr_card_s = root.data.card.small;
                    valorantUser.usr_card_l = root.data.card.large;
                    valorantUser.usr_card_w = root.data.card.wide;
                }
                else
                {
                    valorantUser.is_usrHasProfilePicture = false;
                    setInfoBar("Warning", "Your profile is not loaded because your last match is too long ago.", InfoBarSeverity.Warning);
                }
                try
                {
                    HttpClient client1 = new HttpClient();
                    HttpResponseMessage response1 = await client1.GetAsync("https://api.henrikdev.xyz/valorant/v2/mmr/eu/" + valorantUser.usr_Name + "/" + valorantUser.usr_Tag + "?api_key=" + apiKeyVariable.apiKey);
                    response1.EnsureSuccessStatusCode();
                    string responseBody1 = await response1.Content.ReadAsStringAsync();
                    apiLinks.mmrLink = "https://api.henrikdev.xyz/valorant/v2/mmr/eu/" + valorantUser.usr_Name + "/" + valorantUser.usr_Tag + "?api_key=" + apiKeyVariable.apiKey;
                    try
                    {
                        v2MMRModel.Root mmrRoot = JsonConvert.DeserializeObject<v2MMRModel.Root>(responseBody1);
                        valorantUser.usr_rank = mmrRoot.data.current_data.currenttierpatched;
                        valorantUser.usr_rankImage_url = mmrRoot.data.current_data.images.large;
                    }
                    catch (Exception)
                    {
                        valorantUser.usr_rank = "Unranked";
                        valorantUser.usr_rankImage_url = "https://media.valorant-api.com/competitivetiers/564d8e28-c226-3180-6285-e48a390db8b1/0/largeicon.png";
                    }
                }
                catch (HttpRequestException ex)
                {
                    ErrorDialog("HttpClient erorr", ex.Message);
                }
                UserInfoUpdated?.Invoke();
            }
            catch (HttpRequestException ex)
            {
                ErrorDialog("HttpClient error", ex.Message);
                valorantUser.login_auth = false;
            }
        }


        private void setUsersForHistoryCard() {
            var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            var path = System.IO.Path.Combine(systemPath, "ValStatHistory.txt");
            string[] rows = System.IO.File.ReadAllLines(path);
            foreach (var row in rows)
            {

                string[] datas = row.Split(';');
                foreach (var data in datas) {
                    if (string.IsNullOrWhiteSpace(data))
                    {
                        continue;
                    }
                    ViewModel.AddUser(data);
                    string[] parts = data.Split('#');

                    if (parts.Length == 2)
                    {
                        userHistoryModel.apiName = parts[0];
                        userHistoryModel.apiTag = parts[1];

                    }
                }
                
            }
        }

        private void UserHistory()
        {
            var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            var path = System.IO.Path.Combine(systemPath, "ValStatHistory.txt");
            string data = valorantUser.usr_Name + "#" + valorantUser.usr_Tag;
            if (CheckIfUserExistsOnHistory(path, data)){}
            else
            {
                AddToHistory(path, data);
            }
        }
        static bool CheckIfUserExistsOnHistory(string filepath, string checkdata)
        {
            if (!System.IO.File.Exists(filepath))
                return false;
            string[] rows = System.IO.File.ReadAllLines(filepath);
            foreach (string row in rows)
            {
                string[] datas = row.Split(';');
                foreach (string data in datas)
                {
                    if (data.Trim().Equals(checkdata))
                        return true;
                }
            }
            return false;
        }
        static void AddToHistory(string filepath, string data)
        {
            using (StreamWriter dosya = new StreamWriter(filepath, true))
            {
                dosya.Write(data + ";"); // Veriyi dosyaya yaz, her verinin sonuna ; ekle
            }
        }

        public async void ErrorDialog(string title, string error)
        {
            ContentDialog errorDialog = new ContentDialog
            {
                Title = title,
                Content = error,
                PrimaryButtonText = "Ok"
            };
            errorDialog.XamlRoot = NavView.XamlRoot;
            ContentDialogResult result = await errorDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                GetValorantUserInfo();
            }
        }

        public async void GetValorantUserInfo()
        {
            setUsersForHistoryCard();
            var container = new StackPanel()
            {
                Width = 350
            };
            var test = new SettingsExpander()
            {
                Header = "History",
                Margin = new Thickness(0, 10, 0, 10)
            };
            foreach (var user in ViewModel.Users){
                SettingsCard settingsCard = new SettingsCard
                {
                    Header = user,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    IsClickEnabled = true,
                    HorizontalContentAlignment = HorizontalAlignment.Left,

                };
                test.Items.Add(settingsCard);
            }
            TextBox nameTextBox = new TextBox()
            {
                PlaceholderText = "Name",
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Style = (Style)Application.Current.Resources["AccentButtonStyle"],
            };
            TextBox tagTextBox = new TextBox()
            {
                PlaceholderText = "Tag",
                Margin = new Thickness(0, 10, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Stretch
            };
            nameTextBox.AcceptsReturn = false;
            tagTextBox.AcceptsReturn = false;
            container.Children.Add(nameTextBox);
            container.Children.Add(tagTextBox);
            container.Children.Add(test);
            //container.Children.Add(settingsExpander);
            ContentDialog userDialog = new ContentDialog
            {
                Title = "Valorant Login",
                Content = container,
                PrimaryButtonText = "Ok",
                CloseButtonText = "Cancel",
                Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style
            };
            userDialog.XamlRoot = NavView.XamlRoot;
            ContentDialogResult result = await userDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                valorantUser.usr_Name = nameTextBox.Text;
                valorantUser.usr_Tag = tagTextBox.Text;
                GetUserInfo();
            }
        }

        public void MyNavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.SelectedItemContainer is NavigationViewItem selectedItem)
            {
                NavigateToPage(selectedItem);
            }
        }

        public void NavigateToPage(NavigationViewItem selectedItem)
        {
            switch (selectedItem.Tag)
            {
                case "home":
                    ContentFrame.Navigate(typeof(Home));
                    break;
                case "settings":
                    ContentFrame.Navigate(typeof(Settings));
                    break;
            }
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            GetValorantUserInfo();
        }
        public void setInfoBar(string Title, string Message, InfoBarSeverity severity)
        {
            infobar.IsOpen = true;
            infobar.Title = Title;
            infobar.Message = Message;
            infobar.Severity = severity;
            
        }
    }
}
