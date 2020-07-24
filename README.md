# examples-git

An example repository for trying out some specific scenarios.

This is meant to present some more rare scenarios, such as `git bisect`.

Note: the development of this repo was done under Windows, so it will probably not work out of the box under Linux.

## Background

The initial author of this repository found an useful scenario of applying git bisect and wrote [a blog post about it](https://dezgusty.github.io/git-bisect-with-unit-tests/). It may not be very easy to follow, therefore this repository was created to also allow users to try it on first-hand.

## Examples

### Unit tests

There is a project named `sample-proj-mstest`. This is an MS Unit Test project. To run it, you shall need some version of .NET Core.
Tested and working with `.NET Core 2.1`.

There is a batch file to build and execute the unit tests from the command line.
See `scripts/buildandruntest.bat`.

### Git pickaxe

Try the git pickaxe operator on the phrase: "Description for git pickaxe".
Or "GetFirstRepetitionInterval".

E.g.

```sh
git log -S GetFirstRepetitionInterval
```
