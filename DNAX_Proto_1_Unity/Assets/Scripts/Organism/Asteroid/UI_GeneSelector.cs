using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class UI_GeneSelector : MonoBehaviour
{
	public e_GeneType gene;
	[HideInInspector] public Dropdown dd;

	Asteroid asteroid;
	UI_Asteroid uiAsteroid;

	void Start()
    {
		//Init();
    }

    void Update()
    { }

	
	public void Init()
	{
		this.asteroid = GetComponentInParent<Asteroid>();
		this.uiAsteroid = GetComponentInParent<UI_Asteroid>();
		this.dd = GetComponentInChildren<Dropdown>();

		SetGene(e_GeneType.None);
		InitDropdownFromGenes(dd, asteroid.Storage.Genes);
	}

	void InitDropdown(Dropdown _dropdown, List<string> _items)
	{
		_dropdown.ClearOptions();
		_dropdown.AddOptions(_items);
	}

	void InitDropdownFromGenes(Dropdown _dropdown, List<e_GeneType> _genes)
	{
		List<e_GeneType> genes = new List<e_GeneType>();
		genes.Add(e_GeneType.None);
		genes.AddRange(_genes);

		InitDropdown(_dropdown, (from g in genes select g.ToString()).ToList());
	}
	

	void SetGene(e_GeneType _g)
	{
		gene = _g;
	}

	// UI Functions

	public void DROPDOWN_SelectGene()
	{
		SetGene((e_GeneType)Enum.Parse(typeof(e_GeneType), dd.captionText.text));
	}

	public void BUTTON_RemoveGeneSelector()
	{
		this.uiAsteroid.RemoveCell(this);
		Destroy(this.gameObject);
	}
}
