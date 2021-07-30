﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimbirSoftTestTask
{
    class WordCountResult
    {
        public WordCountResult(string word, int count = 1)
        {
            Word = word;
            Count = count;
        }

        public string Word { get; set; }
        public int Count { get; set; }
    }
}
