using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

//inRange fucntion
public static class IComparableExtension
{
    public static bool InRange<T>(this T value, T from, T to) where T : IComparable<T>
    {
        return value.CompareTo(from) >= 1 && value.CompareTo(to) <= -1;
    }
}


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

    void Update() {
        if (person.newBackgroundPlatformLayerActive)
            setActivePlatform(person.currentPosition);
	}

    private void SetNextPlatfrom(Transform platform) {
        Vector3 scale = new Vector3(
			UnityEngine.Random.Range(platformMinSize.x, platformMaxSize.x),
            UnityEngine.Random.Range(platformMinSize.y, platformMaxSize.y),
			7);
        
        platform.localPosition = currentPlatformPosition;
        platform.localScale = scale;
        currentPlatformPosition.x += scale.x + intervalBetweenPlatforms;
    }

    public void setActivePlatform(Vector3 position)
    {
        Debug.Log("setActivePlatform");
        if (position.z.InRange(prefab.localPosition.z - 3.5f,  prefab.localPosition.z + 3.5f))
        {
            Debug.Log("printing in active mat");
            Debug.Log(prefab.localPosition.z);
            for (int i = 0; i < numberOfPlatforms; i++)
            {
                Renderer vMesh = platforms[i].renderer;
                vMesh.material = activeMaterial;
            }
        }
        else
        {
            Debug.Log("printing in inactive mat");
            Debug.Log(prefab.localPosition.z);
            Debug.Log(position.z);
            for (int i = 0; i < numberOfPlatforms; i++)
            {
                Renderer vMesh = platforms[i].renderer;
                vMesh.material = inActiveMaterial;
            }
        }
    }


}
