using System.Text;

namespace Blit
{
    /// <summary>
    /// Realizes design pattern "Composite"
    /// each element can be composed of symbols or other elements
    /// </summary>
    public interface IElement
    {
        /// <summary>
        /// Returns true if upper triangle of the pyramid is processed - printed or filled
        /// </summary>
        bool UpperPartProcessed { get; }
        /// <summary>
        /// Returns true if bottom 3 triangles of the pyramid is processed - printed or filled
        /// </summary>
        bool BottomPartProcessed { get; }
        /// <summary>
        /// Returns true if all 4 triangles of the pyramid is processed - printed or filled
        /// </summary>
        bool WholeElementProcessed { get; }
        /// <summary>
        ///  Returns true if all childs of a pyramid can be compressed.
        ///  If the pyramid consists of chars - returns true if all of the chars a the same
        /// </summary>
        bool CanBeCompressed { get; }
        /// <summary>
        /// Converts element of the pyramid using a predefined rule
        /// </summary>
        void Blit();
        /// <summary>
        /// Printing all "childs" of current element
        /// </summary>
        /// <param name="outputArray">StringBuilder for create output string</param>
        void Print(StringBuilder outputArray);
        /// <summary>
        /// Fills the current element with symbols using InputSymbolsProvider
        /// </summary>
        /// <param name="inputSymbolsProvider">Provides symbols from an input string</param>
        void Fill(InputSymbolsProvider inputSymbolsProvider);
        /// <summary>
        /// Create a structured copy of the current item and all of its "sub-items".
        /// </summary>
        /// /// <returns>IElement - new cloned item</returns>
        IElement Clone();
        /// <summary>
        /// Inverts the element from straight to inverted or back.
        /// </summary>
        /// <returns>IElement - inverted object</returns>
        IElement Turn();
        /// <summary>
        /// Sets "element" as a "Child" of the current element at index childIndex
        /// </summary>
        /// <param name="element">Element to be set as a "child"</param>
        /// <param name="childIndex">New element index</param>
        void SetChild(int childIndex, object element);
        /// <summary>
        /// Fills the subelements of the current element with symbols using InputSymbolsProvider
        /// </summary>
        /// <param name="childIndex">subelement index </param>
        /// <param name="inputSymbolsProvider">Provides symbols from an input string</param>
        void FillChild(int childIndex, InputSymbolsProvider inputSymbolsProvider);
        /// <summary>
        /// Clears information about which parts of the current element have already been "processed" - printed or filled.
        /// </summary>
        void ClearProcessedInfo();
        /// <summary>
        /// Prints the subelements of the current element to the output string
        /// </summary>
        /// <param name="childIndex">subelement index </param>
        /// <param name="outputArray">StringBuilder for create output string</param>
        void PrintChild(int childIndex, StringBuilder outputArray);
        /// <summary>
        /// Converts the current element to a smaller one
        /// </summary>
        /// <returns>Smaller element of type IElement or "char"</returns>
        object Compress();
    }
}
