using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour {

    // wiring
    public GameObject enemy;

    public void spawnEnemy(int count) {
        float d = 10;

        while (count > 0) {
            Vector3 offset = new Vector3(Random.Range(-d, d),
                                         0,
                                         Random.Range(-d, d));
            Instantiate(enemy,
                        gameObject.transform.position + offset,
                        Quaternion.identity);
            count--;
        }
    }
}

