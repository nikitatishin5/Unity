using UnityEngine;
using System.Collections;

public class HealthScript: MonoBehaviour {

	public int currentHealth = 3;

    void OnCollisionEnter(Collision col) {
        Debug.Log("Damaged!");
        getDamage(1);
    }

	public void getDamage(int damageAmount) {
		currentHealth -= damageAmount;

		if (currentHealth <= 0) {
            // TODO: refactor
            GameObject es = GameObject.Find("EnemySpawner");
            es.GetComponent<EnemySpawnScript>().spawnEnemy(2);
			Destroy(gameObject);
		}
	}
}

