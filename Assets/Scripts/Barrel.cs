using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour {
    [SerializeField] Animator animator;

	void OnTriggerEnter(Collider other) {
		animator.SetTrigger("Start");
	}
}
