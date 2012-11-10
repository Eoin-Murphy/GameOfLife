using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOL.Models;

namespace GOL.Interfaces
{
    /// <summary>
    /// Interface specifying the methods for interacting with the game world
    /// </summary>
    public interface IGameWorld
    {
        /// <summary>
        /// Initialize the game world
        /// </summary>
        void InitializeGameWorld();

        /// <summary>
        /// Executes the next world iteration
        /// </summary>
        void ExecuteGameWorldIteration();

        /// <summary>
        /// Gets the current game world state
        /// </summary>
        List<LiveNode> GetGameWorldState();
    }
}
