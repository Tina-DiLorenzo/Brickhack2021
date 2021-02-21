using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
	// doesn't do anything moved to game manager but can be used if someone wants to and keeps code safe
	public List<int> surviveList;
	public List<int> happyList;
	public int lives;
	public Score(List<int> surviveList, List<int> happyList, int lives)
	{
		this.surviveList = surviveList;
		this.happyList = happyList;
		this.lives = lives;
	}
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
