using AutoMapper;
using BusinessLayer.Model.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        private readonly ILogger _log;
        // GET api/<controller>
        public EmployeeController(IEmployeeService employeeService, IMapper mapper, ILogger log)
        {
            _employeeService = employeeService;
            _mapper = mapper;
            _log = log;
        }
        public async Task<IEnumerable<EmployeeDto>> Get()
        {
            var items = _employeeService.GetAllEmployee();
            return await Task.FromResult(_mapper.Map<IEnumerable<EmployeeDto>>(items));
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}