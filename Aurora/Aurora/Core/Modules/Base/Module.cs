using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Aurora.Core.Objects;

namespace Aurora.Core.Modules.Base {
    class Module {
        /// <summary>
        /// Stores my object
        /// </summary>
        public GameObject MyObj { get; set; }

        /// <summary>
        /// Creates new instance of Module.
        /// </summary>
        public Module() {
   
        }

        /// <summary>
        /// Turn this module on.
        /// </summary>
        public void Enable() {

        }

        /// <summary>
        /// Turn this module off.
        /// </summary>
        public void Disable() {

        }

        /// <summary>
        /// Updates this module.
        /// </summary>
        /// <param name="gT"></param>
        public virtual void Update(GameTime gT ) {
        }

        /// <summary>
        ///  Draw logic for this module.
        /// </summary>
        /// <param name="sB"></param>
        public virtual void Draw(SpriteBatch sB) {
           
        }
    }
}
