using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackgroundManager : MonoBehaviour {

    public Transform prefab;

    public int numberOfPlatforms;
    public int intervalBetweenPlatforms;

    public Material activeMaterial;
    public Material inActiveMaterial;

    public Vector3 currentPlatformPosition;
    public Vector3 platformMinSize;
    public Vector3 platformMaxSize;

    private Transform [] platforms;

	// Use this for initialization
	void Start () {
        platforms = new Transform[numberOfPlatforms];
        Renderer vMesh = prefab.GetComponent("Renderer") as Renderer;
        currentPlatformPosition = prefab.localPosition;
        for (int i = 0; i < numberOfPlatforms; i++) {
            Transform platform = (Transform)Instantiate(prefab);
            SetNextPlatfrom(platform);
            platforms[i] = platform;
        }
	}

    // Update is called once per frame
    void Update() {
        if (person.newBackgroundPlatformLayerActive)
            setActivePlatform(person.currentPosition);
	}

    private void SetNextPlatfrom(Transform platform) {
        Vector3 scale = new Vector3(
			Random.Range(platformMinSize.x, platformMaxSize.x),
			Random.Range(platformMinSize.y, platformMaxSize.y),
			Random.Range(platformMinSize.z, platformMaxSize.z));
        
        platform.localPosition = currentPlatformPosition;
        platform.localScale = scale;
        currentPlatformPosition.x += scale.x + intervalBetweenPlatforms;
    }

    public void setActivePlatform(Vector3 position)
    {
        Debug.Log("setActivePlatform");
        if (prefab.localPosition.z == position.z)
        {
            Debug.Log("printing in active mat");
            Debug.Log(prefab.localPosition.z);
            for (int i = 0; i < numberOfPlatforms; i++)
            {
                Renderer vMesh = platforms[i].GetComponent("Renderer") as Renderer;
                vMesh.material = activeMaterial;
            }
        }
        else
        {
            Debug.Log("printing in inactive mat");
            Debug.Log(prefab.localPosition.z);
            for (int i = 0; i < numberOfPlatforms; i++)
            {
                Renderer vMesh = platforms[i].GetComponent("Renderer") as Renderer;
                vMesh.material = inActiveMaterial;
            }
        }
    }


}
