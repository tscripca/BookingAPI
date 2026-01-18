using System;
using WebApplication1;
using Xunit;
//these tests ensure that if the logic is changed later, incorrect behavior is caught immediately.
public class BookingOverlapTests
{
    [Fact]
    public void Touching_bookings_do_not_overlap()
    {
        var start1 = new DateTime(2025, 1, 1, 7, 0, 0);
        var end1 = new DateTime(2025, 1, 1, 9, 0, 0);

        var start2 = new DateTime(2025, 1, 1, 9, 0, 0);
        var end2 = new DateTime(2025, 1, 1, 11, 0, 0);

        var result = BookingOverlap.DoBookingsOverlap(
            start1, end1, start2, end2);

        Assert.False(result);
    }

    [Fact]
    public void Overlapping_bookings_return_true()
    {
        var start1 = new DateTime(2025, 1, 1, 7, 0, 0);
        var end1 = new DateTime(2025, 1, 1, 9, 0, 0);

        var start2 = new DateTime(2025, 1, 1, 8, 30, 0);
        var end2 = new DateTime(2025, 1, 1, 10, 30, 0);

        var result = BookingOverlap.DoBookingsOverlap(
            start1, end1, start2, end2);

        Assert.True(result);
    }

}
