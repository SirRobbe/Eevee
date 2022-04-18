# Eevee
## Evolve your code generation
In many projects metaprogramming can be used to safe time by generating boilerplate code or auto
generating APIs etc. Often times the most efficient solution to the problem is to write a little custom program
to do the work instead of using some large meta programming framework. In this situations I prefer to focus
on the actual code I want to generate not its syntax or formatting. However, a somehow clean format of the produced code
can still help a lot with inspecting it, especially if it has errors.

This little library aims at making this process easier. By providing functionality to write certain constructs specific
to a given programming language you can focus on the code you want to generate and the library guarantees that your code is correctly indented and
doesn't miss braces.

## Features

Currently supported output languages are:
 - C#
 - C++

For none of the languages the API currently provides functions for the whole feature sets of the languages, but
most of my use cases are already covered.

## Installation

Either build the `eevee` project and add the library to your project or just directly add the
source files into your project.
