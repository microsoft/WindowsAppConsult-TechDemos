using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows;
using Windows.UI.Notifications;

namespace NotificationsSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnSendNotification(object sender, RoutedEventArgs e)
        {
            new ToastContentBuilder()
                .AddText("Hello world")
                .Show();
        }

        private void OnSendHeroNotification(object sender, RoutedEventArgs e)
        {
            string imagePath = $"file:///{System.IO.Path.GetFullPath("HeroImage.png")}";

            new ToastContentBuilder()
                .AddText("Hello world")
                .AddHeroImage(new Uri(imagePath), "Forest")
                .Show();
        }

        private void OnSendInteractiveNotification(object sender, RoutedEventArgs e)
        {
            ToastNotificationManagerCompat.OnActivated += (args) =>
            {
                string outcome = string.Empty;

                switch (args.Argument)
                {
                    case "yes":
                        outcome = "You have clicked yes";
                        break;
                    case "no":
                        outcome = "You have clicked no";
                        break;
                };

                Dispatcher.Invoke(() =>
                {
                    txtStatus.Text = outcome;
                });
            };


            new ToastContentBuilder()
                .AddText("Do you want to get more information on the topic?")
                .AddButton(new ToastButton()
                    .SetContent("Yes")
                    .AddArgument("yes")
                    .SetBackgroundActivation())
                .AddButton(new ToastButton()
                    .SetContent("No")
                    .AddArgument("no")
                    .SetBackgroundActivation())
                .Show();
        }

        private async void OnShowToast(object sender, RoutedEventArgs e)
        {
            string tag = "download-update";

            new ToastContentBuilder()
            .AddText("Updating your collection")
            .AddVisualChild(new AdaptiveProgressBar()
            {
                Title = "Download in progress",
                Value = new BindableProgressBarValue("progressValue"),
                ValueStringOverride = new BindableString("progressValueString"),
                Status = "Downloading"
            })
            .Show(toast =>
            {
                toast.Tag = tag;
                toast.Data = new NotificationData(new Dictionary<string, string>()
                {
                    { "progressValue", "0.0" },
                    { "progressValueString", "1/5 songs" }
                }, 1);
            });

            for (uint cont = 1; cont <= 5; cont++)
            {
                await Task.Delay(1000);
                var data = new NotificationData
                {
                    SequenceNumber = cont
                };

                IFormatProvider provider = CultureInfo.CreateSpecificCulture("en-US");

                double progressValue = (double)cont / 10 * 2;
                string progressValueConverted = progressValue.ToString(provider);
                Debug.WriteLine(progressValueConverted);

                data.Values["progressValue"] = progressValueConverted;
                data.Values["progressValueString"] = $"{cont} / 5 songs";

                ToastNotificationManagerCompat.CreateToastNotifier().Update(data, tag);
            }

            new ToastContentBuilder().
                AddText("Download completed!")
                .Show();
        }
    }
}
