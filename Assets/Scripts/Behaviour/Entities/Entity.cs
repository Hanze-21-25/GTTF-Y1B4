using System;
using Managers;
using UnityEngine;

namespace Behaviour{
    public abstract class Entity : MonoBehaviour, ILiving{

        [SerializeField] protected int reward;
        [SerializeField] protected int health;
        [SerializeField] protected int agility;
        [SerializeField] protected Transform prefab;
        private Entity instance;

        private void Update() {
            Kill();
            Target();
        }

        protected Entity(Vector3 position) {
            Spawn(position);
        }

        /// Calls kill function if this is dead.
        private void Kill() {
            if (health > 0) return;
            FindObjectOfType<GameManager>().player.money += reward;
            Destroy(this);
        }
        
        /** <summary> Damage() is called by another entity or an object to hurt this </summary>
         * <param name="damage"></param> */
        public void Damage(int damage) {
            if (damage > 100  || damage <= 0) return;
            health -= damage;
        }
        
        /// Spawns this on specific coordinates.
        private void Spawn(Vector3 position) {
            instance = Instantiate(this, position, Quaternion.Euler(Vector3.zero));
        }

        /// Executes a specific ability of an entity.
        protected abstract void Action();
        
        /// Used to get the target.
        protected abstract void Target();
    }
}