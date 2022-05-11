using UnityEngine;
using UnityEngine.UI;


/**
 * This class represents all enemies of all types
 */
public class Enemy : MonoBehaviour {
    public float speed = 10f;
    public int reward = 50;
    int _health;
    int _stage; // former index - an index of the closest waypoint.
    HealthBar _hpBar;
    Transform _currentWaypoint;


    
    /** Unity Events */
    
    
    /// Initialisation
    void Start() {
        _stage = 0;
        _currentWaypoint = Waypoints.Points[_stage];
        _health = 100;
        _hpBar = new HealthBar(_health);
    }

    /// Action
    void Update() {
        Kill();
        MoveToWaypoint();
        _hpBar.Draw(_health);
    }
    
    
    
    /** Enemy Methods */
    
    
    /// Damages this
    public void Damage(int damage) {
        if (damage > 100 || damage < 0) return;
        _health -= damage;
    }

    /// Kills this + Gives a reward for that
    void Kill() {
        if (_health > 0) return;
        _hpBar = null;
        Player.Money += reward;
        Destroy(gameObject);
    }

    /// Sets next waypoint to go
    void NextWaypoint() {
        if (_stage >= Waypoints.Amount) {
            Player.Lives--;
            Destroy(gameObject);
            return;
        }

        _stage++;
        _currentWaypoint = Waypoints.Points[_stage];
    }

    /// Moves this towards a current waypoint
    void MoveToWaypoint() {
        var direction = _currentWaypoint.position - transform.position;
        transform.Translate(direction.normalized * (speed * Time.deltaTime), Space.World);
        if (Vector3.Distance(transform.position, _currentWaypoint.position) <= 0.4f) NextWaypoint();
    }
}


/**
 * This class represents a health bar of an enemy
 */
internal class HealthBar {
    Image _texture;
    readonly int _maxHealth;

    public HealthBar(int health) {
        _maxHealth = health;
        Draw(health);
    }

    public Image Draw(int health) {
        var hp = health * 100 / _maxHealth;
        _texture.fillAmount = hp;
        return _texture;
    }
}