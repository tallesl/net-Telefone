# Telefone

[![][build-img]][build]
[![][nuget-img]][nuget]

Checks for [Brazilian telephone numbers] in the following formats:

* `AANNNNNNNN`;
* `AA9NNNNNNNN`;
* `AA NNNNNNNN`;
* `AA 9NNNNNNNN`;
* `AA NNNN-NNNN`;
* `AA 9NNNN-NNNN`.

[build]:                       https://ci.appveyor.com/project/TallesL/net-Telefone
[build-img]:                   https://ci.appveyor.com/api/projects/status/github/tallesl/net-Telefone?svg=true
[nuget]:                       https://www.nuget.org/packages/Telefone
[nuget-img]:                   https://badge.fury.io/nu/Telefone.svg
[Brazilian telephone numbers]: https://en.wikipedia.org/wiki/Telephone_numbers_in_Brazil

## Usage

```cs
using TelefoneLibrary;

// a parsed Brazilian cellphone number
var cellphone = Telefone.Parse("11 98765-4321");

// a landline one
var landlinePhone = Telefone.Parse("11 2345-6789");

// null is returned for invalid numbers
var invalid = Telefone.Parse("text");
```