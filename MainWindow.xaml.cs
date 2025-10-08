using System;
using System.Collections.Generic;
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

namespace Calculating_triangles
{
    public partial class MainWindow : Window 
    {
        public MainWindow()
        {
            InitializeComponent();
            TextBoxC.KeyDown += TextBoxC_KeyDown;

            Loaded += (sender, e) => TextBoxA.Focus();
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            CalculateTriangleType();
        }

        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            TextBoxA.Clear();
            TextBoxB.Clear();
            TextBoxC.Clear();

            ResultPanel.Visibility = Visibility.Collapsed;
            InputPanel.Visibility = Visibility.Visible;

            TextBoxA.Focus();
        }

        private void TextBoxC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                CalculateTriangleType();
            }
        }

        private void CalculateTriangleType()
        {
            double a, b, c;

            if (!double.TryParse(TextBoxA.Text, out a) || a <= 0 ||
                !double.TryParse(TextBoxB.Text, out b) || b <= 0 ||
                !double.TryParse(TextBoxC.Text, out c) || c <= 0)
            {
                MessageBox.Show("Пожалуйста, введите положительные числа для длин сторон.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!(a + b > c && a + c > b && b + c > a))
            {
                ResultTextBlock.Text = "Это не треугольник (стороны не удовлетворяют теореме неравенства).";
            }
            else
            {
                if (a == b && b == c)
                {
                    ResultTextBlock.Text = "Полученный треугольник равносторонний.";
                }
                else if (a == b || b == c || a == c)
                {
                    ResultTextBlock.Text = "Полученный треугольник равнобедренный.";
                }
                else
                {
                    ResultTextBlock.Text = "Полученный треугольник разносторонний.";
                }
            }

            InputPanel.Visibility = Visibility.Collapsed;
            ResultPanel.Visibility = Visibility.Visible;
        }
    }
}