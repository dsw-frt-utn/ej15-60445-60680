namespace Dsw2026Ej15.Api.Models
{
    public record DoctorModel
    {
        internal class Response
        {
            public string Name { get; set; }
            public string LicenseNumber { get; set; }
            public string? SpecialityName { get; set; }

            public Response(
                string name,
                string licenseNumber,
                string? specialityName)
            {
                Name = name;
                LicenseNumber = licenseNumber;
                SpecialityName = specialityName;
            }
        }

        public record Request(string Name, string LicenseNumber, Guid SpecialityId);//estructura del body del endpoint
    }
}
