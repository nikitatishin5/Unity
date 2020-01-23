using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {
	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("SnakeMain"))
		{
			other.GetComponent<SnakeMovment>().AddTail();
			Destroy(gameObject);
		}
	}

}
