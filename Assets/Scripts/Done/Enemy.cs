using UnityEngine;
using UnityEngine.SceneManagement;

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
    private Waypoint _waypoint;
    private Vector3 _direction;
    
    
    /** Unity Events **/

    // Initialiser
    private void Start() {
        index = 1;
        _waypoints = FindObjectsOfType<Waypoint>();
        _waypoint = GameObject.Find("Waypoint (" + index + ")").GetComponent<Waypoint>();
        InitBody();
    }
    private void Update() {
        _waypoint = GameObject.Find("Waypoint (" + index + ")").GetComponent<Waypoint>();
        _direction = _waypoint.transform.position - transform.position;
        Follow();
    }
    
    // On waypoint touch + checks defeat
    private void OnTriggerEnter(Collider c) {
        if (c.gameObject.GetComponent<Waypoint>() == null) return;
        body.velocity = Vector3.zero;
        
        if (index >= _waypoints.Length) {
            Destroy(gameObject);
            SceneManager.LoadScene("Defeat");
        }
        
        if(index < _waypoints.Length) index++;
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
    
    private void InitBody() {
        body = GetComponent<Rigidbody>();
        if (body == null) body = gameObject.AddComponent<Rigidbody>();
        body.velocity = Vector3.zero;
        body.centerOfMass = Vector3.zero;
        body.inertiaTensorRotation = Quaternion.identity;
        body.freezeRotation = true;
        body.constraints &= ~RigidbodyConstraints.FreezeRotationY;
        body.mass = 40;
    }
    
    // Moves towards waypoint
    private void Follow() {

        var dir = _direction;
        dir = new Vector3(dir.x,0,dir.z);
        // Rotates towards waypoint
        var rot = Vector3.RotateTowards
        (
            transform.forward, dir,
            300 * agility * Mathf.Deg2Rad * Time.deltaTime, //rotation speed
            1f
        );
        transform.rotation = Quaternion.LookRotation(rot);
        
        
        
        
        // Move towards waypoint
        body.AddForce(
             agility * 3000 * dir.normalized * Time.deltaTime, //direction and magnitude
             ForceMode.Force
        );
    }
}

