using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json.Serialization;

namespace Tonesoft.Settings
{
    class StaticPropertyContractResolver : DefaultContractResolver
    {
        protected override List<MemberInfo> GetSerializableMembers(Type objectType)
        {
            var baseMembers = base.GetSerializableMembers(objectType);
            var staticMembers =
                objectType.GetProperties(BindingFlags.Static | BindingFlags.Public);
            baseMembers.AddRange(staticMembers);
            return baseMembers;
        }
    }
}
