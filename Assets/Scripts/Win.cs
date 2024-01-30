using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour {
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.TryGetComponent(out Player player)) player.winGame(); 	
	}
}