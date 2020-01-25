using UnityEngine;
using System.Collections;

public class LookRayDebugScript : MonoBehaviour {

    private float lookRange = 100f;
    private Camera fpsCam;                                

	void Start () {
        fpsCam = GetComponentInParent<Camera>();
	}
	
	void Update () {
        Vector3 lineOrigin = fpsCam.ViewportToWorldPoint(
                                        new Vector3(0.5f, 0.5f, 0.0f));

        Debug.DrawRay(lineOrigin,
                      fpsCam.transform.forward * lookRange,
                      Color.red);
    }
}
