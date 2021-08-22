using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Photosynthesis : Passive
{
	[SerializeField] int healPerSecond;
	[Tooltip("the delay between two tick of heal (0 -> each frame)")]
	[SerializeField] float delayInSecond;

	float t;

	protected override void Start()
	{
		base.Start();
	}

	protected override void Update()
	{
		base.Update();

		if (this.delayInSecond == 0)
		{
			Activate();
		}
		else
		{
			this.t += Time.deltaTime;
			if (this.t > this.delayInSecond)
			{
				this.t -= this.delayInSecond;

				Activate();
			}
		}
	}

	protected override void Activate()
	{
		base.Activate();

		float healAmount = (this.delayInSecond == 0) ? this.healPerSecond * Time.deltaTime : this.healPerSecond * this.delayInSecond;
		this.organism.ApplyStatsModif(new StatsModifier() { hpCur = healAmount });

		Debug.Log("Passive : \"Photosyntesis\" activation. hp : " + (int)this.organism.Stats.HpCur);
	}

	protected override void Deactivate()
	{
		base.Deactivate();
	}
}
