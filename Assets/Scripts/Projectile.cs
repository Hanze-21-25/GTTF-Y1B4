using System;
using UnityEngine;
public class Projectile : MonoBehaviour{

    /* Serialized Fields */
    
    [SerializeField] private float velocity;
    
    /* Private Variables */
    private Enemy _target;
    private Rigidbody body;

    /** Unity Event Functions **/
    
    // Initialisation
    private void Start() {
        body = gameObject.GetComponent<Rigidbody>();
        if (body == null) {
            body = gameObject.AddComponent<Rigidbody>();
        }
    }
    

    /** Public Methods **/
    
    /** Private Methods **/
    private void Follow() {
        var dir = _target.transform.position - transform.position;
        body.AddForce(dir, ForceMode.Force);
        
    }

    private void Launch(Vector3 position) {
        
    }

    private void Hit() {
        
    }
}