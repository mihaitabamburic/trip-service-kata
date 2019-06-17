using System.Collections.Generic;

namespace TripServiceKata.User
{
    public sealed class User
    {
        private readonly List<Trip.Trip> trips   = new List<Trip.Trip>();
        private readonly List<User>      friends = new List<User>();

        public IEnumerable<User> GetFriends()
        {
            return friends;
        }

        public void AddFriend(User user)
        {
            friends.Add(user);
        }

        public void AddTrip(Trip.Trip trip)
        {
            trips.Add(trip);
        }

        public List<Trip.Trip> Trips()
        {
            return trips;
        }
    }
}