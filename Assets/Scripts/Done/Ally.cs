using UnityEngine;
using System;
using System.Runtime.InteropServices.ComTypes;

public class Ally : MonoBehaviour{
    
    /* Serialised Fields */
    
    [SerializeField] private int agility; // Fire rate
    
    
    /* public variables */
    
    
    /* private variables */
    
    private bool _upgraded;
    private Tile _host; // A tile, on top of which this sits 
    private Enemy[] _enemies;
    private Enemy _target;

    /** Unity Events **/

    private void Start() {
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
    
    /** Public Methods **/
    
    // Sets a host of this 
    public void SetHost(ref Ally ally,Tile host) { // ally should be passed empty. 
        _host = host;
        ally = this;
    }
    public void Upgrade() {
        if (_upgraded) return;
        transform.GetComponent<Renderer>().material.color = Color.black;
        // Add money
        agility *= 2;
        _upgraded = true;
    }
    public void Sell() {
        // Add money
        Destroy(gameObject);
    }
    
    
    
    /** Private Methods **/
    
    
    // Key move of an object *
    private void Action() {
        
    }
    // Locks On on an enemy
    private void Aim() {
        _target = LocateClosestEnemy();
        
        var dir = _target.transform.position - transform.position;
        var rotSpeed = 5 * agility;
        
        var rot = Vector3.RotateTowards(transform.forward,
            dir, rotSpeed * Mathf.Deg2Rad* Time.deltaTime, 
            1f);
        
        transform.rotation = Quaternion.LookRotation(rot);
    }

    // Returns closest enemy
    private Enemy LocateClosestEnemy() {
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