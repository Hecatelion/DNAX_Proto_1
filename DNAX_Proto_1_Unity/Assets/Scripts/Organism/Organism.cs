
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Organism : MonoBehaviour
{
	[SerializeField] private OrganismData data;

	private DNA dna;
	private Stats stats;
	private List<Passive> passives;
	private List<Ability> abilities;

	public Callback onSpawn = () => { };
	public Callback onDeath = () => { };

	private new Rigidbody rigidbody;

	public Stats Stats { get => this.stats; }

	void Start()
    {
		this.rigidbody = GetComponent<Rigidbody>();

		GameObject.FindObjectOfType<CustomCamera>().SetTarget(this.gameObject);
	}

	void Update()
	{
		// debug
		if (Input.GetKeyDown(KeyCode.KeypadMinus))
		{
			ApplyStatsModif(new StatsModifier() { hpCur = -10 });
		}
		if (Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			this.dna.Log();
			this.Stats.Log();
		}

		MovementUpdate();
		DeathUpdate();
	}

	#region Creation Management

	public void Init(DNA _dna)
	{
		this.dna = _dna;

		int nbGene = this.dna.Genes.Count;

		this.stats = new Stats() + new StatsModifier() {
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

		passives.Add(TheSkillManager.InstantiatePassive(e_PassiveType.Dot, this).GetComponent<Passive>());

		foreach (e_GeneType gene in this.dna.Genes)
		{
			switch (gene)
			{
				case e_GeneType.Photosynthesis:
					passives.Add(TheSkillManager.InstantiatePassive(e_PassiveType.Photosynthesis, this).GetComponent<Passive>()); 
					break;

				case e_GeneType.AntiDot:
					passives.Add(TheSkillManager.InstantiatePassive(e_PassiveType.AntiDot, this).GetComponent<Passive>()); 
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
		this.stats = new Stats();

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

	private void MovementUpdate()
	{
		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");

		if (horizontal != 0 || vertical != 0)
		{
			this.transform.forward = new Vector3(horizontal, 0, vertical);

			this.rigidbody.velocity = this.transform.forward * this.Stats.MovementSpeed;
		}
		else
		{
			this.rigidbody.velocity = Vector3.zero;
		}
	}

	public void ApplyStatsModif(StatsModifier _modif)
	{
		this.stats += _modif;
	}

	private void DeathUpdate()
	{
		if (this.Stats.HpCur < 0 )
		{
			Die();
		}
	}

	private void Die()
	{
		this.onDeath();

		// dying behavior code
		Debug.Log(this.gameObject.name + " died.");

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
