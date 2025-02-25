using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Clothes.Domain.Extensions;

public static class EnumExtensions
{
    /// <summary>
    ///     A generic extension method that aids in reflecting 
    ///     and retrieving any attribute that is applied to an `Enum`.
    /// </summary>
    public static TAttribute? GetAttribute<TAttribute>(this Enum enumValue) 
        where TAttribute : Attribute
    {
        return enumValue.GetType()
            .GetMember(enumValue.ToString())
            .First()
            .GetCustomAttribute<TAttribute>();
    }
    
    /// <summary>
    /// If <paramref name="Enum"/> has <see cref="DisplayAttribute"/> defined, this will return <see cref="DisplayAttribute.Name"/>. Otherwise, <see langword="null" /> will be returned.
    /// </summary>
    /// <returns><see cref="string"/> containing <see cref="DisplayAttribute.Name"/> if defined. Otherwise, will return <see langword="null" /></returns>
    public static string? GetDisplayName<T>(this T Enum) where T : Enum
        => Enum.GetEnumAttribute<T, DisplayAttribute>()?.Name;
    
    /// <summary>
    /// If <paramref name="Enum"/> has <see cref="DisplayAttribute"/> defined, this will return <see cref="DisplayAttribute.Description"/>. Otherwise, <see langword="null" /> will be returned.
    /// </summary>
    /// <returns><see cref="string"/> containing <see cref="DisplayAttribute.Description"/> if defined. Otherwise, will return <see langword="null" /></returns>
    public static string? GetDescription<T>(this T Enum) where T : Enum
        => Enum.GetEnumAttribute<T, DisplayAttribute>()?.Description;
    
    /// <summary>
    /// Returns <see cref="DisplayAttribute"/> from <paramref name="Enum"/> if defined. Otherwise will return <see langword="null" />.
    /// </summary>
    public static DisplayAttribute? GetDisplayAttribute<T>(this T Enum) where T : Enum
        => Enum.GetEnumAttribute<T, DisplayAttribute>();
    
    private static TAttribute? GetEnumAttribute<TEnum, TAttribute>(this TEnum Enum)
        where TEnum : Enum
        where TAttribute :Attribute
    {
        var memberInfo = typeof(TEnum).GetMember(Enum.ToString());
        return memberInfo[0].GetCustomAttribute<TAttribute>();
    }
}