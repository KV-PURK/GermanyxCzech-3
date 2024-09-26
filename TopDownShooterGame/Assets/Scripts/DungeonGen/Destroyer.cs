using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class Destroyer : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		Destroy(other.gameObject);
		
		
	}


}
