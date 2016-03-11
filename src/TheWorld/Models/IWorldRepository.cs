using System.Collections.Generic;

namespace TheWorld.Models
{
    public interface IWorldRepository
    {
        IEnumerable<Trip> GetAllTrips();
        IEnumerable<Trip> GetAllTripsWithStops();
        bool SaveAll();
        void AddTrip(Trip newTrip);
        Trip GetTripByName(string tripName, string userName);
        void AddStop(string tripName, Stop newStop, string userName);
        IEnumerable<Trip> GetUserTripsWithStops(string name);
    }
}