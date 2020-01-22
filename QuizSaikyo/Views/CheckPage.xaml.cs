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

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=234238 を参照してください

namespace QuizSaikyo.Views
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class CheckPage : Page
    {
        public CheckPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is CheckViewModel data)
            {
                this.DataContext = data;
                data.SerialByte
                    .Where(x => x == 0x00)
                    .Delay(TimeSpan.FromMilliseconds(2000))
                    .FirstAsync()
                    .ObserveOn(SynchronizationContext.Current)
                    .Subscribe(_ =>
                    {
                        MainPageViewModel.Next();
                        Frame.Navigate(typeof(QuizControl));
                        Debug.WriteLine("CheckPage Rx");
                    });
                this.Grid.Background = data.IsCorrect ? OkBackGround : NgBackGround;
            }
            base.OnNavigatedTo(e);
        }
    }
}
