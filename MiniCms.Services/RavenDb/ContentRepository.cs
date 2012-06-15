using MiniCms.Model.Entities;
using MiniCms.Model.Repositories;

namespace MiniCms.Services.RavenDb
{
    public class ContentRepository : RavenRepositoryBase<EditableContent>, IContentRepository
    {
        public ContentRepository() : base("editablecontents-")
        {
        }
    }
}
