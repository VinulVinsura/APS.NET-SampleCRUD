using SampleCRUD.Model;

namespace SampleCRUD.Service
{
    public interface UserService
    {

        Responce addUser(User user);
        Responce login(LoginDto loginDto);
    }
}
