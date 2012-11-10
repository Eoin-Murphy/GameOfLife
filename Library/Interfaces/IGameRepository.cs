using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOL.Models;

namespace GOL.Interfaces
{
    /// <summary>
    /// Interface providing methods to load & persist game data
    /// </summary>
    public interface IGameRepository
    {
        /// <summary>
        /// Loads a list of saved game world descriptions
        /// </summary>
        List<string> LoadGameWorldDescriptions();

        /// <summary>
        /// Saves a game world description
        /// </summary>
        void SaveGameWorldDescription();

        /// <summary>
        /// Loads a game world
        /// </summary>
        GameWorld LoadGameWorld(string worldDescriptor);

        /// <summary>
        /// Saves a game world
        /// </summary>
        void SaveGameWorld(string worldDescriptor, GameWorld gameWorld);
    }
}
