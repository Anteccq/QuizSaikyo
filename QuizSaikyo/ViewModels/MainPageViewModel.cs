﻿using System;
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

        private Quiz[] quizzes = Quiz.Default;

        public ReactiveProperty<Quiz> CurrentQuiz { get; } = new ReactiveProperty<Quiz>();

        private int quizNum = 0;

        public MainPageViewModel()
        {
            SerialByte = SerialManager.ObserveProperty(x => x.NextData).ToReadOnlyReactiveProperty();
            CurrentQuiz.Value = quizzes[0];
        }

        public void Next() => CurrentQuiz.Value = quizzes[++quizNum % quizzes.Length];
    }
}
