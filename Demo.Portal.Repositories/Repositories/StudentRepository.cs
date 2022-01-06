using Demo.Portal.Repositories;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Demo.Portal.Common;
using Demo.Portal.Common.Dtos;
using Demo.Portal.Common.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Demo.Portal.Repositories
{
    public class StudentRepository : ApiRepositoryBase,IStudentRepository
    {
        private readonly ILogger<StudentRepository> _logger;


        public StudentRepository(ILogger<StudentRepository> logger, HttpClient httpClient, IOptions<ApiClientSettings> apiSettings):base(httpClient, apiSettings)
        {
            this.EndpointName = ApiEndpoints.Students;
            this._logger = logger;
        }

       
        public async Task<StudentDto> AddStudent(CreateStudentDto studentDto)
        {
            try
            {
                var result = new StudentDto();
                var token = await this.HttpClient.GetAsync("Security");
                var tokendata = await token.Content.ReadAsStringAsync();
                this.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokendata);
                var content = new StringContent(JsonConvert.SerializeObject(studentDto), Encoding.UTF8, "application/json");
                var response = await this.HttpClient.PostAsync(this.EndpointName + $"/AddData", content);
                if (response.IsSuccessStatusCode)
                {
                    result = JsonConvert.DeserializeObject<StudentDto>(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    var msg = $"API Call Failure in: {nameof(this.GetStudents)}. HTTP Status: {response.StatusCode}. Message: {response.ReasonPhrase}.";
                }

                return result;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"Exception: {nameof(this.GetStudents)}: {ex.Message}");
                throw;
            }
        }

        public async Task<IList<StudentDto>> GetStudents()
        {
            try
            {
                var result = new List<StudentDto>();
                var token = await this.HttpClient.GetAsync("Security");
                var tokendata = await token.Content.ReadAsStringAsync();
                this.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokendata);
                var response = await this.HttpClient.GetAsync(this.EndpointName+$"/StudentsData");
                if (response.IsSuccessStatusCode)
                {
                    result = JsonConvert.DeserializeObject<List<StudentDto>>(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    var msg = $"API Call Failure in: {nameof(this.GetStudents)}. HTTP Status: {response.StatusCode}. Message: {response.ReasonPhrase}.";
                }

                return result;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"Exception: {nameof(this.GetStudents)}: {ex.Message}");
                throw;
            }

        }
    }
}
