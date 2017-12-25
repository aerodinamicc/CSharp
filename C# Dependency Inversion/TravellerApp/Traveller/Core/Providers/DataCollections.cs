using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveller.Core.Contracts;
using Traveller.Models.Abstractions;
using Traveller.Models.Vehicles.Abstractions;

namespace Traveller.Core.Providers
{
    public class DataCollections : IDataCollections
    {
        private readonly List<IVehicle> vehicles;
        private readonly List<IJourney> journeys;
        private readonly List<ITicket> tickets;

        public DataCollections()
        {
            this.vehicles = new List<IVehicle>();
            this.journeys = new List<IJourney>();
            this.tickets = new List<ITicket>();
        }

        public IList<IVehicle> Vehicles
        {
            get
            {
                return this.vehicles;
            }
        }

        public IList<IJourney> Journeys
        {
            get
            {
                return this.journeys;
            }
        }

        public IList<ITicket> Tickets
        {
            get
            {
                return this.tickets;
            }
        }
    }
}
