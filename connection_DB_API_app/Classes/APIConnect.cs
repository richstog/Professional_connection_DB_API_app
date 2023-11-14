using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace connection_DB_API_app.Classes
{
    public class APIConnect
    {
        static HttpClient api = new HttpClient();
        static string url = "https://localhost:7219/api/";

        private static string generateGeneralUrl(string object_name)
        {
            return url + object_name;
        }

        public static List<T> getAll<T>()
        {
            string result = api.GetStringAsync(generateGeneralUrl(typeof(T).Name)).Result;
            List<T> objs_result = JsonConvert.DeserializeObject<List<T>>(result);
            return objs_result;
        }

        public static T getOne<T>(int id)
        {
            string result = api.GetStringAsync(generateGeneralUrl(String.Format("{0}/{1}", typeof(T).Name, id))).Result;
            T obj_result = JsonConvert.DeserializeObject<T>(result);
            return obj_result;
        }

        public static bool delete<T>(int id)
        {
            try {
                HttpResponseMessage result = api.DeleteAsync(generateGeneralUrl(String.Format("{0}/{1}", typeof(T).Name, id))).Result;
                if (result.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static void createOne<T>(T new_obj)
        {
            try {

                var result_json = JsonConvert.SerializeObject(new_obj, Formatting.Indented);
                HttpContent content = new StringContent(result_json, Encoding.UTF8, "application/json");
                Console.WriteLine(content.ReadAsStringAsync().Result);
                var request = api.PostAsync(generateGeneralUrl(typeof(T).Name), content).Result;

                Console.WriteLine(request.Content.ReadAsStringAsync().Result);
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
