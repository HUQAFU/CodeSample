using UnityEngine;

/// <summary>
/// Loads prefab by link (like announced Unity's nested prefabs... Realy waiting for it...)
/// \author Adik
/// </summary>
public class PrefabLoader : MonoBehaviour {
    public GameObject PrefabLink;

    GameObject _loadedPrefab;

    #region Unity Messages
    private void OnEnable()
    {
        //DummyLoad
        LoadPrefab();
    }
    #endregion

    #region private Methods
    public GameObject LoadPrefab()
    {
        if (PrefabLink)
        {
            _loadedPrefab = Instantiate(PrefabLink, transform.position, transform.rotation, transform);
        }
        else {
            Debug.Log("Prefab is missing!", this);
        }
        return _loadedPrefab;
    }

    void UnloadPrefab()
    {
        Destroy(_loadedPrefab);
    }

    #endregion
}
