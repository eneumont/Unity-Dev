using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour {
    [SerializeField] Inventory inventory;
    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            inventory.use();
        }

        if (Input.GetButtonUp("Fire1")) { 
            inventory.stopUse();
        }
    }
}
