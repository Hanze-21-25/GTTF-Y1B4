using UnityEngine;
using UnityEngine.Serialization;

public class Shop : MonoBehaviour {
    [Header("Prefabs")] public Turret crab;
    public Turret seaTurtle;
    public Turret squid;
    public Turret seal;
    public Turret seagull;

    Game _game;

    void Start() {
        _game = Game.instance;
    }

    /// Selection of a turret
    public void SelectCrabTurret() {
        Debug.Log("Crab Selected");
        _game.SelectTurret(crab);
    }

    public void SelectSeaTurtleTurret() {
        Debug.Log("Seaturtle Selected");
        _game.SelectTurret(seaTurtle);
    }

    public void SelectSquidTurret() {
        Debug.Log("Squid Selected");
        _game.SelectTurret(squid);
    }

    public void SelectSealTurret() {
        Debug.Log("Seal Selected");
        _game.SelectTurret(seal);
    }

    public void SelectSeagullTower() {
        Debug.Log("Seagull Tower Selected");
        _game.SelectTurret(seagull);
    }
}