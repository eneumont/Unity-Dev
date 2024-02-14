using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using Unity.Mathematics;

public class PathFollower : MonoBehaviour {
    [SerializeField] SplineContainer splineContainer;
    [Range(0, 40)] public float speed = 1;
	[Range(0, 1)] public float tdistance = 0; // distance along spline (0 - 1)

    public float length { get { return splineContainer.CalculateLength(); } }
    public float distance {
        get { return tdistance * length; }
        set { tdistance = value / length; }
    }

	void Start() {
        
	}

	void Update() {
        distance += (speed * 5) * Time.deltaTime;
        updateTransform(math.frac(tdistance));
    }

    void updateTransform(float t) { 
        Vector3 position = splineContainer.EvaluatePosition(t);
        Vector3 up = splineContainer.EvaluateUpVector(t);
        Vector3 forward = Vector3.Normalize(splineContainer.EvaluateTangent(t));
        Vector3 right = Vector3.Cross(up, forward);
        transform.position = position;
        transform.rotation = Quaternion.LookRotation(forward, up);
    }
}