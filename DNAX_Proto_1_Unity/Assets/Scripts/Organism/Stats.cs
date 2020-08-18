using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats
{
	private int om;
	private float hpMax; 
	private float hpCur; // timer
	private float dot;
	private float movementSpeed;

	public static Stats operator+ (Stats _stats, StatsModifier _modifier)
	{
		Stats result = new Stats();

		result.om = _stats.om + _modifier.om;

		result.hpMax = _stats.hpMax + _modifier.hpMax;
		result.hpCur = _stats.hpCur + _modifier.hpCur;
		if (result.hpCur > result.hpMax) result.hpCur = result.hpMax;

		result.dot = _stats.dot + _modifier.dot;
		result.movementSpeed = _stats.movementSpeed + _modifier.movementSpeed;

		return result;
	}
}