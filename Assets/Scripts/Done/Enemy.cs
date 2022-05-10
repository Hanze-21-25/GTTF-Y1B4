using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
    public float speed = 10f; 
    public int maxHealth = 100;
    private int health;
    public int reward = 50;
    private Transform currentWaypoint;
    private int stage; // former index - an index of the closest waypoint.
    private HealthBar hpBar;

    /// Initialisation
    void Start() {
        stage = 0;
        currentWaypoint = Waypoints.points[stage];
        health = maxHealth;
        hpBar = new HealthBar(health, maxHealth);
    }
    private void Update() {
        Kill();
        MoveToWaypoint();
        hpBar.Draw(health, maxHealth);
    }

    /// Damages this.
    public void Damage(int damage) {
        if (damage > 100|| damage < 0) return;
        health -= damage;
    }

    /// Kills this + Gives a reward for that.
    void Kill() {
        if (health > 0) return;
        hpBar = null;
        Player.Money += reward;
        Destroy(gameObject);
    }

    /// Sets next waypoint to go;
    private void NextWaypoint() {
        if (stage >= Waypoints.amount) {
            Player.Lives--;
            Destroy(gameObject);
            return;
        }
        stage++;
        currentWaypoint = Waypoints.points[stage];
    }

    /// Moves this towards a current waypoint
    private void MoveToWaypoint() {
        var direction = currentWaypoint.position - transform.position;
        transform.Translate(direction.normalized * (speed * Time.deltaTime), Space.World);
        
        if (Vector3.Distance(transform.position, currentWaypoint.position) <= 0.4f) {
            NextWaypoint();
        }
    }
}


/**
 * This class represents a health bar of an enemy
 */
internal class HealthBar {
    private Image texture;
    public HealthBar(int health, int maxHealth) {
        Draw(health, maxHealth);
    }
    public Image Draw(int health, int maxHealth) {
        texture.fillAmount = (float) health / maxHealth;
        return texture;
    }
}