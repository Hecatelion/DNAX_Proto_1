using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheCameraMan : Singleton<TheCameraMan>
{
	CustomCamera mainCamera;

    void Start()
    {
		mainCamera = FindObjectOfType<CustomCamera>();
		TheOrganismFactory.Instance.onOrganismBirth += Target;
		TheOrganismFactory.Instance.onOrganismDeath += TargetAsteroid;

		TargetAsteroid();
	}
	
	public void Target(GameObject _newTarget)
	{
		mainCamera.SetTarget(_newTarget);
	}

	public void TargetAsteroid()
	{
		mainCamera.SetTarget(TheGameState.Instance.curAsteroid.gameObject);
	}
}
