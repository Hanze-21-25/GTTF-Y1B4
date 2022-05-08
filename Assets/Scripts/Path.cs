using UnityEngine;
/**
 * All waypoints must be under a "Path" object, which inherits this class.
 */
public class Path : MonoBehaviour
{
	private static Transform[] points;
	private void Start() {
		Initialise();
	}
	//Initialises necessary settings
	private void Initialise() {
		points = new Transform[transform.childCount];
		Build();
	}
	
	//Builds a path
	private void Build() {
		for (int i = 0; i < points.Length; i++)
		{
			points[i] = transform.GetChild(i);
		}
	}

	public Transform GetPoint(int index) {
		return points[index];
	}
}