using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Aurora.Core.Modules.Base;


namespace Aurora.Core.Objects {
    class GameObject {
        #region Properties
        #region Positioning.
        /// <summary>
        /// Stores the world position of this display object.
        /// </summary>
        public Vector3 WorldPosition;
        #endregion

        #region Modules
        /// <summary>
        /// Dictionary which stores all modules attached to this GameObject
        /// </summary>
        private List<Module> Modules;
        #endregion
        #endregion

        #region Get and Set
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new display object.
        /// </summary>
        public GameObject() {
            WorldPosition = new Vector3(0, 0, 0);
            Modules = new List<Module>();
        }
        #endregion

        #region ModuleManagement.
        /// <summary>
        /// Add a module to a RenderableObject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T AddModule<T>() where T : Modules.Base.Module, new() {
            // Made our Module List if it doesn't exist:
            // Make sure module can only be added once.
            for (int i = 0; i < Modules.Count; i++) {
                if (typeof(T).IsInstanceOfType(Modules[i])) {
                    return (T)Modules[i];
                }
            }

            T newModule = new T {
                MyObj = this
            };

            Modules.Add(newModule);
            return newModule;
        }

        /// <summary>
        /// Get and return module with type T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetModule<T>() where T : Modules.Base.Module {
            // Find and return our module.
            for (int i = 0; i < Modules.Count; i++) {
                if (typeof(T).IsInstanceOfType(Modules[i])) {
                    return (T)Modules[i];
                }
            }

            // No module was found.
            return null;
        }

        /// <summary>
        /// Find and remove module with type T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public bool RemoveModule<T>() where T : Modules.Base.Module {
            // Find and remove our module.
            for (int i = 0; i < Modules.Count; i++) {
                if (typeof(T).IsInstanceOfType(Modules[i])) {
                    Modules.RemoveAt(i);
                    return true;
                }
            }

            // No module was removed.
            return false;
        }
        #endregion
        /// <summary>
        /// TODO: Properly drawing.
        /// </summary>
        /// <param name="sB"></param>
        public void Draw( SpriteBatch sB ) {
            foreach ( Module M in Modules) {
                M.Draw(sB);
            }
        }
    }
}
