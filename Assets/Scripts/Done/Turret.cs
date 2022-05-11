using System;
using UnityEngine;

public class Turret : MonoBehaviour {
    
    Transform _target;
    float _timer;
    Node _host;
    
    public GameObject prefab;

    public int cost;
    public float fireRate = 1f;
    public bool upgraded;
    public float range = 15f;
    
    
    
    /* Unity Events */
    
    void Start() {
        upgraded = false;
    }
    void Update() {
        Action();
    }
    
    
    /* Methods */
    
    /// Targets closest enemy (launched from the start loop) 
    void LockOn() {
        //Target lock on
        transform.rotation = Quaternion.Euler(new Vector3(0, (_target.position - transform.position).y, 0));
    }
    
    /// Action
    void Action(){
        if (_target == null) return;

        LockOn();
        if (_timer > 0) { 
            _timer -= Time.deltaTime;
            return;
        }
        Shoot();
        _timer = 1/fireRate;
    }
    
    /// Launches a projectile towards closest enemy
    void Shoot() {
        throw new NotImplementedException();
    }

    /// Upgrades this
    public void Upgrade() {
        throw new NotImplementedException();
        if (Player.Money < cost * 1.25) return;
        // upgrade code; Change stats and prefab
        upgraded = true;
    }

    /// Sells this (Done)
    public void Sell() {
        Player.Money += cost / 2;
        Destroy(this);
    }
}