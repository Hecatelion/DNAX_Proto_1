using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
	List<GameObject> children;
	List<Animator> childrenAnimtors;

    void Start()
    {
		this.children = new List<GameObject>();
		foreach (Transform tr in this.transform)
		{
			if (tr != this.transform)
			{
				this.children.Add(tr.gameObject);
			}
		}

		this.childrenAnimtors = new List<Animator>();
		foreach (var child in this.children)
		{
			Animator animator = child.GetComponent<Animator>();

			if (animator != null)
			{
				this.childrenAnimtors.Add(animator);
			}
		}
    }

    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			PlayAnim();
		}
    }

	public void PlayAnim()
	{
		foreach (Animator animator in this.childrenAnimtors)
		{
			if (animator.HasState(0, Animator.StringToHash("Green")))
			{
				animator.Play("Green");
			}
		}
	}
}
