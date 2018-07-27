namespace eclj.UtilityBelt
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;

    public static class TypeExtension
    {
        //  TODO: Enhance and document better
        public static object GetValueFromField(this Type type, string fieldName, object objectValue, BindingFlags bindingAttr)
        {
            var result = (object)null;

            var fieldInfo = type.GetField(fieldName, bindingAttr);

            if (fieldInfo != null)
                result = fieldInfo.GetValue(objectValue);

            return result;
        }
    }
}
