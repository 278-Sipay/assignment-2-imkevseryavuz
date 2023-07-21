using Microsoft.AspNetCore.Mvc;
using SipayApi.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Transactions;
using SipayApi.Data.Domain;


namespace SipayApiProject.Controllers
{
    [ApiController]
    [Route("sipy/api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository repository;
        public TransactionController(ITransactionRepository repository)
        {
            this.repository = repository;
        }


        [HttpGet("GetByParameter")]
        public IActionResult GetByParameter(int? accountNumber, string referenceNumber,
                                        decimal? minAmountCredit, decimal? maxAmountCredit,
                                        decimal? minAmountDebit, decimal? maxAmountDebit,
                                        string description, DateTime? beginDate, DateTime? endDate)
        {
            var transactions = repository.GetByFilter(accountNumber, referenceNumber,
                                                                 minAmountCredit, maxAmountCredit,
                                                                 minAmountDebit, maxAmountDebit,
                                                                 description, beginDate, endDate);

            return Ok(transactions);

            //[HttpGet]
            //public ApiResponse<List<TransactionResponse>> GetAll()
            //{
            //    var entityList = repository.GetAll();
            //    var mapped = mapper.Map<List<Transaction>, List<TransactionResponse>>(entityList);
            //    return new ApiResponse<List<TransactionResponse>>(mapped);
            //}

            //[HttpGet("{id}")]
            //public ApiResponse<TransactionResponse> Get(int id)
            //{
            //    var entity = repository.GetById(id);
            //    var mapped = mapper.Map<Transaction, TransactionResponse>(entity);
            //    return new ApiResponse<TransactionResponse>(mapped);
            //}

            //[HttpGet("GetByReference")]
            //public ApiResponse<List<TransactionResponse>> GetByReference(string ReferenceNumber)
            //{
            //    var entityList = repository.GetByReference(ReferenceNumber);
            //    var mapped = mapper.Map<List<Transaction>, List<TransactionResponse>>(entityList);
            //    return new ApiResponse<List<TransactionResponse>>(mapped);
            //}

            //[HttpPost]
            //public ApiResponse Post([FromBody] TransactionRequest request)
            //{
            //    var entity = mapper.Map<TransactionRequest, Transaction>(request);
            //    repository.Insert(entity);
            //    repository.Save();
            //    return new ApiResponse();
            //}


        }
    }
}

