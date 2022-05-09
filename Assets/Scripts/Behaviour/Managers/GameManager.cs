using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers{
    public class GameManager : MonoBehaviour{
        
        private Spawner spawn;
        public Player player;
        [SerializeField] private int waves;

        private void Start() {
            player = new Player();
            player.Initialise();
            spawn = FindObjectOfType<Spawner>();
        }

        private void Update() {
            if (player.IsAlive() && spawn.wave >= waves) {
                SceneManager.LoadScene("Victory");
                return;
            }
            if (player.IsAlive()) return;
            SceneManager.LoadScene("Defeat");
        }
    }
}