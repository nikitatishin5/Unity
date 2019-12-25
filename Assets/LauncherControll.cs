using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherControll : MonoBehaviour
{

    public GameObject enemy;
    public float launch_time;

    public void launch()
    {
        GameObject nev = Instantiate(enemy, transform.position, transform.rotation);
        nev.GetComponent<Rigidbody>().AddForce(gameObject.transform.up * 200000);
    }
    // Start is called before the first frame update
    void Start()
    {
        launch_time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(launch_time < Time.time)
        {
            launch_time = Time.time + 10f;
            launch();
        }
    }
}
