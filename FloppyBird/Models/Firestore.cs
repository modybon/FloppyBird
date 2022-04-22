using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Auth;
using Plugin.CloudFirestore;

namespace FloppyBird.Models
{
    public class Firestore
    {
        // Key to Access the Database From Firebase
        private string _webApiKey = "AIzaSyCrOIB7bsTx218JLcxsHCWymOTzJBI4ToM";
        public static string Message;
        private FirebaseAuthProvider authProvider;
        public static User CurrentUser;

        public Firestore()
        {
            // Allows to access Firebase Features.
            authProvider = new FirebaseAuthProvider(new FirebaseConfig(_webApiKey));
        }

        public static async Task<bool> CreateUserAsync(string userName, string email, string password)
        {
            Firestore fire = new Firestore();
            // todo: Try to do this with promises or TaskCompletionSource ;
            //TaskCompletionSource<String> tcs = new TaskCompletionSource<String>();
            User user = new User() { HighScore = 90, UserName = userName, Purchases = new List<string>() };
            try
            {
                // Takes User Inputs and Creates a new User With it.
                var auth = await fire.authProvider.CreateUserWithEmailAndPasswordAsync(email, password);
                // Creates a Document for that User in "Users" Collection. 
                var document = await CrossCloudFirestore.Current
                         .Instance
                         .Collection("Users")
                         .AddAsync(new { UserName = user.UserName, HighScore = user.HighScore, Purchases = user.Purchases, uid = auth.User.LocalId });
                return true;
            }
            catch (Exception ex)
            {
                // Error Message
                Message = ex.Message;
                return false;
            }

        }

        public static async Task<bool> SignInUser(string email, string password)
        {
            Firestore fire = new Firestore();
            // Sign a User in with their Email and Password. 
            try
            {
                await fire.authProvider.SignInWithEmailAndPasswordAsync(email, password);
                return true;
            }
            catch (Exception ex)
            {
                // if Sign In fails the user gets back a message to explain why. 
                Message = ex.Message;
                return false;
            }
        }

        public static async Task<bool> CheckUserNameExist(string userName)
        {
            Firestore fire = new Firestore();
            // Checks if there's any user using this UserName if it exist it returns 
            var collection = await CrossCloudFirestore
                .Current.Instance
                .Collection("Users")
                .WhereEqualsTo("UserName", userName)
                .GetAsync();
            var userNameUsed = collection.IsEmpty;
            // if user name exists return true otherwise return false
            //await getUserInfoTest();
            if (userNameUsed)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // gets all the users that have a highscore higher than 0
        public static async Task<IEnumerable<User>> getUserList()
        {
            var users = await CrossCloudFirestore.Current
                                        .Instance
                                        .Collection("Users")
                                        .WhereGreaterThan("HighScore", 0)
                                        .OrderBy("HighScore", true)
                                        .GetAsync();
            var count = users.Count;
            var usersWithHighScore = users.ToObjects<User>();
            return usersWithHighScore;
        }
    }
}
