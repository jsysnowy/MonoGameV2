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

        #region Parent/Children
        /// <summary>
        /// Stores parent of this.
        /// </summary>
        private GameObject Parent;

        /// <summary>
        /// Stores children of this.
        /// </summary>
        private List<GameObject> Children;
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
            Children = new List<GameObject>();
        }
        #endregion

        #region Children functions.
        /// <summary>
        /// Add an object to this manager.
        /// </summary>
        /// <param name="obj"></param>
        public void Add(GameObject obj) {
            Children.Add(obj);
            obj.Parent = this;
        }

        /// <summary>
        ///  Remove an object from this manager.
        /// </summary>
        /// <param name="obj"></param>
        public void Remove(GameObject obj) {
            Children.Remove(obj);
            obj.Parent = null;
        }

        /// <summary>
        ///  Clear all objects from this ObjectManager.
        /// </summary>
        public void Clear() {
            foreach ( GameObject child in Children) {
                child.Parent = null;
            }
            Children.Clear();
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
        /// Update all modules in this.
        /// </summary>
        /// <param name="gt"></param>
        public void Update( GameTime gT) {
            // Update each module in this GameObject.
            foreach ( Module M in Modules) {
                M.Update(gT);
            }
            // Update all its children.
            foreach ( GameObject C in Children) {
                C.Update(gT);
            }
        }

        /// <summary>
        /// TODO: Properly drawing.
        /// </summary>
        /// <param name="sB"></param>
        public void Draw( SpriteBatch sB ) {
            // Draw all modules in this GameObject.
            foreach ( Module M in Modules) {
                M.Draw(sB);
            }

            // Draw all this modules children.
            foreach (GameObject C in Children) {
                C.Draw(sB);
            }
        }
    }
}
