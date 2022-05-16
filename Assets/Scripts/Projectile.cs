using System;
using UnityEngine;
public class Projectile : MonoBehaviour{

    /* Serialized Fields */
    [SerializeField] private int power;

    /* Public Variables */
    

    /* Private Variables */ 
    private Enemy _target;
    private Rigidbody _body;
    private Vector3 _spawn;
    
    
    /* Public Fields */
    public float damage { get; private set; }

    /** Unity Event Functions **/
    
    // Initialisation
    private void Start() {
        _target = transform.parent.GetComponent<Ally>()._target;
        _spawn = transform.position;
        _body = gameObject.GetComponent<Rigidbody>();
        if (_body == null) {
            _body = gameObject.AddComponent<Rigidbody>();
        }
    }

    private void Update() {
        damage = power / (transform.position - _spawn).magnitude;
        Follow();
    }

    private void OnCollisionEnter(Collision c) {
        var enemy = c.gameObject.GetComponent<Enemy>();
        if(enemy != null) {
            // Particle explosion;
            Destroy(this);
        }
    }
    
    /** Public Methods **/

    /** Private Methods **/
    private void Follow() {
        var dir = _target.transform.position - transform.position;
        if (dir.magnitude > 300) Destroy(this); // Destroys itself if it's too far from enemy
        _body.AddForce(dir * power * Time.deltaTime, ForceMode.Force);
    }
}