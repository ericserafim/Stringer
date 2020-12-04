![Stringer CI/CD](https://github.com/ericserafim/Stringer/workflows/Stringer%20CI/CD/badge.svg)

# Stringer
It is a set of string extensions to avoid runtime exceptions and keep the code easy to read as much as possible.

# Methods
* IsNull()
* IsNotNull()
* IsEmpty()
* IsNotEmpty()
* IsNullOrEmpty()
* IsNotNullOrEmpty()
* IsNullOrWhiteSpace()
* IsNotNullOrWhiteSpace()
* Contain("")
* NotContain("")
* In(new string[] { "1", "2", "3"})
* NotIn(new string[] { "1", "2", "3"})
* Equal("ABC", StringComparison stringComparison = StringComparison.Ordinal)
* NotEqual("ABC", StringComparison stringComparison = StringComparison.Ordinal)

# Examples
```csharp
  # It'll never throw an exception
  string source = null;
  
  var result = source.IsNull();
  var result = source.NotIsNull();
  var result = source.IsEmpty();
  var result = source.NotIsEmpty();
  var result = source.IsNullOrEmpty();
  var result = source.NotIsNullOrEmpty();
  var result = source.IsNullOrWhiteSpace();
  var result = source.NotIsNullOrWhiteSpace();
  var result = source.Contain("1");
  var result = source.NotContain("1");
  var result = source.In(new string[] { "1", "2", "3"});
  var result = source.NotIn(new string[] { "1", "2", "3"});
  var result = source.Equal("A");
  var result = source.NotEqual("A");
  var result = source.Equal("A", StringComparison.OrdinalIgnoreCase);
  var result = source.NotEqual("A", StringComparison.OrdinalIgnoreCase);
```

# How to use
```
dotnet add package EricSerafim.Stringer --version 1.0.0
```
