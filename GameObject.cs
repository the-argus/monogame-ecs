using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace GameObject_Proof_of_Concept
{
    class GameObject
    {
        // public int id { get; }

        List<Component> ComponentList;
        
        public GameObject()
        {
            ComponentList = new List<Component>();
        }

        public void AddComponent(Component item)
        {
            ComponentList.Add(item);
        }

        // calls the update method of every component that implements IUpdate
        public void Update()
        {
            foreach (Component c in ComponentList)
            {
                if (c is IUpdate)
                {
                    IUpdate u = (IUpdate)c;
                    u.Update();
                }
            }
        }

        // calls the draw method of every component that implements IDraw
        public void Draw()
        {
            foreach (Component c in ComponentList)
            {
                if (c is IDraw)
                {
                    IDraw u = (IDraw)c;
                    u.Draw();
                }
            }
        }
        
        /// <summary>
        /// Get the first component of type T from this game object's component list.
        /// </summary>
        /// <typeparam name="T">Type of component to return.</typeparam>
        /// <returns>First Component of type T found.</returns>
        public T GetComponent<T>() where T : Component
        {
            foreach (Component c in ComponentList)
            {
                if (c.GetType().Equals(typeof(T)))
                {
                    return (T)c;
                }
            }
            return null;
        }
    }
}
