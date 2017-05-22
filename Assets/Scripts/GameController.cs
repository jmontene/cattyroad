using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	private static GameController _instance;

	public static GameController Instance { get { return _instance; } }

	private void Awake(){
		if (_instance != null && _instance != this)
		{
			Destroy(this.gameObject);
		} else {
			_instance = this;
		}
	}

	public CatController cat;

	private int coins = 0;


	void Update(){
		if(cat.IsDead()){
			OnDeath();
		}
	}

	public void AddCoin(){
		coins += 1;
	}

	void OnDeath(){
		Debug.Log("Game Ended");
	}

}
