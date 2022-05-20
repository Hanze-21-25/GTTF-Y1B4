using System;
using System.Collections;
using UnityEngine;

public class Spawn <T> : MonoBehaviour where T : MonoBehaviour{

    
    
    /* Serialised Fields */
    [SerializeField] private float cooldown;
    [SerializeField] private Transform subject;
    [SerializeField] private float offset;




    /* Private Variables */
    private int subjectToSpawn;
    private int subjects => FindObjectsOfType<T>().Length;
    private bool inWait;

    private int _wave;
    private int Wave {
        get => _wave;
         set {
            if (value >= 0) {
                subjectToSpawn = (int) Math.Pow(2, value) + 1;
                if (cooldown > 0.5f) cooldown-=0.4f;
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
        Wave = 0;
    }

    // Spawn cooldown timer;
    private void Update() {
        if (subjects <= 0 && !inWait) Wave++;
    }


    // Spawns Enemies
    private IEnumerator Action() {
        
        var t = transform;
        var sub = subjectToSpawn;

        while (sub <= subjectToSpawn && sub > 0) {

            inWait = true;
            yield return new WaitForSeconds(cooldown);
            Instantiate(subject,t.position + Vector3.up * offset, t.rotation);
            sub--;
            inWait = false;
        }
    }
}