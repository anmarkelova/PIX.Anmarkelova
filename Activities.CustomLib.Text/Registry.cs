using System.Globalization;
using System.Threading;

namespace Activities.CustomLib.Text
{
    /// <summary>
    /// Перечисление основных типов регистра.
    /// </summary>
    public enum Registry
    {
        /// <summary>
        /// Регистр написания текста, при котором заглавные буквы не пишутся.
        /// </summary>
        LowerCase = 0,
        /// <summary>
        /// Регистр написания текста, при котором каждый символ пишется с большой буквы.
        /// </summary>
        UpperCase = 1,
        /// <summary>
        /// Регистр написания текста, при котором первая буква каждого слова заглавная.
        /// </summary>
        TitleCase = 2

    }

    public class RegistryClass
    {
        /// <summary>
        /// Метод для приведения текста к регистру Title.
        /// </summary>
        /// <param name="text">Входящий текст.</param>
        /// <returns>Текст, в котором первая буква каждого слова - заглавная.</returns>/returns>
        public static string ToTitleCase(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }

            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            return textInfo.ToTitleCase(text.ToLower());
        }
    }
}
