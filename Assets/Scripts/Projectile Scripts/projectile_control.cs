using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile_control : MonoBehaviour
{

    public float speed, lifetime;
    public GameObject sparkles;
    
    private float finishTime;
    private bool canSpawn;
    // Start is called before the first frame update
    void Start()
    {
        speed = 10;
        lifetime = 3;
        finishTime = Time.time + lifetime;
        canSpawn = false;

        gameObject.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * 2000);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += transform.forward * speed * Time.deltaTime;
        if(Time.time > finishTime)
        {
            canSpawn = true;
            Destroy(gameObject);
        }

// Debug.Log(transform.forward);
// Debug.Log(transform.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        canSpawn = true;
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        if(canSpawn)
            Instantiate(sparkles, transform.position, transform.rotation);
    }
}
