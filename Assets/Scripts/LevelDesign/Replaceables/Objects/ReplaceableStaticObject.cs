using UnityEngine;

/// <summary>
/// Custom replacible class for static objects
/// \author Adik
/// </summary>
public class ReplaceableStaticObject : ReplaceableObject
{
    public FilterStaticObjects Filter;

    public override GameObject TryGetPrefabFromLibrary()
    {
        LevelPart levelPart = GetComponentInParent<LevelPart>();
        if (levelPart)
        {
            Filter.Biome = levelPart.PartFilter.Biome;
            Filter.Zone = levelPart.PartFilter.Zone;
            return LibrariesHolder.StaticObjects?.TryGetRandomObjectByParams(Filter);
        }
        else
        {
            return null;
        }
    }
}
