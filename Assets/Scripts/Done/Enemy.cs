using UnityEngine;
using UnityEngine.UI;


/**
 * This class represents all enemies of all types
 */

public class Enemy : MonoBehaviour {
    public float speed = 10f;
    private int _health;
    public int reward = 50;
    private Transform _currentWaypoint;
    private int _stage; // former index - an index of the closest waypoint.
    private HealthBar _hpBar;



    /** Unity Events */
    
    

    /// Initialisation
    private void Start() {
        _stage = 0;
        _currentWaypoint = Waypoints.Points[_stage];
        _health = 100;
        _hpBar = new HealthBar(_health);
    }
    /// Action
    private void Update() {
        Kill();
        MoveToWaypoint();
        _hpBar.Draw(_health);
    }
    
    
    
    
    /** Enemy Methods */
    
    
    
    
    /// Damages this.
    public void Damage(int damage) {
        if (damage > 100|| damage < 0) return;
        _health -= damage;
    }
    /// Kills this + Gives a reward for that.
    private void Kill() {
        if (_health > 0) return;
        _hpBar = null;
        Player.Money += reward;
        Destroy(gameObject);
    }
    /// Sets next waypoint to go;
    private void NextWaypoint() {
        if (_stage >= Waypoints.Amount) {
            Player.Lives--;
            Destroy(gameObject);
            return;
        }
        _stage++;
        _currentWaypoint = Waypoints.Points[_stage];
    }
    /// Moves this towards a current waypoint
    private void MoveToWaypoint() {
        var direction = _currentWaypoint.position - transform.position;
        transform.Translate(direction.normalized * (speed * Time.deltaTime), Space.World);
        if (Vector3.Distance(transform.position, _currentWaypoint.position) <= 0.4f) {
            NextWaypoint();
        }
    }
}


/**
 * This class represents a health bar of an enemy
 */


internal class HealthBar {
    private Image _texture;
    private readonly int _maxHealth;
    public HealthBar(int health) {
        _maxHealth = health;
        Draw(health);
    }
    public Image Draw(int health) {
        var hp = health * 100/ _maxHealth;
        _texture.fillAmount = hp;
        return _texture;
    }
}