using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats
{
	public int Om { get; private set; }
	public float HpMax { get; private set; }
	public float HpCur { get; private set; } // timer
	public float Dot { get; private set; }
	public float MovementSpeed { get; private set; }

	public Stats()
	{
		Om = 0;
		HpMax = 0;
		HpCur = 0;
		Dot = 0;
		MovementSpeed = 0;
	}

	public static Stats operator+(Stats _stats, StatsModifier _modifier)
	{
		Stats result = new Stats();

		result.Om = _stats.Om + _modifier.om;

		result.HpMax = _stats.HpMax + _modifier.hpMax;
		result.HpCur = _stats.HpCur + _modifier.hpCur;
		if (result.HpCur > result.HpMax) result.HpCur = result.HpMax;

		result.Dot = _stats.Dot + _modifier.dot;
		result.MovementSpeed = _stats.MovementSpeed + _modifier.movementSpeed;

		return result;
	}

	// -----------------------------
	// Debug Methods

	public void Log()
	{
		Debug.Log("Stats : Om(" + Om + ") HpMax(" + HpMax + ") HpCur(" + HpCur + ") Dot(" + Dot + ") speed(" + MovementSpeed + ")");
	}
}