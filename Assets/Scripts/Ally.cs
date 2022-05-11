using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Ally : MonoBehaviour{
    
    /* Serialised Fields */
    /* public variables */
    
    
    /* private variables */
    private int _agility; // Fire rate
    private bool _upgraded;
    private Tile _host; // A tile, on top of which this sits 
    // private Enemy target;

    /** Unity Events **/

    private void Start() {
        _agility = 1;
        _upgraded = false;
    }

    private void Update() {
        Action();
        Aim();
    }

    private void OnMouseDown() {
        var MMB = Input.GetMouseButtonDown(2);
        var RMB = Input.GetMouseButtonDown(1);
        if (MMB) {
            Sell();
        }

        if (RMB) {
            Upgrade();
        }
    }

    /** Public Methods **/
    
    // Sets a host of this 
    public void SetHost(ref Ally ally,Tile host) { // ally should be passed empty. 
        _host = host;
        ally = this;
    }
    
    
    

    /** Private Methods **/
    

    // Key move of an object *
    private void Action() {
        
    }
    
    // Locks On on an enemy *
    private void Aim() {
        
    }
    
    // *
    private void Upgrade() {
        if (_upgraded) return;
        // Add money
        _agility *= 2;
        _upgraded = true;
    }

    // *
    private void Sell() {
        // Add money
        Destroy(this);
    }
}