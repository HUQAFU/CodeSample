/// <summary>
/// Base class of filters
/// \author Adik
/// </summary>
[System.Serializable]
public abstract class ObjectsFilter{
    public abstract bool IsFilterMatching(ObjectsFilter filterToCheck);
}
