using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WareHouseRelic
{
    static class OutText
    {
        /// <summary>
        /// Проверка на ввод цифр 0..9
        /// </summary>
        /// <param name="e">параметр события "KeyPress"</param>
        public static void EnterOnlyNumbers(KeyPressEventArgs e) 
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != 46 && e.KeyChar != 44)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Проверка на ввод букв Кирилицы и символа "пробел"
        /// </summary>
        /// <param name="e">параметр события "KeyPress"</param>
        public static void EnterOnlyLettersCyrillicAlphabet(KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && e.KeyChar != 8 && e.KeyChar != 32)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Проверка на ввод латинских букв и символа "пробел"
        /// </summary>
        /// <param name="e">параметр события "KeyPress"</param>
        public static void EnterOnlyLettersLatinAlphabet(KeyPressEventArgs e)
        {
            if ((e.KeyChar < 64 || e.KeyChar > 91) && (e.KeyChar < 96 || e.KeyChar > 123) && e.KeyChar != 8 && e.KeyChar != 32)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Проверка на ввод кирилицы и латинских букв, а так же символа "пробел"
        /// </summary>
        /// <param name="e">параметр события "KeyPress"</param>
        public static void EnterOnlyAlphabet(KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && (e.KeyChar < 64 || e.KeyChar > 91) && (e.KeyChar < 96 || e.KeyChar > 123) && e.KeyChar != 8 && e.KeyChar != 32)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Проверка на ввод кирилицы и латинских букв, цифр а так же символа "пробел"
        /// </summary>
        /// <param name="e">параметр события "KeyPress"</param>
        public static void EnterLettersAndNumbers(KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && (e.KeyChar < 'А' || e.KeyChar > 'я') && (e.KeyChar < 64 || e.KeyChar > 91) && (e.KeyChar < 96 || e.KeyChar > 123) && e.KeyChar != 8 && e.KeyChar != 32)
            {
                e.Handled = true;
            }
        }
    }
}
