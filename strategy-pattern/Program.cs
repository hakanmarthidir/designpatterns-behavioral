using System;

namespace strategy_pattern
{
    class Program
    {
        static void Main(string[] args)
        {

            IConverter converter = new DxfConverter();

            Transformer transformer = new Transformer(converter);

            transformer.Transform("my file path");
        }
    }
}
