using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public interface IMeasurementService
    {
        Task<Measurement> GetMeasurementsAsync();
        //Task<bool> AddMeasurementAsync(Measurement measurement);
        //Task<bool> UpdateMeasurementAsync(Measurement measurement);
        //Task<bool> DeleteMeasurementAsync();
        Task<Measurement> GetMeasurementAsync();
        Task<Measurement> GetMeasurementsAsync(string result);
    }
}
