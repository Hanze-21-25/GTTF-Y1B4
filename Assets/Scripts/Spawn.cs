using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawn <T> : MonoBehaviour where T : MonoBehaviour{
    
    /* Serialised Fields */
    [SerializeField] private float cooldown;
    [SerializeField] private float timeout;
    [SerializeField] private Transform subject;
    [SerializeField] private float offset;
    [SerializeField] private int wave;

    /* Private Variables */
    private bool _isSpawning;
    private static bool _noSpawnedItems => !FindObjectOfType<T>();
    private int _current;


    /** Unity Events **/
    
    
    
    // Initialises spawn variables if needed.
    private void Start() {
        if (subject.gameObject.GetComponent<T>() == null) {
            Debug.Log("Subject's not Enemy, thus destroyed");
            Destroy(gameObject);
        }
        _current = 0;
        _isSpawning = false;
    }
    
    private void Update() {
        if (_current > wave) SceneManager.LoadScene("Victory");
        if (_noSpawnedItems && !_isSpawning && _current <= wave) StartCoroutine(Initiate());
    }

    /** Private Enumerators **/

    // Next Wave
    private IEnumerator Action() {
        
        
        //Spawns Enemies
        for (var sub = 0; sub <= (int) (Math.Pow(2, _current) + 1); sub++) {
            yield return new WaitForSeconds(cooldown);
            Instantiate(subject,transform.position + Vector3.up * offset, transform.rotation);
        }
        _isSpawning = false;
    }

    private IEnumerator Initiate() {
        _isSpawning = true;
                // Launches new wave
                _current++;
                if (cooldown > 0.5f) cooldown-=0.4f; //Acceleration of spawn each wave
                yield return new WaitForSeconds(timeout);
                StartCoroutine(Action());
    }
}
