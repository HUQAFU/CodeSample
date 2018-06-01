using UnityEngine;

/// <summary>
/// Base class of library objects
/// \author Adik
/// </summary>
public abstract class BaseObjectOfLibrary : MonoBehaviour
{
    public abstract ObjectsFilter GetFilter();
}
