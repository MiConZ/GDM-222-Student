using UnityEngine;

namespace Assignment02.StudentSolution
{
    public class Entity
    {
        public string name;
        private UnityEngine.Vector3 position;
        protected int health;

        public virtual void Update()
        {
        }

        protected virtual void TakeDamage(int damage)
        {
        }

        private void Move(UnityEngine.Vector3 direction)
        {
        }
    }
}
