using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymApplication.Data;
using SQLite;

namespace GymApplication.Services
{
    public class StaffService
    {
        public SQLiteAsyncConnection con;
        string _dbPath;

        public StaffService(string dbPath)
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
            await con.CreateTableAsync<StaffInfo>();
        }

        public async Task<bool> AddUpdateStaffAsync(StaffInfo staffInfo)
        {
            if (staffInfo.StaffId > 0)
            {
                await con.UpdateAsync(staffInfo);
            }
            else
            {
                await con.InsertAsync(staffInfo);
            }
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteStaffAsync(int staffId)
        {
            await con.DeleteAsync<StaffInfo>(staffId);
            return await Task.FromResult(true);
        }

        public async Task<StaffInfo> GetStaffAsync(int staffId)
        {
            return await con.Table<StaffInfo>().Where(x => x.StaffId == staffId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<StaffInfo>> GetStaffAsync()
        {
            await InitAsync();
            return await Task.FromResult(await con.Table<StaffInfo>().ToListAsync());
        }
    }
}