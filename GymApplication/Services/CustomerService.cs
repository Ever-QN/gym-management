using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymApplication.Data;
using Microsoft.AspNetCore.Components;
using SQLite;

namespace GymApplication.Services
{
	public class CustomerService
	{
		public SQLiteAsyncConnection con;
		string _dbPath;

		public CustomerService(string dbPath)
		{
			_dbPath = dbPath;
		}

		private async Task InitAsync()
		{
			if (con != null)
			{
				return;
			}
			con = new SQLiteAsyncConnection(_dbPath);
			await con.CreateTableAsync<CustomerInfo>();
		}

		public async Task<bool> AddUpdateCustomerAsync(CustomerInfo customerInfo)
		{
			if (customerInfo.CustomerId > 0)
			{
				await con.UpdateAsync(customerInfo);
			}
			else
			{
				await con.InsertAsync(customerInfo);
			}
			return await Task.FromResult(true);
		}

		public async Task<bool> DeleteCustomerAsync(int customerId)
		{
			await con.DeleteAsync<CustomerInfo>(customerId);
			return await Task.FromResult(true);
		}

		public async Task<CustomerInfo> GetCustomerAsync(int customerId)
		{
			return await con.Table<CustomerInfo>().Where(x => x.CustomerId == customerId).FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<CustomerInfo>> GetCustomerAsync()
		{
			await InitAsync();
			return await Task.FromResult(await con.Table<CustomerInfo>().ToListAsync());
		}
	}
}

