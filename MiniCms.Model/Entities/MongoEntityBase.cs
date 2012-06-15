using System;

namespace MiniCms.Model.Entities
{
    public class MongoEntityBase
    {
        public MongoEntityBase()
        {
            Id = Guid.NewGuid();
            DateCreated = DateTime.Now;
        }

        //[BsonId]
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
