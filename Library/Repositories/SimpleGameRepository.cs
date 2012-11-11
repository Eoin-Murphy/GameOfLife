using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOL.Interfaces;
using GOL.Models;

namespace GOL.Repositories
{
    /// <summary>
    /// This is a very simple game world repository.
    /// </summary>
    public class SimpleGameRepository : IGameRepository
    {
        private List<GameWorld> savedWorlds;

        /// <summary>
        /// Initializes an instance of the simpleGameRepository class with some dummy data
        /// </summary>
        public SimpleGameRepository()
        {
            savedWorlds = new List<GameWorld>();

            GameWorld Block = new GameWorld();
            Block.LiveNodes.Add(new Node() { X = 1, Y = 1 });
            Block.LiveNodes.Add(new Node() { X = 1, Y = 2 });
            Block.LiveNodes.Add(new Node() { X = 2, Y = 1 });
            Block.LiveNodes.Add(new Node() { X = 2, Y = 2 });
            Block.Description = "Block";
            savedWorlds.Add(Block);

            GameWorld Boat = new GameWorld();
            Boat.LiveNodes.Add(new Node() { X = 1, Y = 1 });
            Boat.LiveNodes.Add(new Node() { X = 2, Y = 1 });
            Boat.LiveNodes.Add(new Node() { X = 1, Y = 2 });
            Boat.LiveNodes.Add(new Node() { X = 3, Y = 2 });
            Boat.LiveNodes.Add(new Node() { X = 2, Y = 3 });
            Boat.Description = "Boat";
            savedWorlds.Add(Boat);

            GameWorld Blinker = new GameWorld();
            Blinker.LiveNodes.Add(new Node() { X = 2, Y = 1 });
            Blinker.LiveNodes.Add(new Node() { X = 2, Y = 2 });
            Blinker.LiveNodes.Add(new Node() { X = 2, Y = 3 });          
            Blinker.Description = "Blinker";
            savedWorlds.Add(Blinker);


            GameWorld Toad = new GameWorld();
            Toad.LiveNodes.Add(new Node() { X = 2, Y = 1 });
            Toad.LiveNodes.Add(new Node() { X = 3, Y = 1 });
            Toad.LiveNodes.Add(new Node() { X = 4, Y = 1 });
            Toad.LiveNodes.Add(new Node() { X = 1, Y = 2 });
            Toad.LiveNodes.Add(new Node() { X = 2, Y = 2 });
            Toad.LiveNodes.Add(new Node() { X = 3, Y = 2 });
            Toad.Description = "Toad";
            savedWorlds.Add(Toad);
        }

        /// <summary>
        /// Returns the saved descriptions
        /// </summary>
        public List<string> LoadGameWorldDescriptions()
        {
            return savedWorlds.Select(gw => gw.Description).ToList();
        }

        /// <summary>
        /// Saves the provided game world
        /// </summary>
        public void SaveGameWorld(GameWorld gameWorld)
        {
            this.DeleteGameWorld(gameWorld.Description);

            // Add a new world
            savedWorlds.Add(gameWorld);            
        }

        /// <summary>
        /// Returns the specified game world if one exists
        /// </summary>
        public GameWorld LoadGameWorld(string description)
        {
            return savedWorlds.Where(gw => gw.Description.Equals(description, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
        }

        /// <summary>
        /// Deletes the specified game world
        /// </summary>
        public void DeleteGameWorld(string description)
        {
            savedWorlds.RemoveAll(gw => gw.Description.Equals(description, StringComparison.OrdinalIgnoreCase));
        }
    }
}
