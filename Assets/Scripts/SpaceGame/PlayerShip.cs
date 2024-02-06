using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : Interactable {
    [SerializeField] Action action;
    [SerializeField] Inventory inventory;

	public float health = 100;

	void Start () {
        if (action != null) {
			action.onEnter += OnInteractStart;
			action.onEnter += OnInteractActive;
        }
    }

    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            inventory.use();
        }

        if (Input.GetButtonUp("Fire1")) { 
            inventory.stopUse();
        }
    }

	public override void OnInteractActive(GameObject gameObject) {
		
	}

	public override void OnInteractEnd(GameObject gameObject) {
		
	}

	public override void OnInteractStart(GameObject gameObject) {
		
	}
}
