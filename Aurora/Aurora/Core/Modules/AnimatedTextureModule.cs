using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Aurora.Core.Modules {
    class AnimatedTextureModule : TextureModule {

        /// <summary>
        /// Stores amount of frames.
        /// </summary>
        public int numFrames;

        /// <summary>
        /// Sets current prefix.
        /// </summary>
        public string Prefix;

        /// <summary>
        /// Whether animation is playing or not.
        /// </summary>
        public bool Playing;

        /// <summary>
        /// Stores FPS of this animation.
        /// </summary>
        public float FPS;

        /// <summary>
        /// Current elapsed time.
        /// </summary>
        private float _elapsed;

        /// <summary>
        /// Current frame of the animation.
        /// </summary>
        private int curFrame;

        /// <summary>
        /// Create new instance of this.
        /// </summary>
        public AnimatedTextureModule() : base() {
            Playing = false;
            FPS = 3;
            _elapsed = 0;
            curFrame = 1;
        }

        /// <summary>
        /// Update this.
        /// </summary>
        /// <param name="gT"></param>
        public override void Update(GameTime gT) {
            base.Update(gT);

            if (Playing) {
                _elapsed += gT.ElapsedGameTime.Milliseconds;

                if (_elapsed > (1000 * (1/FPS))) {
                    curFrame++;
                    _elapsed = 0;
                    if (curFrame > numFrames) {
                        curFrame = 1;
                    }
                }

                TextureID = Prefix + curFrame.ToString();
            }
        }
    }
}
