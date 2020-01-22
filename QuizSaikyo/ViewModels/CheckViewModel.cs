using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Reactive.Bindings;

namespace QuizSaikyo.ViewModels
{
    public class CheckViewModel : BindableBase
    {
        public string Text { get; }
        public ReadOnlyReactiveProperty<int> SerialByte { get; }

        public CheckViewModel(bool isCorrect, ReadOnlyReactiveProperty<int> serialByte)
        {
            Text = isCorrect ? "やるじゃねえか" : "は？";
            SerialByte = serialByte;
        }
    }
}
