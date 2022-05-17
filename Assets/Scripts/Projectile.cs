
using System;
using System.Linq.Expressions;
using UnityEngine;
public class Projectile : MonoBehaviour{

    /* Serialized Fields */
    [SerializeField] private int power;
    [SerializeField] private float age;

    /* Public Variables */
    [NonSerialized] public Enemy _target;

    /* Private Variables */
    private Rigidbody _body;
    private Vector3 _spawn;
    private Vector3 _direction;
    private Transform _parent;

    /** Unity Event Functions **/
    
    // Initialiser
    private void Start() {
        _body = gameObject.GetComponent<Rigidbody>();
        if (_body == null) {
            _body = gameObject.AddComponent<Rigidbody>();
        }
    }

    private void Update() {
        Follow();
    }

    private void OnCollisionEnter(Collision c) {
        // Particle explosion
        if (c.transform != _target.transform) return;
        gameObject.GetComponent<Renderer>().material.color = Color.cyan;
        c.gameObject.GetComponent<Enemy>().Hit(power); Destroy(gameObject);
    }

    /** Private Methods **/
    private void Follow() {
        try {
            // Rotate to target
            var rot = Vector3.RotateTowards
            (
                transform.forward,
                _target.transform.position - transform.position,
                300 * power * Mathf.Deg2Rad * Time.deltaTime, //rotation speed
                1f
            );
            transform.rotation = Quaternion.LookRotation(rot);
            // Moves towards a target
            if (_target != null) {
                _direction = _target.transform.position - transform.position;
                _body.velocity = Vector3.zero;
                _body.AddForce(
                    power * 300 * _direction.normalized * Time.deltaTime, //direction and magnitude
                    ForceMode.Force
                );
            }
            else {
                Destroy(gameObject);
            }
        }
        catch (MissingReferenceException) {
            // Explosion animation
            Destroy(gameObject); 
        }
    }
}