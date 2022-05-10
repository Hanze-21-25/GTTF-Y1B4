using UnityEngine;

public class CarAnimationController : MonoBehaviour
{
    void Update()
    {
        if (Wave.Enemies.Length < 1)
        {
            GetComponent<Animator>().Play("Car Movement");
        } else
        {
            GetComponent<Animator>().Play("New State");
        }
    }
}
