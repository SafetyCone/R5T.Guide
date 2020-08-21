using System;

using R5T.Guide;


namespace System
{
    /// <summary>
    /// Functionality put into the <see cref="System"/> namespace to make sure that these extensions are available everywhere you might have a <see cref="TypedGuid"/>.
    /// </summary>
    public static class TypedGuidExtensions
    {
        public static bool IsEmpty(this TypedGuid typedGuid)
        {
            var isEmpty = typedGuid.Value == Guid.Empty;
            return isEmpty;
        }
    }
}
