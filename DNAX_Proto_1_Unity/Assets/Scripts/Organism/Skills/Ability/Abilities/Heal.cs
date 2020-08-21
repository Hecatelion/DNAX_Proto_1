﻿using System.Collections;
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

		isInCooldown = false;
		Debug.Log("Ability : \"Heal\" Start().");
	}

	protected override void Update()
	{
		base.Update();

		if (isInCooldown)
		{
			t += Time.deltaTime;

			if (t >= cooldown)
			{
				isInCooldown = false;
				t = 0;
			}
		}
	}

	protected override void Activate()
	{
		base.Activate();

		isInCooldown = true;
		Debug.Log("Ability : \"Heal\" Launched."); // TODO :  heal code, implying StatModifier
	}

	protected override void Deactivate()
	{
		base.Deactivate();
	}

	public override void RequestActivation()
	{
		base.Update();

		if (!isInCooldown)
		{
			Activate();
		}
		else
		{
			Debug.Log("in cooldown");
		}
	}
}