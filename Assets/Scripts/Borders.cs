using UnityEngine;
using System.Collections;

public class Borders : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		
		if(other.CompareTag("SnakeMain"))
		{
				Application.LoadLevel(Application.loadedLevel);
		}

	}
}
