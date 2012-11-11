using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOL.Models
{
    /// <summary>
    /// This class holds the current state of the game world
    /// </summary>
    public class GameWorld : IEquatable<GameWorld>
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

        /// <summary>
        /// Equivalence test method
        /// </summary>
        public bool Equals(GameWorld gw)
        {
            bool result = false;

            result = this.Description.Equals(gw.Description, StringComparison.OrdinalIgnoreCase);
            
            if (result)
            {
                // Check the same number of nodes
                result = this.LiveNodes.Count() == gw.LiveNodes.Count();

                if (result)
                {
                    // Check all of the nodes in matching order by. Ensuring none are missed.
                    for (int i = 0; i < this.LiveNodes.Count; i++)
                    {
                        result = this.LiveNodes.OrderBy(n => n.X).ThenBy(n => n.Y).ToArray()[i]
                                    .Equals(gw.LiveNodes.OrderBy(n => n.X).ThenBy(n => n.Y).ToArray()[i]);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Required for set comparisons
        /// </summary>
        public override int GetHashCode()
        {
            return this.Description.GetHashCode() ^ this.LiveNodes.GetHashCode();
        }
    }
}
