using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Construction; // Подключение пространства имен библиотеки Construction

namespace classwork22._09
{
    /// <summary>
    /// Главное окно WPF-приложения для строительных расчетов
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Конструктор главного окна
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Преобразует строку в число с плавающей точкой
        /// </summary>
        /// <param name="text">Текст для преобразования</param>
        /// <returns>Число типа double</returns>
        private double ParseNumber(string text)
        {
            // Заменяем запятую на точку и парсим
            text = text.Replace(',', '.');
            return double.Parse(text, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Обработчик нажатия кнопки расчета обоев
        /// </summary>
        private void BtnWallpaper_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Парсим введенные пользователем значения
                double roomWidth = ParseNumber(TbRoomWidthWallpaper.Text);
                double roomLength = ParseNumber(TbRoomLengthWallpaper.Text);
                double roomHeight = ParseNumber(TbRoomHeightWallpaper.Text);
                double windowWidth = ParseNumber(TbWindowWidth.Text);
                double windowHeight = ParseNumber(TbWindowHeight.Text);
                double doorWidth = ParseNumber(TbDoorWidth.Text);
                double doorHeight = ParseNumber(TbDoorHeight.Text);

                // Получаем выбранную ширину рулона из ComboBox
                string selectedWidth = (CbRollWidth.SelectedItem as System.Windows.Controls.ComboBoxItem).Content.ToString();
                double rollWidth = selectedWidth == "0.5 м" ? 0.5 : 1.0;

                // Создаем экземпляр строителя и вызываем метод расчета
                Builder builder = new Builder();
                int rolls = builder.PasteWallpaper(roomWidth, roomLength, roomHeight, windowWidth, windowHeight, doorWidth, doorHeight, rollWidth);

                // Выводим результат пользователю
                TbWallpaperResult.Text = $"Нужно рулонов: {rolls}";
            }
            catch
            {
                MessageBox.Show("Введите числа правильно! Например: 5 или 2.5");
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки расчета линолеума
        /// </summary>
        private void BtnLinoleum_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Парсим введенные пользователем значения
                double roomWidth = ParseNumber(TbRoomWidthLinoleum.Text);
                double roomLength = ParseNumber(TbRoomLengthLinoleum.Text);

                // Получаем выбранную ширину линолеума из ComboBox
                string selectedWidth = (CbLinoleumWidth.SelectedItem as System.Windows.Controls.ComboBoxItem).Content.ToString();
                double linoleumWidth = double.Parse(selectedWidth.Replace(" м", ""));

                // Создаем экземпляр строителя и вызываем метод расчета
                Builder builder = new Builder();
                double meters = builder.LayLinoleum(roomWidth, roomLength, linoleumWidth);

                // Выводим результат пользователю
                TbLinoleumResult.Text = $"Нужно метров: {meters:F2}";
            }
            catch
            {
                MessageBox.Show("Введите числа правильно! Например: 5 или 2.5");
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки расчета краски
        /// </summary>
        private void BtnPaint_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Парсим введенные пользователем значения
                double roomWidth = ParseNumber(TbRoomWidthPaint.Text);
                double roomLength = ParseNumber(TbRoomLengthPaint.Text);
                double paintConsumption = ParseNumber(TbPaintConsumption.Text);
                double canVolume = ParseNumber(TbCanVolume.Text);

                // Создаем экземпляр строителя и вызываем метод расчета
                Builder builder = new Builder();
                int cans = builder.CeilingPainting(roomWidth, roomLength, paintConsumption, canVolume);

                // Выводим результат пользователю
                TbPaintResult.Text = $"Нужно банок: {cans}";
            }
            catch
            {
                MessageBox.Show("Введите числа правильно! Например: 5 или 2.5");
            }
        }
    }
}