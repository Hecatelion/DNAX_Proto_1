using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : Skill, IBindable
{
	[SerializeField] protected e_AbilityType type;
	public e_AbilityType Type { get => type; }

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

	public virtual void RequestAction()
	{

	}
}
