using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Organism : MonoBehaviour
{
	[SerializeField] private OrganismData data;

	private DNA dna;
	private List<Passive> passives;
	private List<Ability> abilities;

	public Stats Stats { get; private set; }

	void Start()
    { }

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			dna.Log();
			Stats.Log();
		}

		DotUpdate();
		DeathUpdate();
	}

	#region Creation Management

	public void Init(DNA _dna)
	{
		dna = _dna;

		int nbGene = dna.Genes.Count;

		Stats = new Stats() + new StatsModifier() {
			om = nbGene,
			hpMax = nbGene * data.hpPerOm,
			hpCur = nbGene * data.hpPerOm,
			dot = nbGene * data.dotPerOm,
			movementSpeed = data.movementSpeed
		};

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
		Stats = new Stats();

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
		// make all refs = null (in OrganismBuilder for example) ?
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

	#endregion

	#region Behavior, Gameplay

	public void ApplyStatsModif(StatsModifier _modif)
	{
		Stats += _modif;
	}

	public void DotUpdate()
	{
		ApplyStatsModif(new StatsModifier() { hpCur = -Time.deltaTime * Stats.Dot });

		Debug.Log("hp : " + Stats.HpCur.ToString());
	}

	public void DeathUpdate()
	{
		if (Stats.HpCur < 0 )
		{
			Die();
		}
	}

	private void Die()
	{
		// dying behavior code

		Debug.Log(gameObject.name + "died.");

		this.Destroy();
	}

	#endregion
	
	#region Debug

	void Funk1()
	{
		Debug.Log("Funk 1");
	}
	void Funk2()
	{
		Debug.Log("Funk 2");
	}

	#endregion
}
