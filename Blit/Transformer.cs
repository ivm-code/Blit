using System;
using System.Collections.Generic;
using System.Text;

namespace Blit
{
    public class Transformer : ITransformer
    {
        private readonly IPrinter _printer;

        private IElement _pyramid;

        public Transformer(IPrinter printer) 
        {
            _printer = printer;
        }

        public void TransformPyramid(IElement pyramid) 
        {
            _pyramid = pyramid;
            Compress();
        }
        /// <summary>
        /// Compresses pyramid after each conversion step by step
        /// </summary>
        /// <param name="pyramid">Pyramid for compress</param>
        private void Compress()
        {
            object compressedPyramid;
            char result = 'e';

            while (result == 'e')
            {
                Blit();
                compressedPyramid = _pyramid.Compress();

                if (compressedPyramid is char)
                {
                    result = (char)compressedPyramid;
                    Console.WriteLine(result);
                }
                else
                {
                    _pyramid = (IElement)compressedPyramid;
                }
            }
        }
        /// <summary>
        /// Converts all the basic elements of the pyramid using a predefined rule, step by step, 
        /// until all the characters of the element are the same.
        /// Printing all elements of a pyramid on each step
        /// </summary>
        /// <param name="pyramid">pyramid for transform</param>
        private void Blit()
        {
            while (!_pyramid.CanBeCompressed)
            {
                _pyramid.Blit();
                _printer.Print(_pyramid);
            }
        }
    }
}
