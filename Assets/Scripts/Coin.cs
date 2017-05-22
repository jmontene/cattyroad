using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		Debug.Log("Entered");
		if(other.tag == "Player"){
			GameController.Instance.AddCoin();
			Destroy(this.gameObject);
		}
	}
}
