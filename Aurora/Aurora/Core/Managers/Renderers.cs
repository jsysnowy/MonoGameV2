using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Microsoft XNA
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Monogame Extended.
using MonoGame.Extended.Tiled.Graphics;

namespace Aurora.Core.Managers {
    class Renderers {
        #region Class Properties
        /// <summary>
        /// Stores the GraphicsDevice renderer used by this game.
        /// </summary>
        private GraphicsDevice _gD;

        /// <summary>
        /// Stores an instance of TiledMapRenderer which can render Tiled maps;
        /// </summary>
        private TiledMapRenderer _mapRenderer;
        #endregion

        #region Get/Setters.
        public TiledMapRenderer MapRenderer { get { return _mapRenderer;  } }
        #endregion

        #region Constructor
        public Renderers( GraphicsDevice gD ) {
            // Store the graphics device.
            _gD = gD;

            // Create new TiledMapRenderer.
            _mapRenderer = new TiledMapRenderer(gD);
        }

        public void Update( GameTime gT) {
            //_mapRenderer.Update(gT);
        }
        #endregion
    }
}
