using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
	[SerializeField] Item[] items;
	public Item currentItem { get; private set; }
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