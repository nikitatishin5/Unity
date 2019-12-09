using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int health = 3;

    void collidedWithEnemy(Enemy enemy) {
      enemy.Attack(this);
      Debug.Log("Attacked!");

      if(health <= 0) {
        // Todo 
      }
    }

    void OnCollisionEnter(Collision col) {
        Enemy enemy = col.collider.gameObject.GetComponent<Enemy>();
        if (enemy) {
            collidedWithEnemy(enemy);
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
