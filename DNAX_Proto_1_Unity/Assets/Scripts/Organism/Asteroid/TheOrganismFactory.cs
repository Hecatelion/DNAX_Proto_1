using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Design pattern : factory

public class TheOrganismFactory : Singleton<TheOrganismFactory>
{
	[SerializeField] GameObject organismPrefab;
	GameObject organismGO;

	public CallbackGO onOrganismBirth = (GameObject _go) => { }; 
	public Callback onOrganismDeath = () => { }; 

	// factory method
	public GameObject InstantiateNewOrganism(DNA _dna, Vector3 _pos)
	{
		if (_dna.Genes.Count < 1)
		{
			Debug.LogError("Trying to Instantiate an organism with no cells/DNA");
		}

		GameObject newOrganismGO = Instantiate(this.organismPrefab, _pos, Quaternion.identity);
		newOrganismGO.name = "New Organism";

		Organism newOrganism = newOrganismGO.GetComponent<Organism>();
		newOrganism.Init(_dna);
		newOrganism.onDeath += CallOrganismDeath;

		TheGameState.Instance.curOrganism = newOrganism;
		onOrganismBirth(newOrganismGO);

		Debug.Log("New Organism");
		_dna.Log();

		return newOrganismGO;
	}

	private void CallOrganismDeath()
	{
		onOrganismDeath();
	}
}
