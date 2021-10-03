using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheGameState : Singleton<TheGameState>
{
	public Organism curOrganism;
	public Asteroid curAsteroid;

	private void Start()
	{
		curAsteroid = GameObject.FindObjectOfType<Asteroid>();
	}
}
