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
        private string description;
        private GameWorld gameWorld;
        private Object thisLock;

        /// <summary>
        /// Initializes a instance of the SimpleGameEngine class
        /// </summary>
        public SimpleGameEngine(IGameRepository gameRepo)
        {
            this.thisLock = new Object();
            this.gameRepository = gameRepo;
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
                if (this.gameWorld.LiveNodes.Any())
                {
                    /*
                     * Nodes added to this list are carried forward to the next iteration.
                     * If they are not added, then they are dead.
                     */
                    List<Node> nextGameState = new List<Node>();

                    // These are the dead nodes adjacent to live nodes in the current iteration
                    List<Node> deadAdjNodes = new List<Node>();

                    // Loop variables
                    List<Node> allAdjNodes;
                    List<Node> liveAdjNodes;

                    /*
                     * Loop through, check each live node for the rules.
                     * Take note of the dead nodes adjacent
                     */
                    foreach (Node node in this.gameWorld.LiveNodes)
                    {
                        allAdjNodes = this.GetAdjacentNodes(node);
                        liveAdjNodes = new List<Node>();

                        // Get the live nodes which are adjacent to the current node
                        liveAdjNodes = this.gameWorld.LiveNodes.Intersect(allAdjNodes).ToList();

                        // Get the dead nodes which are adjacent to the current node
                        deadAdjNodes.AddRange(allAdjNodes.Except(this.gameWorld.LiveNodes).ToList());

                        /*
                         * Applying rules 1, 2, & 3
                         * 1. Any live cell with fewer than two live neighbours dies, as if by loneliness.
                         * 2. Any live cell with more than three live neighbours dies, as if by overcrowding.
                         * 3. Any live cell with two or three live neighbours lives, unchanged, to the next generation. 
                         */
                        if (liveAdjNodes.Count() == 2 || liveAdjNodes.Count() == 3)
                        {
                            nextGameState.Add(node);
                        }
                    }

                    /*
                     * Applying rule 4
                     * 4. Any dead cell with exactly three live neighbours comes to life.
                     * 
                     * Using a while loop as iterators don't like it when you delete items out during a loop.
                     */
                    while (deadAdjNodes.Any())
                    {
                        Node deadNode = deadAdjNodes.First();

                        int count = deadAdjNodes.Where(daj => daj.Equals(deadNode)).Count();

                        // If it appears three times then it was added by three live nodes
                        if (count == 3)
                        {
                            nextGameState.Add(deadNode);
                        }

                        // Remove each node as we progress through the list. No need to check them twice.
                        deadAdjNodes.RemoveAll(n => n.Equals(deadNode));
                    }

                    // Update the game world state
                    this.gameWorld.LiveNodes = nextGameState;
                }
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

        /// <summary>
        /// Gets a list of the nodes adjacent to the specified node
        /// </summary>
        private List<Node> GetAdjacentNodes(Node node)
        {
            List<Node> adjNodes = new List<Node>();

            adjNodes.Add(new Node(){ X = node.X -1, Y = node.Y -1});        // -1, -1
            adjNodes.Add(new Node(){ X = node.X -1, Y = node.Y});           // -1, 0
            adjNodes.Add(new Node() { X = node.X - 1, Y = node.Y + 1 });    // -1, +1 
            
            adjNodes.Add(new Node(){ X = node.X, Y = node.Y -1});           // 0, -1
            adjNodes.Add(new Node() { X = node.X, Y = node.Y +1});          // 0, +1

            adjNodes.Add(new Node() { X = node.X + 1, Y = node.Y - 1 });    // +1, -1
            adjNodes.Add(new Node() { X = node.X + 1, Y = node.Y });        // +1, 0
            adjNodes.Add(new Node() { X = node.X + 1, Y = node.Y + 1 });    // +1, +1
            
            return adjNodes;
        }
    }
}
