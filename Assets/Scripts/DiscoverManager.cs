using System.Collections.Generic;
using UnityEngine;

public class DiscoverManager : MonoBehaviour
{
    public static DiscoverManager Instance;
    public HashSet<string> discoveredItems = new HashSet<string>();
    //Hashset du Discovering system
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

        }
        else
        {
            Destroy(gameObject); // doublon
        }


    }
}
