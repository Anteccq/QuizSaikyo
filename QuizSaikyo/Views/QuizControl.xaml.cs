using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using QuizSaikyo.ViewModels;

// ユーザー コントロールの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=234236 を参照してください

namespace QuizSaikyo.Views
{
    public sealed partial class QuizControl : Page
    {
        private CheckViewModel checkViewModel;
        public QuizControl()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.DataContext = MainPageViewModel.CurrentQuiz;
            if (e.Parameter is MainPageViewModel data)
            {
                data.SerialByte.Throttle(TimeSpan.FromMilliseconds(1000))
                    .Where(x => x != 0x00)
                    .ObserveOn(SynchronizationContext.Current)
                    .Subscribe(serialData =>
                    {
                        Debug.WriteLine("QuizControl Rx");
                        checkViewModel = new CheckViewModel((serialData == 0x01) == MainPageViewModel.CurrentQuiz.Value.Correct, data.SerialByte);
                        Frame.Navigate(typeof(CheckPage), checkViewModel);
                    });
            }
            base.OnNavigatedTo(e);
        }
    }
}
