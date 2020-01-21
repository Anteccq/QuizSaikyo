using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
            if (e.Parameter is MainPageViewModel data)
            {
                this.DataContext = data.CurrentQuiz;
                data.SerialByte.FirstAsync()
                    .ObserveOn(Scheduler.CurrentThread)
                    .Subscribe(serialData =>
                    {
                        checkViewModel = new CheckViewModel(serialData == 0x01);
                        data.Next();
                        Frame.Navigate(typeof(CheckPage), checkViewModel);
                    });
            }
            base.OnNavigatedTo(e);
        }
    }
}
