using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disco : MonoBehaviour {
    public Light discolight;
 
    void Start() {
        
    }

    void Update() {
        discolight.color = Random.ColorHSV();
    }
}
