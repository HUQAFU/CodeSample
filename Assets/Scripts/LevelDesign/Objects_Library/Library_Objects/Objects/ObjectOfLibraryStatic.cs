/// <summary>
/// BaseClass of all Static Library objects
/// \author Adik
/// </summary>
public class ObjectOfLibraryStatic : BaseObjectOfLibrary
{
    public FilterStaticObjects ObjectsFilter;

    public override ObjectsFilter GetFilter()
    {
        return ObjectsFilter;
    }
}
