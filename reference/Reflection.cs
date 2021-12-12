using System;
using System.Reflection;

namespace ReflectionUtility
{
    public static class Reflection
    {
        public static object CallMethod(this object o, string methodName, params object[] args)
        {
            MethodInfo method = o.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);
            bool flag = method != null;
            object result;
            if (flag)
            {
                result = method.Invoke(o, args);
            }
            else
            {
                result = null;
            }
            return result;
        }
   
        public static object CallStaticMethod(Type type, string methodName, params object[] args)
        {
            MethodInfo method = type.GetMethod(methodName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            return method.Invoke(null, args);
        }
   
        public static object GetField(Type type, object instance, string fieldName)
        {
            BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
            FieldInfo field = type.GetField(fieldName, bindingAttr);
            return field.GetValue(instance);
        }
   
        public static void SetField<T>(object originalObject, string fieldName, T newValue)
        {
            BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
            FieldInfo field = originalObject.GetType().GetField(fieldName, bindingAttr);
            field.SetValue(originalObject, newValue);
        }
    }
}
