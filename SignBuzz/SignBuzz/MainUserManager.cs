using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
namespace SignBuzz
{
    public class MainUserManager
    {
        static MainUserManager defaultInstance = new MainUserManager();
        MobileServiceClient client;
        IMobileServiceTable<User> userTable;
        private MainUserManager()
        {
            this.client = new MobileServiceClient("https://signbuzz.azurewebsites.net");
            this.userTable = client.GetTable<User>();
        }

        public static MainUserManager DefaultManager
        {
            get
            {
                return defaultInstance;
            }
            private set
            {
                defaultInstance = value;
            }
        }

        public MobileServiceClient CurrentClient
        {
            get { return client; }
        }
        public IMobileServiceTable<User> CurrentUserTable
        {
            get { return userTable; }
        }
        public async Task SaveUserAsync(User user)
        {
            try
            {
              await userTable.InsertAsync(user);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Save error: {0}", new[] { e.Message });
            }
        }
    }
}
