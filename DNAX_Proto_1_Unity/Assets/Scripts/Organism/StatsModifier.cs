using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsModifier
{
	public int om;
	public float hpMax;
	public float hpCur; // timer
	public float dot;
	public float movementSpeed;

	public StatsModifier()
	{
		this.om = 0;
		this.hpMax = 0;
		this.hpCur = 0;
		this.dot = 0;
		this.movementSpeed = 0;
	}

	public static StatsModifier operator+(StatsModifier _modif1, StatsModifier _modif2)
	{
		return new StatsModifier {		
			om = _modif1.om + _modif2.om,
			hpMax = _modif1.hpMax + _modif2.hpMax,
			hpCur = _modif1.hpCur + _modif2.hpCur,
			dot = _modif1.dot + _modif2.dot,
			movementSpeed = _modif1.movementSpeed + _modif2.movementSpeed
		};
	}
}
