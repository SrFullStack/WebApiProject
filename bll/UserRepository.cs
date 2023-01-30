using Entitiy;
using System.Text.Json;


namespace T_Repository

{

    public class UserRepository : IUserRepository
    {
        private readonly UserContext _userContext;
        public UserRepository(UserContext userContext)
        {
            _userContext = userContext;


        }
        string path = "./userdata.txt";
        async public Task<UserTable> Get(string nameuser, int password)
        {
            var userQuery = (from user in _userContext.UserTables
                             where user.Password == password && user.Nameuser == nameuser
                             select user).ToArray<UserTable>();
            return userQuery.FirstOrDefault();


        }

        async public Task<UserTable> Post(UserTable user)
        {

            await _userContext.UserTables.AddAsync(user);
            await _userContext.SaveChangesAsync();
            return user;

        }

        public async Task<UserTable> Put(int userid, UserTable user)
        {

            //var update = await _userContext.UserTables.FindAsync(userid);
            //if (update == null)
            //{

            //    return null;
            //}
            //_userContext.Entry(update).CurrentValues.SetValues(user);

            //await _userContext.SaveChangesAsync();
            //return user;
            _userContext.UserTables.Update(user);
            await _userContext.SaveChangesAsync();
            return user;
        } 

    }
}