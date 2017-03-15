using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalizationExample
{
    public class ExampleModel
    {
        public string Argument { get; set; }

        public string StringLocalizedNoArguments { get; set; }

        public string StringLocalizedNoArgumentsCurly { get; set; }

        public string StringLocalizedWithArguments { get; set; }

        public bool Curly { get;  set; }
    }
}
