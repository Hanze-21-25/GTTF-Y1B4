using System;
using Behaviour;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Entity{

    private int checkpoint;
    protected int reward; // Drop from the enemy.
    private Path path; // A waypoint to go to.
    private HealthBar healthBar;

    private void Start() {
        Initialise();
        Action();
    }

    ///Initialises default necessary value
    private void Initialise() {
        checkpoint = 0;
        path = new Path();
        Target();
    }

    /// Gets next waypoint
    protected override void Target () {
        path.GetPoint(checkpoint);
    }

    /// Moves this to next waypoint.
    protected override void Action() {
        
    }

    protected void Reward() {
        
    }
}

[Serializable]
internal class HealthBar{
    // The host of the health bar
    private Enemy owner;
    
    private int hp { get; set; }
    [SerializeField] private Image texture;
    
    public HealthBar(Enemy enemy) {
        hp = enemy.GetHealth();
        owner = enemy;
    }

    private void Draw() {
        throw new NotImplementedException();
    }
}