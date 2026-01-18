namespace WebApplication1
{
    public static class BookingOverlap
    {
        public static bool DoBookingsOverlap(
            DateTime start1,
            DateTime end1,
            DateTime start2,
            DateTime end2)
        {
            return start1 < end2 && end1 > start2;
        }
    }

}
