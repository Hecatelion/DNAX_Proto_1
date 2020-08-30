using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCascadingAnimator : CascadingAnimator
{
    protected override void Start()
    {
		base.Start();
    }

	protected override void Update()
    {
		base.Update();
    }

	protected override void PlayAnim(e_AnimationType _animType)
	{
		switch (_animType)
		{
			case e_AnimationType.Idle:		PlayIdleAnim();			break;

			// if animTypes has _animType but switch doesnt call the corresponding func
			default:	LogErrorPlayAnim(_animType);	return;		
		}

		this.curAnim = _animType;

		LogPlayAnim(_animType);
	}

	protected override void CancelCurAnim()
	{
		switch (this.curAnim)
		{
			// if no animation running, nothing to cancel
			case e_AnimationType.None:		return;		

			case e_AnimationType.Idle:		CancelIdleAnim();		break;

			// if switch doesnt call the func corresponding to curAnim
			default:	LogErrorCancelCurAnim();	return;
		}

		LogCancelAnim(this.curAnim);
	}

	#region Animations

	private void PlayIdleAnim()
	{
		// animator.PlayAnim("walking_state");
		// -> Unity classical anim stuff  
		// LaunchFx("dust_paillette");
	}

	private void CancelIdleAnim()
	{
		// animator.PlayAnim("walking_state");
		// -> Unity classical anim stuff  
		// LaunchFx("dust_paillette");
	}

	#endregion
}
