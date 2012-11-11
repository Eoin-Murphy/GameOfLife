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
        List<string> GetGameWorldDescriptions();

        /// <summary>
        /// Saves a game world
        /// </summary>
        void SaveGameWorld(GameWorld gameWorld);

        /// <summary>
        /// Loads a game world
        /// </summary>
        GameWorld LoadGameWorld(string description);
        
        /// <summary>
        /// Deletes the specified game world
        /// </summary>
        void DeleteGameWorld(string description);
    }
}
