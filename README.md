<p align="center">
  <img src="logo.png" width="700"/>
</p>

# Rush
Rush is a simple interactive interpreter written in C#. It's not named so because I completed this in 2 hours and 8 minutes, thats crazy talk!

Its dynamically typed (im sorry), doesn't feauture semicolons (im sorry again but I wanted to try a make a "python styled" language this time. You can check out my compiler <a href="https://github.com/kunrex/Sugar.lang">here</a>) and specialises with numbers!

## Feautures
Lets get technical. shall we?
> All lines preceeded by a `>` are input while any other line is output

#### Variables
```c#
> x = 10
10

> y = 20
20

> x + y
30
```

#### Functions
```rust
//general syntax
fn name <arguments> => <expression>

> fn echo x => x
no output

> fn add x y => x + y
no output

> add 10 echo 30
40
```

#### Conditions
> Its worth noting rush doesn't feauture booleans explicitly. It conforms to the not so standard:

> 0: true

> 1: false

```cs
//general syntax
if <condition> => <expression>

> x = 4
4

> if x > 1 && x < 10 => x + 10
14
```

#### Loops
> Rush has an execution limit of 255 statements in a while loop
```cs
//general syntax
while <condition> => <expression>
> x = 4
4

> while x < 10 => x = x + 1
5
6
7
8
9
10
```

## Further?
Now I get it, rush isn't exactly a goldmine of oppurtunity here. Keeping that in mind I am happy with how much I was able to complete in 2 hours from scratch. It might not be much but it was fun and so I consider this a win.  

Thanks for reading and I hope you like my interpreter. Have a good day!!!
