using System;
using System.Collections;
using UnityEngine;

public class Spawn : MonoBehaviour{

    /* Serialised Fields */
    [SerializeField] private float cooldown;
    [SerializeField] private Transform target; // Object to spawn
    
    /* Private Variables */
    private Enemy[] _targets; // Object to spawn
    private int _wave;
    private Game _game;

    /** Unity Events **/
    
    // Initialiser
    private void Start() {
        var otherSP = FindObjectOfType<Spawn>(); // Removes other spawns if found
        if (otherSP != null) {
            Destroy(otherSP);
        }
    }
    private void Update() {
        _wave = _game._wave;
        _targets = FindObjectsOfType<Enemy>();
        _game.Enemies = _targets;
        
        StartCoroutine(Launch()); // Launches Spawn
    }

    /** Private Methods **/
    // Launches spawn. Called by coroutine. Spawns an enemy and adds it to _targets[];
    private IEnumerator Launch() {
        for (var index = 0;index < (int) Math.Pow(2,_wave); index++) {
            yield return new WaitForSeconds(cooldown);
            Instantiate(target, transform.position, transform.rotation).GetComponent<Enemy>(); // Spawn
        }
    }
}