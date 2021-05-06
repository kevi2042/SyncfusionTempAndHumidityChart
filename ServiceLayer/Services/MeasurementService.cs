using ServiceLayer.Constants;
using ServiceLayer.Models;
using ServiceLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class MeasurementService : IMeasurementService
    {
        private readonly IGenericRepository _repo;

        public MeasurementService(IGenericRepository repo)
        {
            _repo = repo;
        }

        public async Task<Measurement> GetMeasurementsAsync()
        {
            UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
            {
                Path = ApiConstants.MeasurementEndPoint,
                Query = ApiConstants.apikey
            };

            string urlkey = builder.ToString();

            Measurement measurements = await _repo.GetAsync<Measurement>(urlkey);
            //Saves to cache
            return measurements;
        }

        public async Task<Measurement> GetMeasurementAsync()
        {
            UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
            {
                Path = $"{ApiConstants.MeasurementEndPoint}",
                Query = ApiConstants.apikey + "&results=1"
            };
            return await _repo.GetAsync<Measurement>(builder.ToString());
        }

        public async Task<Measurement> GetMeasurementsAsync(string result)
        {
            UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
            {
                Path = ApiConstants.MeasurementEndPoint,
                Query = ApiConstants.apikey + "&results=" + result
            };

            string urlkey = builder.ToString();

            Measurement measurements = await _repo.GetAsync<Measurement>(urlkey);
            //Saves to cache
            return measurements;
        }

        //public async Task<bool> AddMeasurementAsync(Measurement measurement)
        //{
        //    UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
        //    {
        //        Path = ApiConstants.MeasurementEndPoint
        //    };
        //    await _repo.PostAsync(builder.ToString(), measurement);
        //    return true;
        //}

        //public async Task<bool> UpdateMeasurementAsync(Measurement measurement)
        //{
        //    UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
        //    {
        //        Path = $"{ApiConstants.MeasurementEndPoint}/{measurement.ID.ToString()}"
        //    };
        //    await _repo.PutAsync(builder.ToString(), measurement);
        //    return true;
        //}


        //public async Task<bool> DeleteMeasurementAsync()
        //{
        //    UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
        //    {
        //        Path = $"{ApiConstants.MeasurementEndPoint}"
        //    };
        //    await _repo.DeleteAsync(builder.ToString());
        //    return true;
        //}
    }
}
