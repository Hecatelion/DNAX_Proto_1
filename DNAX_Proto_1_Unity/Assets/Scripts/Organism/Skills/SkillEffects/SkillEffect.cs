using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillEffect : MonoBehaviour
{
	[SerializeField] public e_SkillEffectTypes type;

	Callback onLaunch = () => { };
	Callback onEnd = () => { };

	protected virtual void Start()
	{
		Launch();
	}

	protected virtual void Launch()
	{
		onLaunch();
	}

	protected virtual void End()
	{
		onEnd();
	}
}
