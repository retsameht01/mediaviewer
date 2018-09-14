using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace tiniottest.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 

    public sealed partial class MediaSlider : Page
    {
        //BitmapImage bitmap = new BitmapImage(new Uri(base.BaseUri, @"/Assets/" + weather.IconString + ".png"));
        //weatherIcon.Source = bitmap; 

        private  List<string> adsImages = new List<string>();
        private int currentIndex = 0;
        public MediaSlider()
        {
            this.InitializeComponent();
            adsImages.Add("/Assets/ads_sample/add_new.jpg");
            adsImages.Add("/Assets/ads_sample/ads_1.jpg");
            adsImages.Add("/Assets/ads_sample/pepsi_french.jpg");
            adsImages.Add("/Assets/ads_sample/scary_ad.jpg");
            Loaded += MainWindow_Loaded;

           

        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {

            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 10);
            dispatcherTimer.Tick += changePicture;
            dispatcherTimer.Start();
            //This is to start the tim
        }

        private void changePicture(object sender, object e)
        {
            BitmapImage bitmap = new BitmapImage(new Uri(base.BaseUri, @adsImages[currentIndex]));
            //new Uri("Assets/Icons/noprofilepic.png", UriKind.Relative)
            imageView.Source = bitmap;
            currentIndex++;
            currentIndex = currentIndex % adsImages.Count; 
        }
    }
}
