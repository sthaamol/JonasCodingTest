using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using BusinessLayer.Model.Interfaces;
using BusinessLayer.Model.Models;
using Microsoft.Extensions.Logging;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class CompanyController : ApiController
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        private readonly ILogger _log;

        public CompanyController(ICompanyService companyService, IMapper mapper, ILogger log)
        {
            _companyService = companyService;
            _mapper = mapper;
            _log = log;
        }
        // GET api/<controller>
        public async Task<IEnumerable<CompanyDto>> GetAll()
        {
            var items = _companyService.GetAllCompanies();
            return await Task.FromResult(_mapper.Map<IEnumerable<CompanyDto>>(items));
        }

        // GET api/<controller>/5
        public async Task<CompanyDto> Get(string companyCode)
        {
            var item = _companyService.GetCompanyByCode(companyCode);
            return await Task.FromResult(_mapper.Map<CompanyDto>(item));
        }

        // POST api/<controller>
        public async Task Post([FromBody] CompanyInfo info)
        {
            try
            {
                await Task.Run(() => _companyService.SaveCompany(info));
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message);
            }
        }

        // PUT api/<controller>/5
        public async Task Put([FromBody] CompanyInfo companyInfo)
        {
            try
            {
                await Task.Run(() => _companyService.SaveCompany(companyInfo));
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message);
            }
        }

        // DELETE api/<controller>/5
        public async Task Delete(string companyCode)
        {
            try
            {
                await Task.Run(() => _companyService.DeleteCompany(companyCode));
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message);
            }
        }
    }
}