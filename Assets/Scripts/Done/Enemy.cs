using UnityEngine;
using UnityEngine.SceneManagement;

/** Represents an opposing force in the game - plastic bottles, boxes, etc. **/
public partial class Enemy : MonoBehaviour{
    
    /* Serialised Fields */
    [SerializeField] private float health;
    [SerializeField] private int agility;
    [SerializeField] private int reward;
    
    
    /* Private Variables */
    private int index; // Waypoint index
    private Rigidbody body;
    private Waypoint[] _waypoints;
    private Waypoint _waypoint;
    private Vector3 _direction;
    
    
    /** Unity Events **/

    // Initialiser
    private void Start() {
        index = 0;
        _waypoints = FindObjectsOfType<Waypoint>();
        body = GetComponent<Rigidbody>();
        if (body == null) body = gameObject.AddComponent<Rigidbody>();
    }
    private void Update() {
        if (_waypoints.Length > 0) {
            _waypoint = _waypoints[index];
            _direction = _waypoint.transform.position - transform.position;
            Follow();
        }
    }
    
    // On waypoint touch + checks defeat
    private void OnTriggerEnter(Collider c) {
        if (c.gameObject.GetComponent<Waypoint>() == null) return;
        body.velocity = Vector3.zero;
        if (index == _waypoints.Length - 1 && c.gameObject.GetComponent<Waypoint>() == _waypoints[index]) {
            Destroy(gameObject);
            SceneManager.LoadScene("Defeat");
        }
        if(index < _waypoints.Length - 1) {
            index++;
        }
        GetComponent<Renderer>().material.color = Color.red;
        
        if(index < _waypoints.Length - 1) {
            index++;
        }
    }

    
    /** Public Methods **/
    
    // Damages this
    public void Hit(float damage) {
        if (damage is > 200 or < 0) return;
        health -= damage;
        // Hit animation
        if(health <= 0) {
            // Add money = reward
            //Death animation
            Destroy(gameObject);
        }
    }
    
    /** Private Methods **/
    
    // Moves towards waypoint
    private void Follow() {
        // Rotates towards waypoint
        var rot = Vector3.RotateTowards
        (
            transform.forward,
            _waypoint.transform.position - transform.position,
            300 * agility * Mathf.Deg2Rad * Time.deltaTime, //rotation speed
            1f
        );
        transform.rotation = Quaternion.LookRotation(rot);
        
        
        
        
        // Move towards waypoint
        body.AddForce(
             agility * 30 * _direction.normalized * Time.deltaTime, //direction and magnitude
             ForceMode.Force
        );
    }
}

