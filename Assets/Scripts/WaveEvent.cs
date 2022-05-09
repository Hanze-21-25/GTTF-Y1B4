using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class WaveEvents : MonoBehaviour
{
    public static int EnemiesAlive;
    public Wave[] waves;
    public Transform spawnPoint;
    [FormerlySerializedAs("timeBetweenWaves")] public float waveDeelay = 5f;
    public float countdown = 10f;
    private int waveIndex;
    
    private void Start()
    {
        EnemiesAlive = 0;
    }

    void Update () {

        if (EnemiesAlive > 0) return;
        if (countdown <= 0f) {
            StartCoroutine(SpawnWave());
            countdown = waveDeelay;
            return;
        }
        
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
    }
    
    IEnumerator SpawnWave () {
        
        Wave wave = waves[waveIndex];
        
        for (int i = 0; i < wave.count; i++) {
            Instantiate(wave.enemy, spawnPoint.position, spawnPoint.rotation);
            EnemiesAlive++;
            yield return new WaitForSeconds(1f / wave.rate);
        }
        waveIndex++;
        PlayerStats.Rounds++;
        
        if (waveIndex == waves.Length) {
            Debug.Log("LEVEL WON!");
            this.enabled = false;
            FindObjectOfType<GameManager>().WinLevel();
        }
    }
}