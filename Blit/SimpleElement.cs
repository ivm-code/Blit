using System.Text;

namespace Blit
{
    public class SimpleElement : IElement
    {
        private State currentState = new UpState();

        private readonly char[] _childs = new char[4];

        public bool UpperPartProcessed { get; private set; } = false;

        public bool BottomPartProcessed { get; private set; } = false;

        public bool WholeElementProcessed => BottomPartProcessed && UpperPartProcessed;

        public bool CanBeCompressed => ChildsAreEqual();

        private bool ChildsAreEqual()
        {
            return _childs[0] == _childs[1] && _childs[1] == _childs[2] && _childs[2] == _childs[3];
        }

        public void Blit()
        {
            string newValuesString;
            string key = string.Format("{0}{1}{2}{3}", _childs[3], _childs[2], _childs[1], _childs[0]);//new string(_childs); ;
            if (TransformationRules.blitPairs.TryGetValue(key, out newValuesString))
                for (int i = 0; i < 4; i++)
                    SetChild(i, newValuesString[3 - i]);
        }

        public void Print(StringBuilder outputArray)
        {
            currentState.Print(this, outputArray);
        }
        public void Fill(InputSymbolsProvider inputSymbolsProvider)
        {
            currentState.Fill(this, inputSymbolsProvider);
        }

        public IElement Clone()
        {
            IElement clone = new SimpleElement();
            if (currentState.IsDown)
                clone.Turn();
            return clone;
        }

        public IElement Turn()
        {
            if (currentState.IsDown)
                currentState = new UpState();
            else currentState = new DownState();

            return this;
        }

        public void SetChild(int childIndex, object element)
        {
            _childs[childIndex] = (char)element;
        }

        public void FillChild(int childIndex, InputSymbolsProvider inputSymbolsProvider)
        {
            _childs[childIndex] = inputSymbolsProvider.GetNextChar();
            if (childIndex == 0)
                UpperPartProcessed = true;
            if (childIndex == 3)
                BottomPartProcessed = true;
        }

        public void ClearProcessedInfo()
        {
            UpperPartProcessed = false;
            BottomPartProcessed = false;
        }

        public void PrintChild(int childIndex, StringBuilder outputArray)
        {
            outputArray.Insert(0, _childs[childIndex]);
            if (childIndex == 0)
                UpperPartProcessed = true;
            if (childIndex == 3)
                BottomPartProcessed = true;
        }

        public object Compress()
        {
            return _childs[0];
        }
    }
}
