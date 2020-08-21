using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Photosynthesis : Passive
{
	[SerializeField] int healPerSecond;

	protected override void Start()
	{
		base.Start();

		Debug.Log("Passive : \"Photosynthesis\" Start().");
	}

	protected override void Update()
	{
		base.Update();
	}

	protected override void Activate()
	{
		base.Activate();

		Debug.Log("Ability : \"Photosyntesis\" Launched."); // TODO :  heal code, implying StatModifier
	}

	protected override void Deactivate()
	{
		base.Deactivate();
	}
}
