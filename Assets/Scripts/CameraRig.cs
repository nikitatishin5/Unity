using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : MonoBehaviour {

    public float moveSpeed = 8;
    public GameObject target;

    private Transform rigTransform;

	// Use this for initialization
	void Start () {
		rigTransform = this.transform.parent;
	}

    void FixedUpdate () {
      if(target == null) {
        return;
      }

      rigTransform.position = Vector3.Lerp(rigTransform.position,
                                           target.transform.position, 
                                           Time.deltaTime * moveSpeed);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
