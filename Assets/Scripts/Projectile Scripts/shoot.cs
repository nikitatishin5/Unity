using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{

    public GameObject projectile;

    public bool test;
    public float times;
    // Start is called before the first frame update
    void Start()
    {
        times = 0;
    }

    public void shootProj()
    {
        Instantiate(projectile, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (test)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                shootProj();
            }
        }
        else
        {
            if (Time.time > times)
            {
                shootProj();
                times = Time.time + 5f;
            }
        }
    }
}
