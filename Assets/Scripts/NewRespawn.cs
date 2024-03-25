using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewRespawn : MonoBehaviour {
    [SerializeField] int point;
	[SerializeField] RespawnPoints points;

	private void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.TryGetComponent(out Player player)) {
			points.point = point;
			points.newRespawn();
		}
	}
}
