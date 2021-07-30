using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimbirSoftTestTask
{
    class ParseHtml
    {
        private List<char> _spaces = new List<char>() { ' ', ',', '.', '!', '?', '"', ';', ':', '[', ']', '(', ')', '\n', '\r', '\t' };
        public List<WordCountResult> WordsCount { get; } = new List<WordCountResult>();

        public ParseHtml(string url)//конструктор класса - скачивает html страницу
        {
            WebClient client = new WebClient();
            Stream data = client.OpenRead(url);
            StreamReader reader = new StreamReader(data);
            string htmlPage = reader.ReadToEnd();
            reader.Close();
            data.Close();
            CountWordsInHtml(htmlPage);
        }

        private static string StripHTML(string input)//удаляет html теги
        {
            input = Regex.Replace(input, "<span.*?>.*?</span>", "", RegexOptions.Singleline);
            input = Regex.Replace(input, "<script.*?>.*?</script>", "", RegexOptions.Singleline);
            input = Regex.Replace(input, "<style.*?>.*?</style>", "", RegexOptions.Singleline);
            input = Regex.Replace(input, "<.*?>", "", RegexOptions.Singleline);
            return input;
        }

        private void CountWordsInHtml(string htmlPage)//подсчет слов на странице
        {
            StringBuilder outStr = new StringBuilder();
            htmlPage = StripHTML(htmlPage);
            foreach (var c in htmlPage)
            {
                if (!_spaces.Contains(c))
                {
                    outStr.Append(Char.ToUpper(c));
                }
                else if (outStr.Length != 0)
                {
                    var word = WordsCount.FirstOrDefault(f => f.Word == outStr.ToString());
                    if (word != null)
                    {
                        word.Count += 1;
                    }
                    else
                    {
                        WordsCount.Add(new WordCountResult(outStr.ToString()));
                    }
                    outStr.Clear();
                }
            }
        }
    }
}
