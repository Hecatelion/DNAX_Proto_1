using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Organism : MonoBehaviour
{
	Organism organism;

	[SerializeField] Text hpText;

    void Start()
    {
		organism = GetComponentInParent<Organism>();

		Debug.Log((int)4.8f);
	}

    void Update()
    {
		UpdateHP();
    }

	void UpdateHP()
	{
		int upRoundedHP = (int)((int)(organism.Stats.HpCur) + 0.99f);
		hpText.text = upRoundedHP.ToString(); // int cast will round down HpCur, to round up : (int) (x + 0.99f)
	}
}
