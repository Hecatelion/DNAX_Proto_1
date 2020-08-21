using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// Singleton & Factory
public class TheSkillManager : MonoBehaviour
{
	private static TheSkillManager instance;

	[SerializeField] List<GameObject> passivePrefabs;
	[SerializeField] List<GameObject> abilityPrefabs;

	void Start()
    {
        if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(this.gameObject);
		}
    }

    void Update()
    { }

	private void instance_InstantiatePassive(e_PassiveType _passive, Organism _org) // var Context ?
	{
		GameObject passivePrefab = (from prefab in passivePrefabs where prefab.GetComponent<Passive>().Type == _passive select prefab).ToList()[0];

		if (!passivePrefab)
		{
			Debug.LogError("Passive Type : \"" + _passive.ToString() + "\" not found in TheSkillManager.\n" +
			"Please ensure present is referenced in the List");

			return;
		}

		GameObject passiveCreated = Instantiate(passivePrefab, this.transform);
		passiveCreated.GetComponent<Skill>().Init(_org);
	}

	private void instance_InstantiateAbility(e_AbilityType _ability, Organism _org) // var Context + Input
	{
		GameObject abilityPrefab = (from prefab in abilityPrefabs where prefab.GetComponent<Ability>().Type == _ability select prefab).ToList()[0];

		if (!abilityPrefab)
		{
			Debug.LogError("Ability Type : \"" + _ability.ToString() + "\" not found in TheSkillManager.\n" +
			"Please ensure present is referenced in the List");

			return;
		}

		GameObject abilityCreated = Instantiate(abilityPrefab, this.transform);
		abilityCreated.GetComponent<Skill>().Init(_org);
		_ = 0; // must bind it to input manager
	}

	// --------------------------------
	// Singleton static functions

	public static void InstantiateAbility(e_AbilityType _ability, Organism _org)
	{
		instance.instance_InstantiateAbility(_ability, _org);
	}

	public static void InstantiatePassive(e_PassiveType _passive, Organism _org)
	{
		instance.instance_InstantiatePassive(_passive, _org);
	}
}
