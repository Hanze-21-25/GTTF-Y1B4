using UnityEngine;
using System.Threading;

public class Ally : MonoBehaviour{
    
    /* Serialised Fields */
    
    [SerializeField] private int agility; // Fire rate
    [SerializeField] private Transform bulletType;
    
    /* Public Variables */
    public Enemy _target { get; private set; }

    /* private Variables */
    
    private bool _upgraded;
    private Tile _host; // A tile, on top of which this sits 
    private Enemy[] _enemies;
    

    /** Unity Events **/

    private void Start() {
        LockOn();
        agility = 1;
        _upgraded = false;
    }
    private void Update() {
        Action();
        Aim();  
    }
    private void OnMouseOver() {
        if (Input.GetMouseButtonDown(2) || Input.GetKeyDown(KeyCode.Backspace)) {
            Sell();
        }
        if (Input.GetMouseButtonDown(1)) {
            Upgrade();
        }
    }


    
    
    /** Private Methods **/
    
    
    private void Upgrade() {
        if (_upgraded) return;
        transform.GetComponent<Renderer>().material.color = Color.black;
        // Add money
        agility *= 2;
        _upgraded = true;
    }
    private void Sell() {
        // Add money
        Destroy(gameObject);
    }
    
    
    
    // Key move of an object *
    private void Action() {
        var bullet = Instantiate(bulletType, transform.position, transform.rotation).GetComponent<Projectile>();
        bullet.transform.parent = transform;
    }
    
    // Locks On on an enemy
    private void Aim() {
        _target = LockOn();
        
        var dir = _target.transform.position - transform.position;
        var rotSpeed = 100 * agility;
        
        var rot = Vector3.RotateTowards(transform.forward,
            dir, rotSpeed * Mathf.Deg2Rad* Time.deltaTime, 
            1f);
        
        transform.rotation = Quaternion.LookRotation(rot);
    }
    
    // Returns closest enemy
    private Enemy LockOn() {
        
        _enemies = FindObjectsOfType<Enemy>();
        var lo = Mathf.Infinity;
        
        Enemy closest = null;
        foreach (var enemy in _enemies) {
            var distance = Vector3.Distance(transform.position, enemy.transform.position);
            
            if (distance >= lo) continue;
            lo = distance;
            closest = enemy;
        }
        
        return closest;
    }
}