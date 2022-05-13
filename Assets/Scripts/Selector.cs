using UnityEngine;

public class Selector : MonoBehaviour{
    
    /* Serialized Fields */
    [SerializeField] private Transform prefab;
    /* Public Variables */
    
    
    /* Private Variables */
    private int _selected;
    private Ally[] _inventory;
    
    /** Unity Events **/
    private void Start() {
        _selected = 0;
    }

    private void Update() {
        switch (Input.mouseScrollDelta.y) {
            case <0:
                if (_selected > 0) _selected--;
                break;
            case >0:
                if (_selected < _inventory.Length - 1) _selected++;
                break;
        }
    }

    /** Public Methods **/

    private void PP() {
    }

    /** Private Methods **/

    private void PPM() {
        
    }
}