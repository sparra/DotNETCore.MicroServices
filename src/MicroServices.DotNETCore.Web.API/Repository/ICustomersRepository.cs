using MicroServices.DotNETCore.Domain.CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServices.DotNETCore.Web.API.Repository
{
    public interface ICustomersRepository
    {
        Task<List<Customer>> GetCustomersAsync();

        Task<Customer> GetCustomerAsync(int id);

        Task<Customer> InsertCustomerAsync(Customer customer);
        Task<bool> UpdateCustomerAsync(Customer customer);
        Task<bool> DeleteCustomerAsync(int id);
        Task<List<State>> GetStatesAsync();
    }
}
