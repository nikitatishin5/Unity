using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: add jumping etc
public class MovementScript : MonoBehaviour {
    
    private CharacterController controller;
    public float speed = 5f;

    void Start() {
        controller = GetComponent<CharacterController>();
    }

    void Update() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x
                       + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
    }
}
