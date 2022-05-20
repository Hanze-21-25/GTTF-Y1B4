using UnityEngine;
public class Waypoint : MonoBehaviour{

    [SerializeField] private float radius;

    private SphereCollider body;
    private void Start() {
        if (GetComponent<SphereCollider>() == null) body = gameObject.AddComponent<SphereCollider>();
        body.radius = radius; body.isTrigger = true;
    }
}