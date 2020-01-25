using UnityEngine;
using System.Collections;

public class ShootScript : MonoBehaviour {

	public float fireDelay = 0.25f;
	private float nextFire;

    public float shootRange = 50f;
    public float shootForce = 300f;

	private Camera playerCam;												

    // wiring
	public Transform gunPoint;
    // wiring
    public GameObject bullet;

	private AudioSource shotSound;										

	void Start() {
        shootRange = 50f;
		playerCam = GetComponentInParent<Camera>();
		shotSound = GetComponent<AudioSource>();
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > nextFire) {
			nextFire = Time.time + fireDelay;

            shotSound.Play();

            Vector3 rayOrigin =
                playerCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

            Vector3 toPoint;

            RaycastHit hit;
            if (Physics.Raycast(rayOrigin, playerCam.transform.forward,
                                out hit, shootRange))
                toPoint = hit.point;
            else
                toPoint = rayOrigin + (playerCam.transform.forward
                                       * shootRange);

            Shoot(gunPoint.position, toPoint);
		}
	}

    void Shoot(Vector3 fromPoint, Vector3 toPoint) {
        // Debug.Log(fromPoint + " " + toPoint);
        Vector3 shootDir = new Vector3(toPoint.x - fromPoint.x,
                                      toPoint.y - fromPoint.y,
                                      toPoint.z - fromPoint.z);
        Quaternion rotation = Quaternion.LookRotation(shootDir);
        GameObject blt = Instantiate(bullet,
                                     gunPoint.position,
                                     rotation);
        // TODO: move to bullet constructor?
        // save full ray
        ShootRayStorage.SaveRay(fromPoint, shootDir, shootRange);
        BulletScript bs = blt.GetComponent<BulletScript>();
        bs.DrawRay(fromPoint, toPoint);

        blt.GetComponent<Rigidbody>().AddForce(blt.transform.forward
                                               * shootForce);
    }
}

