using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
	[SerializeField] public Item[] items; //was not public
	public Item currentItem { get; set; } //set was private
	void Start () {
		currentItem = items[0];
		currentItem.Equip();
	}

	public void use() {
		currentItem?.Use();
	}

	public void stopUse() { 
		currentItem?.StopUse();
	}
}