using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : SkillEffect
{
	StatsModifier modif; // TODO :  should it be SerializeField so it is easier to balance ?

	protected override void Launch()
	{
		base.Launch();

		_ = 0; // TODO :  heal code, implying StatModifier
	}
}
