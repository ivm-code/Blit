using System.Text;

namespace Blit
{
    public class DownState : State
    {
        internal override bool IsDown { get { return true; } }

        internal override void Fill(IElement element, InputSymbolsProvider inputSymbolsProvider)
        {
            if (element.BottomPartProcessed)
                element.FillChild(0, inputSymbolsProvider);
            else
            {
                element.FillChild(1, inputSymbolsProvider);
                element.FillChild(2, inputSymbolsProvider);
                element.FillChild(3, inputSymbolsProvider);
            }
        }

        internal override void Print(IElement element, StringBuilder outputArray)
        {
            if (element.BottomPartProcessed)
                element.PrintChild(0, outputArray);
            else
            {
                element.PrintChild(1, outputArray);
                element.PrintChild(2, outputArray);
                element.PrintChild(3, outputArray);
            }
        }
    }
}
