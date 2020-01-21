using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSaikyo.Models
{
    public class Quiz
    {
        public string Content { get; }
        public bool Correct { get; }

        public Quiz(string content, bool correct)
        {
            Content = content;
            Correct = correct;
        }

        public static Quiz[] Default => new[]{new Quiz("正解はTrue", true),new Quiz("正解はFalse", false),new Quiz("次にあなたがいう言葉はFalseですね", false)  };
    }
}