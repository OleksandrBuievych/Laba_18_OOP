using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba_18_OOP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("В одномірному масиві, що складається з n дійсних елементів, розрахувати:\n а) кількість додатних елементів масиву;\n б) суму елементів масиву, розташованих після останнього елементу, рівного нулю. \nПеретворити масив таким чином, щоб спочатку розташовувались усі елементи, ціла частина яких не перевищує 1, а потім – усі інші. \nРезультати всіх розрахунків і перетворень масиву вивести на консоль.");
        }

        private void DoTask1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Replace(".", ","); 
            try
            {
                double[] array = textBox1.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                                .Select(x => double.Parse(x))
                                                .ToArray();


                // Розрахунок кількості додатних елементів масиву
                int positiveCount = array.Where(x => x > 0).Count();

                // Розрахунок суми елементів масиву, розташованих після останнього елементу, рівного нулю
                double sumAfterLastZero = 0;
                int lastIndex = Array.LastIndexOf(array, 0);
                if (lastIndex != -1 && lastIndex != array.Length - 1)
                {
                    sumAfterLastZero = array.Skip(lastIndex + 1).Sum();
                }

                // Перетворення масиву
                double[] transformedArray = array.OrderBy(x => Math.Truncate(x) <= 1 ? 0 : 1)
                                                 .ThenBy(x => x)
                                                 .ToArray();

                // Виведення результатів в MessageBox
                string resultMessage = $"Кількість додатних елементів масиву: {positiveCount}\n"
                                       + $"Сума елементів масиву, розташованих після останнього елементу, рівного нулю: {sumAfterLastZero}\n\n"
                                       + $"Перетворений масив: {string.Join(", ", transformedArray)}";
                MessageBox.Show(resultMessage, "Результати");
            }
            catch (Exception) 
            {
                MessageBox.Show("Будь-ласка перевірте введені дані!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Даний двовимірний масив. Вивести на екран:\n а) увесь масив;\n б) усі елементи п’ятого рядка масиву;\n в) усі елементи s - го стовбця масиву.");
        }

        private void DoTask2_Click(object sender, EventArgs e)
        {
            int[,] array = new int[,]
            {
                { 1, 2, 3, 4, 5 },
                { 6, 7, 8, 9, 10 },
                { 11, 12, 13, 14, 15 },
                { 16, 17, 18, 19, 20 },
                {21, 22, 23, 24, 25}
            };

            // Виведення усього масиву
            string arrayString = "Увесь масив:\n";
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    arrayString += array[i, j] + "\t";
                }
                arrayString += "\n";
            }

            // Виведення елементів п'ятого рядка масиву
            string fifthRowString = "Елементи п'ятого рядка масиву:\n";
            for (int j = 0; j < array.GetLength(1); j++)
            {
                fifthRowString += array[4, j] + "\t";
            }

            // Виведення елементів s-го стовбця масиву
            int s = int.Parse(textBox2.Text);
            string sColumnString = $"Елементи {s}-го стовбця масиву:\n";
           try
            {
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    sColumnString += array[i, s - 1] + "\n";
                }
            }
           catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Такого стовпця масиву не існує!!!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Виведення результатів в MessageBox
            string resultMessage = $"{arrayString}\n{fifthRowString}\n{sColumnString}";
            MessageBox.Show(resultMessage, "Результати");
        }
    }
}
