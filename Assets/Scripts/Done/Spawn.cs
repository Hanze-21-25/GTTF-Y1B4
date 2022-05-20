using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class Spawn <T> : MonoBehaviour where T : MonoBehaviour{

    
    
    /* Serialised Fields */
    [SerializeField] private float cooldown;
    [SerializeField] private Transform subject;
    [SerializeField] private float offset;




    /* Private Variables */
    private int entitiesToSpawn;
    private int currentEntities;
    private bool inWait;

    private int _wave;
    public int Wave {
        get => _wave;
        private set {
            if (value >= 0) {
                entitiesToSpawn = (int) Math.Pow(2, value) + 1;
                currentEntities = FindObjectsOfType<T>().Length;
                _wave = value;
                StartCoroutine(Action());
            }
            else {
                throw new ArgumentOutOfRangeException();
            }
        }
    }


    /** Unity Events **/
    // Initialises spawn variables if needed.
    private void Start() {
        if (subject.gameObject.GetComponent<T>() == null) {
            Debug.Log("Subject's not Enemy, thus destroyed");
            Destroy(gameObject);
        }
        Wave = 3;
    }

    // Spawn cooldown timer;
    private void Update() {
        if (currentEntities <= 0 && !inWait) Wave++;
        else {
            currentEntities = FindObjectsOfType<T>().Length;
        }
    }


    // Spawns Enemies
    private IEnumerator Action() {
        
        var t = transform;
        currentEntities = FindObjectsOfType<T>().Length;
        
        while (currentEntities < entitiesToSpawn) {

            inWait = true;
            yield return new WaitForSeconds(cooldown);
            Instantiate(subject,t.position + Vector3.up * offset, t.rotation);
            currentEntities++;
            inWait = false;
        }
    }
}