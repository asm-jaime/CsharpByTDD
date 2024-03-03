using System;
using System.Collections;

namespace numberxoranvinverse;

public class Solution
{
    private static long GetLongFromBitArray(BitArray bitArray)
    {
        var array = new int[2];
        bitArray.CopyTo(array, 0);
        return (uint)array[0] + ((long)(uint)array[1] << 32);
    }

    public static long Xor(long n)
    {
        var bytes = new BitArray(BitConverter.GetBytes(n));
        var bytesInv = new BitArray(BitConverter.GetBytes(n >> 1));
        var result = bytes.Xor(bytesInv);

        return GetLongFromBitArray(result);
    }

    public static long XorInv(long number)
    {
        var degree = (int)Math.Log2(number) + 1;

        var bytes = new BitArray(BitConverter.GetBytes(number));
        var bytesMask = new BitArray(BitConverter.GetBytes(number >> 1));
        for(int i = 0; i < degree; i++)
        {
            bytes = bytes.Xor(bytesMask);
            bytesMask.RightShift(1);
        }

        return GetLongFromBitArray(bytes);
    }

    public static string NameOfXorInv()
    {
        return "";
    }
}
