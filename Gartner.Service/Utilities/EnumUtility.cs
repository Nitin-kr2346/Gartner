using System;

namespace Gartner.Service.Utilities
{
    public static class EnumUtility
    {
        /// <summary>
        /// Gets the enum from the string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns>Generic Type</returns>
        public static T GetEnum<T>(string value) where T : struct => Enum.TryParse(value, true, out T val) ? val : default;
    }
}
