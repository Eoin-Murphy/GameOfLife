using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOL.Interfaces;
using GOL.Models;

namespace GOL.Repositories
{
    /// <summary>
    /// This is a mock game world repository. Just returns dummy data
    /// Useful for testing and getting started.
    /// </summary>
    public class MockGameWorldRepository : IGameRepository
    {
        private Dictionary<string, GameWorld> savedWorlds;

        public MockGameWorldRepository()
        {
            savedWorlds = new Dictionary<string, GameWorld>();

            GameWorld mockWorld = new GameWorld();
            Node n1 = new Node() { X = 2, Y = 1 };
            Node n2 = new Node() { X = 2, Y = 2 };
            Node n3 = new Node() { X = 2, Y = 3 };

            mockWorld.liveNodes.Add(n1);
            mockWorld.liveNodes.Add(n2);
            mockWorld.liveNodes.Add(n3);

            mockWorld.Height = 3;
            mockWorld.Width = 3;

            mockWorld.iteration = 0;

            savedWorlds.Add("Blinker", mockWorld);
        }

        /// <summary>
        /// Returns the saved descriptions
        /// </summary>
        /// <returns></returns>
        public List<string> LoadGameWorldDescriptions()
        {
            return savedWorlds.Keys.ToList();
        }

        /// <summary>
        /// Saves the provided game world
        /// </summary>
        public void SaveGameWorld(string description, GameWorld gameWorld)
        {
            if (savedWorlds.ContainsKey(description))
            {
                // Update the existing world
                savedWorlds[description] = gameWorld;
            }
            else
            {
                // Add a new world
                savedWorlds.Add(description, gameWorld);
            }
        }

        /// <summary>
        /// Returns the specified game world if one exists
        /// </summary>
        public GameWorld LoadGameWorld(string description)
        {
            return savedWorlds[description];
        }

        /// <summary>
        /// Deletes the specified game world
        /// </summary>
        public void DeleteGameWorld(string description)
        {
            savedWorlds.Remove(description);
        }
    }
}
