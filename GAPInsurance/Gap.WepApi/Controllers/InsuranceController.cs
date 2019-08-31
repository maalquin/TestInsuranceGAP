using Gap.DataAccess.Repositories;
using Gap.Domain;
using Gap.WepApi.Common;
using Gap.WepApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Gap.WepApi.Controllers
{
    public class InsuranceController : ApiController
    {

        private readonly ICoverTypePolicyRepository<GAPCoverTypePolicy> _covertTypePolicyRepository;
        private readonly ITypeRiksRepository<GAPTypeRisk> _typeRiskRepository;
        private readonly IPoliciesRepository<GAPPolicies> _policiesRepository;
        private readonly ICustomerRepository<GAPCustomerPolicy> _customerRepository;

        public InsuranceController(
            ICoverTypePolicyRepository<GAPCoverTypePolicy> coverTypePolicyRepository,
            ITypeRiksRepository<GAPTypeRisk> typeRiskRepository,
            IPoliciesRepository<GAPPolicies> policiesRepository,
            ICustomerRepository<GAPCustomerPolicy> customerRepository
            )
        {
            _covertTypePolicyRepository = coverTypePolicyRepository;
            _typeRiskRepository = typeRiskRepository;
            _policiesRepository = policiesRepository;
            _customerRepository = customerRepository;
        }
        /// <summary>
        /// Get CovertType of Policies.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage CoverTypePolicy()
        {
            var coverTypePolicies = _covertTypePolicyRepository.GetAll();
           
            return Request.CreateResponse(HttpStatusCode.OK, coverTypePolicies.Select(x => x.ToModel()));
        }

        [HttpGet]
        public HttpResponseMessage TypeOfRisk()
        {
            var riskPolicies = _typeRiskRepository.GetAll();

            return Request.CreateResponse(HttpStatusCode.OK, riskPolicies.Select(x => x.ToModel()));
        }

        [HttpGet]
        public HttpResponseMessage GetPolicies()
        {
            var policies = _policiesRepository.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, policies.Select(x => x.ToModel()));
        }

      
        [HttpPost]
        public async Task<IHttpActionResult> InsertUpdate(PolicyModel policyModel)
        {
            if (policyModel.PolicyId != null)
                return BadRequest("Cannot add policy as it already has an id.");

            await _policiesRepository.InsertOrUpdate(policyModel.ToEntity());

            return StatusCode(HttpStatusCode.Created);
        }
        [HttpGet]
        public HttpResponseMessage GetCustomers()
        {
            var customer = _customerRepository.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, customer.Select(x => x.ToModel()));
        }


    }
}
