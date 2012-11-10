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
            this.liveNodes = new List<LiveNode>();
        }

        /// <summary>
        /// Gets or sets the game world iteration
        /// </summary>
        public long iteration { get; set; }

        /// <summary>
        /// Gets or sets the game world width
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets the game world height
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Gets or sets the list of live nodes in the game world
        /// </summary>
        public List<LiveNode> liveNodes { get; set; }
    }
}
