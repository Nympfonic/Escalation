using Mono.Cecil;

namespace EscalationPatcher
{
    internal static class PatcherHelper
    {
        private const FieldAttributes defaultFieldAttributes =
            FieldAttributes.Public | FieldAttributes.Static | FieldAttributes.Literal | FieldAttributes.HasDefault;

        internal static void AddEnumValues(ref TypeDefinition typeDef, params string[] names)
        {
            foreach (var name in names)
            {
                AddEnumValue(ref typeDef, name);
            }
        }

        internal static void AddEnumValue(ref TypeDefinition typeDef, string name)
        {
            var enumFields = typeDef.Fields;

            for (int i = 0; i < enumFields.Count; i++)
            {
                if (i + 1 > enumFields.Count - 1)
                {
                    EscalationPatcher.LogSource.LogError("Reached end of enum collection without adding new enum value.");
                    break;
                }

                int currentValue = (int)enumFields[i].Constant;
                int nextValue = (int)enumFields[i + 1].Constant;

                if (nextValue - currentValue > 1)
                {
                    enumFields.Add(new FieldDefinition(name, defaultFieldAttributes, typeDef)
                    {
                        Constant = currentValue + 1
                    });

                    break;
                }
            }
        }
    }
}
