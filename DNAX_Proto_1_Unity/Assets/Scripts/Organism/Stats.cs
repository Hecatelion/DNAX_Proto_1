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

	public Stats()
	{
		om = 0;
		hpMax = 0;
		hpCur = 0;
		dot = 0;
		movementSpeed = 0;
	}

	public static Stats GetStatsFromDNA(DNA _dna)
	{
		int nbGene = _dna.Genes.Count;

		return new Stats	{
			om = nbGene,
			hpMax = nbGene * 10,
			hpCur = nbGene * 10,
			dot = nbGene,
			movementSpeed = 0
		};
	}

	public static Stats operator+(Stats _stats, StatsModifier _modifier)
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

	// -----------------------------
	// Debug Methods

	public void Log()
	{
		string str = "Stats : om(" + om + ") hpMax(" + hpMax + ") hpCur(" + hpCur + ") dot(" + dot + ") speed(" + movementSpeed + ")";

		

		Debug.Log(str);
	}
}