using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : Passive
{
	protected override void Start()
	{
		base.Start();
	}

	protected override void Update()
	{
		base.Update();

		Activate();
	}

	protected override void Activate()
	{
		base.Activate();

		this.organism.ApplyStatsModif(new StatsModifier() { hpCur = -Time.deltaTime * this.organism.Stats.Dot });
	}

	protected override void Deactivate()
	{
		base.Deactivate();
	}
}
