using Behaviour;
using Managers;
using UnityEngine;
using UnityEngine.UI;

///Enemy Class
public class Enemy : Entity{

    private int checkpoint; // Drop from the enemy.
    private Waypoint path; // A waypoint to go to.
    [SerializeField] private Image healthBar;

    private void Start() {
        checkpoint = 0;
        path = new Waypoint();
        Target();
    }
    
    public Enemy(Vector3 position) : base(position) {
    }

    /// Gets next waypoint
    protected override void Target () {
        path.GetPoint(checkpoint);
    }

    /// Moves this to next waypoint.
    protected override void Action() {
        //Move towards target
    }
    
     /// takes player's life if end reached
    private void End() {
        //if end reached
        FindObjectOfType<GameManager>().player.Damage();
    }
}