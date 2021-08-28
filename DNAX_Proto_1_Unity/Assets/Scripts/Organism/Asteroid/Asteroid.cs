using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
	ClickableModel model;
	UI_Asteroid ui;
	OrganismBuilder builder;
	Organism curOrganism;

	bool isUsable = true;
	public bool IsUsable { get => isUsable; }

	// put it in Organism Builder ?
	// {
	List<e_GeneType> geneStorage;
	public List<e_GeneType> GeneStorage { get=>geneStorage; }
	public int nbCells = 5;
	// }

	void Start()
	{
		this.model = GetComponentInChildren<ClickableModel>();
		this.ui = GetComponentInChildren<UI_Asteroid>();
		this.builder = GetComponentInParent<OrganismBuilder>();


		this.ui.gameObject.SetActive(false);
		AllowInterraction();

		this.geneStorage = new List<e_GeneType> { e_GeneType.Photosynthesis, e_GeneType.Heal, e_GeneType.Spikes };
    }

    void Update()
    { }

	private void OpenUI()
	{
		this.ui.gameObject.SetActive(true);
		this.ui.Init();
	}

	public void AllowInterraction()
	{
		this.model.onClick += OpenUI;
	}

	public void DisallowInterraction()
	{
		this.model.onClick -= OpenUI;
	}

	public void SpawnOrganism(DNA _dna)
	{
		this.curOrganism = this.builder.InstantiateNewOrganism(_dna).GetComponent<Organism>();
		this.curOrganism.onDeath += AllowInterraction;

		DisallowInterraction();
		this.ui.gameObject.SetActive(false);
	}
}
