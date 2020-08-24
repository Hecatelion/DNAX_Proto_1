using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Ability
{
	[SerializeField] int heal;
	[SerializeField] float cooldown;
	private bool isInCooldown;
	private float t;

	protected override void Start()
	{
		base.Start();

		this.isInCooldown = false;
	}

	protected override void Update()
	{
		base.Update();

		if (this.isInCooldown)
		{
			this.t += Time.deltaTime;

			if (this.t >= this.cooldown)
			{
				this.isInCooldown = false;
				this.t = 0;
			}
		}
	}

	protected override void Activate()
	{
		base.Activate();

		this.organism.ApplyStatsModif(new StatsModifier() { hpCur = heal });
		this.isInCooldown = true;

		Debug.Log("Ability : \"Heal\" Launched.");
	}

	protected override void Deactivate()
	{
		base.Deactivate();
	}

	public override void RequestAction()
	{
		base.RequestAction();

		if (!this.isInCooldown)
		{
			Activate();
		}
		else
		{
			Debug.Log("in cooldown");
		}
	}
}
