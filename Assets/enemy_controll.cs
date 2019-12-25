using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_controll : MonoBehaviour
{

    public int Hp;
    public float DestroyTime, SpawnTime;
    // Start is called before the first frame update
    void Start()
    {
        SpawnTime = Time.time;

        Hp = 100;
    }

    void OnCollisionEnter(Collision collision)
    {
        Hp -= 34;

        if (Hp == -2)
        {
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            DestroyTime = Time.time + 5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SpawnTime + 60 * Time.deltaTime < Time.time)
        {

            gameObject.GetComponent<Rigidbody>().Sleep();
            gameObject.GetComponent<Rigidbody>().WakeUp();
        }
        GameObject player = GameObject.Find("Player");
        transform.LookAt(player.transform);

        if (Hp <= 0)
        {
            if(DestroyTime < Time.time)
            {
                Destroy(gameObject);
            }

        }
        else
        {

            if ((gameObject.transform.position - player.transform.position).magnitude > 20)
            {
                gameObject.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward);
            }
        }
    }
}
