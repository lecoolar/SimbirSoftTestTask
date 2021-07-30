using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimbirSoftTestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите адрес Web-страницы: ");
            string url = Console.ReadLine();
            ParseHtml parseHtml = new ParseHtml(url);

            foreach (var word in parseHtml.CountWords)
            {
                Console.WriteLine($"{word.Word} - {word.Count}");
            }
            Console.ReadLine();
        }
    }
}
