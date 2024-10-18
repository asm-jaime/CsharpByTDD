<!-- ENGLISH -->
# disassembly c# code



in:
```
ildasm.exe bin\Debug\net6.0\template.dll
```
out:
```

//  .NET IL Disassembler.  Version 8.0.0



// Metadata version: v4.0.30319
.assembly extern System.Runtime
{
  .publickeytoken = (B0 3F 5F 7F 11 D5 0A 3A )                         // .?_....:
  .ver 6:0:0:0
}
.assembly extern nunit.framework
{
  .publickeytoken = (26 38 CD 05 61 07 44 EB )                         // &8..a.D.
  .ver 3:13:3:0
}
.assembly extern System.Console
{
  .publickeytoken = (B0 3F 5F 7F 11 D5 0A 3A )                         // .?_....:
  .ver 6:0:0:0
}
.assembly csharp.ILDASM
{
  .custom instance void [System.Runtime]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void [System.Runtime]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                                   63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.

  // --- The following custom attribute is added automatically, do not uncomment -------
  //  .custom instance void [System.Runtime]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [System.Runtime]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 07 01 00 00 00 00 ) 

  .custom instance void [System.Runtime]System.Runtime.Versioning.TargetFrameworkAttribute::.ctor(string) = ( 01 00 18 2E 4E 45 54 43 6F 72 65 41 70 70 2C 56   // ....NETCoreApp,V
                                                                                                              65 72 73 69 6F 6E 3D 76 36 2E 30 01 00 54 0E 14   // ersion=v6.0..T..
                                                                                                              46 72 61 6D 65 77 6F 72 6B 44 69 73 70 6C 61 79   // FrameworkDisplay
                                                                                                              4E 61 6D 65 08 2E 4E 45 54 20 36 2E 30 )          // Name..NET 6.0
  .custom instance void [System.Runtime]System.Reflection.AssemblyCompanyAttribute::.ctor(string) = ( 01 00 0D 63 73 68 61 72 70 2E 49 4C 44 41 53 4D   // ...csharp.ILDASM
                                                                                                      00 00 ) 
  .custom instance void [System.Runtime]System.Reflection.AssemblyConfigurationAttribute::.ctor(string) = ( 01 00 05 44 65 62 75 67 00 00 )                   // ...Debug..
  .custom instance void [System.Runtime]System.Reflection.AssemblyFileVersionAttribute::.ctor(string) = ( 01 00 07 31 2E 30 2E 30 2E 30 00 00 )             // ...1.0.0.0..
  .custom instance void [System.Runtime]System.Reflection.AssemblyInformationalVersionAttribute::.ctor(string) = ( 01 00 05 31 2E 30 2E 30 00 00 )                   // ...1.0.0..
  .custom instance void [System.Runtime]System.Reflection.AssemblyProductAttribute::.ctor(string) = ( 01 00 0D 63 73 68 61 72 70 2E 49 4C 44 41 53 4D   // ...csharp.ILDASM
                                                                                                      00 00 ) 
  .custom instance void [System.Runtime]System.Reflection.AssemblyTitleAttribute::.ctor(string) = ( 01 00 0D 63 73 68 61 72 70 2E 49 4C 44 41 53 4D   // ...csharp.ILDASM
                                                                                                    00 00 ) 
  .hash algorithm 0x00008004
  .ver 1:0:0:0
}
.module csharp.ILDASM.dll
// MVID: {f34ed1f1-2f07-4da7-b93c-da34866032a2}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x0000019D4AFC0000


// =============== CLASS MEMBERS DECLARATION ===================

.class private auto ansi beforefieldinit csharpILDASM.Program
       extends [System.Runtime]System.Object
{
  .method private hidebysig static void  Main(string[] args) cil managed
  {
    .entrypoint
    // Code size       60 (0x3c)
    .maxstack  3
    .locals init (int32 V_0,
             int32 V_1,
             string[] V_2,
             class csharpILDASM.Solution V_3,
             int32 V_4)
    IL_0000:  nop
    IL_0001:  call       string [System.Console]System.Console::ReadLine()
    IL_0006:  call       !!0[] [System.Runtime]System.Array::Empty<char>()
    IL_000b:  callvirt   instance string[] [System.Runtime]System.String::Split(char[])
    IL_0010:  stloc.2
    IL_0011:  ldloc.2
    IL_0012:  ldc.i4.0
    IL_0013:  ldelem.ref
    IL_0014:  call       int32 [System.Runtime]System.Int32::Parse(string)
    IL_0019:  stloc.0
    IL_001a:  ldloc.2
    IL_001b:  ldc.i4.1
    IL_001c:  ldelem.ref
    IL_001d:  call       int32 [System.Runtime]System.Int32::Parse(string)
    IL_0022:  stloc.1
    IL_0023:  newobj     instance void csharpILDASM.Solution::.ctor()
    IL_0028:  stloc.3
    IL_0029:  ldloc.3
    IL_002a:  ldloc.0
    IL_002b:  ldloc.1
    IL_002c:  callvirt   instance int32 csharpILDASM.Solution::Calculate(int32,
                                                                         int32)
    IL_0031:  stloc.s    V_4
    IL_0033:  ldloc.s    V_4
    IL_0035:  call       void [System.Console]System.Console::WriteLine(int32)
    IL_003a:  nop
    IL_003b:  ret
  } // end of method Program::Main

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [System.Runtime]System.Object::.ctor()
    IL_0006:  nop
    IL_0007:  ret
  } // end of method Program::.ctor

} // end of class csharpILDASM.Program

.class public auto ansi beforefieldinit csharpILDASM.Solution
       extends [System.Runtime]System.Object
{
  .method public hidebysig instance int32 
          Calculate(int32 a,
                    int32 b) cil managed
  {
    // Code size       9 (0x9)
    .maxstack  2
    .locals init (int32 V_0)
    IL_0000:  nop
    IL_0001:  ldarg.1
    IL_0002:  ldarg.2
    IL_0003:  add
    IL_0004:  stloc.0
    IL_0005:  br.s       IL_0007

    IL_0007:  ldloc.0
    IL_0008:  ret
  } // end of method Solution::Calculate

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [System.Runtime]System.Object::.ctor()
    IL_0006:  nop
    IL_0007:  ret
  } // end of method Solution::.ctor

} // end of class csharpILDASM.Solution

.class public auto ansi beforefieldinit csharpILDASM.SolutionTests
       extends [System.Runtime]System.Object
{
  .custom instance void [nunit.framework]NUnit.Framework.TestFixtureAttribute::.ctor() = ( 01 00 00 00 ) 
  .method public hidebysig instance void 
          TestCalculate(int32 a,
                        int32 b,
                        int32 expected) cil managed
  {
    .custom instance void [nunit.framework]NUnit.Framework.TestAttribute::.ctor() = ( 01 00 00 00 ) 
    .custom instance void [nunit.framework]NUnit.Framework.TestCaseAttribute::.ctor(object,
                                                                                    object,
                                                                                    object) = ( 01 00 08 02 00 00 00 08 02 00 00 00 08 04 00 00 
                                                                                                00 00 00 ) 
    .custom instance void [nunit.framework]NUnit.Framework.TestCaseAttribute::.ctor(object,
                                                                                    object,
                                                                                    object) = ( 01 00 08 00 00 00 00 08 00 00 00 00 08 00 00 00 
                                                                                                00 00 00 ) 
    // Code size       35 (0x23)
    .maxstack  3
    .locals init (class csharpILDASM.Solution V_0,
             int32 V_1)
    IL_0000:  nop
    IL_0001:  newobj     instance void csharpILDASM.Solution::.ctor()
    IL_0006:  stloc.0
    IL_0007:  ldloc.0
    IL_0008:  ldarg.1
    IL_0009:  ldarg.2
    IL_000a:  callvirt   instance int32 csharpILDASM.Solution::Calculate(int32,
                                                                         int32)
    IL_000f:  stloc.1
    IL_0010:  ldarg.3
    IL_0011:  box        [System.Runtime]System.Int32
    IL_0016:  ldloc.1
    IL_0017:  box        [System.Runtime]System.Int32
    IL_001c:  call       void [nunit.framework]NUnit.Framework.Assert::AreEqual(object,
                                                                                object)
    IL_0021:  nop
    IL_0022:  ret
  } // end of method SolutionTests::TestCalculate

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [System.Runtime]System.Object::.ctor()
    IL_0006:  nop
    IL_0007:  ret
  } // end of method SolutionTests::.ctor

} // end of class csharpILDASM.SolutionTests


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
// WARNING: Created Win32 resource file IL.ASM.res

```
