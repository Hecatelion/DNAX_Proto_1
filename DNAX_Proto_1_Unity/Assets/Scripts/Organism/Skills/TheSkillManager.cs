using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// Singleton & Factory
public class TheSkillManager : Singleton<TheSkillManager>
{
	[SerializeField] List<GameObject> passivePrefabs;
	[SerializeField] List<GameObject> abilityPrefabs;

	void Start()
    { }

    void Update()
    { }

	private GameObject instance_InstantiatePassive(e_PassiveType _passive, Organism _org) // var Context ?
	{
		GameObject passivePrefab = (from prefab in passivePrefabs where prefab.GetComponent<Passive>().Type == _passive select prefab).ToList()[0];

		if (!passivePrefab)
		{
			Debug.LogError("Passive Type : \"" + _passive.ToString() + "\" not found in TheSkillManager.\n" +
			"Please ensure present is referenced in the List");

			return null;
		}

		GameObject passiveCreated = Instantiate(passivePrefab, this.transform);
		passiveCreated.GetComponent<Skill>().Init(_org);

		return passiveCreated;
	}

	private GameObject instance_InstantiateAbility(e_AbilityType _ability, Organism _org) // var Context ?
	{
		List<GameObject> correspondingPrefabs = (from prefab in abilityPrefabs where prefab.GetComponent<Ability>().Type == _ability select prefab).ToList();

		if (correspondingPrefabs.Count < 1)
		{
			Debug.LogError("Ability Type : \"" + _ability.ToString() + "\" not found in TheSkillManager.\n" +
			"Please ensure present is referenced in the List");

			return null;
		}

		GameObject abilityPrefab = correspondingPrefabs[0];

		GameObject abilityCreated = Instantiate(abilityPrefab, this.transform);
		abilityCreated.GetComponent<Skill>().Init(_org);

		return abilityCreated;
	}

	// --------------------------------
	// Singleton static functions

	public static GameObject InstantiateAbility(e_AbilityType _ability, Organism _org)
	{
		return Instance.instance_InstantiateAbility(_ability, _org);
	}

	public static GameObject InstantiatePassive(e_PassiveType _passive, Organism _org)
	{
		return Instance.instance_InstantiatePassive(_passive, _org);
	}
}
