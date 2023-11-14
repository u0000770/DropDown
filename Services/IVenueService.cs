

namespace DropDown.Services
{
    public interface IVenueService
    {
        Task<List<EventTypeDTO>> getEventTypes();
        Task<EventTypeDTO> getEventType(string id);
    }

    public class VenueService : IVenueService
    {
        private HttpClient venuesClient;

        public VenueService() {
            venuesClient = new();
            venuesClient.BaseAddress = new System.Uri("https://thamcovenues.azurewebsites.net/");
            venuesClient.DefaultRequestHeaders.Accept.ParseAdd("application/json");

        }

        public async Task<EventTypeDTO> getEventType(string id)
        {
            var eventTypes = await getEventTypes();

            return eventTypes.Find(et => et.Id == id);
        }

        public async Task<List<EventTypeDTO>> getEventTypes()
        {
            var eventTypes = new List<EventTypeDTO>().AsEnumerable();


            HttpResponseMessage response = await venuesClient.GetAsync("api/eventtypes");

            if (response.IsSuccessStatusCode)
            {
                eventTypes = await response.Content.ReadAsAsync<IEnumerable<EventTypeDTO>>();
            }
            else
            {
                throw new ApplicationException("Something went wrong callling the EventType api:" + response.ReasonPhrase);
            }

            return eventTypes.ToList();
        }


    }
}
