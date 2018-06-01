using UnityEngine;

/// <summary>
/// Filter for static objects
/// \author Adik
/// </summary>
[System.Serializable]
public class FilterStaticObjects : ObjectsFilter
{
    public Biomes Biome;
    public Zones Zone;

    /// <summary>
    /// Objcet Dimensions
    /// </summary>
    public Vector3Int Dimensions = Vector3Int.one;

    public override string ToString()
    {
        return ($"Biome: {Biome}, Zone: {Zone}, Dimensions: {Dimensions}");
    }

    public override bool IsFilterMatching(ObjectsFilter filterToCheck)
    {
        FilterStaticObjects filter = (FilterStaticObjects)filterToCheck;
        bool isMatch = (Biome.HasFlag(filter.Biome)
                        && Zone.Equals(filter.Zone)
                        && Dimensions.Equals(filter.Dimensions));
        return isMatch;
    }
}
