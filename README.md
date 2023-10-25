# Overview

This is a .NET MAUI app that uses [this data set](https://www.kaggle.com/datasets/cprosser3/wordle-5-letter-words) to create a similar experience to Wordle.

There are some subtle differences between this version and the official Wordle game. Most notably, there are five guesses as opposed to six, and the user is allowed to guess any five letter combination regardless of whether it is a valid English word.

# Notes

Currently, the data set stored in the project is not accessed by the code. As such, forking this repository will not create a functional version. I have had difficulty acccessing this data due to the varying storage systems across iOS, Android, Windows, and MacOS that are accommodated through MAUI. I am hopeful that this issue will be resolved in the future.

Due to the small scale of this application, there is some repeated code that does not reflect my standards of scalable code, and also violates DRY(Don't Repeat Yourself) principles.
