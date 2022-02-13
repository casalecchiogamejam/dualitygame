using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class VolumeSwitcher : MonoBehaviour
{
    public List<Volume> volumesPrefab;

    Volume activeVolume;

    public int defaultVolume = 0;

    void Start()
    {
        SetVolume(defaultVolume);
    }

    public void SetVolume(int volumeIndex)
    {
        Debug.Log("Set volume " + volumeIndex);
        if (activeVolume != null)
            Destroy(activeVolume.gameObject);
        activeVolume = Instantiate(volumesPrefab[volumeIndex], transform);
    }

}
