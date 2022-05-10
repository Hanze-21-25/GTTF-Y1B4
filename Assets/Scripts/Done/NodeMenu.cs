using UnityEngine;
using UnityEngine.UI;

/**
 * This class represents a context menu, which parent MUST be a node.
 */
public class NodeMenu : MonoBehaviour{
    
    public GameObject ui;
    public Button upgradeButton;
    private Node _host;

    /// Initialisation
    private void Start() {
        _host = transform.parent.GetComponent<Node>();
        transform.position = _host.transform.position + _host.turret.positionOffset;
        _host.contextMenu = this;
    }

    /// Upgrade Button
    public void Upgrade() {
        _host.turret.Upgrade();
        _host.Deselect(ref _host);
    }

    /// Sell Button
    public void Sell() {
        _host.turret.Sell();
        _host.Deselect(ref _host);
    }
}