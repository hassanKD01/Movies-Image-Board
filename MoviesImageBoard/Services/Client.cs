using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MoviesImageBoard.ViewModels;
using Newtonsoft.Json;

namespace MoviesImageBoard.Services
{
    public class Client : IClient
    {
        private readonly HttpClient _client;

        public Client(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("http://api");
        }

        //Get list of threads based on given filters + pagination info
        public async Task<ViewPaginatedList<ListThreadsViewModel>> GetListThreads(
            int page,int limit,
            string category,string movieName)
        {
            //send get request to api/threads and ensure success
            var response = await _client.GetAsync($"api/threads?Page={page}" +
                $"&Limit={limit}&Category={category}&MovieName={movieName}");

            response.EnsureSuccessStatusCode();

            //read json data and deserialize list of threads and custom Header data 
            var jsonString = await response.Content.ReadAsStringAsync();
            var threads = JsonConvert.DeserializeObject<List<ListThreadsViewModel>>(jsonString);
            var header = JsonConvert.DeserializeObject( response.Headers.GetValues("X-Pagination").FirstOrDefault());

            var o = header?.GetType().GetProperty("First")?.GetValue(header);
            var pageIndex  = o?.GetType().GetProperty("First")?.GetValue(o);
            o = header?.GetType().GetProperty("Last")?.GetValue(header);
            var totalPages = o?.GetType().GetProperty("First")?.GetValue(o);

            //return paginated list with list of threads , oage index and number of total pages
            return new ViewPaginatedList<ListThreadsViewModel>(threads,
               Convert.ToInt32(totalPages?.GetType().GetProperty("Value")?.GetValue(totalPages))
                , Convert.ToInt32(pageIndex?.GetType().GetProperty("Value")?.GetValue(pageIndex)));
        }

        public async Task<IEnumerable<ListThreadsViewModel>> GetThreadsByUserID(string userid)
        {
            IEnumerable<ListThreadsViewModel> model;
            var response = await _client.GetAsync($"api/threads/userthreads/{userid}");
            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();
            model = JsonConvert.DeserializeObject<IEnumerable<ListThreadsViewModel>>(jsonString);
            return model;
        }

        public async Task<ThreadViewModel> GetThreadById(int id)
        {
            ThreadViewModel model;
            var response = await _client.GetAsync($"api/threads/thread/{id}");
            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();
            model = JsonConvert.DeserializeObject<ThreadViewModel>(jsonString);
            return model;
        }

        public async Task<string> PostThread(CreateThreadViewModel model)
        {
            var jsonString = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonString.ToString(), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/threads", content);
            var responseString = await response.Content.ReadAsStringAsync();
            return responseString;
        }

        public async Task DeleteThread(int id)
        {
            var response = await _client.DeleteAsync($"api/threads/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<CommentViewModel>> GetComments()
        {
            IEnumerable<CommentViewModel> comments;
            var response = await _client.GetAsync("api/comments");
            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();
            comments = JsonConvert.DeserializeObject<IEnumerable<CommentViewModel>>(jsonString);
            return comments;
        }

        public async Task<string> PostComment(CommentCreateViewModel viewModel)
        {
            var jsonString = JsonConvert.SerializeObject(viewModel);
            var content = new StringContent(jsonString.ToString(), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/comments", content);
            var responseString = await response.Content.ReadAsStringAsync();
            return responseString;
        }

        public async Task DeleteComment(int id)
        {
            var response = await _client.DeleteAsync($"api/comments/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
