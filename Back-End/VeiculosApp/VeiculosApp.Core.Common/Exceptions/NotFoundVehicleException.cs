namespace VeiculosApp.Core.Common.Exceptions
{
    public class NotFoundVehicleException : BusinessException
    {
        public NotFoundVehicleException(string message) : base(message) { }
    }
}
