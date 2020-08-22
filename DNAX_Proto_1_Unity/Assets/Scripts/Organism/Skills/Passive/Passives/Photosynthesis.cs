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

		t += Time.deltaTime;
		if (t > frequency)
		{
			t -= frequency;

			Activate();
		}
	}

	protected override void Activate()
	{
		base.Activate();

		Debug.Log("Ability : \"Photosyntesis\" activation."); // TODO :  heal code, implying StatModifier
	}

	protected override void Deactivate()
	{
		base.Deactivate();
	}
}
