using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOL.Models
{
    /// <summary>
    /// This class holds the current state of the game world
    /// </summary>
    public class GameWorld
    {
        /// <summary>
        /// Initializes a new instance of the GameWorld class
        /// </summary>
        public GameWorld()
        {
            this.LiveNodes = new List<Node>();
        }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the list of live nodes in the game world
        /// </summary>
        public List<Node> LiveNodes { get; set; }
    }
}
