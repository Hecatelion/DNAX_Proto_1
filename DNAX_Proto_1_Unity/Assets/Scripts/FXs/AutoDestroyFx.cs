using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class AutoDestroyFx : MonoBehaviour
{
	VisualEffect fx;
	//float t = 0;
	//bool b = false;

	private void Start()
	{
		Debug.Assert(this.GetComponent<VisualEffect>() != null,
			"AutoDestroyFX script must be attached to a Visual Effect object");

		this.fx = this.GetComponent<VisualEffect>();

		/*this.fx.Stop();
		this.b = true;*/

		StartCoroutine(DestroyOnEnd());
	}

	private void Update()
	{
		/*
		if (!this.b)
		{
			this.t += Time.deltaTime;

			if (!this.b && this.fx.aliveParticleCount > 0)
			{
				Debug.Log("t : " + this.t);
				this.b = true;
			}
		}
		else
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				this.fx.Reinit();
				this.t = 0;
				this.b = false;
			}
		}
		*/
	}

	IEnumerator DestroyOnEnd()
	{
		while (true)
		{
			yield return new WaitForSeconds(1f);

			if (this.fx.aliveParticleCount < 1)
			{
				Destroy(this.gameObject);
			}
		}
	}
}
