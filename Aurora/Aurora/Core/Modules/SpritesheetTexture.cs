using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Aurora.Core.Modules {
    class SpritesheetTexture : TextureModule {
        /// <summary>
        /// Rectangle which stores current bounds of the spritesheet rendering.
        /// </summary>
        private Rectangle _curRect;

        /// <summary>
        /// Stores tile width of this spritesheet texture.
        /// </summary>
        private int _tileWidth = 94;

        /// <summary>
        /// Stores tile height of this spritesheet texture.
        /// </summary>
        private int _tileHeight = 100;


        /// <summary>
        /// Store start index of anim.
        /// </summary>
        private int _startIndex = 6;

        /// <summary>
        /// Store end index of anim.
        /// </summary>
        public int EndIndex = 8;
        
        
        /// <summary>
        /// Stores index of tile which is currently displayed.
        /// </summary>
        private int _tileIndex = 0;

        /// <summary>
        /// Stores the sprite rectanges used,
        /// </summary>
        private Rectangle[] _spriteArray;

        /// <summary>
        /// How long has elapsed
        /// </summary>
        private float _elapsed = 0;

        /// <summary>
        /// FPS the anim plays at.
        /// </summary>
        public int FPS = 12;

        /// <summary>
        /// Readonly. Get current rendered rectangle.
        /// </summary>
        public Rectangle CurrentRectangle {
            get {
                return _curRect;
            }
        }

        /// <summary>
        /// Set new TileWidth
        /// </summary>
        public int TileWidth {
            get { return _tileWidth; }
            set {
                _tileWidth = value;
                GenerateGrid();
                
            }
        }

        /// <summary>
        /// Set new TileHeight
        /// </summary>
        public int TileHeight {
            get { return _tileHeight; }
            set {
                _tileHeight = value;
                GenerateGrid();
            }
        }

        public int StartIndex {
            set {
                if ( value != _startIndex) {
                    _startIndex = value;
                    _tileIndex = value;
                }
            }
            get {
                return _startIndex;
            }

        }

        public SpritesheetTexture() {
            _startIndex = 0;
            EndIndex = 0;
            _tileIndex = _startIndex;
        }

        /// <summary>
        /// Generates grid of different assets split via tileW and tileH
        /// </summary>
        private void GenerateGrid() {
            if ( Texture != null ) {
                // Generate array
                _spriteArray = new Rectangle[(int)(Math.Ceiling((decimal)Texture.Height / _tileHeight) * Math.Ceiling((decimal)Texture.Width / _tileWidth))];

                _tileWidth = Texture.Width / 3;
                _tileHeight = Texture.Height / 4;

                int i = 0;
                for ( int y = 0;  y < Texture.Height; y += _tileHeight) {
                    for (int x = 0; x < Texture.Width; x += _tileWidth) {
                        _spriteArray[i] = new Rectangle(x, y, _tileWidth, _tileHeight);
                        i++;
                    }
                }
            } else {
                _spriteArray = new Rectangle[0];
            }
        }

        public override void Update(GameTime gT) {
            base.Update(gT);

            _elapsed += gT.ElapsedGameTime.Milliseconds;

            

            if (_spriteArray != null) {
                if (_elapsed > (1000 * (1 / (double)FPS))) {
                    _tileIndex++;
                    _elapsed = 0;
                    if (_tileIndex > EndIndex) {
                        _tileIndex = _startIndex;
                    }
                }
            }
        }

        /// <summary>
        /// Draw the current rect.
        /// </summary>
        /// <param name="sB"></param>
        public override void Draw(SpriteBatch sB) {
            GenerateGrid();
            _curRect = _spriteArray[_tileIndex];
            
            sB.Draw(Texture, new Vector2(MyObj.WorldPosition.X, MyObj.WorldPosition.Y), _curRect, Color.White);
        }
    }
}
