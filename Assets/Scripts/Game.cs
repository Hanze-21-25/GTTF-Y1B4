using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour{
    /* Serialised Fields */
    [SerializeField] private int waves;
    [SerializeField] private int lives;
    [SerializeField] public int money;
    
    /* Public Variable */
    public bool GoalIsReached;
    public int _wave { get; private set; }
    public Enemy[] Enemies { get; set; }

    /* Private Variables */

    private Spawn _spawn;

    /** Unity Events **/
    
    // Initialise
    private void Start() {
        _wave = 1;
    }
    
    private void Update() {
        _spawn = FindObjectOfType<Spawn>(); // Finds spawn and if it couldn't finds enemies
        if(_spawn == null) Enemies = FindObjectsOfType<Enemy>();
        CheckResult(); // Checks whether player won or lost
    }

    /** Private Methods **/
    private void CheckResult() {
        if (Enemies.Length <= 0) _wave++;
        if(lives <= 0) SceneManager.LoadScene("Defeat");
        if (_wave > waves) SceneManager.LoadScene("Victory");
    }
}