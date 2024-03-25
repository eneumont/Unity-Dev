using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoints : MonoBehaviour {
    [SerializeField] public Vector3[] points;
    [SerializeField] public int point = 0;
	[SerializeField] Transform respawnTransform;

	public void newRespawn() {
		respawnTransform.position = points[point];
	}
}