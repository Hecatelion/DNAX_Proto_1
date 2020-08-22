using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill: MonoBehaviour
{
	Organism organism;

	Callback onActivation = () => { };
	Callback onDeactivation = () => { };

	public void Init(Organism _org)
	{
		organism = _org;
	}

	public void Destroy()
	{
		Destroy(gameObject);
	}

	protected virtual void Start()
	{ }

	protected virtual void Update()
	{ }

	// call it to Activate the effects of the skill 
	// e.g. When a passive procs or when an ability is used
	protected virtual void Activate() 
	{
		onActivation();
	}

	// call it to Deactivate the effects of the skill
	// when a passive or an ability should stop or be cancelled
	protected virtual void Deactivate()
	{
		onDeactivation();
	}
}
