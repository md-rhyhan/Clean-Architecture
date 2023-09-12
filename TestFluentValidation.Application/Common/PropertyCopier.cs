namespace TestFluentValidation.Application.Common;

public static class PropertyCopier
{
    public static void Copy<TParent, TChild>(this TParent parent, TChild child)
       where TParent : class
        where TChild : class
    {
        var parentProperties = parent.GetType().GetProperties();
        var childProperties = child.GetType().GetProperties();

        foreach (var parentProp in parentProperties)
        {
            foreach (var childProp in childProperties)
            {
                if (parentProp.Name == childProp.Name && parentProp.PropertyType == childProp.PropertyType)
                {
                    childProp.SetValue(child, parentProp.GetValue(parent));
                    break;
                }
            }
        }
    }

}