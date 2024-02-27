using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// CollisionAction - Map collision events to actions.
/// </summary>
public class CollisionAction : Action {
	[SerializeField] private string tagName;

	#region COLLISION EVENTS
	public void OnTriggerEnter(Collider other) {
		if (tagName == string.Empty || other.CompareTag(tagName)) {
			onEnter?.Invoke(other.gameObject);
			print("hit " + other.name);
		}
	}

	public void OnTriggerStay(Collider other) {
		if (tagName == string.Empty || other.CompareTag(tagName)) {
			onStay?.Invoke(other.gameObject);
			print("hit " + other.name);
		}
	}

	public void OnTriggerExit(Collider other) {
		if (tagName == string.Empty || other.CompareTag(tagName)) {
			onExit?.Invoke(other.gameObject);
			print("hit " + other.name);
		}
	}

	public void OnCollisionEnter(Collision collision) {
		if (tagName == string.Empty || collision.gameObject.CompareTag(tagName)) {
			onEnter?.Invoke(collision.gameObject);
			print("collided with " + collision.gameObject.name);
		}
	}

	public void OnCollisionStay(Collision collision) {
		if (tagName == string.Empty || collision.gameObject.CompareTag(tagName)) {
			onStay?.Invoke(collision.gameObject);
			print("collided with " + collision.gameObject.name);
		}
	}

	public void OnCollisionExit(Collision collision) {
		if (tagName == string.Empty || collision.gameObject.CompareTag(tagName)) {
			onExit?.Invoke(collision.gameObject);
			print("collided with " + collision.gameObject.name);
		}
	}
	#endregion
}