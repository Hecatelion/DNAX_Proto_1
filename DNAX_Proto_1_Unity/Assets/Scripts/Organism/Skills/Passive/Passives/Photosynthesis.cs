using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Photosynthesis : Passive
{
	[SerializeField] int healPerSecond;
	[SerializeField] float frequency;

	float t;

	protected override void Start()
	{
		base.Start();
	}

	protected override void Update()
	{
		base.Update();

		this.t += Time.deltaTime;
		if (this.t > this.frequency)
		{
			this.t -= this.frequency;

			Activate();
		}
	}

	protected override void Activate()
	{
		base.Activate();

		this.organism.ApplyStatsModif(new StatsModifier() { hpCur = healPerSecond });

		Debug.Log("Ability : \"Photosyntesis\" activation.");
	}

	protected override void Deactivate()
	{
		base.Deactivate();
	}
}
