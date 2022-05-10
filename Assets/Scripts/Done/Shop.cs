using System;
using UnityEngine;

public class Shop : MonoBehaviour {

    private int _selection;
    private Turret[] _contents;
    private Game _game;
    public Turret selected;

    /** Unity Events*/
    private void Start() {
        _game = Game.Instance;
        _selection = 0;
        _contents = new Turret[5];
    }

    private void FillContents() {
        throw new NotImplementedException();
    }


    private void Update() {
        Scroll();
    }

    /// Changes selection on scroll
    private void Scroll() {
        switch (Input.mouseScrollDelta.y) {
            case > 0:
                _selection++;
                break;
            case < 0:
                _selection--;
                break;
        }
        if (_selection < 0) {
            _selection = 0;
        } else if (_selection > _contents.Length - 1) {
            _selection = _contents.Length - 1;
        }
        selected = _contents[_selection];
    }

    
    
    /** Methods */
    
    /// Selects from a shop
    public Turret Select(int index) {
        _selection = index;
        return _contents[index];
    }
}