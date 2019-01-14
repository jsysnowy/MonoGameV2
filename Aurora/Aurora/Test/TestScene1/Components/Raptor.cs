using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Microsoft XNA
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

// Monogame Extended

// Aurora
using Aurora.Core.Objects;
using Aurora.Core.Modules;
using Aurora.Core.Modules.PlayerControllers;
using Aurora.Core.Modules.CollisionBoxes;

namespace Aurora.Test.TestScene1.Components {
    class Raptor : GameObject {

        #region Properties
        /// <summary>
        /// Stores controller for this object.
        /// </summary>
        private GRIDController _controller;

        /// <summary>
        /// Stores texture for this object.
        /// </summary>
        private SpritesheetTexture _texture;

        /// <summary>
        /// Stores hitara for this object.
        /// </summary>
        private CustomRectHitArea _collisionBox;

        /// <summary>
        /// Stores which direction the raptor is facing.
        /// </summary>
        private Vector2 _facingDir;

        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of raptor
        /// </summary>
        public Raptor() {

            // Setup controller:
            _controller = this.AddModule<GRIDController>();

            // Setup texture:
            _texture = this.AddModule<SpritesheetTexture>();
            _texture.TextureID = "Raptor";

            // Setup collision box:
            _collisionBox = this.AddModule<CustomRectHitArea>();
            _collisionBox.SetBounds( new Rectangle(0, 0, 100, 100));
        }
        #endregion

        public override void Update(GameTime gT) {
            base.Update(gT);

            bool pressed = false;

            KeyboardState kbs = Keyboard.GetState();
            if (kbs.IsKeyDown(Keys.W)) {
                _texture.StartIndex = 9;
                _texture.EndIndex = 11;
                pressed = true;
                _facingDir = new Vector2(0, -1);
            }
            if (kbs.IsKeyDown(Keys.A)) {
                _texture.StartIndex = 3;
                _texture.EndIndex = 5;
                pressed = true;
                _facingDir = new Vector2(-1, 0);
            }
            if (kbs.IsKeyDown(Keys.S)) {
                _texture.StartIndex = 0;
                _texture.EndIndex = 2;
                _facingDir = new Vector2(0, 1);
                pressed = true;
            }
            if (kbs.IsKeyDown(Keys.D)) {
                _texture.StartIndex = 6;
                _texture.EndIndex = 8;
                pressed = true;
                _facingDir = new Vector2(1,0);
            }

            if ( kbs.IsKeyDown(Keys.Space)) {
                Components.Flame flame = new Components.Flame( _facingDir);
                flame.WorldPosition = WorldPosition;
                flame.WorldPosition.X += 50 * _facingDir.X;
                flame.WorldPosition.Y += 50 * _facingDir.Y;
                Parent.Add(flame);

            }

            if (!pressed) {
                //_texture.EndIndex = _texture.StartIndex;
            }
        }
    }
}
