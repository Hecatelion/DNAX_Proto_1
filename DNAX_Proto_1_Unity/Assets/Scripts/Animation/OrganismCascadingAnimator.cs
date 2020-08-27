﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganismCascadingAnimator : CascadingAnimator
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
			case e_AnimationType.Walk:		PlayWalkAnim();			break;

			// if animTypes has _animType but switch doesnt call the corresponding func
			default:	LogErrorPlayAnim(_animType);	return;		
		}

		this.curAnim = _animType;
	}

	protected override void CancelCurAnim()
	{
		switch (this.curAnim)
		{
			// if no animation running, nothing to cancel
			case e_AnimationType.None:		return;		

			case e_AnimationType.Walk:		CancelWalkAnim();		break;

			// if switch doesnt call the func corresponding to curAnim
			default:	LogErrorCancelCurAnim();	return;         
		}
	}

	#region Animations

	private void PlayWalkAnim()
	{
		// animator.PlayAnim("walking_state");
		// -> Unity classical anim stuff  
		// LaunchFx("dust_paillette");
	}

	private void CancelWalkAnim()
	{
		// animator.StopAnim("walking_state");
		// -> Unity classical anim stuff  
		// DestroyFx("dust_paillette"); ? or let them finish their stuff ?
	}

	#endregion
}
