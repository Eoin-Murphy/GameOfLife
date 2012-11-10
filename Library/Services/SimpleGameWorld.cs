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
    public class SimpleGameWorld : IGameWorld
    {
        private GameWorld simpleGameWorld;

        /// <summary>
        /// Initializes a instance of the SimpleGameWorld class
        /// </summary>
        public SimpleGameWorld()
        {
            this.simpleGameWorld = new GameWorld();
        }

        /// <summary>
        /// Initializes a simple game world
        /// </summary>
        public void InitializeGameWorld()
        {
            LiveNode n1 = new LiveNode() { X = 1, Y = 1 };
            LiveNode n2 = new LiveNode() { X = 1, Y = 2 };
            LiveNode n3 = new LiveNode() { X = 2, Y = 2 };
            LiveNode n4 = new LiveNode() { X = 2, Y = 1 };

            this.simpleGameWorld.liveNodes.Add(n1);
            this.simpleGameWorld.liveNodes.Add(n2);
            this.simpleGameWorld.liveNodes.Add(n3);
            this.simpleGameWorld.liveNodes.Add(n4);

            this.simpleGameWorld.Height = 10;
            this.simpleGameWorld.Width = 10;
        }

        /// <summary>
        /// Executes an iteration of the simple game world
        /// </summary>
        public void ExecuteGameWorldIteration()
        {
            // TODO : make thread safe
            if (this.simpleGameWorld.liveNodes.Any())
            {
                List<LiveNode> nextState = new List<LiveNode>();
                foreach (LiveNode node in this.simpleGameWorld.liveNodes)
                {
                    // Implement world rules
                }

                this.simpleGameWorld.liveNodes = nextState;
            }
        }

        /// <summary>
        /// Gets the current state of the simple game world
        /// </summary>
        public List<LiveNode> GetGameWorldState()
        {
            return this.simpleGameWorld.liveNodes;
        }
    }
}
