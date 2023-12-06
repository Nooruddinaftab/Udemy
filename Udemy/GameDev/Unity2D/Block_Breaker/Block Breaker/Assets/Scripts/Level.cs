using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

	[SerializeField] int breakableBlocks; // serialized for debugging purposes

	// cached ref
	SceneLoader sceneLoader;

	public void Start()
    {
		sceneLoader = FindObjectOfType<SceneLoader>();
	}
	public void AddCountBreakableBlocks()
    {
		breakableBlocks++;
    }

	public void BlockDestroyed()
	{
		breakableBlocks--;

		if (breakableBlocks <= 0)
		{
			// load next level
			sceneLoader.LoadNextScene();
		}
	}

}
