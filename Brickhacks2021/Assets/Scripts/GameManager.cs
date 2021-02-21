using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	//lists and game objects and shit 
	public GameObject shopper;
	public GameObject item;
	public List<int> surviveList;
	public List<int> happyList;
	public List<GameObject> shoppers;
	public List<GameObject> items;
	public int lives;

	//timers
	float timeDelayItems;
	float timeDelayShoppers;

	//score keeping and sprite changes
	//SPRITES NOT SET PLEASE SET
	public Sprite[] sprites = new Sprite[7];
	int[] scoresSurvive;
	int[] scoreHappy;
	public int surviveScore;
	public int happyScore;

	void Start()
    {
		//sets up scores
		scoreHappy = new int[7];
		scoresSurvive = new int[7];
		for (int i = 0; i < 7; i++)
		{
			scoreHappy[i] = 1000 - (i * 125);
			scoresSurvive[i] = i * 125;
		}
    }

	// Update is called once per frame
	void Update()
	{
		//staggered spawning
        #region
        //keeps track of time 
        timeDelayItems += Time.deltaTime;
		timeDelayShoppers += Time.deltaTime;

		// staggars the spawning of items 
		if (timeDelayItems >= 3)
		{
			//resets time
			timeDelayItems = 0;
			// checks the random to change the item to survivable or happy or both
			int randomInt = Random.Range(0, 7);
			//adds the item to the list 
			items.Add(Instantiate(item));
			//sets the objects attrobutes like sprite and score values 
			switch (randomInt)
			{
				case (0):
					items[items.Count].GetComponent<SpriteRenderer>().sprite = sprites[0];
					items[items.Count].GetComponent<Items>().happyScore = happyList[0];
					items[items.Count].GetComponent<Items>().surviveScore = surviveList[0];
					break;
				case (1):
					items[items.Count].GetComponent<SpriteRenderer>().sprite = sprites[1];
					items[items.Count].GetComponent<Items>().happyScore = happyList[1];
					items[items.Count].GetComponent<Items>().surviveScore = surviveList[1];
					break;
				case (2):
					items[items.Count].GetComponent<SpriteRenderer>().sprite = sprites[2];
					items[items.Count].GetComponent<Items>().happyScore = happyList[2];
					items[items.Count].GetComponent<Items>().surviveScore = surviveList[2];
					break;
				case (3):
					items[items.Count].GetComponent<SpriteRenderer>().sprite = sprites[3];
					items[items.Count].GetComponent<Items>().happyScore = happyList[3];
					items[items.Count].GetComponent<Items>().surviveScore = surviveList[3];
					break;
				case (4):
					items[items.Count].GetComponent<SpriteRenderer>().sprite = sprites[4];
					items[items.Count].GetComponent<Items>().happyScore = happyList[4];
					items[items.Count].GetComponent<Items>().surviveScore = surviveList[4];
					break;
				case (5):
					items[items.Count].GetComponent<SpriteRenderer>().sprite = sprites[5];
					items[items.Count].GetComponent<Items>().happyScore = happyList[5];
					items[items.Count].GetComponent<Items>().surviveScore = surviveList[5];
					break;
				case (6):
					items[items.Count].GetComponent<SpriteRenderer>().sprite = sprites[6];
					items[items.Count].GetComponent<Items>().happyScore = happyList[6];
					items[items.Count].GetComponent<Items>().surviveScore = surviveList[6];
					break;
			}
			//changes the spawning location of the new item
			randomInt = Random.Range(0, 4);
			switch (randomInt)
			{
				case (0):
					items[items.Count].transform.position = new Vector2(Camera.main.orthographicSize * Camera.main.aspect, Camera.main.orthographicSize - item.GetComponent<BoxCollider2D>().size.y);
					break;
				case (1):
					items[items.Count].transform.position = new Vector2(Camera.main.orthographicSize * Camera.main.aspect, item.GetComponent<BoxCollider2D>().size.y);
					break;
				case (2):
					items[items.Count].transform.position = new Vector2(Camera.main.orthographicSize * Camera.main.aspect, -item.GetComponent<BoxCollider2D>().size.y);
					break;
				case (3):
					items[items.Count].transform.position = new Vector2(Camera.main.orthographicSize * Camera.main.aspect, -Camera.main.orthographicSize - item.GetComponent<BoxCollider2D>().size.y);
					break;
			}
			
			/*
			plz insert a for loop and check this new item against the others in the lists to make sure no overlapping
			
			 */
		}
		// staggers delay of shoppers 
		if (timeDelayShoppers >= 2)
		{
			//resest timer
			timeDelayShoppers = 0;
			int randomInt = Random.Range(0, 4);
			//changes the location and spawns a new object
			switch (randomInt)
			{
				case (0):
					shoppers.Add(Instantiate(shopper, new Vector2(Camera.main.orthographicSize * Camera.main.aspect, Camera.main.orthographicSize - shopper.GetComponent<BoxCollider2D>().size.y), Quaternion.identity));
					break;
				case (1):
					shoppers.Add(Instantiate(shopper, new Vector2(Camera.main.orthographicSize * Camera.main.aspect, shopper.GetComponent<BoxCollider2D>().size.y), Quaternion.identity));					
					break;
				case (2):
					shoppers.Add(Instantiate(shopper, new Vector2(Camera.main.orthographicSize * Camera.main.aspect, -shopper.GetComponent<BoxCollider2D>().size.y), Quaternion.identity));					
					break;
				case (3):
					shoppers.Add(Instantiate(shopper, new Vector2(Camera.main.orthographicSize * Camera.main.aspect, -Camera.main.orthographicSize - shopper.GetComponent<BoxCollider2D>().size.y), Quaternion.identity));
					break;
			}
			/*
			plz insert a for loop and check this new item against the others in the lists to make sure no overlapping
			
			 */
			
		}
        #endregion   
        //destroys objects if offscreem
        foreach (GameObject item in items)
		{
			if (item.transform.position.x < Camera.main.orthographicSize * Camera.main.aspect + 5)
			{
				items.Remove(item);
				Destroy(item);
			}
		}
		//destroys objects if off screen
		foreach (GameObject shopper in shoppers)
		{
			if (shopper.transform.position.x < Camera.main.orthographicSize * Camera.main.aspect + 5)
			{
				items.Remove(item);
				Destroy(item);
			}
		}
	}
	// score system please call when the game is done I dont call this yet because dont have collisions
	public int Calculate()
	{
		int totalScore;
		float multiplier;
		int scoreSurvive = 0;
		for (int i = 0; i < surviveList.Count; i++)
		{
			scoreSurvive += surviveList[i];
		}
		int scoreHappy = 0;
		for (int i = 0; i < happyList.Count; i++)
		{
			scoreHappy += happyList[i];
		}
		totalScore = scoreHappy + scoreSurvive;
		if (scoreSurvive < scoreHappy)
		{
			multiplier = scoreSurvive / scoreHappy;
		}
		else
		{
			multiplier = scoreHappy / scoreSurvive;
		}
		if (multiplier >= .85f)
		{
			multiplier = 1.25f;
		}
		if (lives == 3)
		{
			multiplier += .25f;
		}
		totalScore = (int)(totalScore * multiplier);
		return totalScore;
	}
}
