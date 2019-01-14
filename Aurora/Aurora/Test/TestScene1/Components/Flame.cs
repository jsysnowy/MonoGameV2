using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Microsoft XNA
using Microsoft.Xna.Framework;

// Monogame Extended

// Aurora
using Aurora.Core.Objects;
using Aurora.Core.Modules;
using Aurora.Core.Modules.PlayerControllers;
using Aurora.Core.Modules.CollisionBoxes;

namespace Aurora.Test.TestScene1.Components {
    class Flame:GameObject {
        #region Properties
        /// <summary>
        /// Stores texture for this object.
        /// </summary>
        private TextureModule _texture;

        /// <summary>
        /// Stores hitara for this object.
        /// </summary>
        private CustomRectHitArea _collisionBox;

        /// <summary>
        /// Movement direction.
        /// </summary>
        private Vector2 _dir;

        /// <summary>
        /// Counts up and kills itself once time is hit.
        /// </summary>
        private float _deadCount;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of raptor
        /// </summary>
        public Flame( Vector2 dir) {

            // Setup texture:
            _texture = this.AddModule<TextureModule>();
            _texture.TextureID = "flame";

            // Setup collision box:
            _collisionBox = this.AddModule<CustomRectHitArea>();
            _collisionBox.SetBounds(new Rectangle(0, 0, 100, 100));

            _deadCount = 0;
            _dir = dir;
            _dir.X *= 4;
            _dir.Y *= 4;
            _dir.X += ((float)Core.Overseer.Instance.rnd.NextDouble()*1)-0.5f;
            _dir.Y += ((float)Core.Overseer.Instance.rnd.NextDouble()*1)-0.5f;
        }
        #endregion

        public override void Update(GameTime gT) {
            base.Update(gT);

            WorldPosition.X += _dir.X;
            WorldPosition.Y += _dir.Y;


            _deadCount += gT.ElapsedGameTime.Milliseconds;
            if ( _deadCount >= 3000) {
                RemoveModule<CollisionModule>();
                RemoveModule<TextureModule>();
            }
        }
    }
}
