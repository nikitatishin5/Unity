using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_control : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
// gameObject.transform.Rotate(0, 10, 0);
        //gameObject.transform.Rotate(0, Input.GetAxis("Mouse X") * 5, 0);
        float rotationY = Input.GetAxis("Mouse Y") * 10F;
        if (((Mathf.Abs(Vector3.Angle(transform.forward, transform.forward) - rotationY) < 50) && (Vector3.Angle(transform.forward, transform.up) > 90)) || ((Mathf.Abs(Vector3.Angle(transform.forward, transform.forward) + rotationY) < 70) && (Vector3.Angle(transform.forward, transform.up) <= 90)))
            transform.Rotate(new Vector3(-rotationY, 0, 0));
    }
}
