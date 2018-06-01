using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// Library of Static objects
/// \author Adik
/// </summary>
public class LibraryStaticObjects : BaseLibrary
{
    public override BaseObjectOfLibrary[] LoadLibrary()
    {
        return Resources.LoadAll<ObjectOfLibraryStatic>(Helper.Paths.OBJECTS_LIBRARY_STATIC_PATH);
    }

    public override IEnumerable<BaseObjectOfLibrary> SelectFromObjectsLibrary(ObjectsFilter filter)
    {
        IEnumerable < BaseObjectOfLibrary > objects = from prefab in _objectsLibrary
                                                      where ((ObjectOfLibraryStatic)prefab).GetFilter().IsFilterMatching((FilterStaticObjects)filter)
                                                      select prefab ;
        return objects;
    }
}
