# Regular expressions exercise

## Objective

Illustrate how to use regular expressions. In this exercise, you will parse a given CSV file (market data of gold prices).

## Setup

* ``MarketDataReader.cs`` reads a given CSV file line-by-line. This data shall be transformed to a List of MarketDay objects, if the data can be parsed.
* ``MarketDay.cs`` is used for parsing a string into market day data.
* ``ParsingExtensions.cs`` provides an extension method of parsing a string to a decimal using decimal point instead of comma.

## Tasks

* Complete the ``TryParse`` method in ``MarketDay.cs``. Here, you return a bool that illustrates if the given string was able to be passed correctly into a market day object. You are invited to use the ``ParsingExtensions.cs`` for parsing a string to a decimal. Use the provided unit tests to check your implementation.
* Complete the ``Reader`` method in ``MarketDataReader``. Hereby, you are invited to use LINQ in combination with the just implemented ``TryParse`` function. Use the provided unit tests to check your implementation.