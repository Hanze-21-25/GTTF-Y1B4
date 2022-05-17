using System;
using System.Collections;
using UnityEngine;

public class Spawn : MonoBehaviour{
    private IEnumerator Launch(int wave , Transform prefabToSpawn) {
        for (var index = 0;index < (int) Math.Pow(2,wave); index++) {
            yield return new WaitForSeconds(1);
            Instantiate(prefabToSpawn, transform.position, transform.rotation).GetComponent<Enemy>(); // Spawn
        }
    }
}