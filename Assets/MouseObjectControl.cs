using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseObjectControl : MonoBehaviour
{

    private Vector3 mOffset { get; set; }
    private float mZCoord { get; set; }
    private HingeJoint joint { get; set; }

    private void Start()
    {
        gameObject.AddComponent<Rigidbody>();
    }

    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
        joint = gameObject.AddComponent<HingeJoint>();
        joint.axis = new Vector3(1,1,1);
    }

    void OnMouseUp()
    {
        foreach (var item in gameObject.GetComponents<HingeJoint>())
        {
            Destroy(item);
        }
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseAsWorldPoint() + mOffset;
        joint.anchor = gameObject.transform.position;
    }

    private Vector3 GetMouseAsWorldPoint()

    {

        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen
        mousePoint.z = mZCoord;

        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
