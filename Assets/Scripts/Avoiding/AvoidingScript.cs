using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// FIXME: problem with platform collapsing
public class AvoidingScript : MonoBehaviour {

    public float speed = 5f;
    public float lookRange = 50f;
    private Vector3 newPos;

    public Camera playerCam;                                

    void Start() {
        newPos = transform.position;
    }

    void Update() {
        // avoid only if not moving
        // and on the shoot ray or look ray
        if (transform.position == newPos
            && (
                // IsOnTheLookRay()
                IsOnTheShootRay()
            ))
            ChooseNewPosition();

        transform.position = Vector3.MoveTowards(transform.position,
                                                 newPos,
                                                 speed * Time.deltaTime);
    }

    private bool IsOnTheLookRay() {
        // Debug.Log("Checking look ray...");
        Vector3 rayOrigin = playerCam.ViewportToWorldPoint(
                                           new Vector3(0.5f, 0.5f, 0.0f));
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, playerCam.transform.forward,
                            out hit, lookRange))
            // TODO: refactor?
            if (hit.collider.GetComponent<AvoidingScript>() != null)
                return true;
        return false;
    }

    private bool IsOnTheShootRay() {
        // Debug.Log("Checking shoot rays...");
        RaycastHit hit;
        // for not to casting to bullet
        // FIXME: all enemies avoides even only one on the ray
        int layerMask = 1 << 9;
        foreach (ShootRay shootRay in ShootRayStorage.shootRays)
            if (Physics.Raycast(shootRay.origin, shootRay.dir,
                                out hit, shootRay.range, layerMask))
                // TODO: refactor?
                if (hit.collider.GetComponent<AvoidingScript>() != null)
                    return true;
        return false;
    }

    private void ChooseNewPosition() {
        Debug.Log("Choosing new position...");
        Vector3 dir = new Vector3(Random.Range(-2f, 2f),
                                  Random.Range(-2f, 2f),
                                  Random.Range(-2f, 2f));
        newPos = transform.position + dir;
    }
}

