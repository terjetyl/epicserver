using System.Collections.Generic;
using System.Linq;

namespace MiniCms.Model.Entities
{
    public class Feature : EntityBase
    {
        public Feature()
        {
            EnabledForGroups = new List<string>();
            EnabledForUsers = new List<string>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public FeatureSwitchStatus FeatureSwitchStatus { get; set; }
        public int Type { get; set; }
        public List<string> EnabledForGroups { get; set; }
        public List<string> EnabledForUsers { get; set; }
        public string UserStories { get; set; }
        public List<string> Tags { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }

        public bool IsEnabledForUser(IFeatureUser user)
        {
            if (FeatureSwitchStatus == FeatureSwitchStatus.Disabled)
                return false;
            if (FeatureSwitchStatus == FeatureSwitchStatus.EnabledForAll)
                return true;
            if (FeatureSwitchStatus == FeatureSwitchStatus.EnabledForAuthenticatedUsers)
            {
                if (user != null)
                    return true;
                return false;
            }
            if (FeatureSwitchStatus == FeatureSwitchStatus.EnabledForSpecifiedUsersOrGroups)
            {
                if (EnabledForUsers.Any(o => o == user.Username))
                    return true;
                if (EnabledForGroups.Any(o => user.Groups.Any(i => i == o)))
                    return true;
                return false;
            }
            return false;
        }

        public bool UsersCanVote { get; set; }

        public string Requirements { get; set; }

        public bool EnableForAll { get; set; }

        public bool EnableForAuthenticatedUsers { get; set; }

        public string FeatureKey { get; set; }

        public bool PublishToReleaseLog { get; set; }

        public FeatureStatus Status { get; set; }
    }

    public enum FeatureStatus
    {
        ToDo = 1, InProgress = 2, Done = 3
    }
    public enum FeatureSwitchStatus
    {
        Disabled = 0, EnabledForAll = 1, EnabledForAuthenticatedUsers = 2, EnabledForSpecifiedUsersOrGroups = 3
    }
}
