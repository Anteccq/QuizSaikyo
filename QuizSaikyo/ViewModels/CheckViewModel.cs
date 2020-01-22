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
        public bool IsCorrect { get; }
        public string Text { get; }
        public ReadOnlyReactiveProperty<int> SerialByte { get; }

        public CheckViewModel(bool isCorrect, ReadOnlyReactiveProperty<int> serialByte)
        {
            IsCorrect = isCorrect;
            Text = isCorrect ? "やるじゃねえか" : "は？";
            SerialByte = serialByte;
        }
    }
}
