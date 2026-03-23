namespace RoutingExample
{
    public class CustomConstraints : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (values.TryGetValue(routeKey, out var value) && value != null)
            {
                return value.ToString()?.StartsWith("A", StringComparison.OrdinalIgnoreCase) == true;
            }
            return false;
        }
    }
}
