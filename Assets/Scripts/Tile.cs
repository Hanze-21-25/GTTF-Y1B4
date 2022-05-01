using UnityEngine;

public class Tile : MonoBehaviour
{
    void Start()
    {
        Debug.Log(name + "/" + gameObject.GetInstanceID() + " Created.");
    }
}
