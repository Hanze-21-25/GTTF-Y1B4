using System.Threading;
using UnityEngine;

[System.Serializable]
public class Wave : MonoBehaviour {

    public int number;
    private int maxEnemies;
    public int enemyCounter;
    public int rate = 500;
    public Transform spawn;
    public static Enemy[] enemies;
    private GameObject[] enemyTypePrefabs;
    
    private void Start() {
        enemyCounter = 0;
        number = 0;
        SpawnWave(enemyTypePrefabs, maxEnemies);
    }
    private void Update() {
        enemies = FindObjectsOfType<Enemy>();
        enemyCounter = enemies.Length;
    }
    /// Spawns a single wave. Gets array of enemy type prefabs as an argument
    private void SpawnWave(GameObject[] prefabs, int maxEnemies) {
        if (enemyCounter > 0) return;
        
        Thread.Sleep(10000);

        // Spawn enemies of all types, no more that maximum set in total.
        foreach (var type in prefabs) {
            for (var i = 0; i < maxEnemies / prefabs.Length; i++) {
                var instance = Instantiate(type, spawn.position, spawn.rotation);
                instance.transform.parent = transform.parent;
                Thread.Sleep(rate);
            }
        }

        number++;
        PlayerStats.Rounds++;
    }

}