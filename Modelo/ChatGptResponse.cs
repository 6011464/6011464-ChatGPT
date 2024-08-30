using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppEjemplo.Modelo
{
    public class ChatGptResponse
    {
        public List<Choice> choices { get; set; }

        public class Choice
        {
            public string text { get; set; }
        }
    }
}
