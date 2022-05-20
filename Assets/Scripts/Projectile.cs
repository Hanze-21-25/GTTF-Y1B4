using System;
using UnityEngine;
using Random = UnityEngine.Random;

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
    private Renderer rnd;
    private Color _dstroyClr;

    /** Unity Event Functions **/
    
    // Initialiser
    private void Start() {
        rnd = GetComponent<Renderer>() == null ? gameObject.AddComponent<Renderer>() : rnd;
        _body = gameObject.GetComponent<Rigidbody>();
        if (_body == null) {
            _body = gameObject.AddComponent<Rigidbody>();
        }
    }

    private void Update() {
        Follow();
    }

    private void OnCollisionEnter(Collision c) {
        try {
            // Particle explosion
            if (c.transform != _target.transform) return;
            c.gameObject.GetComponent<Enemy>().Hit(power);
            Destroy(gameObject);
        }
        catch (MissingReferenceException) {
            Destroy(gameObject);
        }
    }


    private void OnDestroy() {
        //Destroy animation (Explosion).
    }

    /** Private Methods **/
    // Locks-on and follows target& 
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
                    power * 600 * _direction.normalized * (float) (Math.Log(_direction.magnitude,power) + 1.5f) * Time.deltaTime, //direction and magnitude
                    ForceMode.Force
                );
            }
            else {
                Destroy(gameObject);
            }
        }
        catch (MissingReferenceException) {
            Destroy(gameObject,0.65f);
        }
    }
}