﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Organism : MonoBehaviour
{
	private DNA dna;
	private List<Passive> passives;
	private List<Ability> abilities;
	private Stats stats;

	private void Init(DNA _dna)
	{
		dna = _dna;
	}

	void Start()
    {
		passives = new List<Passive>();
		abilities = new List<Ability>();

		// temporary : must be deduced from DNA
		passives.Add(TheSkillManager.InstantiatePassive(e_PassiveType.Photosynthesis, this).GetComponent<Passive>());
		abilities.Add(TheSkillManager.InstantiateAbility(e_AbilityType.Heal, this).GetComponent<Ability>());

		TheCustomInputManager.Bind(abilities[0].RequestActivation, e_CommandType.Ability0);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			dna.Log();
		}

		// temporary : must be bound in TheInputManager
		if (Input.GetKeyDown(KeyCode.Keypad1))
		{
			abilities[0].RequestActivation();
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

	void Funk1()
	{
		Debug.Log("Funk 1");
	}
	void Funk2()
	{
		Debug.Log("Funk 2");
	}
}
