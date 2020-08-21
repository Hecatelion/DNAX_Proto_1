using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passive : Skill
{
	[SerializeField] protected e_PassiveType type;
	public e_PassiveType Type { get => type; }

	protected override void Start()
	{
		base.Start();
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
