# Serialization exercise

## Objective

Illustrate the benefits of asynchronous programming principles.

## Setup

The given WPF GUI compares a synchronous, asynchronous and parallelized asynchronous execution of 6 tasks.
The synchronous version has already been provided.

## Tasks

All functionalities associated with the buttons from the GUI are provided in ``ViewModel.cs``. Your task is to:

* Check the synchronous version. Notice: During execution, the program freezes (you cannot see any progress or move/resize the window)
* Complete the ``StartAsyncTasksExecuted`` method
* Complete the ``StartAsyncParallelTasksExecuted`` method