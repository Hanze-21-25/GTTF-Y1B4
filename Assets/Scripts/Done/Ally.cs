using System;
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
    private float _cooldown;
    private float _currentCooldown;
    private double _mod;

    /** Unity Events **/

    private void Start() {
        if (agility<= 0) {
            agility = 1;
        }
        UpdateInit();
        _upgraded = false;
    }
    private void Update() {
        Aim();
        if (_target == null) return;
        if (_currentCooldown > 0) {
            _currentCooldown -= Time.deltaTime * (float) _mod;
        }
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

    private void UpdateInit() {
        _mod = Math.Log(agility,10);
        _mod = Math.Floor(_mod);
        _mod = Math.Pow(10, _mod);
        _mod = agility/ _mod;
        
        _cooldown = 1;
        _currentCooldown = 0;
    }

    private void Upgrade() {
        if (_upgraded) return;
        transform.GetComponent<Renderer>().material.color = Color.black;
        // - money
        agility *= 2;
        UpdateInit();
        _upgraded = true;
    }
    private void Sell() {
        // +money/2
        Destroy(gameObject);
    }
    // Key move of an object *
    protected virtual void Action() {
        if (_currentCooldown > 0) return;
        var bullet = Instantiate(bulletType, transform.position, transform.rotation);
        bullet.GetComponent<Projectile>()._target = _target; _currentCooldown = _cooldown;
        Aim();
    }
    // Locks-on on an enemy and rotates towards it
    private void Aim() {
        try {
            // Finds closest enemy
            if (FindObjectsOfType<Enemy>() == null) return;
            _enemies = FindObjectsOfType<Enemy>();
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
                _direction, rotSpeed * Mathf.Deg2Rad * Time.deltaTime,
                1f);
            transform.rotation = Quaternion.LookRotation(rot);
        }
        catch (MissingReferenceException) {
            // New Wave;
        }
    }
}