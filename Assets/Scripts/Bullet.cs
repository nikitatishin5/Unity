using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 0.5f;
    public int damage = 1;

    Vector3 shootDirection;

    // 1
    void FixedUpdate () {
      this.transform.Translate(shootDirection * speed,
                               Space.World);
    }

    void rotateInShootDirection() {
      Vector3 newRotation = Vector3.RotateTowards(transform.forward,
                                                  shootDirection,
                                                  0.01f, 0.0f);
      transform.rotation = Quaternion.LookRotation(newRotation);
    }

    // 2
    public void FireBullet(Ray shootRay) {
      this.shootDirection = shootRay.direction;
      this.transform.position = shootRay.origin;
      rotateInShootDirection();
    }

    // 3
    void OnCollisionEnter (Collision col) {
      Enemy enemy = col.collider.gameObject.GetComponent<Enemy>();
      if(enemy) {
        enemy.TakeDamage(damage);
      }
      Destroy(this.gameObject);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
