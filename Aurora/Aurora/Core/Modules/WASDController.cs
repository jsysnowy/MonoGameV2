using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Aurora.Core.Modules {
    class WASDController : Base.Module {

        public override void Update(GameTime gT) {
            KeyboardState keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.W)) {
                MyObj.WorldPosition.Y -= 1.5f;
            }
            if (keyState.IsKeyDown(Keys.A)) {
                MyObj.WorldPosition.X -= 1.5f;
            }
            if (keyState.IsKeyDown(Keys.S)) {
                MyObj.WorldPosition.Y += 1.5f;
            }
            if (keyState.IsKeyDown(Keys.D)) {
                MyObj.WorldPosition.X += 1.5f;
            }
        }
    }
}
