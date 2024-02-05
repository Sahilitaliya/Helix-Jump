using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicComan : MonoBehaviour
{
    public static MusicComan instance;

    public bool IsMusic, IsSound;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}