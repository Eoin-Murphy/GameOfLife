using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOL.Models;

namespace GOL.Interfaces
{
    /// <summary>
    /// Interface for game updaters
    /// </summary>
    public interface IGameUpdater
    {
        /// <summary>
        /// Updates the specified world
        /// </summary>
        List<Node> UpdateGameWorld(List<Node> worldState);
    }
}
