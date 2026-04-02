using Autofac;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;

namespace DependencyInjection.Controllers
{
    public class HomeController(ICitiesService citiesService1, ICitiesService citiesService2, ICitiesService citiesService3 , ILifetimeScope scopeFactory) : Controller
    {
        private readonly ICitiesService _citiesService1 = citiesService1;
        private readonly ICitiesService _citiesService2 = citiesService2;
        private readonly ICitiesService _citiesService3 = citiesService3;
        private readonly ILifetimeScope _lifetimeScope = scopeFactory;

        [Route("/")]
        public IActionResult Index()
        {
            //List<string> cities = _citiesService.GetCities();
            ViewBag.InstanceId1 = _citiesService1.ServiceInstanceId;
            ViewBag.InstanceId2 = _citiesService2.ServiceInstanceId;
            ViewBag.InstanceId3 = _citiesService3.ServiceInstanceId;
            using(ILifetimeScope scope = _lifetimeScope.BeginLifetimeScope())
            {
                var citiesService4 = scope.Resolve<ICitiesService>();
                ViewBag.InstanceId4 = citiesService4.ServiceInstanceId;
            }
            return View();

        }
    }
}
