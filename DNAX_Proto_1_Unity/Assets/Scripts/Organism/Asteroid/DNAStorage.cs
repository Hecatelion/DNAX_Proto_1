using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNAStorage : MonoBehaviour
{
	public int nbCells = 0;
	public int NbCells { get => nbCells; }

	List<e_GeneType> genes;
	public List<e_GeneType> Genes { get => genes; }


	void Start()
    {
		genes = new List<e_GeneType>();
		UnlockAllGenes();
    }

    void Update()
    {
        
    }

	// UnLockGene(e_GeneType _gene) { }

	void UnlockAllGenes()
	{
		genes.Clear();

		for (int i = 0; i < (int)e_GeneType.Count; i++)
		{
			genes.Add((e_GeneType)i);
		}
	}

	public void AddCell(int _nb = 1)
	{
		nbCells += _nb;
	}

	// OnIntrude += UpdateStorage
}
