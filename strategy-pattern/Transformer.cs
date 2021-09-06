using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strategy_pattern
{
    public interface IConverter
    {
        void Convert(string path);
    }

    public class DxfConverter : IConverter
    {
        public void Convert(string path)
        {
            Console.WriteLine("dxf file is ready");
        }
    }

    public class DwgConverter : IConverter
    {
        public void Convert(string path)
        {
            Console.WriteLine("dwg file is ready");
        }
    }


    public class Transformer
    {
        private IConverter _converter;

        public Transformer(IConverter converter)
        {
            this._converter = converter;
        }

        public void Transform(string filePath)
        {
            this._converter.Convert(filePath);
        }

    }



}
