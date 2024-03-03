<!-- ENGLISH -->
# assembler interpreter

Write the assembler interpreter.


### Comment


Example 1

in:
```
; My first program
mov  a, 5
inc  a
call function
msg  '(5+1)/2 = ', a ; output message
end

function:
div  a, 2
ret

```
out:
```
(5+1)/2 = 3
```