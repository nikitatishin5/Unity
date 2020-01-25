using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    // public float speed = 5f;
    public float desTime = 3f;

    void Start() {
        Invoke("Destruct", desTime);
    }

    void Update() {
        // transform.position += transform.forward
        //                       * speed
        //                       * Time.deltaTime;
    }

    public void DrawRay(Vector3 fromPoint, Vector3 toPoint) {
        LineRenderer laserLine = GetComponent<LineRenderer>();
		laserLine.SetPosition(0, fromPoint);
		laserLine.SetPosition(1, toPoint);
        laserLine.enabled = true;
        // Debug.Log("Ray drawn!");
    }

    // void OnTriggerEnter(Collider other) {
        // CancelInvoke();
        // Debug.Log("hit!");
        // Destruct();
    // }

    private void Destruct() {
        // assuming that each bullet has
        // same destruct time
        ShootRayStorage.PopRay();
        Destroy(gameObject);
    }
}
