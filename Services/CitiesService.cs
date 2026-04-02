using ServiceContracts;

namespace Services
{
    public class CitiesService : ICitiesService , IDisposable
    {
        private readonly List<string> _cities;

        private readonly Guid _servieInstanceId;

        public Guid ServiceInstanceId
        {
            get
            {
                return _servieInstanceId;
            }
        }

        public CitiesService()
        {
            _servieInstanceId = Guid.NewGuid();
            _cities =
            [
                "London",
                "Paris",
                "New York",
                "Tokyo",
                "Rome"
            ];
        }

        public List<string> GetCities()
        {
            return _cities;
        }

        public void Dispose()
        {
        }
    }
}