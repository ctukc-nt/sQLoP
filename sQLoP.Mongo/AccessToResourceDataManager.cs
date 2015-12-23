using Mongo.Common;
using MongoDB.Driver;
using sQLoP.Core;

namespace sQLoP.Mongo
{
    public class AccessToResourceDataManager : NamedSimpleMongoDbDataManager<AccessToResource>
    {
        public AccessToResourceDataManager(IMongoDataBaseWithUser db, string name) : base(db, name)
        {
        }

        public override void Insert(AccessToResource doc)
        {
            var filterBuilder = Builders<AccessToResource>.Filter;

            var filterTime = filterBuilder.Eq(resource => resource.Time, doc.Time);
            var filterHost = filterBuilder.Eq(resource => resource.RemoteHost, doc.RemoteHost);
            var filterUrl = filterBuilder.Eq(resource => resource.URL, doc.URL);

            var agrFilter = filterBuilder.And(filterTime, filterHost, filterUrl);

            var collection = GetCollection();
            var doubled = collection.Find(agrFilter).FirstOrDefaultAsync().Result;
            if (doubled == null)
                base.Insert(doc);
        }
    }


}