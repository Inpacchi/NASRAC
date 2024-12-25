using System.Linq.Expressions;
using Castle.DynamicProxy;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.EntityFrameworkCore;

namespace NASRAC.Data.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<TDestination> MapProperties<TSource, TDestination>(this IQueryable<TSource> source)
            where TDestination : new()
        {
            var sourceType = typeof(TSource);
            var destinationType = typeof(TDestination);

            // Create a parameter expression for the source object.
            var sourceParameter = Expression.Parameter(sourceType, "source");

            // Create a new expression for the destination object.
            var newExpression = Expression.New(destinationType);

            // Get the properties of the source and destination types.
            var sourceProperties = sourceType.GetProperties();
            var destinationProperties = destinationType.GetProperties();

            // Create a list of member bindings for the destination object.
            var bindings = new List<MemberBinding>();

            foreach (var destinationProperty in destinationProperties)
            {
                // Find the corresponding property in the source object.
                var sourceProperty = sourceProperties.FirstOrDefault(p => p.Name == destinationProperty.Name);

                if (sourceProperty != null)
                {
                    // If the property is a complex type, map it recursively.
                    if (!destinationProperty.PropertyType.IsValueType && destinationProperty.PropertyType != typeof(string))
                    {
                        // Get the generic MapChildren method.
                        var mapChildrenMethod = typeof(QueryableExtensions).GetMethod(nameof(MapChildren), System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);

                        // Create a generic method for the specific types.
                        var genericMapChildrenMethod = mapChildrenMethod.MakeGenericMethod(sourceProperty.PropertyType, destinationProperty.PropertyType);

                        var entityType = Expression.Condition(
                            Expression.TypeIs(sourceParameter, typeof(IProxyTargetAccessor)),
                            Expression.Call(
                                Expression.Convert(sourceParameter, typeof(IProxyTargetAccessor)), 
                                typeof(IProxyTargetAccessor).GetMethod("DynProxyGetTarget")
                            ),
                            sourceParameter
                        );

                        // Create an expression to call the MapChildren method.
                        var mapChildrenExpression = Expression.Call(genericMapChildrenMethod, Expression.Property(entityType, sourceProperty));

                        // Add a member binding for the complex property.
                        bindings.Add(Expression.Bind(destinationProperty, mapChildrenExpression));
                    }
                    else
                    {
                        // If the property is a simple type, map it directly.
                        var sourcePropertyExpression = Expression.Property(sourceParameter, sourceProperty);

                        // Add a member binding for the simple property.
                        bindings.Add(Expression.Bind(destinationProperty, sourcePropertyExpression));
                    }
                }
            }

            // Create a member initialization expression for the destination object.
            var memberInitExpression = Expression.MemberInit(newExpression, bindings);

            // Create a lambda expression that maps the source object to the destination object.
            var lambdaExpression = Expression.Lambda<Func<TSource, TDestination>>(memberInitExpression, sourceParameter);

            // Apply the lambda expression to the source queryable.
            return source.Select(lambdaExpression);
        }

        private static TDestinationChild MapChildren<TSourceChild, TDestinationChild>(TSourceChild source)
            where TDestinationChild : new()
        {
            if (source == null)
            {
                return default(TDestinationChild);
            }

            // Create a new instance of the destination child type.
            var destination = new TDestinationChild();
            
            var entityType = source is IProxyTargetAccessor proxy 
                ? proxy.DynProxyGetTarget().GetType().BaseType
                : source.GetType();

            // Get the properties of the source and destination child types.
            var sourceProperties = entityType.GetProperties(); // Use source.GetType()
            var destinationProperties = typeof(TDestinationChild).GetProperties();

            foreach (var destinationProperty in destinationProperties)
            {
                // Find the corresponding property in the source child object.
                var sourceProperty = sourceProperties.FirstOrDefault(p => p.Name == destinationProperty.Name);

                if (sourceProperty != null)
                {
                    // Get the value of the source property.
                    var value = sourceProperty.GetValue(source);

                    // Set the value of the destination property.
                    destinationProperty.SetValue(destination, value);
                }
            }

            return destination;
        }
    }
}