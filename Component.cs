using System;
using System.Collections.Generic;
using System.Text;

namespace GameObject_Proof_of_Concept
{
    class Component
    {
        public GameObject gameObject;

        public Component(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }
    }

    interface IUpdate
    {
        public void Update();
    }

    interface IDraw
    {
        public void Draw();
    }
}
