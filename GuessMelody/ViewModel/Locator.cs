using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessMelody.ViewModel
{
    class Locator
    {
       public GuessMelody.ViewModel.ViewModel MainViewModel { get; } = new ViewModel();
    }
}
