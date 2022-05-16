using System.Collections;
using UnityEngine;

public class Ally : MonoBehaviour{
    
    /* Serialised Fields */
    
    [SerializeField] private int agility; // Fire rate
    [SerializeField] private int cost; // Fire rate
    [SerializeField] private Transform bulletType;

    /* Private Variables */

    private bool _upgraded;
    private Tile _host; // A tile, on top of which this sits 
    private Enemy[] _enemies;
    private Vector3 _direction;
    private Enemy _target;
    private Game _game;

    /** Unity Events **/

    private void Start() {
        agility = 1;
        _upgraded = false;
    }
    private void Update() {
        if (_target == null) return;
        Aim();
        Action();
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
        _game.money -= cost;
        agility *= 2;
        _upgraded = true;
    }
    private void Sell() {
        _game.money += cost/2;
        Destroy(gameObject);
    }

    // Key move of an object *
    private void Action() {
        Aim();
        var bullet = Instantiate(bulletType, transform.position, transform.rotation);
        bullet.GetComponent<Projectile>()._target = _target;
    }
    
    // Locks-on on an enemy and rotates towards it
    private void Aim() {
        // Finds closest enemy
        _enemies = _game != null ? _game.Enemies : FindObjectsOfType<Enemy>();
        
        var lo = Mathf.Infinity;
        
        Enemy closest = null;
        foreach (var enemy in _enemies) {
            var distance = Vector3.Distance(transform.position, enemy.transform.position);
            
            if (distance >= lo) continue;
            lo = distance;
            closest = enemy;
        }
        _target = closest;
        
        _direction = _target.transform.position - transform.position;
        
        
        // Rotates towards enemy
        var rotSpeed = 100 * agility;
        var rot = Vector3.RotateTowards(transform.forward,
            _direction, rotSpeed * Mathf.Deg2Rad* Time.deltaTime, 
            1f);
        transform.rotation = Quaternion.LookRotation(rot);
    }
}