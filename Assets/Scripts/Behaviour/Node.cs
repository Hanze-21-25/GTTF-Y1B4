using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Object = UnityEngine.Object;

/**
 * This class represents all tiles, to which players can place allies;
 */
public class Node : MonoBehaviour {

	private Renderer rend;
	[SerializeField] private Color def;
	[SerializeField] private Color unavailable;
	[SerializeField] private Color available;

	void Start()
	{
		rend = GetComponent<Renderer>();
		def = rend.material.color;

	}

	/**
	 * On this pressed - Build() method invoked
	 */
	void OnMouseDown()
	{
		//Build();
	}
	
	private void OnMouseEnter() {
		OnHover();
	}
	private void OnMouseExit()
	{
		ChangeColour(def);
	}

	/**
	 * Builds an object, which is passed by an argument on top of this object.
	 */
	private void Build (Object obj)
    {
    }

	/**
	 * Upgrades an object above itself. 
	 */
	private void Upgrade()
    {
    }

	/**
	 * Sells an object above itself.
	 */
	private void Sell() {
		
	}


	private void OnHover() {
		//Available colour on hover
		if (IsEnoughMoney()) {
			ChangeColour(available);
			return;
		}
		//Unavailable colour on hover if not enough money
		ChangeColour(unavailable);
	}
	private void ChangeColour(Color colour) {
		rend.material.color = colour;
	}
	
	/**
	 * Checks whether player has enough money.
	 */
	private bool IsEnoughMoney() {
		throw new NotImplementedException();
	}
}