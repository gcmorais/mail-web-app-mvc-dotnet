using mail_web_app.Models;

namespace mail_web_app.Services.SectionService
{
    public interface ISectionInterface
    {
        UserModel FindSection();
        void CreateSection(UserModel user);
        void RemoveSection();
    }
}
