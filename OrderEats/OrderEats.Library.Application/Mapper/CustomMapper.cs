using OrderEats.Library.Application.Interfaces;
using OrderEats.Library.Models.DTO;
using OrderEats.Library.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderEats.Library.Application.Mapper
{
    //public class CustomMapper<TSource, TDestination> : IMapper<TSource, TDestination>
    //{
    //    // Phương thức này không cần khai báo lại <TSource, TDestination>
    //    public virtual TDestination Map(TSource source)
    //    {
    //        if (source == null)
    //            return default;

    //        var destination = Activator.CreateInstance<TDestination>();
    //        var sourceProperties = typeof(TSource).GetProperties();
    //        var destinationProperties = typeof(TDestination).GetProperties();

    //        foreach (var sourceProperty in sourceProperties)
    //        {
    //            var destinationProperty = destinationProperties.FirstOrDefault(p => p.Name == sourceProperty.Name && p.CanWrite);
    //            if (destinationProperty != null)
    //            {
    //                // Kiểm tra xem thuộc tính có phải là một collection (List, Array, v.v.)
    //                if (sourceProperty.PropertyType.IsGenericType && sourceProperty.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
    //                {
    //                    var sourceList = (IEnumerable<object>)sourceProperty.GetValue(source);
    //                    var destinationList = Activator.CreateInstance(destinationProperty.PropertyType) as IList<object>;

    //                    foreach (var item in sourceList)
    //                    {
    //                        var itemType = destinationProperty.PropertyType.GetGenericArguments()[0];
    //                        var mappedItem = Map(item, itemType, Activator.CreateInstance(itemType)); // Phương thức map cho từng item
    //                        destinationList.Add(mappedItem);
    //                    }

    //                    destinationProperty.SetValue(destination, destinationList);
    //                }
    //                else if (destinationProperty.PropertyType.IsClass && destinationProperty.PropertyType != typeof(string))
    //                {
    //                    var nestedValue = Map(sourceProperty.GetValue(source), destinationProperty.PropertyType, Activator.CreateInstance(destinationProperty.PropertyType));
    //                    destinationProperty.SetValue(destination, nestedValue);
    //                }
    //                else
    //                {
    //                    destinationProperty.SetValue(destination, sourceProperty.GetValue(source));
    //                }
    //            }
    //        }

    //        return destination;
    //    }

    //    private object Map(object sourceObject, Type destinationType, object destinationObject)
    //    {
    //        // Cập nhật cách gọi phương thức Map
    //        var mapMethod = typeof(CustomMapper<TSource, TDestination>).GetMethod("Map", new[] { sourceObject.GetType() });
    //        return mapMethod?.Invoke(this, new[] { sourceObject });
    //    }

    //    public List<TDestination> MapList(IEnumerable<TSource> source)
    //    {
    //        return source.Select(item => Map(item)).ToList();
    //    }

    //}
}
