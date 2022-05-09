using System.Threading;
using UnityEngine;

namespace DefaultNamespace{
    public class Spawner : MonoBehaviour{
        
        private Enemy[] enemies;
        public int wave { get; private set; }

        private void Start() {
            wave = 0;
        }

        /// Spawns a single wave
        private void Update() {
            Run();
        }

        private void Run() {
            if (enemies.Length > 0) return;
            for (var i = 0; i < 2 * wave; i++) {
                var pos = transform.position;
                pos.y += 1;
                new Enemy(pos);
                Thread.Sleep(1000);
            }
            enemies = (Enemy[]) FindObjectsOfType (typeof(Enemy));
            wave++;
        }
    }
}