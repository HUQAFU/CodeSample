using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;

/// <summary>
/// Stores objects library
/// \author Adik
/// </summary>
public abstract class BaseLibrary : MonoBehaviour
{
    public BaseObjectOfLibrary[] _objectsLibrary;

    #region Unity Messages
    /// <summary>
    /// Initializes object library
    /// </summary>
    void OnEnable ()
    {
        _objectsLibrary = LoadLibrary();
    }
    #endregion

    #region public Methods

    public abstract BaseObjectOfLibrary[] LoadLibrary();

    public GameObject TryGetRandomObjectByParams(ObjectsFilter filter)
    {

        if (_objectsLibrary == null)
        {
            Debug.LogWarning("_objectsLibrary is null!");
            return null;
        }

        IEnumerable<BaseObjectOfLibrary> tempObjects = SelectFromObjectsLibrary(filter);

        if (tempObjects.Count() > 0)
        {
            BaseObjectOfLibrary libraryObject = tempObjects.ElementAt(UnityEngine.Random.Range(0, tempObjects.Count()));
            return libraryObject.gameObject;
        }
        else
        {
            Debug.LogWarning($"No Objects with this filter: \n {filter.ToString()}");
            return null;
        }
    }

    public virtual IEnumerable<BaseObjectOfLibrary> SelectFromObjectsLibrary(ObjectsFilter filter)
    {
        return 
            from prefab in _objectsLibrary
            where (prefab.GetFilter().Equals(filter))
            select prefab;
    }

























    /*
    /// <summary>
    /// Get random Terrain from library that matches params
    /// </summary>
    /// <param name="terrainType"></param>
    /// <param name="biome"></param>
    /// <param name="zone"></param>
    /// <param name="activity"></param>
    /// <param name="spawnPosition"></param>
    /// <returns>Terrain from library by params. Returns null if no object with this params</returns>
    public static GameObject TryGetRandomTerrainByParams(TerrainTypes terrainType, Biomes biome, Zones zone, Activities activity, SpawnPositions spawnPosition)
    {

        if (_terrainObjectsLibrary == null)
        {
            Debug.LogWarning("_terrainObjectsLibrary is null!");
            return null;
        }
        IEnumerable<LibraryObjectTerrain> tempObjects =
     from prefab in _terrainObjectsLibrary
     where (prefab.TerrainType.Equals(terrainType)
         && prefab.Biome.HasFlag(biome)
         && prefab.Zone.Equals(zone)
         && prefab.Activity.Equals(activity)
         && prefab.SpawnPoition.Equals(spawnPosition))
     select prefab;
        if (tempObjects.Count() > 0)
        {
            LibraryObjectTerrain libraryObject = tempObjects.ElementAt(UnityEngine.Random.Range(0, tempObjects.Count()));
            return libraryObject.gameObject;
        }
        else
        {
            Debug.LogWarning($"No Terain with this params: \n TerrainTypes {terrainType},\n Biomes {biome},\n Zones {zone},\n Activities {activity},\n SpawnPositions {spawnPosition}");
            return null;
        }
    }

    /// <summary>
    /// Get random StaticObject from library that matches params
    /// </summary>
    /// <param name="biome"></param>
    /// <param name="zone"></param>
    /// <param name="dimensions"></param>
    /// <returns>StaticObject from library by params. Returns null if no object with this params</returns>
    public static GameObject TryGetRandomStaticObjectByParams(Biomes biome, Zones zone, Vector3Int dimensions)
    {
        if (_staticObjectsLibrary == null)
        {
            Debug.LogWarning("_staticObjectsLibrary is null!");
            return null;
        }
        IEnumerable<LibraryObjectStatic> tempObjects =
     from prefab in _staticObjectsLibrary
     where (prefab.Biome.HasFlag(biome)
         && prefab.Zone.Equals(zone)
         && prefab.Dimensions.Equals(dimensions))
     select prefab;
        if (tempObjects.Count() > 0)
        {
            LibraryObjectStatic libraryObject = tempObjects.ElementAt(UnityEngine.Random.Range(0, tempObjects.Count()));
            return libraryObject.gameObject;
        }
        else
        {
            Debug.LogWarning($"No StaticObject with this params: \n Biomes {biome},\n Zones {zone},\n Dimensions {dimensions}");
            return null;
        }
    }

    
    /// <summary>
    /// Get random DangerObject from library that matches params
    /// </summary>
    /// <param name="biome"></param>
    /// <param name="zone"></param>
    /// <param name="dimensions"></param>
    /// <returns>DangerObject from library by params. Returns null if no object with this params</returns>
    public static GameObject TryGetRandomDangerObjectByParams(Biomes biome, Zones zone, Vector3Int dimensions)
    {
        if (_dangerObjectsLibrary == null) {
            Debug.LogWarning("_dangerObjectsLibrary is null!");
            return null;
        }

        IEnumerable<LibraryObjectDanger> tempObjects =
     from prefab in _dangerObjectsLibrary
     where (prefab.Biome.HasFlag(biome)
         && prefab.Zone.Equals(zone)
         && prefab.Dimensions.Equals(dimensions))
     select prefab;
        if (tempObjects.Count() > 0)
        {
            LibraryObjectDanger libraryObject = tempObjects.ElementAt(UnityEngine.Random.Range(0, tempObjects.Count()));
            return libraryObject.gameObject;
        }
        else
        {
            Debug.LogWarning($"No DangerObject with this params: \n Biomes {biome},\n Zones {zone},\n Dimensions {dimensions}");
            return null;
        }
    }
    

    /// <summary>
    /// Get random DangerObject from library that matches params
    /// </summary>
    /// <param name="biome"></param>
    /// <param name="zone"></param>
    /// <param name="dimensions"></param>
    /// <returns>DangerObject from library by params. Returns null if no object with this params</returns>
    public static GameObject TryGetRandomEnemyByParams(Biomes biome, Zones zone)
    {
        if (_enemyObjectsLibrary == null)
        {
            Debug.LogWarning("_enemyObjectsLibrary is null!");
            return null;
        }
        IEnumerable<LibraryObjectEnemy> tempObjects =
     from prefab in _enemyObjectsLibrary
     where (prefab.Biome.HasFlag(biome)
         && prefab.Zone.Equals(zone))
     select prefab;
        if (tempObjects.Count() > 0)
        {
            LibraryObjectEnemy libraryObject = tempObjects.ElementAt(UnityEngine.Random.Range(0, tempObjects.Count()));
            return libraryObject.gameObject;
        }
        else
        {
            Debug.LogWarning($"No Enemy with this params: \n Biomes {biome},\n Zones {zone}");
            return null;
        }
    }
    */
    

    #endregion
}
