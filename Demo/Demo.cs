using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDemo
{
    public class Demo<T>
    {
        public ListOfUsersDTO GetUsers(String endpoint)
        {


            var user = new APIHelper<ListOfUsersDTO>();
            var url = user.SetUrl(endpoint);
            var request = user.CreateGetRequest();
            var response = user.GetResponse(url, request);
            ListOfUsersDTO content = user.GetContent<ListOfUsersDTO>(response);
            return content;

            // var restClient =new RestClient("https://reqres.in");
            // var restrequest = new RestRequest("/api/users?page=2", Method.GET);
            // restrequest.AddHeader("Accept", "application/json");
            // restrequest.RequestFormat = DataFormat.Json;
            //IRestResponse response = restClient.Execute(restrequest);
            // var content = response.Content;
            // var users = JsonConvert.DeserializeObject<ListOfUsersDTO>(content);
            // return users;
        }
        public CreateUserDTO CreateUser(String endpoint, dynamic payload)
        {
            var user = new APIHelper<CreateUserDTO>();
            var url = user.SetUrl(endpoint);
            var jsonRequest = user.Serialize(payload);
            var request = user.CreatePostRequest(jsonRequest);
            var response = user.GetResponse(url, request);
            CreateUserDTO content = user.GetContent<CreateUserDTO>(response);
            return content;
        }



    }
}
