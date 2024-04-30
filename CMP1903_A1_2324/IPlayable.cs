using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    /// <summary>
    /// Interface for making sure a PlayGame method exists 
    /// with a argument for testing 
    /// </summary>
    internal interface IPlayable
    {
        int PlayGame(bool testing);
    }
}
