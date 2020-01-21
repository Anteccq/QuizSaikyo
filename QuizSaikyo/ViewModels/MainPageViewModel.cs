using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using QuizSaikyo.Models;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace QuizSaikyo.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        public SerialManager SerialManager { get; } = new SerialManager();

        public ReadOnlyReactiveProperty<int> SerialByte { get; }

        public MainPageViewModel() => SerialByte = SerialManager.ObserveProperty(x => x.NextData).ToReadOnlyReactiveProperty();
    }
}
