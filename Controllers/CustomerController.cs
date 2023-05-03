using APIII.Models;
using APIII.ViewModel;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace APIII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IRepository _repository;

        public CustomerController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("GetAllCustomers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            try
            {
                var results = await _repository.GetAllCustomersAsync();
                return Ok(results);
            }
            catch (Exception)
            {
                return StatusCode(500,"Internal Server Error. Please contact support.");
            }
        }

        [HttpGet]
        [Route("GetCustomer/{custId}")]
        public async Task<IActionResult> GetCustomerAsync(int custId)
        {
            try
            {
                var result = await _repository.GetCustomerAsync(custId);

                if (result == null) return NotFound("Customer does not exist");

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error. Please contact support");
            }
        }

        [HttpPost]
        [Route("AddCustomer")]
        public async Task<IActionResult> AddCustomer(CustomerViewModel cvm)
        {
            var customer = new Customer { LastName = cvm.LastName, FirstName = cvm.FirstName, Address = cvm.Address, City = cvm.City, State = cvm.State, PostalCode = cvm.PostalCode, PhoneNumber = cvm.PhoneNumber };

            try
            {
                _repository.Add(customer);
                await _repository.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest("Invalid transaction");
            }

            return Ok(customer);
        }

        [HttpPut]
        [Route("EditCustomer/{custId}")]
        public async Task<ActionResult<CustomerViewModel>> EditCustomer(int custId, CustomerViewModel customerModel)
        {
            try
            {
                var existingCustomer = await _repository.GetCustomerAsync(custId);
                if (existingCustomer == null) return NotFound($"The customer does not exist");

                existingCustomer.LastName = customerModel.LastName;
                existingCustomer.FirstName = customerModel.FirstName;
                existingCustomer.Address = customerModel.Address;
                existingCustomer.City = customerModel.City;
                existingCustomer.State = customerModel.State;
                existingCustomer.PostalCode = customerModel.PostalCode;
                existingCustomer.PhoneNumber = customerModel.PhoneNumber;

                if (await _repository.SaveChangesAsync())
                {
                    return Ok(existingCustomer);
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error. Please contact support.");
            }
            return BadRequest("Your request is invalid.");
        }

        [HttpDelete]
        [Route("DeleteCustomer/{custId}")]
        public async Task<IActionResult> DeleteCustomer(int custId)
        {
            try
            {
                var existingCustomer = await _repository.GetCustomerAsync(custId);

                if (existingCustomer == null) return NotFound($"The customer does not exist");

                _repository.Delete(existingCustomer);

                if (await _repository.SaveChangesAsync()) return Ok(existingCustomer);

            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error. Please contact support.");
            }
            return BadRequest("Your request is invalid.");
        }


    }
}
