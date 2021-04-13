using System;
using System.Collections.Generic;
using System.Text;

namespace Blit
{ 
    public interface ICreator
    {
        IElement CreatePyramid(InputSymbolsProvider inputSymbolsProvider);
    }
}
