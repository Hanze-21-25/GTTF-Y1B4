using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawn <T> : MonoBehaviour where T : MonoBehaviour{
    
    /* Serialised Fields */
    [SerializeField] private float cooldown;
    [SerializeField] private Transform subject;
    [SerializeField] private float offset;
    [SerializeField] private int waves;

    
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
                StartCoroutine(NewWave());
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
    private void Update() {
        if (Wave > waves) SceneManager.LoadScene("Victory"); // Win
        if (subjects <= 0 && !inWait) Wave++;
    }

    /** Private Enumerators **/

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
    // Launches a new wave
    private IEnumerator NewWave() {
        inWait = true;
        yield return new WaitForSeconds(5);
        StartCoroutine(Action());
    }
}
