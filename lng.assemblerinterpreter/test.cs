using NUnit.Framework;
using System;

namespace lngassemblerinterpreter;


[TestFixture]
public class AssemblerInterpreterTest
{
    private static string[] expected = {"(5+1)/2 = 3",
                                        "5! = 120",
                                        "Term 8 of Fibonacci series is: 21",
                                        "mod(11, 3) = 2",
                                        "gcd(81, 153) = 9",
                                        null,
                                        "2^10 = 1024"};

    [Test]
    public void TestSimple()
    {
        for(int i = 0; i < expected.Length; i++)
        {
            Assert.That(AssemblerInterpreter.Interpret(displayProg(progs[i])), Is.EqualTo(expected[i]));
        }
    }

    private static string[] progs = {
            "\n; My first program\nmov  a, 5\ninc  a\ncall function\nmsg  '(5+1)/2 = ', a    ; output message\nend\n\nfunction:\n    div  a, 2\n    ret\n",
            "\nmov   a, 5\nmov   b, a\nmov   c, a\ncall  proc_fact\ncall  print\nend\n\nproc_fact:\n    dec   b\n    mul   c, b\n    cmp   b, 1\n    jne   proc_fact\n    ret\n\nprint:\n    msg   a, '! = ', c ; output text\n    ret\n",
            "\nmov   a, 8            ; value\nmov   b, 0            ; next\nmov   c, 0            ; counter\nmov   d, 0            ; first\nmov   e, 1            ; second\ncall  proc_fib\ncall  print\nend\n\nproc_fib:\n    cmp   c, 2\n    jl    func_0\n    mov   b, d\n    add   b, e\n    mov   d, e\n    mov   e, b\n    inc   c\n    cmp   c, a\n    jle   proc_fib\n    ret\n\nfunc_0:\n    mov   b, c\n    inc   c\n    jmp   proc_fib\n\nprint:\n    msg   'Term ', a, ' of Fibonacci series is: ', b        ; output text\n    ret\n",
            "\nmov   a, 11           ; value1\nmov   b, 3            ; value2\ncall  mod_func\nmsg   'mod(', a, ', ', b, ') = ', d        ; output\nend\n\n; Mod function\nmod_func:\n    mov   c, a        ; temp1\n    div   c, b\n    mul   c, b\n    mov   d, a        ; temp2\n    sub   d, c\n    ret\n",
            "\nmov   a, 81         ; value1\nmov   b, 153        ; value2\ncall  init\ncall  proc_gcd\ncall  print\nend\n\nproc_gcd:\n    cmp   c, d\n    jne   loop\n    ret\n\nloop:\n    cmp   c, d\n    jg    a_bigger\n    jmp   b_bigger\n\na_bigger:\n    sub   c, d\n    jmp   proc_gcd\n\nb_bigger:\n    sub   d, c\n    jmp   proc_gcd\n\ninit:\n    cmp   a, 0\n    jl    a_abs\n    cmp   b, 0\n    jl    b_abs\n    mov   c, a            ; temp1\n    mov   d, b            ; temp2\n    ret\n\na_abs:\n    mul   a, -1\n    jmp   init\n\nb_abs:\n    mul   b, -1\n    jmp   init\n\nprint:\n    msg   'gcd(', a, ', ', b, ') = ', c\n    ret\n",
            "\ncall  func1\ncall  print\nend\n\nfunc1:\n    call  func2\n    ret\n\nfunc2:\n    ret\n\nprint:\n    msg 'This program should return null'\n",
            "\nmov   a, 2            ; value1\nmov   b, 10           ; value2\nmov   c, a            ; temp1\nmov   d, b            ; temp2\ncall  proc_func\ncall  print\nend\n\nproc_func:\n    cmp   d, 1\n    je    continue\n    mul   c, a\n    dec   d\n    call  proc_func\n\ncontinue:\n    ret\n\nprint:\n    msg a, '^', b, ' = ', c\n    ret\n"};



    private string displayProg(string p)
    {
        Console.WriteLine("\n----------------------\n");
        Console.WriteLine(p);
        return p;
    }

    //[Test]
    public void TestLarge()
    {
        var program = "\n; My first program\nmov  a, 5\ninc  a\nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \nmsg  '(5+1)/2 = ', a    \ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ninc  a\ncall function\nmsg  '(5+1)/2 = ', a    ; output message\nend\n\nfunction:\n    div  a, 2\n    ret\n";

        Assert.That(AssemblerInterpreter.Interpret(program), Is.EqualTo("(5+1)/2 = 71"));
    }

    //[Test]
    public void TestFibo()
    {
        var program = "mov   a, 2            ; value1\nmov   b, 10           ; value2\nmov   c, a            ; temp1\nmov   d, b            ; temp2\ncall  proc_func\ncall  print\nend\n\nproc_func:\ncmp   d, 1\nje    continue\nmul   c, a\ndec   d\ncall  proc_func\n\ncontinue:\nret\n\nprint:\nmsg a, '^', b, ' = ', c\nret\n";

        Assert.That(AssemblerInterpreter.Interpret(program), Is.EqualTo("2^10 = 1024"));
    }

    [Test]
    public void TestRandom()
    {
        var program = "mov g, 14   ; instruction mov g, 14\nmov i, 15   ; instruction mov i, 15\ncall func\nmsg 'Random result: ', k\nend\nfunc:\n  cmp g, i\n  jge exit\n  mov k, g\n  div k, i\n  ret\n; Do nothing\nexit:\n  msg 'Do nothing'";

        Assert.That(AssemblerInterpreter.Interpret(program), Is.EqualTo("Random result: 0"));
    }
}
