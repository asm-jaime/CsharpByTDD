.assembly extern System.Runtime
{
  .ver 6:0:0:0
}
.assembly extern System.Console
{
  .ver 6:0:0:0
}
.assembly csharp.ILASM{}
.module csharp.ILASM.dll
.class private auto Program
{
  .method private static void main(string[] args) cil managed
  {
    .entrypoint
    ldstr      "this is Intermediate Language ASM"
    call       void [System.Console]System.Console::WriteLine(string)
    ret
  }
}