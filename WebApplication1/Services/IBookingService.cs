using BookingAPI.Dtos;

namespace BookingAPI.Services
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
