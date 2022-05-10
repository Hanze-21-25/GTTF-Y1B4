using UnityEngine;

public class Waypoints : MonoBehaviour {
    public static Transform[] Points { get; private set; }
    public static int Amount { get; private set; }

    private void Awake() {
        Points = new Transform[transform.childCount];
        for (var i = 0; i < Points.Length; i++) {
            Points[i] = transform.GetChild(i);
        }
        Amount = Points.Length;
    }
}