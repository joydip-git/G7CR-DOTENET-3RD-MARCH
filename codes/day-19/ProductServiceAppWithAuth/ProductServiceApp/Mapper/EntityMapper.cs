using System.Reflection;

namespace ProductServiceApp.Mapper
{
    public class EntityMapper
    {
        public static TTarget Map<TSource, TTarget>(TSource source) where TTarget : class where TSource : class
        {
            //TTarget target = new();
            TTarget target = Activator.CreateInstance<TTarget>();

            Type sourceType = typeof(TSource);
            Type targetType = typeof(TTarget);

            PropertyInfo[] sourceProperties = sourceType.GetProperties();
            PropertyInfo[] targetProperties = targetType.GetProperties();

            foreach (PropertyInfo sourceProperty in sourceProperties)
            {
                PropertyInfo? targetProperty =
                    targetProperties
                    .ToList()
                    .Find(tp => tp.Name == sourceProperty.Name && tp.PropertyType == sourceProperty.PropertyType);

                if (targetProperty != null && targetProperty.CanWrite && sourceProperty.CanRead)
                {
                    var value = sourceProperty.GetValue(source);
                    targetProperty.SetValue(target, value);
                }
            }

            return target;
        }
    }
}
