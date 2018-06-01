using UnityEngine;

/// <summary>
/// Contains all info about concrete LevelPart
/// \authors Adik
/// </summary>
public class LevelPart : MonoBehaviour
{
    /// <summary>
    /// Level part ID (for analytics and etc)
    /// </summary>
    public string Id;

    /// Level Part Filter (sets from LevelDesigner)
    public FilterLevelPart PartFilter;
}
