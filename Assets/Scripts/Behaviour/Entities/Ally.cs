using System;
using Behaviour;
using UnityEngine;

namespace DefaultNamespace.Entities.Allies{
    public abstract class Ally : Entity{
        
        private Node node;
        private Ally instance;
        [SerializeField] private float heightOffset;

        private void Update() {
            Target();
            Action();
        }

        /// Targets enemies.
        protected override void Target() {
            throw new NotImplementedException();
        }

        /// Places this to nodes.
        private void Place(ref int money, Node node) {
            money -= reward;
            var pos = node.transform.position;
            pos.y += heightOffset;
            instance = Instantiate(this,pos, Quaternion.Euler(Vector3.zero));
            instance.transform.parent = node.transform;

        }

        /// Sells this from node and removes it from the scene.
        private void Sell(ref int money) {
            money += reward;
            Destroy(this);
        }
        
        /// Shots at enemies.
        protected abstract override void Action();
        
        /// Upgrades this
        protected abstract void Upgrade();

        protected Ally(Vector3 position) : base(position) {
        }
    }
}