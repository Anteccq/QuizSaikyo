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

        public static Quiz[] Default => new[]{
            new Quiz("チャレンジラボの2階にはAIラボがある", true),
            new Quiz("扇が丘キャンパスには食堂が2つある", true), 
            new Quiz("やつかほリサーチキャンパスには、「ACQUA」2号店がある", false),
            new Quiz("次にあなたが雪だるまを置くのは X である", false)
        };
    }
}