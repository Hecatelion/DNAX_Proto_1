using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class CascadingAnimator : MonoBehaviour
{
	[SerializeField] protected List<e_AnimationType> animationTypes;

	protected e_AnimationType curAnim;
	protected Animator animator;
	protected List<CascadingAnimator> childrenCascadingAnimators;

	protected virtual void Start()
	{
		AssertPrerequisites();

		this.curAnim = e_AnimationType.None;
		this.animator = GetComponent<Animator>();
		this.childrenCascadingAnimators = GetComponentsInChildren<CascadingAnimator>().ToList();
	}

	protected virtual void Update()
	{ }

	protected void AssertPrerequisites()
	{
		Debug.Assert(GetComponent<Animator>() != null,
			"'" + this.gameObject.name + "' requires an 'Animator' component.");

		Debug.Assert(GetComponent<MeshRenderer>() == null,
			"'" + this.gameObject.name + "' mustn't have a 'MeshRenderer' component.\n" +
			"GameObjects with a 'CascadingAnimator' component have to be the root of other GameObjects only used as 3D model with a 'MeshRenderer'.");
	}

	public void RequestAnim(e_AnimationType _animType)
	{
		if (HasAnim(_animType))
		{
			CancelCurAnim();
			PlayAnim(_animType);
		}

		// propagate animation request even if doesnt have the animation itself
		PropagateToChildren(_animType);
	}

	protected bool HasAnim(e_AnimationType _animType)
	{
		return this.animationTypes.Contains(_animType);
	}

	protected abstract void PlayAnim(e_AnimationType _animType);
	protected abstract void CancelCurAnim();

	protected void PropagateToChildren(e_AnimationType _animType)
	{
		foreach (var cAnimator in this.childrenCascadingAnimators)
		{
			cAnimator.RequestAnim(_animType);
		}
	}

	protected void LogErrorPlayAnim(e_AnimationType _animType)
	{
		Debug.LogError("You tried to play the '" + _animType.ToString() + "' animation on the '" + this.gameObject.name + "' whereas its 'CascadingAnimator' component can't. \n" +
			"You may have forgotten to call the corresponding function in the 'PlayAnim(e_AnimType)' switch.");
	}

	protected void LogErrorCancelCurAnim()
	{
		Debug.LogError("You tried to cancel the '" + this.curAnim.ToString() + "' animation on the '" + this.gameObject.name + "' whereas its 'CascadingAnimator' component can't. \n" +
			"You may have forgotten to call the corresponding function in the 'CancelCurrentAnim()' switch.");
	}
}
