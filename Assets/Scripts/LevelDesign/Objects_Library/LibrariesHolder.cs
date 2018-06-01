using UnityEngine;

/// <summary>
/// Instansiates Library of static objects
/// \author Adik
/// </summary>
public class LibrariesHolder : MonoBehaviour {
    public static LibraryStaticObjects StaticObjects { get; private set; }
    [SerializeField] bool _dontDestroyOnLoad = false;

    protected void Awake()
    {
        if (_dontDestroyOnLoad)
        {
            DontDestroyOnLoad(gameObject);
        }

        if (StaticObjects != null)
        {
            Destroy(gameObject.GetComponent<LibraryStaticObjects>());
        }
        else
        {
            StaticObjects = gameObject.AddComponent<LibraryStaticObjects>();
        }
    }
}
