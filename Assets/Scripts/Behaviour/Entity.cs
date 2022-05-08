using System;
using UnityEngine;

namespace Behaviour{
    public abstract class Entity : MonoBehaviour, ILiving{

        [SerializeField] protected int reward;
        [SerializeField] protected int health;
        [SerializeField] protected int agility;
        [SerializeField] private Game player;
        
        /**
         * Executes a specific ability of an entity.
         */
        protected abstract void Action();
        
        /**
         * Used to get the target.
         */
        protected abstract void Target();
        
        
        private void Update() {
            KillOnDead();
        }

        /**
         * Calls kill function if this is dead.
         */
        protected void KillOnDead() {
            if (IsAlive()) return;
            Kill();
        }
        
        
        /** <summary> Damage() is called by another entity or an object to hurt this </summary>
         * <param name="damage"></param> */
        
        public void Damage(int damage) {
            if (damage > 100  || damage <= 0) return;
            if(health <= damage) {Kill(); return;}
            health -= damage;
        }
        
        
        public int GetHealth() {
            return health;
        }
        

        /// Checks whether this is alive or dead.
        protected bool IsAlive() {
            return health > 0;
        }
        
        /// Instantly kills this object.
        private void Kill() {
            Debug.Log(name + " Was killed");
            Destroy(this);
        }

        private void Reward(ref int money) {
            money += reward;
        }
    }
}