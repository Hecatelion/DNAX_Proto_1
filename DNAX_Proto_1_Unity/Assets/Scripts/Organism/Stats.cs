using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats
{
	private int om;
	private float hpMax;
	private float hpCur;
	private float dot;
	private float movementSpeed;

	public int Om { get; }
	public float HpMax { get; }
	public float HpCur { get; } // timer
	public float Dot { get; }
	public float MovementSpeed { get; }

	public Stats()
	{
		this.om = 0;
		this.hpMax = 0;
		this.hpCur = 0;
		this.dot = 0;
		this.movementSpeed = 0;
	}

	public static Stats operator+(Stats _stats, StatsModifier _modifier)
	{
		Stats result = new Stats();

		result.om = _stats.Om + _modifier.om;

		result.hpMax = _stats.HpMax + _modifier.hpMax;
		result.hpCur = _stats.HpCur + _modifier.hpCur;
		if (result.HpCur > result.HpMax) result.hpCur = result.HpMax;

		result.dot = _stats.Dot + _modifier.dot;
		result.movementSpeed = _stats.MovementSpeed + _modifier.movementSpeed;

		return result;
	}

	// -----------------------------
	// Debug Methods

	public void Log()
	{
		Debug.Log("Stats : Om(" + this.Om + ") HpMax(" + this.HpMax + ") HpCur(" + this.HpCur + ") Dot(" + this.Dot + ") speed(" + this.MovementSpeed + ")");
	}
}