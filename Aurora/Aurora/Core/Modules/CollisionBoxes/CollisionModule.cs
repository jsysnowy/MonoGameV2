using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Microsoft.XNA
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// MonoGame Extended
using MonoGame.Extended;

namespace Aurora.Core.Modules.CollisionBoxes {
    class CollisionModule : Base.Module {
        #region Class Params
        /// <summary>
        /// Stores bounds of this Collision.
        /// </summary>
        protected Rectangle _bounds = new Rectangle(0, 0, 0, 0);
        #endregion

        #region Get/Set
        /// <summary>
        /// Readonly accesor for bounds.
        /// </summary>
        public Rectangle Bounds { get {
                return _bounds;
            }
        }
        #endregion

        /// <summary>
        ///  Create a ne CollisionModule.
        /// </summary>
        public CollisionModule() {
            Collision.CollisionManager.Instance.Objects.Add(this);
        }

        #region Public properties.
        /// <summary>
        /// Called when collision triggers with "Other"
        /// </summary>
        /// <param name="Other"></param>
        public virtual void OnCollision( CollisionModule Other ) {
            //System.Diagnostics.Trace.WriteLine("COLLISION");
        }

        /// <summary>
        /// Draw the hitbox.
        /// </summary>
        /// <param name="sB"></param>
        public override void Draw(SpriteBatch sB) {
            //sB.DrawRectangle(_bounds, Color.Green, 4);
            base.Draw(sB);
        }
        #endregion
    }
}
