using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOL.Interfaces;
using GOL.Models;

namespace GOL.Services
{
    /// <summary>
    /// This class represents a very simple game world
    /// </summary>
    public class SimpleGameEngine : IGameEngine
    {
        private IGameRepository gameRepository;
        private IGameUpdater gameUpdater;
        private string description;
        private GameWorld gameWorld;
        private Object thisLock;

        /// <summary>
        /// Initializes a instance of the SimpleGameEngine class
        /// </summary>
        public SimpleGameEngine(
                        IGameRepository gameRepo,
                        IGameUpdater gameUpdater)
        {
            this.thisLock = new Object();
            this.gameRepository = gameRepo;
            this.gameUpdater = gameUpdater;
        }


        /// <summary>
        /// Gets a list of world descriptions
        /// </summary>
        /// <returns></returns>
        public List<string> GetWorldDescriptions()
        {
            return this.gameRepository.GetGameWorldDescriptions();
        }

        /// <summary>
        /// Loads the specified game world
        /// </summary>
        public void LoadGameWorld(string description)
        {
            this.gameWorld = this.gameRepository.LoadGameWorld(description);
            this.description = description;
        }

        /// <summary>
        /// Save the current game world
        /// </summary>
        public void SaveGameWorld()
        {
            this.gameRepository.SaveGameWorld(this.gameWorld);
        }

        /// <summary>
        /// Executes an iteration of the simple game engine
        /// </summary>
        public void UpdateGameWorld()
        {
            lock (thisLock)
            {
                this.gameWorld.LiveNodes = this.gameUpdater.UpdateGameWorld(this.gameWorld.LiveNodes);
            }
        }

        /// <summary>
        /// Gets the current state of the simple game world
        /// </summary>
        public List<Node> GetGameWorldState()
        {
            return this.gameWorld.LiveNodes;
        }

        /// <summary>
        /// Gets the current game world name
        /// </summary>
        /// <returns></returns>
        public string GetCurrentWorldDescription()
        {
            return this.gameWorld.Description;
        }
    }
}
