using System;

namespace Restaurant
{
    public class XorShiftRandom
    {
        private const double DOUBLE_UNIT = 1.0 / (int.MaxValue + 1.0);

        private ulong x_;
        private ulong y_;

        public XorShiftRandom()
        {
            x_ = (ulong)Guid.NewGuid().GetHashCode();           //rożnego ziarna, funkcja haszująca giuda,https://stackoverflow.com/questions/7326593/guid-gethashcode-uniqueness
            y_ = (ulong)Guid.NewGuid().GetHashCode();
        }
        public XorShiftRandom(ulong seed)
        {
            x_ = seed << 3; x_ = seed >> 3;
        }

        public double NextDouble()
        {

            ulong temp_x = y_;
            x_ ^= x_ << 23;
            ulong temp_y = x_ ^ y_ ^ (x_ >> 17) ^ (y_ >> 26);

            ulong temp_z = temp_y + y_;

            var value = DOUBLE_UNIT * (0x7FFFFFFF & temp_z);

            x_ = temp_x;
            y_ = temp_y;

            return value;
        }
    }
}
