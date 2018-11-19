using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Aurora.Core.Objects {
    class GameObject {
        #region Properties
        #region Positioning.
        /// <summary>
        /// Stores the world position of this display object.
        /// </summary>
        public Vector3 WorldPosition { set; get; }
        #endregion

        #region Modules
        /// <summary>
        /// Dictionary which stores all modules attached to this GameObject
        /// </summary>
        private Dictionary<string, string> Modules;
        #endregion
        #endregion

        #region Get and Set
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new display object.
        /// </summary>
        public GameObject() {
            WorldPosition = new Vector3(0, 0, 0);
        }
        #endregion
    }
}
