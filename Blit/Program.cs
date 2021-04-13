using System;
using System.Collections.Generic;
using System.Text;
namespace Blit
{
    class Program
    {

        static void Main(string[] args)
        {
            InputSymbolsProvider inputSymbolsProvider = new InputSymbolsProvider(args[0].Trim());
            IPrinter printer = new Printer();
            ICreator pyramideBuilder = new Creator();
            ITransformer pyramideTransformer = new Transformer(printer);
            IElement pyramid = pyramideBuilder.CreatePyramid(inputSymbolsProvider);
            printer.Print(pyramid);
            pyramideTransformer.TransformPyramid(pyramid);
        }
    }
}
