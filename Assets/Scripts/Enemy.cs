using System;
using UnityEngine;

/** Represents an opposing force in the game - plastic bottles, boxes, etc. **/
public class Enemy : MonoBehaviour{
    
    /* Serialised Fields */
    [SerializeField] private float health;
    [SerializeField] private int agility;
    [SerializeField] private int reward;
    
    
    /* Private Variables */
    private int index; // Waypoint index
    private Rigidbody body;
    private Waypoint[] _waypoints;
    private Waypoint _target;




    /** Unity Events **/

    private void Start() {
        index = 0;
        _waypoints = FindObjectsOfType<Waypoint>();
        
        body = GetComponent<Rigidbody>();
        if (body == null) body = gameObject.AddComponent<Rigidbody>();

        LockOn();
    }
    private void Update() {
        _target = _waypoints[index];
        Rotate();
        Follow();
    }
    
    // On collision with bullet
    private void OnCollisionEnter(Collision c) {
        var bullet = c.body.gameObject.GetComponent<Projectile>();
        if (bullet != null) Hit(bullet.damage);
    }

    // On waypoint touch
    private void OnTriggerEnter(Collider c) {
        if (index == _waypoints.Length - 1 && c.gameObject.GetComponent<Waypoint>() == _waypoints[index]) {
            throw new Exception("Defeat");
        }
        if (c.gameObject.GetComponent<Waypoint>()) {
            LockOn();
        }
    }



    /** Private Methods **/

    // Moves towards waypoint
    private void Follow() {
        body.AddForce(
             agility * (_target.transform.position - transform.position).normalized * Time.deltaTime, //direction and magnitude
             ForceMode.Force
        );
    }
    
    // Finds a target and locks-on on it
    private void LockOn() {
        if(index < _waypoints.Length - 1) {
            index++;
        }
        _target = _waypoints[index];
    }
    
    // Rotate towards waypoint
    private void Rotate() {
        var rot = Vector3.RotateTowards
        (
            transform.forward,
            
            _target.transform.position - transform.position,
            
            300 * agility * Mathf.Deg2Rad* Time.deltaTime, //rotation speed
            
            1f
        );
        
        transform.rotation = Quaternion.LookRotation(rot);
    }

    // Damages this
    private void Hit(float damage) {
        if (damage is > 200 or < 0) return;
        health -= damage;
        // Hit animation
        if(health <= 0) {
           // Add money = reward
           //Death animation
           Destroy(this);
        }
    }
}

