using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FleetManagement.Tests.Service
{
    public static class PropertyComparer
    {
        public static bool IsEqual(object self, object to)
        {
            if (self != null && to != null)
            {
                Type type = self.GetType();
                foreach (PropertyInfo pi in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    object selfValue=null;
                    object toValue=null;
                    try
                    {
                        selfValue = type.GetProperty(pi.Name).GetValue(self, null);
                        toValue = type.GetProperty(pi.Name).GetValue(to, null);
                    }
                    catch (TargetParameterCountException e)
                    {

                    }

                    if (selfValue != toValue && (selfValue == null || !selfValue.Equals(toValue)))
                    {
                        return false;
                    }
                }
                foreach (PropertyInfo pi in type.BaseType.GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    object selfValue = null;
                    object toValue = null;
                    try
                    {
                        selfValue = type.GetProperty(pi.Name).GetValue(self, null);
                        toValue = type.GetProperty(pi.Name).GetValue(to, null);
                    }
                    catch (TargetParameterCountException e)
                    {

                    }

                    if (selfValue != toValue && (selfValue == null || !selfValue.Equals(toValue)))
                    {
                        return false;
                    }
                }
                return true;
            }
            return self == to;
        }

        public static bool AreEqual<T>(List<T> self, List<T> to) where T : class
        {
            if (self == null || to == null || self.Count<=0 || to.Count<=0 || self.Count!=to.Count)
                return false;

            var compareList = to.ToList();
            foreach (var s in self)
            {
                var compareList2 = compareList.ToList();
                foreach (var c in compareList2)
                {
                    if (IsEqual(s, c))
                    {
                        compareList.Remove(c);
                        break;
                    }                        
                }
            }
            return compareList.Count == 0;
        }
    }
}
