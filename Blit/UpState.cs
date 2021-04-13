using System.Text;

namespace Blit
{
    public class UpState : State
    {
        internal override bool IsDown { get { return false; } }

        internal override void Fill(IElement element, InputSymbolsProvider inputSymbolsProvider)
        {
            if (element.UpperPartProcessed)
            {
                element.FillChild(1, inputSymbolsProvider);
                element.FillChild(2, inputSymbolsProvider);
                element.FillChild(3, inputSymbolsProvider);
            }
            else
                element.FillChild(0, inputSymbolsProvider);
        }

        internal override void Print(IElement element, StringBuilder outputArray)
        {
            if (element.UpperPartProcessed)
            {
                element.PrintChild(1, outputArray);
                element.PrintChild(2, outputArray);
                element.PrintChild(3, outputArray);
            }
            else
                element.PrintChild(0, outputArray);
        }
    }
}
