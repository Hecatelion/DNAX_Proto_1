using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Split it in 2 sub-scripts ? : 
 * - Organism Manager
 * - Asteroid 
*/

public class Asteroid : MonoBehaviour
{
	DNAStorage storage;
	public DNAStorage Storage { get => storage; }

	// Organism Management
	Organism curOrganism;

	// Interraction
	ClickableModel model;
	UI_Asteroid ui;
	bool isUsable = true;
	public bool IsUsable { get => isUsable; }

	void Start()
	{
		this.storage = GetComponentInChildren<DNAStorage>();
		this.storage.AddCell(5);

		this.model = GetComponentInChildren<ClickableModel>();

		this.ui = GetComponentInChildren<UI_Asteroid>();
		this.ui.gameObject.SetActive(false);
		AllowInterraction();
    }

    void Update()
    { }

	#region Interraction

	private void OpenUI()
	{
		this.ui.gameObject.SetActiveRecursively(true);
	}

	public void AllowInterraction()
	{
		this.model.onClick += OpenUI;
	}

	public void DisallowInterraction()
	{
		this.model.onClick -= OpenUI;
	}

	#endregion

	#region Organism Management

	public void SpawnOrganism(DNA _dna)
	{
		this.curOrganism = TheOrganismFactory.Instance.InstantiateNewOrganism(_dna, this.transform.position + Vector3.left * 2).GetComponent<Organism>();
		this.curOrganism.onDeath += AllowInterraction;

		DisallowInterraction();
		this.ui.gameObject.SetActive(false);
	}

	#endregion
}
