using System;
using System.Collections.Generic;
using System.Linq;

using R5T.Guide;


// In the System namespace to allow referencing the R5T.Guide library to be enough indication-of-interest in the extension methods (since by habit System is always used in code files).
namespace System
{
    /// <summary>
    /// Functionality put into the <see cref="System"/> namespace to make sure that these extensions are available everywhere you might have a <see cref="TypedGuid"/>.
    /// </summary>
    public static class TypedGuidExtensions
    {
        public static IEnumerable<Guid> DistinctValues<TTypedGuid>(this IEnumerable<TTypedGuid> typedGuids)
            where TTypedGuid : TypedGuid
        {
            var output = typedGuids.Select(x => x.Value).Distinct();
            return output;
        }

        public static bool IsEmpty(this TypedGuid typedGuid)
        {
            var isEmpty = typedGuid.Value == Guid.Empty;
            return isEmpty;
        }

        public static IEnumerable<TTypedGuid> ToType<TTypedGuid>(this IEnumerable<Guid> guids, Func<Guid, TTypedGuid> constructor)
        {
            var output = guids.Select(x => constructor(x));
            return output;
        }
    }
}
