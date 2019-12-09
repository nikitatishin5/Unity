using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    public Bullet bulletPrefab;
    public LayerMask mask;

    void shoot(RaycastHit hit){
      // 1
      var bullet = Instantiate(bulletPrefab).
                            GetComponent<Bullet>();
      // 2
      var pointAboveFloor = hit.point
                            + new Vector3(0,
                                          this.transform.position.y,
                                          0);

      // 3
      var direction = pointAboveFloor - transform.position;

      // 4
      var shootRay = new Ray(this.transform.position, direction);
      Debug.DrawRay(shootRay.origin,
                    shootRay.direction * 100.1f,
                    Color.green,
                    2);

      // 5
      Physics.IgnoreCollision(GetComponent<Collider>(),
                                bullet.GetComponent<Collider>());

      // 6
      bullet.FireBullet(shootRay);
    }

    // 1
    void raycastOnMouseClick () {
      RaycastHit hit;
      Ray rayToFloor = Camera.main.ScreenPointToRay(Input.mousePosition);
      Debug.DrawRay(rayToFloor.origin,
                    rayToFloor.direction * 100.1f,
                    Color.red,
                    2);

      if(Physics.Raycast(rayToFloor,
                         out hit,
                         100.0f,
                         mask,
                         QueryTriggerInteraction.Collide)) {
        shoot(hit);
      }
    }

    // 2
    void Update () {
      bool mouseButtonDown = Input.GetMouseButtonDown(0);
      if(mouseButtonDown) {
        Debug.Log("Shoot!");
        raycastOnMouseClick();  
      }
    }

	// Use this for initialization
	void Start () {
		
	}
}
