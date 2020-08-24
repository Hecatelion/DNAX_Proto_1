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
			this.dna.Log();
			this.Stats.Log();
		}

		DotUpdate();
		DeathUpdate();
	}

	#region Creation Management

	public void Init(DNA _dna)
	{
		this.dna = _dna;

		int nbGene = this.dna.Genes.Count;

		this.Stats = new Stats() + new StatsModifier() {
			om = nbGene,
			hpMax = nbGene * this.data.hpPerOm,
			hpCur = nbGene * this.data.hpPerOm,
			dot = nbGene * this.data.dotPerOm,
			movementSpeed = this.data.movementSpeed
		};

		this.passives = GetPassivesFromDNA();
		this.abilities = GetAbilitiesFromDNA();
		BindAbilities();
	}

	private List<Passive> GetPassivesFromDNA()
	{
		List<Passive> passives = new List<Passive>();

		foreach (e_GeneType gene in this.dna.Genes)
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

		foreach (e_GeneType gene in this.dna.Genes)
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
		this.dna = null;
		this.Stats = new Stats();

		foreach (var passive in this.passives)
		{
			passive.Destroy();
		}
		this.passives = null;

		UnbindAbilities();
		foreach (var ability in this.abilities)
		{
			ability.Destroy();
		}
		this.abilities = null;
	}

	public void Destroy()
	{
		Clear();
		Destroy(this.gameObject);
		// make all refs = null (in OrganismBuilder for example) ?
	}

	private void BindAbilities()
	{
		int abilityIndex = (int)e_CommandType.Ability1;

		for (int i = 0; i < this.abilities.Count; ++i)
		{
			TheCustomInputManager.Bind(this.abilities[i], (e_CommandType)(abilityIndex + i));
		}
	}

	private void UnbindAbilities()
	{
		int abilityIndex = (int)e_CommandType.Ability1;

		for (int i = 0; i < this.abilities.Count; ++i)
		{
			TheCustomInputManager.Unbind(this.abilities[i], (e_CommandType)(abilityIndex + i));
		}
	}

	#endregion

	#region Behavior, Gameplay

	public void ApplyStatsModif(StatsModifier _modif)
	{
		this.Stats += _modif;
	}

	public void DotUpdate()
	{
		ApplyStatsModif(new StatsModifier() { hpCur = -Time.deltaTime * this.Stats.Dot });

		Debug.Log("hp : " + this.Stats.HpCur.ToString());
	}

	public void DeathUpdate()
	{
		if (this.Stats.HpCur < 0 )
		{
			Die();
		}
	}

	private void Die()
	{
		// dying behavior code

		Debug.Log(this.gameObject.name + "died.");

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
