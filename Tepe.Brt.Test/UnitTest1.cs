using Microsoft.Extensions.Configuration;
using Tepe.Brt.Business.Services;
using Tepe.Brt.Data.Entities;

namespace Tepe.Brt.Test
{
    public class UnitTest1
    {

        [Theory]
        [InlineData("arthur.chen330@gmail.com", "+1 9142652104")]
        public async Task Test1(string email, string phoneNumber)
        {
            try
            {

                Console.WriteLine($"Testing {email}");

                PatientEntity patients = new PatientEntity();
                patients.Email = email;
                patients.PhoneNumber = phoneNumber;

                var result = await _genericService.SavePatientDetail(patients);

            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}