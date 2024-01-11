using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    [Header("Movement")]
    [SerializeField][Range(1, 20)][Tooltip("Force to move object")]  float force;

    [SerializeField] Rigidbody rb;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            rb.AddForce(transform.up * force, ForceMode.VelocityChange);
        }    
    }
}
