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
        /// Loads the specified game world
        /// </summary>
        void LoadGameWorld(string description);

        /// <summary>
        /// Save the current game world
        /// </summary>
        void SaveGameWorld();

        /// <summary>
        /// Executes the next world iteration
        /// </summary>
        void UpdateGameWorld();

        /// <summary>
        /// Gets the current game world state
        /// </summary>
        List<Node> GetGameWorldState();
    }
}
