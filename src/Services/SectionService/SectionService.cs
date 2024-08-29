using mail_web_app.Models;
using Newtonsoft.Json;

namespace mail_web_app.Services.SectionService
{
    public class SectionService : ISectionInterface
    {

        private readonly IHttpContextAccessor _httpContextAccessor;

        public SectionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void CreateSection(UserModel user)
        {
            string userJson = JsonConvert.SerializeObject(user);
            _httpContextAccessor.HttpContext.Session.SetString("active-user", userJson);
        }

        public UserModel FindSection()
        {
            string userSection = _httpContextAccessor.HttpContext.Session.GetString("active-user");

            if(userSection == null)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<UserModel>(userSection);
        }

        public void RemoveSection()
        {
            _httpContextAccessor.HttpContext.Session.Remove("active-user");
        }
    }
}
