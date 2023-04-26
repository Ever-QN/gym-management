using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymApplication.Data;
using SQLite;

namespace GymApplication.Services
{
    public class AdminService
    {
        public SQLiteAsyncConnection con;
        string _dbPath;

        public AdminService(string dbPath)
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
            await con.CreateTableAsync<AdminInfo>();
        }

        public async Task<bool> AddUpdateAdminAsync(AdminInfo adminInfo)
        {
            if (adminInfo.AdminId > 0)
            {
                await con.UpdateAsync(adminInfo);
            }
            else
            {
                await con.InsertAsync(adminInfo);
            }
            return await Task.FromResult(true);
        }

		public async Task<bool> DeleteAdminAsync(int adminId)
		{
			await con.DeleteAsync<AdminInfo>(adminId);
            return await Task.FromResult(true);
		}

		public async Task<AdminInfo> GetAdminAsync(int adminId) 
        {
            return await con.Table<AdminInfo>().Where(x => x.AdminId == adminId).FirstOrDefaultAsync();
        }

		public async Task<IEnumerable<AdminInfo>> GetAdminAsync()
		{
            await InitAsync();
            return await Task.FromResult(await con.Table<AdminInfo>().ToListAsync());
		}
	}
}
