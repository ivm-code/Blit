using System;
using System.Collections.Generic;
using System.Text;

namespace Blit
{
    public class Creator : ICreator
    {
        public IElement CreatePyramid(InputSymbolsProvider inputSymbolsProvider) 
        {
            IElement newPyramid = CreateStructure(inputSymbolsProvider.GetSymbolsCount());
            Fillpyramid(inputSymbolsProvider, newPyramid);
            return newPyramid;
        }
        /// <summary>
        /// Creates a pyramid structure recursively, depending on the number of elements in the input string
        /// </summary>
        /// <param name="symbolsCountInInput">The number of elements in the input string</param>
        /// <returns>IElement - new pyramid object</returns>
        private IElement CreateStructure(int symbolsCountInInput)
        {
            IElement firstElement = new SimpleElement();
            IElement currentElement = firstElement;
            int symbolsCountInpyramid = 4;
            int symbolsLeftInInput = symbolsCountInInput - symbolsCountInpyramid;
            while (symbolsLeftInInput > 0)
            {
                currentElement = new Composite();
                currentElement.SetChild(0, firstElement);
                currentElement.SetChild(1, firstElement.Clone());
                currentElement.SetChild(2, firstElement.Clone().Turn());
                currentElement.SetChild(3, firstElement.Clone());
                symbolsCountInpyramid *= 4;
                symbolsLeftInInput = symbolsCountInInput - symbolsCountInpyramid;
                firstElement = currentElement;
            }
            return currentElement;
        }
        /// <summary>
        /// Fills the pyramid with symbols using InputSymbolsProvider
        /// </summary>
        /// <param name="inputSymbolsProvider">Provides symbols from an input string</param>
        /// <param name="pyramid">pyramid for filling with symbols</param>
        private void Fillpyramid(InputSymbolsProvider inputSymbolsProvider, IElement pyramid)
        {
            while (inputSymbolsProvider.HasMoreSybols())
                pyramid.Fill(inputSymbolsProvider);
        }
    }
}
