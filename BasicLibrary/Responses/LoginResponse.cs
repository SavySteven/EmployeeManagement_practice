

namespace BasicLibrary.Responses
{
    public record LoginResponse(bool Flag, string Message = null!, string token = null!, string refreshToken = null!);
}
