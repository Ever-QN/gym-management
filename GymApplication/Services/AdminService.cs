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

		public async Task<bool> DeleteAdminAsync(int AdminId)
		{
			await con.DeleteAsync<AdminInfo>(AdminId);
            return await Task.FromResult(true);
		}

		public async Task<AdminInfo> GetAdminInfoAsync(int AdminId) 
        {
            return await con.Table<AdminInfo>().Where(x => x.AdminId == AdminId).FirstOrDefaultAsync();
        }

		public async Task<IEnumerable<AdminInfo>> GetAdminInfoAsync()
		{
            await InitAsync();
            return await Task.FromResult(await con.Table<AdminInfo>().ToListAsync());
		}
	}
}
