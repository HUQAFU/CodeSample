using UnityEngine;

/// <summary>
/// Bace class for custom replacers
/// \author Adik
/// </summary>
public abstract class ReplaceableObject : MonoBehaviour
{
    /// <summary>
    /// if object Predefined 
    /// </summary>
    public bool Predefined;

    public GameObject Prefab;
    /// <summary>
    /// Returns specified prefab
    /// </summary>
    /// <returns>prefab</returns>
    GameObject TryGetPrefab()
    {
        if (Predefined)
        {
            return Prefab;
        }
        else
        {
            Prefab = TryGetPrefabFromLibrary();
            return Prefab;
        }
    }

    /// <summary>
    /// Get prefab from library by filter
    /// </summary>
    /// <returns>prefab</returns>
    public abstract GameObject TryGetPrefabFromLibrary();


    #region Unity Messages
    void Start()
    {
        GameObject prefab = TryGetPrefab();
        if (prefab)
        {
            transform.DestroyChilds();
            Instantiate(prefab, transform.position, transform.rotation, transform);
        }
    }
    #endregion
}
