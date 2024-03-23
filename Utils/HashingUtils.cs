using System.Security.Cryptography;
using System.Text;
using MusicPlayer.MusicApi;

namespace MusicPlayer.Utils
{
    public class HashingUtils
    {
        
        public static string HashParamNoId(string path, ZingMp3Api api)
        {
            return HashingUtils.GetHmac512Hashing(
                path + HashingUtils.GetSha256Hashing(
                    $"ctime={api.Ctime}version={api.Version}"
                ),
                api.SecretKey
            );
        }
        
        public static string HashParam(string path, ZingMp3Api api, string id)
        {
            return HashingUtils.GetHmac512Hashing(
                path + HashingUtils.GetSha256Hashing(
                    $"ctime={api.Ctime}id={id}version={api.Version}"
                ),
                api.SecretKey
            );
        }
        
        public static string HashParamHome(string path, ZingMp3Api api)
        {
            return HashingUtils.GetHmac512Hashing(
                path + HashingUtils.GetSha256Hashing(
                    $"count=30ctime={api.Ctime}page=1version={api.Version}"
                ),
                api.SecretKey
            );
        }
        
        public static string HashCategoryMv(string path, ZingMp3Api api, string id, string type)
        {
            return HashingUtils.GetHmac512Hashing(
                path + HashingUtils.GetSha256Hashing(
                    $"ctime={api.Ctime}id={id}type={type}version={api.Version}"
                ),
                api.SecretKey
            );
        }

        public static string HashListMv(string path, ZingMp3Api api, string id, string type,
            string page, string count)
        {
            return HashingUtils.GetHmac512Hashing(
                path + HashingUtils.GetSha256Hashing(
                    $"count={count}ctime={api.Ctime}id={id}page={page}type={type}version={api.Version}"
                ),
                api.SecretKey
            );
        }
        
        public static string GetSha256Hashing(string text)
        {
            var bytes = Encoding.UTF8.GetBytes(text);
            var hashstring = new SHA256Managed();
            var hash = hashstring.ComputeHash(bytes);
            var hashString = string.Empty;
            foreach (var x in hash) hashString += string.Format("{0:x2}", x);
            return hashString;
        }

        public static string GetHmac512Hashing(string str, string secretKey)
        {
            var encoding = new ASCIIEncoding();
            var keyByte = encoding.GetBytes(secretKey);
            var messageBytes = encoding.GetBytes(str);
            using (var hmacsha512 = new HMACSHA512(keyByte))
            {
                var hashmessage = hmacsha512.ComputeHash(messageBytes);
                var hashString = string.Empty;
                foreach (var x in hashmessage) hashString += string.Format("{0:x2}", x);
                return hashString;
            }
        }
    }
}