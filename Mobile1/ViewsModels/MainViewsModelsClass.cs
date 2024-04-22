using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Mobile1.ViewsModels
{
    internal class MainViewsModelsClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged; // Создание ивента

        private byte _R; // Переменные для букв (внутрянки)
        public byte R { get { return _R; } set { _R = value; OnPropertyChanged(); updateColor(); } } // Переменная для внешних действий

        private byte _G;

        public byte G { get { return _G; } set { _G = value; OnPropertyChanged(); updateColor(); } }

        private byte _B;

        public byte B { get { return _B; } set { _B = value; OnPropertyChanged(); updateColor(); } }

        private Brush _Brush; // Приватная переменная кисти для смешивания

        public Brush Brush { get { return _Brush; } set { _Brush = value; OnPropertyChanged(); } } // Внешняя кисть


        public void OnPropertyChanged([CallerMemberName] string name = "")// ф-я вызова ивента
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void updateColor() // ф-я добавления цвета на браш с слайдеров
        {
            Brush = new SolidColorBrush(Color.FromRgb( R, G, B));
        }

        public DelegateCommand UpdateClipBoardCommand
        {
            get { return new DelegateCommand(Object => { updateClipBoard(); }); } // ф-я обмена
        }

        private void updateClipBoard()
        {
            Clipboard.SetText("Код цвета: " + Color.FromRgb(R, G, B).ToString() + "."); // копирование кода цвета
        }

    }
}
