using System.Collections.Generic;
using TripServiceKata.Exception;
using TripServiceKata.User;

namespace TripServiceKata.Trip
{
    public class TripService
    {
        public List<Trip> GetTripsByUser(User.User user)
        {
            var tripList   = new List<Trip>();
            var loggedUser = GetLoggedUser();
            var isFriend   = false;

            if (loggedUser is null)
            {
                throw new UserNotLoggedInException();
            }

            foreach (var friend in user.GetFriends())
            {
                // ReSharper disable once InvertIf
                if (friend.Equals(loggedUser))
                {
                    isFriend = true;
                    break;
                }
            }

            if (isFriend)
            {
                tripList = TripDAO.FindTripsByUser(user);
            }

            return tripList;
        }

        protected virtual User.User GetLoggedUser()
        {
            return UserSession.GetInstance().GetLoggedUser();
        }
    }
}