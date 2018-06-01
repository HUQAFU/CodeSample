using UnityEngine;

/// <summary>
/// Helpers 
/// \author Adik
/// </summary>

public static class Helper
{
    #region Static

    /// <summary>
    /// Destroy childs Transform extension method
    /// </summary>
    /// <param name="transform"></param>
    public static void DestroyChilds(this Transform transform)
    {
        int childs = transform.childCount;
        for (int i = childs - 1; i >= 0; i--)
        {
            if (!Application.isPlaying)
            {
#if UNITY_EDITOR
                MonoBehaviour.DestroyImmediate(transform.GetChild(i).gameObject);
#endif
            }
            else
            {
                MonoBehaviour.Destroy(transform.GetChild(i).gameObject);
            }
        }
    }
    #endregion

    public static class Paths
    {
        public const string OBJECTS_LIBRARY_STATIC_PATH = "Objects Library/Static";
        //etc.
    }
}

