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
using Windows.ApplicationModel.Background;
using CommunityToolkit.WinUI.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace val_stat
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Home : Page
    {
        public Home()
        {
            this.InitializeComponent();
            if (valorantUser.login_auth)
            {
                SetXAML();
            }
            MainWindow.UserInfoUpdated += OnUserInfoUpdated;
            
        }
        private void OnUserInfoUpdated()
        {
            SetXAML();
        }
        public void SetXAML()
        {
            //Set profile picture
            if (valorantUser.is_usrHasProfilePicture)
            {
                Uri uri = new Uri(valorantUser.usr_card_s);
                BitmapImage bmpPP = new BitmapImage();
                bmpPP.UriSource = uri;
                usr_pp.ProfilePicture = bmpPP;
            }
            else {
                usr_pp.DisplayName = valorantUser.usr_Name + valorantUser.usr_Tag;
            }
            //set ranks levels names and tags etc.
            usr_nametag.Text = valorantUser.usr_Name + "#" + valorantUser.usr_Tag;
            usr_level.Text = valorantUser.usr_level.ToString();
            usr_rank.Text = valorantUser.usr_rank;
            Uri usrRankImage = new Uri(valorantUser.usr_rankImage_url);
            BitmapImage usrRankBitmap = new BitmapImage();
            usrRankBitmap.UriSource = usrRankImage;
            usr_rankImage.Source = usrRankBitmap;
            UserRankBackGroundColorSet();
            UserLevelBackgroundColorSet();
            Uri accountApi = new Uri(apiLinks.accountLink);
            Uri mmrApi = new Uri(apiLinks.mmrLink);
            link1.NavigateUri = accountApi;
            link2.NavigateUri = mmrApi;

        }

        Color ConvertHexToColor(string hex)
        {
            hex = hex.Replace("#", string.Empty);
            byte a = 255;
            byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
            return Color.FromArgb(a, r, g, b);
        }

        public void RankColorsSet()
        {
            rankColors.iron = "#929292";
            rankColors.bronze = "#9b8054";
            rankColors.silver = "#f2f7f6";
            rankColors.gold = "#f0d558";
            rankColors.platinum = "#3a95a4";
            rankColors.diamond = "#a96ff0";
            rankColors.ascendant = "#2faa6e";
            rankColors.immortal = "#aa4471";
            rankColors.radiant = "#d4b67e";
            rankColors.unranked = "#4a5055";
        }
        public void LevelColorSet()
        {
            levelColors.level1 = "#c3c0bf";
            levelColors.level2 = "#72584e";
            levelColors.level3 = "#344446";
            levelColors.level4 = "#7d7157";
            levelColors.level5 = "#234b46";

        }

        private void UserRankBackGroundColorSet()
        {
            RankColorsSet();
            switch (valorantUser.usr_rank)
            {
                case string iron when iron.Contains("Iron"):
                    Color ironColor = ConvertHexToColor(rankColors.iron);
                    SolidColorBrush solidColorBrush = new SolidColorBrush(ironColor);
                    rankBackground.Background = solidColorBrush;
                    break;
                case string bronze when bronze.Contains("Bronze"):
                    Color bronzeColor = ConvertHexToColor(rankColors.bronze);
                    SolidColorBrush solidColorBrush1 = new SolidColorBrush(bronzeColor);
                    rankBackground.Background = solidColorBrush1;
                    break;
                case string silver when silver.Contains("Silver"):
                    Color silverColor = ConvertHexToColor(rankColors.silver);
                    SolidColorBrush solidColorBrush2 = new SolidColorBrush(silverColor);
                    rankBackground.Background = solidColorBrush2;
                    break;
                case string gold when gold.Contains("Gold"):
                    Color goldColor = ConvertHexToColor(rankColors.gold);
                    SolidColorBrush solidColorBrush3 = new SolidColorBrush(goldColor);
                    rankBackground.Background = solidColorBrush3;
                    break;
                case string platinum when platinum.Contains("Platinum"):
                    Color platinumColor = ConvertHexToColor(rankColors.platinum);
                    SolidColorBrush solidColorBrush4 = new SolidColorBrush(platinumColor);
                    rankBackground.Background = solidColorBrush4;
                    break;
                case string diamond when diamond.Contains("Diamond"):
                    Color diamondColor = ConvertHexToColor(rankColors.diamond);
                    SolidColorBrush solidColorBrush5 = new SolidColorBrush(diamondColor);
                    rankBackground.Background = solidColorBrush5;
                    break;
                case string ascendant when ascendant.Contains("Ascendant"):
                    Color ascendantColor = ConvertHexToColor(rankColors.ascendant);
                    SolidColorBrush solidColorBrush6 = new SolidColorBrush(ascendantColor);
                    rankBackground.Background = solidColorBrush6;
                    break;
                case string immortal when immortal.Contains("Immortal"):
                    Color immortalColor = ConvertHexToColor(rankColors.immortal);
                    SolidColorBrush solidColorBrush7 = new SolidColorBrush(immortalColor);
                    rankBackground.Background = solidColorBrush7;
                    break;
                case string radiant when radiant.Contains("Radiant"):
                    Color radiantColor = ConvertHexToColor(rankColors.radiant);
                    SolidColorBrush solidColorBrush8 = new SolidColorBrush(radiantColor);
                    rankBackground.Background = solidColorBrush8;
                    break;
            }
        }

        private void UserLevelBackgroundColorSet()
        {
            LevelColorSet();
            switch (valorantUser.usr_level)
            {
                case int level5 when (level5 >= 400):
                    Color level5Color = ConvertHexToColor(levelColors.level5);
                    SolidColorBrush solidColorBrush5 = new SolidColorBrush(level5Color);
                    levelBackground.Background = solidColorBrush5;
                    break;
                case int level4 when (level4 >= 300 && level4<=399):
                    Color level4Color = ConvertHexToColor(levelColors.level4);
                    SolidColorBrush solidColorBrush4 = new SolidColorBrush(level4Color);
                    levelBackground.Background = solidColorBrush4;
                    break;
                case int level3 when (level3 >= 200 && level3<=299):
                    Color level3Color = ConvertHexToColor(levelColors.level3);
                    SolidColorBrush solidColorBrush3 = new SolidColorBrush(level3Color);
                    levelBackground.Background = solidColorBrush3;
                    break;
                case int level2 when (level2 >= 100 && level2<=199):
                    Color level2Color = ConvertHexToColor(levelColors.level2);
                    SolidColorBrush solidColorBrush2 = new SolidColorBrush(level2Color);
                    levelBackground.Background = solidColorBrush2;
                    break;
                case int level1 when (level1 >= 0 && level1<=99):
                    Color level1Color = ConvertHexToColor(levelColors.level1);
                    SolidColorBrush solidColorBrush1 = new SolidColorBrush(level1Color);
                    levelBackground.Background = solidColorBrush1;
                    break;
            }
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
