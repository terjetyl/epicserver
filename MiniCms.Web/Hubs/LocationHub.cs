using System.Threading.Tasks;
using MiniCms.Web.Models.Entities;
using SignalR.Hubs;

namespace MiniCms.Web.Hubs
{
    public class LocationHub : Hub
    {
        public Task UpdateLocation(Location location)
        {
            return Clients.say(location);
        }
    }
}