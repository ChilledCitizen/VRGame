using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour {

	// Use this for initialization
	public GameObject[] flammableItems;
	public float timeTilLose, timeTilWin;
	private bool win, lose, called;
	public Image winI, loseI;
	float tmpWin, tmpLose;

	void Start () {
		
		flammableItems = GameObject.FindGameObjectsWithTag("Flammable");
		tmpLose = timeTilLose;
		tmpWin = timeTilWin;
		called = false;
	}
	
	// Update is called once per frame
	void Update () {

		if(!called)
		{
			CheckWin();
		}
		

		if(win)
		{
			timeTilWin -= Time.deltaTime;
			if(timeTilWin <= 0)
			{
				//winI.gameObject.SetActive(true);
				foreach (var item in flammableItems)
				{
					item.SetActive(false);
				}
			}		
		}
		else if(lose)
		{
			//timeTilLose -= Time.deltaTime;
			if(timeTilLose <= 0)
			{
				loseI.gameObject.SetActive(true);
				foreach (var item in flammableItems)
				{
					item.SetActive(false);
				}
			}	
		}

		
		
	}

	private void CheckWin()
	{
		called = true;
		for (int i = 0; i < flammableItems.Length; i++)
		{
			if(flammableItems[i].GetComponent<ButtonThingy>().possibleToWin == false)
			{
				win = false;
				timeTilWin = tmpWin;
				
			}
			// else if(flammableItems[i].GetComponent<ButtonThingy>().onFire == false)
			// {
			// 	lose = false;
			// 	win = true;
			// }			
			else
			{
				// timeTilWin = tmpWin;
				// timeTilLose  = tmpLose;
				win = true;
				
			}
		}
		called = false;
	}
}
