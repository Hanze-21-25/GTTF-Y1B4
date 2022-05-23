using System;
using UnityEngine;


public class UserInterface : MonoBehaviour{
    /* Public Variables */
    public Transform selected { get; private set; } // contains prefabs, which can be bought

    /* Private Variables */
    private int _index;

    private int index {
        get => _index;
        set {
            if (_index >= _inventory.Length - 1) value = _inventory.Length - 2;
            else if (index < _inventory.Length - 1) value = 0;
            // set selection
            selected = _inventory[value];
            _index = value;
        }
    }

    private readonly Transform[] _inventory = GetAvailableAllyPrefabs(); // contains prefabs, which can be bought


    /** Unity Events **/
    private void Start() {
        if(FindObjectOfType<UserInterface>() != null) Destroy(gameObject);
        index = 0;
    }

    private void Update() {
        UpdateInputs();
    }


    /** Private Methods **/
    private void UpdateInputs() {
        // Updates mouse
        var scroll = Input.GetAxis("Mouse ScrollWheel");
        // Selection
        switch (scroll) { case > 0: index++; break; case < 0: index--; break; }
    }
    // Updates UI
    private void UpdateInterface() {
        throw new NotImplementedException();
    }
    
    private static Transform[] GetAvailableAllyPrefabs() {
        var goArr = Resources.LoadAll ("Assets/Resources/Visual/Prefabs/Allies") as GameObject[];
        var res = new Transform[goArr.Length];
        var index = 0;
        foreach (var go in goArr) {
            res[index] = go.transform;
            index++;
        }
        return res;
    }
}