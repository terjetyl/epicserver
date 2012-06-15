using MiniCms.Model.Entities;
using MiniCms.Model.Repositories;

namespace MiniCms.Model
{
    public class FeatureService
    {
        private readonly IFeatureRepository _featureRepository;
        public FeatureService(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }

        public Feature EnableNewsletter
        {
            get { return GetFeatureByName("EnableNewsletter"); }
        }

        public Feature EnableTaggableContent
        {
            get { return GetFeatureByName("EnableTaggableContent"); }
        }

        public Feature EnableUserLogin
        {
            get { return GetFeatureByName("EnableUserLogin"); }
        }

        public Feature EnableCommentsOnContent
        {
            get { return GetFeatureByName("EnableCommentsOnContent"); }
        }

        public Feature EnableSearch
        {
            get { return GetFeatureByName("EnableSearch"); }
        }

        public Feature GetFeatureByName(string name)
        {
            return _featureRepository.GetByName(name);
        }
    }
}
