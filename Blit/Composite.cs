using System.Text;

namespace Blit
{
    public class Composite : IElement
    {
        private State currentState = new UpState();

        private readonly IElement[] _childs = new IElement[4];

        public bool UpperPartProcessed => _childs[0].WholeElementProcessed;

        public bool BottomPartProcessed => _childs[3].WholeElementProcessed;

        public bool WholeElementProcessed => BottomPartProcessed && UpperPartProcessed;

        public bool CanBeCompressed => AllChildsCanBeCompressed();

        private bool AllChildsCanBeCompressed()
        {
            return _childs[0].CanBeCompressed && _childs[1].CanBeCompressed && _childs[2].CanBeCompressed && _childs[3].CanBeCompressed;
        }

        public void Blit()
        {
            for (int i = 0; i < 4; i++)
                _childs[i].Blit();
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
            IElement clone = new Composite();

            for (int i = 0; i < 4; i++)
                clone.SetChild(i, _childs[i].Clone());
            if (currentState.IsDown)
                clone.Turn();

            return clone;
        }

        public IElement Turn()
        {
            if (currentState.IsDown)
                currentState = new UpState();
            else currentState = new DownState();
            for (int i = 0; i < 4; i++)
                _childs[i].Turn();

            return this;
        }

        public void SetChild(int childIndex, object element)
        {
            _childs[childIndex] = (IElement)element;
        }

        public bool IsCurrentStateDown()
        {
            return currentState.IsDown;
        }

        public void FillChild(int childIndex, InputSymbolsProvider inputSymbolsProvider)
        {
            _childs[childIndex].Fill(inputSymbolsProvider);
        }

        public void ClearProcessedInfo()
        {
            for (int i = 0; i < 4; i++)
            {
                _childs[i].ClearProcessedInfo();
            }
        }

        public void PrintChild(int childIndex, StringBuilder outputArray)
        {
            _childs[childIndex].Print(outputArray);
        }

        public object Compress()
        {
            if (_childs[0] is SimpleElement)
            {
                SimpleElement compressed = new SimpleElement();
                if (currentState.IsDown)
                    compressed.Turn();
                for (int i = 0; i < 4; i++)
                    compressed.SetChild(i, _childs[i].Compress());
                return compressed;
            }
            else
            {
                Composite compressed = new Composite();
                for (int i = 0; i < 4; i++)
                    compressed.SetChild(i, _childs[i].Compress());
                if (currentState.IsDown)
                    compressed.Turn();
                return compressed;
            }
        }
    }
}
