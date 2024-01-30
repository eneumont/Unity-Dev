using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour {
	private void OnTriggerEnter(Collider other)	{
		if (other.gameObject.TryGetComponent<IInteractable>(out IInteractable interactable)) {
			interactable.onEnter();
		}
	}

	private void OnTriggerExit(Collider other) {
		if (other.gameObject.TryGetComponent<IInteractable>(out IInteractable interactable)) {
			interactable.onExit();
		}
	}
}
