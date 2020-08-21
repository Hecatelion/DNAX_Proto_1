using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Ability
{
	[SerializeField] int heal;

	protected override void Start()
	{
		base.Start();

		Debug.Log("Ability : \"Heal\" Start().");
	}

	protected override void Update()
	{
		base.Update();
	}

	protected override void Activate()
	{
		base.Activate();

		Debug.Log("Ability : \"Heal\" Launched."); // TODO :  heal code, implying StatModifier
	}

	protected override void Deactivate()
	{
		base.Deactivate();
	}

	public override void RequestActivation()
	{
		base.Update();
	}
}
