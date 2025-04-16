using MAUI101.Maui.Data_Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI101.Maui.Services
{
    public class LocalDbService
    {
        // In real app move this to a config file.
        private const string DbName = "maui101db.db3";
        private readonly SQLiteAsyncConnection _db;

        public LocalDbService()
        {
            _db = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DbName));
            _db.CreateTableAsync<User>();
			_db.CreateTableAsync<AdoptionForm>();
		}

        public async Task<User> GetUser(string username)
        {
            return await _db.Table<User>().Where(u => u.Username == username).FirstOrDefaultAsync();
        }

        public async Task<int> AddUser(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return -1;
            }

            return await _db.InsertAsync(new User { Username = username, Password = password });
        }

        public async Task<int> AddAdoptionForm(AdoptionForm form)
        {
			return await _db.InsertAsync(form);
		}

		public async Task<List<AdoptionForm>> GetUserAdoptionForms(string username)
		{
			return await _db.Table<AdoptionForm>().Where(u => u.UserName == username).ToListAsync();
		}

		public async Task<int> DeleteAllForms()
		{
            return await _db.DeleteAllAsync<AdoptionForm>();
		}
	}
}
