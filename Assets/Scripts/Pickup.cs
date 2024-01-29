using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {
    [SerializeField] GameObject pickupPrefab = null;
    [SerializeField] string pickupType = null;

    void OnCollisionEnter(Collision collision) {
        print(collision.gameObject.name);    
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.TryGetComponent(out Player player)) {
            switch (pickupType) {
                case "coin":
					player.AddPoints(10);
					break;
                case "health":
                    player.Healing(33);
                    break;
                case "time":
                    player.moreTime(10);
                    break;
            }
            
        }
        
        Instantiate(pickupPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}