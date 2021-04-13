namespace Blit
{
    /// <summary>
    /// Provides functionality to iterate through the characters of input strings from end to beginning
    /// </summary>
    public class InputSymbolsProvider
    {
        private readonly string _inputSybols;

        private int _pointer;

        public InputSymbolsProvider(string inputSybols)
        {
            _inputSybols = inputSybols;
            _pointer = inputSybols.Length;
        }

        public char GetNextChar()
        {
            return _inputSybols[--_pointer];
        }

        public bool HasMoreSybols()
        {
            return _pointer != 0;
        }

        public int GetSymbolsCount()
        {
            return _inputSybols.Length;
        }
    }
}
