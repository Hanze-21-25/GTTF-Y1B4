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

    void Start() {
        stage = 0;
        currentWaypoint = Waypoints.points[stage];
        health = maxHealth;
        hpBar = new HealthBar(health, maxHealth);
    }

    /// Damages this.
    public void Damage(int damage) {
        if (damage > 100|| damage < 0) return;
        health -= damage;
    }

    /// Kills this.
    void Kill() {
        if (health > 0) return;
        PlayerStats.Money += reward;
        Destroy(gameObject);
        WaveEvents.EnemiesAlive--;
    }

    ///
    private void Update() {
        Kill();
        hpBar.Draw(health, maxHealth);
        
        var dir = currentWaypoint.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, currentWaypoint.position) <= 0.4f) {
            NextWaypoint();
        }
    }

    /// 
    private void NextWaypoint() {
        if (stage >= Waypoints.points.Length) {
            PlayerStats.Lives--;
            WaveEvents.EnemiesAlive--;
            Destroy(gameObject);
            return;
        }
        stage++;
        currentWaypoint = Waypoints.points[stage];
    }
}

internal class HealthBar{
    public Image texture { get; private set; }

    public HealthBar(int health, int maxHealth) {
        Draw(health, maxHealth);
    }

    public void Draw(int health, int maxHealth) {
        texture.fillAmount = health / maxHealth;
    }
}