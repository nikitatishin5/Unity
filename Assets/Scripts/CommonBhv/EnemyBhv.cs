using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBhv : MonoBehaviour {
	public float fireDelay = 5;
	private float nextFire;
    public float shootForce = 300f;

    // wiring
    public GameObject bullet;
    // wiring
	public Transform gunPoint;

    void Start()
    {
        
    }

    void Update() {
        // TODO: refactor
        GameObject player = GameObject.Find("HeadCam");
        transform.LookAt(player.transform);
        

		if (Time.time > nextFire) {
			nextFire = Time.time + fireDelay;

            GameObject blt = Instantiate(bullet,
                                         gunPoint.position,
                                         transform.rotation);

            blt.GetComponent<Rigidbody>().AddForce(blt.transform.forward
                                                   * shootForce);
        }
    }
}
