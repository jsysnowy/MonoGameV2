using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Aurora.Core.Camera {
    class Camera {
        #region Private Properties
        /// <summary>
        /// Stores viewport of the game.
        /// </summary>
        private Viewport _viewport;

        /// <summary>
        /// How zoomed in/out the Camera is. Default = 1.
        /// </summary>
        private float _zoom = 1.0f;

        /// <summary>
        /// Stores the position of the Camera.
        /// </summary>
        private Vector2 _position = new Vector2(0, 0);

        /// <summary>
        /// Stores the bounds of the Camera.
        /// </summary>
        private Rectangle _bounds;

        /// <summary>
        /// Stores the visible area currently displayed by the camera.
        /// </summary>
        private Rectangle _visibleArea;

        /// <summary>
        /// Matrix applied onto the camera.
        /// </summary>
        private Matrix _transform;
        #endregion

        #region Get/Sets
        /// <summary>
        /// Get/Set current value of zoom, along with error handling.
        /// </summary>
        public float Zoom {
            get {
                return _zoom;
            }
            set {
                // Make sure you cannot zoom past 0.
                if (value < 0) {
                    value = 0;
                }
                _zoom = value;
            }
        }

        /// <summary>
        /// Public getter for position.
        /// </summary>
        public Vector2 Position {
            get {
                return _position;
            }
            set {
                _position = value;
            }
        }

        /// <summary>
        /// Get/Set X position of Camera.
        /// </summary>
        public float X {
            get {
                return _position.X;
            }
            set {
                _position.X = value;
            }
        }

        /// <summary>
        /// Get/Set Y position of Camera.
        /// </summary>
        public float Y {
            get {
                return _position.Y;
            }
            set {
                _position.Y = value;
            }
        }

        /// <summary>
        /// Public readonly accessor for _bounds.
        /// </summary>
        public Rectangle Bounds { get { return _bounds; } }

        /// <summary>
        /// Public readonly accessor for _visibleArea.
        /// </summary>
        public Rectangle VisibleArea { get { return _visibleArea; } }

        /// <summary>
        /// Public readonly accessor for _transform.
        /// </summary>
        public Matrix Transform { get { return _transform; } }
        #endregion

        #region Constructor
        /// <summary>
        /// Create new camera with passed in viewport.
        /// </summary>
        /// <param name="viewport"></param>
        public Camera(Viewport viewport) {
            _viewport = viewport;
            _bounds = _viewport.Bounds;
        }
        #endregion

        #region Public Functions
        /// <summary>
        /// Updates the visibleArea based on current Transform.
        /// </summary>
        public void UpdateVisibleArea() {
            // Invert our Transform matrix.
            Matrix inverse = Matrix.Invert(_transform);

            // Get 4 corners of our rect based on inverse transform.
            Vector2 topLeft = Vector2.Transform(Vector2.Zero, inverse);
            Vector2 topRight = Vector2.Transform(new Vector2(_bounds.X, 0), inverse);
            Vector2 botLeft = Vector2.Transform(new Vector2(0, _bounds.Y), inverse);
            Vector2 botRight = Vector2.Transform(new Vector2(_bounds.Width, _bounds.Height), inverse);

            // Work out the min and max to generate rect out of:
            Vector2 min = new Vector2(
                Math.Min(topLeft.X, Math.Min(topRight.X, Math.Min(botLeft.X, botRight.X))),
                Math.Min(topLeft.Y, Math.Min(topRight.Y, Math.Min(botLeft.Y, botRight.Y)))
            );
            Vector2 max = new Vector2(
                Math.Max(topLeft.X, Math.Max(topRight.X, Math.Max(botLeft.X, botRight.X))),
                Math.Max(topLeft.Y, Math.Max(topRight.Y, Math.Max(botLeft.Y, botRight.Y)))
            );

            // Set visible Rect based on calculated values:
            _visibleArea = new Rectangle((int)min.X, (int)min.Y, (int)(max.X - min.X), (int)(max.Y - min.Y));
        }

        /// <summary>
        /// Updates the matrix based on current position of the Camera.
        /// </summary>
        public void UpdateMatrix() {
            _transform = Matrix.CreateTranslation(new Vector3(-_position.X, -_position.Y, 0));
            _transform *= Matrix.CreateScale(_zoom);
            _transform *= Matrix.CreateTranslation(new Vector3(_bounds.Width / 2, _bounds.Height / 2, 0));
            UpdateVisibleArea();
        }

        /// <summary>
        /// Called every frame via CameraManager this camera is attached to.
        /// </summary>
        public void Update() {
            _bounds = _viewport.Bounds;
            UpdateMatrix();
        }

        #endregion

        #region Private Functions
        #endregion
    }
}
