using UnityEngine;

/// <summary>
/// Filter for static objects
/// \author Adik
/// </summary>
[System.Serializable]
public class FilterLevelPart : ObjectsFilter
{
    public Biomes Biome;
    public Zones Zone;

    public override string ToString()
    {
        return ($"Biome: {Biome}, Zone: {Zone}");
    }

    public override bool IsFilterMatching(ObjectsFilter filterToCheck)
    {
        FilterLevelPart filter = (FilterLevelPart)filterToCheck;
        bool isMatch = (Biome.Equals(filter.Biome)
                        && Zone.Equals(filter.Zone));
        return isMatch;
    }
}
