using System;
using System.Reflection.Emit;

namespace csharpMSILMethod;

class DynamicMethodUsingMSIL
{
    public static DynamicMethod MulBy2AndAdd1()
    {
        DynamicMethod mulAndPlusIt = new(
          "mulAndPlusIt",
          typeof(int),
          new Type[] { typeof(int) },
          typeof(DynamicMethodUsingMSIL).Module
        );

        ILGenerator mp = mulAndPlusIt.GetILGenerator();
        mp.Emit(OpCodes.Ldarg_0);
        mp.Emit(OpCodes.Ldc_I4_2);
        mp.Emit(OpCodes.Mul);
        mp.Emit(OpCodes.Ldc_I4_1);
        mp.Emit(OpCodes.Add);
        mp.Emit(OpCodes.Ret);

        return mulAndPlusIt;
    }
}
