using WebApplication1.Dtos;

namespace WebApplication1.Services
{
//Why an interface?
// -> decoupling
// -> testability
// -> real-world pattern
    public interface IBookingService
    {
        Task<BookingResponseDto> CreateAsync(BookingCreateDto dto, int userId);
    }
}
