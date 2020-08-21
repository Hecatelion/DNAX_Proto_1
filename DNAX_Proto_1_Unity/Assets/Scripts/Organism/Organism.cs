﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Organism : MonoBehaviour
{
	private DNA dna;

	private void Init(DNA _dna)
	{
		dna = _dna;
	}

	void Start()
    {
		// temp
		TheSkillManager.InstantiatePassive(e_PassiveType.Photosynthesis, this);
		TheSkillManager.InstantiateAbility(e_AbilityType.Heal, this);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			dna.Log();
		}

		if (Input.GetKeyDown(KeyCode.Keypad1))
		{
			_ = 0; // TODO :  use SkillEffect : Heal
		}

	}

	public static GameObject InstantiateNewOrganism(DNA _dna)
	{
		GameObject go = new GameObject("New Organism");
		go.transform.position = Vector3.zero;
		go.transform.rotation = Quaternion.identity;

		go.AddComponent<Organism>().Init(_dna);

		return go;
	}
}
