using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour{
    /* Serialised Fields */
    [SerializeField] private int waves;
    [SerializeField] private int lives;
    [SerializeField] public int money;
    
    
    
    /* Public Variable */
    public bool GoalIsReached;
    public int Wave { get; private set; }
    public Enemy[] Enemies { get; private set; }
    public Waypoint[] Waypoints { get; private set; }

    
    /* Private Variables */

    private Spawn _spawn;
    
    
    
    

    /** Unity Events **/
    
    // Initialise
    private void Start() {
        Wave = 0;
        _spawn = FindObjectOfType<Spawn>();
        Waypoints = FindObjectsOfType<Waypoint>();
    }
    
    private void Update() {
        if(_spawn == null) Enemies = FindObjectsOfType<Enemy>();
        CheckResult(); // Checks whether player won or lost
    }

    /** Private Methods **/
    private void CheckResult() {
        if(lives <= 0) SceneManager.LoadScene("Defeat");
        if (Enemies.Length > 0) return;
            Wave++;
        if(lives <= 0) SceneManager.LoadScene("Defeat");
        if (Wave > waves) SceneManager.LoadScene("Victory");
    }
}