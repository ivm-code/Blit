using System.Text;

namespace Blit
{
    /// <summary>
    /// Realizes design pattern "State" for IElement
    /// describes the behavior for a "UpState" and "DownState" elements ("direct" and "inverted")
    /// </summary>
    public abstract class State
    {
        /// <summary>
        /// Returns true if the current element is "inverted"
        /// </summary>
        internal abstract bool IsDown { get; }
        /// <summary>
        /// Fills the element with symbols using InputSymbolsProvider
        /// </summary>
        /// <param name="inputSymbolsProvider">Provides symbols from an input string</param>
        /// <param name="element">element for filling with symbols</param>
        internal abstract void Fill(IElement element, InputSymbolsProvider inputSymbolsProvider);
        /// <summary>
        /// Printing all elements of IElement
        /// </summary>
        /// <param name="element">element for printing</param>
        /// <param name="outputArray">StringBuilder for create output string</param>
        internal abstract void Print(IElement element, StringBuilder outputArray);
    }
}
