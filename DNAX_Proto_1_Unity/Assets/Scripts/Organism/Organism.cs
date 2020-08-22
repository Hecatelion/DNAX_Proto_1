using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Organism : MonoBehaviour
{
	private DNA dna;
	private List<Passive> passives;
	private List<Ability> abilities;
	private Stats stats;

	void Start()
    {
		/*
		passives = new List<Passive>();
		abilities = new List<Ability>();

		// temporary : must be deduced from DNA
		passives.Add(TheSkillManager.InstantiatePassive(e_PassiveType.Photosynthesis, this).GetComponent<Passive>());
		abilities.Add(TheSkillManager.InstantiateAbility(e_AbilityType.Heal, this).GetComponent<Ability>());

		TheCustomInputManager.Bind(abilities[0], e_CommandType.Ability0);
		TheCustomInputManager.Bind(Funk1, e_CommandType.Ability1);
		TheCustomInputManager.Bind(Funk2, e_CommandType.Ability5);
		*/
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			dna.Log();
			stats.Log();
		}
	}

	public void Init(DNA _dna)
	{
		dna = _dna;

		stats = Stats.GetStatsFromDNA(_dna);
		stats += new StatsModifier() { movementSpeed = 5 };

		passives = GetPassivesFromDNA();
		abilities = GetAbilitiesFromDNA();
		BindAbilities();
	}

	private List<Passive> GetPassivesFromDNA()
	{
		List<Passive> passives = new List<Passive>();

		foreach (e_GeneType gene in dna.Genes)
		{
			switch (gene)
			{
				case e_GeneType.Photosynthesis:
					passives.Add(TheSkillManager.InstantiatePassive(e_PassiveType.Photosynthesis, this).GetComponent<Passive>()); 
					break;
			}
		}

		return passives;
	}

	private List<Ability> GetAbilitiesFromDNA()
	{
		List<Ability> abilities = new List<Ability>();

		foreach (e_GeneType gene in dna.Genes)
		{
			switch (gene)
			{
				case e_GeneType.Heal:
					abilities.Add(TheSkillManager.InstantiateAbility(e_AbilityType.Heal, this).GetComponent<Ability>());
					break;
			}
		}

		return abilities;
	}

	public void Clear() // (delete all skills and unbind abilities)
	{
		dna = null;
		stats = new Stats();

		foreach (var passive in passives)
		{
			passive.Destroy();
		}
		passives = null;

		UnbindAbilities();
		foreach (var ability in abilities)
		{
			ability.Destroy();
		}
		abilities = null;
	}

	public void Destroy()
	{
		Clear();
		Destroy(gameObject);
		// make all refs = null (in OrganismBuilder for example)
	}

	private void BindAbilities()
	{
		int abilityIndex = (int)e_CommandType.Ability1;

		for (int i = 0; i < abilities.Count; ++i)
		{
			TheCustomInputManager.Bind(abilities[i], (e_CommandType)(abilityIndex + i));
		}
	}

	private void UnbindAbilities()
	{
		int abilityIndex = (int)e_CommandType.Ability1;

		for (int i = 0; i < abilities.Count; ++i)
		{
			TheCustomInputManager.Unbind(abilities[i], (e_CommandType)(abilityIndex + i));
		}
	}

	// factory
	public static GameObject InstantiateNewOrganism(DNA _dna)
	{
		GameObject go = new GameObject("New Organism");
		go.transform.position = Vector3.zero;
		go.transform.rotation = Quaternion.identity;

		go.AddComponent<Organism>().Init(_dna);

		return go;
	}


	// Debug
	void Funk1()
	{
		Debug.Log("Funk 1");
	}
	void Funk2()
	{
		Debug.Log("Funk 2");
	}
}
