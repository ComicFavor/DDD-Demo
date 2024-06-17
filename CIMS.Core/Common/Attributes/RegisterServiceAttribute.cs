namespace CIMS.Core.Common.Attributes
{
    public class RegisterServiceAttribute: Attribute
    {
        public ServiceLifetime ServiceLifetime { get; }

        public RegisterServiceAttribute(ServiceLifetime serviceLifetime)
        {
            ServiceLifetime = serviceLifetime;
        }
    }
}
