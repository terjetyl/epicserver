using MiniCms.Web.Models.Entities;
using SignalR.Hubs;

namespace MiniCms.Web.Hubs
{
    public class LocationHub : Hub
    {
        public void UpdateLocation(Location location)
        {
            Clients.say(location);
        }
    }
}