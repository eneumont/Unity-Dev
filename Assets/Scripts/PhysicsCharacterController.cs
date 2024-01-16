using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PhysicCharacterController : MonoBehaviour {
    [Header("Movement")]
    [SerializeField][Range(1, 10)] float maxForce;
    [SerializeField][Range(1, 10)] float jumpForce;
    [SerializeField] Transform view;
    [Header("Collision")]
    [SerializeField][Range(0, 5)] float raylength = 1;
    [SerializeField] LayerMask groundLayerMask;

    Rigidbody rb;
    Vector3 force = Vector3.zero;
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        Vector3 direction = Vector3.zero;
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        Quaternion yrotation = Quaternion.AngleAxis(view.rotation.eulerAngles.y, Vector3.up);
        force = yrotation * direction * maxForce;

        Debug.DrawRay(transform.position, Vector3.down * raylength, Color.red);
        if (Input.GetButtonDown("Jump") && CheckGround()) { 
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void FixedUpdate() {
        rb.AddForce(force, ForceMode.Force);
    }

    bool CheckGround() {
        return Physics.Raycast(transform.position, Vector3.down, raylength, groundLayerMask);
    }
}