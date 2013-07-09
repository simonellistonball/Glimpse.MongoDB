using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glimpse.Core.Extensibility;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Glimpse.MongoDB
{
    class GlimpseMongoSerializationConverter : ISerializationConverter
    {
        public IEnumerable<Type> SupportedTypes { get { return new[] { typeof(SystemProfileInfo) }; } }

        public object Convert(object target)
        {

            return ((SystemProfileInfo)target).ToJson();
        }

    }
}
