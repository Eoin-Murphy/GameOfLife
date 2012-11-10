using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOL.Models
{
    /// <summary>
    /// This class represents a single live node in the game world
    /// </summary>
    public class Node : IEquatable<Node>
    {
        /// <summary>
        /// Gets or sets the X value
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Gets or sets the Y value
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Equivalence test method
        /// </summary>
        public bool Equals(Node n)
        {
            return this.X == n.X && this.Y == n.Y;
        } 

        /// <summary>
        /// Required for set comparisons
        /// </summary>
        public override int GetHashCode()
        {
            int xHash = this.X.GetHashCode();
            int yHash = this.Y.GetHashCode();

            return xHash ^ yHash;
        }
    }
}
