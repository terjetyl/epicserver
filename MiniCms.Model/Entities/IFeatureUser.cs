using System.Collections.Generic;

namespace MiniCms.Model.Entities
{
    public interface IFeatureUser
    {
        string Username { get; set; }
        List<string> Groups { get; set; }
    }
}
