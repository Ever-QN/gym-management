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
	public class MemberService
	{
		public SQLiteAsyncConnection con;
		string _dbPath;

		public MemberService(string dbPath)
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
			await con.CreateTableAsync<MembershipInfo>();
		}

		public async Task<bool> AddUpdateMemberAsync(MembershipInfo memberInfo)
		{
			if (memberInfo.CustomerId > 0)
			{
				await con.UpdateAsync(memberInfo);
			}
			else
			{
				await con.InsertAsync(memberInfo);
			}
			return await Task.FromResult(true);
		}

		public async Task<bool> DeleteMemberAsync(int memberId)
		{
			await con.DeleteAsync<MembershipInfo>(memberId);
			return await Task.FromResult(true);
		}

		public async Task<MembershipInfo> GetMemberAsync(int customerId)
		{
			return await con.Table<MembershipInfo>().Where(x => x.CustomerId == customerId).FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<MembershipInfo>> GetMemberAsync()
		{
			await InitAsync();
			return await Task.FromResult(await con.Table<MembershipInfo>().ToListAsync());
		}
	}
}