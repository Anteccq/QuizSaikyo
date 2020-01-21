using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace QuizSaikyo.ViewModels
{
    public class CheckViewModel : BindableBase
    {
        public string Text { get; }

        public CheckViewModel(bool isCorrect) => Text = isCorrect ? "やるじゃねえか" : "は？";
    }
}
