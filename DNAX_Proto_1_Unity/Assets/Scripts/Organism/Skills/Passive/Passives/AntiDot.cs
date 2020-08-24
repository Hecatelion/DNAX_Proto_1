using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiDot : Passive
{
	[SerializeField] float dotReduction;

	protected override void Start()
	{
		base.Start();

		this.organism.ApplyStatsModif(new StatsModifier() { dot = -this.dotReduction });
	}

	protected override void Update()
	{
		base.Update();
	}

	protected override void Activate()
	{
		base.Activate();
	}

	protected override void Deactivate()
	{
		base.Deactivate();
	}
}