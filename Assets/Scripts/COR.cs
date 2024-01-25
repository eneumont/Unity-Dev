using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COR : MonoBehaviour {
    [SerializeField] float time = 3;
    [SerializeField] bool go = false;
    Coroutine timerCoroutine;
    void Start() {
        //StartCoroutine(Timer(time));
        timerCoroutine = StartCoroutine(Timer(time));
        StartCoroutine("Storytime");
        StartCoroutine(waitAction());
    }

    void Update() {
		//time -= Time.deltaTime;
		//if (time <= 0) {
		//	time = 3;
		//	print("hello");
		//}
	}

    IEnumerator Timer(float time) {
        while (true) {
            yield return new WaitForSeconds(time);
            print("tick");
        }
        //yield return null;
    }

    IEnumerator Storytime() {
        print("hello");
		yield return new WaitForSeconds(1);
        print("hi");
		yield return new WaitForSeconds(1);
        print("time to die");
        StopCoroutine(timerCoroutine);
		yield return null;
    }

    IEnumerator waitAction() {
        yield return new WaitUntil(() => go);
        print("go");
        yield return null;
    }
}
