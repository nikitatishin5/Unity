using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAroundScript : MonoBehaviour {

    public float mouseSensitivity = 150f;

    private Transform playerBody;
    private float rotation = 0f;

    void Start() {
        playerBody = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {
        float mouseX = Input.GetAxis("Mouse X")
                       * mouseSensitivity
                       * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y")
                       * mouseSensitivity
                       * Time.deltaTime;
        
        // Look vertically
        playerBody.Rotate(Vector3.up * mouseX);
        
        // Look horizontally
        rotation -= mouseY;
        rotation = Mathf.Clamp(rotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(rotation, 0f, 0f);
    }
}
