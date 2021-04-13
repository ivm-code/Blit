using System;
using System.Collections.Generic;
using System.Text;

namespace Blit
{
    public class Printer : IPrinter
    {
        /// <summary>
        /// Printing all elements of a pyramid recursively
        /// </summary>
        /// <param name="pyramid">pyramid for printing</param>
        public void Print(IElement pyramid)
        {
            StringBuilder outputString = new StringBuilder();

            pyramid.ClearProcessedInfo();
            while (!pyramid.WholeElementProcessed)
                pyramid.Print(outputString);
            Console.WriteLine(outputString.ToString());
        }
    }
}
