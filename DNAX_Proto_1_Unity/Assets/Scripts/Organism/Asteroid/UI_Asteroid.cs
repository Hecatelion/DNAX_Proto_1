using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class UI_Asteroid : MonoBehaviour
{
	Asteroid asteroid;
	OrganismBuilder builder;

	// WIP
	// List<UI_Gene> uiGenes;
	Dropdown geneDropdown;

    void Start()
    {
		asteroid = GetComponentInParent<Asteroid>();
		geneDropdown = GetComponentInChildren<Dropdown>();

		// WIP
		/*
		uiGenes = new List<UI_Gene>();
		uiGenes.Add(new ) 
		*/
    }

    void Update() 
	{ }

	void InitDropdown(Dropdown _dropdown, List<string> _items)
	{
		_dropdown.ClearOptions();
		_dropdown.AddOptions(_items);
	}

	void InitDropdownFromGenes(Dropdown _dropdown, List<e_GeneType> _genes)
	{
		InitDropdown(_dropdown, (from g in _genes select g.ToString()).ToList());
	}

	void AddGeneInUI()
	{

	}

#region ButtonFunctions

	public void BUTTON_SpawnOrganism()
	{
		builder.InstantiateNewOrganism(builder.dna1);

		gameObject.SetActive(false);
	}

	public void BUTTON_GeneSelection()
	{
		InitDropdownFromGenes(this.geneDropdown, asteroid.GeneStorage);
	}

#endregion
}
