using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Microsoft.XNA
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Aurora CollisionBox
using Aurora.Core.Modules.CollisionBoxes;

// Monogame Extended.
using MonoGame.Extended;

namespace Aurora.Core.Collision {
    class CollisionManager {
        #region Statics/Singleton
        /// <summary>
        /// Stores singleton instance of this class.
        /// </summary>
        private static CollisionManager _instance;

        /// <summary>
        /// Stores the QuadTree.
        /// </summary>
        private QuadTree.QuadTree _qT;

        /// <summary>
        /// Stores all currently collidable objects.
        /// </summary>
        public List<CollisionModule> Objects = new List<CollisionModule>();
        #endregion

        #region Class Properties
        #endregion

        #region Static Get/Sets.
        /// <summary>
        /// Readonly single instance of CollisionManager.
        /// </summary>
        public static CollisionManager Instance {       
            get {
                if (_instance == null) {
                    _instance = new CollisionManager();
                }
                return _instance;
            }
        }
        #endregion


        #region Get/Sets.
        #endregion

        #region Constructor
        /// <summary>
        /// Create new instance of CollisionManager
        /// </summary>
        private CollisionManager() {

        }
        #endregion

        #region Public Functions
        /// <summary>
        /// Update the collision manager.
        /// </summary>
        public void Update() {
            _qT = new QuadTree.QuadTree(0, Core.Overseer.Instance.SceneManager.ActiveScene.ActiveCamera.VisibleArea); 
            
            foreach( CollisionModule c in Objects) {
                if ( c.Bounds.Intersects(Core.Overseer.Instance.SceneManager.ActiveScene.ActiveCamera.VisibleArea)) {
                    _qT.AddObject(c);
                }
            }

            foreach( CollisionModule c in Objects) {
                //System.Diagnostics.Trace.WriteLine(_qT.Retreive(c).Count);
                foreach (CollisionModule o in _qT.Retreive(c) ) {
                    if ( c != o) {
                        if ( c.Bounds.Intersects(o.Bounds)) {
                            c.OnCollision(o);
                        }
                    }
                }
            }
            
        }

        /// <summary>
        /// Draws this QuadTree structure
        /// </summary>
        /// <param name="sB"></param>
        public void Draw( SpriteBatch sB) {
            _qT.Draw(sB, Color.White);
        }
        #endregion

        #region Private Functions
        #endregion
    }
}
