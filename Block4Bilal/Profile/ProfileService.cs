using SQLite;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;

namespace Block4Bilal.Profile
{
    public class ProfileService
    {
        private readonly SQLiteAsyncConnection _database;

        public ProfileService()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "userprofiles.db3");
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Profile>().Wait();
        }

        public async Task<int> SaveProfileAsync(Profile profile)
        {
            if (profile.Id == 0)
            {
                return await _database.InsertAsync(profile);
            }
            else
            {
                return await _database.UpdateAsync(profile);
            }
        }

        public Task<int> DeleteProfileAsync(Profile profile)
        {
            return _database.DeleteAsync(profile);
        }


        public async Task<ObservableCollection<Profile>> GetAllProfilesAsync()
        {
            var profiles = await _database.Table<Profile>().ToListAsync();
            return new ObservableCollection<Profile>(profiles);
        }


        public Task<Profile> GetProfileByIdAsync(int id)
        {
            return _database.Table<Profile>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }
    }

}
