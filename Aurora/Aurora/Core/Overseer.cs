using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Aurora.Core {
    class Overseer {
        #region Singletons
        /// <summary>
        ///  Stores singleton instance of this.
        /// </summary>
        private static Overseer _instance;

        /// <summary>
        /// Getter for this singleton.
        /// </summary>
        public static Overseer Instance {
            get {
                if ( _instance == null) {
                    _instance = new Overseer();
                }
                return _instance;
            }
        }
        #endregion

        #region Game properties
        /// <summary>
        /// Stores the graphics device manager.
        /// </summary>
        public GraphicsDeviceManager GDM;

        /// <summary>
        ///  Stores the graphics device.
        /// </summary>
        public GraphicsDevice GD;
        #endregion

        #region Managers
        /// <summary>
        /// Stores the SceneManager.
        /// </summary>
        public Scenes.SceneManager SceneManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Create new Game instance
        /// </summary>
        private Overseer() {

        }
        #endregion
    }
}
