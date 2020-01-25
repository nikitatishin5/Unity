using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltScript : MonoBehaviour {
    public float desTime = 3f;

    void Start() {
        Invoke("Destruct", desTime);
    }

    private void Destruct() {
        Destroy(gameObject);
    }
}
